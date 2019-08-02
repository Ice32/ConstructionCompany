using System.Collections.Generic;
using System.Linq;
using ConstructionCompany.Specifications;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Tasks
{
    public class TasksService : BaseCRUDService<Task, TaskSearch, TaskSpecification>
    {
        public TasksService(IRepository<Task> repository) : base(repository)
        {
        }
        
        public override List<Task> Get(TaskSearch search)
        {
            if (search.WorkerId != default || search.ConstructionSiteId != default)
            {
                return _repository.List(new TaskSpecification(search)).ToList();
            }
            return _repository.List(new TaskSpecification()).ToList();
        }
    }
}
