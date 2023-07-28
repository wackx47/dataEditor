namespace dataEditor
{
    partial class hoursZoneEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(hoursZoneEditor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("0");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("с", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("0");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("до", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("день", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("0");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("с", new System.Windows.Forms.TreeNode[] {
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("0");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("до", new System.Windows.Forms.TreeNode[] {
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("ночь", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("пик");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("полупик");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("ночь");
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnConfirm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.hoursDataGrid = new dataEditor.MainForm.DoubleBufferedDataGridView();
            this.Hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupDoubleZone = new System.Windows.Forms.GroupBox();
            this.DoubleZTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.doubleZoneTreeView = new System.Windows.Forms.TreeView();
            this.groupTrippleZone = new System.Windows.Forms.GroupBox();
            this.TrippleZTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.trippleZoneTreeView = new System.Windows.Forms.TreeView();
            this.zoneToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnAddNew3z = new System.Windows.Forms.ToolStripButton();
            this.cmbxSelectTypeZone = new System.Windows.Forms.ToolStripComboBox();
            this.groupHours = new System.Windows.Forms.GroupBox();
            this.HoursTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnApplyHours = new System.Windows.Forms.Button();
            this.cmbxSelectGlobalZone = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoursDataGrid)).BeginInit();
            this.groupDoubleZone.SuspendLayout();
            this.DoubleZTableLayout.SuspendLayout();
            this.groupTrippleZone.SuspendLayout();
            this.TrippleZTableLayout.SuspendLayout();
            this.zoneToolStrip.SuspendLayout();
            this.groupHours.SuspendLayout();
            this.HoursTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConfirm,
            this.toolStripSeparator7});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(10, 1, 1, 1);
            this.ToolStrip.Size = new System.Drawing.Size(534, 25);
            this.ToolStrip.TabIndex = 81;
            this.ToolStrip.Text = "mgTools";
            // 
            // btnConfirm
            // 
            this.btnConfirm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(23, 20);
            this.btnConfirm.Text = "Enter";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // hoursDataGrid
            // 
            this.hoursDataGrid.AllowUserToAddRows = false;
            this.hoursDataGrid.AllowUserToDeleteRows = false;
            this.hoursDataGrid.AllowUserToResizeColumns = false;
            this.hoursDataGrid.AllowUserToResizeRows = false;
            this.hoursDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.hoursDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.hoursDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hoursDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.hoursDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.hoursDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hoursDataGrid.ColumnHeadersVisible = false;
            this.hoursDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hours});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.hoursDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.hoursDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hoursDataGrid.GridColor = System.Drawing.SystemColors.ControlLight;
            this.hoursDataGrid.Location = new System.Drawing.Point(2, 57);
            this.hoursDataGrid.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.hoursDataGrid.Name = "hoursDataGrid";
            this.hoursDataGrid.ReadOnly = true;
            this.hoursDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.hoursDataGrid.RowHeadersVisible = false;
            this.hoursDataGrid.RowTemplate.Height = 15;
            this.hoursDataGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.hoursDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.hoursDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.hoursDataGrid.Size = new System.Drawing.Size(105, 365);
            this.hoursDataGrid.TabIndex = 82;
            this.hoursDataGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.hoursDataGrid_Paint);
            this.hoursDataGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.hoursDataGrid_MouseMove);
            // 
            // Hours
            // 
            this.Hours.HeaderText = "Hours";
            this.Hours.Name = "Hours";
            this.Hours.ReadOnly = true;
            // 
            // groupDoubleZone
            // 
            this.groupDoubleZone.Controls.Add(this.DoubleZTableLayout);
            this.groupDoubleZone.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupDoubleZone.Location = new System.Drawing.Point(137, 28);
            this.groupDoubleZone.Name = "groupDoubleZone";
            this.groupDoubleZone.Size = new System.Drawing.Size(180, 475);
            this.groupDoubleZone.TabIndex = 83;
            this.groupDoubleZone.TabStop = false;
            this.groupDoubleZone.Text = "2 зоны";
            // 
            // DoubleZTableLayout
            // 
            this.DoubleZTableLayout.ColumnCount = 1;
            this.DoubleZTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DoubleZTableLayout.Controls.Add(this.doubleZoneTreeView, 0, 1);
            this.DoubleZTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DoubleZTableLayout.Location = new System.Drawing.Point(3, 18);
            this.DoubleZTableLayout.Name = "DoubleZTableLayout";
            this.DoubleZTableLayout.RowCount = 2;
            this.DoubleZTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.DoubleZTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DoubleZTableLayout.Size = new System.Drawing.Size(174, 454);
            this.DoubleZTableLayout.TabIndex = 87;
            // 
            // doubleZoneTreeView
            // 
            this.doubleZoneTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleZoneTreeView.ItemHeight = 15;
            this.doubleZoneTreeView.Location = new System.Drawing.Point(3, 3);
            this.doubleZoneTreeView.Name = "doubleZoneTreeView";
            treeNode1.Name = "initialVal";
            treeNode1.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode1.Text = "0";
            treeNode2.Name = "initial";
            treeNode2.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode2.Text = "с";
            treeNode3.Name = "finalVal";
            treeNode3.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode3.Text = "0";
            treeNode4.Name = "final";
            treeNode4.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode4.Text = "до";
            treeNode5.Name = "day";
            treeNode5.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            treeNode5.Text = "день";
            treeNode6.Name = "initialVal";
            treeNode6.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode6.Text = "0";
            treeNode7.Name = "initial";
            treeNode7.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode7.Text = "с";
            treeNode8.Name = "finalVal";
            treeNode8.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode8.Text = "0";
            treeNode9.Name = "final";
            treeNode9.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode9.Text = "до";
            treeNode10.Name = "night";
            treeNode10.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            treeNode10.Text = "ночь";
            this.doubleZoneTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode10});
            this.doubleZoneTreeView.Size = new System.Drawing.Size(168, 448);
            this.doubleZoneTreeView.TabIndex = 0;
            this.doubleZoneTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.doubleZoneTreeView_AfterSelect);
            this.doubleZoneTreeView.Enter += new System.EventHandler(this.doubleZoneTreeView_Enter);
            // 
            // groupTrippleZone
            // 
            this.groupTrippleZone.Controls.Add(this.TrippleZTableLayout);
            this.groupTrippleZone.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupTrippleZone.Location = new System.Drawing.Point(323, 28);
            this.groupTrippleZone.Name = "groupTrippleZone";
            this.groupTrippleZone.Size = new System.Drawing.Size(200, 475);
            this.groupTrippleZone.TabIndex = 84;
            this.groupTrippleZone.TabStop = false;
            this.groupTrippleZone.Text = "3 зоны";
            // 
            // TrippleZTableLayout
            // 
            this.TrippleZTableLayout.ColumnCount = 1;
            this.TrippleZTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TrippleZTableLayout.Controls.Add(this.trippleZoneTreeView, 0, 1);
            this.TrippleZTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrippleZTableLayout.Location = new System.Drawing.Point(3, 18);
            this.TrippleZTableLayout.Name = "TrippleZTableLayout";
            this.TrippleZTableLayout.RowCount = 2;
            this.TrippleZTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TrippleZTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TrippleZTableLayout.Size = new System.Drawing.Size(194, 454);
            this.TrippleZTableLayout.TabIndex = 86;
            // 
            // trippleZoneTreeView
            // 
            this.trippleZoneTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trippleZoneTreeView.ItemHeight = 15;
            this.trippleZoneTreeView.Location = new System.Drawing.Point(3, 3);
            this.trippleZoneTreeView.Name = "trippleZoneTreeView";
            treeNode11.Name = "peak";
            treeNode11.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            treeNode11.Text = "пик";
            treeNode12.Name = "semiPeak";
            treeNode12.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            treeNode12.Text = "полупик";
            treeNode13.Name = "night";
            treeNode13.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            treeNode13.Text = "ночь";
            this.trippleZoneTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13});
            this.trippleZoneTreeView.Size = new System.Drawing.Size(188, 448);
            this.trippleZoneTreeView.TabIndex = 1;
            this.trippleZoneTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrippleZoneTreeView_AfterSelect);
            this.trippleZoneTreeView.Enter += new System.EventHandler(this.TrippleZoneTreeView_Enter);
            // 
            // zoneToolStrip
            // 
            this.zoneToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zoneToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.zoneToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNew3z,
            this.cmbxSelectTypeZone});
            this.zoneToolStrip.Location = new System.Drawing.Point(1, 29);
            this.zoneToolStrip.Margin = new System.Windows.Forms.Padding(1);
            this.zoneToolStrip.Name = "zoneToolStrip";
            this.zoneToolStrip.Padding = new System.Windows.Forms.Padding(1);
            this.zoneToolStrip.Size = new System.Drawing.Size(107, 26);
            this.zoneToolStrip.TabIndex = 85;
            this.zoneToolStrip.Text = "mgTools";
            // 
            // btnAddNew3z
            // 
            this.btnAddNew3z.AutoToolTip = false;
            this.btnAddNew3z.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddNew3z.Enabled = false;
            this.btnAddNew3z.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddNew3z.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew3z.Image")));
            this.btnAddNew3z.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNew3z.Name = "btnAddNew3z";
            this.btnAddNew3z.Size = new System.Drawing.Size(23, 21);
            this.btnAddNew3z.Text = "Add";
            this.btnAddNew3z.Click += new System.EventHandler(this.btnAddNew3z_Click);
            // 
            // cmbxSelectTypeZone
            // 
            this.cmbxSelectTypeZone.AutoSize = false;
            this.cmbxSelectTypeZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxSelectTypeZone.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbxSelectTypeZone.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbxSelectTypeZone.Margin = new System.Windows.Forms.Padding(1);
            this.cmbxSelectTypeZone.Name = "cmbxSelectTypeZone";
            this.cmbxSelectTypeZone.Size = new System.Drawing.Size(80, 22);
            this.cmbxSelectTypeZone.DropDownClosed += new System.EventHandler(this.cmbxSelectTypeZone_DropDownClosed);
            // 
            // groupHours
            // 
            this.groupHours.Controls.Add(this.HoursTableLayoutPanel);
            this.groupHours.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupHours.Location = new System.Drawing.Point(12, 28);
            this.groupHours.Name = "groupHours";
            this.groupHours.Size = new System.Drawing.Size(115, 475);
            this.groupHours.TabIndex = 85;
            this.groupHours.TabStop = false;
            this.groupHours.Text = "Hours";
            // 
            // HoursTableLayoutPanel
            // 
            this.HoursTableLayoutPanel.ColumnCount = 1;
            this.HoursTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HoursTableLayoutPanel.Controls.Add(this.btnApplyHours, 0, 3);
            this.HoursTableLayoutPanel.Controls.Add(this.zoneToolStrip, 0, 1);
            this.HoursTableLayoutPanel.Controls.Add(this.hoursDataGrid, 0, 2);
            this.HoursTableLayoutPanel.Controls.Add(this.cmbxSelectGlobalZone, 0, 0);
            this.HoursTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HoursTableLayoutPanel.Location = new System.Drawing.Point(3, 18);
            this.HoursTableLayoutPanel.Name = "HoursTableLayoutPanel";
            this.HoursTableLayoutPanel.RowCount = 4;
            this.HoursTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.HoursTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.HoursTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HoursTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.HoursTableLayoutPanel.Size = new System.Drawing.Size(109, 454);
            this.HoursTableLayoutPanel.TabIndex = 83;
            // 
            // btnApplyHours
            // 
            this.btnApplyHours.Location = new System.Drawing.Point(3, 426);
            this.btnApplyHours.Name = "btnApplyHours";
            this.btnApplyHours.Size = new System.Drawing.Size(103, 25);
            this.btnApplyHours.TabIndex = 83;
            this.btnApplyHours.Text = "Применить";
            this.btnApplyHours.UseVisualStyleBackColor = true;
            this.btnApplyHours.Click += new System.EventHandler(this.btnApplyHours_Click);
            // 
            // cmbxSelectGlobalZone
            // 
            this.cmbxSelectGlobalZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbxSelectGlobalZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxSelectGlobalZone.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbxSelectGlobalZone.FormattingEnabled = true;
            this.cmbxSelectGlobalZone.Items.AddRange(new object[] {
            "2 зоны",
            "3 зоны"});
            this.cmbxSelectGlobalZone.Location = new System.Drawing.Point(3, 3);
            this.cmbxSelectGlobalZone.Name = "cmbxSelectGlobalZone";
            this.cmbxSelectGlobalZone.Size = new System.Drawing.Size(103, 22);
            this.cmbxSelectGlobalZone.TabIndex = 84;
            this.cmbxSelectGlobalZone.DropDownClosed += new System.EventHandler(this.cmbxSelectGlobalZone_DropDownClosed);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // hoursZoneEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 511);
            this.Controls.Add(this.groupTrippleZone);
            this.Controls.Add(this.groupHours);
            this.Controls.Add(this.groupDoubleZone);
            this.Controls.Add(this.ToolStrip);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "hoursZoneEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "hoursZoneEditor";
            this.Load += new System.EventHandler(this.hoursZoneEditor_Load);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoursDataGrid)).EndInit();
            this.groupDoubleZone.ResumeLayout(false);
            this.DoubleZTableLayout.ResumeLayout(false);
            this.groupTrippleZone.ResumeLayout(false);
            this.TrippleZTableLayout.ResumeLayout(false);
            this.zoneToolStrip.ResumeLayout(false);
            this.zoneToolStrip.PerformLayout();
            this.groupHours.ResumeLayout(false);
            this.HoursTableLayoutPanel.ResumeLayout(false);
            this.HoursTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ToolStrip ToolStrip;
        private ToolStripButton btnConfirm;
        private ToolStripSeparator toolStripSeparator7;
        private dataEditor.MainForm.DoubleBufferedDataGridView hoursDataGrid;
        private DataGridViewTextBoxColumn Hours;
        private GroupBox groupDoubleZone;
        private TreeView doubleZoneTreeView;
        private GroupBox groupTrippleZone;
        private TreeView trippleZoneTreeView;
        private GroupBox groupHours;
        private TableLayoutPanel DoubleZTableLayout;
        private TableLayoutPanel TrippleZTableLayout;
        private ToolStrip zoneToolStrip;
        private ToolStripButton btnAddNew3z;
        private TableLayoutPanel HoursTableLayoutPanel;
        private Button btnApplyHours;
        private ComboBox cmbxSelectGlobalZone;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripComboBox cmbxSelectTypeZone;
    }
}