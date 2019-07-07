using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.Specifications
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
        
        public UserAllRelatedDataSpecification(int id)
            : base(u => u.Id == id)
        {
            AddInclude("UserRoles.Role");
        }
    }
}