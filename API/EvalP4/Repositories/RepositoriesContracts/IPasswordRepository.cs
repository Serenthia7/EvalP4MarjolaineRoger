using Repositories.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RepositoriesContracts
{
    public interface IPasswordRepository
    {
        /// <summary>
        /// Add a new password
        /// </summary>
        /// <param name="password"></param>
        public void Add(Password password);

        /// <summary>
        /// Delete a password
        /// </summary>
        /// <param name="password"></param>
        public void Delete(Password password);

        /// <summary>
        /// Get list of all password
        /// </summary>
        /// <returns>Return the list of all passwords</returns>
        public IEnumerable<Password> FindAll();
    }
}
