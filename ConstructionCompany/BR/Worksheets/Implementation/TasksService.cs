using System.Linq;
using ConstructionCompany.BR.Worksheets.Interfaces;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace ConstructionCompany.BR.Worksheets.Implementation
{
    public class TasksService : ITasksService
    {
        private readonly ConstructionCompanyContext _constructionCompanyContext;
        public TasksService(ConstructionCompanyContext constructionCompanyContext)
        {
            _constructionCompanyContext = constructionCompanyContext;
        }
        public Task AddTask(Task task)
        {
            var inserted = _constructionCompanyContext.Tasks.Add(task);
            _constructionCompanyContext.SaveChanges();
            return inserted.Entity;
        }

        public Task GetById(int id)
        {
            return _constructionCompanyContext.Tasks.Include("Worker").SingleOrDefault(t => t.Id == id);
        }
        
    }
}
