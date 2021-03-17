﻿using System;
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
    public class OrderService :  RepositoryFactory
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
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<OrderEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<OrderEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(OrderEntity entity)
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
            await this.BaseRepository().Delete<OrderEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<OrderEntity, bool>> ListFilter(OrderListParam param)
        {
            var expression = LinqExtensions.True<OrderEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}