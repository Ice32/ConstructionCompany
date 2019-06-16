using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Specifications
{

    public class TasksAllRelatedDataSpecification : BaseSpecification<Task>
    {
        public TasksAllRelatedDataSpecification()
            : base(c => true)
        {
            AddInclude("WorkerTasks.Worker");
        }

        public TasksAllRelatedDataSpecification(int id)
            : base(c => c.Id == id)
        {
            AddInclude("WorkerTasks.Worker");
        }
    }
}