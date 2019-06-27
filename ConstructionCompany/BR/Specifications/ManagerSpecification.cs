using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Specifications
{

    public class ManagerSpecification : BaseSpecification<Manager>
    {
        public ManagerSpecification()
            : base(c => true)
        {
            AddInclude(cs => cs.User);
        }

        public ManagerSpecification(int id)
            : base(c => c.Id == id)
        {
            AddInclude(cs => cs.User);
        }
        
        public ManagerSpecification(User user)
            : base(c => c.UserId == user.Id)
        {
            AddInclude(cs => cs.User);
        }
        
        
    }
}