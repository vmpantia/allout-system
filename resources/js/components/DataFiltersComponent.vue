<template>
    <div class="list-filter-search">
        <div class="row d-flex justify-content-end align-items-center">
            <!-- <div class="list-limit col-1">
                <select class="form-control" v-on:change="onChangeListLimit">
                    <option value="10">10</option>
                    <option value="50">50</option>
                    <option value="100">100</option>
                </select>
            </div> -->
            
            <div class="col-5">
                <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search Anything Here..." v-model="searchValue">
                    <div class="input-group-append">
                        <button class="btn btn-info" v-on:click="btnSearch"><i class="fa fa-search" aria-hidden="true"></i></button>
                    </div>
                </div>
            </div>
        </div>                 
    </div>
</template>


<script>
export default {
    data() {
        return {
            searchValue : '',
        }
    },

    methods: {
        btnSearch() {
            this.$emit('searchedValue', this.searchValue);
        },

        onChangeListLimit(e) {
            this.$emit('listLimits', e.target.value)
        }
    }
}

</script>