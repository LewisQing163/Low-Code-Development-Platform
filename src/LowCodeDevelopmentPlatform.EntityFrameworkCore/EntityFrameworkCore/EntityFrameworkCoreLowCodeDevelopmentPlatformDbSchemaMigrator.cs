using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LowCodeDevelopmentPlatform.Data;
using Volo.Abp.DependencyInjection;

namespace LowCodeDevelopmentPlatform.EntityFrameworkCore
{
    public class EntityFrameworkCoreLowCodeDevelopmentPlatformDbSchemaMigrator
        : ILowCodeDevelopmentPlatformDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreLowCodeDevelopmentPlatformDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the LowCodeDevelopmentPlatformDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<LowCodeDevelopmentPlatformDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
