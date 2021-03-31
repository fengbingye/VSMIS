using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;
using System.Threading.Tasks;

namespace YiSha.Model.Param.ScheduleManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-03-17 10:43
    /// 描 述：订单匹配查询类
    /// </summary>
    public class PlanListParam : DateTimeParam
    {
        public string OrderNo { get; set; }
        public int? MissonType { get; set; }
        public int? GoodsType { get; set; }

    }
}
