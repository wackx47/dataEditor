namespace dataEditor
{
    partial class bankDictionary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bankDictionary));
            this.dictLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridBanksList = new System.Windows.Forms.DataGridView();
            this.urToolStrip = new System.Windows.Forms.ToolStrip();
            this.dictBankBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.dictBankBtnSave = new System.Windows.Forms.ToolStripButton();
            this.dictBankBtnShowFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dictBankBtnAddElm = new System.Windows.Forms.ToolStripButton();
            this.dictBankBtnDelElm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.dictBankBtnImportFromExcel = new System.Windows.Forms.ToolStripButton();
            this.dictBankBtnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.dictBankID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dictBankNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dictBankBIK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dictBankCorrAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dictBankINN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dictLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBanksList)).BeginInit();
            this.urToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dictLayoutPanel
            // 
            this.dictLayoutPanel.ColumnCount = 1;
            this.dictLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dictLayoutPanel.Controls.Add(this.dataGridBanksList, 0, 1);
            this.dictLayoutPanel.Controls.Add(this.urToolStrip, 0, 0);
            this.dictLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dictLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.dictLayoutPanel.Name = "dictLayoutPanel";
            this.dictLayoutPanel.RowCount = 2;
            this.dictLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.dictLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dictLayoutPanel.Size = new System.Drawing.Size(684, 450);
            this.dictLayoutPanel.TabIndex = 5;
            // 
            // dataGridBanksList
            // 
            this.dataGridBanksList.AllowUserToAddRows = false;
            this.dataGridBanksList.AllowUserToResizeRows = false;
            this.dataGridBanksList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridBanksList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridBanksList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridBanksList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridBanksList.ColumnHeadersHeight = 25;
            this.dataGridBanksList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridBanksList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dictBankID,
            this.dictBankNAME,
            this.dictBankBIK,
            this.dictBankCorrAcc,
            this.dictBankINN});
            this.dataGridBanksList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridBanksList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridBanksList.EnableHeadersVisualStyles = false;
            this.dataGridBanksList.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridBanksList.Location = new System.Drawing.Point(3, 28);
            this.dataGridBanksList.Name = "dataGridBanksList";
            this.dataGridBanksList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridBanksList.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridBanksList.RowHeadersWidth = 20;
            this.dataGridBanksList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridBanksList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridBanksList.RowTemplate.Height = 20;
            this.dataGridBanksList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridBanksList.Size = new System.Drawing.Size(678, 419);
            this.dataGridBanksList.TabIndex = 0;
            // 
            // urToolStrip
            // 
            this.urToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dictBankBtnOpen,
            this.dictBankBtnSave,
            this.dictBankBtnShowFolder,
            this.toolStripSeparator1,
            this.dictBankBtnAddElm,
            this.dictBankBtnDelElm,
            this.toolStripSeparator3,
            this.dictBankBtnImportFromExcel,
            this.dictBankBtnExportToExcel,
            this.toolStripSeparator4});
            this.urToolStrip.Location = new System.Drawing.Point(0, 0);
            this.urToolStrip.Name = "urToolStrip";
            this.urToolStrip.Size = new System.Drawing.Size(684, 25);
            this.urToolStrip.TabIndex = 77;
            this.urToolStrip.Text = "mgTools";
            // 
            // dictBankBtnOpen
            // 
            this.dictBankBtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dictBankBtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("dictBankBtnOpen.Image")));
            this.dictBankBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dictBankBtnOpen.Name = "dictBankBtnOpen";
            this.dictBankBtnOpen.Size = new System.Drawing.Size(23, 22);
            this.dictBankBtnOpen.Text = "OpenFile";
            // 
            // dictBankBtnSave
            // 
            this.dictBankBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dictBankBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("dictBankBtnSave.Image")));
            this.dictBankBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dictBankBtnSave.Name = "dictBankBtnSave";
            this.dictBankBtnSave.Size = new System.Drawing.Size(23, 22);
            this.dictBankBtnSave.Text = "Save";
            this.dictBankBtnSave.Click += new System.EventHandler(this.dictBankBtnSave_Click);
            // 
            // dictBankBtnShowFolder
            // 
            this.dictBankBtnShowFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dictBankBtnShowFolder.Image = ((System.Drawing.Image)(resources.GetObject("dictBankBtnShowFolder.Image")));
            this.dictBankBtnShowFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dictBankBtnShowFolder.Name = "dictBankBtnShowFolder";
            this.dictBankBtnShowFolder.Size = new System.Drawing.Size(23, 22);
            this.dictBankBtnShowFolder.Text = "Show in Windows";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // dictBankBtnAddElm
            // 
            this.dictBankBtnAddElm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dictBankBtnAddElm.Image = ((System.Drawing.Image)(resources.GetObject("dictBankBtnAddElm.Image")));
            this.dictBankBtnAddElm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dictBankBtnAddElm.Name = "dictBankBtnAddElm";
            this.dictBankBtnAddElm.Size = new System.Drawing.Size(23, 22);
            this.dictBankBtnAddElm.Text = "Add Element";
            this.dictBankBtnAddElm.Click += new System.EventHandler(this.dictBankBtnAddElm_Click);
            // 
            // dictBankBtnDelElm
            // 
            this.dictBankBtnDelElm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dictBankBtnDelElm.Image = ((System.Drawing.Image)(resources.GetObject("dictBankBtnDelElm.Image")));
            this.dictBankBtnDelElm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dictBankBtnDelElm.Name = "dictBankBtnDelElm";
            this.dictBankBtnDelElm.Size = new System.Drawing.Size(23, 22);
            this.dictBankBtnDelElm.Text = "Remove Element";
            this.dictBankBtnDelElm.Click += new System.EventHandler(this.dictBankBtnDelElm_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // dictBankBtnImportFromExcel
            // 
            this.dictBankBtnImportFromExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dictBankBtnImportFromExcel.Image = ((System.Drawing.Image)(resources.GetObject("dictBankBtnImportFromExcel.Image")));
            this.dictBankBtnImportFromExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dictBankBtnImportFromExcel.Name = "dictBankBtnImportFromExcel";
            this.dictBankBtnImportFromExcel.Size = new System.Drawing.Size(23, 22);
            this.dictBankBtnImportFromExcel.Text = "ImportFromExcel";
            // 
            // dictBankBtnExportToExcel
            // 
            this.dictBankBtnExportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dictBankBtnExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("dictBankBtnExportToExcel.Image")));
            this.dictBankBtnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dictBankBtnExportToExcel.Name = "dictBankBtnExportToExcel";
            this.dictBankBtnExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.dictBankBtnExportToExcel.Text = "CreateExcel";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // dictBankID
            // 
            this.dictBankID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dictBankID.HeaderText = "id";
            this.dictBankID.Name = "dictBankID";
            this.dictBankID.ReadOnly = true;
            this.dictBankID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dictBankID.Width = 40;
            // 
            // dictBankNAME
            // 
            this.dictBankNAME.FillWeight = 14.87603F;
            this.dictBankNAME.HeaderText = "bankName";
            this.dictBankNAME.Name = "dictBankNAME";
            this.dictBankNAME.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dictBankBIK
            // 
            this.dictBankBIK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dictBankBIK.HeaderText = "BIK";
            this.dictBankBIK.Name = "dictBankBIK";
            this.dictBankBIK.Width = 50;
            // 
            // dictBankCorrAcc
            // 
            this.dictBankCorrAcc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dictBankCorrAcc.HeaderText = "corrAcc";
            this.dictBankCorrAcc.Name = "dictBankCorrAcc";
            this.dictBankCorrAcc.Width = 77;
            // 
            // dictBankINN
            // 
            this.dictBankINN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dictBankINN.HeaderText = "INN";
            this.dictBankINN.Name = "dictBankINN";
            this.dictBankINN.Width = 50;
            // 
            // bankDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 450);
            this.Controls.Add(this.dictLayoutPanel);
            this.Name = "bankDictionary";
            this.Text = "bankDictionary";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.bankDictionary_FormClosing);
            this.dictLayoutPanel.ResumeLayout(false);
            this.dictLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBanksList)).EndInit();
            this.urToolStrip.ResumeLayout(false);
            this.urToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel dictLayoutPanel;
        public DataGridView dataGridBanksList;
        private ToolStrip urToolStrip;
        private ToolStripButton dictBankBtnOpen;
        private ToolStripButton dictBankBtnSave;
        private ToolStripButton dictBankBtnShowFolder;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton dictBankBtnAddElm;
        private ToolStripButton dictBankBtnDelElm;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton dictBankBtnImportFromExcel;
        private ToolStripButton dictBankBtnExportToExcel;
        private ToolStripSeparator toolStripSeparator4;
        private DataGridViewTextBoxColumn dictBankID;
        private DataGridViewTextBoxColumn dictBankNAME;
        private DataGridViewTextBoxColumn dictBankBIK;
        private DataGridViewTextBoxColumn dictBankCorrAcc;
        private DataGridViewTextBoxColumn dictBankINN;
    }
}