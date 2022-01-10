using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace LowCodeDevelopmentPlatform
{
    [Dependency(ReplaceServices = true)]
    public class LowCodeDevelopmentPlatformBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "LowCodeDevelopmentPlatform";
    }
}
