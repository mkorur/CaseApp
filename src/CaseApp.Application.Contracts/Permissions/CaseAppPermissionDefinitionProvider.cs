using CaseApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CaseApp.Permissions
{
    public class CaseAppPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CaseAppPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(CaseAppPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CaseAppResource>(name);
        }
    }
}
