using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;
using AllOut.Api.Common;
using Microsoft.EntityFrameworkCore;
using Puregold.API.Exceptions;
using AllOut.Api.Models;

namespace AllOut.Api.Services
{
    public class SalesService : ISalesService
    {
        private readonly AllOutDbContext _db;
        private readonly IRequestService _request;
        public SalesService(AllOutDbContext context, IRequestService request)
        {
            _db = context;
            _request = request;
        }

        #region Public Methods
        public async Task<IEnumerable<SalesReportInformation>> GetSalesReportByYearAsync()
        {
            var sales = await (from a in _db.Sales
                               join b in _db.SalesItems on a.SalesID equals b.SalesID
                               where a.Status == Constants.STATUS_ENABLED_INT
                               select new
                               {
                                   Year = a.CreatedDate.Year.ToString(),
                                   Quantity = b.Quantity,
                                   Total = b.Total,
                                   AmountPaid = a.AmountPaid,
                                   Change = a.Change
                               }).ToListAsync();

            var report = (from a in sales
                          group a by a.Year into g
                          select new SalesReportInformation
                          {
                              Year = g.First().Year,
                              Quantity = g.Sum(g => g.Quantity),
                              Total = g.Sum(g => g.Total),
                              AmountPaid = g.Sum(g => g.AmountPaid),
                              Change = g.Sum(g => g.Change)
                          }).ToList();

            return report;
        }

        public async Task<IEnumerable<SalesReportInformation>> GetSalesReportByMonthAsync(int year)
        {
            var sales = await (from a in _db.Sales
                               join b in _db.SalesItems on a.SalesID equals b.SalesID
                               where a.Status == Constants.STATUS_ENABLED_INT &&
                                     a.CreatedDate.Year == year
                               select new
                               {
                                   Month = a.CreatedDate.Month.ToString(),
                                   Quantity = b.Quantity,
                                   Total = b.Total,
                                   AmountPaid = a.AmountPaid,
                                   Change = a.Change
                               }).ToListAsync();

            var report = (from a in sales
                          group a by a.Month into g
                          select new SalesReportInformation
                          {
                              Month = g.First().Month,
                              Quantity = g.Sum(g => g.Quantity),
                              Total = g.Sum(g => g.Total),
                              AmountPaid = g.Sum(g => g.AmountPaid),
                              Change = g.Sum(g => g.Change)
                          }).ToList();

            return report;
        }

        public async Task<string> SaveSalesAsync(SaveSalesRequest request)
        {
            //Check if Request is NULL
            if (request == null)
                throw new APIException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.OBJECT_SALES));

            var requestID = await _request.InsertRequest(_db, request.client.UserID,
                                                              request.FunctionID,
                                                              request.RequestStatus);

            if (requestID == null)
                throw new APIException(string.Format(Constants.ERROR_ID_NULL, Constants.OBJECT_SALES));

            switch (request.FunctionID)
            {
                case Constants.FUNCTION_ID_ADD_SALES_BY_ADMIN: //Add
                case Constants.FUNCTION_ID_ADD_SALES: //Add
                    await InsertSales(request.inputSales);
                    break;
            }

            await SaveSalesItems(request.inputSalesItems,
                                 request.inputSales.SalesID,
                                 requestID);
            await SaveOtherCharges(request.inputOtherCharges,
                                   request.inputSales.SalesID,
                                   requestID);

            //Insert Transaction
            await InsertSales_TRN(request.inputSales, requestID.ToString());
            //Save Changes
            await _db.SaveChangesAsync();

            return requestID;
        }
        #endregion

        #region Private Methods
        private async Task InsertSales(Sales inputSales)
        {
            inputSales.SalesID = await GetNewSalesID();
            inputSales.CreatedDate = DateTime.Now;
            await _db.Sales.AddAsync(inputSales);
        }

        private async Task SaveSalesItems(List<SalesItem> inputSalesItems, string salesID, string requestID)
        {
            await DeleteSalesItemsBySalesID(salesID);

            int number = 1;
            foreach (var salesItem in inputSalesItems)
            {
                //Insert SalesItem
                salesItem.SalesID = salesID;
                await _db.SalesItems.AddAsync(salesItem);

                //Insert SalesItem_TRN
                await _db.SalesItem_TRN.AddAsync(new SalesItem_TRN
                {
                    RequestID = requestID,
                    Number = number,
                    SalesID = salesItem.SalesID,
                    ProductID = salesItem.ProductID,
                    Quantity = salesItem.Quantity,
                    Price = salesItem.Price,
                    Total = salesItem.Total,
                });

                number++;
            }
        }

        private async Task DeleteSalesItemsBySalesID(string salesID)
        {
            var salesItems = await _db.SalesItems.Where(data => data.SalesID == salesID).ToListAsync();

            foreach (var salesItem in salesItems)
            {
                _db.SalesItems.Remove(salesItem);
            }
        }

        private async Task SaveOtherCharges(List<OtherCharge> otherCharges, string salesID, string requestID)
        {
            await DeleteOtherChargesBySalesID(salesID);

            int number = 1;
            foreach (var otherCharge in otherCharges)
            {
                //Insert OtherCharge
                otherCharge.SalesID = salesID;
                await _db.OtherCharges.AddAsync(otherCharge);

                //Insert OtherCharge_TRN
                await _db.OtherCharge_TRN.AddAsync(new OtherCharge_TRN
                {
                    RequestID = requestID,
                    Number = number,
                    SalesID = salesID,
                    ChargeName = otherCharge.ChargeName,
                    Amount = otherCharge.Amount,
                });

                number++;
            }
        }

        private async Task DeleteOtherChargesBySalesID(string salesID)
        {
            var otherCharges = await _db.OtherCharges.Where(data => data.SalesID == salesID).ToListAsync();

            foreach (var otherCharge in otherCharges)
            {
                _db.OtherCharges.Remove(otherCharge);
            }
        }

        private async Task InsertSales_TRN(Sales inputSales, string requestID, int number = 1)
        {
            var newTrn = new Sales_TRN
            {
                RequestID = requestID,
                Number = number,
                SalesID = inputSales.SalesID,
                UserID = inputSales.UserID,
                Remarks = inputSales.Remarks,
                Status = inputSales.Status,
                CreatedDate = inputSales.CreatedDate,
                ModifiedDate = inputSales.ModifiedDate
            };

            await _db.Sales_TRN.AddAsync(newTrn);
        }

        private async Task<string> GetNewSalesID()
        {
            var salesToday = await _db.Sales.Where(data => data.CreatedDate == DateTime.Parse(Globals.EXEC_DATE))
                                           .OrderByDescending(data => data.SalesID).ToListAsync();

            if (salesToday == null || !salesToday.Any())
                return string.Format(Constants.SALES_ID_FORMAT, Globals.ID_PREFFIX, Constants.ID_DEFAULT_SUFFIX);

            var latestSalesID = salesToday.First().SalesID;
            var currentSuffix = latestSalesID.Substring(Constants.ID_PREFIX_LENGTH, Constants.ID_SUFFIX_LENGTH);
            var newSuffix = (int.Parse(currentSuffix) + 1).ToString().PadLeft(Constants.ID_SUFFIX_LENGTH, Constants.ZERO);

            return string.Format(Constants.SALES_ID_FORMAT, Globals.ID_PREFFIX, newSuffix);
        }
        #endregion
    }
}
