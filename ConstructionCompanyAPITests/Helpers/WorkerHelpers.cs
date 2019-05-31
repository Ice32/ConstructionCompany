using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompanyAPITests.Helpers
{
    public class WorkerHelpers
    {
        private readonly ConstructionCompanyContext _persistence;
        
        public WorkerHelpers(ConstructionCompanyContext persistence)
        {
            _persistence = persistence;
        }
        public Worker CreateWorker()
        {
            User user = new User
            {
                FirstName = "Name",
                LastName = "Last name",
            };
            Worker worker = new Worker
            {
                User = user
            };
            var inserted = _persistence.Workers.Add(worker);
            _persistence.SaveChanges();

            return inserted.Entity;
        } 
    }
}
