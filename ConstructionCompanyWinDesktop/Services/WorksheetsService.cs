using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionCompanyWinDesktop.Util;
using ConstructionCompanyModel.ViewModels.Worksheets;

namespace ConstructionCompanyWinDesktop.Services
{
    public class WorksheetsService
    {
        private readonly APIClient _client = new APIClient("worksheets");

        public Task<List<WorksheetVM>> GetAllWorksheets()
        {
            return _client.Get<List<WorksheetVM>>();
        }
        
        public Task<WorksheetVM> CreateWorksheet(WorksheetAddVM worksheet)
        {
            return _client.Post<WorksheetVM>("", worksheet);
        }
        
        public Task<WorksheetVM> UpdateWorksheet(int id, WorksheetAddVM worksheet)
        {
            return _client.Post<WorksheetVM>($"/{id}", worksheet);
        }
    }
}
