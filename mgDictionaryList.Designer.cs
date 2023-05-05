using System.Windows.Forms;

namespace dataEditor
{
    partial class mgDatsList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mgDatsList));
            this.mgRightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mgMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridDictionaryList = new System.Windows.Forms.DataGridView();
            this.Agreement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateAgreement = new dataEditor.mgDatsList.CalendarColumn();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DocTC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewLinkColumn();
            this.TimeZone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PWR = new dataEditor.NumericUpDownDataGrid.NumericUpDownColumn();
            this.Extra1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Extra2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Extra3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Extra4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dictLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.urToolStrip = new System.Windows.Forms.ToolStrip();
            this.dictBtnSave = new System.Windows.Forms.ToolStripButton();
            this.dictBtnShowFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dictBtnAddElm = new System.Windows.Forms.ToolStripButton();
            this.dictBtnDelElm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dictListGTP = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.dictBtnImportFromExcel = new System.Windows.Forms.ToolStripButton();
            this.dictBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.mgRightClickMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDictionaryList)).BeginInit();
            this.dictLayoutPanel.SuspendLayout();
            this.urToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mgRightClickMenu
            // 
            this.mgRightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mgMenuDelete});
            this.mgRightClickMenu.Name = "mgRightClickMenu";
            this.mgRightClickMenu.Size = new System.Drawing.Size(183, 26);
            // 
            // mgMenuDelete
            // 
            this.mgMenuDelete.Name = "mgMenuDelete";
            this.mgMenuDelete.Size = new System.Drawing.Size(182, 22);
            this.mgMenuDelete.Text = "Remove Contractors";
            this.mgMenuDelete.Click += new System.EventHandler(this.RemoveContractors_Click);
            // 
            // dataGridDictionaryList
            // 
            this.dataGridDictionaryList.AllowUserToAddRows = false;
            this.dataGridDictionaryList.AllowUserToResizeRows = false;
            this.dataGridDictionaryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridDictionaryList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridDictionaryList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridDictionaryList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridDictionaryList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDictionaryList.ColumnHeadersHeight = 30;
            this.dataGridDictionaryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridDictionaryList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Agreement,
            this.DateAgreement,
            this.Type,
            this.DocTC,
            this.FullName,
            this.INN,
            this.Address,
            this.NumCC,
            this.PhoneNumber,
            this.Mail,
            this.TimeZone,
            this.Status,
            this.PWR,
            this.Extra1,
            this.Extra2,
            this.Extra3,
            this.Extra4});
            this.dataGridDictionaryList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridDictionaryList.EnableHeadersVisualStyles = false;
            this.dataGridDictionaryList.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridDictionaryList.Location = new System.Drawing.Point(3, 28);
            this.dataGridDictionaryList.Name = "dataGridDictionaryList";
            this.dataGridDictionaryList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridDictionaryList.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDictionaryList.RowHeadersWidth = 20;
            this.dataGridDictionaryList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridDictionaryList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridDictionaryList.RowTemplate.Height = 20;
            this.dataGridDictionaryList.Size = new System.Drawing.Size(1151, 589);
            this.dataGridDictionaryList.TabIndex = 0;
            this.dataGridDictionaryList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridDictionary_EditingControlShowing);
            // 
            // Agreement
            // 
            this.Agreement.HeaderText = "agreement";
            this.Agreement.Name = "Agreement";
            this.Agreement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DateAgreement
            // 
            this.DateAgreement.HeaderText = "date";
            this.DateAgreement.Name = "DateAgreement";
            // 
            // Type
            // 
            this.Type.HeaderText = "type";
            this.Type.Items.AddRange(new object[] {
            "ФЗ",
            "ЮЛ"});
            this.Type.MaxDropDownItems = 2;
            this.Type.Name = "Type";
            // 
            // DocTC
            // 
            this.DocTC.HeaderText = "atp";
            this.DocTC.Name = "DocTC";
            this.DocTC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FullName
            // 
            this.FullName.HeaderText = "name";
            this.FullName.Name = "FullName";
            this.FullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // INN
            // 
            this.INN.HeaderText = "inn";
            this.INN.Name = "INN";
            this.INN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.INN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Address
            // 
            this.Address.HeaderText = "accAddress";
            this.Address.Name = "Address";
            this.Address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NumCC
            // 
            this.NumCC.HeaderText = "numberCounter";
            this.NumCC.Name = "NumCC";
            this.NumCC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.HeaderText = "phoneNumber";
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PhoneNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Mail
            // 
            this.Mail.HeaderText = "mail";
            this.Mail.Name = "Mail";
            this.Mail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Mail.TrackVisitedState = false;
            // 
            // TimeZone
            // 
            this.TimeZone.HeaderText = "typeCounter";
            this.TimeZone.Name = "TimeZone";
            this.TimeZone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Status
            // 
            this.Status.HeaderText = "status";
            this.Status.Items.AddRange(new object[] {
            "Действует",
            "Расторгнут"});
            this.Status.Name = "Status";
            // 
            // PWR
            // 
            this.PWR.HeaderText = "Pmax";
            this.PWR.Name = "PWR";
            // 
            // Extra1
            // 
            this.Extra1.HeaderText = "#1";
            this.Extra1.Name = "Extra1";
            this.Extra1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Extra1.Visible = false;
            // 
            // Extra2
            // 
            this.Extra2.HeaderText = "#2";
            this.Extra2.Name = "Extra2";
            this.Extra2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Extra2.Visible = false;
            // 
            // Extra3
            // 
            this.Extra3.HeaderText = "#3";
            this.Extra3.Name = "Extra3";
            this.Extra3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Extra3.Visible = false;
            // 
            // Extra4
            // 
            this.Extra4.HeaderText = "#4";
            this.Extra4.Name = "Extra4";
            this.Extra4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Extra4.Visible = false;
            // 
            // dictLayoutPanel
            // 
            this.dictLayoutPanel.ColumnCount = 1;
            this.dictLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dictLayoutPanel.Controls.Add(this.dataGridDictionaryList, 0, 1);
            this.dictLayoutPanel.Controls.Add(this.urToolStrip, 0, 0);
            this.dictLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dictLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.dictLayoutPanel.Name = "dictLayoutPanel";
            this.dictLayoutPanel.RowCount = 2;
            this.dictLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.dictLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 530F));
            this.dictLayoutPanel.Size = new System.Drawing.Size(1157, 620);
            this.dictLayoutPanel.TabIndex = 4;
            // 
            // urToolStrip
            // 
            this.urToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dictBtnOpen,
            this.dictBtnImportFromExcel,
            this.dictBtnSave,
            this.dictBtnShowFolder,
            this.toolStripSeparator2,
            this.dictBtnAddElm,
            this.dictBtnDelElm,
            this.toolStripSeparator1,
            this.dictListGTP,
            this.toolStripSeparator3});
            this.urToolStrip.Location = new System.Drawing.Point(0, 0);
            this.urToolStrip.Name = "urToolStrip";
            this.urToolStrip.Size = new System.Drawing.Size(1157, 25);
            this.urToolStrip.TabIndex = 77;
            this.urToolStrip.Text = "mgTools";
            // 
            // dictBtnSave
            // 
            this.dictBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dictBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("dictBtnSave.Image")));
            this.dictBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dictBtnSave.Name = "dictBtnSave";
            this.dictBtnSave.Size = new System.Drawing.Size(23, 22);
            this.dictBtnSave.Text = "Save";
            this.dictBtnSave.Click += new System.EventHandler(this.dictBtnSave_Click);
            // 
            // dictBtnShowFolder
            // 
            this.dictBtnShowFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dictBtnShowFolder.Image = ((System.Drawing.Image)(resources.GetObject("dictBtnShowFolder.Image")));
            this.dictBtnShowFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dictBtnShowFolder.Name = "dictBtnShowFolder";
            this.dictBtnShowFolder.Size = new System.Drawing.Size(23, 22);
            this.dictBtnShowFolder.Text = "Show in Windows";
            this.dictBtnShowFolder.Click += new System.EventHandler(this.dictBtnShowFolder_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // dictBtnAddElm
            // 
            this.dictBtnAddElm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dictBtnAddElm.Image = ((System.Drawing.Image)(resources.GetObject("dictBtnAddElm.Image")));
            this.dictBtnAddElm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dictBtnAddElm.Name = "dictBtnAddElm";
            this.dictBtnAddElm.Size = new System.Drawing.Size(23, 22);
            this.dictBtnAddElm.Text = "Add Element";
            this.dictBtnAddElm.Click += new System.EventHandler(this.dictBtnAddElm_Click);
            // 
            // dictBtnDelElm
            // 
            this.dictBtnDelElm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dictBtnDelElm.Image = ((System.Drawing.Image)(resources.GetObject("dictBtnDelElm.Image")));
            this.dictBtnDelElm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dictBtnDelElm.Name = "dictBtnDelElm";
            this.dictBtnDelElm.Size = new System.Drawing.Size(23, 22);
            this.dictBtnDelElm.Text = "Remove Element";
            this.dictBtnDelElm.Click += new System.EventHandler(this.dictBtnDelElm_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // dictListGTP
            // 
            this.dictListGTP.Items.AddRange(new object[] {
            "KUBANESK"});
            this.dictListGTP.Name = "dictListGTP";
            this.dictListGTP.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // dictBtnImportFromExcel
            // 
            this.dictBtnImportFromExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dictBtnImportFromExcel.Image = ((System.Drawing.Image)(resources.GetObject("dictBtnImportFromExcel.Image")));
            this.dictBtnImportFromExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dictBtnImportFromExcel.Name = "dictBtnImportFromExcel";
            this.dictBtnImportFromExcel.Size = new System.Drawing.Size(23, 22);
            this.dictBtnImportFromExcel.Text = "ImportFromExcel";
            // 
            // dictBtnOpen
            // 
            this.dictBtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dictBtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("dictBtnOpen.Image")));
            this.dictBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dictBtnOpen.Name = "dictBtnOpen";
            this.dictBtnOpen.Size = new System.Drawing.Size(23, 22);
            this.dictBtnOpen.Text = "ImportFile";
            this.dictBtnOpen.Click += new System.EventHandler(this.dictBtnOpen_ButtonClick);
            // 
            // mgDatsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 620);
            this.Controls.Add(this.dictLayoutPanel);
            this.Name = "mgDatsList";
            this.Text = "DatsEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mgDatsList_FormClosing);
            this.Load += new System.EventHandler(this.mgDatsEditor_Load);
            this.mgRightClickMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDictionaryList)).EndInit();
            this.dictLayoutPanel.ResumeLayout(false);
            this.dictLayoutPanel.PerformLayout();
            this.urToolStrip.ResumeLayout(false);
            this.urToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ContextMenuStrip mgRightClickMenu;
        private ToolStripMenuItem mgMenuDelete;
        private CalendarColumn DateIntoForce;
        private DataGridView dataGridDictionaryList;
        private TableLayoutPanel dictLayoutPanel;
        private ToolStrip urToolStrip;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton dictBtnSave;
        private ToolStripButton dictBtnShowFolder;
        private ToolStripButton dictBtnAddElm;
        private ToolStripButton dictBtnDelElm;
        public ToolStripComboBox dictListGTP;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator3;
        private DataGridViewTextBoxColumn Agreement;
        private CalendarColumn DateAgreement;
        private DataGridViewComboBoxColumn Type;
        private DataGridViewTextBoxColumn DocTC;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn INN;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn NumCC;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewLinkColumn Mail;
        private DataGridViewTextBoxColumn TimeZone;
        private DataGridViewComboBoxColumn Status;
        private NumericUpDownDataGrid.NumericUpDownColumn PWR;
        private DataGridViewTextBoxColumn Extra1;
        private DataGridViewTextBoxColumn Extra2;
        private DataGridViewTextBoxColumn Extra3;
        private DataGridViewTextBoxColumn Extra4;
        private ToolStripButton dictBtnOpen;
        private ToolStripButton dictBtnImportFromExcel;
    }
}