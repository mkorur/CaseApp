using CaseApp.Candidate;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace CaseApp.Candidates
{
    public class Candidate : AuditedAggregateRoot<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public Guid SchoolId { get; set; }
        public GenderType Gender { get; set; }
    }
}
