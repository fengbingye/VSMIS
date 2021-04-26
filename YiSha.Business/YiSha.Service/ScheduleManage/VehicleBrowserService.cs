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
            }
            return expression;
        }
        #endregion
    }
}
