<template>

    <div class="p-3">

        <!-- PAGE TITLE  -->

        <div class="card">
            <div class="card-header">
                <div class="d-flex justify-content-between align-items-center">
                    <span class="page-title">List of Products</span>
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
                        <span v-if="!props.row.reorderState">ON STOCK LEVEL</span>
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
                        
                        <label>Brand</label>
                        <select type="text" class="form-control" v-model="values.brandID">
                            <option v-for="brand in brands" :value="brand.brandID">{{ brand.name }}</option>
                        </select>
                        <div class="text-danger" v-if="errors.brandID">{{ errors.brandID[0] }}</div>

                        <label>Category</label>
                        <select type="text" class="form-control" v-model="values.categoryID">
                            <option v-for="category in categories" :value="category.categoryID">{{ category.name }}</option>
                        </select>
                        <div class="text-danger" v-if="errors.categoryID">{{ errors.categoryID[0] }}</div>

                        <label>Product Name</label>
                        <input type="text" class="form-control" v-model="values.name">
                        <div class="text-danger" v-if="errors.name">{{ errors.name[0] }}</div>

                        <label>Description</label>
                        <input type="text" class="form-control" v-model="values.description">
                        <div class="text-danger" v-if="errors.description">{{ errors.description[0] }}</div>

                        <label>Re Order Point</label>
                        <input type="text" class="form-control" v-model="values.reorderPoint">
                        <div class="text-danger" v-if="errors.reorderPoint">{{ errors.reorderPoint[0] }}</div>
                        
                        <label>Price</label>
                        <input type="text" class="form-control" v-model="values.price">
                        <div class="text-danger" v-if="errors.price">{{ errors.price[0] }}</div>

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
            data_columns : ['productName', 'productDescription', 'brandName', 'categoryName', 'reorderState', 'stock', 'status','action'],
            data_options : {
                    headings : {
                        productName : 'Names',
                        productDescription : 'Description',
                        brandName : 'Brand',
                        categoryName : 'Category',
                        reorderState : 'Re Order',
                        stock : 'Stock',
                        status : 'Status',
                        action : 'Action'
                    },
                    filterable : false,
            },
            brands : [],
            categories : [],
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
                let responseData = JSON.parse(response.data.data);    
              
                for(const key in Object.keys(responseData)) {
                    this.data_table.push({
                        productID : responseData[key].productInfo.productID,
                        name : responseData[key].productInfo.name,
                        description : responseData[key].productInfo.description,
                        brand : responseData[key].brandInfo == null ? 'N/A' : responseData[key].brandInfo.name,
                        category : responseData[key].categoryInfo == null ? 'N/A' : responseData[key].categoryInfo.name,
                        status : responseData[key].productInfo.status,
                        reorderState : responseData[key].reorderState,
                        stock : responseData[key].stock
                    });
                };
            })
        },
        initialData() {

            /* get brands */

            axios.get('brand/getData').then(response => {
                this.brands = response.data;
            });

            
            /* get brands */
            
            axios.get('category/getData').then(response => {
                this.categories = response.data;
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
                functionID : '01A00',
                brandID : this.values.brandID,
                categoryID : this.values.categoryID,
                name : this.values.name,
                description : this.values.description,
                reorderPoint : this.values.reorderPoint,
                price : this.values.price,
            };

            if(this.values.productID) 
            {
                obj.productID = this.values.productID;
                obj.functionID = '01C00';
                obj.createdDate = this.values.createdDate;
                obj.modifiedDate = this.values.modifiedDate;
            }

            axios.post('product/store', obj).then(response => {
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
            axios.get('product/edit/' + props.row.productID).then(response => {

                if(response.status === 200) {
                    this.values = JSON.parse(response.data.data);
                    $('#modal-entry').modal('show');
                }
               
            })
        },
        deleteBtn(props) {
            axios.get('product/delete/' + props.row.productID).then(response => {
                this.messageBox('Success', 'Data Successfully Deleted', 'success');
                this.data_table = response.data.data;
            });
        }
    },
    mounted() {
        axios.get('product/getData').then(response => {
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