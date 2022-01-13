using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace LowCodeDevelopmentPlatform.Entities
{
    public class RoleMenu : BasicAggregateRoot<Guid>
    {
        /// <summary>
        /// 角色id
        /// </summary>
        public Guid Rid { get; set; }
        /// <summary>
        /// 菜单id
        /// </summary>
        public Guid Mid { get; set; }

    }
}
