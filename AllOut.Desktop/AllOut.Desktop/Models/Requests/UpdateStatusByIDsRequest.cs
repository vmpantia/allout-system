using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllOut.Desktop.Models.Requests
{
    public class UpdateStatusByIDsRequest
    {
        //Request Information
        public Guid UserID { get; set; }
        public string FunctionID { get; set; }
        public string RequestStatus { get; set; }

        //List of IDs
        public List<Guid> IDs { get; set; }
        public int newStatus { get; set; }  
    }
}
