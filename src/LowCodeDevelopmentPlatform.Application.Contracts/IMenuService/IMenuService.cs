using LowCodeDevelopmentPlatform.Common;
using LowCodeDevelopmentPlatform.IBaseService_;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace LowCodeDevelopmentPlatform.IMenuService_
{
    public interface IMenuService:IApplicationService // IBaseService<MenuDTO>
    {
        /// <summary>
        /// 添加用户信息接口
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        Task<ReturnResult<int>> AddMenu(MenuDTO menuDTO);
        /// <summary>
        /// 删除接口
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ReturnResult<int>> DeleteMenu(Guid id);
        /// <summary>
        /// 编辑接口
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        Task<ReturnResult<int>> UpdateMenu(MenuDTO menuDTO);
        /// <summary>
        /// 菜单列表接口
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        //Task<List<MenuDTO>> ListMenu();
    }
}
