using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CaseApp.Data;
using Volo.Abp.DependencyInjection;

namespace CaseApp.EntityFrameworkCore
{
    public class EntityFrameworkCoreCaseAppDbSchemaMigrator
        : ICaseAppDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreCaseAppDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the CaseAppDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<CaseAppDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
