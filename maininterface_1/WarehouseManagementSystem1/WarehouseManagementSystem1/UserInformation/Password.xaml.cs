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

namespace WarehouseManagementSystem1.UserInformation
{
    /// <summary>
    /// Password.xaml 的交互逻辑
    /// </summary>
    public partial class Password : Window
    {
        public string UserName { get; set; }
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");
        public Password()
        {
            DBConnection2.Open();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button Btn = sender as Button;
            switch (Btn.Content.ToString())
            {
                case "确定":
                    string sqlcommand = "select * from User where Name = '" + UserName + "'";
                    SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
                    SQLiteDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if(OldPBx.Password != reader["Password"].ToString())
                    {
                        MessageBox.Show("旧密码输入错误！", "提醒", MessageBoxButton.OK);
                        break;
                    }
                    sqlcommand = "update user set Password = " + NewPBx.Password + " where Name = '" + UserName + "'";
                    command = new SQLiteCommand(sqlcommand, DBConnection2);
                    reader = command.ExecuteReader();
                    MessageBox.Show("密码修改成功！", "提醒", MessageBoxButton.OK);
                    DBConnection2.Close(); 
                    this.Close();
                    break;
                case "取消":
                    DBConnection2.Close(); 
                    this.Close();
                    break;
            }
        }
    }
}
