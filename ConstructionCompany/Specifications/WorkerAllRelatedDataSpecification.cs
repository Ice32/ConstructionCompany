using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.Specifications
{

    public class WorkerAllRelatedDataSpecification : BaseSpecification<Worker>
    {
        public WorkerAllRelatedDataSpecification()
            : base(c => true)
        {
            AddInclude("User");
        }

        public WorkerAllRelatedDataSpecification(int id)
            : base(c => c.Id == id)
        {
            AddInclude("User");
        }
        
        public WorkerAllRelatedDataSpecification(User user)
            : base(c => c.UserId == user.Id)
        {
            AddInclude(cs => cs.User);
        }
        
        public WorkerAllRelatedDataSpecification(UserSearch search)
            : base(w => search.Name != default ? (w.User.FirstName.Contains(search.Name) || w.User.LastName.Contains(search.Name) || w.User.UserName.Contains(search.Name)) : true)
        {
            AddInclude(cs => cs.User);
        }
    }
}