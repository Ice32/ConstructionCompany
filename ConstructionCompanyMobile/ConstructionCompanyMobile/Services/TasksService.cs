using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionCompanyModel.ViewModels.Tasks;

namespace ConstructionCompanyMobile.Services
{
    public class TasksService: APIService<TaskVM, TaskAddVM, TaskAddVM>
    {
        public TasksService() : base("tasks")
        {
        }

        public Task<List<TaskVM>> GetByWorkerAndConstructionSite(int? workerId = null, int? constructionSiteId = null)
        {
            var search = new Dictionary<string, string>();
            if (workerId != null)
            {
                search.Add("workerId", workerId.ToString());
            }
            
            if (constructionSiteId != null)
            {
                search.Add("constructionSiteId", constructionSiteId.ToString());
            }
            
            return GetAll(search);
        }
    }
}