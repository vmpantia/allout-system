<template>

    <div class="p-3">

        <!-- PAGE TITLE  -->

        <div class="card">
            <div class="card-header">
                <div class="d-flex justify-content-between align-items-center">
                    <span class="page-title">List of Inventory</span>
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
                    <template slot="reorderState" slot-scope="props">
                        <span v-if="props.row.reorderState">ON STOCK LEVEL</span>
                        <span v-else>FOR REPLENISHMENT</span>
                    </template>
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
                        <label>Product</label>
                        <select type="text" class="form-control" v-model="values.productID">
                            <option v-for="product in products" :value="product.productID">{{ product.productName }}</option>
                        </select>
                        <div class="text-danger" v-if="errors.brandID">{{ errors.brandID[0] }}</div>

                        <label>Quantity</label>
                        <input type="text" class="form-control" v-model="values.quantity">
                        <div class="text-danger" v-if="errors.quantity">{{ errors.quantity[0] }}</div>
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
            data_columns : ['productName', 'brandName', 'categoryName', 'quantity', 'createdDate', 'modifiedDate','status','action'],
            data_options : {
                    headings : {
                        productName : 'Product Name',
                        brandName : 'Brand',
                        categoryName : 'Category',
                        quantity : 'Quantity',
                        status : 'Status',
                        createdDate : 'Created Date',
                        modifiedDate : 'Modified Date',
                        action : 'Action'
                    },
                    filterable : false,
            },
            products : [],
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
            this.data_table = [];

            if(searchValue === '') {
                searchValue = 'null';
            }
            
            axios.get('product/search/' + searchValue).then(response => {
                this.data_table = response.data;    
            })
        },
        initialData() {
            axios.get('product/getData').then(response => {
                this.products = response.data;
            });
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
                functionID : '04A00',
                productID : this.values.productID,
                quantity : this.values.quantity,
            };

            if(this.values.inventoryID) 
            {
                obj.inventoryID = this.values.inventoryID;
                obj.functionID = '04C00';
                obj.createdDate = this.values.createdDate;
                obj.modifiedDate = this.values.modifiedDate;
            }

            axios.post('inventory/store', obj).then(response => {
                if(response.status === 200) {
                    this.messageBox('Success', 'Data Successfully Saved! Request ID:' + response.data.data, 'success', true);
                }
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
            axios.get('inventory/edit/' + props.row.inventoryID).then(response => {

                if(response.status === 200) {
                    this.values = JSON.parse(response.data.data);
                    $('#modal-entry').modal('show');
                }
               
            })
        },
        deleteBtn(props) {
            axios.get('inventory/delete/' + props.row.inventoryID).then(response => {
                this.messageBox('Success', 'Data Successfully Deleted', 'success');
                this.data_table = response.data.data;
            });
        }
    },
    mounted() {
        axios.get('inventory/getData').then(response => {
            this.data_table = response.data;
            this.initialData();
        });
    }
}
</script>

<style>
    input[type="text"] {
        text-transform: uppercase;
    }
</style>