using AllOut.Api.DataAccess;

namespace AllOut.Api.Contractors
{
    public interface IRequestService
    {
        Task<string> InsertRequest(AllOutDbContext db, Guid userID, string functionID, string requestStatus);
    }
}