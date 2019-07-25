using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.Specifications
{

    public class WorksheetAllRelatedDataSpecification : BaseSpecification<Worksheet>
    {
        public WorksheetAllRelatedDataSpecification()
            : base(c => true)
        {
            AddInclude(w => w.ConstructionSite);
            AddInclude("Tasks.WorkerTasks.Worker.User");
            AddInclude("WorksheetMaterials.Material");
            AddInclude("WorksheetEquipment.Equipment");
        }

        public WorksheetAllRelatedDataSpecification(int id)
            : base(c => c.Id == id)
        {
            AddInclude(w => w.ConstructionSite);
            AddInclude("Tasks.WorkerTasks.Worker.User");
            AddInclude("WorksheetMaterials.Material");
            AddInclude("WorksheetEquipment.Equipment");
        }
    }
}