using Repositories.Entities;
using Repositories.RepositoriesContracts;
using Services.ServicesContracts;
using System.Collections.Generic;

namespace Services.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }
        public void AddApplication(Application application)
        {
            _applicationRepository.Add(application);
        }

        public IEnumerable<Application> GetAllApplications()
        {
            return _applicationRepository.FindAll();
        }

        public void AddPasswordToApplication(int applicationId, int passwordId)
        {
            _applicationRepository.AddPassword(applicationId, passwordId);
        }
    }
}
