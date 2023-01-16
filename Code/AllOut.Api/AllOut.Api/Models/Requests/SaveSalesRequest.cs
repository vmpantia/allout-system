using AllOut.Api.DataAccess.Models;

namespace AllOut.Api.Models.Requests
{
    public class SaveSalesRequest : RequestBase
    {
        //Sales Information
        public Sales inputSales { get; set; }
        public List<SalesItem> inputSalesItems { get; set; }
        public List<OtherCharge> inputOtherCharges { get; set; }
    }
}
