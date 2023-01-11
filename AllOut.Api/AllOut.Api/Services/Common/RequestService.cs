using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Common;
using Microsoft.EntityFrameworkCore;

namespace AllOut.Api.Services.Common
{
    public class RequestService : IRequestService
    {
        public async Task<string> InsertRequest(AllOutDbContext db, Guid userID, string functionID, string requestStatus)
        {
            var newRequest = new Request
            {
                RequestID = await GetNewRequestID(db),
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

        private async Task<string> GetNewRequestID(AllOutDbContext db)
        {
            var newRequestID = string.Format(Constants.REQUEST_ID_FORMAT, Globals.REQUEST_ID_PREFFIX, Constants.REQUEST_ID_SUFFIX);

            var createdRequestToday = await db.Requests.Where(data => data.RequestDate == DateTime.Parse(Globals.EXEC_DATE))
                                                       .OrderByDescending(data => data.RequestID).ToListAsync();

            if (createdRequestToday == null || createdRequestToday.Count == 0)
            {
                return newRequestID;
            }

            var latestRequestID = createdRequestToday.First().RequestID;
            var currentSuffix = latestRequestID.Substring(Constants.REQUEST_ID_PREFIX_LENGTH, Constants.REQUEST_ID_SUFFIX_LENGTH);
            var newSuffix = (int.Parse(currentSuffix) + 1).ToString().PadLeft(Constants.REQUEST_ID_SUFFIX_LENGTH, '0');

            newRequestID = string.Format(Constants.REQUEST_ID_FORMAT, Globals.REQUEST_ID_PREFFIX, newSuffix);

            return newRequestID;
        }
    }
}
