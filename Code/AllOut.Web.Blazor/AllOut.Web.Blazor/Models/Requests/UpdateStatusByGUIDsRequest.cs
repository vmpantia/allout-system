using System;
using System.Collections.Generic;

namespace AllOut.Web.Blazor.Models.Requests
{
    public class UpdateStatusByGUIDsRequest : RequestBase
    {
        //List of IDs
        public List<Guid> IDs { get; set; }
        public int newStatus { get; set; }
    }
}
