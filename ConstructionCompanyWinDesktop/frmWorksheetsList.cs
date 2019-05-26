using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Worksheets;
using ConstructionCompanyWinDesktop.Services;


namespace ConstructionCompanyWinDesktop
{
    public partial class frmWorksheetsList : Form
    {
        private readonly WorksheetsService _worksheetsService;

        public frmWorksheetsList()
        {
            InitializeComponent();
            _worksheetsService = new WorksheetsService();
            LoadData();
        }

        private async void LoadData()
        {
            List<WorksheetVM> results = await _worksheetsService.GetAllWorksheets();
            var mappedResults = results.Select(w => new
            {
                ConstructionSite = w.ConstructionSite.Title,
                Equipment = w.Equipment != null ? string.Join(", ", w.Equipment.Select(e => e.Name)) : "",
                Workers = w.Workers != null ? string.Join(", ", w.Workers.Select(worker => worker.FirstName + ' ' + worker.LastName)) : "",
                w.Remarks,
                w.Date,
            }).ToList();
            dgvMain.DataSource = mappedResults;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
