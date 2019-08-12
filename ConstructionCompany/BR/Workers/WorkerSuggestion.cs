using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Workers
{
    public class WorkerSuggestion
    {
        public Task Task { get; set; }
        public Worker Worker { get; set; }
        public float Compatibility { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as WorkerSuggestion;

            if (item == null)
            {
                return false;
            }

            return Task.Id.Equals(item.Task.Id) && Worker.Id.Equals(item.Worker.Id);
        }
    }
}
