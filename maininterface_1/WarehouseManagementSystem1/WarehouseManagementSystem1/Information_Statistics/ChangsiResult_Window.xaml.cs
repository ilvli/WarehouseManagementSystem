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
    /// ChangsiResult_Window.xaml 的交互逻辑
    /// </summary>
    public partial class ChangsiResult_Window : Window
    {
        ObservableCollection<ChangsiMessage> materialData = new ObservableCollection<ChangsiMessage>();
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\test1.sqlite");

        public string DataStart { get; set; }
        public string DataEnd { get; set; }
        public string Merchant { get; set; }
        public string Model { get; set; }
        public string TypeR { get; set; }
        public string Color { get; set; }

        public ChangsiResult_Window()
        {
            InitializeComponent();
            DBConnection2.Open();
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            string sqlcommand;
            if (TypeR == "长丝")
            {
                sqlcommand = "select * from Changsi where Merchant='" + Merchant + "' and Color='" + Color + "' and Time>='" + DataStart + "' and Time<='" + DataEnd + "'";

            }
            else
            {
                sqlcommand = "select * from Changsi where Merchant='" + Merchant + "' and Type='" + TypeR + "' and Time>='" + DataStart + "' and Time<='" + DataEnd + "'";
            }
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                materialData.Add(new ChangsiMessage()
                {
                    Data = reader["Time"].ToString(),
                    Type = reader["Type"].ToString(),
                    Model = reader["Model"].ToString(),
                    Weight = reader["Weight"].ToString(),
                    Color = reader["Color"].ToString(),
                    Name = reader["Merchant"].ToString()
                });
            }

            Material_message.ItemsSource = materialData;
        }

    }
    public class ChangsiMessage
    {
        public string Data { get; set; }//收货日期
        public string Type { get; set; }//只有长丝/氨纶两种
        public string Model { get; set; }//类型
        public string Weight { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }//供货商家
    }
}