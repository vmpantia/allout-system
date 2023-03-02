using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;
using AllOut.Api.Commons;
using Microsoft.EntityFrameworkCore;
using AllOut.Api.Models.FullInformations;
using AllOut.Api.DataAccess.Models.Transactions;
using AllOut.Api.Exceptions;

namespace AllOut.Api.Services
{
    public class SalesService : ISalesService
    {
        private readonly AllOutDbContext _db;
        private readonly IRequestService _request;
        private readonly IUtilityService _utility;
        public SalesService(AllOutDbContext context, IRequestService request, IUtilityService utility)
        {
            _db = context;
            _request = request;
            _utility = utility;
        }

        #region Public Methods

        public async Task<IEnumerable<SalesFullInformation>> GetSalesAsync()
        {
            var salesList = await (from a in _db.Sales
                                   join b in _db.Users on a.UserID equals b.UserID into bb from b in bb.DefaultIfEmpty()
                                   where a.Status != Constants.STATUS_DELETION_INT
                                   select new SalesFullInformation
                                   {
                                       SalesID = a.SalesID,
                                       UserID = a.UserID,
                                       CashierName = _utility.CheckUserAvailability(b) ? string.Format(Constants.NAME_FORMAT, b.LastName, b.FirstName) : Constants.NA,
                                       AmountPaid = a.AmountPaid,
                                       Change = a.Change,
                                       Remarks = a.Remarks,
                                       Status = a.Status,
                                       CreatedDate = a.CreatedDate,
                                       ModifiedDate = a.ModifiedDate
                                   }).ToListAsync();

            foreach (var sales in salesList)
            {
                sales.salesItems = await GetSalesItemsByID(sales.SalesID);
                sales.otherCharges = await GetOtherChargesByID(sales.SalesID);
                sales.TotalItems = sales.salesItems.Sum(x => x.Total);
                sales.TotalAdditional = sales.otherCharges.Where(data => data.Amount > 0).Sum(data => data.Amount);
                sales.TotalDeduction = sales.otherCharges.Where(data => data.Amount < 0).Sum(data => data.Amount);
                sales.Total = _utility.GetTotal(sales.TotalItems, sales.TotalAdditional, sales.TotalDeduction);
            }

            return salesList;
        }

        public async Task<IEnumerable<SalesFullInformation>> GetSalesByQueryAsync(string query)
        {
            var salesList = await (from a in _db.Sales
                                   join b in _db.Users on a.UserID equals b.UserID into bb from b in bb.DefaultIfEmpty()
                                   where a.Status != Constants.STATUS_DELETION_INT &&
                                         (a.SalesID.Contains(query) || b.FirstName.Contains(query) || b.LastName.Contains(query))
                                   select new SalesFullInformation
                                   {
                                       SalesID = a.SalesID,
                                       UserID = a.UserID,
                                       CashierName = _utility.CheckUserAvailability(b) ? string.Format(Constants.NAME_FORMAT, b.LastName, b.FirstName) : Constants.NA,
                                       AmountPaid = a.AmountPaid,
                                       Change = a.Change,
                                       Remarks = a.Remarks,
                                       Status = a.Status,
                                       CreatedDate = a.CreatedDate,
                                       ModifiedDate = a.ModifiedDate
                                   }).ToListAsync();

            foreach (var sales in salesList)
            {
                sales.salesItems = await GetSalesItemsByID(sales.SalesID);
                sales.otherCharges = await GetOtherChargesByID(sales.SalesID);
                sales.TotalItems = sales.salesItems.Sum(x => x.Total);
                sales.TotalAdditional = sales.otherCharges.Where(data => data.Amount > 0).Sum(data => data.Amount);
                sales.TotalDeduction = sales.otherCharges.Where(data => data.Amount < 0).Sum(data => data.Amount);
                sales.Total = _utility.GetTotal(sales.TotalItems, sales.TotalAdditional, sales.TotalDeduction);
            }

            return salesList;
        }

        public async Task<IEnumerable<SalesFullInformation>> GetSalesByStatusAsync(int status)
        {
            var salesList = await (from a in _db.Sales
                                   join b in _db.Users on a.UserID equals b.UserID into bb from b in bb.DefaultIfEmpty()
                                   where a.Status == status
                                   select new SalesFullInformation
                                   {
                                       SalesID = a.SalesID,
                                       UserID = a.UserID,
                                       CashierName = _utility.CheckUserAvailability(b) ? string.Format(Constants.NAME_FORMAT, b.LastName, b.FirstName) : Constants.NA,
                                       AmountPaid = a.AmountPaid,
                                       Change = a.Change,
                                       Remarks = a.Remarks,
                                       Status = a.Status,
                                       CreatedDate = a.CreatedDate,
                                       ModifiedDate = a.ModifiedDate
                                   }).ToListAsync();

            foreach (var sales in salesList)
            {
                sales.salesItems = await GetSalesItemsByID(sales.SalesID);
                sales.otherCharges = await GetOtherChargesByID(sales.SalesID);
                sales.TotalItems = sales.salesItems.Sum(x => x.Total);
                sales.TotalAdditional = sales.otherCharges.Where(data => data.Amount > 0).Sum(data => data.Amount);
                sales.TotalDeduction = sales.otherCharges.Where(data => data.Amount < 0).Sum(data => data.Amount);
                sales.Total = _utility.GetTotal(sales.TotalItems, sales.TotalAdditional, sales.TotalDeduction);
            }

            return salesList;
        }

        public async Task<SalesFullInformation> GetSalesByIDAsync(string id)
        {
            var salesList = await (from a in _db.Sales
                                   join b in _db.Users on a.UserID equals b.UserID into bb
                                   from b in bb.DefaultIfEmpty()
                                   where a.Status != Constants.STATUS_DELETION_INT && a.SalesID == id
                                   select new SalesFullInformation
                                   {
                                       SalesID = a.SalesID,
                                       UserID = a.UserID,
                                       CashierName = _utility.CheckUserAvailability(b) ? string.Format(Constants.NAME_FORMAT, b.LastName, b.FirstName) : Constants.NA,
                                       AmountPaid = a.AmountPaid,
                                       Change = a.Change,
                                       Remarks = a.Remarks,
                                       Status = a.Status,
                                       CreatedDate = a.CreatedDate,
                                       ModifiedDate = a.ModifiedDate
                                   }).ToListAsync();

            foreach (var sales in salesList)
            {
                sales.salesItems = await GetSalesItemsByID(sales.SalesID);
                sales.otherCharges = await GetOtherChargesByID(sales.SalesID);
                sales.TotalItems = sales.salesItems.Sum(x => x.Total);
                sales.TotalAdditional = sales.otherCharges.Where(data => data.Amount > 0).Sum(data => data.Amount);
                sales.TotalDeduction = sales.otherCharges.Where(data => data.Amount < 0).Sum(data => data.Amount);
                sales.Total = _utility.GetTotal(sales.TotalItems, sales.TotalAdditional, sales.TotalDeduction);
            }

            return salesList.First();
        }

        public async Task<int> GetCountSalesAsync()
        {
            var count = await _db.Sales.Where(data => data.Status != Constants.STATUS_DELETION_INT).CountAsync();
            return count;
        }

        public async Task<int> GetCountSalesByStatusAsync(int status)
        {
            var count = await _db.Sales.Where(data => data.Status == status).CountAsync();
            return count;
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

        public async Task<string> UpdateSalesStatusByIDsAsync(UpdateStatusByStringIDsRequest request)
        {
            var requestID = await _request.InsertRequest(_db, request.client.UserID,
                                                              request.FunctionID,
                                                              request.RequestStatus);
            var count = 0;
            foreach (var id in request.IDs)
            {
                count++;
                var sales = await _db.Sales.FindAsync(id);
                if (sales != null)
                {
                    sales.Status = request.newStatus;
                    sales.ModifiedDate = DateTime.Now;
                    await InsertSales_TRN(sales, requestID.ToString(), count);
                }
            }

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
            var salesToday = await _db.Sales.Where(data => data.CreatedDate.Year == DateTime.Parse(Globals.EXEC_DATE).Year &&
                                                           data.CreatedDate.Month == DateTime.Parse(Globals.EXEC_DATE).Month &&
                                                           data.CreatedDate.Day == DateTime.Parse(Globals.EXEC_DATE).Day)
                                            .OrderByDescending(data => data.SalesID).ToListAsync();

            if (salesToday == null || !salesToday.Any())
                return string.Format(Constants.SALES_ID_FORMAT, Globals.ID_PREFFIX, Constants.ID_DEFAULT_SUFFIX);

            var latestSalesID = salesToday.First().SalesID;
            var currentSuffix = latestSalesID.Substring(Constants.ID_PREFIX_LENGTH, Constants.ID_SUFFIX_LENGTH);
            var newSuffix = (int.Parse(currentSuffix) + 1).ToString().PadLeft(Constants.ID_SUFFIX_LENGTH, Constants.ZERO);

            return string.Format(Constants.SALES_ID_FORMAT, Globals.ID_PREFFIX, newSuffix);
        }

        private async Task<IEnumerable<SalesItemFullInformation>> GetSalesItemsByID(string salesID)
        {
            var salesItems = await (from a in _db.SalesItems
                                    join b in _db.Products on a.ProductID equals b.ProductID into bb from b in bb.DefaultIfEmpty()
                                    where a.SalesID == salesID
                                    select new SalesItemFullInformation
                                    {
                                        SalesID = a.SalesID,
                                        ProductID= a.ProductID,
                                        ProductName = _utility.CheckProductAvailablity(b) ? b.Name : Constants.NA,
                                        Quantity = a.Quantity,
                                        Price = a.Price,
                                        Total = a.Total
                                    }).ToListAsync();

            return salesItems;
        }

        private async Task<IEnumerable<OtherCharge>> GetOtherChargesByID(string salesID)
        {
            return await _db.OtherCharges.Where(data => data.SalesID == salesID).ToListAsync();
        }
        #endregion
    }
}
