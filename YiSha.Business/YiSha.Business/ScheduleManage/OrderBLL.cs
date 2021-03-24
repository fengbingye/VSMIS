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
using YiSha.Web.Code;

namespace YiSha.Business.ScheduleManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-03-17 10:43
    /// 描 述：订单录入业务类
    /// </summary>
    public class OrderBLL
    {
        private OrderService orderService = new OrderService();

        #region 获取数据
        public async Task<TData<List<OrderEntity>>> GetList(OrderListParam param)
        {
            TData<List<OrderEntity>> obj = new TData<List<OrderEntity>>();
            obj.Data = await orderService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<OrderEntity>>> GetPageList(OrderListParam param, Pagination pagination)
        {
            TData<List<OrderEntity>> obj = new TData<List<OrderEntity>>();
            obj.Data = await orderService.GetPageList(param, pagination);
            OperatorInfo operatorInfo = await Operator.Instance.Current();
            if (operatorInfo.IsSystem != 1)
            {
                obj.Data = obj.Data.Where(p => operatorInfo.DepartmentId.Value.Equals(p.DeptId.Value)).ToList();
            }
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<OrderEntity>> GetEntity(long id)
        {
            TData<OrderEntity> obj = new TData<OrderEntity>();
            obj.Data = await orderService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(OrderEntity entity)
        {
            TData<string> obj = new TData<string>();
            await orderService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await orderService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
