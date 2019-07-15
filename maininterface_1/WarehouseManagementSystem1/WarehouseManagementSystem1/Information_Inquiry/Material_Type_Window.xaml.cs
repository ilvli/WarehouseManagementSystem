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
    /// Material_Type_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Material_Type_Window : Window
    {
        public Material_Type_Window()
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
                case "长丝/氨纶":
                    w = new Changsi_Inquiry_Window();
                    break;
                case "纸箱/纸管/塑料袋":
                    w = new Zhixiang_Inquiry_Window();
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
}
