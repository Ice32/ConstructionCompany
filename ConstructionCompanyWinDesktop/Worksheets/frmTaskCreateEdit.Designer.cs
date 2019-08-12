namespace ConstructionCompanyWinDesktop.Worksheets
{
    partial class frmTaskCreateEdit
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
            this.components = new System.ComponentModel.Container();
            this.lblTaskName = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.lblTaskWorkers = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listTaskWorkers = new System.Windows.Forms.ListBox();
            this.btnTaskSave = new System.Windows.Forms.Button();
            this.errorProviderTaskCreateEdit = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtTaskDescription = new System.Windows.Forms.TextBox();
            this.lblTaskDescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTaskCreateEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTaskName
            // 
            this.lblTaskName.AutoSize = true;
            this.lblTaskName.Location = new System.Drawing.Point(22, 23);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(66, 25);
            this.lblTaskName.TabIndex = 0;
            this.lblTaskName.Text = "Naziv";
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(178, 17);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(259, 31);
            this.txtTaskName.TabIndex = 1;
            this.txtTaskName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtTaskName_Validating);
            // 
            // lblTaskWorkers
            // 
            this.lblTaskWorkers.AutoSize = true;
            this.lblTaskWorkers.Location = new System.Drawing.Point(22, 92);
            this.lblTaskWorkers.Name = "lblTaskWorkers";
            this.lblTaskWorkers.Size = new System.Drawing.Size(84, 25);
            this.lblTaskWorkers.TabIndex = 2;
            this.lblTaskWorkers.Text = "Radnici";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // listTaskWorkers
            // 
            this.listTaskWorkers.FormattingEnabled = true;
            this.listTaskWorkers.ItemHeight = 25;
            this.listTaskWorkers.Location = new System.Drawing.Point(178, 92);
            this.listTaskWorkers.Name = "listTaskWorkers";
            this.listTaskWorkers.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listTaskWorkers.Size = new System.Drawing.Size(259, 104);
            this.listTaskWorkers.TabIndex = 4;
            this.listTaskWorkers.Validating += new System.ComponentModel.CancelEventHandler(this.ListTaskWorkers_Validating);
            // 
            // btnTaskSave
            // 
            this.btnTaskSave.Location = new System.Drawing.Point(178, 443);
            this.btnTaskSave.Name = "btnTaskSave";
            this.btnTaskSave.Size = new System.Drawing.Size(104, 37);
            this.btnTaskSave.TabIndex = 5;
            this.btnTaskSave.Text = "Spremi";
            this.btnTaskSave.UseVisualStyleBackColor = true;
            this.btnTaskSave.Click += new System.EventHandler(this.BtnTaskSave_Click);
            // 
            // errorProviderTaskCreateEdit
            // 
            this.errorProviderTaskCreateEdit.ContainerControl = this;
            // 
            // txtTaskDescription
            // 
            this.txtTaskDescription.Location = new System.Drawing.Point(178, 281);
            this.txtTaskDescription.Multiline = true;
            this.txtTaskDescription.Name = "txtTaskDescription";
            this.txtTaskDescription.Size = new System.Drawing.Size(259, 105);
            this.txtTaskDescription.TabIndex = 7;
            // 
            // lblTaskDescription
            // 
            this.lblTaskDescription.AutoSize = true;
            this.lblTaskDescription.Location = new System.Drawing.Point(22, 287);
            this.lblTaskDescription.Name = "lblTaskDescription";
            this.lblTaskDescription.Size = new System.Drawing.Size(56, 25);
            this.lblTaskDescription.TabIndex = 6;
            this.lblTaskDescription.Text = "Opis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "* preporučeni radnici";
            // 
            // frmTaskCreateEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 516);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTaskDescription);
            this.Controls.Add(this.lblTaskDescription);
            this.Controls.Add(this.btnTaskSave);
            this.Controls.Add(this.listTaskWorkers);
            this.Controls.Add(this.lblTaskWorkers);
            this.Controls.Add(this.txtTaskName);
            this.Controls.Add(this.lblTaskName);
            this.Name = "frmTaskCreateEdit";
            this.Text = "Zadatak";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTaskCreateEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Label lblTaskWorkers;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ListBox listTaskWorkers;
        private System.Windows.Forms.Button btnTaskSave;
        private System.Windows.Forms.ErrorProvider errorProviderTaskCreateEdit;
        private System.Windows.Forms.TextBox txtTaskDescription;
        private System.Windows.Forms.Label lblTaskDescription;
        private System.Windows.Forms.Label label1;
    }
}