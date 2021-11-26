using Volo.Abp.Settings;

namespace CaseApp.Settings
{
    public class CaseAppSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(CaseAppSettings.MySetting1));
        }
    }
}
