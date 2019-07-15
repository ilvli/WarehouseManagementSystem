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
    /// UserName.xaml 的交互逻辑
    /// </summary>
    public partial class UserName : Window
    {
        public new string Name { get; set; }
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");
        public UserName()
        {
            InitializeComponent();
            DBConnection2.Open();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "确定":
                    string sqlcommand = "select * from User where Name = '" + Name + "'";
                    SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
                    SQLiteDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (OldPBx.Password != reader["Password"].ToString())
                    {
                        MessageBox.Show("密码输入错误！", "提醒", MessageBoxButton.OK);
                        break;
                    }
                    sqlcommand = "update user set Name = '" + NameBox.Text + "' where Name = '" + Name + "'";
                    command = new SQLiteCommand(sqlcommand, DBConnection2);
                    reader = command.ExecuteReader();
                    MessageBox.Show("用户名修改成功！", "提醒", MessageBoxButton.OK);
                    DBConnection2.Close();
                    Name = NameBox.Text;
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
