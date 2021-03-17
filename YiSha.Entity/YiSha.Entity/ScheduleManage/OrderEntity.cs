using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.ScheduleManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-03-17 10:43
    /// 描 述：订单录入实体类
    /// </summary>
    [Table("BusOrder")]
    public class OrderEntity : BaseEntity
    {
        /// <summary>
        /// 销售订单号
        /// </summary>
        /// <returns></returns>
        public string OrderNo { get; set; }
        /// <summary>
        /// 任务类型（01：装货  02：卸货）
        /// </summary>
        /// <returns></returns>
        public int? MissonType { get; set; }
        /// <summary>
        /// 货物类型（01：成品 02：原材料）
        /// </summary>
        /// <returns></returns>
        public int? GoodsType { get; set; }
        /// <summary>
        /// 目的地（01：国内 02：国外）
        /// </summary>
        /// <returns></returns>
        public int? Destination { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        /// <returns></returns>
        public int? TotalQuantity { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 执行时间
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? ExecutionTime { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? FinishTime { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? OperationTime { get; set; }
        /// <summary>
        /// 订单状态（01：新订单 02：已匹配 03：已排队 04：结束 05：取消）
        /// </summary>
        /// <returns></returns>
        public int? OrderStatus { get; set; }
        /// <summary>
        /// 出库码头
        /// </summary>
        /// <returns></returns>
        public int? ShippingDock { get; set; }
        /// <summary>
        /// 操作员Id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? UserId { get; set; }
        /// <summary>
        /// 操作员姓名
        /// </summary>
        /// <returns></returns>
        public string UserName { get; set; }
        /// <summary>
        /// 部门Id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? DeptId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        /// <returns></returns>
        public string DeptName { get; set; }
        /// <summary>
        /// 备注说明
        /// </summary>
        /// <returns></returns>
        public string Remarks { get; set; }
    }
}
