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

namespace WarehouseManagementSystem1
{
    /// <summary>
    /// SqliteSet.xaml 的交互逻辑
    /// </summary>
    public partial class SqliteSet : Window
    {
        //数据库文件路径 C:\\ProgramData\\QinShan\\
        //建立4个表，分别存储1.产品信息 2.商家信息 3.长丝/氨纶信息 4.纸箱/纸管/塑料袋信息
        public SqliteSet()
        {
            InitializeComponent();
            //ConnectToDatabase(dbName);
        }

        //创建连接
        SQLiteConnection DBConnection;

        //数据库文件路径加文件名
        //string dbName = "C#_test3";

        //新建一个连接到指定数据库
        void ConnectToDatabase(string DB_Name)
        {
            DBConnection = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\" + DB_Name + ".sqlite");
            DBConnection.Open();
        }

        //创建一个空的数据库,需要输入数据库的名称，默认保存目录在D盘
        void CreateNewDatabase(string DB_Name)
        {
            SQLiteConnection cn = new SQLiteConnection("data source=C:\\ProgramData\\QinShan\\" + DB_Name + ".sqlite");
            cn.Open();
            cn.Clone();
        }

        //创建表
        void CreateMerchantTable()
        {
            string sqlCommand = "create table Merchant (Type varchar(8), Name varchar(30), Message varchar(100))";
            SQLiteCommand command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();
        }
        void CreateProductTable()
        {
            //time-日期 color-颜色 model-型号 weight-重量 number-箱数 isending-是否发货 merchant-收货商家
            string sqlCommand = "create table Product (Time data,Color Varchar(10),Model varchar(10),Weight int,Number int,IsSending boolean, Merchant varchar(20))";
            SQLiteCommand command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();
        }
        void CreateChangsiTable()
        {
            //type-类型，用于记录是长丝还是氨纶
            string sqlCommand = "create table Changsi (Type text, Time text,Color text,Weight real, Merchant text)";
            SQLiteCommand command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();
        }
        void CreateZhixiangTable()
        {
            string sqlCommand = "create table Zhixiang (Type varchar(6), Time data, Number int, Price int, Merchant varchar(20))";
            SQLiteCommand command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();
        }

        private void but_Click2(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "创建商家表":
                    CreateMerchantTable();
                    break;
                case "创建产品表":
                    CreateProductTable();
                    break;
                case "创建长丝表":
                    CreateChangsiTable();
                    break;
                case "创建纸箱表":
                    CreateZhixiangTable();
                    break;
            }

        }

        //sqlcommand = "insert into highscores (name, score) values ('Myself2', 6000)";
        //command = new SQLiteCommand(sqlcommand, DBConnection);
        //command.ExecuteNonQuery();
        //插入数据
        void InsertMerchantTable(string Type,string Name,string Message)
        {
            string sqlcommand = "insert into Merchant (Type, Name, Message) values ('" + Type + "','" + Name + "','" + Message + "')";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            command.ExecuteNonQuery();
        }
        //,int Weight 
        void InsertChangsiTable(string Type, string Time, string Color,string Weight, string Merchant)
        {
            double WeightInt = Convert.ToDouble(Weight);
            //MessageBoxResult result = MessageBox.Show(WeightInt.ToString(), "提醒", MessageBoxButton.OK);

            //string sqlcommand = "insert into Changsi (Type,Time,Color,Weight,Merchant) values ('" + Type + "','" + Time + "','" + Color + "','" + Weight + "','" + Merchant + "')";
            string sqlcommand = "insert into Changsi (Type,Time,Color,Weight,Merchant) values ('" + Type + "','" + Time + "','" + Color + "','" + WeightInt + "','" + Merchant + "')";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            command.ExecuteNonQuery();
        }
        void InsertZhixiangTable(string Type, string Time, string Number, string Price, string Merchant)
        {
            int NumberInt = Convert.ToInt32(Number);
            double PriceDouble = Convert.ToDouble(Price);
            string sqlcommand = "insert into Zhixiang (Type,Time,Number,Price,Merchant) values ('" + Type + "','" + Time + "','" + NumberInt + "','" + PriceDouble + "','" + Merchant + "')";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            command.ExecuteNonQuery();
        }
        void InsertProductTable(string Time, string Color,string Model, string Weight,string Number,string IsSending, string Merchant)
        {
            double WeightDouble = Convert.ToDouble(Weight);
            int NumberInt = Convert.ToInt32(Number);
            int IsSendingInt = Convert.ToInt32(IsSending);
            string sqlcommand = "insert into Product (Time,Color,Model,Weight,Number,IsSending,Merchant) values ('" + Time + "','" + Color + "','" + Model + "','" + WeightDouble + "','" + NumberInt + "','" + IsSendingInt + "','" + Merchant + "')";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            command.ExecuteNonQuery();
        }

        private void But_Insert(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "插入商家":
                    InsertMerchantTable(tbType.Text, tbName.Text, tbMessage.Text);
                    break;
                case "插入产品":
                    InsertProductTable(tbTime.Text, tbColor.Text, tbModel.Text, tbWeight.Text,tbNumber.Text, tbIsSend.Text, tbMerchant.Text);
                    break;
                case "插入长丝":
                    InsertChangsiTable(tbType.Text, tbTime.Text, tbColor.Text, tbWeight.Text, tbMerchant.Text);
                    break;
                case "插入纸箱":
                    InsertZhixiangTable(tbType.Text, tbTime.Text, tbNumber.Text, tbPrice.Text,tbMerchant.Text);
                    break;

            }
        }


        //使用sql查询语句，并显示结果
        void PrintHighscores(string TableName)
        {
            string sqlcommand = "select * from " + TableName + " order by score desc";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                tbValue.AppendText("\nName: " + reader["name"] + "\nScore: " + reader["score"]);
            //Console.ReadLine();
        }

        private void but_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "创建新数据库":
                    CreateNewDatabase(tbNewDB.Text);
                    MessageBoxResult result = MessageBox.Show(tbNewDB.Text, "输入内容", MessageBoxButton.OK);
                    break;
                case "连接到数据库":
                    ConnectToDatabase(tbDBConnection.Text);
                    MessageBoxResult result1 = MessageBox.Show(tbDBConnection.Text, "输入内容", MessageBoxButton.OK);
                    break;
                case "创建表":
                   // CreateTable(tbNewTable.Text);
                    break;
                case "插入值":
                    //FillTable(tbTableName.Text, tbInsartName.Text, int.Parse(tbInsertValue.Text));
                    MessageBoxResult result2 = MessageBox.Show(tbTableName.Text + "\n" + tbInsartName.Text + "\n" + tbInsertValue.Text, "输入内容", MessageBoxButton.OK);
                    break;
                case "查询":
                    PrintHighscores(tbTableName_Chaxun.Text);
                    break;

            }

        }

        

        
    }
}
