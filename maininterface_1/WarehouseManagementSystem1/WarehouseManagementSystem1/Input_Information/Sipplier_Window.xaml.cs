using System;
using System.Collections.Generic;
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
    /// Sipplier_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Sipplier_Window : Window
    {
        //创建操作对象
        WarehouseManagementSystem1.Sqlite_Operate_Function sqlite_Operate = new Sqlite_Operate_Function();
        private SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\test1.sqlite");

        public Sipplier_Window()
        {
            InitializeComponent();
            //sqlite_Operate.ConnectToDatabase(DBConnection2,"test1");
            //DBConnection2 = new SQLiteConnection("C:\\ProgramData\\QinShan\\test1.sqlite");
            //连接数据库
            DBConnection2.Open();
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            //连接数据库
            //DBConnection2.Open();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Window w = null;
            switch (btn.Content.ToString())
            {
                case "确定":
                    sqlite_Operate.InsertMerchantTable(DBConnection2, "供货商", tbName.Text, tbMessage.Text);
                    MessageBox.Show("保存成功！", "提醒", MessageBoxButton.OK);
                    this.Close();
                    break;
                case "取消": this.Close(); break;
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
