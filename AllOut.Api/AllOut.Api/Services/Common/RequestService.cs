using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Common;
using Microsoft.EntityFrameworkCore;

namespace AllOut.Api.Services.Common
{
    public class RequestService : IRequestService
    {
        #region Public Methods
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
        #endregion

        #region Private Methods
        private async Task<string> GetNewRequestID(AllOutDbContext db)
        {
            var requestsToday = await db.Requests.Where(data => data.RequestDate == DateTime.Parse(Globals.EXEC_DATE))
                                                 .OrderByDescending(data => data.RequestID).ToListAsync();

            if (requestsToday == null || !requestsToday.Any())
                return string.Format(Constants.REQUEST_ID_FORMAT, Globals.ID_PREFFIX, Constants.ID_DEFAULT_SUFFIX);

            var latestRequestID = requestsToday.First().RequestID;
            var currentSuffix = latestRequestID.Substring(Constants.ID_PREFIX_LENGTH, Constants.ID_SUFFIX_LENGTH);
            var newSuffix = (int.Parse(currentSuffix) + 1).ToString().PadLeft(Constants.ID_SUFFIX_LENGTH, Constants.ZERO);

            return string.Format(Constants.REQUEST_ID_FORMAT, Globals.ID_PREFFIX, newSuffix);
        }
        #endregion
    }
}
