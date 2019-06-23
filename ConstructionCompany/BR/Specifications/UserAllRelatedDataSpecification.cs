using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Specifications
{

    public class UserAllRelatedDataSpecification : BaseSpecification<User>
    {
        public UserAllRelatedDataSpecification()
            : base(c => true)
        {
            AddInclude("UserRoles.Role");
        }

        public UserAllRelatedDataSpecification(string username)
            : base(u => u.UserName == username)
        {
            AddInclude("UserRoles.Role");
        }
    }
}