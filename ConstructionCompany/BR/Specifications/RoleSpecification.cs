using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Specifications
{
    public class RoleSpecification : BaseSpecification<Role>
    {
        public RoleSpecification() : base(c => true)
        {
        }

        public RoleSpecification(Role.RoleEnum roleName)
            : base(r => r.Name == roleName)
        {
        }
    }
}