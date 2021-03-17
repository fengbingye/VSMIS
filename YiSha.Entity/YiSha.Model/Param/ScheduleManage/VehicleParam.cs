using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;
using YiSha.Model.Param.SystemManage;

namespace YiSha.Model.Param.ScheduleManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-03-15 16:10
    /// 描 述：车辆签到实体查询类
    /// </summary>
    public class VehicleListParam : BaseAreaParam
    {
        public string DriverName { get; set; }
        public string DriverIdentityNo { get; set; }
        public string DriverPhone { get; set; }
        public string VehicleNo { get; set; }
    }
}
