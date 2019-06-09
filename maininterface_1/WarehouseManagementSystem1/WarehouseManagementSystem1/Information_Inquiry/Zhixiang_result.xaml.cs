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
    /// Zhixiang_result.xaml 的交互逻辑
    /// </summary>
    public partial class Zhixiang_result : Window
    {
        ObservableCollection<ZhixiangMessage> ZhixiangData = new ObservableCollection<ZhixiangMessage>();
        private SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\test1.sqlite");

        public string DataStart { get; set; }
        public string DataEnd { get; set; }
        public string TypeR { get; set; }

        public Zhixiang_result()
        {
            InitializeComponent();
            DBConnection2.Open();
            bnSave.IsEnabled = false;
            bnDelete.IsEnabled = false;
            Zhixiang_message.IsReadOnly = true;
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            string sqlcommand;
            if (TypeR == "全部")
            {
                sqlcommand = "select * from Zhixiang where Time>='" + DataStart + "' and Time<='" + DataEnd + "'";

            }
            else
            {
                sqlcommand = "select * from Zhixiang where Type='" + TypeR + "' and Time>='" + DataStart + "' and Time<='" + DataEnd + "'";
            }
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ZhixiangData.Add(new ZhixiangMessage()
                {
                    Type = reader["Type"].ToString(),
                    Data = reader["Time"].ToString(),
                    Number = reader["Number"].ToString(),
                    UnitPrice = reader["Price"].ToString(),
                    Name = reader["Merchant"].ToString(),
                });
            }
            Zhixiang_message.ItemsSource = ZhixiangData;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "编辑":
                    Zhixiang_message.IsReadOnly = false;
                    bnSave.IsEnabled = true;
                    bnDelete.IsEnabled = true;
                    break;
                case "保存":
                    Zhixiang_message.IsReadOnly = true;
                    bnSave.IsEnabled = false;
                    bnDelete.IsEnabled = false;
                    //string result = Changsi_message.SelectedItem.ToString();
                    MessageBox.Show("编辑成功", "提醒", MessageBoxButton.OK);
                    break;
                case "返回":
                    this.Close();
                    break;
            }
        }
    }

    
    public class ZhixiangMessage
    {
        public string Data { get; set; }//收货日期
        public string Type { get; set; }//只有长丝/氨纶两种
        public string Number { get; set; }//个数
        public string UnitPrice { get; set; }   //单价
        public string Name { get; set; }//供货商家
        //public double Count { get; set; }//总价
    }
}
