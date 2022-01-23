using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace LowCodeDevelopmentPlatform.Data
{
    /* This is used if database provider does't define
     * ILowCodeDevelopmentPlatformDbSchemaMigrator implementation.
     */
    public class NullLowCodeDevelopmentPlatformDbSchemaMigrator : ILowCodeDevelopmentPlatformDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}