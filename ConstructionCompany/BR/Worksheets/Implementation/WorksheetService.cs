using System;
using System.Collections.Generic;
using System.Linq;
using ConstructionCompany.BR.Worksheets.Interfaces;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace ConstructionCompany.BR.Worksheets.Implementation
{
    public class WorksheetService : IWorksheetService
    {
        private readonly ConstructionCompanyContext _constructionCompanyContext;
        public WorksheetService(ConstructionCompanyContext constructionCompanyContext)
        {
            _constructionCompanyContext = constructionCompanyContext;
        }
        public Worksheet AddWorksheet(Worksheet worksheet)
        {
            var inserted = _constructionCompanyContext.Worksheets.Add(worksheet);
            _constructionCompanyContext.SaveChanges();
            return inserted.Entity;
        }

        public Worksheet GetById(int id)
        {
            return _constructionCompanyContext.Worksheets.Find(id);
        }

        public List<Worksheet> GetAll()
        {
            return _constructionCompanyContext.Worksheets.Include("ConstructionSite").ToList();
        }

        public void RemoveWorksheet(int worksheetId)
        {
            throw new NotImplementedException();
        }
    }
}
