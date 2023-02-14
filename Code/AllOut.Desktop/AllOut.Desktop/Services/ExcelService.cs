using AllOut.Desktop.Models;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AllOut.Desktop.Services
{
    public class ExcelService<T>
    {
        private ApplicationClass _excelApp;
        private readonly Workbook _excelWorkbook;
        private readonly Worksheet _excelWorksheet;
        private readonly object _misValue;

        private int _excelDefaultRowIdx = 2, _excelDefaultColIdx = 1;
        private int _firstRowIdx = 1;
        private int _firstColIdx = 1;

        private readonly List<T> _data;

        public ExcelService(List<T> values)
        {
            _excelApp = new ApplicationClass();

            _misValue = System.Reflection.Missing.Value;
            _excelWorkbook = _excelApp.Workbooks.Add(_misValue);

            //Get Default Work Sheet
            _excelWorksheet = (Worksheet)_excelWorkbook.Worksheets.get_Item(1);

            //Clear Worksheet Rows
            _excelWorksheet.Rows.Clear();

            _data = values;
        }

        public string Title
        {
            set
            {
                _excelWorksheet.Name = value;
                _excelWorksheet.Cells[_firstRowIdx, _firstColIdx] = value;
            }
        }

        public string ExportToExcel()
        {
            try
            {
                _excelDefaultRowIdx = 2;
                _excelDefaultColIdx = 1;

                if (_data == null || _data.Count() == 0)
                    return "Data to Export cannot be NULL.";

                foreach(var item in _data)
                {
                    var properties = item.GetType().GetProperties();

                    foreach(var property in properties)
                    {
                        var value = property.GetValue(item);

                        if (property.PropertyType.Name == "Decimal")
                            value = Convert.ToDouble(value).ToString(Common.Constants.N0_FORMAT);

                        if(_excelDefaultRowIdx == 2)
                        {
                            //Initialize Header and 1st Row
                            _excelWorksheet.Cells[_excelDefaultRowIdx, _excelDefaultColIdx] = property.Name;
                            _excelWorksheet.Cells[_excelDefaultRowIdx + 1, _excelDefaultColIdx] = value;
                        }
                        else
                        {
                            //Initialize 2nd Row and more
                            _excelWorksheet.Cells[_excelDefaultRowIdx, _excelDefaultColIdx] = value;
                        }
                        _excelDefaultColIdx++;
                    }
                    _excelDefaultRowIdx++;
                }


                var columnCount = _data.First().GetType().GetProperties().Count();
                var rowCount = _excelDefaultRowIdx;

                _excelWorksheet.Range[_excelWorksheet.Cells[_firstRowIdx, _firstColIdx],
                                                            _excelWorksheet.Cells[_firstRowIdx, columnCount]].Merge();

                var range = _excelWorksheet.Range[_excelWorksheet.Cells[_firstRowIdx, _firstColIdx],
                                                  _excelWorksheet.Cells[rowCount, columnCount]];

                range.Columns.AutoFit();
                Borders borders = range.Borders;
                borders.LineStyle = XlLineStyle.xlContinuous;
                borders.Weight = 2d;
                _excelWorksheet.Cells.Font.Size = 15;


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
            finally
            {
                DisposeObject(_excelWorksheet);
                DisposeObject(_excelWorkbook);
                DisposeObject(_excelApp);
            }
        }

        private void DisposeObject(object data)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(data);
                data = null;
            }
            catch(Exception ex)
            {
                data = null;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
