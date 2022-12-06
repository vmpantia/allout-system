using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllOut.Desktop.Models.Requests
{
    public class BrandRequest
    {
        //Request Information
        public Guid UserID { get; set; }
        public string FunctionID { get; set; }
        public string RequestStatus { get; set; }

        //Category Information
        public Brand inputBrand { get; set; }
    }
}
