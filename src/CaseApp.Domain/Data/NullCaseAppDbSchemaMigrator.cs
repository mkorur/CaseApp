using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaseApp.Data
{
    /* This is used if database provider does't define
     * ICaseAppDbSchemaMigrator implementation.
     */
    public class NullCaseAppDbSchemaMigrator : ICaseAppDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}