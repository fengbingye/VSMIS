using System;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Data;
using YiSha.Data.Repository;
using YiSha.Entity.ScheduleManage;
using YiSha.Model.Param.ScheduleManage;

namespace YiSha.Service.ScheduleManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-03-17 10:43
    /// 描 述：订单录入服务类
    /// </summary>
    public class OrderService : RepositoryFactory
    {
        #region 获取数据
        public async Task<List<OrderEntity>> GetList(OrderListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<OrderEntity>> GetPageList(OrderListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<OrderEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<OrderEntity>(id);
        }
        //获取指定订单关联车辆的Id字符串（Fdy@2021.4.26）
        public async Task<string> GetVehicleIds(long id)
        {
            string sIds = "";
            var expression = LinqExtensions.True<VehicleEntity>();
            expression = expression.And(t => t.OrderId == id);
            //expression = expression.And(t => t.Status == 2 || t.Status == 3);
            var list = await this.BaseRepository().FindList(expression);
            foreach (VehicleEntity item in list)
            {
                if (sIds.Length > 0)
                    sIds += ",";
                sIds += item.Id.ToString();
                //将VehicleEntity数据写入VehicleBrowserEntity
                VehicleBrowserEntity vbEntity = new VehicleBrowserEntity();
                vbEntity.VehicleMissionId = item.Id;
                vbEntity.OrderId = item.OrderId;
                vbEntity.OrderNo = item.OrderNo;
                vbEntity.DriverName = item.DriverName;
                vbEntity.DriverIdentityNo = item.DriverIdentityNo;
                vbEntity.DriverPhone = item.DriverPhone;
                vbEntity.VehicleNo = item.VehicleNo;
                vbEntity.CheckTime = item.CheckTime;
                vbEntity.MissonType = item.MissonType;
                vbEntity.GoodsType = item.GoodsType;
                vbEntity.GoodsName = item.GoodsName;
                vbEntity.GoodsModel = item.GoodsModel;
                vbEntity.Destination = item.Destination;
                vbEntity.BillNumber = item.BillNumber;
                vbEntity.CabinetNo = item.CabinetNo;
                vbEntity.Loadable = item.Loadable;
                vbEntity.Loaded = item.Loaded;
                vbEntity.ShippingDock = item.ShippingDock;
                vbEntity.ReachTime = item.ReachTime;
                vbEntity.Status = item.Status;
                vbEntity.UserId = item.UserId;
                vbEntity.UserName = item.UserName;
                vbEntity.DeptId = item.DeptId;
                vbEntity.DeptName = item.DeptName;
                vbEntity.Remarks = item.Remarks;
                await SaveVehicleBrowserForm(vbEntity);
            }
            //删除VehicleEntity数据
            if (sIds.Length > 0)
                await DeleteVehicleForm(sIds);
            return sIds;
        }
        //获取指定订单关联车辆的为完成数量（Fdy@2021.5.12）
        public async Task<int> GetVehicleLineNum(long id)
        {
            int iRtn = 0;
            var expression = LinqExtensions.True<VehicleEntity>();
            expression = expression.And(t => t.OrderId == id);
            expression = expression.And(t => t.Status < 4);
            var list = await this.BaseRepository().FindList(expression);
            iRtn = list.Count();
            return iRtn;
        }
        //获取指定订单号数量（Fdy@2021.5.13）
        public async Task<int> GetOrderNoCnt(string sOrderNo)
        {
            int iRtn = 0;
            var expression = LinqExtensions.True<OrderEntity>();
            expression = expression.And(t => t.OrderNo == sOrderNo);
            var list = await this.BaseRepository().FindList(expression);
            iRtn = list.Count();
            return iRtn;
        }
        #endregion

        #region 提交数据
        public async Task<int> SaveForm(OrderEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                //判断订单号是否存在（Fdy@2021.5.13）
                int iCnt = await GetOrderNoCnt(entity.OrderNo);
                if (iCnt > 0)
                {
                    return -1;
                }
                entity.Create();
                await this.BaseRepository().Insert(entity);
            }
            else
            {

                await this.BaseRepository().Update(entity);
            }
            return 1;
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<OrderEntity>(idArr);
        }
        //存储VehicleBrowserEntity（Fdy@2021.4.26）
        public async Task SaveVehicleBrowserForm(VehicleBrowserEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                entity.Create();
                await this.BaseRepository().Insert(entity);
            }
            else
            {

                await this.BaseRepository().Update(entity);
            }
        }
        //删除VehicleEntity（Fdy@2021.4.26）
        public async Task DeleteVehicleForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<VehicleEntity>(idArr);
        }

        #endregion

        #region 私有方法
        private Expression<Func<OrderEntity, bool>> ListFilter(OrderListParam param)
        {
            var expression = LinqExtensions.True<OrderEntity>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.OrderNo))
                {
                    expression = expression.And(t => t.OrderNo.Contains(param.OrderNo));
                }
                if (param.MissonType > -1)
                {
                    expression = expression.And(t => t.MissonType == param.MissonType);
                }
                if (param.GoodsType > -1)
                {
                    expression = expression.And(t => t.GoodsType == param.GoodsType);
                }
                if (param.Destination > -1)
                {
                    expression = expression.And(t => t.Destination == param.Destination);
                }
                if (param.ShippingDock > -1)
                {
                    expression = expression.And(t => t.ShippingDock == param.ShippingDock);
                }
                if (param.OrderStatus > -1)
                {
                    expression = expression.And(t => t.OrderStatus == param.OrderStatus);
                }
                if (!string.IsNullOrEmpty(param.StartTime.ParseToString()))
                {
                    expression = expression.And(t => t.CreateTime >= param.StartTime);
                }
                if (!string.IsNullOrEmpty(param.EndTime.ParseToString()))
                {
                    param.EndTime = param.EndTime.Value.Date.Add(new TimeSpan(23, 59, 59));
                    expression = expression.And(t => t.CreateTime <= param.EndTime);
                }
                if (!string.IsNullOrEmpty(param.StartOrderStatus.ParseToString()))
                {
                    expression = expression.And(t => t.OrderStatus >= param.StartOrderStatus);
                }
                if (!string.IsNullOrEmpty(param.EndOrderStatus.ParseToString()))
                {
                    expression = expression.And(t => t.OrderStatus <= param.EndOrderStatus);
                }
            }
            return expression;
        }
        #endregion
    }
}
