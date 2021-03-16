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
    /// 日 期：2021-03-16 15:14
    /// 描 述：车辆签到业务类
    /// </summary>
    public class VehicleBLL
    {
        private VehicleService vehicleService = new VehicleService();

        #region 获取数据
        public async Task<TData<List<VehicleEntity>>> GetList(VehicleListParam param)
        {
            TData<List<VehicleEntity>> obj = new TData<List<VehicleEntity>>();
            obj.Data = await vehicleService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<VehicleEntity>>> GetPageList(VehicleListParam param, Pagination pagination)
        {
            TData<List<VehicleEntity>> obj = new TData<List<VehicleEntity>>();
            obj.Data = await vehicleService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<VehicleEntity>> GetEntity(long id)
        {
            TData<VehicleEntity> obj = new TData<VehicleEntity>();
            obj.Data = await vehicleService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(VehicleEntity entity)
        {
            TData<string> obj = new TData<string>();
            await vehicleService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await vehicleService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
