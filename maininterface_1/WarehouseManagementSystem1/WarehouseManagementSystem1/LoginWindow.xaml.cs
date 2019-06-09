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
using System.Windows.Shapes;

namespace WarehouseManagementSystem1
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public string UserName { get; set; }
        public LoginWindow()
        {
            InitializeComponent();
            ImageBrush bg = new ImageBrush();
            bg.ImageSource = new BitmapImage(new Uri("D:\\GitHub\\WarehouseManagementSystem\\maininterface_1\\WarehouseManagementSystem1\\WarehouseManagementSystem1\\Source\\Login3.jpg", UriKind.RelativeOrAbsolute));
            this.Background = bg;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            userNameTextBox.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "登录":
                    if (PasswordTextBox.Password == "123456")
                    {
                        this.UserName = userNameTextBox.Text;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("密码输入错误！", "提醒", MessageBoxButton.OK);
                    }
                    break;
                case "退出": App.Current.Shutdown(); break;
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.UserName) == true)
            {
                App.Current.Shutdown();
            }

        }

    }
}
