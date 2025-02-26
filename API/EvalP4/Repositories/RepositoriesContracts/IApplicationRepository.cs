using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RepositoriesContracts
{
    public interface IApplicationRepository
    {
        /// <summary>
        /// Add a new application
        /// </summary>
        /// <param name="application"></param>
        public void Add(Application application);

        /// <summary>
        /// Get list of all applications
        /// </summary>
        /// <returns>Return the list of all applications</returns>
        public IEnumerable<Application> FindAll();

        /// <summary>
		/// add a password to an application
		///</summary>
		/// <param name="applicationId">application id in the list</param>
		/// <param name="passwordId">password id</param>
		public void AddPassword(int applicationId, int passwordId);
    }
}
