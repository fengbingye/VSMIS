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
    /// 日 期：2021-04-26 12:06
    /// 描 述：车辆记录查询控制器类
    /// </summary>
    [Area("ScheduleManage")]
    public class VehicleBrowserController :  BaseController
    {
        private VehicleBrowserBLL vehicleBrowserBLL = new VehicleBrowserBLL();

        #region 视图功能
        [AuthorizeFilter("schedule:vehiclebrowser:view")]
        public ActionResult VehicleBrowserIndex()
        {
            return View();
        }

        public ActionResult VehicleBrowserForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("schedule:vehiclebrowser:search")]
        public async Task<ActionResult> GetListJson(VehicleBrowserListParam param)
        {
            TData<List<VehicleBrowserEntity>> obj = await vehicleBrowserBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("schedule:vehiclebrowser:search")]
        public async Task<ActionResult> GetPageListJson(VehicleBrowserListParam param, Pagination pagination)
        {
            TData<List<VehicleBrowserEntity>> obj = await vehicleBrowserBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<VehicleBrowserEntity> obj = await vehicleBrowserBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("schedule:vehiclebrowser:add,schedule:vehiclebrowser:edit")]
        public async Task<ActionResult> SaveFormJson(VehicleBrowserEntity entity)
        {
            TData<string> obj = await vehicleBrowserBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("schedule:vehiclebrowser:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await vehicleBrowserBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
