using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace LowCodeDevelopmentPlatform.Entities
{
    public class Role: BasicAggregateRoot<Guid>
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public int Name { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public int Createtime { get; set; }
        /// <summary>
        /// 创建人id
        /// </summary>
        public int CreateId { get; set; }
    }
}
