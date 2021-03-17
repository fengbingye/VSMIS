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
            }
            return expression;
        }
        #endregion
    }
}
