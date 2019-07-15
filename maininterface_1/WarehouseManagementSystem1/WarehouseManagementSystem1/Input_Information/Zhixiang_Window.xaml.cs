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
    /// Zhixiang_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Zhixiang_Window : Window
    {
        ObservableCollection<ComboBoxValue> TypeBoxValue = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> SiplierBoxValue = new ObservableCollection<ComboBoxValue>();
        WarehouseManagementSystem1.Sqlite_Operate_Function sqlite_Operate = new Sqlite_Operate_Function();
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");
        public Zhixiang_Window()
        {
            InitializeComponent();
            //打开数据库连接
            DBConnection2.Open();
            //设置种类下拉栏
            TypeCombo.ItemsSource = TypeBoxValue;
            TypeCombo.DisplayMemberPath = "Name";
            TypeCombo.SelectedValuePath = "Value";
            //设置供货商下拉栏
            SiplierCombo.ItemsSource = SiplierBoxValue;
            SiplierCombo.DisplayMemberPath = "Name";
            SiplierCombo.SelectedValuePath = "Value";
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            TypeBoxValue.Add(new ComboBoxValue()
            {
                Name = "纸箱",
                Value = "纸箱"
            });
            TypeBoxValue.Add(new ComboBoxValue()
            {
                Name = "纸管",
                Value = "纸管"
            });
            TypeBoxValue.Add(new ComboBoxValue()
            {
                Name = "塑料袋",
                Value = "塑料袋"
            });
            //插入供货商家
            string sqlcommand = "select * from Merchant where Type='供货商'";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SiplierBoxValue.Add(new ComboBoxValue()
                {
                    Name = reader["Name"].ToString(),
                    Value = reader["Message"].ToString()
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
                    sqlite_Operate.InsertZhixiangTable(DBConnection2, TypeCombo.Text, tbTime.Text, tbNumber.Text, tbPrice.Text, SiplierCombo.Text);
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
    }
}
