using CaseApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace CaseApp.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(CaseAppEntityFrameworkCoreModule),
        typeof(CaseAppApplicationContractsModule)
        )]
    public class CaseAppDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
