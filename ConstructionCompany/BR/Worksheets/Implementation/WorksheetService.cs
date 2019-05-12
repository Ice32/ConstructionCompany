using ConstructionCompanyAPI.BR.Worksheets.Interfaces;
using DataLayer;
using DataLayer.Models;
using System;

namespace ConstructionCompanyAPI.BR.Worksheets.Implementation
{
    public class WorksheetService : IWorksheetService
    {
        private readonly ConstructionCompanyContext constructionCompanyContext;
        public WorksheetService(ConstructionCompanyContext constructionCompanyContext)
        {
            this.constructionCompanyContext = constructionCompanyContext;
        }
        public Worksheet AddWorksheet(Worksheet worksheet)
        {
            var inserted = constructionCompanyContext.Worksheets.Add(worksheet);
            constructionCompanyContext.SaveChanges();
            return inserted.Entity;
        }

        public void CompleteWorksheet(int worksheetId)
        {
            throw new NotImplementedException();
        }

        public void RemoveWorksheet(int worksheetId)
        {
            throw new NotImplementedException();
        }
    }
}
