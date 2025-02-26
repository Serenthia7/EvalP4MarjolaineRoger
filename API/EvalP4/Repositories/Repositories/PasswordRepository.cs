using Repositories.Entities;
using Repositories.RepositoriesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly AppDbContext context;

        public PasswordRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Password password)
        {
            context.Passwords.Add(password);
            context.SaveChanges();
        }

        public void Delete(Password password)
        {
            context.Passwords.Remove(context.Passwords.SingleOrDefault(t => t.IdPassword == password.IdPassword));
            context.SaveChanges();
        }


        public IEnumerable<Password> FindAll()
        {
            return context.Passwords.ToList();
        }

    }
}
