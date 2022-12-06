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
            this.dataViewer = new System.Windows.Forms.DataGridView();
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
            this.RowContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RightClick_HeadsRow = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClick_FirstRowData = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsGrid = new System.Windows.Forms.PropertyGrid();
            this.BackUserMessanger = new System.Windows.Forms.PictureBox();
            this.UserMessanger = new System.Windows.Forms.Label();
            this.CellContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAsStaticValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAsColumn4CheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usedXML = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.settingsBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.RowContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackUserMessanger)).BeginInit();
            this.CellContext.SuspendLayout();
            this.ColumnContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBackground)).BeginInit();
            this.SuspendLayout();
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataViewer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewer.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataViewer.Location = new System.Drawing.Point(7, 59);
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
            this.dataViewer.Size = new System.Drawing.Size(724, 399);
            this.dataViewer.TabIndex = 1;
            // 
            // ExportXML
            // 
            this.ExportXML.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExportXML.Enabled = false;
            this.ExportXML.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ExportXML.Location = new System.Drawing.Point(237, 30);
            this.ExportXML.Name = "ExportXML";
            this.ExportXML.Size = new System.Drawing.Size(92, 23);
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
            this.Convert2Tree.Location = new System.Drawing.Point(335, 30);
            this.Convert2Tree.Name = "Convert2Tree";
            this.Convert2Tree.Size = new System.Drawing.Size(92, 23);
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
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.MenuOptions,
            this.universalReaderToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1072, 24);
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
            // RowContext
            // 
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
            this.optionsGrid.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.optionsGrid.LineColor = System.Drawing.SystemColors.ControlLight;
            this.optionsGrid.Location = new System.Drawing.Point(737, 33);
            this.optionsGrid.Name = "optionsGrid";
            this.optionsGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.optionsGrid.Size = new System.Drawing.Size(322, 487);
            this.optionsGrid.TabIndex = 64;
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
            this.BackUserMessanger.Size = new System.Drawing.Size(1072, 24);
            this.BackUserMessanger.TabIndex = 65;
            this.BackUserMessanger.TabStop = false;
            // 
            // UserMessanger
            // 
            this.UserMessanger.AutoSize = true;
            this.UserMessanger.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.UserMessanger.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UserMessanger.Location = new System.Drawing.Point(12, 530);
            this.UserMessanger.Name = "UserMessanger";
            this.UserMessanger.Size = new System.Drawing.Size(0, 16);
            this.UserMessanger.TabIndex = 66;
            // 
            // CellContext
            // 
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
            // usedXML
            // 
            this.usedXML.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.usedXML.FormattingEnabled = true;
            this.usedXML.Location = new System.Drawing.Point(12, 486);
            this.usedXML.MaxDropDownItems = 10;
            this.usedXML.Name = "usedXML";
            this.usedXML.Size = new System.Drawing.Size(172, 23);
            this.usedXML.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(11, 468);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 68;
            this.label1.Text = "Used file presset";
            // 
            // settingsBackground
            // 
            this.settingsBackground.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.settingsBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settingsBackground.Location = new System.Drawing.Point(7, 461);
            this.settingsBackground.Name = "settingsBackground";
            this.settingsBackground.Size = new System.Drawing.Size(724, 59);
            this.settingsBackground.TabIndex = 69;
            this.settingsBackground.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 550);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usedXML);
            this.Controls.Add(this.Convert2Tree);
            this.Controls.Add(this.UserMessanger);
            this.Controls.Add(this.BackUserMessanger);
            this.Controls.Add(this.optionsGrid);
            this.Controls.Add(this.FormName);
            this.Controls.Add(this.ExportXML);
            this.Controls.Add(this.dataViewer);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.settingsBackground);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "dataEditor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.RowContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BackUserMessanger)).EndInit();
            this.CellContext.ResumeLayout(false);
            this.ColumnContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.settingsBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView dataViewer;
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
        private Label UserMessanger;
        private ContextMenuStrip CellContext;
        private ContextMenuStrip ColumnContext;
        private ToolStripMenuItem setAsColumn4CheckToolStripMenuItem;
        private ComboBox usedXML;
        private Label label1;
        private ToolStripMenuItem closeAllExcelsToolStripMenuItem;
        private ToolStripMenuItem setAsStaticValueToolStripMenuItem;
        private PictureBox settingsBackground;
    }
}