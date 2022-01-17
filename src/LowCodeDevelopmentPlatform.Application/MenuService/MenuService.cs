﻿using AutoMapper;
using LowCodeDevelopmentPlatform.BaseService;
using LowCodeDevelopmentPlatform.Common;
using LowCodeDevelopmentPlatform.Entities;
using LowCodeDevelopmentPlatform.IMenuService_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace LowCodeDevelopmentPlatform.MenuService
{
    public class MenuService :ApplicationService, IMenuService //BaseService<Menu>
    {
        public readonly IRepository<Menu> Repository;
        public MenuService(IRepository<Menu> repository)
        {
            Repository = repository;
        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="menuDTO"></param>
        /// <returns></returns>
        public async Task<ReturnResult<int>> AddMenu(MenuDTO menuDTO)
        {
           var result= new ReturnResult<int>
            {
                Message = "添加成功",
                State = State.Success
            };
            try
            {
                var data = ObjectMapper.Map<MenuDTO, Menu>(menuDTO);
                await Repository.InsertAsync(data);
            }
            catch (Exception ex)
            {
                result.Message = "添加失败"+ex.Message;
                result.State = State.Fail;
            }
            return result;
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id">参数用户id</param>
        /// <returns></returns>
        public async Task<ReturnResult<int>> DeleteMenu(Guid id)
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

        public async Task<IEnumerable<MenuDTO>> ListMenu()
        {
            //查出列表状态是1所有的数据
            //var list = Repository.GetListAsync().Result.Where(x => x.Status == 1).ToList();
            //if (!string.IsNullOrEmpty(key))
            //{
            //    list = list.Where(d => d.Name.Contains(key)).ToList();
            //}
            //var data = ObjectMapper.Map<List<Menu>, List<MenuDTO>>(list);
            //var list = await Task.Run(() => GetMneu(""));
            return GetMneu(new Guid(""));
          
        }

        public IEnumerable<MenuDTO> GetMneu(Guid id)
        {
            var list =  Repository.GetListAsync().Result;

            var newList = list.Where(p => p.SupId.Equals(id)).ToList();

            List<MenuDTO> treeMenuList = new();
            newList.ForEach( p =>
            {
                MenuDTO treeMenu = new();
                treeMenu.Id = p.Id;
                treeMenu.Name = p.Name;
                treeMenu.Url = p.Url;
                treeMenu.Children = GetMneu(p.Id).ToList();
                treeMenuList.Add(treeMenu);
            });
            return treeMenuList;
        }
        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="menuDTO">需要修改的数据字段</param>
        /// <returns></returns>
        public async Task<ReturnResult<int>> UpdateMenu(MenuDTO menuDTO)
        {
            var result = new ReturnResult<int>
            {
                Message = "修改成功",
                State = State.Success
            };
            try
            {
                var data = ObjectMapper.Map<MenuDTO, Menu>(menuDTO);
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