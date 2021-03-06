﻿using System;
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
    /// Receiving_Merchant_Information.xaml 的交互逻辑
    /// </summary>
    public partial class Receiving_Merchant_Information : Window
    {
        ObservableCollection<MerchantMessage> merchantData = new ObservableCollection<MerchantMessage>();
        private SQLiteConnection DBConnection2 = new SQLiteConnection("Data Source=C:\\ProgramData\\QinShan\\QinShan.sqlite");
        WarehouseManagementSystem1.Sqlite_Operate_Function sqlite_Operate = new Sqlite_Operate_Function();
        readonly string[] title = { "Type", "Name", "Message" };
        public string preValue;
        public int rowIndex = 0;
        public int columnIndex = 0;

        public Receiving_Merchant_Information()
        {
            InitializeComponent();
            DBConnection2.Open();
            bnSave.IsEnabled = false;
            bnDelete.IsEnabled = false;
            ReceivingMerchant_message.IsReadOnly = true;
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            string sqlcommand = "select rowid,* from Merchant where Type='收货商'";
            SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                merchantData.Add(new MerchantMessage()
                {
                    Number = reader["rowid"].ToString(),
                    Type = reader["Type"].ToString(),
                    Name = reader["Name"].ToString(),
                    Remark = reader["Message"].ToString()
                });
            }

            ReceivingMerchant_message.ItemsSource = merchantData;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "编辑":
                    ReceivingMerchant_message.IsReadOnly = false;
                    bnSave.IsEnabled = true;
                    bnDelete.IsEnabled = true;
                    break;
                case "退出编辑":
                    ReceivingMerchant_message.IsReadOnly = true;
                    bnSave.IsEnabled = false;
                    bnDelete.IsEnabled = false;
                    break;
                case "删除":
                    sqlite_Operate.Delete(DBConnection2, ReceivingMerchant_message, "Merchant", ref rowIndex, merchantData[rowIndex].Number);
                    this.Close();
                    break;
                case "返回":
                    DBConnection2.Close();
                    this.Close();
                    break;
            }
        }

        private void ReceivingMerchant_message_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string newValue = (e.EditingElement as TextBox).Text;
            //如果修改后的值和修改前的值不一样
            if (preValue != newValue && newValue != "")
            {
                var _cells = ReceivingMerchant_message.SelectedCells;
                rowIndex = ReceivingMerchant_message.Items.IndexOf(_cells.First().Item);
                columnIndex = e.Column.DisplayIndex;
                string sqlcommand = "update Merchant set " + title[columnIndex - 1] + "='" + newValue + "' where rowid=" + merchantData[rowIndex].Number.ToString();
                SQLiteCommand command = new SQLiteCommand(sqlcommand, DBConnection2);
                command.ExecuteReader();
                MessageBox.Show("编辑成功！", "提醒", MessageBoxButton.OK);
            }
        }

        private void ReceivingMerchant_message_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            preValue = (e.Column.GetCellContent(e.Row) as TextBlock).Text;
        }
    }
}
