<template>

    <div class="p-3">

        <!-- PAGE TITLE  -->

        <div class="card">
            <div class="card-header">
                <div class="d-flex justify-content-between align-items-center">
                    <span class="page-title">List of Categories</span>
                    <button class="btn btn-info" v-on:click="newBtn"><i class="fa fa-plus mr-2" aria-hidden="true"></i> New</button>
                </div>
            </div>
            <div class="card-body">
                <!-- DATA FILTERS -->
                <DataFilterComponent @searchedValue="searchBtn" @listLimits="limitList"></DataFilterComponent>
                <!-- DATA TABLES -->
                <v-client-table class="mt-2"
                    :data="data_table"
                    :columns="data_columns"
                    :options="data_options">
                    <template slot="action" slot-scope="props">
                        <button v-on:click="editBtn(props)" class="btn btn-success">Edit</button>
                        <!-- <button v-on:click="deleteBtn(props)" class="btn btn-danger">Delete</button> -->
                    </template>
                    <template slot="status" slot-scope="props">
                        <div class="custom-control custom-switch custom-switch-off-danger custom-switch-on-success">
                            <input type="checkbox" class="custom-control-input" id="customSwitch3" :checked="props.row.status === 0">
                                <label class="custom-control-label" for="customSwitch3"></label>
                            </div>
                    </template>
                </v-client-table>
            </div>
        </div>



        <!-- MODAL -->

        <div class="modal" id="modal-entry">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <span v-if="!isUpdate">New</span>
                        <span v-else>Edit</span>
                    </div>
                    <div class="modal-body">
                        <label>Category Name</label>
                        <input type="text" class="form-control" v-model="values.name">
                        <div class="text-danger" v-if="errors['inputCategory.Name']">{{ errors['inputCategory.Name'][0] }}</div>

                        <label>Description</label>
                        <input type="text" class="form-control" v-model="values.description">
                        <div class="text-danger" v-if="errors['inputCategory.Description']">{{ errors['inputCategory.Description'][0] }}</div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" v-on:click="saveBtn">Save</button>
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>   
</template>

<script>

import DataFilterComponent from './DataFiltersComponent.vue';

export default {
    props : ['data'],
    data() {
        return {
            errors : [],
            values : [],
            data_table : [],
            data_columns : ['name', 'description', 'status','action'],
            data_options : {
                    headings : {
                        name : 'Names',
                        description : 'Description',
                        status : 'Status',
                        action : 'Action'
                    },
                    filterable : false,
            },
            isUpdate: false,
        }
    },
    components : {
        DataFilterComponent,
    },
    methods: {
        messageBox(title, text, type, reload = false) {
            this.$fire({
                title,
                text,
                type
            }).then(() => {
                if(reload) {
                   location.reload();
                }
            })
        },
        searchBtn(value) {
            let searchValue = value;

            if(searchValue === '') {
                searchValue = 'null';
            }

            axios.get('category/search/' + searchValue).then(response => {
                this.data_table = [];
                this.data_table = JSON.parse(response.data.data);
            })
        },
        limitList(value) {
            console.log(value);
        },
        newBtn() {
            this.isUpdate = false;
            this.values = [];
            $('#modal-entry').modal('show');
        },
        saveBtn() {

            let obj = {
                functionID : '03A00',
                name : this.values.name,
                description : this.values.description,
                status : 0,
            };

            if(this.values.categoryID) 
            {
                obj.functionID = '03C00';
                obj.categoryID = this.values.categoryID;
                obj.createdDate = this.values.createdDate;
                obj.modifiedDate = this.values.modifiedDate;
            }

            axios.post('category/store', obj).then(response => {
                this.messageBox('Success', 'Data Successfully Saved! Request ID:' + response.data.data, 'success', true);
            }).catch(error => {

                if(error.response.status  === 409) {
                    this.messageBox('Warning', error.response.data.data, 'warning');
                    return false;
                }

                let parse = JSON.parse(error.response.data.data);
                this.errors = parse.errors;

            });

        },
        editBtn(props) {
            this.isUpdate = true;
            this.values = [];
            axios.get('category/edit/' + props.row.categoryID).then(response => {

                if(response.status === 200) {
                    this.values = JSON.parse(response.data.data);
                    $('#modal-entry').modal('show');
                }
               
            })
        },
        deleteBtn(props) {
            axios.get('category/delete/' + props.row.id).then(response => {
                this.messageBox('Success', 'Data Successfully Deleted', 'success');
                this.data_table = response.data.data;
            });
        }
    },
    mounted() {
        axios.get('category/getData/').then(response => {
            this.data_table = response.data;
        });
    }
}
</script>

<style>
    input[type="text"] {
        text-transform: uppercase;
    }
</style>