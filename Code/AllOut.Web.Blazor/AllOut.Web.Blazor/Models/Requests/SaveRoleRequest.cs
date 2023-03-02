using AllOut.Web.Blazor.Models.DataAccess;

namespace AllOut.Web.Blazor.Models.Requests
{
    public class SaveRoleRequest : RequestBase
    {
        //Role Information
        public Role inputRole { get; set; }
    }
}
