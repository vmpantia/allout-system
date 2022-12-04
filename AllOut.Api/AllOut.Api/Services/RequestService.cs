using AllOut.Api.Commons;
using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;

namespace AllOut.Api.Services
{
    public class RequestService : IRequestService
    {
        private string NewRequestID
        {
            get
            {
                return string.Empty;
            }
        }

        public async Task<string> InsertRequest(AllOutDbContext db, Guid userID, string functionID, string requestStatus)
        {
            var newRequest = new Request
            {
                RequestID = NewRequestID,
                FunctionID = functionID,
                RequestDate = DateTime.Parse(Globals.EXEC_DATE),
                RequestBy = userID,
                ApprovedDate = null,
                ApprovedBy = null,
                Status = requestStatus,
                CreatedDate = Globals.EXEC_DATETIME,
                ModifiedDate = null
            };

            await db.Requests.AddAsync(newRequest);

            return newRequest.RequestID;
        }
    }
}
