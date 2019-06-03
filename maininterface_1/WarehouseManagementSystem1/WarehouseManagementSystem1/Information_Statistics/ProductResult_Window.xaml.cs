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

namespace WarehouseManagementSystem1.Information_Statistics
{
    /// <summary>
    /// ProductResult_Window.xaml 的交互逻辑
    /// </summary>
    public partial class ProductResult_Window : Window
    {
        ObservableCollection<ProductMessage> materialData = new ObservableCollection<ProductMessage>();
        public ProductResult_Window()
        {
            InitializeComponent();
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            materialData.Add(new ProductMessage()
            {
                Data = "2019-2-12",
                Model = "A12321",
                Weight = 24.4,
                Color = "大红",
                Number = 21,
                IsSend = false,
                Name = "宝莎"
            });
            materialData.Add(new ProductMessage()
            {
                Data = "2019-5-12",
                Model = "A80212",
                Weight = 29.2,
                Color = "黑",
                Number = 34,
                IsSend = true,
                Name = "宝莎"
            });

            Product_message.ItemsSource = materialData;
        }
    }
    public class ProductMessage
    {
        public string Data { get; set; }//收货日期
        public string Model { get; set; }//类型
        public double Weight { get; set; }
        public string Color { get; set; }
        public int Number { get; set; }
        public bool IsSend { get; set; }
        public string Name { get; set; }//收货商家
    }
}
