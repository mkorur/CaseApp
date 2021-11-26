using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace CaseApp
{
    public class CaseAppWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<CaseAppWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}