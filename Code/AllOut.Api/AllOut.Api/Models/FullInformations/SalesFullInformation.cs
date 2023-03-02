using AllOut.Api.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.Models.FullInformations
{
    public class SalesFullInformation : Sales
    {
        public string CashierName { get; set; }

        //Sales Items
        public IEnumerable<SalesItemFullInformation> salesItems { get; set; }

        //Other Charges
        public IEnumerable<OtherCharge> otherCharges { get; set; }

        public decimal TotalItems { get; set; }
        public decimal TotalAdditional { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal Total { get; set; }
    }
}
