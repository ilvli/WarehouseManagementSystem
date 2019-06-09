using System;
using System.Collections.Generic;
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

namespace WarehouseManagementSystem1.Input_Information
{
    /// <summary>
    /// InputMainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class InputMainWindow : Window
    {
        public InputMainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Window w = null;
            switch (btn.Content.ToString())
            {
                case "原料": w = new Material_Information_Input_Window(); break;
                case "产品": w = new Product_Information_Input_Window(); break;
                case "商家": w = new Merchant_Information_Input_Window(); break;
                case "返回": this.Close(); break;
            }
            if (w != null)
            {
                w.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                w.Owner = this;
                w.ShowDialog();
            }
        }
    }
    public class ComboBoxValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
