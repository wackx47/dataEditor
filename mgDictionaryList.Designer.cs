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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mgDatsList));
            this.mgRightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mgMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mgLocalPhone = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridDictionaryList = new dataEditor.MainForm.DoubleBufferedDataGridView();
            this.editLink = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Agreement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateAgreement = new dataEditor.mgDatsList.CalendarColumn();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DocTC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new dataEditor.mgDatsList.MaskedEditColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TariffZone = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PWR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankNAME = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.KPP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankPayAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankBIK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankINN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankCorrAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Extra1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Extra2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Extra3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Extra4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dictLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.urToolStrip = new System.Windows.Forms.ToolStrip();
            this.dictBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.dictBtnSave = new System.Windows.Forms.ToolStripButton();
            this.dictBtnShowFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dictListGTP = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dictBtnAddElm = new System.Windows.Forms.ToolStripButton();
            this.dictBtnDelElm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.dictBtnImportFromExcel = new System.Windows.Forms.ToolStripButton();
            this.dictBtnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.dictBtnBankData = new System.Windows.Forms.ToolStripButton();
            this.mgRightClickMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDictionaryList)).BeginInit();
            this.dictLayoutPanel.SuspendLayout();
            this.urToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mgRightClickMenu
            // 
            this.mgRightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mgMenuDelete,
            this.mgLocalPhone});
            this.mgRightClickMenu.Name = "mgRightClickMenu";
            this.mgRightClickMenu.Size = new System.Drawing.Size(183, 48);
            // 
            // mgMenuDelete
            // 
            this.mgMenuDelete.Name = "mgMenuDelete";
            this.mgMenuDelete.Size = new System.Drawing.Size(182, 22);
            this.mgMenuDelete.Text = "Remove Contractors";
            this.mgMenuDelete.Click += new System.EventHandler(this.RemoveContractors_Click);
            // 
            // mgLocalPhone
            // 
            this.mgLocalPhone.Name = "mgLocalPhone";
            this.mgLocalPhone.Size = new System.Drawing.Size(182, 22);
            this.mgLocalPhone.Text = "LocalPhoneNumber";
            this.mgLocalPhone.Visible = false;
            this.mgLocalPhone.Click += new System.EventHandler(this.mgLocalPhone_Click);
            // 
            // dataGridDictionaryList
            // 
            this.dataGridDictionaryList.AllowUserToAddRows = false;
            this.dataGridDictionaryList.AllowUserToResizeRows = false;
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
            this.dataGridDictionaryList.ColumnHeadersHeight = 25;
            this.dataGridDictionaryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridDictionaryList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.editLink,
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
            this.TariffZone,
            this.Status,
            this.PWR,
            this.bankNAME,
            this.KPP,
            this.bankPayAcc,
            this.bankBIK,
            this.bankINN,
            this.bankCorrAcc,
            this.Extra1,
            this.Extra2,
            this.Extra3,
            this.Extra4});
            this.dataGridDictionaryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDictionaryList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridDictionaryList.EnableHeadersVisualStyles = false;
            this.dataGridDictionaryList.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridDictionaryList.Location = new System.Drawing.Point(3, 28);
            this.dataGridDictionaryList.Name = "dataGridDictionaryList";
            this.dataGridDictionaryList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridDictionaryList.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridDictionaryList.RowHeadersWidth = 20;
            this.dataGridDictionaryList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridDictionaryList.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridDictionaryList.RowTemplate.Height = 20;
            this.dataGridDictionaryList.Size = new System.Drawing.Size(1132, 571);
            this.dataGridDictionaryList.TabIndex = 0;
            this.dataGridDictionaryList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridDictionaryList_CellMouseClick);
            this.dataGridDictionaryList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grid_CellPainting);
            this.dataGridDictionaryList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridDictionary_EditingControlShowing);
            this.dataGridDictionaryList.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridDictionaryList_RowHeaderMouseClick);
            // 
            // editLink
            // 
            this.editLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.editLink.DefaultCellStyle = dataGridViewCellStyle2;
            this.editLink.FillWeight = 5F;
            this.editLink.HeaderText = "";
            this.editLink.Name = "editLink";
            this.editLink.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.editLink.ToolTipText = "Open Editor";
            this.editLink.Width = 25;
            // 
            // Agreement
            // 
            this.Agreement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Agreement.FillWeight = 29.56386F;
            this.Agreement.HeaderText = "agreement";
            this.Agreement.Name = "Agreement";
            this.Agreement.Width = 93;
            // 
            // DateAgreement
            // 
            this.DateAgreement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.DateAgreement.DefaultCellStyle = dataGridViewCellStyle3;
            this.DateAgreement.FillWeight = 27.15376F;
            this.DateAgreement.HeaderText = "date";
            this.DateAgreement.Name = "DateAgreement";
            this.DateAgreement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DateAgreement.Width = 56;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Type.DefaultCellStyle = dataGridViewCellStyle4;
            this.Type.FillWeight = 14.54666F;
            this.Type.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Type.HeaderText = "type";
            this.Type.Items.AddRange(new object[] {
            "ФЛ",
            "ЮЛ"});
            this.Type.MaxDropDownItems = 2;
            this.Type.Name = "Type";
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Type.Width = 50;
            // 
            // DocTC
            // 
            this.DocTC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DocTC.FillWeight = 20.7653F;
            this.DocTC.HeaderText = "atp";
            this.DocTC.MinimumWidth = 30;
            this.DocTC.Name = "DocTC";
            this.DocTC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DocTC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DocTC.Width = 30;
            // 
            // FullName
            // 
            this.FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FullName.FillWeight = 29.56386F;
            this.FullName.HeaderText = "name";
            this.FullName.MinimumWidth = 200;
            this.FullName.Name = "FullName";
            // 
            // INN
            // 
            this.INN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.INN.FillWeight = 29.56386F;
            this.INN.HeaderText = "inn";
            this.INN.Name = "INN";
            this.INN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.INN.Width = 48;
            // 
            // Address
            // 
            this.Address.FillWeight = 29.56386F;
            this.Address.HeaderText = "accAddress";
            this.Address.Name = "Address";
            this.Address.Visible = false;
            // 
            // NumCC
            // 
            this.NumCC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NumCC.FillWeight = 29.56386F;
            this.NumCC.HeaderText = "№Counter";
            this.NumCC.Name = "NumCC";
            this.NumCC.Width = 89;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle5.NullValue = "+7(XXX)XXX-XX-XX;";
            this.PhoneNumber.DefaultCellStyle = dataGridViewCellStyle5;
            this.PhoneNumber.FillWeight = 33F;
            this.PhoneNumber.HeaderText = "Phone";
            this.PhoneNumber.Mask = null;
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.PromtChar = '_';
            this.PhoneNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PhoneNumber.ValidatingType = null;
            this.PhoneNumber.Width = 48;
            // 
            // Mail
            // 
            this.Mail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Mail.DefaultCellStyle = dataGridViewCellStyle6;
            this.Mail.FillWeight = 29.56386F;
            this.Mail.HeaderText = "mail";
            this.Mail.Name = "Mail";
            this.Mail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Mail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Mail.Width = 36;
            // 
            // TariffZone
            // 
            this.TariffZone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TariffZone.FillWeight = 21.3351F;
            this.TariffZone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TariffZone.HeaderText = "tariff";
            this.TariffZone.Items.AddRange(new object[] {
            "1ЦК",
            "2 зоны",
            "3 зоны"});
            this.TariffZone.Name = "TariffZone";
            this.TariffZone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TariffZone.Width = 58;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Status.FillWeight = 29.56386F;
            this.Status.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Status.HeaderText = "status";
            this.Status.Items.AddRange(new object[] {
            "Действует",
            "Расторгнут",
            "Направлен",
            "Аннулирован"});
            this.Status.Name = "Status";
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Status.Width = 67;
            // 
            // PWR
            // 
            this.PWR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PWR.FillWeight = 29.56386F;
            this.PWR.HeaderText = "Pmax";
            this.PWR.Name = "PWR";
            this.PWR.Width = 40;
            // 
            // bankNAME
            // 
            this.bankNAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.bankNAME.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.bankNAME.DropDownWidth = 350;
            this.bankNAME.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bankNAME.HeaderText = "bankName";
            this.bankNAME.MaxDropDownItems = 16;
            this.bankNAME.Name = "bankNAME";
            this.bankNAME.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.bankNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.bankNAME.Width = 92;
            // 
            // KPP
            // 
            this.KPP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.KPP.HeaderText = "KPP";
            this.KPP.Name = "KPP";
            this.KPP.Width = 55;
            // 
            // bankPayAcc
            // 
            this.bankPayAcc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.bankPayAcc.HeaderText = "PayAcc";
            this.bankPayAcc.Name = "bankPayAcc";
            this.bankPayAcc.Width = 74;
            // 
            // bankBIK
            // 
            this.bankBIK.HeaderText = "bankBIK";
            this.bankBIK.Name = "bankBIK";
            this.bankBIK.Visible = false;
            // 
            // bankINN
            // 
            this.bankINN.HeaderText = "bankINN";
            this.bankINN.Name = "bankINN";
            this.bankINN.Visible = false;
            // 
            // bankCorrAcc
            // 
            this.bankCorrAcc.HeaderText = "bankCorrAcc";
            this.bankCorrAcc.Name = "bankCorrAcc";
            this.bankCorrAcc.Visible = false;
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
            this.dictLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dictLayoutPanel.Size = new System.Drawing.Size(1138, 602);
            this.dictLayoutPanel.TabIndex = 4;
            // 
            // urToolStrip
            // 
            this.urToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dictBtnOpen,
            this.dictBtnSave,
            this.dictBtnShowFolder,
            this.toolStripSeparator1,
            this.dictBtnImportFromExcel,
            this.dictBtnExportToExcel,
            this.toolStripSeparator4,
            this.dictListGTP,
            this.toolStripSeparator2,
            this.dictBtnAddElm,
            this.dictBtnDelElm,
            this.toolStripSeparator3,
            this.dictBtnBankData});
            this.urToolStrip.Location = new System.Drawing.Point(0, 0);
            this.urToolStrip.Name = "urToolStrip";
            this.urToolStrip.Size = new System.Drawing.Size(1138, 25);
            this.urToolStrip.TabIndex = 77;
            this.urToolStrip.Text = "mgTools";
            // 
            // dictBtnOpen
            // 
            this.dictBtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dictBtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("dictBtnOpen.Image")));
            this.dictBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dictBtnOpen.Name = "dictBtnOpen";
            this.dictBtnOpen.Size = new System.Drawing.Size(23, 22);
            this.dictBtnOpen.Text = "OpenFile";
            this.dictBtnOpen.Click += new System.EventHandler(this.dictBtnOpen_ButtonClick);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // dictListGTP
            // 
            this.dictListGTP.Name = "dictListGTP";
            this.dictListGTP.Size = new System.Drawing.Size(121, 25);
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
            this.dictBtnImportFromExcel.Click += new System.EventHandler(this.dictBtnImportFromExcel_Click);
            // 
            // dictBtnExportToExcel
            // 
            this.dictBtnExportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dictBtnExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("dictBtnExportToExcel.Image")));
            this.dictBtnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dictBtnExportToExcel.Name = "dictBtnExportToExcel";
            this.dictBtnExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.dictBtnExportToExcel.Text = "CreateExcel";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // dictBtnBankData
            // 
            this.dictBtnBankData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dictBtnBankData.Image = ((System.Drawing.Image)(resources.GetObject("dictBtnBankData.Image")));
            this.dictBtnBankData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dictBtnBankData.Name = "dictBtnBankData";
            this.dictBtnBankData.Size = new System.Drawing.Size(23, 22);
            this.dictBtnBankData.Text = "BankDictionary";
            this.dictBtnBankData.Click += new System.EventHandler(this.dictBtnBankData_Click);
            // 
            // mgDatsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1138, 602);
            this.Controls.Add(this.dictLayoutPanel);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(960, 500);
            this.Name = "mgDatsList";
            this.Text = "DatsEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mgDatsList_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mgDatsList_FormClosed);
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
        private ToolStripButton dictBtnOpen;
        private ToolStripButton dictBtnImportFromExcel;
        private ToolStripMenuItem mgLocalPhone;
        private ToolStripButton dictBtnExportToExcel;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton dictBtnBankData;
        public MainForm.DoubleBufferedDataGridView dataGridDictionaryList;
        private DataGridViewButtonColumn editLink;
        private DataGridViewTextBoxColumn Agreement;
        private CalendarColumn DateAgreement;
        private DataGridViewComboBoxColumn Type;
        private DataGridViewCheckBoxColumn DocTC;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn INN;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn NumCC;
        private MaskedEditColumn PhoneNumber;
        private DataGridViewTextBoxColumn Mail;
        private DataGridViewComboBoxColumn TariffZone;
        private DataGridViewComboBoxColumn Status;
        private DataGridViewTextBoxColumn PWR;
        private DataGridViewComboBoxColumn bankNAME;
        private DataGridViewTextBoxColumn KPP;
        private DataGridViewTextBoxColumn bankPayAcc;
        private DataGridViewTextBoxColumn bankBIK;
        private DataGridViewTextBoxColumn bankINN;
        private DataGridViewTextBoxColumn bankCorrAcc;
        private DataGridViewTextBoxColumn Extra1;
        private DataGridViewTextBoxColumn Extra2;
        private DataGridViewTextBoxColumn Extra3;
        private DataGridViewTextBoxColumn Extra4;
    }
}