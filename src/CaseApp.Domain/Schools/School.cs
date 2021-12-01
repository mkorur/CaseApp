using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace CaseApp.Schools
{
    public class School : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
    }
}
