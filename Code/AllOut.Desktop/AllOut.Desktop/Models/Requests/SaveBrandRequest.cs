using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllOut.Desktop.Models.Requests
{
    public class SaveBrandRequest
    {
        //Request Information
        public Guid UserID { get; set; }
        public string FunctionID { get; set; }
        public string RequestStatus { get; set; }

        //Brand Information
        public Brand inputBrand { get; set; }
    }
}
