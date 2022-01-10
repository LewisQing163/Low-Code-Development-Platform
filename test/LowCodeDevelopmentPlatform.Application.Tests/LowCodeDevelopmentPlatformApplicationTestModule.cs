using Volo.Abp.Modularity;

namespace LowCodeDevelopmentPlatform
{
    [DependsOn(
        typeof(LowCodeDevelopmentPlatformApplicationModule),
        typeof(LowCodeDevelopmentPlatformDomainTestModule)
        )]
    public class LowCodeDevelopmentPlatformApplicationTestModule : AbpModule
    {

    }
}