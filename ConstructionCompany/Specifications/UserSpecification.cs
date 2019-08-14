using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.Specifications
{

    public class UserSpecification : BaseSpecification<User>
    {
        public UserSpecification()
            : base(c => true)
        {
            AddInclude("UserRoles.Role");
        }

        public UserSpecification(string username)
            : base(u => u.UserName == username)
        {
            AddInclude("UserRoles.Role");
        }
        
        public UserSpecification(int id)
            : base(u => u.Id == id && u.IsDeleted != true)
        {
            AddInclude("UserRoles.Role");
        }
    }
}