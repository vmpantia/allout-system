<template>

    <div class="p-3">


        <div class="row d-flex justify-content-between">


            <!-- LEFT SIDE -->


            <div class="col-12 col-md-8">


                <!-- SEARCH  -->

                <!-- ITEM LIST -->

                <div class="row">
                    <div class="col-12 mb-3 d-flex justify-content-between align-items-center">
                        <h5 class="text-bold m-0 p-0">Sales Item/s</h5>

                        <div>
                            <button class="btn text-white" style="background: #00b894" v-on:click="searchProduct">
                                <i class="fa fa-plus mr-2"></i>Add Item
                            </button>

                            <button class="btn text-white" style="background: #b2bec3">
                                <i class="fa fa-search mr-2" aria-hidden="true"></i>Price Check
                            </button>
                        </div>
                    </div>
                </div>

                
                <div class="card">
                    <div class="card-body p-0 pb-2">
                        <table class="w-100">
                            <thead>
                                <tr class="border-bottom">
                                    <th class="text-left p-2">Item</th>
                                    <th style="width: 150px;" class="text-right p-2" >Price</th>
                                    <th style="width: 150px;" class="text-center p-2">Qty</th>
                                    <th style="width: 150px;" class="text-right p-2">Subtotal</th>
                                    <th style="width: 50px;" class="text-center p-2"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <template v-for="(item,key) in itemlist">
                                    <tr class="border-bottom">
                                        <th class="text-left p-2">{{ item.productName }}</th>
                                        <td class="text-right p-2">₱ {{ formatPrice(item.price) }}</td>
                                        <td class="text-center p-2"><input type="number" class="border text-center" :value="item.quantity" @blur="computeSubTotal($event,key)"></td>
                                        <td class="text-right p-2">{{ formatPrice(item.total) }}</td>
                                        <td class="text-center p-3"><button class="btn text-danger" v-on:click="removeItem(key)"><i class="fa fa-trash" aria-hidden="true"></i></button></td>
                                    </tr>
                                </template>
                            </tbody>
                        </table>
                    </div>
                </div>
             

            </div>


            <!-- RIGHT SIDE -->

            <div class="col-12 col-md-4"> 
                <div class="card">
                    <div class="card-header">
                        <div class="w-100 d-flex justify-content-between align-items-center">
                            <label class="m-0 font-weight-bold" style="font-size: 13px;">OTHER CHARGES</label>
                            <button class="btn text-white" style="font-size: 12px; background: #00b894" v-on:click="newOtherCharges">Add</button>
                        </div>
                    </div>
                    <div class="card-body p-0">
                        <table class="w-100">
                            <thead>
                                <tr class="border-bottom">
                                    <th class="text-left p-3">Charge</th>
                                    <th class="text-center p-3">Amount</th>
                                    <th class="text-right p-3"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <template v-for="item,key in otherCharges">
                                    <tr>
                                        <td class="text-left p-3">{{ item.chargeName }}</td>
                                        <td class="text-center p-3">₱ {{ formatPrice(item.amount) }}</td>
                                        <td class="text-center p-3"><button class="btn text-danger" v-on:click="removeOtherCharges(key)"><i class="fa fa-trash" aria-hidden="true"></i></button></td>
                                    </tr>
                                </template>
                            </tbody>
                        </table>
                    </div>
                </div>   

                <div class="card">
                    <div class="card-header">
                        <label class="m-0 font-weight-bold" style="font-size: 13px;">TOTAL</label>
                    </div>
                    <div class="card-body">
                        <label class="m-0 font-weight-bold w-100 text-center" style="font-size: 30px;">₱ <span id="totals" style="font-size: 30px;">{{ formatPrice(computeTotals) }}</span></label>
                    </div>
                </div>    
                
                <div class="card">
                    <div class="card-header">
                        <label class="m-0 font-weight-bold" style="font-size: 13px;">PAYMENT</label>
                    </div>
                    <div class="card-body">
                        <label class="m-0 font-weight-bold w-100 text-center" style="font-size: 30px;">₱ {{ formatPrice(computeTotals) }}</label>
                    </div>
                </div>      
                
                <div class="row">
                    <div class="col-6">
                        <button class="w-100 text-bold btn text-light" style="font-size: 15px; background: #ff7675" v-on:click="cancelTransaction"><i class="fas fa-times mr-2"></i> CANCEL</button>
                    </div>
                    <div class="col-6">
                        <button class="w-100 text-bold btn text-light" style="font-size: 15px; background: #00b894" v-on:click="openPayment"><i class="fas fa-check mr-2"></i> COMPLETE</button>
                    </div>
                </div>
            </div>
        </div>


        <!-- SEARCH PRODUCT -->

        <div class="modal" id="modal-search-product">
            <div class="modal-dialog  modal-xl">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Search Product</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <v-client-table class="mt-2"
                            :data="products"
                            :columns="products_columns"
                            :options="products_options">
                            <template slot="action" slot-scope="props">
                                <button v-if="props.row.stock !== 0" class="btn text-white" style="background: #00b894" v-on:click="itemSelected(props)"><i class="fa fa-check mr-2 " aria-hidden="true"></i> Add Item</button>
                            </template>
                        </v-client-table>
                    </div>
                </div>
            </div>
        </div>


        <!-- OTHER CHARGES -->

        <div class="modal" id="modal-other-charges">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Other Charges</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                       <label for="">Other Charges</label>
                       <select v-model="otherChargesValue.chargeName" class="form-control">
                            <option value="LABOR">LABOR</option>
                            <option value="DISCOUNT">DISCOUNT</option>
                       </select>

                        <label for="">Amount</label>
                        <input v-model="otherChargesValue.amount" type="text" class="form-control">
                    </div>
                    <div class="modal-footer">
                        <button class="btn text-white" style="background: #00b894" v-on:click="addOtherCharges">Add Charges</button>
                    </div>
                </div>
            </div>
        </div>


        <!-- ADD PAYMENT -->

        <div class="modal" id="modal-payment">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Payment</h5>
                    </div>
                    <div class="modal-body">
                       <table class="w-100">
                            <tr>
                                <th class="text-left p-3">Payment Type</th>
                                <th>:</th>
                                <th class="text-right p-3">
                                    <select v-model="paymentType" class="form-control">
                                        <option value="CASH">CASH</option>
                                    </select>
                                </th>
                            </tr>
                            <tr>
                                <th class="text-left p-3">Total Amount to Pay</th>
                                <th>:</th>
                                <th class="text-right p-3">{{ formatPrice(computeTotals) }}</th>
                            </tr>
                            <tr>
                                <th class="text-left p-3">Payment</th>
                                <th>:</th>
                                <th class="p-3"><input type="text" v-model="transactionPayment" class="form-control text-right" @blur="getPayment($event)"></th>
                            </tr>
                            <tr>
                                <th class="text-left p-3">Change</th>
                                <th>:</th>
                                <th class="p-3"><input type="text" v-model="paymentChange" class="form-control text-right" readonly></th>
                            </tr>
                       </table>
                    </div>
                    <div class="modal-footer">
                        <button class="btn text-white" style="background: #00b894" v-on:click="completeTransaction">Complete Transaction</button>
                    </div>
                </div>
            </div>
        </div>



        

    </div>


</template>

<script>
import { is } from '@babel/types';


export default {

    data() {
        return {
            
            itemlist : [],
            otherCharges : [],
            otherChargesValue : [],
            products : [],
            products_columns : ['productName', 'productDescription', 'brandName', 'categoryName', 'stock','action'],
            products_options : {
                headings : {
                    productName : 'Names',
                    productDescription : 'Description',
                    brandName : 'Brand',
                    categoryName : 'Category',
                    stock : 'Stock',
                    action : 'Action'
                },
                filterable : ['productName', 'productDescription', 'brandName', 'categoryName', 'stock',],
            },
            paymentType : 'CASH',
            paymentChange : 0,
            transactionPayment : 0,

        }
    },
    computed: {
        computeTotals() {
            let totals = 0;

            for(const key in Object.keys(this.itemlist)) {
                totals += this.itemlist[key].total;
            }

            for(const key in Object.keys(this.otherCharges)) {
                totals += parseFloat(this.otherCharges[key].amount);
            }

            return totals;
        }
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

        formatPrice(value) {
            let val = (value/1).toFixed(2).replace(',', '.')
            return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")
        },

        initialData() {
            axios.get('product/getData').then(response => {
                this.products = response.data;
            });
        },

        searchProduct() {
            $('#modal-search-product').modal('show');
        },

        /* ITEM TABLE */

        itemSelected(items) {
            if(items.row.stock === 0) {
                this.$fire({
                    title : 'No Stocks',
                    text : 'This Product has no stocks',
                    type : 'warning'
                });
                return true;
            }

            let isExist = false;

            for(const key in Object.keys(this.itemlist)) {
                if(this.itemlist[key].productID === items.row.productID) {
                    isExist = true;
                }
            }

            if(isExist)
            {
                this.$fire({
                    title : 'Invalid',
                    text : 'Product Already Exist',
                    type : 'warning'
                })
                return true;
            }



            this.itemlist.push({
                salesID : items.row.salesID ?? '',
                productID : items.row.productID,
                productName : items.row.productName,
                price : items.row.price,
                stock : items.row.stock,
                quantity : 1,
                total: items.row.price,
            });
        },

        computeSubTotal(e, key) {

            let quantity = parseInt(e.target.value);
            let stocks = parseInt(this.itemlist[key].stock);
            let price = parseFloat(this.itemlist[key].price);

            if(quantity > stocks)
            {
                this.$fire({
                    title : 'Insufficient Stocks',
                    text : 'Current Stocks: ' + stocks,
                    type : 'warning'
                }).then(() => {
                    this.itemlist[key].quantity = stocks;
                })

            }

            this.itemlist[key].quantity = quantity;
            this.itemlist[key].total = price * quantity;
        },

        removeItem(key) {
            this.itemlist.splice(key, 1);
        },

        /* OTHER CHARGES */

        newOtherCharges() {
            $('#modal-other-charges').modal('show');
        },

        addOtherCharges() {

            if(parseInt(this.otherChargesValue.amount) === 0 || typeof(this.otherChargesValue.amount) === 'undefined')
            {
                this.$fire({
                    title : 'Invalid',
                    text : 'Amount must have a value',
                    type : 'warning'
                })
                return true;
            }

            if(this.otherChargesValue.chargeName === 'DISCOUNT') {
                if(parseInt(this.otherChargesValue.amount) >= 0 || typeof(this.otherChargesValue.amount) === 'undefined')
                {
                    this.$fire({
                        title : 'Invalid Discount',
                        text : 'Discount must be less than 0',
                        type : 'warning'
                    }).then(() => {
                        this.otherChargesValue.amount = 0;
                    });

                    return true;
                }
            }

            let isExist = false;

            for(const key in Object.keys(this.otherCharges)) {
                if(this.otherCharges[key].chargeName === this.otherChargesValue.chargeName) {
                    isExist = true;
                }
            }


            if(isExist)
            {
                this.$fire({
                    title : 'Invalid',
                    text : 'Other Charges Already Exist',
                    type : 'warning'
                })
                return true;
            }

            let obj = {
                salesID : '',
                chargeName : this.otherChargesValue.chargeName,
                amount : parseFloat(this.otherChargesValue.amount)
            }

            this.otherCharges.push(obj);
            this.otherChargesValue = [];
            $('#modal-other-charges').modal('hide');
            
        },

        removeOtherCharges(key) {
            this.otherCharges.splice(key, 1);
        },


        /* PAYMENT */

        openPayment() {
            if(parseFloat($('#totals').text().toString().replace(',','')) === 0)
            {
                this.$fire({
                    title : 'Invalid Transaction',
                    text : 'No Transaction to be made',
                    type : 'warning'
                });

                return true;
            }

            $('#modal-payment').modal('show');
        },

        getPayment(e) {

            let totals = parseFloat($('#totals').text().toString().split(',').join(''));
            let payment = parseFloat(this.transactionPayment);

            if(payment < totals) {
                this.$fire({
                    title : 'Invalid Payment',
                    text : 'Total Payment is Less than Amount to be Paid',
                    type : 'warning'
                });
                return true;
            }

            this.paymentChange = Math.abs(totals - payment);

      
        },

        cancelTransaction() {
            location.reload();
        },


        /* COMPLETE TRANSACTION */

        completeTransaction() {

            this.$confirm('Are you sure to complete this Transaction?', 'Finish Transaction', 'question').then(() => {
                let total = parseFloat(this.transactionPayment);
                let change = parseFloat(this.paymentChange);

                if(total === 0)
                {
                    this.$fire({
                        title : 'Invalid Payment',
                        text : 'Total Payment is Less than Amount to be Paid',
                        type : 'warning'
                    });
                    return true;
                }

                let headerData = {
                    inputSales : {
                        salesID : "",
                        userID : "",
                        amountPaid : total,
                        change : change,
                        remarks : "NEW TRANSACTION",
                        status : 0,
                        createdDate : "",
                        modifiedDate : "",
                    },
                    inputSalesItems : this.itemlist,
                    inputOtherCharges : this.otherCharges,
                };




                axios.post('pos/store', headerData).then(response => {
                    if(response.status === 200) {
                        this.$fire({
                            title : 'Success!',
                            text : 'Transaction Successfully Saved',
                            type : 'success'
                        }).then(() => {
                            location.reload();
                        });
                    } 
                })

            })
        }
        
    },
    mounted() {
        this.initialData();
    }
}

</script>