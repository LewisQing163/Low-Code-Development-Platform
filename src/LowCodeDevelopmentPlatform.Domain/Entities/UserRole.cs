using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace LowCodeDevelopmentPlatform.Entities
{
    public class UserRole: BasicAggregateRoot<Guid>
    {
        /// <summary>
        /// 用户表id
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 角色表id
        /// </summary>
        public int Rid { get; set; }
    }
}
