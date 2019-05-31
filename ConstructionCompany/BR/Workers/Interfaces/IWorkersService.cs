using System.Collections.Generic;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Workers.Interfaces
{
    public interface IWorkersService
    {
        List<Worker> GetAll();
    }
}
