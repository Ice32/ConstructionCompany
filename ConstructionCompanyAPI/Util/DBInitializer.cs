using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using System.Linq;

namespace ConstructionCompanyAPI.Util
{
    public static class DBInitializer
    {
        public static void Initialize(ConstructionCompanyContext context)
        {
            context.Database.EnsureCreated();

            if (context.ConstructionSites.Any())
            {
                return;   // DB has been seeded
            }

            ConstructionSite[] constructionSites = {
                new ConstructionSite{Title= "Construction site"},
            
            };

            User[] users = {
                new User
                {
                    FirstName = "first",
                    LastName = "worker"
                },
                new User
                {
                    FirstName = "second",
                    LastName = "worker"
                },
            };
            Worker[] workers = {
                new Worker{ User = users[0]},
                new Worker{ User = users[1]},
            
            };
            context.ConstructionSites.AddRange(constructionSites);
            context.Workers.AddRange(workers);

            context.SaveChanges();
        }
    }
}
