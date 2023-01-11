namespace AllOut.Api.Models.Requests
{
    public class UpdateStatusByIDsRequest : RequestBase
    {
        //List of IDs
        public List<Guid> IDs { get; set; }
        public int newStatus { get; set; }
    }
}
