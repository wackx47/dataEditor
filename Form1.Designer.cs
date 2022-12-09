using System.Windows.Forms;

namespace dataEditor
{
    partial class MainForm
    {

        private System.ComponentModel.IContainer components = null;


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


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ExportXML = new System.Windows.Forms.Button();
            this.Convert2Tree = new System.Windows.Forms.Button();
            this.FormName = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.importXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.showConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllExcelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.universalReaderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RowContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RightClick_HeadsRow = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClick_FirstRowData = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsGrid = new System.Windows.Forms.PropertyGrid();
            this.BackUserMessanger = new System.Windows.Forms.PictureBox();
            this.CellContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAsStaticValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAsColumn4CheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RegistryFix = new System.Windows.Forms.Button();
            this.dataViewer = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.RowContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackUserMessanger)).BeginInit();
            this.CellContext.SuspendLayout();
            this.ColumnContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ExportXML
            // 
            this.ExportXML.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExportXML.Enabled = false;
            this.ExportXML.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ExportXML.Location = new System.Drawing.Point(7, 59);
            this.ExportXML.Name = "ExportXML";
            this.ExportXML.Size = new System.Drawing.Size(100, 40);
            this.ExportXML.TabIndex = 11;
            this.ExportXML.Text = "Export to XML";
            this.ExportXML.UseCompatibleTextRendering = true;
            this.ExportXML.UseVisualStyleBackColor = true;
            this.ExportXML.Click += new System.EventHandler(this.ExportXML_Click);
            // 
            // Convert2Tree
            // 
            this.Convert2Tree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Convert2Tree.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Convert2Tree.Location = new System.Drawing.Point(7, 105);
            this.Convert2Tree.Name = "Convert2Tree";
            this.Convert2Tree.Size = new System.Drawing.Size(100, 40);
            this.Convert2Tree.TabIndex = 15;
            this.Convert2Tree.Text = "Transfer2Tree";
            this.Convert2Tree.UseCompatibleTextRendering = true;
            this.Convert2Tree.UseVisualStyleBackColor = true;
            this.Convert2Tree.Click += new System.EventHandler(this.Convert2Tree_Click);
            // 
            // FormName
            // 
            this.FormName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.FormName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormName.FormattingEnabled = true;
            this.FormName.Location = new System.Drawing.Point(7, 30);
            this.FormName.Name = "FormName";
            this.FormName.Size = new System.Drawing.Size(224, 23);
            this.FormName.TabIndex = 21;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.MenuOptions,
            this.universalReaderToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1233, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportExcel,
            this.importXMLToolStripMenuItem});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "File";
            // 
            // ImportExcel
            // 
            this.ImportExcel.Name = "ImportExcel";
            this.ImportExcel.Size = new System.Drawing.Size(138, 22);
            this.ImportExcel.Text = "New Presset";
            this.ImportExcel.Click += new System.EventHandler(this.ImportEXCL_Click);
            // 
            // importXMLToolStripMenuItem
            // 
            this.importXMLToolStripMenuItem.Name = "importXMLToolStripMenuItem";
            this.importXMLToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.importXMLToolStripMenuItem.Text = "Import XML";
            this.importXMLToolStripMenuItem.Click += new System.EventHandler(this.import2Universal_Click);
            // 
            // MenuOptions
            // 
            this.MenuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showConsoleToolStripMenuItem,
            this.closeAllExcelsToolStripMenuItem});
            this.MenuOptions.Name = "MenuOptions";
            this.MenuOptions.Size = new System.Drawing.Size(61, 20);
            this.MenuOptions.Text = "Options";
            // 
            // showConsoleToolStripMenuItem
            // 
            this.showConsoleToolStripMenuItem.Name = "showConsoleToolStripMenuItem";
            this.showConsoleToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.showConsoleToolStripMenuItem.Text = "Show Console";
            this.showConsoleToolStripMenuItem.Click += new System.EventHandler(this.ShowConsole_Click);
            // 
            // closeAllExcelsToolStripMenuItem
            // 
            this.closeAllExcelsToolStripMenuItem.Name = "closeAllExcelsToolStripMenuItem";
            this.closeAllExcelsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.closeAllExcelsToolStripMenuItem.Text = "Close all Excel";
            this.closeAllExcelsToolStripMenuItem.Click += new System.EventHandler(this.CloseAllExcel_Click);
            // 
            // universalReaderToolStripMenuItem1
            // 
            this.universalReaderToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem});
            this.universalReaderToolStripMenuItem1.Name = "universalReaderToolStripMenuItem1";
            this.universalReaderToolStripMenuItem1.Size = new System.Drawing.Size(106, 20);
            this.universalReaderToolStripMenuItem1.Text = "Universal Reader";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.FileWriter);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // RowContext
            // 
            this.RowContext.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.RowContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RightClick_HeadsRow,
            this.RightClick_FirstRowData});
            this.RowContext.Name = "contextDataViewer";
            this.RowContext.Size = new System.Drawing.Size(177, 48);
            // 
            // RightClick_HeadsRow
            // 
            this.RightClick_HeadsRow.Name = "RightClick_HeadsRow";
            this.RightClick_HeadsRow.Size = new System.Drawing.Size(176, 22);
            this.RightClick_HeadsRow.Text = "Set as HeadsRow";
            this.RightClick_HeadsRow.Click += new System.EventHandler(this.StripMenuHeaderRow_Click);
            // 
            // RightClick_FirstRowData
            // 
            this.RightClick_FirstRowData.Name = "RightClick_FirstRowData";
            this.RightClick_FirstRowData.Size = new System.Drawing.Size(176, 22);
            this.RightClick_FirstRowData.Text = "Set as FirstDataRow";
            this.RightClick_FirstRowData.Click += new System.EventHandler(this.StripMenuFirstData_Click);
            // 
            // optionsGrid
            // 
            this.optionsGrid.BackColor = System.Drawing.SystemColors.Control;
            this.optionsGrid.CommandsBackColor = System.Drawing.SystemColors.ControlDark;
            this.optionsGrid.CommandsVisibleIfAvailable = false;
            this.optionsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsGrid.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.optionsGrid.LineColor = System.Drawing.SystemColors.ControlLight;
            this.optionsGrid.Location = new System.Drawing.Point(836, 3);
            this.optionsGrid.Name = "optionsGrid";
            this.optionsGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.optionsGrid.Size = new System.Drawing.Size(269, 455);
            this.optionsGrid.TabIndex = 64;
            this.optionsGrid.UseCompatibleTextRendering = true;
            this.optionsGrid.ViewBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.optionsGrid.ViewBorderColor = System.Drawing.SystemColors.WindowFrame;
            this.optionsGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.optionsGrid_PropertyValueChanged);
            // 
            // BackUserMessanger
            // 
            this.BackUserMessanger.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BackUserMessanger.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BackUserMessanger.Location = new System.Drawing.Point(0, 526);
            this.BackUserMessanger.Name = "BackUserMessanger";
            this.BackUserMessanger.Size = new System.Drawing.Size(1233, 24);
            this.BackUserMessanger.TabIndex = 65;
            this.BackUserMessanger.TabStop = false;
            // 
            // CellContext
            // 
            this.CellContext.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CellContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAsStaticValueToolStripMenuItem});
            this.CellContext.Name = "RowContext";
            this.CellContext.Size = new System.Drawing.Size(170, 26);
            // 
            // setAsStaticValueToolStripMenuItem
            // 
            this.setAsStaticValueToolStripMenuItem.Name = "setAsStaticValueToolStripMenuItem";
            this.setAsStaticValueToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.setAsStaticValueToolStripMenuItem.Text = "Set As Static Value";
            // 
            // ColumnContext
            // 
            this.ColumnContext.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ColumnContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAsColumn4CheckToolStripMenuItem});
            this.ColumnContext.Name = "ColumnContext";
            this.ColumnContext.Size = new System.Drawing.Size(190, 26);
            // 
            // setAsColumn4CheckToolStripMenuItem
            // 
            this.setAsColumn4CheckToolStripMenuItem.Name = "setAsColumn4CheckToolStripMenuItem";
            this.setAsColumn4CheckToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.setAsColumn4CheckToolStripMenuItem.Text = "Set as Column4Check";
            // 
            // RegistryFix
            // 
            this.RegistryFix.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegistryFix.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RegistryFix.Location = new System.Drawing.Point(7, 151);
            this.RegistryFix.Name = "RegistryFix";
            this.RegistryFix.Size = new System.Drawing.Size(100, 40);
            this.RegistryFix.TabIndex = 69;
            this.RegistryFix.Text = "RegLib";
            this.RegistryFix.UseCompatibleTextRendering = true;
            this.RegistryFix.UseVisualStyleBackColor = true;
            this.RegistryFix.Click += new System.EventHandler(this.RegistryFix_Click);
            // 
            // dataViewer
            // 
            this.dataViewer.AllowUserToAddRows = false;
            this.dataViewer.AllowUserToDeleteRows = false;
            this.dataViewer.AllowUserToResizeColumns = false;
            this.dataViewer.AllowUserToResizeRows = false;
            this.dataViewer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataViewer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataViewer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewer.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataViewer.Location = new System.Drawing.Point(3, 3);
            this.dataViewer.Name = "dataViewer";
            this.dataViewer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataViewer.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataViewer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataViewer.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataViewer.RowTemplate.Height = 25;
            this.dataViewer.Size = new System.Drawing.Size(619, 455);
            this.dataViewer.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 208F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 275F));
            this.tableLayoutPanel1.Controls.Add(this.dataViewer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusGridView, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.optionsGrid, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(113, 59);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1108, 461);
            this.tableLayoutPanel1.TabIndex = 71;
            // 
            // statusGridView
            // 
            this.statusGridView.AllowUserToAddRows = false;
            this.statusGridView.AllowUserToDeleteRows = false;
            this.statusGridView.AllowUserToResizeColumns = false;
            this.statusGridView.AllowUserToResizeRows = false;
            this.statusGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.statusGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.statusGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.statusGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.statusGridView.ColumnHeadersHeight = 20;
            this.statusGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.statusGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.statusGridView.EnableHeadersVisualStyles = false;
            this.statusGridView.Location = new System.Drawing.Point(628, 3);
            this.statusGridView.Name = "statusGridView";
            this.statusGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.statusGridView.RowHeadersVisible = false;
            this.statusGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.statusGridView.RowTemplate.Height = 25;
            this.statusGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.statusGridView.Size = new System.Drawing.Size(201, 455);
            this.statusGridView.TabIndex = 70;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Value";
            this.Column2.Name = "Column2";
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Status";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1233, 550);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ExportXML);
            this.Controls.Add(this.Convert2Tree);
            this.Controls.Add(this.RegistryFix);
            this.Controls.Add(this.BackUserMessanger);
            this.Controls.Add(this.FormName);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "dataEditor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.RowContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BackUserMessanger)).EndInit();
            this.CellContext.ResumeLayout(false);
            this.ColumnContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button ExportXML;
        private Button Convert2Tree;
        private ComboBox FormName;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem FileMenu;
        private ToolStripMenuItem ImportExcel;
        private ToolStripMenuItem importXMLToolStripMenuItem;
        private ToolStripMenuItem MenuOptions;
        private ToolStripMenuItem showConsoleToolStripMenuItem;
        private ContextMenuStrip RowContext;
        private ToolStripMenuItem RightClick_HeadsRow;
        private ToolStripMenuItem RightClick_FirstRowData;
        private ToolStripMenuItem universalReaderToolStripMenuItem1;
        private ToolStripMenuItem openFileToolStripMenuItem;
        private PropertyGrid optionsGrid;
        private PictureBox BackUserMessanger;
        private ContextMenuStrip CellContext;
        private ContextMenuStrip ColumnContext;
        private ToolStripMenuItem setAsColumn4CheckToolStripMenuItem;
        private ToolStripMenuItem closeAllExcelsToolStripMenuItem;
        private ToolStripMenuItem setAsStaticValueToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Button RegistryFix;
        private DataGridView dataViewer;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView statusGridView;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
    }
}