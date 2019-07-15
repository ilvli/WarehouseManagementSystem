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
using System.IO;

namespace WarehouseManagementSystem1
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        //用户名
        public string UserName { get; set; }
        public LoginWindow()
        {
            //初始化登录界面窗口
            InitializeComponent();
            if (!System.IO.File.Exists("C:\\ProgramData\\QinShan\\QinShan.sqlite"))
            {
                CreateNewDatabase();
            }
            //设置背景图片
            ImageBrush bg = new ImageBrush();
            bg.ImageSource = new BitmapImage(new Uri("C:\\ProgramData\\QinShan\\Login3.jpg", UriKind.RelativeOrAbsolute));
            this.Background = bg;
            //设置窗口位置
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            
        }

        //按键被按下时触发的函数
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");
            DBConnection2.Open();
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                //当按下登录按键时判断密码是否正确，正确则进入主界面，否则提示密码错误
                case "登录":
                    string sqlcommand = "select * from User where Name = '" + userNameTextBox.Text + "'";
                    try
                    {
                        SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
                        SQLiteDataReader reader = command.ExecuteReader();
                        reader.Read();
                        if (PasswordTextBox.Password == reader["Password"].ToString())
                        {
                            this.UserName = userNameTextBox.Text;
                            //this.Close();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("密码输入错误！", "提醒", MessageBoxButton.OK);
                        }
                    }
                    catch (System.InvalidOperationException)
                    {
                        MessageBox.Show("用户名输入错误", "提醒", MessageBoxButton.OK);
                    }
                    //按下退出按键时退出程序
                    break;
                case "退出": App.Current.Shutdown(); break;
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }

        public void CreateNewDatabase()
        {
            //这里还有一个问题待解决，就是指定文件夹不存在时，要创建文件夹
            SQLiteConnection DBConnection = new SQLiteConnection("data source = C:\\ProgramData\\QinShan\\QinShan.sqlite");
            DBConnection.Open();

            string sqlCommand = "create table ModelAndColor (Type TEXT(8),Merchant TEXT(10),Message TEXT(10))";
            SQLiteCommand command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();

            sqlCommand = "create table Merchant (Type TEXT(8), Name TEXT(30), Message TEXT(100))";
            command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();

            //time-日期 color-颜色 model-型号 weight-重量 number-箱数 isending-是否发货 merchant-收货商家
            sqlCommand = "create table Product (Time TEXT(10),Color TEXT(6),Model TEXT(10),Weight real,Number real,IsSending TEXT(5), Merchant TEXT(20))";
            command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();

            //type-类型，用于记录是长丝还是氨纶
            sqlCommand = "create table Changsi (Type text, Time text,Color text,Weight real, Merchant text,Model text)";
            command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();

            sqlCommand = "create table Zhixiang (Type TEXT, Time TEXT, Number real, Price real, Merchant TEXT)";
            command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();

            sqlCommand = "create table User (Name TEXT, Password INTEGER)";
            command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();

            sqlCommand = "insert into User (Name,Password) values ('user',123)";
            command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();
            DBConnection.Close();
        }
    }
}
