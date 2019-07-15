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
    /// Information_Inquiry_Main_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Information_Inquiry_Main_Window : Window
    {
        public Information_Inquiry_Main_Window()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Window w = null;
            //按下对应的键时打开对应的窗口
            switch (btn.Content.ToString())
            {
                case "原料查询":
                    w = new Material_Type_Window();
                    break;
                case "包纱查询":
                    w = new Product_Information_Inquiry();
                    break;
                case "商家查询":
                    w = new Merchant_Inquiry();
                    break;
                case "型号和颜色":
                    w = new ModelAndColor_Inquiry_Window();
                    break;
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
    //用于保存下拉栏信息的类
    public class ComboBoxValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
