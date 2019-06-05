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

        //数据库连接
        SQLiteConnection DBConnection;
        //数据库文件路径加文件名
        //string dbName = "C#_test3";

        //新建一个连接到指定数据库
        void ConnectToDatabase(string DB_Name)
        {
            DBConnection = new SQLiteConnection("C:\\ProgramData\\QinShan\\" + DB_Name + ".sqlite");
            DBConnection.Open();
        }

        //创建一个空的数据库,需要输入数据库的名称，默认保存目录在D盘
        void CreateNewDatabase(string DB_Name)
        {
            //这里还有一个问题待解决，就是指定文件夹不存在时，要创建文件夹
            SQLiteConnection cn = new SQLiteConnection("data source=C:\\ProgramData\\QinShan\\" + DB_Name + ".sqlite");
            cn.Open();
            cn.Clone();
        }

        //创建表,这里表的项仅以姓名和分数为例
        void CreateTable(string TableName)
        {
            string sqlCommand = "create table " + TableName + " (name varchar(20), score int)";
            SQLiteCommand command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();

            sqlCommand = "create table " + TableName + " (name varchar(20), score int)";
            command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();

            sqlCommand = "create table " + TableName + " (name varchar(20), score int)";
            command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();

            sqlCommand = "create table " + TableName + " (name varchar(20), score int)";
            command = new SQLiteCommand(sqlCommand, DBConnection);
            command.ExecuteNonQuery();
        }

        //插入数据
        void FillTable(string TableName, string name, int value)
        {
            string sqlcommand = "insert into " + TableName + " (name, score) values ('" + name + "'," + value + ")";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            command.ExecuteNonQuery();

            //sqlcommand = "insert into highscores (name, score) values ('Myself2', 6000)";
            //command = new SQLiteCommand(sqlcommand, DBConnection);
            //command.ExecuteNonQuery();
        }

        //使用sql查询语句，并显示结果
        void Inquiry(string TableName)
        {
            string sqlcommand = "select * from " + TableName + " order by score desc";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            //while (reader.Read())
                //tbValue.AppendText("\nName: " + reader["name"] + "\nScore: " + reader["score"]);
            //Console.ReadLine();
        }

    }
}
