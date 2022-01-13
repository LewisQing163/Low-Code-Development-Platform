using LowCodeDevelopmentPlatform.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace LowCodeDevelopmentPlatform.IBaseService_
{
    public interface IBaseService<T> where T : class, new()
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnResult<int>> AddAsync(T model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<ReturnResult<int>> DeleteAsync(Guid ids);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnResult<int>> UpdateAsync(T model);
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="key">查询关键字</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页几条</param>
        /// <returns></returns>
        Task<IEnumerable<T>> SelectAsync(string key, int pageindex = 1, int pagesize = 10);
    }
}
