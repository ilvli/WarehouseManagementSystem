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

namespace WarehouseManagementSystem1.Input_Information
{
    /// <summary>
    /// Zhixiang_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Zhixiang_Window : Window
    {
        ObservableCollection<TypeValue> TypeBoxValue = new ObservableCollection<TypeValue>();

        public Zhixiang_Window()
        {
            InitializeComponent();

            //设置种类下拉栏
            TypeCombo.ItemsSource = TypeBoxValue;
            TypeCombo.DisplayMemberPath = "Name";
            TypeCombo.SelectedValuePath = "Value";
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            TypeBoxValue.Add(new TypeValue()
            {
                Name = "纸箱",
                Value = "纸箱"
            });
            TypeBoxValue.Add(new TypeValue()
            {
                Name = "纸管",
                Value = "纸管"
            });
            TypeBoxValue.Add(new TypeValue()
            {
                Name = "塑料袋",
                Value = "塑料袋"
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Window w = null;
            switch (btn.Content.ToString())
            {
                case "确定": break;
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
    public class TypeValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
