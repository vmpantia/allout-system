using AllOut.Api.Common;
using AllOut.Api.Contractors;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.enums;
using AllOut.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Puregold.API.Exceptions;

namespace AllOut.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _report;
        private readonly IUtilityService _utility;
        public ReportController(IReportService report, IUtilityService utility)
        {
            _report = report;
            _utility = utility;
        }

        [HttpGet("GetSalesReport")]
        public async Task<IActionResult> GetSalesReportAsync(Guid clientID)
        {
            return await ProcessRequest(RequestType.GET_SALES_REPORT, clientID);
        }

        [HttpGet("GetSalesReportByYear")]
        public async Task<IActionResult> GetSalesReportByYearAsync(Guid clientID, int year)
        {
            return await ProcessRequest(RequestType.GET_SALES_REPORT_BY_YEAR, clientID, year);
        }

        [HttpGet("GetSalesReportByYearAndMonth")]
        public async Task<IActionResult> GetSalesReportByYearAndMonthAsync(Guid clientID, string query)
        {
            return await ProcessRequest(RequestType.GET_SALES_REPORT_BY_YEAR_MONTH, clientID, query);
        }

        private async Task<IActionResult> ProcessRequest(RequestType type, Guid clientID, object data = null, string functionID = null)
        {
            try
            {
                object? response = null;

                var errorMessage = await _utility.ValidateClientID(clientID, type, functionID);
                if (!string.IsNullOrEmpty(errorMessage))
                    return Unauthorized(errorMessage);

                switch (type)
                {
                    case RequestType.GET_SALES_REPORT:
                        response = await _report.GetSalesReportAsync();
                        break;

                    case RequestType.GET_SALES_REPORT_BY_YEAR:
                        response = await _report.GetSalesReportByYearAsync((int)data);
                        break;

                    case RequestType.GET_SALES_REPORT_BY_YEAR_MONTH:
                        response = await _report.GetSalesReportByYearAndMonthAsync((string)data);
                        break;
                }

                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

    }
}
