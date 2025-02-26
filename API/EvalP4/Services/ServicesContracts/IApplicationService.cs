using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesContracts
{
    public interface IApplicationService
    {
        void AddApplication(Application application);
        IEnumerable<Application> GetAllApplications();
        void AddPasswordToApplication(int applicationId, int passwordId);
    }
}
