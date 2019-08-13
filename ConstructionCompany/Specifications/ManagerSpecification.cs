using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.Specifications
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
        
        public ManagerSpecification(UserSearch search)
            : base(w => search.Name != default ? (w.User.FirstName.Contains(search.Name) || w.User.LastName.Contains(search.Name) || w.User.UserName.Contains(search.Name)) : true)
        {
            AddInclude(cs => cs.User);
        }
    }
}