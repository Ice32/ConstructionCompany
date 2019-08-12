using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.Specifications
{

    public class TaskSpecification : BaseSpecification<Task>
    {
        public TaskSpecification()
            : base(c => true)
        {
            AddInclude("WorkerTasks.Worker.User");
            AddInclude("Worksheet.ConstructionSite");
            AddInclude("Worksheet.WorksheetMaterials.Material");
            AddInclude("Worksheet.WorksheetEquipment.Equipment");
        }

        public TaskSpecification(int id)
            : base(c => c.Id == id)
        {
            AddInclude("WorkerTasks.Worker.User");
            AddInclude("Worksheet.ConstructionSite");
            AddInclude("Worksheet.WorksheetMaterials.Material");
            AddInclude("Worksheet.WorksheetEquipment.Equipment");
        }
        
        public TaskSpecification(TaskSearch search)
            : base(t => (search.WorkerId != 0 ? t.WorkerTasks.Exists(wt => wt.WorkerId == search.WorkerId) : true) && (search.ConstructionSiteId != 0 ? t.Worksheet.ConstructionSiteId == search.ConstructionSiteId : true))
        {
            AddInclude("WorkerTasks.Worker.User");
            AddInclude("Worksheet.ConstructionSite");
            AddInclude("Worksheet.WorksheetMaterials.Material");
            AddInclude("Worksheet.WorksheetEquipment.Equipment");
        }

        public TaskSpecification(string title)
            : base(t => t.Title == title)
        {
            AddInclude("WorkerTasks.Worker.User");
            AddInclude("Worksheet.ConstructionSite");
            AddInclude("Worksheet.WorksheetMaterials.Material");
            AddInclude("Worksheet.WorksheetEquipment.Equipment");
        }
    }
}