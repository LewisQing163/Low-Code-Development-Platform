using LowCodeDevelopmentPlatform.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace LowCodeDevelopmentPlatform.IUserInfoService
{
    public interface IUserInfo:IApplicationService
    {
        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        Task<ReturnResult<int>> Login(UserInfoDTO userInfo);
        /// <summary>
        /// 添加用户信息接口
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        Task<ReturnResult<int>> AddUserInfo(UserInfoDTO userInfo);
        /// <summary>
        /// 删除接口
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ReturnResult<int>> DeletetUserInfo(int id);
        /// <summary>
        /// 修改接口
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        Task<ReturnResult<int>> UpdateUserInfo(UserInfoDTO userInfo);
        /// <summary>
        /// 用户列表接口
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<IEnumerable<UserInfoDTO>> ListUserinfo(string key);
    }
}
