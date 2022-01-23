using AutoMapper;
using LowCodeDevelopmentPlatform.Entities;
using LowCodeDevelopmentPlatform.IMenuService_;
using LowCodeDevelopmentPlatform.IRoleService_;
using LowCodeDevelopmentPlatform.IUserInfoService;

namespace LowCodeDevelopmentPlatform
{
    public class LowCodeDevelopmentPlatformApplicationAutoMapperProfile : Profile
    {
        public LowCodeDevelopmentPlatformApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            /* 您可以在此处配置 AutoMapper 映射配置。
              * 或者，您可以拆分映射配置
              * 进入多个配置文件类以获得更好的组织。 */
            //用户
            CreateMap<UserInfo, UserInfoDTO>();
            CreateMap<UserInfoDTO, UserInfo>();
            CreateMap<CreateUpdateUserInfoDTO,UserInfo>();
            //菜单
            CreateMap<Menu, MenuDTO>();
            CreateMap<MenuDTO, Menu>();
            //角色
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();
        }
    }
}
