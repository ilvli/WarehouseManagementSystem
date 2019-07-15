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

namespace WarehouseManagementSystem1.Information_Statistics
{
    /// <summary>
    /// Product_Information_Statistics.xaml 的交互逻辑
    /// </summary>
    public partial class Product_Information_Statistics : Window
    {
        ObservableCollection<ComboBoxValue> ReceivingMerchantValue = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> ColorValue = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> ModelValue = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> IsSendingValue = new ObservableCollection<ComboBoxValue>();
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");

        public Product_Information_Statistics()
        {
            InitializeComponent();
            DBConnection2.Open();
            //设置收货商下拉栏
            ReceivingMerchantCombo.ItemsSource = ReceivingMerchantValue;
            ReceivingMerchantCombo.DisplayMemberPath = "Name";
            ReceivingMerchantCombo.SelectedValuePath = "Value";
            //设置颜色下拉栏
            ColorCombo.ItemsSource = ColorValue;
            ColorCombo.DisplayMemberPath = "Name";
            ColorCombo.SelectedValuePath = "Value";
            //设置型号下拉栏
            ModelCombo.ItemsSource = ModelValue;
            ModelCombo.DisplayMemberPath = "Name";
            ModelCombo.SelectedValuePath = "Value";
            //设置发货状态下拉栏
            IsSendingCombo.ItemsSource = IsSendingValue;
            IsSendingCombo.DisplayMemberPath = "Name";
            IsSendingCombo.SelectedValuePath = "Value";

            ModelCombo.IsEnabled = false;
        }

        private void LoadCombo(string sqlcommand, ObservableCollection<ComboBoxValue> comboBoxValues, string NameValue)
        {
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBoxValues.Add(new ComboBoxValue()
                {
                    Name = reader[NameValue].ToString(),
                    Value = reader[NameValue].ToString()
                });
            }
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            //加载收货商信息
            //定义查询语句，将收货商的所有信息都加载进来
            string sqlcommand = "select Name from Merchant where Type='收货商'";
            //执行命令
            LoadCombo(sqlcommand, ReceivingMerchantValue, "Name");

            //加载产品颜色
            sqlcommand = "select Message from ModelAndColor where Type = '颜色'";
            LoadCombo(sqlcommand, ColorValue, "Message");
            ColorValue.Add(new ComboBoxValue()
            {
                Name = "全部",
                Value = "全部"
            });
            
            //加载发货状态
            IsSendingValue.Add(new ComboBoxValue()
            {
                Name = "已发货",
                Value = "已发货"
            });
            IsSendingValue.Add(new ComboBoxValue()
            {
                Name = "未发货",
                Value = "未发货"
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString()){
                case "确定":
                    //创建查询结果窗口并将信息传递给新窗口
                    ProductResult_Window Result = new ProductResult_Window
                    {
                        DataStart = tbStartData.Text,
                        DataEnd = tbEndData.Text,
                        Merchant = ReceivingMerchantCombo.Text,
                        Model = ModelCombo.Text,
                        IsSending = IsSendingCombo.Text,
                        Color = ColorCombo.Text
                    };
                    //显示窗口
                    Result.ShowDialog();
                    Result.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                    break; 
                case "返回": this.Close(); break;
            }
        }

        private void ReceivingMerchantCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ModelValue.Clear();
            ModelCombo.IsEnabled = true;
            //加载型号下拉栏
            string sqlcommand = "select Message from ModelAndColor where Type='包纱' and Merchant='" + ReceivingMerchantCombo.SelectedValue.ToString() + "'";
            LoadCombo(sqlcommand, ModelValue, "Message");
            ModelValue.Add(new ComboBoxValue()
            {
                Name = "全部",
                Value = "全部"
            });
        }
    }
}
