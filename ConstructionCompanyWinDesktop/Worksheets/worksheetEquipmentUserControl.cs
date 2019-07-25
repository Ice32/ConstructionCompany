using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConstructionCompanyModel.ViewModels.Worksheets;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    public partial class worksheetEquipmentUserControl : UserControl
    {
        public worksheetEquipmentUserControl()
        {
            InitializeComponent();
        }
        private ListRenderer<WorksheetEquipmentVM> _equipmentRenderer;
        private List<WorksheetEquipmentVM> _equipment = new List<WorksheetEquipmentVM>();


        public void SetEquipment(List<WorksheetEquipmentVM> equipment)
        {
            _equipment = equipment;
            RenderAddButton();
            _equipmentRenderer = new ListRenderer<WorksheetEquipmentVM>(ref _equipment, panelWorksheetTasks.Controls, AddNewEquipmentInput);
            Rerender();
        }

        private List<Control> AddNewEquipmentInput(WorksheetEquipmentVM equipment, int i, Action rerenderTaskInputs)
        {
            var worksheetTaskUserControl = new worksheetEquipmentItemUserControl(
                    equipment,
                    Rerender,
                    (sender, args) =>
                    {
                        _equipment.Remove(equipment);
                        Rerender();
                    }
                );
            
            return new List<Control>{ worksheetTaskUserControl };
        }

        private void RenderAddButton()
        {
            btnAddMaterial.Click += (object sender, EventArgs e) =>
            {
                _equipment.Add(new WorksheetEquipmentVM());
            
                Rerender();
            };
        }

        private void Rerender()
        {
            _equipmentRenderer.RerenderInputs();
        }
    }
}
