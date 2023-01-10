using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenEMR.Utilities
{
    public  class ExcelUtils
    {
        public static object[] GetSheetIntoObjectArray(string file, string sheetname)
        {
            using (IXLWorkbook book = new XLWorkbook(file))
            {

                IXLWorksheet sheet = book.Worksheet(sheetname);
                IXLRange range = sheet.RangeUsed();
                int rowCount = range.RowCount();
                int columnCount = range.ColumnCount();

                object[] allData = new object[rowCount - 1];
                for (int r = 2; r <= rowCount; r++)
                {
                    string[] arr = new string[columnCount];
                    for (int c = 1; c <= columnCount; c++)
                    {
                        string Value = range.Cell(r, c).GetString();
                        arr[c - 1] = Value;
                    }
                    allData[r - 2] = arr;
                }
                return allData;



            }



        }

    }
}

