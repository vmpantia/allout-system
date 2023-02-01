using AllOut.Api.DataAccess.Models;

namespace AllOut.Api.Models.Requests
{
    public class SaveRoleRequest : RequestBase
    {
        //Role Information
        public Role inputRole { get; set; }
    }
}
