using AllOut.Api.DataAccess.Models;

namespace AllOut.Api.Models.Requests
{
    public class SaveCategoryRequest : RequestBase
    {
        //Category Information
        public Category inputCategory { get; set; }
    }
}
