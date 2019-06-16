using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Worksheets;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    public partial class worksheetMaterialsUserControl : UserControl
    {
        public worksheetMaterialsUserControl()
        {
            InitializeComponent();
        }
        private ListRenderer<WorksheetMaterialVM> _materialsRenderer;
        private List<WorksheetMaterialVM> _materials = new List<WorksheetMaterialVM>();


        public void SetMaterials(List<WorksheetMaterialVM> materials)
        {
            _materials = materials;
            RenderAddButton();
            _materialsRenderer = new ListRenderer<WorksheetMaterialVM>(ref _materials, panelWorksheetTasks.Controls, AddNewMaterialInput);
            Rerender();
        }

        private List<Control> AddNewMaterialInput(WorksheetMaterialVM material, int i, Action rerenderTaskInputs)
        {
            var worksheetTaskUserControl = new worksheetMaterialUserControl(
                    material,
                    Rerender,
                    (sender, args) =>
                    {
                        _materials.Remove(material);
                        Rerender();
                    }
                );
            
            return new List<Control>{ worksheetTaskUserControl };
        }

        private void RenderAddButton()
        {
            btnAddMaterial.Click += (object sender, EventArgs e) =>
            {
                _materials.Add(new WorksheetMaterialVM());
            
                Rerender();
            };
        }

        private void Rerender()
        {
            _materialsRenderer.RerenderInputs();
        }
    }
}
