using System.Collections.Generic;
using ConstructionCompanyModel.ViewModels.Workers;

namespace ConstructionCompanyModel.ViewModels.Tasks
{
    public class TaskVM
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public List<WorkerVM> Workers { get; set; }
    }
}
