using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.ConstructionSites;
using ConstructionCompanyModel.ViewModels.Workers;
using ConstructionCompanyModel.ViewModels.Worksheets;
using ConstructionCompanyWinDesktop.Services;
using ConstructionCompanyWinDesktop.Worksheets;

namespace ConstructionCompanyWinDesktop
{
    public partial class frmWorksheetsList : Form
    {
        private readonly APIService<WorksheetVM, WorksheetAddVM, WorksheetAddVM> _worksheetsService = new APIService<WorksheetVM, WorksheetAddVM, WorksheetAddVM>("worksheets");
        private readonly APIService<ConstructionSiteVM, ConstructionSiteAddVM, ConstructionSiteAddVM> _constructionSitesService = new APIService<ConstructionSiteVM, ConstructionSiteAddVM, ConstructionSiteAddVM>("constructionSites");
        private List<WorksheetVM> _worksheets;
        private int _selectedConstructionSiteId;
        private DateTime _selectedDate;

        public frmWorksheetsList()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            List<ConstructionSiteVM> constructionSites = await _constructionSitesService.GetAll();
            cmbConstructionSites.DataSource = constructionSites;
            cmbConstructionSites.DisplayMember = "Title";
            cmbConstructionSites.ValueMember = "Id";
            cmbConstructionSites.SelectedIndex = -1;
            cmbConstructionSites.Text = "Gradilište";

            //cmbConstructionSites.SelectedValue = _material.MaterialId;
            cmbConstructionSites.SelectedIndexChanged += (sender, args) =>
            {
                int selectedConstructionSiteId = (int)cmbConstructionSites.SelectedValue;
                _selectedConstructionSiteId = selectedConstructionSiteId;
                LoadWorksheets();
            };

            dtWorksheetDate.ValueChanged += (sender, args) =>
            {
                DateTime selectedValue = (DateTime)dtWorksheetDate.Value;
                _selectedDate = selectedValue;
                LoadWorksheets();
            };

            LoadWorksheets();
        }

        private async void LoadWorksheets()
        {
            var search = new Dictionary<string, string>();
            if (_selectedConstructionSiteId != default)
            {
                search.Add("constructionSiteId", _selectedConstructionSiteId.ToString());
            }

            if (_selectedDate != default)
            {
                search.Add("date", _selectedDate.ToString());
            }


            _worksheets = await _worksheetsService.GetAll(search);
            var mappedResults = _worksheets.Select(w =>
            {
                List<WorkerVM> workers = w.Tasks.SelectMany(t => t.Workers).Distinct().ToList();
                return new
                {
                    ConstructionSite = w.ConstructionSite.Title,
                    Equipment = w.Equipment != null ? string.Join(", ", w.Equipment.Select(e => e.Name)) : "",
                    Workers = string.Join(", ", workers.Select(worker => worker.User.FirstName + ' ' + worker.User.LastName)),
                    w.Remarks,
                    w.Date,
                    w.Id,
                };
            }).ToList();
            dgvMain.DataSource = mappedResults;
        }


        private void DgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            if (e.RowIndex == -1)
            {
                return;
            }
            int selectedId = (int)dataGridView.Rows[e.RowIndex].Cells["Id"].Value;
            WorksheetVM worksheet = _worksheets.FirstOrDefault(w => w.Id == selectedId);
            frmNewWorksheet worksheetForm = new frmNewWorksheet(worksheet, MdiParent);
            worksheetForm.StartPosition = FormStartPosition.CenterScreen;
            worksheetForm.Show();
        }
    }
}
