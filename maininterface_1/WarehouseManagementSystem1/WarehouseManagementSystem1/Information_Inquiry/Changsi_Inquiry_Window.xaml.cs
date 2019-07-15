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
    /// Changsi_Inquiry_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Changsi_Inquiry_Window : Window
    {
        ObservableCollection<ComboBoxValue> TypeBoxValue = new ObservableCollection<ComboBoxValue>();

        public Changsi_Inquiry_Window()
        {
            InitializeComponent();
            //设置种类下拉栏
            TypeCombo.ItemsSource = TypeBoxValue;
            TypeCombo.DisplayMemberPath = "Name";
            TypeCombo.SelectedValuePath = "Value";
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            //添加类别下拉栏的选项
            TypeBoxValue.Add(new ComboBoxValue()
            {
                Name = "长丝",
                Value = "长丝"
            });
            TypeBoxValue.Add(new ComboBoxValue()
            {
                Name = "氨纶",
                Value = "氨纶"
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
                case "返回":
                    this.Close();
                    break;
                case "查询":
                    //当按下查询按键时，将输入信息传递给长丝/氨纶查询结果窗口，并现实窗口
                    ChangsiResult_Window Result = new ChangsiResult_Window
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
