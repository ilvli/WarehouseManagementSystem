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
    /// Model_result_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Model_result_Window : Window
    {
        public string Type { get; set; }
        public string Merchant { get; set; }
        ObservableCollection<ModelAndColorMessage> ColorData = new ObservableCollection<ModelAndColorMessage>();
        private SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");
        WarehouseManagementSystem1.Sqlite_Operate_Function sqlite_Operate = new Sqlite_Operate_Function();
        public string preValue;
        public int rowIndex = 0;
        public int columnIndex = 0;

        public Model_result_Window()
        {
            InitializeComponent();
            DBConnection2.Open();
            bnSave.IsEnabled = false;
            bnDelete.IsEnabled = false;
            Model_message.IsReadOnly = true;
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            string sqlcommand = "select rowid,* from ModelAndColor where Type='" + Type + "'and Merchant='" + Merchant + "'";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ColorData.Add(new ModelAndColorMessage()
                {
                    Number = reader["rowid"].ToString(),
                    Merchant = reader["Merchant"].ToString(),
                    Message = reader["Message"].ToString()
                });
            }
            Model_message.ItemsSource = ColorData;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "编辑":
                    Model_message.IsReadOnly = false;
                    bnSave.IsEnabled = true;
                    bnDelete.IsEnabled = true;
                    break;
                case "退出编辑":
                    Model_message.IsReadOnly = true;
                    bnSave.IsEnabled = false;
                    bnDelete.IsEnabled = false;
                    break;
                case "删除":
                    sqlite_Operate.Delete(DBConnection2, Model_message, "ModelAndColor", ref rowIndex, ColorData[rowIndex].Number);
                    this.Close();
                    break;
                case "返回":
                    DBConnection2.Close();
                    this.Close();
                    break;
            }
        }

        private void Model_message_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string newValue = (e.EditingElement as TextBox).Text;
            //如果修改后的值和修改前的值不一样
            if (preValue != newValue && newValue != "")
            {
                var _cells = Model_message.SelectedCells;
                rowIndex = Model_message.Items.IndexOf(_cells.First().Item);
                columnIndex = e.Column.DisplayIndex;
                string sqlcommand = "update ModelAndColor set Message ='" + newValue + "' where rowid=" + ColorData[rowIndex].Number.ToString();
                //执行查询命令
                SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
                command.ExecuteReader();
                MessageBox.Show("编辑成功！", "提醒", MessageBoxButton.OK);
            }
        }

        private void Model_message_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            preValue = (e.Column.GetCellContent(e.Row) as TextBlock).Text;
        }
    }
}
