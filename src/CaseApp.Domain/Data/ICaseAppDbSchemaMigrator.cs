using System.Threading.Tasks;

namespace CaseApp.Data
{
    public interface ICaseAppDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
