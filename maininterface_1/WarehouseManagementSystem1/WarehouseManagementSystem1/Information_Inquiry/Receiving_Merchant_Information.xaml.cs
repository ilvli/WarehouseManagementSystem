using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public Receiving_Merchant_Information()
        {
            InitializeComponent();
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            merchantData.Add(new MerchantMessage()
            {
                Name = "宝莎",
                Remark = "最大客户",
            });
            merchantData.Add(new MerchantMessage()
            {
                Name = "永发",
                Remark = "价格最优",
            });

            Supplier_message.ItemsSource = merchantData;
        }
    }
}
