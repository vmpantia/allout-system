using System;

namespace AllOut.Desktop.Models
{
    public class ClientRequest
    {
        public Guid ClientID { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public string Response { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
