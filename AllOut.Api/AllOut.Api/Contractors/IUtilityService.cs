using AllOut.Api.DataAccess.Models;

namespace AllOut.Api.Contractors
{
    public interface IUtilityService
    {
        bool CheckBrandAvailablity(Brand brand);
        bool CheckCategoryAvailablity(Category category);
    }
}