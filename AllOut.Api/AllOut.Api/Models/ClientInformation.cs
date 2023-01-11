namespace AllOut.Api.Models
{
    public class ClientInformation
    {
        public Guid UserID { get; set; }   
        public Guid APIKey { get; set; }
        public string Name { get; set; }    
        public string IPAddress { get; set; } 
        public string Windows { get; set; } 
        public string Browser { get; set; }
    }
}
