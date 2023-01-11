using AllOut.Api.Common;
using AllOut.Api.Contractors;
using AllOut.Api.DataAccess.Models;

namespace AllOut.Api.Services.Common
{
    public class UtilityService : IUtilityService
    {
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
    }
}
