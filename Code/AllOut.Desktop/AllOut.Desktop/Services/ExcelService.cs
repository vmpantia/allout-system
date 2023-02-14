using AllOut.Desktop.Models;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllOut.Desktop.Services
{
    public class ExcelService
    {
        private ApplicationClass _excelApp;
        private readonly Workbook _excelWorkbook;
        private readonly Worksheet _excelWorksheet;
        private readonly object _misValue;

        public ExcelService()
        {
            _excelApp = new ApplicationClass();
            _misValue = System.Reflection.Missing.Value;

            _excelWorkbook = _excelApp.Workbooks.Add(_misValue);
            _excelWorksheet = (Worksheet)_excelWorkbook.Worksheets.get_Item(1);

            //Clear Worksheet Rows
            _excelWorksheet.Rows.Clear();
        }

        public string ExportToExcel(object input)
        {
            int excelRowIdx = 1, excelColIdx = 1;
            try
            {
                var data = (List<SalesReportInformation>)input;

                if (data == null || data.Count() == 0)
                    return "Data to Export cannot be NULL.";

                var rowCount = data.Count();

                foreach(var item in data)
                {
                    var properties = item.GetType().GetProperties();

                    foreach(var property in properties)
                    {
                        var value = property.GetValue(item);

                        if (property.PropertyType.Name == "Decimal")
                            value = Convert.ToDouble(value).ToString(Common.Constants.N0_FORMAT);

                        if(excelRowIdx == 1)
                        {
                            //Initialize Header and 1st Row
                            _excelWorksheet.Cells[excelRowIdx, excelColIdx] = property.Name;
                            _excelWorksheet.Cells[excelRowIdx + 1, excelColIdx] = value;
                        }
                        else
                        {
                            //Initialize 2nd Row and more
                            _excelWorksheet.Cells[excelRowIdx, excelColIdx] = value;
                        }
                        excelColIdx++;
                    }
                    excelRowIdx++;
                }

                _excelWorkbook.SaveAs(@"C:\Users\vince\OneDrive\Desktop\test.xlsx", Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                      XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing);
                _excelApp.Quit();

                return @"C:\Users\vince\OneDrive\Desktop\test.xlsx";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
