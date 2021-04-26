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
    /// 日 期：2021-04-26 12:06
    /// 描 述：车辆记录查询服务类
    /// </summary>
    public class VehicleBrowserService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<VehicleBrowserEntity>> GetList(VehicleBrowserListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<VehicleBrowserEntity>> GetPageList(VehicleBrowserListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<VehicleBrowserEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<VehicleBrowserEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(VehicleBrowserEntity entity)
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

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<VehicleBrowserEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<VehicleBrowserEntity, bool>> ListFilter(VehicleBrowserListParam param)
        {
            var expression = LinqExtensions.True<VehicleBrowserEntity>();
            if (param != null)
            {
                if (!param.DriverName.IsEmpty())
                {
                    expression = expression.And(t => t.DriverName.Contains(param.DriverName));
                }
                if (!param.DriverIdentityNo.IsEmpty())
                {
                    expression = expression.And(t => t.DriverIdentityNo.Contains(param.DriverIdentityNo));
                }
                if (!param.DriverPhone.IsEmpty())
                {
                    expression = expression.And(t => t.DriverPhone.Contains(param.DriverPhone));
                }
                if (!param.VehicleNo.IsEmpty())
                {
                    expression = expression.And(t => t.VehicleNo.Contains(param.VehicleNo));
                }
                if (!param.OrderNo.IsEmpty())
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
                if (param.Status > -1)
                {
                    expression = expression.And(t => t.Status == param.Status);
                }

                if (param.ShippingDock > -1)
                {
                    expression = expression.And(t => t.ShippingDock == param.ShippingDock);
                }
                if (!string.IsNullOrEmpty(param.StartStatus.ParseToString()))
                {
                    expression = expression.And(t => t.Status >= param.StartStatus);
                }
                if (!string.IsNullOrEmpty(param.EndStatus.ParseToString()))
                {
                    expression = expression.And(t => t.Status <= param.EndStatus);
                }
                if (!string.IsNullOrEmpty(param.StartTime.ParseToString()))
                {
                    expression = expression.And(t => t.CheckTime >= param.StartTime);
                }
                if (!string.IsNullOrEmpty(param.EndTime.ParseToString()))
                {
                    param.EndTime = param.EndTime.Value.Date.Add(new TimeSpan(23, 59, 59));
                    expression = expression.And(t => t.CheckTime <= param.EndTime);
                }
            }
            return expression;
        }
        #endregion
    }
}
