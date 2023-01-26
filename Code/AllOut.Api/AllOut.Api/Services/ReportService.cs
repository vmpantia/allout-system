using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;
using AllOut.Api.Common;
using Microsoft.EntityFrameworkCore;
using Puregold.API.Exceptions;
using AllOut.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AllOut.Api.Services
{
    public class ReportService : IReportService
    {
        private readonly AllOutDbContext _db;
        public ReportService(AllOutDbContext context)
        {
            _db = context;
        }

        #region Public Methods
        public async Task<IEnumerable<SalesReportInformation>> GetSalesReportAsync()
        {
            var salesInItems = await (from a in _db.Sales
                                      join b in _db.SalesItems on a.SalesID equals b.SalesID
                                      where a.Status == Constants.STATUS_ENABLED_INT
                                      select new SalesReportInformation
                                      {
                                          Year = a.CreatedDate.Year,
                                          Quantity = b.Quantity,
                                          ItemTotal = b.Total,
                                          Additional = 0,
                                          Deductions = 0,
                                          Total = 0
                                      }).ToListAsync();

            var salesInOtherCharges = await (from a in _db.Sales
                                             join b in _db.OtherCharges on a.SalesID equals b.SalesID
                                             where a.Status == Constants.STATUS_ENABLED_INT
                                             select new SalesReportInformation
                                             {
                                                 Year = a.CreatedDate.Year,
                                                 Quantity = 0,
                                                 ItemTotal = 0,
                                                 Additional = b.Amount > 0 ? b.Amount : 0,
                                                 Deductions = b.Amount < 0 ? b.Amount : 0,
                                                 Total = 0
                                             }).ToListAsync();

            var mergeSales = new List<SalesReportInformation>();
            mergeSales.AddRange(salesInItems);
            mergeSales.AddRange(salesInOtherCharges);

            var report = (from a in mergeSales
                          group a by a.Year into g
                          select new SalesReportInformation
                          {
                              Year = g.Key,
                              Quantity = g.Sum(g => g.Quantity),
                              ItemTotal = g.Sum(g => g.ItemTotal),
                              Additional = g.Sum(g => g.Additional),
                              Deductions = g.Sum(g => g.Deductions),
                              Total = Math.Round((g.Sum(g => g.ItemTotal) + g.Sum(g => g.Additional) + g.Sum(g => g.Deductions)), 2)
                          }).ToList();

            return report;
        }

        public async Task<IEnumerable<SalesReportInformation>> GetSalesReportByYearAsync(int year)
        {
            var salesInItems = await (from a in _db.Sales
                                      join b in _db.SalesItems on a.SalesID equals b.SalesID
                                      where a.Status == Constants.STATUS_ENABLED_INT &&
                                            a.CreatedDate.Year == year
                                      select new SalesReportInformation
                                      {
                                          Month = a.CreatedDate.Month,
                                          Quantity = b.Quantity,
                                          ItemTotal = b.Total,
                                          Additional = 0,
                                          Deductions = 0,
                                          Total = 0
                                      }).ToListAsync();

            var salesInOtherCharges = await (from a in _db.Sales
                                             join b in _db.OtherCharges on a.SalesID equals b.SalesID
                                             where a.Status == Constants.STATUS_ENABLED_INT &&
                                                   a.CreatedDate.Year == year
                                             select new SalesReportInformation
                                             {
                                                 Month = a.CreatedDate.Month,
                                                 Quantity = 0,
                                                 ItemTotal = 0,
                                                 Additional = b.Amount > 0 ? b.Amount : 0,
                                                 Deductions = b.Amount < 0 ? b.Amount : 0,
                                                 Total = 0
                                             }).ToListAsync();

            var mergeSales = new List<SalesReportInformation>();
            mergeSales.AddRange(salesInItems);
            mergeSales.AddRange(salesInOtherCharges);

            var report = (from a in mergeSales
                          group a by a.Month into g
                          select new SalesReportInformation
                          {
                              Month = g.Key,
                              Quantity = g.Sum(g => g.Quantity),
                              ItemTotal = g.Sum(g => g.ItemTotal),
                              Additional = g.Sum(g => g.Additional),
                              Deductions = g.Sum(g => g.Deductions),
                              Total = Math.Round((g.Sum(g => g.ItemTotal) + g.Sum(g => g.Additional) + g.Sum(g => g.Deductions)), 2)
                          }).ToList();

            return report;
        }

        public async Task<IEnumerable<SalesReportInformation>> GetSalesReportByYearAndMonthAsync(string query)
        {
            var year = int.Parse(query.Split(Constants.DASH)[0]);
            var month = int.Parse(query.Split(Constants.DASH)[1]);

            var salesInItems = await (from a in _db.Sales
                                      join b in _db.SalesItems on a.SalesID equals b.SalesID
                                      where a.Status == Constants.STATUS_ENABLED_INT &&
                                            a.CreatedDate.Year == year && a.CreatedDate.Month == month
                                      select new SalesReportInformation
                                      {
                                          Day = a.CreatedDate.Day,
                                          Quantity = b.Quantity,
                                          ItemTotal = b.Total,
                                          Additional = 0,
                                          Deductions = 0,
                                          Total = 0
                                      }).ToListAsync();

            var salesInOtherCharges = await (from a in _db.Sales
                                             join b in _db.OtherCharges on a.SalesID equals b.SalesID
                                             where a.Status == Constants.STATUS_ENABLED_INT &&
                                                   a.CreatedDate.Year == year && a.CreatedDate.Month == month
                                             select new SalesReportInformation
                                             {
                                                 Day = a.CreatedDate.Day,
                                                 Quantity = 0,
                                                 ItemTotal = 0,
                                                 Additional = b.Amount > 0 ? b.Amount : 0,
                                                 Deductions = b.Amount < 0 ? b.Amount : 0,
                                                 Total = 0
                                             }).ToListAsync();

            var mergeSales = new List<SalesReportInformation>();
            mergeSales.AddRange(salesInItems);
            mergeSales.AddRange(salesInOtherCharges);

            var report = (from a in mergeSales
                          group a by a.Day into g
                          select new SalesReportInformation
                          {
                              Day = g.Key,
                              Quantity = g.Sum(g => g.Quantity),
                              ItemTotal = g.Sum(g => g.ItemTotal),
                              Additional = g.Sum(g => g.Additional),
                              Deductions = g.Sum(g => g.Deductions),
                              Total = Math.Round((g.Sum(g => g.ItemTotal) + g.Sum(g => g.Additional) + g.Sum(g => g.Deductions)), 2)
                          }).ToList();

            return report;
        }
        #endregion

    }
}
