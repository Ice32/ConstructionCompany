using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.Specifications
{

    public class TaskSpecification : BaseSpecification<Task>
    {
        public TaskSpecification()
            : base(c => true)
        {
            AddInclude("WorkerTasks.Worker");
        }

        public TaskSpecification(int id)
            : base(c => c.Id == id)
        {
            AddInclude("WorkerTasks.Worker");
        }
        
        public TaskSpecification(TaskSearch search)
            : base(t => t.WorkerTasks.Find(wt => wt.WorkerId == search.WorkerId) != null)
        {
            AddInclude("WorkerTasks.Worker");
        }
    }
}