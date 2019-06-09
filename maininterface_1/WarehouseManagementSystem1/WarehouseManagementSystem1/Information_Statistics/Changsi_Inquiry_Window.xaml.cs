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
    /// Changsi_Inquiry_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Changsi_Inquiry_Window : Window
    {
        ObservableCollection<ComboBoxValue> Sipplier = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> Color = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> Type = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> Model = new ObservableCollection<ComboBoxValue>();
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\test1.sqlite");

        public Changsi_Inquiry_Window()
        {
            InitializeComponent();
            DBConnection2.Open();
            //设置收货商下拉栏
            SipplierCombo.ItemsSource = Sipplier;
            SipplierCombo.DisplayMemberPath = "Name";
            SipplierCombo.SelectedValuePath = "Value";
            //设置颜色下拉栏
            ColorCombo.ItemsSource = Color;
            ColorCombo.DisplayMemberPath = "Name";
            ColorCombo.SelectedValuePath = "Value";
            //设置类别下拉栏
            TypeCombo.ItemsSource = Type;
            TypeCombo.DisplayMemberPath = "Name";
            TypeCombo.SelectedValuePath = "Value";
            //设置型号下拉栏
            ModelCombo.ItemsSource = Model;
            ModelCombo.DisplayMemberPath = "Name";
            ModelCombo.SelectedValuePath = "Value";
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            string sqlcommand = "select Name from Merchant where Type='供货商'";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Sipplier.Add(new ComboBoxValue()
                {
                    Name = reader["Name"].ToString(),
                    Value = reader["Name"].ToString()
                });
            }

            sqlcommand = "select DISTINCT Color from Changsi";
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
            //类别
            Type.Add(new ComboBoxValue()
            {
                Name = "长丝",
                Value = "长丝"
            });
            Type.Add(new ComboBoxValue()
            {
                Name = "氨纶",
                Value = "氨纶"
            });

            sqlcommand = "select DISTINCT Model from Changsi ";
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
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "返回": this.Close(); break;
                case "确定":
                    ChangsiResult_Window Result = new ChangsiResult_Window
                    {
                        DataStart = tbStratData.Text,
                        DataEnd = tbEndData.Text,
                        Merchant = SipplierCombo.Text,
                        Model = ModelCombo.Text,
                        TypeR = TypeCombo.Text,
                        Color = ColorCombo.Text
                    };
                    Result.ShowDialog();
                    Result.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                    break;
            }
        }

        private void TypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeCombo.SelectedValue.ToString() == "氨纶")
            {
                ColorCombo.IsEnabled = false;
            }
            else
            {
                ColorCombo.IsEnabled = true;
            }
        }
    }
}
