using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.RepositoriesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext context;

        public ApplicationRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Application application)
        {
            context.Applications.Add(application);
            context.SaveChanges();
        }

        public IEnumerable<Application> FindAll()
        {
            return context.Applications.ToList();
        }

        public void AddPassword(int applicationId, int passwordId)
        {
            var password = context.Passwords.FirstOrDefault(t => t.IdPassword == passwordId);

            var application = context.Applications.Include(p => p.Passwords).FirstOrDefault(p => p.IdApplication == applicationId);

            if (application == null)
            {
                application.Passwords = new List<Password>();
            }
            if (application != null && password != null)
            {
                application.Passwords.Add(password);
                context.SaveChanges();
            }
        }
    }
}
