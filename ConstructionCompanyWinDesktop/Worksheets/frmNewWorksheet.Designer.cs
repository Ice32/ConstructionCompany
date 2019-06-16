using System.ComponentModel;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    partial class frmNewWorksheet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.lblWorksheetCreateEditHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtWorksheetDate = new System.Windows.Forms.DateTimePicker();
            this.btnSaveEditWorksheet = new System.Windows.Forms.Button();
            this.listWorksheetConstructionSite = new System.Windows.Forms.ListBox();
            this.lblWorksheetConstructionSite = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.userControlWorksheetTasks = new ConstructionCompanyWinDesktop.Worksheets.worksheetTasksUserControl();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.userControlWorksheetMaterials =
                new ConstructionCompanyWinDesktop.Worksheets.worksheetMaterialsUserControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWorksheetCreateEditHeader
            // 
            this.lblWorksheetCreateEditHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblWorksheetCreateEditHeader.Location = new System.Drawing.Point(701, 86);
            this.lblWorksheetCreateEditHeader.Name = "lblWorksheetCreateEditHeader";
            this.lblWorksheetCreateEditHeader.Size = new System.Drawing.Size(377, 55);
            this.lblWorksheetCreateEditHeader.TabIndex = 0;
            this.lblWorksheetCreateEditHeader.Text = "Novi radni list";
            this.lblWorksheetCreateEditHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Datum";
            // 
            // dtWorksheetDate
            // 
            this.dtWorksheetDate.Location = new System.Drawing.Point(314, 50);
            this.dtWorksheetDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtWorksheetDate.Name = "dtWorksheetDate";
            this.dtWorksheetDate.Size = new System.Drawing.Size(445, 39);
            this.dtWorksheetDate.TabIndex = 2;
            // 
            // btnSaveEditWorksheet
            // 
            this.btnSaveEditWorksheet.Location = new System.Drawing.Point(3, 919);
            this.btnSaveEditWorksheet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveEditWorksheet.Name = "btnSaveEditWorksheet";
            this.btnSaveEditWorksheet.Size = new System.Drawing.Size(155, 60);
            this.btnSaveEditWorksheet.TabIndex = 8;
            this.btnSaveEditWorksheet.Text = "Spremi";
            this.btnSaveEditWorksheet.UseVisualStyleBackColor = true;
            this.btnSaveEditWorksheet.Click += new System.EventHandler(this.BtnSaveEditWorksheet_Click);
            // 
            // listWorksheetConstructionSite
            // 
            this.listWorksheetConstructionSite.FormattingEnabled = true;
            this.listWorksheetConstructionSite.ItemHeight = 32;
            this.listWorksheetConstructionSite.Location = new System.Drawing.Point(314, 59);
            this.listWorksheetConstructionSite.Name = "listWorksheetConstructionSite";
            this.listWorksheetConstructionSite.Size = new System.Drawing.Size(448, 100);
            this.listWorksheetConstructionSite.TabIndex = 9;
            // 
            // lblWorksheetConstructionSite
            // 
            this.lblWorksheetConstructionSite.Location = new System.Drawing.Point(24, 59);
            this.lblWorksheetConstructionSite.Name = "lblWorksheetConstructionSite";
            this.lblWorksheetConstructionSite.Size = new System.Drawing.Size(118, 41);
            this.lblWorksheetConstructionSite.TabIndex = 10;
            this.lblWorksheetConstructionSite.Text = "Gradilište";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtWorksheetDate);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 128);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.userControlWorksheetTasks);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(3, 140);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(859, 267);
            this.panel2.TabIndex = 14;
            // 
            // userControlWorksheetTasks
            // 
            this.userControlWorksheetTasks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.userControlWorksheetTasks.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.userControlWorksheetTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControlWorksheetTasks.Location = new System.Drawing.Point(314, 8);
            this.userControlWorksheetTasks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userControlWorksheetTasks.MinimumSize = new System.Drawing.Size(542, 255);
            this.userControlWorksheetTasks.Name = "userControlWorksheetTasks";
            this.userControlWorksheetTasks.Size = new System.Drawing.Size(542, 255);
            this.userControlWorksheetTasks.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 32);
            this.label3.TabIndex = 12;
            this.label3.Text = "Zadaci";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.panel1);
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Controls.Add(this.panel4);
            this.flowLayoutPanel2.Controls.Add(this.panel3);
            this.flowLayoutPanel2.Controls.Add(this.btnSaveEditWorksheet);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(517, 169);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1407, 1495);
            this.flowLayoutPanel2.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.userControlWorksheetMaterials);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(3, 415);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(859, 263);
            this.panel4.TabIndex = 16;
            // 
            // userControlWorksheetMaterials
            // 
            this.userControlWorksheetMaterials.AutoSize = true;
            this.userControlWorksheetMaterials.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.userControlWorksheetMaterials.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.userControlWorksheetMaterials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControlWorksheetMaterials.Location = new System.Drawing.Point(314, 4);
            this.userControlWorksheetMaterials.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userControlWorksheetMaterials.MinimumSize = new System.Drawing.Size(542, 255);
            this.userControlWorksheetMaterials.Name = "userControlWorksheetMaterials";
            this.userControlWorksheetMaterials.Size = new System.Drawing.Size(542, 255);
            this.userControlWorksheetMaterials.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Materijali";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblWorksheetConstructionSite);
            this.panel3.Controls.Add(this.listWorksheetConstructionSite);
            this.panel3.Location = new System.Drawing.Point(3, 686);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(776, 225);
            this.panel3.TabIndex = 15;
            // 
            // frmNewWorksheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1765, 1202);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.lblWorksheetCreateEditHeader);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmNewWorksheet";
            this.ShowInTaskbar = false;
            this.Text = "Novi radni list";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblWorksheetCreateEditHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtWorksheetDate;
        private System.Windows.Forms.ListBox listWorksheetConstructionSite;
        private System.Windows.Forms.Label lblWorksheetConstructionSite;
        private System.Windows.Forms.Button btnSaveEditWorksheet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ConstructionCompanyWinDesktop.Worksheets.worksheetTasksUserControl userControlWorksheetTasks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private ConstructionCompanyWinDesktop.Worksheets.worksheetMaterialsUserControl userControlWorksheetMaterials;
        private System.Windows.Forms.Label label1;
    }
}