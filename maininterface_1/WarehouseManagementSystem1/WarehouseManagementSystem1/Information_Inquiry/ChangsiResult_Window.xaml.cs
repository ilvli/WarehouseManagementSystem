using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Windows.Threading;

namespace WarehouseManagementSystem1.Information_Inquiry
{
    /// <summary>
    /// ChangsiResult_Window.xaml 的交互逻辑
    /// </summary>
    public partial class ChangsiResult_Window : Window
    {
        //ObservableCollection<T>类是C#的一个动态数据集合,可添加项,移除项或刷新整个列表，这里创建一个存储查询数据的集合
        ObservableCollection<ChangsiMessage> materialData = new ObservableCollection<ChangsiMessage>();
        WarehouseManagementSystem1.ExportExcel ExportExcel = new ExportExcel();
        //创建一个数据库对象
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");
        WarehouseManagementSystem1.Sqlite_Operate_Function sqlite_Operate = new Sqlite_Operate_Function();

        readonly string[] title = { "Time", "Type", "Model", "Weight", "Color", "Merchant" };
        //保存查询条件的输入值
        public string DataStart { get; set; }
        public string DataEnd { get; set; }
        public string TypeR { get; set; }
        public string preValue;
        public int rowIndex = 0;
        public int columnIndex = 0;
        public int RowCount = 0;
        public double WeightSum = 0;


        public ChangsiResult_Window()
        {
            InitializeComponent();
            //连接数据库
            DBConnection2.Open();
            //将保存和删除按键设为不可用
            bnSave.IsEnabled = false;
            bnDelete.IsEnabled = false;
            //将用来现实查询信息的DataGride设置为只读，即不可修改
            Changsi_message.IsReadOnly = true;
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            //加载数据
            string sqlcommand;
            if (TypeR == "全部")
            {
                //如果类型选择为“全部”，则将时间范围内的长丝和氨纶的所有信息都加载进来
                sqlcommand = "select rowid,* from Changsi where Time>='" + DataStart + "' and Time<='" + DataEnd + "'";

            }
            else
            {
                //如果类型选择为“长丝”或“氨纶”，则将时间范围内的指定类别的所有信息都加载进来
                sqlcommand = "select rowid,* from Changsi where Type='" + TypeR + "' and Time>='" + DataStart + "' and Time<='" + DataEnd + "'";
            }
            //执行查询命令
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                RowCount += 1;
                //将从数据库获取的所有数据都添加到materialData数据集合中
                materialData.Add(new ChangsiMessage()
                {
                    Number = reader["rowid"].ToString(),
                    Data = reader["Time"].ToString(),
                    Type = reader["Type"].ToString(),
                    Model = reader["Model"].ToString(),
                    Weight = reader["Weight"].ToString(),
                    Color = reader["Color"].ToString(),
                    Name = reader["Merchant"].ToString()
                }) ;
                WeightSum += Convert.ToDouble(reader["Weight"]);
            }
            //将materialData中的数据在DataGride中显示出来
            Changsi_message.ItemsSource = materialData;
            WeightContent.Content = WeightSum.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "编辑":
                    //当按下编辑按键时，将DataGride设置为可编辑模式，并将启用保存和删除按键
                    Changsi_message.IsReadOnly = false;
                    bnSave.IsEnabled = true;
                    bnDelete.IsEnabled = true;
                    break;
                case "退出编辑":
                    //当按下保存按键时，将DataGride设置为只读模式，并将保存和删除按键设置为不可用
                    Changsi_message.IsReadOnly = true;
                    bnSave.IsEnabled = false;
                    bnDelete.IsEnabled = false;
                    //MessageBox.Show("编辑成功", "提醒", MessageBoxButton.OK);
                    break;
                case "删除":
                    sqlite_Operate.Delete(DBConnection2, Changsi_message, "Changsi", ref rowIndex, materialData[rowIndex].Number);
                    this.Close();
                    break;
                case "返回":
                    DBConnection2.Close();
                    this.Close();
                    break;
                case "导出":
                    ExportExcel.ExportChangsi(Changsi_message, "原料账单",RowCount, materialData,1);
                    break;
            }
        }

        private void Changsi_message_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            preValue = (e.Column.GetCellContent(e.Row) as TextBlock).Text;
        }

        private void Changsi_message_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string newValue = (e.EditingElement as TextBox).Text;
            //如果修改后的值和修改前的值不一样
            if (preValue != newValue && newValue!="")
            {
                var _cells = Changsi_message.SelectedCells;
                rowIndex = Changsi_message.Items.IndexOf(_cells.First().Item);
                columnIndex = e.Column.DisplayIndex;
                string sqlcommand = "update Changsi set " + title[columnIndex - 1] + "='" + newValue + "' where rowid="+ materialData[rowIndex].Number.ToString();
                //执行查询命令
                SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
                command.ExecuteReader();
                MessageBox.Show("编辑成功！", "提醒", MessageBoxButton.OK);
            }
        }
    }
}
