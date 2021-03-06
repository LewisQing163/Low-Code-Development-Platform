using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace LowCodeDevelopmentPlatform.Entities
{
    public class Menu: BasicAggregateRoot<Guid>
    {
        /// <summary>
        /// 父类id
        /// </summary>
        public Guid SupId { get; set; }
        /// <summary>
        /// 菜单链接
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 打开目标（原窗口，新窗口或iframe等）
        /// </summary>
        public string Target { get; set; }
        /// <summary>
        /// 菜单名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建人id
        /// </summary>
        public int CreateId { get; set; }
    }
}
