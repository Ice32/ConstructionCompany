using System;
using System.Collections.Generic;
using System.Linq;
using ConstructionCompany.BR.Worksheets.Implementation.Specifications;
using ConstructionCompany.BR.Worksheets.Interfaces;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Worksheets.Implementation
{
    public class WorksheetService : IWorksheetService
    {
        private readonly ConstructionCompanyContext _constructionCompanyContext;
        private readonly IRepository<Worksheet> _worksheetsRepository;

        public WorksheetService(
            ConstructionCompanyContext constructionCompanyContext,
            IRepository<Worksheet> worksheetsRepository)
        {
            _constructionCompanyContext = constructionCompanyContext;
            _worksheetsRepository = worksheetsRepository;
        }
        public Worksheet AddWorksheet(Worksheet worksheet)
        {
            var inserted = _constructionCompanyContext.Worksheets.Add(worksheet);
            _constructionCompanyContext.SaveChanges();
            return inserted.Entity;
        }

        public Worksheet UpdateWorksheet(Worksheet worksheet)
        {
            _worksheetsRepository.Update(worksheet);
            return worksheet;
        }

        public Worksheet GetById(int id)
        {
            var spec = new WorksheetAllRelatedDataSpecification(id);
            return _worksheetsRepository.GetSingle(spec);
        }

        public List<Worksheet> GetAll()
        {
            var spec = new WorksheetAllRelatedDataSpecification();
            return _worksheetsRepository.List(spec).ToList();
        }

        public void RemoveWorksheet(int worksheetId)
        {
            throw new NotImplementedException();
        }
    }
}
