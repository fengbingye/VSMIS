using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.ScheduleManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-04-26 12:03
    /// 描 述：订单记录查询实体类
    /// </summary>
    [Table("BusOrder_Record")]
    public class OrderBrowserEntity : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? OrderId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string OrderNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? MissonType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? GoodsType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? Destination { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? TotalQuantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? ExecutionTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? FinishTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? OperationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? OrderStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? ShippingDock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? DeptId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string DeptName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Remarks { get; set; }
    }
}
