using LowCodeDevelopmentPlatform.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LowCodeDevelopmentPlatform.Permissions
{
    public class LowCodeDevelopmentPlatformPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(LowCodeDevelopmentPlatformPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(LowCodeDevelopmentPlatformPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<LowCodeDevelopmentPlatformResource>(name);
        }
    }
}
