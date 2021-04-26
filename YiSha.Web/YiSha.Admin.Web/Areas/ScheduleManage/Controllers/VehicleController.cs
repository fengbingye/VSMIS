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
using YiSha.Web.Code;

namespace YiSha.Admin.Web.Areas.ScheduleManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-03-16 15:14
    /// 描 述：车辆签到控制器类
    /// </summary>
    [Area("ScheduleManage")]
    public class VehicleController :  BaseController
    {
        private VehicleBLL vehicleBLL = new VehicleBLL();

        #region 视图功能
        [AuthorizeFilter("schedule:vehicle:view")]
        public ActionResult VehicleIndex()
            {
               return View();
        }
        [AuthorizeFilter("schedule:vehicle:view")]
        public ActionResult WapCheck()
        {
            return View();
        }
        public ActionResult QueryVehicleIndex()
        {
            return View();
        }
        public ActionResult CallVehicle()
        {
            return View();
        }
        public async Task<IActionResult> VehicleForm()
        {
            OperatorInfo operatorInfo = await Operator.Instance.Current();
            ViewBag.OperatorInfo = operatorInfo;
            
            return View();
        }
        public async Task<IActionResult> WapVehicleForm()
        {
            OperatorInfo operatorInfo = await Operator.Instance.Current();
            ViewBag.OperatorInfo = operatorInfo;

            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("schedule:vehicle:search")]
        public async Task<ActionResult> GetListJson(VehicleListParam param)
        {
            TData<List<VehicleEntity>> obj = await vehicleBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("schedule:vehicle:search")]
        public async Task<ActionResult> GetPageListJson(VehicleListParam param, Pagination pagination)
        {
            TData<List<VehicleEntity>> obj = await vehicleBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<VehicleEntity> obj = await vehicleBLL.GetEntity(id);
            return Json(obj);
        }
        [HttpGet]
        //获取指定码头已匹配、签到的数量（Fdy@2021.4.2）
        //参数：int iShippingDock（码头编码）
        //返回obj，其中obj.data为排队数量
        public async Task<IActionResult> GetLineCnt(int iShippingDock)
        {
            TData<int> obj = await vehicleBLL.GetLineCnt(iShippingDock);
            return Json(obj);
        }
        [HttpGet]
        //获取司机排队名次（Fdy@2021.4.2）
        //参数：VehicleListParam param（条件参数）
        //返回obj，其中obj.data为排队名次
        public async Task<IActionResult> GetLineNo(VehicleListParam param)
        {
            TData<int> obj = new TData<int>();
            if (!string.IsNullOrEmpty(param.DriverName) || !string.IsNullOrEmpty(param.DriverPhone) || !string.IsNullOrEmpty(param.VehicleNo))
            {
                obj = await vehicleBLL.GetLineNo(param);
            }
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("schedule:vehicle:add,schedule:vehicle:edit")]
        public async Task<ActionResult> SaveFormJson(VehicleEntity entity)
        {
            OperatorInfo operatorInfo = await Operator.Instance.Current();
            entity.DeptId = operatorInfo.DepartmentId;
            entity.UserId = operatorInfo.UserId;
            TData<string> obj = await vehicleBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("schedule:vehicle:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await vehicleBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
