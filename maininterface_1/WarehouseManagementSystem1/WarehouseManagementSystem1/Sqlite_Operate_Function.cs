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
        //数据库连接
        SQLiteConnection m_dbConnection;

        //新建一个连接到指定数据库
        void ConnectToDatabase(string dbName)
        {
            m_dbConnection = new SQLiteConnection("Data Source=" + dbName);
            m_dbConnection.Open();
        }

        //创建一个空的数据库
        void CreateNewDatabase(string dbName)
        {
            SQLiteConnection cn = new SQLiteConnection("data source=" + dbName);
            cn.Open();
            cn.Clone();
        }

        //创建表
        void CreateTable(string dbName)
        {
            string sql = "create table highscores (name varchar(20), score int)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        //插入数据
        void FillTable()
        {
            string sqlcommand = "insert into highscores (name, score) values ('Me2', 3000)";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, m_dbConnection);
            command.ExecuteNonQuery();

            sqlcommand = "insert into highscores (name, score) values ('Myself2', 6000)";
            command = new SQLiteCommand(sqlcommand, m_dbConnection);
            command.ExecuteNonQuery();

            sqlcommand = "insert into highscores (name, score) values ('And I2', 9001)";
            command = new SQLiteCommand(sqlcommand, m_dbConnection);
            command.ExecuteNonQuery();
        }

        //使用sql查询语句，并显示结果
        void PrintHighscores()
        {
            string sqlcommand = "select * from highscores order by score desc";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                MessageBox.Show(("\nName: " + reader["name"] + "\tScore: " + reader["score"]).ToString(), "数据库信息", MessageBoxButton.OK);
            //Console.ReadLine();
        }


    }
}
