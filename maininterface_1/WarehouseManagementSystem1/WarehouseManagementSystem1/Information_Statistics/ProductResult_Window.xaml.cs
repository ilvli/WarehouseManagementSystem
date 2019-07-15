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
    /// ProductResult_Window.xaml 的交互逻辑
    /// </summary>
    public partial class ProductResult_Window : Window
    {
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");
        ObservableCollection<ProductMessage> ProductData = new ObservableCollection<ProductMessage>();
        WarehouseManagementSystem1.ExportExcel ExportExcel = new ExportExcel();


        //保存统计条件的输入值
        public string Merchant { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string IsSending { get; set; }
        public string DataStart { get; set; }
        public string DataEnd { get; set; }
        public int RowCount = 0;
        public double WeightSum = 0;
        public int XiangziSum = 0;

        public ProductResult_Window()
        {
            InitializeComponent();
            DBConnection2.Open();
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            string sqlcommand;
            string s1 = "select * from Product where Merchant='" + Merchant;
            string s2 = "' and Color='" + Color;
            string s3 = "' and Model='" + Model;
            string s4 = "' and IsSending='" + IsSending + "' and Time>='" + DataStart + "' and Time<='" + DataEnd + "'";
            
            //创建查询命令语句
            if (Color == "全部" && Model == "全部")
            {
                sqlcommand = s1 + s4;
            }
            else if (Model == "全部")
            {
                sqlcommand = s1 + s2+ s4;

            }
            else if (Color == "全部")
            {
                sqlcommand = s1 + s3 + s4;
            }
            else
            {
                sqlcommand = s1 + s2 + s3 + s4;
            }

            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                RowCount += 1;
                //将查询到的信息添加到ProductData数据集合中
                ProductData.Add(new ProductMessage()
                {
                    Data = reader["Time"].ToString(),
                    Model = reader["Model"].ToString(),
                    Weight = reader["Weight"].ToString(),
                    Color = reader["Color"].ToString(),
                    Number = reader["Number"].ToString(),
                    IsSend = reader["IsSending"].ToString(),
                    Name = reader["Merchant"].ToString()
                });
                WeightSum += Convert.ToDouble(reader["Weight"]);
                XiangziSum += Convert.ToInt32(reader["Number"]);
            }
            //将materialData中的数据在DataGride中显示出来
            Product_message.ItemsSource = ProductData;
            WeightContent.Content = WeightSum.ToString();
            XiangziContent.Content = XiangziSum.ToString();
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
                    ExportExcel.ExportProduct(Product_message, "包纱账单", RowCount, ProductData,0);
                    break;
            }
        }
    }
}
