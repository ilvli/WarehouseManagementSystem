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
    /// ChangsiAnlun_Window.xaml 的交互逻辑
    /// </summary>
    public partial class ChangsiAnlun_Window : Window
    {
        ObservableCollection<ComboBoxValue> ReceivingMerchant = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> TypeValue = new ObservableCollection<ComboBoxValue>();

        WarehouseManagementSystem1.Sqlite_Operate_Function sqlite_Operate = new Sqlite_Operate_Function();
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\test1.sqlite");
        public ChangsiAnlun_Window()
        {
            InitializeComponent();
            DBConnection2.Open();

            //设置收货商下拉栏
            SipplierCombo.ItemsSource = ReceivingMerchant;
            SipplierCombo.DisplayMemberPath = "Name";
            SipplierCombo.SelectedValuePath = "Value";
            //设置类别下拉栏
            TypeCombo.ItemsSource = TypeValue;
            TypeCombo.DisplayMemberPath = "Name";
            TypeCombo.SelectedValuePath = "Value";
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
            TypeValue.Add(new ComboBoxValue()
            {
                Name = "长丝",
                Value = "长丝"
            });
            TypeValue.Add(new ComboBoxValue()
            {
                Name = "氨纶",
                Value = "氨纶"
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Window w = null;
            switch (btn.Content.ToString())
            {
                case "确定":
                    sqlite_Operate.InsertChangsiTable(DBConnection2, TypeCombo.Text, tbbTime.Text, tbColor.Text, tbModel.Text, tbWeight.Text, SipplierCombo.Text);
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

        private void TypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeCombo.SelectedValue.ToString() == "氨纶")
            {
                tbColor.IsEnabled = false;
            }
            else
            {
                tbColor.IsEnabled = true;
            }
        }
    }
}
