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
            this.label3 = new System.Windows.Forms.Label();
            this.btnDodajZadatak = new System.Windows.Forms.Button();
            this.btnSaveEditWorksheet = new System.Windows.Forms.Button();
            this.listWorksheetConstructionSite = new System.Windows.Forms.ListBox();
            this.lblWorksheetConstructionSite = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.lblWorksheetCreateEditHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblWorksheetCreateEditHeader.Location = new System.Drawing.Point(701, 86);
            this.lblWorksheetCreateEditHeader.Name = "lblWorksheetCreateEditHeader";
            this.lblWorksheetCreateEditHeader.Size = new System.Drawing.Size(377, 55);
            this.lblWorksheetCreateEditHeader.TabIndex = 0;
            this.lblWorksheetCreateEditHeader.Text = "Novi radni list";
            this.lblWorksheetCreateEditHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(342, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Datum";
            this.dtWorksheetDate.Location = new System.Drawing.Point(608, 211);
            this.dtWorksheetDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtWorksheetDate.Name = "dtWorksheetDate";
            this.dtWorksheetDate.Size = new System.Drawing.Size(445, 39);
            this.dtWorksheetDate.TabIndex = 2;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "Zadaci";
            this.btnDodajZadatak.Location = new System.Drawing.Point(608, 396);
            this.btnDodajZadatak.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDodajZadatak.Name = "btnDodajZadatak";
            this.btnDodajZadatak.Size = new System.Drawing.Size(217, 60);
            this.btnDodajZadatak.TabIndex = 7;
            this.btnDodajZadatak.Text = "Dodaj zadatak";
            this.btnDodajZadatak.UseVisualStyleBackColor = true;
            this.btnDodajZadatak.Click += new System.EventHandler(this.BtnDodajZadatak_Click);
            this.btnSaveEditWorksheet.Location = new System.Drawing.Point(608, 860);
            this.btnSaveEditWorksheet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveEditWorksheet.Name = "btnSaveEditWorksheet";
            this.btnSaveEditWorksheet.Size = new System.Drawing.Size(155, 60);
            this.btnSaveEditWorksheet.TabIndex = 8;
            this.btnSaveEditWorksheet.Text = "Spremi";
            this.btnSaveEditWorksheet.UseVisualStyleBackColor = true;
            this.btnSaveEditWorksheet.Click += new System.EventHandler(this.BtnSaveEditWorksheet_Click);
            this.listWorksheetConstructionSite.FormattingEnabled = true;
            this.listWorksheetConstructionSite.ItemHeight = 32;
            this.listWorksheetConstructionSite.Location = new System.Drawing.Point(608, 579);
            this.listWorksheetConstructionSite.Name = "listWorksheetConstructionSite";
            this.listWorksheetConstructionSite.Size = new System.Drawing.Size(458, 100);
            this.listWorksheetConstructionSite.TabIndex = 9;
            this.lblWorksheetConstructionSite.Location = new System.Drawing.Point(342, 579);
            this.lblWorksheetConstructionSite.Name = "lblWorksheetConstructionSite";
            this.lblWorksheetConstructionSite.Size = new System.Drawing.Size(118, 41);
            this.lblWorksheetConstructionSite.TabIndex = 10;
            this.lblWorksheetConstructionSite.Text = "Gradilište";
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1765, 982);
            this.Controls.Add(this.lblWorksheetConstructionSite);
            this.Controls.Add(this.listWorksheetConstructionSite);
            this.Controls.Add(this.btnSaveEditWorksheet);
            this.Controls.Add(this.btnDodajZadatak);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtWorksheetDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblWorksheetCreateEditHeader);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmNewWorksheet";
            this.Text = "frmNewWorksheet";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblWorksheetCreateEditHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtWorksheetDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDodajZadatak;
        private System.Windows.Forms.ListBox listWorksheetConstructionSite;
        private System.Windows.Forms.Label lblWorksheetConstructionSite;
        private System.Windows.Forms.Button btnSaveEditWorksheet;
    }
}