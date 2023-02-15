using AllOut.Desktop.Common;
using AllOut.Desktop.Models;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AllOut.Desktop.Services
{
    public class ExcelService<T>
    {
        private ApplicationClass _excelApp;
        private readonly Workbook _excelWorkbook;
        private readonly Worksheet _excelWorksheet;
        private readonly object _misValue;

        private int TITLE_ROW_IDX = 1,
                    DEFAULT_START_ROW_IDX = 2, 
                    DEFAULT_START_COL_IDX = 1;

        private string _Title = string.Empty;

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
                _Title = value;
                _excelWorksheet.Name = _Title;
                _excelWorksheet.Cells[TITLE_ROW_IDX, DEFAULT_START_COL_IDX] = _Title.ToUpper();
            }
        }

        public string ExportToExcel()
        {
            try
            {
                if (_data == null || _data.Count() == 0)
                    return "Data to Export cannot be NULL.";

                var file = GenerateFileName();

                var expectedColumnCount = _data.First().GetType().GetProperties().Count();
                var expectedRowCount = _data.Count() + DEFAULT_START_ROW_IDX;

                //Set Design Title
                SetDesignToCellTitle(expectedColumnCount);

                //Populate Data in Excel Cells
                var excelRowIdx = DEFAULT_START_ROW_IDX;
                foreach (var item in _data)
                {
                    var properties = item.GetType().GetProperties();
                    var excelColIdx = DEFAULT_START_COL_IDX;
                    foreach (var property in properties)
                    {
                        var value = property.GetValue(item);

                        if (property.PropertyType.Name == "Decimal")
                            value = Convert.ToDouble(value).ToString(Common.Constants.N0_FORMAT);

                        if (property.Name.Contains("Date"))
                            value = value == null ? Common.Constants.NA : DateTime.Parse(value.ToString()).ToString(Common.Constants.DATE_FORMAT);

                        if (property.Name == "Status")
                            value = Utility.ConvertStatusToString((int)value);

                        if (excelRowIdx == DEFAULT_START_ROW_IDX)
                        {
                            //Initialize Header and 1st Row
                            _excelWorksheet.Cells[excelRowIdx, excelColIdx] = property.Name;
                            _excelWorksheet.Cells[excelRowIdx + 1, excelColIdx] = value == null ? Common.Constants.NA : value.ToString();
                        }
                        else
                        {
                            //Initialize 2nd Row and more
                            _excelWorksheet.Cells[excelRowIdx, excelColIdx] = value == null ? Common.Constants.NA : value.ToString();
                        }
                        excelColIdx++;
                    }
                    excelRowIdx += excelRowIdx == DEFAULT_START_ROW_IDX ? DEFAULT_START_ROW_IDX : 1;
                }

                //Align All Cells to Center
                _excelWorksheet.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                //Set Design Header
                SetDesignToCellHeader(DEFAULT_START_ROW_IDX, expectedColumnCount);

                //Set Border
                SetBorderToAllCells(expectedRowCount, expectedColumnCount);

                _excelWorkbook.SaveAs(file, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                      XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing);
                _excelApp.Quit();

                return file;
            }
            catch (Exception ex)
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

        private void SetDesignToCellTitle(int columnCount)
        {
            var range = _excelWorksheet.Range[_excelWorksheet.Cells[TITLE_ROW_IDX, DEFAULT_START_COL_IDX],
                                              _excelWorksheet.Cells[TITLE_ROW_IDX, columnCount]];
            range.Merge();
            range.Font.Size = 30;
            range.Font.Bold = true;
        }

        private void SetDesignToCellHeader(int headerRowIdx, int columnCount)
        {
            var range = _excelWorksheet.Range[_excelWorksheet.Cells[headerRowIdx, DEFAULT_START_COL_IDX],
                                              _excelWorksheet.Cells[headerRowIdx, columnCount]];
            range.Font.Bold = true;
        }

        private void SetBorderToAllCells(int rowCount, int columnCount)
        {
            var range = _excelWorksheet.Range[_excelWorksheet.Cells[TITLE_ROW_IDX, DEFAULT_START_COL_IDX],
                                              _excelWorksheet.Cells[rowCount, columnCount]];
            range.Columns.AutoFit();
            Borders borders = range.Borders;
            borders.LineStyle = XlLineStyle.xlContinuous;
            borders.Weight = 2d;
        }

        private string GenerateFileName()
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (!Directory.Exists(documentPath))
                //If document path is not Exist create it
                Directory.CreateDirectory(documentPath);

            var folderPath = string.Format(Common.Constants.FOLDER_PATH_FORMAT, documentPath, _Title);

            if (!Directory.Exists(folderPath))
                //If folder path is not Exist create it
                Directory.CreateDirectory(folderPath);

            var datetime = DateTime.Now.ToString(Common.Constants.DATETIME_FORMAT);

            //Remove White Space
            var title = String.Concat(_Title.Where(c => !Char.IsWhiteSpace(c)));
            var fileName = string.Format(Common.Constants.EXCEL_FILE_FORMAT, title, datetime);

            return string.Concat(folderPath, fileName);
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
