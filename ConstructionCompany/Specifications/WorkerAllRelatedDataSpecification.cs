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
    }
}