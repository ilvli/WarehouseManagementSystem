using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WarehouseManagementSystem1
{
    class ExportExcel
    {
        public void ExcelExport(System.Data.DataTable dt, string SheetName)
        {
            Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();
            SaveFileDialog savefiledialog = new SaveFileDialog();
            System.Reflection.Missing miss = System.Reflection.Missing.Value;
            appexcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbookdata = appexcel.Workbooks.Add(System.Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheetdata = (Microsoft.Office.Interop.Excel.Worksheet)workbookdata.Worksheets[1];
            //Microsoft.Office.Interop.Excel.Range rangedata;

            //创建Excel
            //Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            //Microsoft.Office.Interop.Excel.Workbook ExcelBook = appexcel.Workbooks.Add(System.Type.Missing);
            ////创建工作表（即Excel里的子表sheet） 1表示在子表sheet1里进行数据导出
            //Microsoft.Office.Interop.Excel.Worksheet ExcelSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelBook.Worksheets[1];
            ////设置Sheet标题
            string start = "A1";
            string end = ChangeASC(dt.Columns.Count) + "1";

            Microsoft.Office.Interop.Excel.Range _Range = (Microsoft.Office.Interop.Excel.Range)worksheetdata.get_Range(start, end);
            _Range.Merge(0);                     //单元格合并动作(要配合上面的get_Range()进行设计)
            _Range = worksheetdata.get_Range(start, end);
            _Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            _Range.Font.Size = 22; //设置字体大小
            _Range.Font.Name = "宋体"; //设置字体的种类 
            worksheetdata.Cells[1, 1] = SheetName;    //Excel单元格赋值
            _Range.EntireColumn.AutoFit(); //自动调整列宽

            //设置对象不可见
            appexcel.Visible = false;
            System.Globalization.CultureInfo currentci = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");

            //workbookdata = appexcel.Workbooks.Add(miss);
            //worksheetdata = (Microsoft.Office.Interop.Excel.Worksheet)workbookdata.Worksheets.Add(miss, miss, miss, miss);

            //给工作表赋名称
            worksheetdata.Name = SheetName;

            start = "A2";
            end = ChangeASC(dt.Columns.Count) + "2";
            _Range = worksheetdata.get_Range(start, end);
            _Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                worksheetdata.Cells[2, i + 1] = dt.Columns[i].ColumnName.ToString();
            }

            //因为第一行已经写了表头，所以所有数据都应该从a2开始
            //rangedata = worksheetdata.get_Range("a3", miss);
            //Microsoft.Office.Interop.Excel.Range xlrang = null;

            //irowcount为实际行数，最大行
            int irowcount = dt.Rows.Count;
            int iparstedrow = 1, icurrsize = 0;

            //ieachsize为每次写行的数值，可以自己设置
            int ieachsize = 1000;

            //icolumnaccount为实际列数，最大列数
            int icolumnaccount = dt.Columns.Count;

            //在内存中声明一个ieachsize×icolumnaccount的数组，ieachsize是每次最大存储的行数，icolumnaccount就是存储的实际列数
            object[,] objval = new object[ieachsize + 1, icolumnaccount];
            icurrsize = ieachsize;

            while (iparstedrow <= irowcount)
            {
                if ((irowcount - iparstedrow) < ieachsize)
                    icurrsize = irowcount - iparstedrow + 1;
                //用for循环给数组赋值
                for (int i = 0; i < icurrsize; i++)
                {
                    for (int j = 0; j < icolumnaccount; j++)
                        objval[i, j] = dt.Rows[i + iparstedrow - 1][j].ToString();
                    //System.Windows.Forms.Application.DoEvents();
                }
                string X = "A" + ((int)(iparstedrow + 2)).ToString();
                string col = "";
                if (icolumnaccount <= 26)
                {
                    col = ((char)('A' + icolumnaccount - 1)).ToString() + ((int)(iparstedrow + icurrsize + 1)).ToString();
                }
                else
                {
                    col = ((char)('A' + (icolumnaccount / 26 - 1))).ToString() + ((char)('A' + (icolumnaccount % 26 - 1))).ToString() + ((int)(iparstedrow + icurrsize + 1)).ToString();
                }
                _Range = worksheetdata.get_Range(X, col);
                // 调用range的value2属性，把内存中的值赋给excel
                _Range.Value2 = objval;
                _Range.EntireColumn.AutoFit(); //自动调整列宽
                _Range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                iparstedrow = iparstedrow + icurrsize;
            }

            //保存工作表
            System.Runtime.InteropServices.Marshal.ReleaseComObject(_Range);
            _Range = null;

            //调用方法关闭excel进程
            appexcel.Visible = true;
        }

        public void ExportProduct(DataGrid dgData, string excelTitle,int RowCount, ObservableCollection<ProductMessage> ProductData,int type)
        {
            DataTable dt = new DataTable();
            for (int i = type; i < dgData.Columns.Count; i++)
            {
                if (dgData.Columns[i].Visibility == System.Windows.Visibility.Visible)//只导出可见列  
                {
                    dt.Columns.Add(dgData.Columns[i].Header.ToString());//构建表头  
                }
            }
            for (int i = 0; i < RowCount; i++)
            {
                dt.Rows.Add(ProductData[i].Data.ToString(), ProductData[i].Model.ToString(), ProductData[i].Weight,
                    ProductData[i].Color.ToString(), ProductData[i].Number, ProductData[i].IsSend.ToString(), ProductData[i].Name.ToString());
            }

            ExcelExport(dt, excelTitle);
        }

        public void ExportChangsi(DataGrid dgData, string excelTitle, int RowCount, ObservableCollection<ChangsiMessage> materialData,int type)
        {
            DataTable dt = new DataTable();
            for (int i = type; i < dgData.Columns.Count; i++)
            {
                if (dgData.Columns[i].Visibility == System.Windows.Visibility.Visible)//只导出可见列  
                {
                    dt.Columns.Add(dgData.Columns[i].Header.ToString());//构建表头  
                }
            }
            for (int i = 0; i < RowCount; i++)
            {
                dt.Rows.Add(materialData[i].Data.ToString(), materialData[i].Type.ToString(), materialData[i].Model.ToString(), materialData[i].Weight.ToString(),
                    materialData[i].Color.ToString(), materialData[i].Name.ToString());
            }

            ExcelExport(dt, excelTitle);
        }

        public void ExportZhixiang(DataGrid dgData, string excelTitle, int RowCount, ObservableCollection<ZhixiangMessage> ZhixiangData,int type)
        {
            DataTable dt = new DataTable();
            for (int i = type; i < dgData.Columns.Count; i++)
            {
                if (dgData.Columns[i].Visibility == System.Windows.Visibility.Visible)//只导出可见列  
                {
                    dt.Columns.Add(dgData.Columns[i].Header.ToString());//构建表头  
                }
            }
            for (int i = 0; i < RowCount; i++)
            {
                dt.Rows.Add(ZhixiangData[i].Data.ToString(), ZhixiangData[i].Type.ToString(), ZhixiangData[i].Number,
                    ZhixiangData[i].UnitPrice, ZhixiangData[i].Count.ToString(),ZhixiangData[i].Name.ToString());
            }

            ExcelExport(dt, excelTitle);
        }

        private string ChangeASC(int count)
        {
            string ascstr = "";
            switch (count)
            {
                case 1:
                    ascstr = "A";
                    break;
                case 2:
                    ascstr = "B";
                    break;
                case 3:
                    ascstr = "C";
                    break;
                case 4:
                    ascstr = "D";
                    break;
                case 5:
                    ascstr = "E";
                    break;
                case 6:
                    ascstr = "F";
                    break;
                case 7:
                    ascstr = "G";
                    break;
                case 8:
                    ascstr = "H";
                    break;
                case 9:
                    ascstr = "I";
                    break;
                case 10:
                    ascstr = "J";
                    break;
                case 11:
                    ascstr = "K";
                    break;
                case 12:
                    ascstr = "L";
                    break;
                case 13:
                    ascstr = "M";
                    break;
                case 14:
                    ascstr = "N";
                    break;
                case 15:
                    ascstr = "O";
                    break;
                case 16:
                    ascstr = "P";
                    break;
                case 17:
                    ascstr = "Q";
                    break;
                case 18:
                    ascstr = "R";
                    break;
                case 19:
                    ascstr = "S";
                    break;
                case 20:
                    ascstr = "T";
                    break;
                default:
                    ascstr = "U";
                    break;
            }
            return ascstr;
        }
    }
}
