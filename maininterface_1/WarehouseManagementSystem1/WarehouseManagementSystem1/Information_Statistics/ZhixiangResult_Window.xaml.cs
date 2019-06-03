﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WarehouseManagementSystem1.Information_Statistics
{
    /// <summary>
    /// ZhixiangResult_Window.xaml 的交互逻辑
    /// </summary>
    public partial class ZhixiangResult_Window : Window
    {
        ObservableCollection<ZhixiangMessage> ZhixiangData = new ObservableCollection<ZhixiangMessage>();

        public ZhixiangResult_Window()
        {
            InitializeComponent();
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            ZhixiangData.Add(new ZhixiangMessage()
            {
                Data = "2019-2-12",
                Type = "长丝",
                Number = 43,
                UnitPrice = 24.4,
                Name = "宝莎",
                Count = 432.5
            });
            ZhixiangData.Add(new ZhixiangMessage()
            {
                Data = "2019-5-12",
                Type = "氨纶",
                Number = 65,
                UnitPrice = 29.2,
                Name = "宝莎",
                Count = 5435.1
            });

            Material_message.ItemsSource = ZhixiangData;
        }
    }
    public class ZhixiangMessage
    {
        public string Data { get; set; }//收货日期
        public string Type { get; set; }//只有长丝/氨纶两种
        public int Number { get; set; }//个数
        public double UnitPrice { get; set; }   //单价
        public string Name { get; set; }//供货商家
        public double Count { get; set; }//总价
    }
}