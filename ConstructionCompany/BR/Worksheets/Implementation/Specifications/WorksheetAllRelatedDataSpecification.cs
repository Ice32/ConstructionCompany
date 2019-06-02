using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Worksheets.Implementation.Specifications
{

    public class WorksheetAllRelatedDataSpecification : BaseSpecification<Worksheet>
    {
        public WorksheetAllRelatedDataSpecification()
            : base(c => true)
        {
            AddInclude(w => w.ConstructionSite);
            AddInclude("Tasks.WorkerTasks.Worker");
        }

        public WorksheetAllRelatedDataSpecification(int id)
            : base(c => c.Id == id)
        {
            AddInclude(w => w.ConstructionSite);
            AddInclude("Tasks.WorkerTasks.Worker");
        }
    }
}