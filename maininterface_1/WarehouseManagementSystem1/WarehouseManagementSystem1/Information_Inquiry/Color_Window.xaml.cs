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
    /// Color_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Color_Window : Window
    {
        ObservableCollection<ModelAndColorMessage> ColorData = new ObservableCollection<ModelAndColorMessage>();
        private SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");
        public string preValue;
        public int rowIndex = 0;
        public int columnIndex = 0;

        public Color_Window()
        {
            InitializeComponent();
            DBConnection2.Open();
            bnSave.IsEnabled = false;
            bnDelete.IsEnabled = false;
            Color_message.IsReadOnly = true;
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            string sqlcommand = "select rowid,Message from ModelAndColor where Type='颜色'";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ColorData.Add(new ModelAndColorMessage()
                {
                    Number = reader["rowid"].ToString(),
                    Message = reader["Message"].ToString()
                });
            }
            Color_message.ItemsSource = ColorData;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "编辑":
                    Color_message.IsReadOnly = false;
                    bnSave.IsEnabled = true;
                    bnDelete.IsEnabled = true;
                    break;
                case "退出编辑":
                    Color_message.IsReadOnly = true;
                    bnSave.IsEnabled = false;
                    bnDelete.IsEnabled = false;
                    break;
                case "删除":
                    Delete(Color_message, ref rowIndex);
                    break;
                case "返回":
                    DBConnection2.Close();
                    this.Close();
                    break;
            }
        }

        private void Delete(DataGrid dg, ref int rowIndex)
        {
            var _cells = dg.SelectedCells;
            if (_cells.Any())
            {
                rowIndex = dg.Items.IndexOf(_cells.First().Item);
                string sqlcommand = "delete from ModelAndColor where rowid=" + ColorData[rowIndex].Number.ToString();
                //执行查询命令
                SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
                command.ExecuteReader();
                MessageBox.Show("删除成功！", "提醒", MessageBoxButton.OK);
            }
        }

        private void Color_message_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string newValue = (e.EditingElement as TextBox).Text;
            //如果修改后的值和修改前的值不一样
            if (preValue != newValue && newValue != "")
            {
                var _cells = Color_message.SelectedCells;
                rowIndex = Color_message.Items.IndexOf(_cells.First().Item);
                columnIndex = e.Column.DisplayIndex;
                string sqlcommand = "update ModelAndColor set Message ='" + newValue + "' where rowid=" + ColorData[rowIndex].Number.ToString();
                //执行查询命令
                SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
                command.ExecuteReader();
                MessageBox.Show("编辑成功！", "提醒", MessageBoxButton.OK);
            }
        }

        private void Color_message_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            preValue = (e.Column.GetCellContent(e.Row) as TextBlock).Text;
        }
    }
}
