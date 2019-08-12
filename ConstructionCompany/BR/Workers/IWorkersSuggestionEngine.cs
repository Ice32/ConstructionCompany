using System.Collections.Generic;

namespace ConstructionCompany.BR.Workers
{
    public interface IWorkersSuggestionEngine
    {
        List<WorkerSuggestion> GetSuggestedWorkers(string taskName, int? taskId);
    }
}
