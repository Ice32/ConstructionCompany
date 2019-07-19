using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Users
{
    public interface IUserTypeRetriever
    {
        IUserType Retrieve(User user);
    }
}