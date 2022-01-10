using AutoMapper;
using LowCodeDevelopmentPlatform.Entities;
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
            CreateMap<UserInfo, UserInfoDTO>();
            CreateMap<CreateUpdateUserInfoDTO,UserInfo>();
        }
    }
}
