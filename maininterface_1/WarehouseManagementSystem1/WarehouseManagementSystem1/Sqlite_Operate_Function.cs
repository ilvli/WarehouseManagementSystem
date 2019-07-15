using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WarehouseManagementSystem1
{
    class Sqlite_Operate_Function
    {
        //数据库文件路径 C:\\ProgramData\\QinShan\\
        //建立4个表，分别存储1.产品信息 2.商家信息 3.长丝/氨纶信息 4.纸箱/纸管/塑料袋信息

        //删除表
        public void Delete(SQLiteConnection DBConnection,DataGrid dg,string tablename, ref int rowIndex,string numb)
        {
            var _cells = dg.SelectedCells;
            if (_cells.Any())
            {
                rowIndex = dg.Items.IndexOf(_cells.First().Item);
                string sqlcommand = "delete from "+ tablename + " where rowid=" + numb;
                //执行查询命令
                SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
                command.ExecuteReader();
                MessageBox.Show("删除成功！", "提醒", MessageBoxButton.OK);
            }
        }

        //插入数据函数
        //插入型号和颜色表
        public void InsertModelTable(SQLiteConnection DBConnection, string Type,string Merchant, string Message)
        {
            string sqlcommand = "insert into ModelAndColor (Type,Merchant,Message) values ('" + Type + "','" + Merchant + "','" + Message + "')";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            command.ExecuteNonQuery();
        }
            //插入到商家表
            public void InsertMerchantTable(SQLiteConnection DBConnection,string Type, string Name, string Message)
        {
            string sqlcommand = "insert into Merchant (Type, Name, Message) values ('" + Type + "','" + Name +
                "','" + Message + "')";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            command.ExecuteNonQuery();
        }
        //插入到长丝/氨纶表
        public void InsertChangsiTable(SQLiteConnection DBConnection, string Type, string Time, string Color,
            string Model, string Weight, string Merchant)
        {
            double WeightInt = Convert.ToDouble(Weight);
            string sqlcommand = "insert into Changsi (Type,Time,Color,Model,Weight,Merchant) values ('" + Type + 
                "','" + Time + "','" + Color + "','" + Model + "','" + WeightInt + "','" + Merchant + "')";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            command.ExecuteNonQuery();
        }
        //插入到纸箱/纸管/塑料袋表
        public void InsertZhixiangTable(SQLiteConnection DBConnection, string Type, string Time, string Number, 
            string Price, string Merchant)
        {
            int NumberInt = Convert.ToInt32(Number);
            double PriceDouble = Convert.ToDouble(Price);
            string sqlcommand = "insert into Zhixiang (Type,Time,Number,Price,Merchant) values ('" + Type + "','" 
                + Time + "','" + NumberInt + "','" + PriceDouble + "','" + Merchant + "')";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            command.ExecuteNonQuery();
        }
        //插入到产品表
        public void InsertProductTable(SQLiteConnection DBConnection, string Time, string Color, string Model, 
            string Weight, string Number, string IsSending, string Merchant)
        {
            double WeightDouble = Convert.ToDouble(Weight);
            int NumberInt = Convert.ToInt32(Number);
            string sqlcommand = "insert into Product (Time,Color,Model,Weight,Number,IsSending,Merchant) values" +
                " ('" + Time + "','" + Color + "','" + Model + "','" + WeightDouble + "','" + NumberInt + "','" + 
                IsSending + "','" + Merchant + "')";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection);
            command.ExecuteNonQuery();
        }
    }
}
