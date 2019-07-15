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
    /// ModelAndColor_Inquiry_Window.xaml 的交互逻辑
    /// </summary>
    public partial class ModelAndColor_Inquiry_Window : Window
    {
        public ModelAndColor_Inquiry_Window()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Window w = null;
            switch (btn.Content.ToString())
            {
                case "颜色":
                    w = new Color_Window();
                    break;
                case "型号":
                    w = new Model_Window();
                    break;
                case "返回":
                    this.Close();
                    break;
            }
            if (w != null)
            {
                w.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                w.Owner = this;
                w.ShowDialog();
            }
        }
    }
    class ModelAndColorMessage
    {
        public string Number { get; set; }
        public string Merchant { get; set; }
        public string Message { get; set; }
    }
}
