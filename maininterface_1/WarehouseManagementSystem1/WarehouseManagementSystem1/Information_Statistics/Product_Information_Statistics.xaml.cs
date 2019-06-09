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
        ObservableCollection<ComboBoxValue> ReceivingMerchant = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> Color = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> Model = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> IsSending = new ObservableCollection<ComboBoxValue>();
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\test1.sqlite");

        public Product_Information_Statistics()
        {
            InitializeComponent();
            DBConnection2.Open();
            //设置收货商下拉栏
            ReceivingMerchantCombo.ItemsSource = ReceivingMerchant;
            ReceivingMerchantCombo.DisplayMemberPath = "Name";
            ReceivingMerchantCombo.SelectedValuePath = "Value";
            //设置颜色下拉栏
            ColorCombo.ItemsSource = Color;
            ColorCombo.DisplayMemberPath = "Name";
            ColorCombo.SelectedValuePath = "Value";
            //设置型号下拉栏
            ModelCombo.ItemsSource = Model;
            ModelCombo.DisplayMemberPath = "Name";
            ModelCombo.SelectedValuePath = "Value";
            //设置发货状态下拉栏
            IsSendingCombo.ItemsSource = IsSending;
            IsSendingCombo.DisplayMemberPath = "Name";
            IsSendingCombo.SelectedValuePath = "Value";
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            string sqlcommand = "select Name from Merchant where Type='收货商'";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReceivingMerchant.Add(new ComboBoxValue()
                {
                    Name = reader["Name"].ToString(),
                    Value = reader["Name"].ToString()
                });
            }
            sqlcommand = "select DISTINCT Color from Product";
            command = new SQLiteCommand(sqlcommand, DBConnection2);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Color.Add(new ComboBoxValue()
                {
                    Name = reader["Color"].ToString(),
                    Value = reader["Color"].ToString()
                });
            }
            sqlcommand = "select DISTINCT Model from Product ";
            command = new SQLiteCommand(sqlcommand, DBConnection2);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Model.Add(new ComboBoxValue()
                {
                    Name = reader["Model"].ToString(),
                    Value = reader["Model"].ToString()
                });
            }
            
            IsSending.Add(new ComboBoxValue()
            {
                Name = "已发货",
                Value = "1"
            });
            IsSending.Add(new ComboBoxValue()
            {
                Name = "未发货",
                Value = "0"
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString()){
                case "确定":
                    ProductResult_Window Result = new ProductResult_Window
                    {
                        DataStart = tbStartData.Text,
                        DataEnd = tbEndData.Text,
                        Merchant = ReceivingMerchantCombo.Text,
                        Model = ModelCombo.Text,
                        IsSending = IsSendingCombo.SelectedValue.ToString(),
                        Color = ColorCombo.Text
                    };
                    Result.ShowDialog();
                    Result.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                    break; 
                case "取消": this.Close(); break;
            }
        }
    }
}
