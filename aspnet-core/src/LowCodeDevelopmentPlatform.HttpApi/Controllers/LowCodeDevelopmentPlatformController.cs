using LowCodeDevelopmentPlatform.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LowCodeDevelopmentPlatform.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class LowCodeDevelopmentPlatformController : AbpControllerBase
    {
        protected LowCodeDevelopmentPlatformController()
        {
            LocalizationResource = typeof(LowCodeDevelopmentPlatformResource);
        }
    }
}