using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
{
    public class ClientRequest
    {
        [Key]
        public Guid ClientID { get; set; }
        public string Type { get; set; }
        public string Response { get; set; }
        public string? Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
