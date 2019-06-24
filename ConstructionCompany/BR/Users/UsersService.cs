using System;
using System.Security.Cryptography;
using System.Text;
using ConstructionCompany.BR.Specifications;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Users
{
    public class UsersService: IUsersService
    {
        private readonly IRepository<User> _usersRepository;

        public UsersService(IRepository<User> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public User GetUserFromCredentials(string username, string password)
        {
            User user = _usersRepository.GetSingle(new UserAllRelatedDataSpecification(username));

            if (user != null)
            {
                var newHash = GenerateHash(user.PasswordSalt, password);

                if(newHash == user.PasswordHash)
                {
                    return user;
                }
            }

            return null;
        }

        private static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        private static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        
        public User Insert(User user, string password)
        {
            user.PasswordSalt = GenerateSalt();
            user.PasswordHash = GenerateHash(user.PasswordSalt, password);

            return _usersRepository.Add(user);
        }
        
        public User Update(User user, string password)
        {
            user.PasswordSalt = GenerateSalt();
            user.PasswordHash = GenerateHash(user.PasswordSalt, password);

            return _usersRepository.Update(user);
        }
    }
}