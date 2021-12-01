using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace CaseApp.Collections
{
    public class CollectionCandidate : AuditedAggregateRoot<Guid>
    {
        public Guid CandidateId { get; set; }
        public Guid CollecionId { get; set; }
    }
}
