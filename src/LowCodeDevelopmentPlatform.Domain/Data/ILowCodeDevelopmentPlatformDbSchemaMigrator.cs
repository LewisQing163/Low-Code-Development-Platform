using System.Threading.Tasks;

namespace LowCodeDevelopmentPlatform.Data
{
    public interface ILowCodeDevelopmentPlatformDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
