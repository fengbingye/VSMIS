using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.ScheduleManage;
using YiSha.Model.Param.ScheduleManage;
using YiSha.Service.ScheduleManage;

namespace YiSha.Business.ScheduleManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-04-26 12:03
    /// 描 述：订单记录查询业务类
    /// </summary>
    public class OrderBrowserBLL
    {
        private OrderBrowserService orderBrowserService = new OrderBrowserService();

        #region 获取数据
        public async Task<TData<List<OrderBrowserEntity>>> GetList(OrderBrowserListParam param)
        {
            TData<List<OrderBrowserEntity>> obj = new TData<List<OrderBrowserEntity>>();
            obj.Data = await orderBrowserService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<OrderBrowserEntity>>> GetPageList(OrderBrowserListParam param, Pagination pagination)
        {
            TData<List<OrderBrowserEntity>> obj = new TData<List<OrderBrowserEntity>>();
            obj.Data = await orderBrowserService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<OrderBrowserEntity>> GetEntity(long id)
        {
            TData<OrderBrowserEntity> obj = new TData<OrderBrowserEntity>();
            obj.Data = await orderBrowserService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(OrderBrowserEntity entity)
        {
            TData<string> obj = new TData<string>();
            await orderBrowserService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await orderBrowserService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
