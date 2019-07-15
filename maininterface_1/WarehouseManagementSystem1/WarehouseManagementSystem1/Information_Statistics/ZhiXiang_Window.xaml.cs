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
    /// ZhiXiang_Window.xaml 的交互逻辑
    /// </summary>
    public partial class ZhiXiang_Window : Window
    {
        //存储种类和供货商信息
        ObservableCollection<ComboBoxValue> TypeBoxValue = new ObservableCollection<ComboBoxValue>();
        ObservableCollection<ComboBoxValue> SiplierBoxValue = new ObservableCollection<ComboBoxValue>();
        private SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");

        public ZhiXiang_Window()
        {
            InitializeComponent();
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
            TypeBoxValue.Add(new ComboBoxValue()
            {
                Name = "全部",
                Value = "全部"
            });
            
            string sqlcommand = "select * from Merchant where Type='供货商'";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SiplierBoxValue.Add(new ComboBoxValue()
                {
                    Name = reader["Name"].ToString(),
                    Value = reader["Name"].ToString()
                });
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "确定":
                    ZhixiangResult_Window Result = new ZhixiangResult_Window
                    {
                        DataStart = tbStartData.Text,
                        DataEnd = tbEndData.Text,
                        TypeR = TypeCombo.Text,
                        Sipplier = SiplierCombo.Text
                    };
                    Result.ShowDialog();
                    Result.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                    break;
                case "返回": this.Close(); break;
            }
        }
    }
}
