namespace ConstructionCompanyWinDesktop
{
    partial class frmWorksheetsList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConstructionSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Workers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ConstructionSite,
            this.Remarks,
            this.Workers,
            this.Equipment});
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(0, 0);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersWidth = 82;
            this.dgvMain.RowTemplate.Height = 33;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(1512, 783);
            this.dgvMain.TabIndex = 1;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMain_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 10;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 200;
            // 
            // ConstructionSite
            // 
            this.ConstructionSite.DataPropertyName = "ConstructionSite";
            this.ConstructionSite.HeaderText = "Gradilište";
            this.ConstructionSite.MinimumWidth = 10;
            this.ConstructionSite.Name = "ConstructionSite";
            this.ConstructionSite.ReadOnly = true;
            this.ConstructionSite.Width = 200;
            // 
            // Remarks
            // 
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "Bilješke";
            this.Remarks.MinimumWidth = 10;
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            this.Remarks.Width = 200;
            // 
            // Workers
            // 
            this.Workers.DataPropertyName = "Workers";
            this.Workers.HeaderText = "Radnici";
            this.Workers.MinimumWidth = 10;
            this.Workers.Name = "Workers";
            this.Workers.ReadOnly = true;
            this.Workers.Width = 200;
            // 
            // Equipment
            // 
            this.Equipment.DataPropertyName = "Equipment";
            this.Equipment.HeaderText = "Oprema";
            this.Equipment.MinimumWidth = 10;
            this.Equipment.Name = "Equipment";
            this.Equipment.ReadOnly = true;
            this.Equipment.Width = 200;
            // 
            // frmWorksheetsList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1512, 783);
            this.Controls.Add(this.dgvMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmWorksheetsList";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConstructionSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Workers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipment;
    }
}

