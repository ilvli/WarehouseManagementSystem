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

namespace WarehouseManagementSystem1.Information_Statistics
{
    /// <summary>
    /// Information_Statistics_Main_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Information_Statistics_Main_Window : Window
    {
        public Information_Statistics_Main_Window()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Window w = null;
            switch (btn.Content.ToString())
            {
                case "包纱":
                    w = new Product_Information_Statistics();
                    break;
                case "原料":
                    w = new Material_Type_Sta_Window();
                    break;
                case "返回": this.Close(); break;
            }
            if (w != null)
            {
                this.Hide();
                w.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                w.Owner = this;
                w.ShowDialog();
                this.ShowDialog();
            }
        }
    }
    public class ComboBoxValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
