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

namespace WarehouseManagementSystem1.Input_Information
{
    /// <summary>
    /// Material_Information_Input_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Material_Information_Input_Window : Window
    {
        public Material_Information_Input_Window()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {

                case "返回": this.Close(); break;
            }
            //if (w != null)
            //{
            //    w.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            //    w.Owner = this;
            //    w.ShowDialog();
            //}
        }
    }
}
