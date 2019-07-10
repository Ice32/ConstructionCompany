using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ConstructionCompanyAPITests.Helpers
{
    public class WorkerHelpers
    {
        private readonly ConstructionCompanyContext _persistence;
        private readonly UserHelpers _userHelpers;
        
        public WorkerHelpers(ConstructionCompanyContext persistence)
        {
            _persistence = persistence;
            _userHelpers = new UserHelpers(persistence);
        }
        public (Worker worker, string password) CreateWorker()
        {
            (User user, string password) = _userHelpers.CreateUser();
            var worker = new Worker
            {
                User = user
            };
            EntityEntry<Worker> inserted = _persistence.Workers.Add(worker);
            _persistence.SaveChanges();

            return (inserted.Entity, password);
        } 
    }
}
