using System.Collections.Generic;
using System.Linq;
using ConstructionCompany.Specifications;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Workers
{
    public class WorkersSuggestionEngine : IWorkersSuggestionEngine
    {
        private readonly IRepository<Task> _tasksRepository;
        public WorkersSuggestionEngine(IRepository<Task> tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }
        public List<WorkerSuggestion> GetSuggestedWorkers(string name, int? taskId)
        {
            List<Task> tasks = _tasksRepository.List(new TaskSpecification(name))
                .Where(t => (taskId == null || t.Id != taskId) && t.Rating != default)
                .ToList();

            bool sameNameTasksExist = tasks.Count != 0;
            if (!sameNameTasksExist)
            {
                // if no tasks with same name exist, look up best rated tasks/workers in general
                tasks = _tasksRepository.List(new TaskSpecification()).Where(t => t.Rating != default).ToList();
            }
            tasks.Sort((t1, t2) => t1.Rating > t2.Rating ? 1 : -1);
            List<WorkerSuggestion> workerSuggestions = tasks
                .SelectMany(t => t.WorkerTasks.Select(wt => new WorkerSuggestion { Worker = wt.Worker, Task = wt.Task, Compatibility = RatingToAbsoluteValue(wt.Task.Rating) }))
                .ToList();

            List<Worker> workers = workerSuggestions.Select(ws => ws.Worker).Distinct().ToList();
            
            var aggregatedSuggestions = new List<WorkerSuggestion>();
            workers.ForEach(worker =>
            {
                IEnumerable<WorkerSuggestion> suggestionsForWorker = workerSuggestions
                    .Where(ws => ws.Worker.Id == worker.Id)
                    .ToList();
                
                float workerCompatibilitySum = suggestionsForWorker
                    .Aggregate(0f, (aggregate, current) => aggregate + current.Compatibility);
                float workerCompatibilityAvg = workerCompatibilitySum / suggestionsForWorker.Count();
                aggregatedSuggestions.Add(new WorkerSuggestion
                {
                    Compatibility = workerCompatibilityAvg,
                    Task = new Task(),
                    Worker = worker
                });
            });

            return aggregatedSuggestions;
        }

        private static float RatingToAbsoluteValue(int rating)
        {
            double result = (rating - 1) * 0.25;
            return (float)result;
        }
    }
}
