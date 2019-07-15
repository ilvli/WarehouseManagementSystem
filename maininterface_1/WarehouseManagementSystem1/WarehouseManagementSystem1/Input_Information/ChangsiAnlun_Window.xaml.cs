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
        ObservableCollection<ComboBoxValue> SipllerValue = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> TypeValue = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> ColorValue = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> ModelValue = new ObservableCollection<ComboBoxValue>();

        WarehouseManagementSystem1.Sqlite_Operate_Function sqlite_Operate = new Sqlite_Operate_Function();
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");
        public ChangsiAnlun_Window()
        {
            InitializeComponent();
            DBConnection2.Open();

            //设置收货商下拉栏
            SipplierCombo.ItemsSource = SipllerValue;
            SipplierCombo.DisplayMemberPath = "Name";
            SipplierCombo.SelectedValuePath = "Value";
            //设置类别下拉栏
            TypeCombo.ItemsSource = TypeValue;
            TypeCombo.DisplayMemberPath = "Name";
            TypeCombo.SelectedValuePath = "Value";
            //设置颜色下拉栏
            ColorCombo.ItemsSource = ColorValue;
            ColorCombo.DisplayMemberPath = "Name";
            ColorCombo.SelectedValuePath = "Value";
            //设置型号下拉栏
            ModelCombo.ItemsSource = ModelValue;
            ModelCombo.DisplayMemberPath = "Name";
            ModelCombo.SelectedValuePath = "Value";
            
            ColorCombo.IsEnabled = false;
            ModelCombo.IsEnabled = false;
            SipplierCombo.IsEnabled = false;
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
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
            string sqlcommand = "select * from Merchant where Type='供货商'";
            LoadCombo(sqlcommand, SipllerValue, "Name");
            
            //加载颜色下拉栏
            sqlcommand = "select Message from ModelAndColor where Type='颜色'";
            LoadCombo(sqlcommand, ColorValue, "Message");
        }

        private void LoadCombo(string sqlcommand, ObservableCollection<ComboBoxValue> comboBoxValues ,string NameValue)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Window w = null;
            switch (btn.Content.ToString())
            {
                case "确定":
                    sqlite_Operate.InsertChangsiTable(DBConnection2, TypeCombo.Text, tbbTime.Text, ColorCombo.Text, ModelCombo.Text, tbWeight.Text, SipplierCombo.Text);
                    MessageBox.Show("保存成功！", "提醒", MessageBoxButton.OK);
                    this.Close();
                    break;
                case "返回":
                    DBConnection2.Close();
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
            SipplierCombo.IsEnabled = true;
            if (TypeCombo.SelectedValue.ToString() == "氨纶")
            {
                ColorCombo.IsEnabled = false;
            }
            else
            {
                ColorCombo.IsEnabled = true;
            }
        }

        private void SipplierCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ModelValue.Clear();
            ModelCombo.IsEnabled = true;
            //加载型号下拉栏
            string sqlcommand = "select Message from ModelAndColor where Type='" + TypeCombo.Text + "' and Merchant='" + SipplierCombo.SelectedValue.ToString() + "'";
            LoadCombo(sqlcommand, ModelValue, "Message");
        }
    }
}
