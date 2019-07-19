using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Users
{
    public interface IUsersService: IService<User, object>
    {
        User GetUserFromCredentials(string username, string password);
        User Insert(User user, string password);
        User Update(User user, string password);
    }
}
