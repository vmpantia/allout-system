using System;
using System.Collections.Generic;

namespace AllOut.Web.Blazor.Models
{ 
    public class SaveSalesRequest : RequestBase
    {
        //Sales Information
        public Sales inputSales { get; set; }
        public List<SalesItem> inputSalesItems { get; set; }
        public List<OtherCharge> inputOtherCharges { get; set; }
    }
}
