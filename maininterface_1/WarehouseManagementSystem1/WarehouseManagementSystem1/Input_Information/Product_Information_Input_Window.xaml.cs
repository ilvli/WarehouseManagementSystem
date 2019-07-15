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

namespace WarehouseManagementSystem1.Input_Information
{
    /// <summary>
    /// Product_Information_Input_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Product_Information_Input_Window : Window
    {
        ObservableCollection<ComboBoxValue> ReceivingMerchant = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> IsSending = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> ColorValue = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> ModelValue = new ObservableCollection<ComboBoxValue>();
        //自定义的数据库操作类
        WarehouseManagementSystem1.Sqlite_Operate_Function sqlite_Operate = new Sqlite_Operate_Function();
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");
        public Product_Information_Input_Window()
        {
            InitializeComponent();
            DBConnection2.Open();
            //设置收货商下拉栏
            ReceicingMerchantCombo.ItemsSource = ReceivingMerchant;
            ReceicingMerchantCombo.DisplayMemberPath = "Name";
            ReceicingMerchantCombo.SelectedValuePath = "Value";
            //设置发货状态下拉栏
            IsSendingCombo.ItemsSource = IsSending;
            IsSendingCombo.DisplayMemberPath = "Name";
            IsSendingCombo.SelectedValuePath = "Value";
            //设置颜色下拉栏
            ColorCombo.ItemsSource = ColorValue;
            ColorCombo.DisplayMemberPath = "Name";
            ColorCombo.SelectedValuePath = "Value";
            //设置型号下拉栏
            ModelCombo.ItemsSource = ModelValue;
            ModelCombo.DisplayMemberPath = "Name";
            ModelCombo.SelectedValuePath = "Value";

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
            //加载发货状态
            IsSending.Add(new ComboBoxValue()
            {
                Name = "已发货",
                Value = "已发货"
            });
            IsSending.Add(new ComboBoxValue()
            {
                Name = "未发货",
                Value = "未发货"
            });
            
            //加载收货商下拉栏
            string sqlcommand = "select * from Merchant where Type='收货商'";
            LoadCombo(sqlcommand, ReceivingMerchant, "Name");
            

            sqlcommand = "select Message from ModelAndColor where Type='颜色'";
            LoadCombo(sqlcommand, ColorValue, "Message");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "确定":
                    //调用自定义的数据库操作类的插入函数
                    sqlite_Operate.InsertProductTable(DBConnection2, tbTime.Text, ColorCombo.Text, 
                        ModelCombo.Text,tbWeight.Text, tbNumber.Text, IsSendingCombo.SelectedValue.ToString(),
                        ReceicingMerchantCombo.Text);
                    //提示保存成功
                    MessageBox.Show("保存成功！", "提醒", MessageBoxButton.OK);
                    this.Close();
                    break;
                case "返回":
                    DBConnection2.Close();
                    this.Close();
                    break;
            }
        }

        private void IsSendingCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //当发货状态为已发货时，将发货日期栏设置为可用，否则不可用
            if (IsSendingCombo.SelectedValue.ToString() == "未发货")
            {
                tbTime.IsEnabled = false;
            }
            else
            {
                tbTime.IsEnabled = true;
            }
        }

        private void ReceicingMerchantCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ModelValue.Clear();
            ModelCombo.IsEnabled = true;
            //加载型号下拉栏
            string sqlcommand = "select Message from ModelAndColor where Type='包纱' and Merchant='" + ReceicingMerchantCombo.SelectedValue.ToString() + "'";
            LoadCombo(sqlcommand, ModelValue, "Message");
        }
    }
}
