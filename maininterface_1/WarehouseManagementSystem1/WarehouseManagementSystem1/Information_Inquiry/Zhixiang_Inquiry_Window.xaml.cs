using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WarehouseManagementSystem1.Information_Inquiry
{
    /// <summary>
    /// Zhixiang_Inquiry_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Zhixiang_Inquiry_Window : Window
    {
        ObservableCollection<ComboBoxValue> TypeBoxValue = new ObservableCollection<ComboBoxValue>();
        public Zhixiang_Inquiry_Window()
        {
            InitializeComponent();
            //设置种类下拉栏
            TypeCombo.ItemsSource = TypeBoxValue;
            TypeCombo.DisplayMemberPath = "Name";
            TypeCombo.SelectedValuePath = "Value";
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            TypeBoxValue.Add(new ComboBoxValue()
            {
                Name = "纸箱",
                Value = "纸箱"
            });
            TypeBoxValue.Add(new ComboBoxValue()
            {
                Name = "纸管",
                Value = "纸管"
            });
            TypeBoxValue.Add(new ComboBoxValue()
            {
                Name = "塑料袋",
                Value = "塑料袋"
            });
            TypeBoxValue.Add(new ComboBoxValue()
            {
                Name = "全部",
                Value = "全部"
            });
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "取消":
                    this.Close();
                    break;
                case "查询":
                    Zhixiang_result Result = new Zhixiang_result
                    {
                        DataStart = tbStartData.Text,
                        DataEnd = tbEndData.Text,
                        TypeR = TypeCombo.Text
                    };
                    Result.ShowDialog();
                    Result.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                    break;
            }
        }
    }
}
