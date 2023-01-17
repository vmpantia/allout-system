using System;

namespace AllOut.Desktop.Models
{
    public class Client
    {
        public Guid ClientID { get; set; }
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Browser { get; set; }
        public string IPAddress { get; set; }
        public string WindowsVersion { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
