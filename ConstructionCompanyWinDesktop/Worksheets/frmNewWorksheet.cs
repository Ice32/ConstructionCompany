using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.ConstructionSites;
using ConstructionCompanyModel.ViewModels.Tasks;
using ConstructionCompanyModel.ViewModels.Worksheets;
using ConstructionCompanyWinDesktop.Services;
using ConstructionCompanyWinDesktop.Util;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    public partial class frmNewWorksheet : Form
    {
        private readonly List<TaskAddVM> _tasks = new List<TaskAddVM> {
            new TaskAddVM()
        };
        private readonly List<WorksheetMaterialVM> _materials = new List<WorksheetMaterialVM> {
            new WorksheetMaterialVM()
        };
        private readonly List<WorksheetEquipmentVM> _equipment = new List<WorksheetEquipmentVM> {
            new WorksheetEquipmentVM()
        };

        private readonly WorksheetVM _originalWorksheet;

        private readonly APIService<WorksheetVM, WorksheetAddVM, WorksheetAddVM> _worksheetsService = new APIService<WorksheetVM, WorksheetAddVM, WorksheetAddVM>("worksheets");
        private readonly APIService<ConstructionSiteVM, ConstructionSiteAddVM, ConstructionSiteAddVM> _constructionSitesService = new APIService<ConstructionSiteVM, ConstructionSiteAddVM, ConstructionSiteAddVM>("constructionSites");
        private readonly Form _parent;

        public frmNewWorksheet(WorksheetVM worksheet = null, Form parent = null)
        {
            InitializeComponent();
            _parent = parent;
            if (worksheet != null)
            {
                _originalWorksheet = worksheet;
                _tasks = worksheet.Tasks.Select(task => new TaskAddVM
                    {
                        Id = task.Id,
                        Title = task.Title,
                        WorkerIds = task.Workers.Select(w => w.Id).ToList(),
                        Description = task.Description
                    })
                    .ToList();
                _materials = worksheet.Materials.Select(m => new WorksheetMaterialVM
                    {
                        MaterialId = m.Id,
                        Amount = m.Amount
                    })
                    .ToList();
                _equipment = worksheet.Equipment.Select(e => new WorksheetEquipmentVM
                {
                    EquipmentId = e.Id,
                    Quantity = e.Quantity
                })
                    .ToList();
                dtWorksheetDate.Value = worksheet.Date;
                lblWorksheetCreateEditHeader.Text = "Uredi radni list";
                txtWorksheetRemarks.Text = worksheet.Remarks;
            }

            LoadConstructionSites();

            userControlWorksheetTasks.SetTasks(_tasks);
            userControlWorksheetMaterials.SetMaterials(_materials);
            userControlWorksheetEquipment.SetEquipment(_equipment);
        }

        private async void LoadConstructionSites()
        {
            List<ConstructionSiteVM> constructionSites = await _constructionSitesService.GetAll();
            listWorksheetConstructionSite.DataSource = constructionSites.Select(cs => new ListBoxItem
            {
                Id = cs.Id,
                Name = cs.Title
            }).ToList();
            listWorksheetConstructionSite.DisplayMember = "Name";
            listWorksheetConstructionSite.ValueMember = "Id";
            if (_originalWorksheet?.ConstructionSite != null && _originalWorksheet.ConstructionSite.Id != 0)
            {
                listWorksheetConstructionSite.SelectedIndices.Clear();
                int indexInList = -1;
                for (var j = 0; j < listWorksheetConstructionSite.Items.Count; j++)
                {
                    if (((ListBoxItem) listWorksheetConstructionSite.Items[j]).Id == _originalWorksheet.ConstructionSite.Id)
                    {
                        indexInList = j;
                    }
                }

                if (indexInList != -1)
                {
                    listWorksheetConstructionSite.SelectedIndices.Add(indexInList);
                }
            }
        }

        private async void BtnSaveEditWorksheet_Click(object sender, EventArgs e)
        {
            WorksheetAddVM worksheet = new WorksheetAddVM
            {
                Date = dtWorksheetDate.Value,
                Tasks = _tasks.Where(t => t.Title != default).ToList(),
                Materials = _materials.Where(m => m.MaterialId != default).ToList(),
                Equipment = _equipment.Where(eq => eq.EquipmentId != default).ToList(),
                ConstructionSiteId = ((ListBoxItem)listWorksheetConstructionSite.SelectedItem).Id,
                Remarks = txtWorksheetRemarks.Text
            };
            if (_originalWorksheet != null)
            {
                worksheet.Id = _originalWorksheet.Id;
                await _worksheetsService.Update(_originalWorksheet.Id, worksheet);
            }
            else
            {
                await _worksheetsService.Create(worksheet);
            }
            Form listForm = new frmWorksheetsList { MdiParent = _parent, Dock = DockStyle.Fill, AutoSize = true};
            Close();
            listForm.Show();
        }
    }
}