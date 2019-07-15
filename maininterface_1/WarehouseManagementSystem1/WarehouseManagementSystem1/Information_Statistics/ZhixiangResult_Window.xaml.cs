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

namespace WarehouseManagementSystem1.Information_Statistics
{
    /// <summary>
    /// ZhixiangResult_Window.xaml 的交互逻辑
    /// </summary>
    public partial class ZhixiangResult_Window : Window
    {
        ObservableCollection<ZhixiangMessage> ZhixiangData = new ObservableCollection<ZhixiangMessage>();
        private SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");
        WarehouseManagementSystem1.ExportExcel ExportExcel = new ExportExcel();

        public string DataStart { get; set; }
        public string DataEnd { get; set; }
        public string TypeR { get; set; }
        public string Sipplier { get; set; }
        public int RowCount = 0;
        public int NumSum = 0;
        public double ZhongjiaSum = 0;

        public ZhixiangResult_Window()
        {
            InitializeComponent();
            DBConnection2.Open();
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            string sqlcommand;
            if (TypeR == "全部")
            {
                sqlcommand = "select * from Zhixiang where Merchant='" + Sipplier + "' and Time>='" + DataStart + "' and Time<='" + DataEnd + "'";
            }
            else
            {
                sqlcommand = "select * from Zhixiang where Merchant='" + Sipplier + "' and  Type='" + TypeR + "' and Time>='" + DataStart + "' and Time<='" + DataEnd + "'";
            }
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                RowCount += 1;
                ZhixiangData.Add(new ZhixiangMessage()
                {
                    Type = reader["Type"].ToString(),
                    Data = reader["Time"].ToString(),
                    Number = reader["Number"].ToString(),
                    UnitPrice = reader["Price"].ToString(),
                    Name = reader["Merchant"].ToString(),
                    Count = Convert.ToDouble(reader["Number"].ToString()) * Convert.ToDouble(reader["Price"].ToString())
                }) ;
                NumSum += Convert.ToInt32(reader["Number"]);
                ZhongjiaSum += Convert.ToDouble(reader["Number"].ToString()) * Convert.ToDouble(reader["Price"].ToString());
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
                case "返回":
                    DBConnection2.Close();
                    this.Close();
                    break;
                case "导出":
                    ExportExcel.ExportZhixiang(Zhixiang_message, "纸箱纸管塑料袋账单", RowCount, ZhixiangData, 0);
                    break;
            }
        }
    }
}
