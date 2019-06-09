using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WarehouseManagementSystem1
{
    class Sqlite_Operate_Function
    {
        //数据库文件路径 C:\\ProgramData\\QinShan\\
        //建立4个表，分别存储1.产品信息 2.商家信息 3.长丝/氨纶信息 4.纸箱/纸管/塑料袋信息

        //SQLiteConnection DBConnection;
        
        //新建一个连接到指定数据库
        public void ConnectToDatabase(SQLiteConnection DBConnection,string DB_Name)
        {
            DBConnection = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\" + DB_Name + ".sqlite");
            DBConnection.Open();
        }

        //创建一个空的数据库,需要输入数据库的名称，默认保存目录在D盘
        public void CreateNewDatabase(SQLiteConnection DBConnection,string DB_Name)
        {
            //这里还有一个问题待解决，就是指定文件夹不存在时，要创建文件夹
            SQLiteConnection cn = new SQLiteConnection("data source=C:\\ProgramData\\QinShan\\" + DB_Name + ".sqlite");
            cn.Open();
            cn.Clone();
        }

        //创建表
        public void CreateMerchantTable(SQLiteConnection DBConnection)
        {
            string sqlCommand = "create table Merchant (Type varchar(8), Name varchar(30), Message varchar(100))";
            SQLiteCommand command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();
        }
        public void CreateProductTable(SQLiteConnection DBConnection)
        {
            //time-日期 color-颜色 model-型号 weight-重量 number-箱数 isending-是否发货 merchant-收货商家
            string sqlCommand = "create table Product (Time data,Color Varchar(10),Model varchar(10),Weight int,Number int,IsSending boolean, Merchant varchar(20))";
            SQLiteCommand command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();
        }
        public void CreateChangsiTable(SQLiteConnection DBConnection)
        {
            //type-类型，用于记录是长丝还是氨纶
            string sqlCommand = "create table Changsi (Type text, Time text,Color text,Weight real, Merchant text)";
            SQLiteCommand command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();
        }
        public void CreateZhixiangTable(SQLiteConnection DBConnection)
        {
            string sqlCommand = "create table Zhixiang (Type varchar(6), Time data, Number int, Price int, Merchant varchar(20))";
            SQLiteCommand command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();
        }

        //插入数据
        public void InsertMerchantTable(SQLiteConnection DBConnection,string Type, string Name, string Message)
        {
            string sqlcommand = "insert into Merchant (Type, Name, Message) values ('" + Type + "','" + Name + "','" + Message + "')";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            command.ExecuteNonQuery();
        }
        public void InsertChangsiTable(SQLiteConnection DBConnection, string Type, string Time, string Color,string Model, string Weight, string Merchant)
        {
            double WeightInt = Convert.ToDouble(Weight);
            string sqlcommand = "insert into Changsi (Type,Time,Color,Model,Weight,Merchant) values ('" + Type + "','" + Time + "','" + Color + "','" + Model + "','" + WeightInt + "','" + Merchant + "')";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            command.ExecuteNonQuery();
        }
        public void InsertZhixiangTable(SQLiteConnection DBConnection, string Type, string Time, string Number, string Price, string Merchant)
        {
            int NumberInt = Convert.ToInt32(Number);
            double PriceDouble = Convert.ToDouble(Price);
            string sqlcommand = "insert into Zhixiang (Type,Time,Number,Price,Merchant) values ('" + Type + "','" + Time + "','" + NumberInt + "','" + PriceDouble + "','" + Merchant + "')";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            command.ExecuteNonQuery();
        }
        public void InsertProductTable(SQLiteConnection DBConnection, string Time, string Color, string Model, string Weight, string Number, string IsSending, string Merchant)
        {
            double WeightDouble = Convert.ToDouble(Weight);
            int NumberInt = Convert.ToInt32(Number);
            int IsSendingInt = Convert.ToInt32(IsSending);
            string sqlcommand = "insert into Product (Time,Color,Model,Weight,Number,IsSending,Merchant) values ('" + Time + "','" + Color + "','" + Model + "','" + WeightDouble + "','" + NumberInt + "','" + IsSendingInt + "','" + Merchant + "')";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            command.ExecuteNonQuery();
        }

        //使用sql查询语句，并显示结果
        public string InquiryMerchant(SQLiteConnection DBConnection)
        {
            // + " order by Time desc"
            string sqlcommand = "select * from Merchant";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //reader["name"] + "\nScore: " + reader["score"]
                return reader["Type"] + "\n" + reader["Name"] + "\n" + reader["Message"];
                //tbValue.AppendText(reader["Type"] + "\n" + reader["Name"] + "\n" + reader["Message"]);
            }
            return null;
            //Console.ReadLine();
        }
        public void InquiryChangsi(SQLiteConnection DBConnection)
        {
            string sqlcommand = "select * from Changsi";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //tbValue.AppendText(reader["Type"] + "\n" + reader["Time"] + "\n" + reader["Color"] + "\n" + reader["Weight"] + "\n" + reader["Merchant"]);
            }
        }
        public void InquiryZhixiang(SQLiteConnection DBConnection)
        {
            string sqlcommand = "select * from Zhixiang";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //tbValue.AppendText(reader["Type"] + "\n" + reader["Time"] + "\n" + reader["Number"] + "\n" + reader["Price"] + "\n" + reader["Merchant"]);
            }
        }
        public void InquiryProduct(SQLiteConnection DBConnection)
        {
            string sqlcommand = "select * from Product";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //tbValue.AppendText(reader["Time"] + "\n" + reader["Color"] + "\n" + reader["Model"] + "\n" + reader["Weight"] + "\n" + reader["Number"] + "\n" + reader["IsSending"] + "\n" + reader["Merchant"]);
            }
        }
    }
}
