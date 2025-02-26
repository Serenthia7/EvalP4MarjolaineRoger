using Microsoft.Extensions.Configuration;
using Repositories.Entities;
using Repositories.RepositoriesContracts;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordRepository _passwordRepository;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IConfiguration _configuration;

        public PasswordService(IPasswordRepository passwordRepository, IApplicationRepository applicationRepository, IConfiguration configuration)
        {
            _passwordRepository = passwordRepository;
            _applicationRepository = applicationRepository;
            _configuration = configuration;
        }

        // Ajouter un mot de passe
        public void AddPassword(Password password)
        {
            // Récupérer l'application associée au mot de passe
            var application = _applicationRepository.FindAll().FirstOrDefault(a => a.IdApplication == password.IdApplication);

            if (application == null)
            {
                throw new KeyNotFoundException("Application non trouvée pour ce mot de passe.");
            }

            // Créer une instance de DynamicEncryptionService avec l'ID de l'application pour le chiffrement dynamique
            var encryptionService = new DynamicEncryptionService(_applicationRepository, _configuration, password.IdApplication);

            // Chiffrer le mot de passe avant de l'ajouter
            password.Libelle = encryptionService.Encrypt(password.Libelle);

            // Ajouter le mot de passe chiffré dans le dépôt
            _passwordRepository.Add(password);
        }

        // Supprimer un mot de passe
        public void DeletePassword(int passwordId)
        {
            var password = _passwordRepository.FindAll().FirstOrDefault(p => p.IdPassword == passwordId);

            if (password == null)
            {
                throw new KeyNotFoundException("Mot de passe non trouvé.");
            }

            _passwordRepository.Delete(password);
        }

        // Récupérer tous les mots de passe
        public IEnumerable<Password> GetAllPasswords()
        {
            var passwords = _passwordRepository.FindAll();

            // Déchiffrer chaque mot de passe avant de le renvoyer
            foreach (var password in passwords)
            {
                // Créer une instance de DynamicEncryptionService pour récupérer l'algorithme de déchiffrement basé sur l'application
                var encryptionService = new DynamicEncryptionService(_applicationRepository, _configuration, password.IdApplication);
                password.Libelle = encryptionService.Decrypt(password.Libelle);
            }

            return passwords;
        }
    }
}
