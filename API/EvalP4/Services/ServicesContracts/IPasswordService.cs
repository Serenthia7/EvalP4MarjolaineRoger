using Repositories.Entities;
using System.Collections.Generic;

namespace Services.Services
{
    public interface IPasswordService
    {
        void AddPassword(Password password);
        void DeletePassword(int passwordId);
        IEnumerable<Password> GetAllPasswords();
    }
}
