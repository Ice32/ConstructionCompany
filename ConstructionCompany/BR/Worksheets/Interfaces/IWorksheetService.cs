using System.Collections.Generic;
using ConstructionCompanyDataLayer.Models;

namespace ConstructionCompany.BR.Worksheets.Interfaces
{
    public interface IWorksheetService
    {
        Worksheet AddWorksheet(Worksheet worksheet);
        void RemoveWorksheet(int worksheetId);
        Worksheet GetById(int id);
        List<Worksheet> GetAll();
    }
}
