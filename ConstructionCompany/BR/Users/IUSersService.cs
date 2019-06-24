using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Users
{
    public interface IUsersService
    {
        User GetUserFromCredentials(string username, string password);
        User Insert(User user, string password);
        User Update(User user, string password);
    }
}
