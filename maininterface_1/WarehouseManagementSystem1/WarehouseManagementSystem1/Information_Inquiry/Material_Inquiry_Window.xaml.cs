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
    /// Material_Inquiry_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Material_Inquiry_Window : Window
    {
        public Material_Inquiry_Window()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window w = null;
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "取消": this.Close(); break;
                case "查询":w = new ChangsiResult_Window();break;
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
