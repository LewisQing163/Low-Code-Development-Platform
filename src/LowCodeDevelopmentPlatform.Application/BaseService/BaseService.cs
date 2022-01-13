using LowCodeDevelopmentPlatform.Common;
using LowCodeDevelopmentPlatform.Entities;
using LowCodeDevelopmentPlatform.IBaseService_;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
namespace LowCodeDevelopmentPlatform.BaseService
{
    public class BaseService<T> : ApplicationService, IBaseService<T> where T :class,  Volo.Abp.Domain.Entities.IEntity<Guid>,new()
    {
        public readonly IRepository<T> _repository;
        public BaseService(IRepository<T> repository) 
        {
            _repository = repository;
        }
       
        [HttpPost,Route("AddAsync")]
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ReturnResult<int>> AddAsync(T model)
        {
            await _repository.InsertAsync(model);
            return new ReturnResult<int> { Message = "添加成功" };
        }
        
        [HttpPost, Route("DeleteAsync")]
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<ReturnResult<int>> DeleteAsync(T model)
        {
            await _repository.UpdateAsync(model);
            return new ReturnResult<int> { Message = "删除成功", State = State.Success };
        }
        
        [HttpPost, Route("DeleteAsync2")]
        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ReturnResult<int>> DeleteAsync(string id)
        {
            await _repository.DeleteAsync(x=>x.Id.ToString().Equals(id));
            return new ReturnResult<int> { Message = "删除成功", State = State.Success };
        }
        
        [HttpGet, Route("SelectAsync")]
        /// <summary>
        /// 带条件列表及分页
        /// </summary>
        /// <param name="key"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> SelectAsync(string key, int pageindex = 1, int pagesize = 10)
        {
            var list = await _repository.GetListAsync();
            return list;
        }
        
        [HttpPost, Route("UpdateAsync")]
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ReturnResult<int>> UpdateAsync(T model)
        {
            //var data = ObjectMapper.Map<UserInfoDTO, UserInfo>(userInfo);
            await _repository.UpdateAsync(model);
            return new ReturnResult<int> { Message = "修改成功", State = State.Success };
        }
    }

    public class MenuService : BaseService<Menu>
    {
        public MenuService(IRepository<Menu> repository) : base(repository)
        {

        }
    }
}
