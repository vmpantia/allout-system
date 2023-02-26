using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllOut.Web.Blazor.Models
{
    public class SalesFullInformation
    {
        public string SalesID { get; set; }

        //Cashier
        public Guid UserID { get; set; }
        public string Name { get; set; }

        //Sales Items
        public IEnumerable<SalesItemFullInformation> salesItems { get; set; }

        //Other Charges
        public IEnumerable<OtherCharge> otherCharges { get; set; }

        public decimal TotalItems { get; set; }
        public decimal TotalAdditional { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal Total { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Change { get; set; }
        public string Remarks { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
