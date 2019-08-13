using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.Specifications
{

    public class ConstructionSiteManagerSpecification : BaseSpecification<ConstructionSiteManager>
    {
        public ConstructionSiteManagerSpecification()
            : base(c => true)
        {
            AddInclude(cs => cs.User);
        }

        public ConstructionSiteManagerSpecification(int id)
            : base(c => c.Id == id)
        {
            AddInclude(cs => cs.User);
        }
        
        public ConstructionSiteManagerSpecification(User user)
            : base(c => c.UserId == user.Id)
        {
            AddInclude(cs => cs.User);
        }
        
        public ConstructionSiteManagerSpecification(UserSearch search)
            : base(w => search.Name != default ? (w.User.FirstName.Contains(search.Name) || w.User.LastName.Contains(search.Name) || w.User.UserName.Contains(search.Name)) : true)
        {
            AddInclude(cs => cs.User);
        }
    }
}
