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
    /// ChangsiResult_Window.xaml 的交互逻辑
    /// </summary>
    public partial class ChangsiResult_Window : Window
    {
        ObservableCollection<MaterialMessage> materialData = new ObservableCollection<MaterialMessage>();
        public ChangsiResult_Window()
        {
            InitializeComponent();
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            materialData.Add(new MaterialMessage()
            {
                Data = "2019-2-12",
                Type = "长丝",
                Model = "A802",
                Weight = 24.4,
                Color = "大红",
                Name = "宝莎"
            });
            materialData.Add(new MaterialMessage()
            {
                Data = "2019-5-12",
                Type = "氨纶",
                Model = "A802",
                Weight = 29.2,
                Color = "黑",
                Name = "宝莎"
            });

            Material_message.ItemsSource = materialData;
            //((this.FindName("DATA_GRID")) as DataGrid).ItemsSource = merchantData;
        }

    }
    public class MaterialMessage
    {
        public string Data { get; set; }//收货日期
        public string Type { get; set; }//只有长丝/氨纶两种
        public string Model { get; set; }//类型
        public double Weight { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }//供货商家
    }
}