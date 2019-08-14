using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.Specifications
{

    public class WorkerSpecification : BaseSpecification<Worker>
    {
        public WorkerSpecification()
            : base(c => true)
        {
            AddInclude("User");
        }

        public WorkerSpecification(int id)
            : base(c => c.Id == id)
        {
            AddInclude("User");
        }
        
        public WorkerSpecification(User user)
            : base(c => c.UserId == user.Id)
        {
            AddInclude(cs => cs.User);
        }
        
        public WorkerSpecification(UserSearch search)
            : base(w => search.Name != default ? (w.User.FirstName.Contains(search.Name) || w.User.LastName.Contains(search.Name) || w.User.UserName.Contains(search.Name)) : true)
        {
            AddInclude(cs => cs.User);
        }
    }
}