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
        
        public virtual List<Task> Get(TaskSearch search)
        {
            List<Task> list = _repository.List(new TaskSpecification(search)).ToList();

            return list;

        }
    }
}
