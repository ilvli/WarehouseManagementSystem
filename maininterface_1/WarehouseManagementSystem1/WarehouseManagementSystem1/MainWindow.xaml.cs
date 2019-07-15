using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WarehouseManagementSystem1.Input_Information;
using WarehouseManagementSystem1.Information_Inquiry;
using WarehouseManagementSystem1.Information_Statistics;
using System.Data.SQLite;
using WarehouseManagementSystem1.UserInformation;

namespace WarehouseManagementSystem1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public new string Name { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            //设置窗口初始位置
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.SourceInitialized += MainWindow_SourceInitialized;
        }
        //显示登录窗口
        void MainWindow_SourceInitialized(object sender, System.EventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.ShowDialog();
            this.Title = "欢迎您，" + login.UserName;
            Name = login.UserName;
        }

        //判断按钮
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Window w = null;
            switch (btn.Content.ToString())
            {
                case "录入":
                    w = new InputMainWindow(); break;
                case "查询":
                    w = new Information_Inquiry_Main_Window();break;
                case "统计":
                    w = new Information_Statistics_Main_Window();break;
                case "退出": App.Current.Shutdown(); break;
            }
            if (w != null)
            {
                this.Hide();
                w.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                w.Owner = this;
                w.ShowDialog();
                this.ShowDialog();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem m = sender as MenuItem;
            //Window w = null;
            switch (m.Header.ToString())
            {
                case "修改用户名":
                    UserName w1 = new UserName();
                    w1.Name = Name;
                    w1.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                    w1.Owner = this;
                    w1.ShowDialog();
                    Name = w1.Name;
                    break;
                case "修改密码":
                    Password w2 = new Password();
                    w2.UserName = Name;
                    w2.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                    w2.Owner = this;
                    w2.ShowDialog();
                    break;
            }
        }
    }
}
