﻿using LowCodeDevelopmentPlatform.Common;
using LowCodeDevelopmentPlatform.Entities;
using LowCodeDevelopmentPlatform.Helper;
using LowCodeDevelopmentPlatform.IUserInfoService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace LowCodeDevelopmentPlatform.UserInfoService
{
    public class UserInfoService : ApplicationService, IUserInfo
    {
        //构造注入
        public IRepository<UserInfo> _repository;
        public UserInfoService(IRepository<UserInfo> repository)
        {
            _repository = repository;
        }
        #region CRUD 登录
        /// <summary>
        /// 添加实现
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost, Route("AddUserInfo")]
        public async Task<ReturnResult<int>> AddUserInfo(UserInfoDTO userInfo)
        {
            var data = ObjectMapper.Map<UserInfoDTO, UserInfo>(userInfo);
            await _repository.InsertAsync(data);
            return new ReturnResult<int> { Message = "添加成功", State = State.Success };
        }
        /// <summary>
        /// 删除实现
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, Route("DeletetUserInfo")]
        public async Task<ReturnResult<int>> DeletetUserInfo(int id)
        {
            var list = await _repository.GetListAsync();
            var data = list.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (data.Status==1)
            {
                data.Status = 0;
            }
            await _repository.UpdateAsync(data);
            return new ReturnResult<int> { Message = "删除成功", State = State.Success };
        }
        /// <summary>
        /// 列表实现
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet, Route("ListUserinfo")]
        public async Task<IEnumerable<UserInfoDTO>> ListUserinfo(string key)
        {
            //查出列表所有的数据
            var list = await _repository.GetListAsync();
            list = list.Where(p => p.Status == 1).ToList();
            if (!string.IsNullOrEmpty(key))
            {
                list = list.Where(d => d.Name.Contains(key)&&d.Status==1).ToList();
            }
            var data = ObjectMapper.Map<List<UserInfo>, List<UserInfoDTO>>(list);
            return data;
        }

        /// <summary>
        /// 用户登录实现
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpGet, Route("Login")]
        public async Task<ReturnResult<int>> Login(UserInfoDTO userInfo)
        {
            var list = await _repository.GetListAsync();
            ObjectMapper.Map<List<UserInfo>, List<UserInfoDTO>>(list);
            MD5Helper.MD5Hash(userInfo.Password);
            var data = list.Where(p => p.Name.Equals(userInfo.Name) && p.Password.Equals(userInfo.Password)).FirstOrDefault();
            if (data != null)
            {
                return new ReturnResult<int> { Message = "登陆成功", State = State.Success };
            }
            else
            {
                return new ReturnResult<int> { Message = "账号密码错误!", State = State.Fail };
            }
        }
        /// <summary>
        /// 生成token方法
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static string CreateToken(string userName)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") ,
                new Claim(JwtRegisteredClaimNames.Exp, $"{new DateTimeOffset(DateTime.Now.AddMinutes(30)).ToUnixTimeSeconds()}"),
                new Claim(ClaimTypes.Name, userName)
                };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Const.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
            issuer: Const.Issuer,
            audience: Const.Aduience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        /// <summary>
        /// 修改实现
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost, Route("UpdateUserInfo")]
        public async Task<ReturnResult<int>> UpdateUserInfo(UserInfoDTO userInfo)
        {
            var data = ObjectMapper.Map<UserInfoDTO, UserInfo>(userInfo);
            await _repository.UpdateAsync(data);
            return new ReturnResult<int> { Message = "修改成功", State = State.Success };
        }
        #endregion
    }
}
