﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Workers;
using ConstructionCompanyWinDesktop.Services;

namespace ConstructionCompanyWinDesktop.Users
{
    public partial class frmWorkersList : Form
    {
        private readonly APIService<WorkerVM, WorkerAddVM, WorkerAddVM> _workersService = new APIService<WorkerVM, WorkerAddVM, WorkerAddVM>("workers");
        private List<WorkerVM> _workers;
        private string _nameSearch = "";
        public frmWorkersList()
        {
            InitializeComponent();
            LoadData();
        }
        
        private async void LoadData()
        {
            var search = new Dictionary<string, string>();
            if (_nameSearch != default)
            {
                search.Add("Name", _nameSearch);
            }

            _workers = await _workersService.GetAll(search);
            var mappedResults = _workers.Select(u => new
            {
                u.Id,
                u.User.FullName,
                u.User.UserName
            }).ToList();
            dgvUsersList.DataSource = mappedResults;
        }


        private void DgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (DataGridView)sender;

            if (e.RowIndex == -1)
            {
                return;
            }
            var selectedId = (int)dataGridView.Rows[e.RowIndex].Cells["Id"].Value;
            WorkerVM worker = _workers.First(w => w.Id == selectedId);
            var editForm = new frmNewWorker(worker, MdiParent);
            editForm.Show();
        }

        private void TextBox1_TextChanged(object sender, System.EventArgs e)
        {
            _nameSearch = ((TextBox)sender).Text;
            LoadData();
        }
    }
}