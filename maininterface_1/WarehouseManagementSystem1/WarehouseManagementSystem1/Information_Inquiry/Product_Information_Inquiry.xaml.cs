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
    /// Product_Information_Inquiry.xaml 的交互逻辑
    /// </summary>
    public partial class Product_Information_Inquiry : Window
    {
        public Product_Information_Inquiry()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "返回": this.Close(); break;
                case "查询":
                    //当按下查询按键时，将查询的条件传递给查询结果窗口，并将窗口显示出来
                    Product_result Result = new Product_result
                    {
                        DataStart = tbStartTime.Text,
                        DataEnd = tbEndTime.Text
                    };
                    Result.ShowDialog();
                    Result.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                    break;
            }
        }
    }
}
