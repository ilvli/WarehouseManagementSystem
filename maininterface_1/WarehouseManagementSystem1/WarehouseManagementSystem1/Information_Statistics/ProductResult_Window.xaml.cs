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
    /// ProductResult_Window.xaml 的交互逻辑
    /// </summary>
    public partial class ProductResult_Window : Window
    {
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\test1.sqlite");
        ObservableCollection<ProductMessage> ProductData = new ObservableCollection<ProductMessage>();

        public string Merchant { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string IsSending { get; set; }
        public string DataStart { get; set; }
        public string DataEnd { get; set; }

        public ProductResult_Window()
        {
            InitializeComponent();
            DBConnection2.Open();
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            string sqlcommand = "select * from Product where Merchant='" + Merchant + "' and Color='" + Color + "' and Model='" + Model + "' and IsSending='" + IsSending + "' and Time>='" + DataStart + "' and Time<='" + DataEnd + "'";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string IsSendTmp = reader["IsSending"].ToString();
                if (IsSendTmp == "1") { IsSendTmp = "已发货"; }
                else { IsSendTmp = "未发货"; }

                ProductData.Add(new ProductMessage()
                {
                    Data = reader["Time"].ToString(),
                    Model = reader["Model"].ToString(),
                    Weight = reader["Weight"].ToString(),
                    Color = reader["Color"].ToString(),
                    Number = reader["Number"].ToString(),
                    IsSend = IsSendTmp,
                    Name = reader["Merchant"].ToString()
                });
            }

            Product_message.ItemsSource = ProductData;
        }
    }
    public class ProductMessage
    {
        public string Data { get; set; }//收货日期
        public string Model { get; set; }//类型
        public string Weight { get; set; }
        public string Color { get; set; }
        public string Number { get; set; }
        public string IsSend { get; set; }
        public string Name { get; set; }//收货商家
    }
}
