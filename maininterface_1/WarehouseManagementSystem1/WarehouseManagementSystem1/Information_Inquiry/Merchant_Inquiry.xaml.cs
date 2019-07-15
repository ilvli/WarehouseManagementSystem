using System;
using System.Collections.Generic;
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
    /// Merchant_Inquiry.xaml 的交互逻辑
    /// </summary>
    public partial class Merchant_Inquiry : Window
    {
        public Merchant_Inquiry()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Window w = null;
            //按下对应键时打开对应的窗口
            switch (btn.Content.ToString())
            {
                case "返回": this.Close(); break;
                case "供货商家":w = new Supplier_Information();break;
                case "收货商家": w = new Receiving_Merchant_Information(); break;
            }
            if (w != null)
            {
                w.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                w.Owner = this;
                w.ShowDialog();
            }
        }
    }
    //用于保存商家信息的类
    public class MerchantMessage
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public string Type { get; set; }
    }
}
