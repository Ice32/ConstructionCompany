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
        private readonly IRepository<Material> _materialsRepository;

        public WorksheetService(
            ConstructionCompanyContext constructionCompanyContext,
            IRepository<Worksheet> worksheetsRepository, IRepository<Material> materialsRepository)
        {
            _constructionCompanyContext = constructionCompanyContext;
            _worksheetsRepository = worksheetsRepository;
            _materialsRepository = materialsRepository;
        }
        public Worksheet AddWorksheet(Worksheet worksheet)
        {
            var inserted = _constructionCompanyContext.Worksheets.Add(worksheet);
            if (worksheet.WorksheetMaterials != null)
            {
                foreach (WorksheetMaterial worksheetWorksheetMaterial in worksheet.WorksheetMaterials)
                {
                    Material material = _materialsRepository.GetById(worksheetWorksheetMaterial.MaterialId);
                    material.Amount -= worksheetWorksheetMaterial.Amount;
                    _materialsRepository.Update(material);
                }
            }
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
