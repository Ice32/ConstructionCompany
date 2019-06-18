﻿using ConstructionCompany.BR.Specifications;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Worksheets
{
    public class WorksheetService : BaseCRUDService<Worksheet, object, WorksheetAllRelatedDataSpecification>
    {
        private readonly IRepository<Material> _materialsRepository;
        public WorksheetService(IRepository<Worksheet> repository, IRepository<Material> materialsRepository) : base(repository)
        {
            _materialsRepository = materialsRepository;
        }

        public override Worksheet Insert(Worksheet worksheet)
        {
            Worksheet inserted = _repository.Add(worksheet);
            if (worksheet.WorksheetMaterials != null)
            {
                foreach (WorksheetMaterial worksheetWorksheetMaterial in worksheet.WorksheetMaterials)
                {
                    Material material = _materialsRepository.GetById(worksheetWorksheetMaterial.MaterialId);
                    material.Amount -= worksheetWorksheetMaterial.Amount;
                    _materialsRepository.Update(material);
                }
            }

            return inserted;
        }
    }
}