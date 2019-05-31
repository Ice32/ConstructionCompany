using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

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
            Worker worker = new Worker();
            var inserted = _persistence.Workers.Add(worker);
            _persistence.SaveChanges();

            return inserted.Entity;
        } 
    }
}
