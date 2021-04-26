using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.ScheduleManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-04-26 12:06
    /// 描 述：车辆记录查询实体查询类
    /// </summary>
    public class VehicleBrowserListParam : DateTimeParam
    {
        public string DriverName { get; set; }
        public string DriverIdentityNo { get; set; }
        public string DriverPhone { get; set; }
        public string VehicleNo { get; set; }
        public string OrderNo { get; set; }
        public int? MissonType { get; set; }
        public int? GoodsType { get; set; }
        public int? Status { get; set; }
        public int? ShippingDock { get; set; }
        public int? StartStatus { get; set; }
        public int? EndStatus { get; set; }
    }
}
