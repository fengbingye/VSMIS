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
    /// 日 期：2021-04-26 12:03
    /// 描 述：订单记录查询控制器类
    /// </summary>
    [Area("ScheduleManage")]
    public class OrderBrowserController :  BaseController
    {
        private OrderBrowserBLL orderBrowserBLL = new OrderBrowserBLL();

        #region 视图功能
        [AuthorizeFilter("schedule:orderbrowser:view")]
        public ActionResult OrderBrowserIndex()
        {
            return View();
        }

        public ActionResult OrderBrowserForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("schedule:orderbrowser:search")]
        public async Task<ActionResult> GetListJson(OrderBrowserListParam param)
        {
            TData<List<OrderBrowserEntity>> obj = await orderBrowserBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("schedule:orderbrowser:search")]
        public async Task<ActionResult> GetPageListJson(OrderBrowserListParam param, Pagination pagination)
        {
            TData<List<OrderBrowserEntity>> obj = await orderBrowserBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<OrderBrowserEntity> obj = await orderBrowserBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("schedule:orderbrowser:add,schedule:orderbrowser:edit")]
        public async Task<ActionResult> SaveFormJson(OrderBrowserEntity entity)
        {
            TData<string> obj = await orderBrowserBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("schedule:orderbrowser:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await orderBrowserBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
