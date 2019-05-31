using System.Collections.Generic;
using System.Linq;
using ConstructionCompany.BR.Workers.Interfaces;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace ConstructionCompany.BR.Workers.Implementation
{
    public class WorkersService : IWorkersService
    {
        private readonly ConstructionCompanyContext _constructionCompanyContext;
        public WorkersService(ConstructionCompanyContext constructionCompanyContext)
        {
            _constructionCompanyContext = constructionCompanyContext;
        }
        public List<Worker> GetAll()
        {
            return _constructionCompanyContext.Workers.Include("User").ToList();
        }
    }
}
