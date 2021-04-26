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
    /// 日 期：2021-04-26 12:06
    /// 描 述：车辆记录查询业务类
    /// </summary>
    public class VehicleBrowserBLL
    {
        private VehicleBrowserService vehicleBrowserService = new VehicleBrowserService();

        #region 获取数据
        public async Task<TData<List<VehicleBrowserEntity>>> GetList(VehicleBrowserListParam param)
        {
            TData<List<VehicleBrowserEntity>> obj = new TData<List<VehicleBrowserEntity>>();
            obj.Data = await vehicleBrowserService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<VehicleBrowserEntity>>> GetPageList(VehicleBrowserListParam param, Pagination pagination)
        {
            TData<List<VehicleBrowserEntity>> obj = new TData<List<VehicleBrowserEntity>>();
            obj.Data = await vehicleBrowserService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<VehicleBrowserEntity>> GetEntity(long id)
        {
            TData<VehicleBrowserEntity> obj = new TData<VehicleBrowserEntity>();
            obj.Data = await vehicleBrowserService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(VehicleBrowserEntity entity)
        {
            TData<string> obj = new TData<string>();
            await vehicleBrowserService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await vehicleBrowserService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
