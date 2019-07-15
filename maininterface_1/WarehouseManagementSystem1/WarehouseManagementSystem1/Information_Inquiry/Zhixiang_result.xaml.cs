using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WarehouseManagementSystem1.Information_Inquiry
{
    /// <summary>
    /// Zhixiang_result.xaml 的交互逻辑
    /// </summary>
    public partial class Zhixiang_result : Window
    {
        ObservableCollection<ZhixiangMessage> ZhixiangData = new ObservableCollection<ZhixiangMessage>();
        private SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");
        WarehouseManagementSystem1.ExportExcel ExportExcel = new ExportExcel();
        WarehouseManagementSystem1.Sqlite_Operate_Function sqlite_Operate = new Sqlite_Operate_Function();
        readonly string[] title = { "Time", "Type", "Number", "Price", "Merchant" };

        public string DataStart { get; set; }
        public string DataEnd { get; set; }
        public string TypeR { get; set; }
        public string preValue;
        public int rowIndex = 0;
        public int columnIndex = 0;
        public int RowCount = 0;
        public int NumSum = 0;
        public double ZhongjiaSum = 0.0;

        public Zhixiang_result()
        {
            InitializeComponent();
            DBConnection2.Open();
            bnSave.IsEnabled = false;
            bnDelete.IsEnabled = false;
            Zhixiang_message.IsReadOnly = true;
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            string sqlcommand;
            if (TypeR == "全部")
            {
                sqlcommand = "select rowid,* from Zhixiang where Time>='" + DataStart + "' and Time<='" + DataEnd + "'";
            }
            else
            {
                sqlcommand = "select rowid,* from Zhixiang where Type='" + TypeR + "' and Time>='" + DataStart + "' and Time<='" + DataEnd + "'";
            }
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                RowCount += 1;
                string tmp = reader["Number"].ToString();
                double tmp2 = Convert.ToDouble(reader["Number"].ToString()) * Convert.ToDouble(reader["Price"].ToString());
                ZhixiangData.Add(new ZhixiangMessage()
                {
                    Numb = reader["rowid"].ToString(),
                    Type = reader["Type"].ToString(),
                    Data = reader["Time"].ToString(),
                    Number = tmp,
                    UnitPrice = reader["Price"].ToString(),
                    Name = reader["Merchant"].ToString(),
                    Count = tmp2
                }) ;
                NumSum += Convert.ToInt32(tmp);
                ZhongjiaSum += tmp2;
            }
            Zhixiang_message.ItemsSource = ZhixiangData;
            NumbContent.Content = NumSum.ToString();
            ZongjiaContent.Content = ZhongjiaSum.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "编辑":
                    Zhixiang_message.IsReadOnly = false;
                    bnSave.IsEnabled = true;
                    bnDelete.IsEnabled = true;
                    break;
                case "退出编辑":
                    Zhixiang_message.IsReadOnly = true;
                    bnSave.IsEnabled = false;
                    bnDelete.IsEnabled = false;
                    break;
                case "删除":
                    sqlite_Operate.Delete(DBConnection2, Zhixiang_message, "Zhixiang", ref rowIndex, ZhixiangData[rowIndex].Number);
                    this.Close();
                    break;
                case "返回":
                    DBConnection2.Close();
                    this.Close();
                    break;
                case "导出":
                    ExportExcel.ExportZhixiang(Zhixiang_message, "纸箱纸管塑料袋账单", RowCount, ZhixiangData, 1);
                    break;
            }
        }

        private void Zhixiang_message_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string newValue = (e.EditingElement as TextBox).Text;
            //如果修改后的值和修改前的值不一样
            if (preValue != newValue && newValue != "")
            {
                var _cells = Zhixiang_message.SelectedCells;
                rowIndex = Zhixiang_message.Items.IndexOf(_cells.First().Item);
                columnIndex = e.Column.DisplayIndex;
                if (columnIndex == 6) columnIndex -= 1;
                string sqlcommand = "update Zhixiang set " + title[columnIndex - 1] + "='" + newValue + "' where rowid=" + ZhixiangData[rowIndex].Numb.ToString();
                //执行查询命令
                SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
                command.ExecuteReader();
                MessageBox.Show("编辑成功！", "提醒", MessageBoxButton.OK);
            }
        }

        private void Zhixiang_message_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            preValue = (e.Column.GetCellContent(e.Row) as TextBlock).Text;
        }
    }
}
