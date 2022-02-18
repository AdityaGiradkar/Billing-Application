using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using ExcelRefrence = Microsoft.Office.Interop.Excel;

namespace Billing_Application
{
    class Excel
    {
        private string _path = "";
        private _Application _excel = new ExcelRefrence.Application();
        private Workbook _wb;
        private Worksheet _ws;
        private int _actualRow;
        private int _actualColumn;


        public int actualRow { get { return _actualRow; } }
        public int actualColumn { get { return _actualColumn; } }


        public Excel(string path, int sheetNumber)
        {
            _path = path;
            _wb = _excel.Workbooks.Open(_path);
            _ws = _wb.Worksheets[sheetNumber];
            _actualRow = _ws.UsedRange.Rows.Count;
            _actualColumn = _ws.UsedRange.Columns.Count;
        }


        public string ReadCell(int row, int column)
        {
            if(_ws.Cells[row, column].Value2 != null)
            {
                return Convert.ToString(_ws.Cells[row, column].Value2);
            }
            else
            {
                return "";
            }
        }

        public void updateQuantityCell(int row, int column, int newQuantity)
        {
            _ws.Cells[row, column].Value2 = newQuantity;
        }

        public void save()
        {
            _wb.Save();
        }

        public void close()
        {
            _wb.Close();
        }
    }
}
