using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ConstructionCompanyAPITests.Helpers
{
    public class TaskHelpers
    {
        private readonly ConstructionCompanyContext _persistence;
        
        public TaskHelpers(ConstructionCompanyContext persistence)
        {
            _persistence = persistence;
        }
        public Worker CreateTask()
        {
            var worker = new Worker();
            EntityEntry<Worker> inserted = _persistence.Workers.Add(worker);
            _persistence.SaveChanges();

            return inserted.Entity;
        } 
    }
}
