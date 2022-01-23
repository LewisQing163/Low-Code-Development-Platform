using AutoMapper;
using LowCodeDevelopmentPlatform.Common;
using LowCodeDevelopmentPlatform.Entities;
using LowCodeDevelopmentPlatform.IRoleService_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace LowCodeDevelopmentPlatform.RoleService
{
    public class RoleService : ApplicationService,IRoleService
    {
        public readonly IRepository<Role> Repository;
        public RoleService(IRepository<Role> repository)
        {
            Repository = repository;
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="roleDto"></param>
        /// <returns></returns>
        public async Task<ReturnResult<int>> AddRole(RoleDTO roleDto)
        {
            var result = new ReturnResult<int>
            {
                Message = "添加成功",
                State = State.Success
            };
            try
            {
                var data = ObjectMapper.Map<RoleDTO, Role>(roleDto);
                await Repository.InsertAsync(data);
            }
            catch (Exception ex)
            {
                result.Message = "添加失败" + ex.Message;
                result.State = State.Fail;
            }
            return result;
        }
        /// <summary>
        /// 逻辑删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ReturnResult<int>> DeletetRole(Guid id)
        {
            var result = new ReturnResult<int>
            {
                Message = "删除成功",
                State = State.Success
            };
            try
            {
                var list = await Repository.GetListAsync();
                var data = list.Where(d => d.Id.Equals(id)).FirstOrDefault();
                if (data.Status == 1)
                {
                    data.Status = 0;
                }
                await Repository.UpdateAsync(data);
            }
            catch (Exception ex)
            {
                result.Message = "删除失败" + ex.Message;
                result.State = State.Fail;
            }
            return result;
        }
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RoleDTO>> ListRole(string key)
        {
            //查出列表状态是1所有的数据
            var list = Repository.GetListAsync().Result.Where(x => x.Status == 1).ToList();
            if (!string.IsNullOrEmpty(key))
            {
                list = list.Where(d => d.Name.Contains(key)).ToList();
            }
            var data = ObjectMapper.Map<List<Role>, List<RoleDTO>>(list);
            return data;
        }
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="roleDto"></param>
        /// <returns></returns>
        public async Task<ReturnResult<int>> UpdateRole(RoleDTO roleDto)
        {
            var result = new ReturnResult<int>
            {
                Message = "修改成功",
                State = State.Success
            };
            try
            {
                var data = ObjectMapper.Map<RoleDTO, Role>(roleDto);
                await Repository.UpdateAsync(data);
            }
            catch (Exception ex)
            {
                result.Message = "修改失败" + ex.Message;
                result.State = State.Fail;
            }
            return result;
        }
    }
}
