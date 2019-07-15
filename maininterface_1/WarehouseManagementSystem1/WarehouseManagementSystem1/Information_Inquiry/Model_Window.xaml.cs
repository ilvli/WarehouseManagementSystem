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

namespace WarehouseManagementSystem1.Information_Inquiry
{
    /// <summary>
    /// Model_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Model_Window : Window
    {
        ObservableCollection<ComboBoxValue> TypeBoxValue = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> MerchantBoxValue = new ObservableCollection<ComboBoxValue>();
        SQLiteConnection DBConnection = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");

        public Model_Window()
        {
            InitializeComponent();
            TypeCombo.ItemsSource = TypeBoxValue;
            TypeCombo.DisplayMemberPath = "Name";
            TypeCombo.SelectedValuePath = "Value";
            MerchantCombo.ItemsSource = MerchantBoxValue;
            MerchantCombo.DisplayMemberPath = "Name";
            MerchantCombo.SelectedValuePath = "Value";
            MerchantCombo.IsEnabled = false;
            BT.IsEnabled = false;
            DBConnection.Open();
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            //添加类别下拉栏的选项
            TypeBoxValue.Add(new ComboBoxValue()
            {
                Name = "长丝",
                Value = "长丝"
            });
            TypeBoxValue.Add(new ComboBoxValue()
            {
                Name = "氨纶",
                Value = "氨纶"
            });
            TypeBoxValue.Add(new ComboBoxValue()
            {
                Name = "包纱",
                Value = "包纱"
            });
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Window w = null;
            //按下对应的键时打开对应的窗口
            switch (btn.Content.ToString())
            {
                case "查询":
                    w = new Model_result_Window { Type = TypeCombo.SelectedValue.ToString(), Merchant= MerchantCombo.SelectedValue.ToString() };
                    break;
                case "返回": this.Close(); break;
            }
            if (w != null)
            {
                this.Hide();
                w.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                w.Owner = this;
                w.ShowDialog();
                this.ShowDialog();
            }
        }

        private void TypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MerchantBoxValue.Clear();
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
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MerchantBoxValue.Add(new ComboBoxValue()
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
