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
        WarehouseManagementSystem1.Sqlite_Operate_Function sqlite_Operate = new Sqlite_Operate_Function();
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\test1.sqlite");
        public Product_Information_Input_Window()
        {
            InitializeComponent();
            DBConnection2.Open();
            //设置收货商下拉栏
            SupplierCombo.ItemsSource = ReceivingMerchant;
            SupplierCombo.DisplayMemberPath = "Name";
            SupplierCombo.SelectedValuePath = "Value";
            //设置发货状态下拉栏
            IsSendingCombo.ItemsSource = IsSending;
            IsSendingCombo.DisplayMemberPath = "Name";
            IsSendingCombo.SelectedValuePath = "Value";
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            string sqlcommand = "select * from Merchant where Type='收货商'";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReceivingMerchant.Add(new ComboBoxValue()
                {
                    Name = reader["Name"].ToString(),
                    Value = reader["Message"].ToString()
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
            Window w = null;
            switch (btn.Content.ToString())
            {
                case "确定":
                    sqlite_Operate.InsertProductTable(DBConnection2, tbTime.Text, tbColor.Text, tbModel.Text, tbWeight.Text, tbNumber.Text, IsSendingCombo.SelectedValue.ToString(), SupplierCombo.Text);
                    MessageBox.Show("保存成功！", "提醒", MessageBoxButton.OK);
                    this.Close();
                    break;
                case "取消":
                    this.Close();
                    break;
            }
            if (w != null)
            {
                w.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                w.Owner = this;
                w.ShowDialog();
            }
        }

        private void IsSendingCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsSendingCombo.SelectedValue.ToString() == "1")
            {
                tbTime.IsEnabled = false;
            }
            else
            {
                tbTime.IsEnabled = true;
            }
        }
    }
}
