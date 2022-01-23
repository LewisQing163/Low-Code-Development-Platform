using LowCodeDevelopmentPlatform.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCodeDevelopmentPlatform.IRoleService_
{
    public interface IRoleService
    {
        /// <summary>
        /// 添加接口
        /// </summary>
        /// <param name="roleDto"></param>
        /// <returns></returns>
        Task<ReturnResult<int>> AddRole(RoleDTO roleDto);
        /// <summary>
        /// 删除接口
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ReturnResult<int>> DeletetRole(Guid id);
        /// <summary>
        /// 修改接口
        /// </summary>
        /// <param name="roleDto"></param>
        /// <returns></returns>
        Task<ReturnResult<int>> UpdateRole(RoleDTO roleDto);
        /// <summary>
        /// 列表接口
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<IEnumerable<RoleDTO>> ListRole(string key);
    }
}
