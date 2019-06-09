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
    /// Receiving_Merchant_Information.xaml 的交互逻辑
    /// </summary>
    public partial class Receiving_Merchant_Information : Window
    {
        ObservableCollection<MerchantMessage> merchantData = new ObservableCollection<MerchantMessage>();
        private SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\test1.sqlite");

        public Receiving_Merchant_Information()
        {
            InitializeComponent();
            DBConnection2.Open();
            bnSave.IsEnabled = false;
            bnDelete.IsEnabled = false;
            ReceivingMerchant_message.IsReadOnly = true;
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            string sqlcommand = "select * from Merchant where Type='收货商'";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                merchantData.Add(new MerchantMessage()
                {
                    Name = reader["Name"].ToString(),
                    Remark = reader["Message"].ToString()
                });
            }

            ReceivingMerchant_message.ItemsSource = merchantData;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "编辑":
                    ReceivingMerchant_message.IsReadOnly = false;
                    bnSave.IsEnabled = true;
                    bnDelete.IsEnabled = true;
                    break;
                case "保存":
                    ReceivingMerchant_message.IsReadOnly = true;
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
}
