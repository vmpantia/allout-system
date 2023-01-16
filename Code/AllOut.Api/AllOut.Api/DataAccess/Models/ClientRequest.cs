using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
{
    [PrimaryKey(nameof(ClientID), nameof(Number))]
    public class ClientRequest
    {
        public Guid ClientID { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public string Response { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
