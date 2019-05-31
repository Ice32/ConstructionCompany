using System.Collections.Generic;

namespace ConstructionCompanyModel.ViewModels.Worksheets
{
    public class TaskVM
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public List<WorkerVM> Workers { get; set; }
    }
}
