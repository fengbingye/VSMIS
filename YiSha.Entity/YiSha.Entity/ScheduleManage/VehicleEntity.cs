using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.ScheduleManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-03-15 17:01
    /// 描 述：车辆签到实体类
    /// </summary>
    [Table("BusVehicleMission")]
    public class VehicleEntity : BaseEntity
    {
        /// <summary>
        /// 订单Id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? OrderId { get; set; }
        /// <summary>
        /// 销售订单号
        /// </summary>
        /// <returns></returns>
        public string OrderNo { get; set; }
        /// <summary>
        /// 司机姓名
        /// </summary>
        /// <returns></returns>
        public string DriverName { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        /// <returns></returns>
        public string DriverIdentityNo { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        /// <returns></returns>
        public string DriverPhone { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        /// <returns></returns>
        public string VehicleNo { get; set; }
        /// <summary>
        /// 签到时间
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? CheckTime { get; set; }
        /// <summary>
        /// 任务类型（01：装货 02：卸货）
        /// </summary>
        /// <returns></returns>
        public int? MissonType { get; set; }
        /// <summary>
        /// 货物类型（01：成品 02：原材料）
        /// </summary>
        /// <returns></returns>
        public int? GoodsType { get; set; }
        /// <summary>
        /// 货物名称（卸货填写）
        /// </summary>
        /// <returns></returns>
        public string GoodsName { get; set; }
        /// <summary>
        /// 货物型号（卸货填写）
        /// </summary>
        /// <returns></returns>
        public string GoodsModel { get; set; }
        /// <summary>
        /// 目的地（01：国内  02：国外）
        /// </summary>
        /// <returns></returns>
        public int? Destination { get; set; }
        /// <summary>
        /// 提单号
        /// </summary>
        /// <returns></returns>
        public string BillNumber { get; set; }
        /// <summary>
        /// 柜号
        /// </summary>
        /// <returns></returns>
        public string CabinetNo { get; set; }
        /// <summary>
        /// 可装载
        /// </summary>
        /// <returns></returns>
        public int? Loadable { get; set; }
        /// <summary>
        /// 已装载
        /// </summary>
        /// <returns></returns>
        public int? Loaded { get; set; }
        /// <summary>
        /// 出货码头
        /// </summary>
        /// <returns></returns>
        public int? ShippingDock { get; set; }
        /// <summary>
        /// 到达时间
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? ReachTime { get; set; }
        /// <summary>
        /// 当前状态（01：签到 02：装货中 03：结束）
        /// </summary>
        /// <returns></returns>
        public int? Status { get; set; }
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
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string Remarks { get; set; }
    }
}
