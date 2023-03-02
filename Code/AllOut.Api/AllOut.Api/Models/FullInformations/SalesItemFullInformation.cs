using AllOut.Api.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.Models.FullInformations
{
    public class SalesItemFullInformation : SalesItem
    {
        public string ProductName { get; set; }
    }
}
