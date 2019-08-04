using System.Collections.Generic;
using ConstructionCompanyModel.ViewModels.Workers;
using ConstructionCompanyModel.ViewModels.Worksheets;

namespace ConstructionCompanyModel.ViewModels.Tasks
{
    public class TaskVM
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public List<WorkerVM> Workers { get; set; }

        public WorksheetVM Worksheet { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as TaskVM;

            if (item == null)
            {
                return false;
            }

            return this.Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
