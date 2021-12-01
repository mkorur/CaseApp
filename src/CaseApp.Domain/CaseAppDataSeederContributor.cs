using CaseApp.Collections;
using CaseApp.Schools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace CaseApp
{
    public class CaseAppDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<School, Guid> _schoolRepository;
        private readonly IRepository<Collection, Guid> _collectionRepository;
        private readonly IRepository<Candidates.Candidate, Guid> _candidateRepository;
        private readonly IRepository<CollectionCandidate, Guid> _collectionCandidateRepository;

        public CaseAppDataSeederContributor(
            IRepository<School, Guid> schoolRepository,
            IRepository<Collection, Guid> collectionRepository,
            IRepository<Candidates.Candidate, Guid> candidateRepository,
            IRepository<CollectionCandidate, Guid> collectionCandidateRepository)
        {
            _schoolRepository = schoolRepository;
            _collectionRepository = collectionRepository;
            _candidateRepository = candidateRepository;
            _collectionCandidateRepository = collectionCandidateRepository;

        }

        public async Task SeedAsync(DataSeedContext context)
        {

            var sakaryaUni = await _schoolRepository.InsertAsync(
                new School
                {
                    Name = "Sakarya Üniversitesi"
                }
            );

            var koleksiyonUniversite = await _collectionRepository.InsertAsync(
                new Collection
                {
                    Name = "Üniversite Koleksiyonu",
                    Visible = true
                }
            );

            var ogrenci1 = await _candidateRepository.InsertAsync(
                new Candidates.Candidate
                {
                    FirstName = "Ahmet",
                    LastName="AL",
                    EMail="ahmet@gmail.com",
                    SchoolId = sakaryaUni.Id,
                    Gender = Candidate.GenderType.Male
                }
            );

            await _collectionCandidateRepository.InsertAsync(
                new CollectionCandidate
                {
                    CollecionId = koleksiyonUniversite.Id,
                    CandidateId = ogrenci1.Id
                },
                autoSave: true
            );

            var ogrenci2 = await _candidateRepository.InsertAsync(
                new Candidates.Candidate
                {
                    FirstName = "Elif",
                    LastName = "AYDIN",
                    EMail = "elif@gmail.com",
                    SchoolId = sakaryaUni.Id,
                    Gender = Candidate.GenderType.Female
                }
            );

            await _collectionCandidateRepository.InsertAsync(
                new CollectionCandidate
                {
                    CollecionId = koleksiyonUniversite.Id,
                    CandidateId = ogrenci2.Id
                },
                autoSave: true
            );

        }
    }
}
