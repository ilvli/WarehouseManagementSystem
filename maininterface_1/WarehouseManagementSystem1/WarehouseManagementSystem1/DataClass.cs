using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem1
{
    public class ProductMessage
    {
        public string Numb { get; set; }//序号
        public string Data { get; set; }//收货日期
        public string Model { get; set; }//类型
        public string Weight { get; set; }
        public string Color { get; set; }
        public string Number { get; set; }
        public string IsSend { get; set; }
        public string Name { get; set; }//收货商家
    }
    //用于保存长丝/氨纶信息的类
    public class ChangsiMessage
    {
        public string Number { get; set; }//序号
        public string Data { get; set; }//收货日期
        public string Type { get; set; }//只有长丝/氨纶两种
        public string Model { get; set; }//类型
        public string Weight { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }//供货商家
    }

    public class ZhixiangMessage
    {
        public string Numb { get; set; }
        public string Data { get; set; }//收货日期
        public string Type { get; set; }//只有长丝/氨纶两种
        public string Number { get; set; }//个数
        public string UnitPrice { get; set; }   //单价
        public string Name { get; set; }//供货商家
        public double Count { get; set; }//总价
    }
}
