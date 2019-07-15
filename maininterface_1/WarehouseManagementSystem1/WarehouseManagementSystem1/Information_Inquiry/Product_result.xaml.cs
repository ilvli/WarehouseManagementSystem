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

namespace WarehouseManagementSystem1.Information_Inquiry
{
    /// <summary>
    /// Product_result.xaml 的交互逻辑
    /// </summary>
    public partial class Product_result : Window
    {
        //创建一个数据库对象
        SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");

        //ObservableCollection<T>类是C#的一个动态数据集合,可添加项,移除项或刷新整个列表，
        //这里创建一个存储查询数据的集合
        private ObservableCollection<ProductMessage> ProductData = new ObservableCollection<ProductMessage>();
        WarehouseManagementSystem1.ExportExcel ExportExcel = new ExportExcel();
        WarehouseManagementSystem1.Sqlite_Operate_Function sqlite_Operate = new Sqlite_Operate_Function();


        //保存查询条件的输入值
        public string DataStart { get; set; }
        public string DataEnd { get; set; }
        readonly string[] title = { "Time", "Model", "Weight", "Color", "Number","IsSending","Merchant" };
        public string preValue;
        public int rowIndex = 0;
        public int columnIndex = 0;
        public int RowCount = 0;
        public double WeightSum = 0;
        public int XiangziSum = 0;

        //初始化窗口
        public Product_result()
        {
            InitializeComponent();
            //打开数据库连接
            DBConnection2.Open();
            //将保存和删除按键设为不可用
            bnSave.IsEnabled = false;
            bnDelete.IsEnabled = false;
            //将用来现实查询信息的DataGride设置为只读，即不可修改
            Product_message.IsReadOnly = true;
        }

        //加载数据
        private void LoadData(object sender, RoutedEventArgs e)
        {
            //定义查询语句，则将时间范围内的产品的所有信息都加载进来
            string sqlcommand = "select rowid,* from Product where Time>='" + DataStart + 
                "' and Time<='" + DataEnd + "'";
            //执行查询命令
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                RowCount += 1;
                ProductData.Add(new ProductMessage()
                {
                    //将从数据库获取的所有数据都添加到ProductData数据集合中
                    Numb = reader["rowid"].ToString(),
                    Data = reader["Time"].ToString(),
                    Model = reader["Model"].ToString(),
                    Weight = reader["Weight"].ToString(),
                    Color = reader["Color"].ToString(),
                    Number = reader["Number"].ToString(),
                    IsSend = reader["IsSending"].ToString(),
                    Name = reader["Merchant"].ToString()
                });
                WeightSum += Convert.ToDouble(reader["Weight"]);
                XiangziSum += Convert.ToInt32(reader["Number"]);
            }
            //将materialData中的数据在DataGride中显示出来
            Product_message.ItemsSource = ProductData;
            WeightContent.Content = WeightSum.ToString();
            XiangziContent.Content = XiangziSum.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                //当按下编辑按键时，将DataGride设置为可编辑模式，并将启用保存和删除按键
                case "编辑":
                    Product_message.IsReadOnly = false;
                    bnSave.IsEnabled = true;
                    bnDelete.IsEnabled = true;
                    break;
                //当按下保存按键时，将DataGride设置为只读模式，并将保存和删除按键设置为不可用
                case "退出编辑":
                    Product_message.IsReadOnly = true;
                    bnSave.IsEnabled = false;
                    bnDelete.IsEnabled = false;
                    break;
                case "删除":
                    sqlite_Operate.Delete(DBConnection2, Product_message, "Product", ref rowIndex, ProductData[rowIndex].Number);
                    this.Close();
                    break;
                case "返回":
                    DBConnection2.Close();
                    this.Close();
                    break;
                case "导出":
                    ExportExcel.ExportProduct(Product_message, "包纱账单", RowCount, ProductData,1);
                    break;
            }
        }

        private void Product_message_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string newValue = (e.EditingElement as TextBox).Text;
            //如果修改后的值和修改前的值不一样
            if (preValue != newValue && newValue != "")
            {
                var _cells = Product_message.SelectedCells;
                rowIndex = Product_message.Items.IndexOf(_cells.First().Item);
                columnIndex = e.Column.DisplayIndex;
                string sqlcommand = "";
                sqlcommand = "update Product set " + title[columnIndex - 1] + "='" + newValue + "' where rowid=" + ProductData[rowIndex].Numb.ToString();
                //执行查询命令
                SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
                command.ExecuteReader();
                MessageBox.Show("编辑成功！", "提醒", MessageBoxButton.OK);
            }
        }

        private void Product_message_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            preValue = (e.Column.GetCellContent(e.Row) as TextBlock).Text;
        }
    }
}
