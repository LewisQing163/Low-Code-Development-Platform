using LowCodeDevelopmentPlatform.Common;
using LowCodeDevelopmentPlatform.Entities;
using LowCodeDevelopmentPlatform.IBaseService_;
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
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<ReturnResult<int>> DeleteAsync(Guid ids)
        {
            var list = await _repository.GetListAsync();
            var data = list.Where(d => d.Id.Equals(ids)).FirstOrDefault();
            //if (data.Status == 1)
            //{
            //    data.Status = 0;
            //}
            await _repository.UpdateAsync(data);
            return new ReturnResult<int> { Message = "删除成功", State = State.Success };
        }

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
