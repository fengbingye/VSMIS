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
    /// 日 期：2021-04-26 12:03
    /// 描 述：订单记录查询服务类
    /// </summary>
    public class OrderBrowserService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<OrderBrowserEntity>> GetList(OrderBrowserListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<OrderBrowserEntity>> GetPageList(OrderBrowserListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<OrderBrowserEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<OrderBrowserEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(OrderBrowserEntity entity)
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
            await this.BaseRepository().Delete<OrderBrowserEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<OrderBrowserEntity, bool>> ListFilter(OrderBrowserListParam param)
        {
            var expression = LinqExtensions.True<OrderBrowserEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
