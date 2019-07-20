﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Workers;
using ConstructionCompanyModel.ViewModels.Worksheets;
using ConstructionCompanyWinDesktop.Services;
using ConstructionCompanyWinDesktop.Worksheets;

namespace ConstructionCompanyWinDesktop
{
    public partial class frmWorksheetsList : Form
    {
        private readonly APIService<WorksheetVM, WorksheetAddVM, WorksheetAddVM> _worksheetsService = new APIService<WorksheetVM, WorksheetAddVM, WorksheetAddVM>("worksheets");
        private List<WorksheetVM> _worksheets;

        public frmWorksheetsList()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            _worksheets = await _worksheetsService.GetAll();
            var mappedResults = _worksheets.Select(w =>
            {
                List<WorkerVM> workers = w.Tasks.SelectMany(t => t.Workers).Distinct().ToList();
                return new
                {
                    ConstructionSite = w.ConstructionSite.Title,
                    Equipment = w.Equipment != null ? string.Join(", ", w.Equipment.Select(e => e.Name)) : "",
                    Workers = string.Join(", ",workers.Select(worker => worker.User.FirstName + ' ' + worker.User.LastName)),
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
            worksheetForm.Show();
        }
    }
}
