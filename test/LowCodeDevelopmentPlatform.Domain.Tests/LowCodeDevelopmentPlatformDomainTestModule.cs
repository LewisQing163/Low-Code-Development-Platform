using LowCodeDevelopmentPlatform.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LowCodeDevelopmentPlatform
{
    [DependsOn(
        typeof(LowCodeDevelopmentPlatformEntityFrameworkCoreTestModule)
        )]
    public class LowCodeDevelopmentPlatformDomainTestModule : AbpModule
    {

    }
}