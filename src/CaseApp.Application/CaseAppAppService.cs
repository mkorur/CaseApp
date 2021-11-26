using System;
using System.Collections.Generic;
using System.Text;
using CaseApp.Localization;
using Volo.Abp.Application.Services;

namespace CaseApp
{
    /* Inherit your application services from this class.
     */
    public abstract class CaseAppAppService : ApplicationService
    {
        protected CaseAppAppService()
        {
            LocalizationResource = typeof(CaseAppResource);
        }
    }
}
