using CaseApp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace CaseApp
{
    [DependsOn(
        typeof(CaseAppEntityFrameworkCoreTestModule)
        )]
    public class CaseAppDomainTestModule : AbpModule
    {

    }
}