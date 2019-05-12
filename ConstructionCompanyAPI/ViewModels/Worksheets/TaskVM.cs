using DataLayer.Models;
using System.Collections.Generic;

namespace ConstructionCompanyAPI.ViewModels.Worksheets
{
    public class TaskVM
    {
        public TaskVM(Task task)
        {
            this.Id = task.Id;
            this.Title = task.Title;
            this.Description = task.Description;
            //this.WorkerIds = task.WorkerTasks;
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public List<int> WorkerIds { get; set; }

        //public List<Worker> Workers { get; set; }
    }
}
