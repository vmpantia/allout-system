using AllOut.Api.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.Models
{
    public class ProductFullInformation
    {
        public Product productInfo { get; set; }
        public Brand? brandInfo { get; set; }
        public Category? categoryInfo { get; set; }
    }
}
