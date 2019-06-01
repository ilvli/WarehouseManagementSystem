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
    /// ZhiXiang_Window.xaml 的交互逻辑
    /// </summary>
    public partial class ZhiXiang_Window : Window
    {
        //存储种类和供货商信息
        ObservableCollection<ComboBoxValue> TypeBoxValue = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> SiplierBoxValue = new ObservableCollection<ComboBoxValue>();
        public ZhiXiang_Window()
        {
            InitializeComponent();
            //设置种类下拉栏
            TypeCombo.ItemsSource = TypeBoxValue;
            TypeCombo.DisplayMemberPath = "Name";
            TypeCombo.SelectedValuePath = "Value";
            //设置发货商下拉栏
            SiplierCombo.ItemsSource = SiplierBoxValue;
            SiplierCombo.DisplayMemberPath = "Name";
            SiplierCombo.SelectedValuePath = "Value";
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
            SiplierBoxValue.Add(new ComboBoxValue()
            {
                Name = "宝莎",
                Value = "宝莎"
            });
            SiplierBoxValue.Add(new ComboBoxValue()
            {
                Name = "艺流",
                Value = "艺流"
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Window w = null;
            switch (btn.Content.ToString())
            {
                case "确定":
                    string combostr = TypeCombo.SelectedValue.ToString()+"\n"+SiplierCombo.SelectedValue.ToString();
                    MessageBoxResult result = MessageBox.Show(combostr, "下拉栏选择的信息", MessageBoxButton.OK);
                    break;
                case "取消": this.Close(); break;
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
