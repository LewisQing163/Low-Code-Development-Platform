using System;
using System.Collections.Generic;
using System.Text;

namespace LowCodeDevelopmentPlatform.IRoleService_
{
    public class RoleDTO
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime Createtime { get; set; }
        /// <summary>
        /// 创建人id
        /// </summary>
        public int CreateId { get; set; }
    }
}
