using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.Specifications
{

    public class WorksheetSpecification : BaseSpecification<Worksheet>
    {
        public WorksheetSpecification()
            : base(c => true)
        {
            AddInclude(w => w.ConstructionSite);
            AddInclude("Tasks.WorkerTasks.Worker.User");
            AddInclude("WorksheetMaterials.Material");
            AddInclude("WorksheetEquipment.Equipment");
        }

        public WorksheetSpecification(int id)
            : base(c => c.Id == id)
        {
            AddInclude(w => w.ConstructionSite);
            AddInclude("Tasks.WorkerTasks.Worker.User");
            AddInclude("WorksheetMaterials.Material");
            AddInclude("WorksheetEquipment.Equipment");
        }
        
        public WorksheetSpecification(WorksheetSearch search)
            : base(c => (search.Date != default ? c.Date.Date.Equals(search.Date.Date) : true) && (search.ConstructionSiteId != default ? c.ConstructionSiteId == search.ConstructionSiteId : true))
        {
            AddInclude(w => w.ConstructionSite);
            AddInclude("Tasks.WorkerTasks.Worker.User");
            AddInclude("WorksheetMaterials.Material");
            AddInclude("WorksheetEquipment.Equipment");
        }
    }
}