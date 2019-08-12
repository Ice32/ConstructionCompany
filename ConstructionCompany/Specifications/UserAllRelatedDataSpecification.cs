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
            : base(u => u.UserName == username && u.IsDeleted != true)
        {
            AddInclude("UserRoles.Role");
        }
        
        public UserAllRelatedDataSpecification(int id)
            : base(u => u.Id == id && u.IsDeleted != true)
        {
            AddInclude("UserRoles.Role");
        }
    }
}