using System.Collections.Generic;

namespace ConstructionCompanyModel.ViewModels.Tasks
{
    public class TaskAddVM
    {
        public int? Id;
        public string Title { get; set; }

        public string Description { get; set; }

        public List<int> WorkerIds { get; set; }
    }
}
