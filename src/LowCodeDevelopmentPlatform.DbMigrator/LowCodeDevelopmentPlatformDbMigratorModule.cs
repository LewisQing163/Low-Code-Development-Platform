using LowCodeDevelopmentPlatform.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace LowCodeDevelopmentPlatform.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(LowCodeDevelopmentPlatformEntityFrameworkCoreModule),
        typeof(LowCodeDevelopmentPlatformApplicationContractsModule)
        )]
    public class LowCodeDevelopmentPlatformDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
