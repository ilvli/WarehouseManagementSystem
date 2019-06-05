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
    /// ChangsiAnlun_Window.xaml 的交互逻辑
    /// </summary>
    public partial class ChangsiAnlun_Window : Window
    {
        ObservableCollection<ComboBoxValue> ReceivingMerchant = new ObservableCollection<ComboBoxValue>();

        public ChangsiAnlun_Window()
        {
            InitializeComponent();

            //设置收货商下拉栏
            SupplierCombo.ItemsSource = ReceivingMerchant;
            SupplierCombo.DisplayMemberPath = "Name";
            SupplierCombo.SelectedValuePath = "Value";
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
}
