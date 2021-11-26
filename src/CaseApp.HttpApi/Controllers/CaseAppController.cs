using CaseApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CaseApp.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class CaseAppController : AbpController
    {
        protected CaseAppController()
        {
            LocalizationResource = typeof(CaseAppResource);
        }
    }
}