using System;
using System.Collections.Generic;
using System.Text;
using LowCodeDevelopmentPlatform.Localization;
using Volo.Abp.Application.Services;

namespace LowCodeDevelopmentPlatform
{
    /* Inherit your application services from this class.
     */
    public abstract class LowCodeDevelopmentPlatformAppService : ApplicationService
    {
        protected LowCodeDevelopmentPlatformAppService()
        {
            LocalizationResource = typeof(LowCodeDevelopmentPlatformResource);
        }
    }
}
