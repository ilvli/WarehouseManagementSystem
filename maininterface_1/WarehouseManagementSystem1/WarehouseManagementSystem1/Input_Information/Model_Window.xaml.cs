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
    /// Model_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Model_Window : Window
    {
        ObservableCollection<ComboBoxValue> TypeValue = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> MerchantValue = new ObservableCollection<ComboBoxValue>();
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");
        WarehouseManagementSystem1.Sqlite_Operate_Function sqlite_Operate = new Sqlite_Operate_Function();

        public Model_Window()
        {
            InitializeComponent();
            DBConnection2.Open();

            //设置类别下拉栏
            TypeCombo.ItemsSource = TypeValue;
            TypeCombo.DisplayMemberPath = "Name";
            TypeCombo.SelectedValuePath = "Value";
            MerchantCombo.ItemsSource = MerchantValue;
            MerchantCombo.DisplayMemberPath = "Name";
            MerchantCombo.SelectedValuePath = "Value";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TypeValue.Add(new ComboBoxValue()
            {
                Name = "包纱",
                Value = "包纱"
            });
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
            switch (btn.Content.ToString())
            {
                case "确定":
                    sqlite_Operate.InsertModelTable(DBConnection2, TypeCombo.Text, MerchantCombo.Text, tbModel.Text);
                    MessageBox.Show("保存成功！", "提醒", MessageBoxButton.OK);
                    this.Close();
                    break;
                case "返回":
                    DBConnection2.Close();
                    this.Close();
                    break;
            }
        }

        private void TypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MerchantValue.Clear();
            MerchantCombo.IsEnabled = true;
            string tmp = "";
            if (TypeCombo.SelectedValue.ToString() == "包纱")
            {
                tmp = "收货商";
            }
            else
            {
                tmp = "供货商";
            }
            string sqlcommand = "select Name from Merchant where Type='" + tmp + "'";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MerchantValue.Add(new ComboBoxValue()
                {
                    Name = reader["Name"].ToString(),
                    Value = reader["Name"].ToString()
                });
            }
        }

        private void MerchantCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BT.IsEnabled = true;
        }
    }
}
