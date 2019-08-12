using ConstructionCompanyModel.ViewModels.Tasks;
using ConstructionCompanyModel.ViewModels.Workers;

namespace ConstructionCompanyModel.ViewModels.WorkerSuggestions
{
    public class WorkerSuggestionVM
    {
        public TaskVM Task { get; set; }
        public WorkerVM Worker { get; set; }
        public float Compatibility { get; set; }
    }
}
