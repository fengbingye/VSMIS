using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.ScheduleManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-04-26 12:03
    /// 描 述：订单记录查询实体查询类
    /// </summary>
    {
        public string OrderNo { get; set; }
        public int? MissonType { get; set; }
        public int? GoodsType { get; set; }
        public int? Destination { get; set; }
        public int? OrderStatus { get; set; }
        public int? ShippingDock { get; set; }
        public int? StartOrderStatus { get; set; }
        public int? EndOrderStatus { get; set; }
    }
}
