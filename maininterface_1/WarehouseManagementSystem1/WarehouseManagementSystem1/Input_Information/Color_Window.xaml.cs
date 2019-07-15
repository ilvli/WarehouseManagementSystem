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
    /// Color_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Color_Window : Window
    {
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");
        WarehouseManagementSystem1.Sqlite_Operate_Function sqlite_Operate = new Sqlite_Operate_Function();
        public Color_Window()
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
                    sqlite_Operate.InsertModelTable(DBConnection2, "颜色","", tbModel.Text);
                    MessageBox.Show("保存成功！", "提醒", MessageBoxButton.OK);
                    this.Close();
                    break;
                case "返回":
                    DBConnection2.Close();
                    this.Close();
                    break;
            }
        }
    }
}
