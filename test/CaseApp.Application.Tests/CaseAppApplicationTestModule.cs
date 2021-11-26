using Volo.Abp.Modularity;

namespace CaseApp
{
    [DependsOn(
        typeof(CaseAppApplicationModule),
        typeof(CaseAppDomainTestModule)
        )]
    public class CaseAppApplicationTestModule : AbpModule
    {

    }
}