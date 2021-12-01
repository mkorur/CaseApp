using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace CaseApp.Collections
{
    public class Collection : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public bool Visible { get; set; }
    }
}
