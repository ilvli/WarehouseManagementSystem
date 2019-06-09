using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\test1.sqlite");

        public string DataStart { get; set; }
        public string DataEnd { get; set; }
        public string TypeR { get; set; }
        public string Sipplier { get; set; }

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
                ZhixiangData.Add(new ZhixiangMessage()
                {
                    Type = reader["Type"].ToString(),
                    Data = reader["Time"].ToString(),
                    Number = reader["Number"].ToString(),
                    UnitPrice = reader["Price"].ToString(),
                    Name = reader["Merchant"].ToString(),
                });
            }
            Material_message.ItemsSource = ZhixiangData;
        }
    }
    public class ZhixiangMessage
    {
        public string Data { get; set; }//收货日期
        public string Type { get; set; }//只有长丝/氨纶两种
        public string Number { get; set; }//个数
        public string UnitPrice { get; set; }   //单价
        public string Name { get; set; }//供货商家
    }
}
