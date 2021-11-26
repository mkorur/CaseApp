using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace CaseApp.Web
{
    [Dependency(ReplaceServices = true)]
    public class CaseAppBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "CaseApp";
    }
}
