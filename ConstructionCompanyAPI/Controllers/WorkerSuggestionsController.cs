using AutoMapper;
using ConstructionCompany.BR.Workers;
using ConstructionCompanyAPI.Controllers.Generics;
using ConstructionCompanyModel.ViewModels.WorkerSuggestions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConstructionCompanyAPI.Controllers
{
    public class WorkerSuggestionsController : CustomControllerBase
    {
        private readonly IWorkersSuggestionEngine _workersSuggestionEngine;
        private readonly IMapper _mapper;
        public WorkerSuggestionsController(IWorkersSuggestionEngine workersSuggestionEngine, IMapper mapper)
        {
            _workersSuggestionEngine = workersSuggestionEngine;
            _mapper = mapper;
        }

        [HttpGet]
        public List<WorkerSuggestionVM> GetRecommendedWorkers([FromQuery]string taskName, [FromQuery]int? taskId)

        {
            List<WorkerSuggestion> retrieved = _workersSuggestionEngine.GetSuggestedWorkers(taskName, taskId);
            return _mapper.Map<List<WorkerSuggestionVM>>(retrieved);

        }
    }
}
