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
    /// 日 期：2021-03-16 15:14
    /// 描 述：车辆签到服务类
    /// </summary>
    public class VehicleService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<VehicleEntity>> GetList(VehicleListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<VehicleEntity>> GetPageList(VehicleListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<VehicleEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<VehicleEntity>(id);
        }

        //获取指定码头已匹配、签到的数量（Fdy@2021.4.2）
        public async Task<int> GetLineCnt(int iShippingDock)
        {
            int iRtn = 0;
            var expression = LinqExtensions.True<VehicleEntity>();
            expression = expression.And(t => t.ShippingDock == iShippingDock);
            expression = expression.And(t => t.Status == 2 || t.Status == 3);
            var list = await this.BaseRepository().FindList(expression);
            iRtn = list.Count();
            return iRtn;
        }
        //按条件获取码头编码（Fdy@2021.4.2）
        public async Task<int> GetShippingDock(VehicleListParam param)
        {
            int iRtn = 0;
            var expression = ListFilter(param);
            expression = expression.And(t => t.Status == 2 || t.Status == 3);
            var list = await this.BaseRepository().FindList(expression);
            foreach(VehicleEntity item in list)
            {
                iRtn = (int)item.ShippingDock;
                break;
            }
            return iRtn;
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(VehicleEntity entity)
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
            await this.BaseRepository().Delete<VehicleEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<VehicleEntity, bool>> ListFilter(VehicleListParam param)
        {
            var expression = LinqExtensions.True<VehicleEntity>();
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
