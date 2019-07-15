using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
        WarehouseManagementSystem1.ExportExcel ExportExcel = new ExportExcel();
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");

        public string DataStart { get; set; }
        public string DataEnd { get; set; }
        public string Merchant { get; set; }
        public string Model { get; set; }
        public string TypeR { get; set; }
        public string Color { get; set; }
        public int RowCount = 0;
        public double WeightSum = 0;

        public ChangsiResult_Window()
        {
            InitializeComponent();
            DBConnection2.Open();
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            string sqlcommand;
            string s1 = "select * from Changsi where Merchant='" + Merchant;
            string s2 = "' and Type='" + TypeR;
            string s3 = "' and Color='" + Color;
            string s4 = "' and Model='" + Model;
            string s5 = "' and Time>='" + DataStart + "' and Time<='" + DataEnd + "'";
            if (TypeR == "长丝")
            {
                if (Color == "全部" && Model == "全部")
                {
                    sqlcommand = s1 + s2 + s5;
                }
                else if (Model == "全部")
                {
                    sqlcommand = s1 + s2 + s3 + s5;

                }
                else if(Color == "全部")
                {
                    sqlcommand = s1 + s2 + s4 + s5;
                }
                else
                {
                    sqlcommand = s1 + s2 + s3 + s4 + s5;
                }
            }
            else
            {
                if (Model == "全部")
                {
                    sqlcommand = s1 + s2 + s5;

                }
                else
                {
                    sqlcommand = s1 + s2 + s4 + s5;
                }
            }
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                RowCount += 1;
                materialData.Add(new ChangsiMessage()
                {
                    Data = reader["Time"].ToString(),
                    Type = reader["Type"].ToString(),
                    Model = reader["Model"].ToString(),
                    Weight = reader["Weight"].ToString(),
                    Color = reader["Color"].ToString(),
                    Name = reader["Merchant"].ToString()
                });
                WeightSum += Convert.ToDouble(reader["Weight"]);
            }
            Changsi_message.ItemsSource = materialData;
            WeightContent.Content = WeightSum.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "返回":
                    DBConnection2.Close();
                    this.Close();
                    break;
                case "导出":
                    ExportExcel.ExportChangsi(Changsi_message, "原料账单", RowCount, materialData, 0);
                    break;
            }
        }
    }
}