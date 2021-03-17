using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using YiSha.Util;
using YiSha.Util.Model;
using YiSha.Entity;
using YiSha.Model;
using YiSha.Admin.Web.Controllers;
using YiSha.Entity.ScheduleManage;
using YiSha.Business.ScheduleManage;
using YiSha.Model.Param.ScheduleManage;

namespace YiSha.Admin.Web.Areas.ScheduleManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-03-17 10:43
    /// 描 述：订单录入控制器类
    /// </summary>
    [Area("ScheduleManage")]
    public class OrderController :  BaseController
    {
        private OrderBLL orderBLL = new OrderBLL();

        #region 视图功能
        [AuthorizeFilter("schedule:order:view")]
        public ActionResult OrderIndex()
        {
            return View();
        }

        public ActionResult OrderForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("schedule:order:search")]
        public async Task<ActionResult> GetListJson(OrderListParam param)
        {
            TData<List<OrderEntity>> obj = await orderBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("schedule:order:search")]
        public async Task<ActionResult> GetPageListJson(OrderListParam param, Pagination pagination)
        {
            TData<List<OrderEntity>> obj = await orderBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<OrderEntity> obj = await orderBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("schedule:order:add,schedule:order:edit")]
        public async Task<ActionResult> SaveFormJson(OrderEntity entity)
        {
            TData<string> obj = await orderBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("schedule:order:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await orderBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
