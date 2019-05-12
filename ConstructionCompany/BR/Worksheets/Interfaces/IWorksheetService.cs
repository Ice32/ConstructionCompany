using DataLayer.Models;

namespace ConstructionCompanyAPI.BR.Worksheets.Interfaces
{
    public interface IWorksheetService
    {
        Worksheet AddWorksheet(Worksheet worksheet);
        void RemoveWorksheet(int worksheetId);
        void CompleteWorksheet(int worksheetId);
    }
}
