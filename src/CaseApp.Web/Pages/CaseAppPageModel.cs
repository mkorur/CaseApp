using CaseApp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace CaseApp.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class CaseAppPageModel : AbpPageModel
    {
        protected CaseAppPageModel()
        {
            LocalizationResourceType = typeof(CaseAppResource);
        }
    }
}