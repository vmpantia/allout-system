namespace AllOut.Api.Models.Requests
{
    public class UpdateStatusByStringIDsRequest : RequestBase
    {
        //List of IDs
        public List<string> IDs { get; set; }
        public int newStatus { get; set; }
    }
}
