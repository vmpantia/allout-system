using AllOut.Api.Common;
using AllOut.Api.Contractors;
using AllOut.Api.DataAccess.Models;

namespace AllOut.Api.Services.Common
{
    public class UtilityService : IUtilityService
    {
        public bool CheckProductAvailablity(Product product)
        {
            if (null == product)
                return false;

            return product.Status == Constants.STATUS_ENABLED_INT;
        }

        public bool CheckBrandAvailablity(Brand brand)
        {
            if (null == brand)
                return false;

            return brand.Status == Constants.STATUS_ENABLED_INT;
        }

        public bool CheckCategoryAvailablity(Category category)
        {
            if (null == category)
                return false;

            return category.Status == Constants.STATUS_ENABLED_INT;
        }

        public int GetCurrentStock(int inventories, int sales)
        {
            var result = inventories - sales;
            if(result < 0)
                return 0;
            return result;
        }

        public bool GetReorderState(int stock, int reorderpoint)
        {
            return stock <= reorderpoint;
        }
    }
}
