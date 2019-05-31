using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Worksheets.Interfaces
{
    public interface ITasksService
    {
        Task AddTask(Task task);
        Task GetById(int id);
    }
}
