using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.ScheduleManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-04-26 12:06
    /// 描 述：车辆记录查询实体类
    /// </summary>
    [Table("BusVehicleMission_Record")]
    public class VehicleBrowserEntity : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? VehicleMissionId { get; set; }
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
        public string DriverName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string DriverIdentityNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string DriverPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string VehicleNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? CheckTime { get; set; }
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
        public string GoodsName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GoodsModel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? Destination { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string BillNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CabinetNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? Loadable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? Loaded { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? ShippingDock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? ReachTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? Status { get; set; }
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
