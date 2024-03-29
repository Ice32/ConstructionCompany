﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using ConstructionCompanyModel.ViewModels.Worksheets;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Task = ConstructionCompanyDataLayer.Models.Task;

namespace ConstructionCompanyAPITests.Helpers
{
    public class WorksheetHelpers
    {
        private readonly ConstructionCompanyContext _persistence;
        private readonly HttpClient _client;
        
        public WorksheetHelpers(IServiceProvider serviceProvider, HttpClient client)
        {
            _client = client;
            _persistence = serviceProvider.GetRequiredService<ConstructionCompanyContext>();
        }
        public Worksheet CreateWorksheet()
        {
            ConstructionSite constructionSite = new ConstructionSiteHelpers(_persistence, _client).CreateConstructionSite();
            (Worker worker, string _) = new WorkerHelpers(_persistence).CreateWorker();
            
            var worksheet = new Worksheet
            {
                ConstructionSiteId = constructionSite.Id,
                Tasks = new List<Task>
                {
                    new Task
                    {
                        Title = "Title",
                        WorkerTasks = new List<WorkerTask>
                        {
                            new WorkerTask { WorkerId = worker.Id }
                        }
                    }
                }
            };
            return InsertWorksheet(worksheet);
        }
        
        public Worksheet CreateWorksheet(IEnumerable<int> workerIds)
        {
            ConstructionSite constructionSite = new ConstructionSiteHelpers(_persistence, _client).CreateConstructionSite();
            
            var worksheet = new Worksheet
            {
                ConstructionSiteId = constructionSite.Id,
                Tasks = new List<Task>
                {
                    new Task
                    {
                        Title = "Title",
                        WorkerTasks = workerIds.Select(workerId => new WorkerTask { WorkerId = workerId }).ToList()
                    }
                }
            };
            return InsertWorksheet(worksheet);
        }

        private Worksheet InsertWorksheet(Worksheet worksheet)
        {
            EntityEntry<Worksheet> inserted = _persistence.Worksheets.Add(worksheet);
            _persistence.SaveChanges();

            return inserted.Entity;
        }

        public async Task<WorksheetVM> GetWorksheetById(int id)
        {
            HttpResponseMessage retrievalHTTPResponse = await _client.GetAsync($"/api/worksheets/{id}");
            retrievalHTTPResponse.EnsureSuccessStatusCode();
            var stringResponse = await retrievalHTTPResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WorksheetVM>(stringResponse);
        }
    }
}
