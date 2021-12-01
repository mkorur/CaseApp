using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using CaseApp.Schools;
using CaseApp.Collections;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace CaseApp.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(IIdentityDbContext))]
    [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class CaseAppDbContext : 
        AbpDbContext<CaseAppDbContext>,
        IIdentityDbContext,
        ITenantManagementDbContext
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */
        
        #region Entities from the modules
        
        /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityDbContext and ITenantManagementDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */
        
        //Identity
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        public DbSet<IdentityLinkUser> LinkUsers { get; set; }
        
        // Tenant Management
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        #endregion

        public DbSet<Candidates.Candidate> Candidaties { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionCandidate> CollectionCandidates { get; set; }
        public DbSet<School> Schools { get; set; }

        public CaseAppDbContext(DbContextOptions<CaseAppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();

            /* Configure your own tables/entities inside here */

            builder.Entity<Candidates.Candidate>(b =>
            {
                b.ToTable("Candidaties");
                b.ConfigureByConvention();
                b.HasOne<School>().WithMany().HasForeignKey(x => x.SchoolId).IsRequired();
            });
            builder.Entity<Collection>(b =>
            {
                b.ToTable("Collections");
                b.ConfigureByConvention();
            });
            builder.Entity<CollectionCandidate>(b =>
            {
                b.ToTable("CollectionCandidates");
                b.ConfigureByConvention();
                b.HasOne<Candidates.Candidate>().WithMany().HasForeignKey(x => x.CandidateId).IsRequired();
                b.HasOne<CollectionCandidate>().WithMany().HasForeignKey(x => x.CollecionId).IsRequired();
            });
            builder.Entity<School>(b =>
            {
                b.ToTable("Schools");
                b.ConfigureByConvention();
            });
        }
    }
}
