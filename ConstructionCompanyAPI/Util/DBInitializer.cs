using System.Collections.Generic;
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
                // used in tests
                new User
                {
                    FirstName = "manager",
                    LastName = "manager",
                    UserName = "manager",
                    PasswordHash = "ZkAEkrkIixbsdvgZKVbzxmTTdNY=",
                    PasswordSalt = "tTs76CTiFJv2Ui4DbCKGhA=="
                },
                new User
                {
                    FirstName = "fourth",
                    LastName = "csm"
                }
            };
            Worker[] workers = {
                new Worker{ User = users[0]},
                new Worker{ User = users[1]},
            };
            context.Workers.AddRange(workers);
            
            Manager[] managers = {
                new Manager{ User = users[2]}
            };
            context.Manager.AddRange(managers);

            ConstructionSiteManager[] constructionSiteManagers = {
                new ConstructionSiteManager{ User = users[3]}
            };
            
            ConstructionSite[] constructionSites = {
                new ConstructionSite{
                    Title = "Construction site",
                    CreatedBy = managers[0].User,
                    ConstructionSiteManagers = new List<ConstructionSiteSiteManager>
                    {
                        new ConstructionSiteSiteManager
                        {
                            ConstructionSiteManager = constructionSiteManagers[0]
                        }
                    }
                }
            };
            context.ConstructionSites.AddRange(constructionSites);

            context.SaveChanges();
        }
    }
}