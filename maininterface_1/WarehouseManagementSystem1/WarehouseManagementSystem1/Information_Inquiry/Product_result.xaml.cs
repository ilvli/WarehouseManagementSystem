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

namespace WarehouseManagementSystem1.Information_Inquiry
{
    /// <summary>
    /// Product_result.xaml 的交互逻辑
    /// </summary>
    public partial class Product_result : Window
    {
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\test1.sqlite");
        ObservableCollection<ProductMessage> ProductData = new ObservableCollection<ProductMessage>();

        public string DataStart { get; set; }
        public string DataEnd { get; set; }

        public Product_result()
        {
            InitializeComponent();
            DBConnection2.Open();
            bnSave.IsEnabled = false;
            bnDelete.IsEnabled = false;
            Product_message.IsReadOnly = true;
        }
        
        private void LoadData(object sender, RoutedEventArgs e)
        {
            string sqlcommand = "select * from Product where Time>='" + DataStart + "' and Time<='" + DataEnd + "'";
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "编辑":
                    Product_message.IsReadOnly = false;
                    bnSave.IsEnabled = true;
                    bnDelete.IsEnabled = true;
                    break;
                case "保存":
                    Product_message.IsReadOnly = true;
                    bnSave.IsEnabled = false;
                    bnDelete.IsEnabled = false;
                    //string result = Changsi_message.SelectedItem.ToString();
                    MessageBox.Show("编辑成功", "提醒", MessageBoxButton.OK);
                    break;
                case "返回":
                    this.Close();
                    break;
            }
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
