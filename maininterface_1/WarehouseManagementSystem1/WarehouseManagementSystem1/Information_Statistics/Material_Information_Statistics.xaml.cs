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
    /// Material_Information_Statistics.xaml 的交互逻辑
    /// </summary>
    public partial class Material_Information_Statistics : Window
    {
        ObservableCollection<ComboBoxValue> ReceivingMerchant = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> Color = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> Type = new ObservableCollection<ComboBoxValue>();

        public Material_Information_Statistics()
        {
            InitializeComponent();

            //设置收货商下拉栏
            SupplierCombo.ItemsSource = ReceivingMerchant;
            SupplierCombo.DisplayMemberPath = "Name";
            SupplierCombo.SelectedValuePath = "Value";
            //设置颜色下拉栏
            ColorCombo.ItemsSource = Color;
            ColorCombo.DisplayMemberPath = "Name";
            ColorCombo.SelectedValuePath = "Value";
            //设置型号下拉栏
            TypeCombo.ItemsSource = Type;
            TypeCombo.DisplayMemberPath = "Name";
            TypeCombo.SelectedValuePath = "Value";
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            ReceivingMerchant.Add(new ComboBoxValue()
            {
                Name = "宝莎",
                Value = "宝莎"
            });
            ReceivingMerchant.Add(new ComboBoxValue()
            {
                Name = "刘涛",
                Value = "刘涛"
            });
            Color.Add(new ComboBoxValue()
            {
                Name = "大红",
                Value = "大红"
            });
            Color.Add(new ComboBoxValue()
            {
                Name = "藏青",
                Value = "藏青"
            });
            Type.Add(new ComboBoxValue()
            {
                Name = "A304",
                Value = "A304"
            });
        }

            private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Window w = null;
            switch (btn.Content.ToString())
            {
                case "返回": this.Close(); break;
                case "确定":
                    w = new ChangsiResult_Window();
                    string combostr = SupplierCombo.SelectedValue.ToString() + "\n" + TypeCombo.SelectedValue.ToString() + "\n" + ColorCombo.SelectedValue.ToString();
                    MessageBoxResult result = MessageBox.Show(combostr, "下拉栏选择的信息", MessageBoxButton.OK);
                    break;
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
