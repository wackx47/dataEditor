using System.Reflection;
using System.Windows.Forms;
using universalReader;
using static dataEditor.Program;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            this.RowContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RightClick_HeadsRow = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClick_FirstRowData = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsGrid = new System.Windows.Forms.PropertyGrid();
            this.propGrid_stripMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackUserMessanger = new System.Windows.Forms.PictureBox();
            this.CellContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAsStaticValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAsColumn4CheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataViewer = new System.Windows.Forms.DataGridView();
            this.statusGridView = new dataEditor.MainForm.StatusGridViewEditMode();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer_rightProps = new System.Windows.Forms.SplitContainer();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.importXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitUR = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.showConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllExcelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regLibOfficeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.universalReaderToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xFAReaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer_bigMain = new System.Windows.Forms.SplitContainer();
            this.splitContainer_dataGrids = new System.Windows.Forms.SplitContainer();
            this.CellViewer = new System.Windows.Forms.TextBox();
            this.SectionsControl = new System.Windows.Forms.TabControl();
            this.tabExcel = new System.Windows.Forms.TabPage();
            this.urToolStrip = new System.Windows.Forms.ToolStrip();
            this.urBtnImportFile = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.urBtnSaveXML = new System.Windows.Forms.ToolStripButton();
            this.urBtnConvert2Tree = new System.Windows.Forms.ToolStripButton();
            this.tabMicrogeneration = new System.Windows.Forms.TabPage();
            this.mgToolStrip = new System.Windows.Forms.ToolStrip();
            this.mgBtnImportFile = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnConvertFile = new System.Windows.Forms.ToolStripSplitButton();
            this.toolBtnDictionaryList = new System.Windows.Forms.ToolStripButton();
            this.toolBtnDictionaryEditor = new System.Windows.Forms.ToolStripButton();
            this.mgSplitContainer_vertical = new System.Windows.Forms.SplitContainer();
            this.mgSplitContainer_horizontal = new System.Windows.Forms.SplitContainer();
            this.MounthTab = new System.Windows.Forms.TabControl();
            this.January = new System.Windows.Forms.TabPage();
            this.mgDataViewer = new System.Windows.Forms.DataGridView();
            this.February = new System.Windows.Forms.TabPage();
            this.March = new System.Windows.Forms.TabPage();
            this.April = new System.Windows.Forms.TabPage();
            this.May = new System.Windows.Forms.TabPage();
            this.June = new System.Windows.Forms.TabPage();
            this.July = new System.Windows.Forms.TabPage();
            this.August = new System.Windows.Forms.TabPage();
            this.September = new System.Windows.Forms.TabPage();
            this.October = new System.Windows.Forms.TabPage();
            this.November = new System.Windows.Forms.TabPage();
            this.December = new System.Windows.Forms.TabPage();
            this.mgWorkDataViewer = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RowContext.SuspendLayout();
            this.propGrid_stripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackUserMessanger)).BeginInit();
            this.CellContext.SuspendLayout();
            this.ColumnContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_rightProps)).BeginInit();
            this.splitContainer_rightProps.Panel1.SuspendLayout();
            this.splitContainer_rightProps.Panel2.SuspendLayout();
            this.splitContainer_rightProps.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_bigMain)).BeginInit();
            this.splitContainer_bigMain.Panel1.SuspendLayout();
            this.splitContainer_bigMain.Panel2.SuspendLayout();
            this.splitContainer_bigMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_dataGrids)).BeginInit();
            this.splitContainer_dataGrids.Panel1.SuspendLayout();
            this.splitContainer_dataGrids.Panel2.SuspendLayout();
            this.splitContainer_dataGrids.SuspendLayout();
            this.SectionsControl.SuspendLayout();
            this.tabExcel.SuspendLayout();
            this.urToolStrip.SuspendLayout();
            this.tabMicrogeneration.SuspendLayout();
            this.mgToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mgSplitContainer_vertical)).BeginInit();
            this.mgSplitContainer_vertical.Panel1.SuspendLayout();
            this.mgSplitContainer_vertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mgSplitContainer_horizontal)).BeginInit();
            this.mgSplitContainer_horizontal.Panel1.SuspendLayout();
            this.mgSplitContainer_horizontal.Panel2.SuspendLayout();
            this.mgSplitContainer_horizontal.SuspendLayout();
            this.MounthTab.SuspendLayout();
            this.January.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mgDataViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgWorkDataViewer)).BeginInit();
            this.SuspendLayout();
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
            this.optionsGrid.CommandsBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.optionsGrid.CommandsVisibleIfAvailable = false;
            this.optionsGrid.ContextMenuStrip = this.propGrid_stripMenu;
            this.optionsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsGrid.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.optionsGrid.HelpBorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.optionsGrid.HelpVisible = false;
            this.optionsGrid.LineColor = System.Drawing.SystemColors.ControlLight;
            this.optionsGrid.Location = new System.Drawing.Point(0, 0);
            this.optionsGrid.Name = "optionsGrid";
            this.optionsGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.optionsGrid.Size = new System.Drawing.Size(285, 399);
            this.optionsGrid.TabIndex = 64;
            this.optionsGrid.UseCompatibleTextRendering = true;
            this.optionsGrid.ViewBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.optionsGrid.ViewBorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.optionsGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.optionsGrid_PropertyValueChanged);
            // 
            // propGrid_stripMenu
            // 
            this.propGrid_stripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.propGrid_stripMenu.Name = "propGrid_stripMenu";
            this.propGrid_stripMenu.Size = new System.Drawing.Size(100, 26);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.propGrid_stripHelp);
            // 
            // BackUserMessanger
            // 
            this.BackUserMessanger.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BackUserMessanger.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BackUserMessanger.Location = new System.Drawing.Point(0, 642);
            this.BackUserMessanger.Name = "BackUserMessanger";
            this.BackUserMessanger.Size = new System.Drawing.Size(1047, 24);
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
            this.setAsColumn4CheckToolStripMenuItem.Click += new System.EventHandler(this.StripMenuHeaderColumnSelect_Click);
            // 
            // dataViewer
            // 
            this.dataViewer.AllowDrop = true;
            this.dataViewer.AllowUserToAddRows = false;
            this.dataViewer.AllowUserToDeleteRows = false;
            this.dataViewer.AllowUserToResizeRows = false;
            this.dataViewer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataViewer.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataViewer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataViewer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataViewer.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataViewer.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataViewer.Location = new System.Drawing.Point(0, 0);
            this.dataViewer.MultiSelect = false;
            this.dataViewer.Name = "dataViewer";
            this.dataViewer.ReadOnly = true;
            this.dataViewer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataViewer.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataViewer.RowHeadersWidth = 20;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataViewer.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataViewer.RowTemplate.Height = 25;
            this.dataViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataViewer.Size = new System.Drawing.Size(744, 524);
            this.dataViewer.TabIndex = 1;
            this.dataViewer.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataViewer_DragDrop);
            this.dataViewer.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataViewer_DragEnter);
            // 
            // statusGridView
            // 
            this.statusGridView.AllowUserToAddRows = false;
            this.statusGridView.AllowUserToDeleteRows = false;
            this.statusGridView.AllowUserToResizeColumns = false;
            this.statusGridView.AllowUserToResizeRows = false;
            this.statusGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.statusGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.statusGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.statusGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.statusGridView.ColumnHeadersHeight = 20;
            this.statusGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.statusGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.statusGridView.DefaultCellStyle = dataGridViewCellStyle9;
            this.statusGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.statusGridView.EnableHeadersVisualStyles = false;
            this.statusGridView.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.statusGridView.Location = new System.Drawing.Point(0, 0);
            this.statusGridView.MultiSelect = false;
            this.statusGridView.Name = "statusGridView";
            this.statusGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.statusGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.statusGridView.RowHeadersVisible = false;
            this.statusGridView.RowHeadersWidth = 130;
            this.statusGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.statusGridView.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.statusGridView.RowTemplate.Height = 17;
            this.statusGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.statusGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.statusGridView.Size = new System.Drawing.Size(285, 150);
            this.statusGridView.TabIndex = 70;
            this.statusGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.statusGridView_CellCmbxValueChanged);
            this.statusGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.statusGridView_CurrentCellDirtyStateChanged);
            // 
            // Column1
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 104;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column2.HeaderText = "Value";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column3.HeaderText = "Status";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 50;
            // 
            // splitContainer_rightProps
            // 
            this.splitContainer_rightProps.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer_rightProps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_rightProps.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_rightProps.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_rightProps.Name = "splitContainer_rightProps";
            this.splitContainer_rightProps.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_rightProps.Panel1
            // 
            this.splitContainer_rightProps.Panel1.Controls.Add(this.statusGridView);
            this.splitContainer_rightProps.Panel1MinSize = 55;
            // 
            // splitContainer_rightProps.Panel2
            // 
            this.splitContainer_rightProps.Panel2.Controls.Add(this.optionsGrid);
            this.splitContainer_rightProps.Panel2MinSize = 0;
            this.splitContainer_rightProps.Size = new System.Drawing.Size(285, 553);
            this.splitContainer_rightProps.SplitterDistance = 150;
            this.splitContainer_rightProps.TabIndex = 74;
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importXMLToolStripMenuItem,
            this.ExitUR});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "File";
            // 
            // importXMLToolStripMenuItem
            // 
            this.importXMLToolStripMenuItem.Name = "importXMLToolStripMenuItem";
            this.importXMLToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.importXMLToolStripMenuItem.Text = "Import XML";
            this.importXMLToolStripMenuItem.Click += new System.EventHandler(this.import2Universal_Click);
            // 
            // ExitUR
            // 
            this.ExitUR.Name = "ExitUR";
            this.ExitUR.Size = new System.Drawing.Size(137, 22);
            this.ExitUR.Text = "Exit";
            this.ExitUR.Click += new System.EventHandler(this.ExitUR_Click);
            // 
            // OptionsMenu
            // 
            this.OptionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showConsoleToolStripMenuItem,
            this.closeAllExcelsToolStripMenuItem,
            this.regLibOfficeToolStripMenuItem});
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.Size = new System.Drawing.Size(46, 20);
            this.OptionsMenu.Text = "Tools";
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
            // regLibOfficeToolStripMenuItem
            // 
            this.regLibOfficeToolStripMenuItem.Enabled = false;
            this.regLibOfficeToolStripMenuItem.Name = "regLibOfficeToolStripMenuItem";
            this.regLibOfficeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.regLibOfficeToolStripMenuItem.Text = "RegLibOffice";
            this.regLibOfficeToolStripMenuItem.Click += new System.EventHandler(this.RigesterCOMfix);
            // 
            // universalReaderToolStripMenu
            // 
            this.universalReaderToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.xFAReaderToolStripMenuItem});
            this.universalReaderToolStripMenu.Name = "universalReaderToolStripMenu";
            this.universalReaderToolStripMenu.Size = new System.Drawing.Size(106, 20);
            this.universalReaderToolStripMenu.Text = "Universal Reader";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.FileWriter);
            // 
            // xFAReaderToolStripMenuItem
            // 
            this.xFAReaderToolStripMenuItem.Enabled = false;
            this.xFAReaderToolStripMenuItem.Name = "xFAReaderToolStripMenuItem";
            this.xFAReaderToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.xFAReaderToolStripMenuItem.Text = "XFA reader";
            // 
            // MenuAbout
            // 
            this.MenuAbout.Name = "MenuAbout";
            this.MenuAbout.Size = new System.Drawing.Size(52, 20);
            this.MenuAbout.Text = "About";
            this.MenuAbout.Click += new System.EventHandler(this.aboutShow);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.OptionsMenu,
            this.universalReaderToolStripMenu,
            this.MenuAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1047, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // splitContainer_bigMain
            // 
            this.splitContainer_bigMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer_bigMain.Location = new System.Drawing.Point(3, 34);
            this.splitContainer_bigMain.Name = "splitContainer_bigMain";
            // 
            // splitContainer_bigMain.Panel1
            // 
            this.splitContainer_bigMain.Panel1.Controls.Add(this.splitContainer_dataGrids);
            this.splitContainer_bigMain.Panel1MinSize = 90;
            // 
            // splitContainer_bigMain.Panel2
            // 
            this.splitContainer_bigMain.Panel2.Controls.Add(this.splitContainer_rightProps);
            this.splitContainer_bigMain.Panel2MinSize = 285;
            this.splitContainer_bigMain.Size = new System.Drawing.Size(1033, 553);
            this.splitContainer_bigMain.SplitterDistance = 744;
            this.splitContainer_bigMain.TabIndex = 75;
            // 
            // splitContainer_dataGrids
            // 
            this.splitContainer_dataGrids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_dataGrids.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_dataGrids.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_dataGrids.Name = "splitContainer_dataGrids";
            this.splitContainer_dataGrids.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_dataGrids.Panel1
            // 
            this.splitContainer_dataGrids.Panel1.Controls.Add(this.CellViewer);
            // 
            // splitContainer_dataGrids.Panel2
            // 
            this.splitContainer_dataGrids.Panel2.Controls.Add(this.dataViewer);
            this.splitContainer_dataGrids.Size = new System.Drawing.Size(744, 553);
            this.splitContainer_dataGrids.SplitterDistance = 25;
            this.splitContainer_dataGrids.TabIndex = 2;
            // 
            // CellViewer
            // 
            this.CellViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CellViewer.Location = new System.Drawing.Point(0, 0);
            this.CellViewer.Multiline = true;
            this.CellViewer.Name = "CellViewer";
            this.CellViewer.ReadOnly = true;
            this.CellViewer.Size = new System.Drawing.Size(744, 25);
            this.CellViewer.TabIndex = 0;
            // 
            // SectionsControl
            // 
            this.SectionsControl.Controls.Add(this.tabExcel);
            this.SectionsControl.Controls.Add(this.tabMicrogeneration);
            this.SectionsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SectionsControl.Location = new System.Drawing.Point(0, 24);
            this.SectionsControl.Name = "SectionsControl";
            this.SectionsControl.SelectedIndex = 0;
            this.SectionsControl.Size = new System.Drawing.Size(1047, 618);
            this.SectionsControl.TabIndex = 76;
            this.SectionsControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.SectionsControl_Selected);
            // 
            // tabExcel
            // 
            this.tabExcel.BackColor = System.Drawing.Color.Transparent;
            this.tabExcel.Controls.Add(this.urToolStrip);
            this.tabExcel.Controls.Add(this.splitContainer_bigMain);
            this.tabExcel.Location = new System.Drawing.Point(4, 24);
            this.tabExcel.Name = "tabExcel";
            this.tabExcel.Padding = new System.Windows.Forms.Padding(3);
            this.tabExcel.Size = new System.Drawing.Size(1039, 590);
            this.tabExcel.TabIndex = 0;
            this.tabExcel.Text = "ExcelReader";
            // 
            // urToolStrip
            // 
            this.urToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.urBtnImportFile,
            this.toolStripSeparator2,
            this.urBtnSaveXML,
            this.urBtnConvert2Tree});
            this.urToolStrip.Location = new System.Drawing.Point(3, 3);
            this.urToolStrip.Name = "urToolStrip";
            this.urToolStrip.Size = new System.Drawing.Size(1033, 25);
            this.urToolStrip.TabIndex = 76;
            this.urToolStrip.Text = "mgTools";
            // 
            // urBtnImportFile
            // 
            this.urBtnImportFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.urBtnImportFile.Image = ((System.Drawing.Image)(resources.GetObject("urBtnImportFile.Image")));
            this.urBtnImportFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.urBtnImportFile.Name = "urBtnImportFile";
            this.urBtnImportFile.Size = new System.Drawing.Size(32, 22);
            this.urBtnImportFile.Text = "ImportFile";
            this.urBtnImportFile.ButtonClick += new System.EventHandler(this.urBtnImportFile_ButtonClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // urBtnSaveXML
            // 
            this.urBtnSaveXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.urBtnSaveXML.Enabled = false;
            this.urBtnSaveXML.Image = ((System.Drawing.Image)(resources.GetObject("urBtnSaveXML.Image")));
            this.urBtnSaveXML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.urBtnSaveXML.Name = "urBtnSaveXML";
            this.urBtnSaveXML.Size = new System.Drawing.Size(23, 22);
            this.urBtnSaveXML.Text = "Export to XML";
            this.urBtnSaveXML.Click += new System.EventHandler(this.urBtnSaveXML_Click);
            // 
            // urBtnConvert2Tree
            // 
            this.urBtnConvert2Tree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.urBtnConvert2Tree.Enabled = false;
            this.urBtnConvert2Tree.Image = ((System.Drawing.Image)(resources.GetObject("urBtnConvert2Tree.Image")));
            this.urBtnConvert2Tree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.urBtnConvert2Tree.Name = "urBtnConvert2Tree";
            this.urBtnConvert2Tree.Size = new System.Drawing.Size(23, 22);
            this.urBtnConvert2Tree.Text = "Tree View";
            this.urBtnConvert2Tree.Click += new System.EventHandler(this.urBtnConvert2Tree_Click);
            // 
            // tabMicrogeneration
            // 
            this.tabMicrogeneration.BackColor = System.Drawing.SystemColors.Control;
            this.tabMicrogeneration.Controls.Add(this.mgToolStrip);
            this.tabMicrogeneration.Controls.Add(this.mgSplitContainer_vertical);
            this.tabMicrogeneration.Location = new System.Drawing.Point(4, 24);
            this.tabMicrogeneration.Name = "tabMicrogeneration";
            this.tabMicrogeneration.Padding = new System.Windows.Forms.Padding(3);
            this.tabMicrogeneration.Size = new System.Drawing.Size(1039, 590);
            this.tabMicrogeneration.TabIndex = 1;
            this.tabMicrogeneration.Text = "Microgeneration";
            // 
            // mgToolStrip
            // 
            this.mgToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mgBtnImportFile,
            this.toolStripSeparator1,
            this.toolBtnConvertFile,
            this.toolBtnDictionaryList,
            this.toolBtnDictionaryEditor});
            this.mgToolStrip.Location = new System.Drawing.Point(3, 3);
            this.mgToolStrip.Name = "mgToolStrip";
            this.mgToolStrip.Size = new System.Drawing.Size(1033, 25);
            this.mgToolStrip.TabIndex = 4;
            this.mgToolStrip.Text = "mgTools";
            // 
            // mgBtnImportFile
            // 
            this.mgBtnImportFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mgBtnImportFile.Image = ((System.Drawing.Image)(resources.GetObject("mgBtnImportFile.Image")));
            this.mgBtnImportFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mgBtnImportFile.Name = "mgBtnImportFile";
            this.mgBtnImportFile.Size = new System.Drawing.Size(32, 22);
            this.mgBtnImportFile.Text = "ImportFile";
            this.mgBtnImportFile.ButtonClick += new System.EventHandler(this.mgBtnImportFile_ButtonClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolBtnConvertFile
            // 
            this.toolBtnConvertFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnConvertFile.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnConvertFile.Image")));
            this.toolBtnConvertFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnConvertFile.Name = "toolBtnConvertFile";
            this.toolBtnConvertFile.Size = new System.Drawing.Size(32, 22);
            this.toolBtnConvertFile.Text = "ConvertFile";
            this.toolBtnConvertFile.ButtonClick += new System.EventHandler(this.toolBtnConvertFile_ButtonClick);
            // 
            // toolBtnDictionaryList
            // 
            this.toolBtnDictionaryList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnDictionaryList.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnDictionaryList.Image")));
            this.toolBtnDictionaryList.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolBtnDictionaryList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnDictionaryList.Name = "toolBtnDictionaryList";
            this.toolBtnDictionaryList.Size = new System.Drawing.Size(23, 22);
            this.toolBtnDictionaryList.Text = "DictionaryList";
            this.toolBtnDictionaryList.Click += new System.EventHandler(this.OpenDictionaryList_Click);
            // 
            // toolBtnDictionaryEditor
            // 
            this.toolBtnDictionaryEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnDictionaryEditor.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnDictionaryEditor.Image")));
            this.toolBtnDictionaryEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnDictionaryEditor.Name = "toolBtnDictionaryEditor";
            this.toolBtnDictionaryEditor.Size = new System.Drawing.Size(23, 22);
            this.toolBtnDictionaryEditor.Text = "DictionaryEditor";
            this.toolBtnDictionaryEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // mgSplitContainer_vertical
            // 
            this.mgSplitContainer_vertical.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mgSplitContainer_vertical.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.mgSplitContainer_vertical.Location = new System.Drawing.Point(3, 31);
            this.mgSplitContainer_vertical.Name = "mgSplitContainer_vertical";
            // 
            // mgSplitContainer_vertical.Panel1
            // 
            this.mgSplitContainer_vertical.Panel1.Controls.Add(this.mgSplitContainer_horizontal);
            this.mgSplitContainer_vertical.Panel1MinSize = 300;
            this.mgSplitContainer_vertical.Panel2MinSize = 285;
            this.mgSplitContainer_vertical.Size = new System.Drawing.Size(1033, 556);
            this.mgSplitContainer_vertical.SplitterDistance = 744;
            this.mgSplitContainer_vertical.TabIndex = 0;
            // 
            // mgSplitContainer_horizontal
            // 
            this.mgSplitContainer_horizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mgSplitContainer_horizontal.Location = new System.Drawing.Point(0, 0);
            this.mgSplitContainer_horizontal.Name = "mgSplitContainer_horizontal";
            this.mgSplitContainer_horizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mgSplitContainer_horizontal.Panel1
            // 
            this.mgSplitContainer_horizontal.Panel1.Controls.Add(this.MounthTab);
            this.mgSplitContainer_horizontal.Panel1MinSize = 100;
            // 
            // mgSplitContainer_horizontal.Panel2
            // 
            this.mgSplitContainer_horizontal.Panel2.Controls.Add(this.mgWorkDataViewer);
            this.mgSplitContainer_horizontal.Panel2MinSize = 100;
            this.mgSplitContainer_horizontal.Size = new System.Drawing.Size(744, 556);
            this.mgSplitContainer_horizontal.SplitterDistance = 396;
            this.mgSplitContainer_horizontal.TabIndex = 3;
            // 
            // MounthTab
            // 
            this.MounthTab.Controls.Add(this.January);
            this.MounthTab.Controls.Add(this.February);
            this.MounthTab.Controls.Add(this.March);
            this.MounthTab.Controls.Add(this.April);
            this.MounthTab.Controls.Add(this.May);
            this.MounthTab.Controls.Add(this.June);
            this.MounthTab.Controls.Add(this.July);
            this.MounthTab.Controls.Add(this.August);
            this.MounthTab.Controls.Add(this.September);
            this.MounthTab.Controls.Add(this.October);
            this.MounthTab.Controls.Add(this.November);
            this.MounthTab.Controls.Add(this.December);
            this.MounthTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MounthTab.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MounthTab.Location = new System.Drawing.Point(0, 0);
            this.MounthTab.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.MounthTab.Name = "MounthTab";
            this.MounthTab.SelectedIndex = 0;
            this.MounthTab.Size = new System.Drawing.Size(744, 396);
            this.MounthTab.TabIndex = 2;
            this.MounthTab.Selected += new System.Windows.Forms.TabControlEventHandler(this.MounthTab_Selected);
            // 
            // January
            // 
            this.January.BackColor = System.Drawing.Color.Transparent;
            this.January.Controls.Add(this.mgDataViewer);
            this.January.Location = new System.Drawing.Point(4, 25);
            this.January.Name = "January";
            this.January.Padding = new System.Windows.Forms.Padding(3);
            this.January.Size = new System.Drawing.Size(736, 367);
            this.January.TabIndex = 0;
            this.January.Text = "January";
            // 
            // mgDataViewer
            // 
            this.mgDataViewer.AllowUserToAddRows = false;
            this.mgDataViewer.AllowUserToDeleteRows = false;
            this.mgDataViewer.AllowUserToResizeRows = false;
            this.mgDataViewer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.mgDataViewer.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.mgDataViewer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mgDataViewer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.mgDataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mgDataViewer.DefaultCellStyle = dataGridViewCellStyle13;
            this.mgDataViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mgDataViewer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.mgDataViewer.EnableHeadersVisualStyles = false;
            this.mgDataViewer.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mgDataViewer.Location = new System.Drawing.Point(3, 3);
            this.mgDataViewer.MultiSelect = false;
            this.mgDataViewer.Name = "mgDataViewer";
            this.mgDataViewer.ReadOnly = true;
            this.mgDataViewer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mgDataViewer.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.mgDataViewer.RowHeadersWidth = 20;
            this.mgDataViewer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.mgDataViewer.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.mgDataViewer.RowTemplate.Height = 25;
            this.mgDataViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.mgDataViewer.Size = new System.Drawing.Size(730, 361);
            this.mgDataViewer.TabIndex = 2;
            // 
            // February
            // 
            this.February.BackColor = System.Drawing.Color.Transparent;
            this.February.Location = new System.Drawing.Point(4, 25);
            this.February.Name = "February";
            this.February.Padding = new System.Windows.Forms.Padding(3);
            this.February.Size = new System.Drawing.Size(736, 367);
            this.February.TabIndex = 1;
            this.February.Text = "February";
            // 
            // March
            // 
            this.March.Location = new System.Drawing.Point(4, 25);
            this.March.Name = "March";
            this.March.Padding = new System.Windows.Forms.Padding(3);
            this.March.Size = new System.Drawing.Size(736, 367);
            this.March.TabIndex = 2;
            this.March.Text = "March";
            this.March.UseVisualStyleBackColor = true;
            // 
            // April
            // 
            this.April.Location = new System.Drawing.Point(4, 25);
            this.April.Name = "April";
            this.April.Padding = new System.Windows.Forms.Padding(3);
            this.April.Size = new System.Drawing.Size(736, 367);
            this.April.TabIndex = 3;
            this.April.Text = "April";
            this.April.UseVisualStyleBackColor = true;
            // 
            // May
            // 
            this.May.Location = new System.Drawing.Point(4, 25);
            this.May.Name = "May";
            this.May.Padding = new System.Windows.Forms.Padding(3);
            this.May.Size = new System.Drawing.Size(736, 367);
            this.May.TabIndex = 4;
            this.May.Text = "May";
            this.May.UseVisualStyleBackColor = true;
            // 
            // June
            // 
            this.June.Location = new System.Drawing.Point(4, 25);
            this.June.Name = "June";
            this.June.Padding = new System.Windows.Forms.Padding(3);
            this.June.Size = new System.Drawing.Size(736, 367);
            this.June.TabIndex = 5;
            this.June.Text = "June";
            this.June.UseVisualStyleBackColor = true;
            // 
            // July
            // 
            this.July.Location = new System.Drawing.Point(4, 25);
            this.July.Name = "July";
            this.July.Padding = new System.Windows.Forms.Padding(3);
            this.July.Size = new System.Drawing.Size(736, 367);
            this.July.TabIndex = 6;
            this.July.Text = "July";
            this.July.UseVisualStyleBackColor = true;
            // 
            // August
            // 
            this.August.Location = new System.Drawing.Point(4, 25);
            this.August.Name = "August";
            this.August.Padding = new System.Windows.Forms.Padding(3);
            this.August.Size = new System.Drawing.Size(736, 367);
            this.August.TabIndex = 7;
            this.August.Text = "August";
            this.August.UseVisualStyleBackColor = true;
            // 
            // September
            // 
            this.September.Location = new System.Drawing.Point(4, 25);
            this.September.Name = "September";
            this.September.Padding = new System.Windows.Forms.Padding(3);
            this.September.Size = new System.Drawing.Size(736, 367);
            this.September.TabIndex = 8;
            this.September.Text = "September";
            this.September.UseVisualStyleBackColor = true;
            // 
            // October
            // 
            this.October.Location = new System.Drawing.Point(4, 25);
            this.October.Name = "October";
            this.October.Padding = new System.Windows.Forms.Padding(3);
            this.October.Size = new System.Drawing.Size(736, 367);
            this.October.TabIndex = 9;
            this.October.Text = "October";
            this.October.UseVisualStyleBackColor = true;
            // 
            // November
            // 
            this.November.Location = new System.Drawing.Point(4, 25);
            this.November.Name = "November";
            this.November.Padding = new System.Windows.Forms.Padding(3);
            this.November.Size = new System.Drawing.Size(736, 367);
            this.November.TabIndex = 10;
            this.November.Text = "November";
            this.November.UseVisualStyleBackColor = true;
            // 
            // December
            // 
            this.December.Location = new System.Drawing.Point(4, 25);
            this.December.Name = "December";
            this.December.Padding = new System.Windows.Forms.Padding(3);
            this.December.Size = new System.Drawing.Size(736, 367);
            this.December.TabIndex = 11;
            this.December.Text = "December";
            this.December.UseVisualStyleBackColor = true;
            // 
            // mgWorkDataViewer
            // 
            this.mgWorkDataViewer.AllowUserToAddRows = false;
            this.mgWorkDataViewer.AllowUserToDeleteRows = false;
            this.mgWorkDataViewer.AllowUserToResizeRows = false;
            this.mgWorkDataViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mgWorkDataViewer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.mgWorkDataViewer.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.mgWorkDataViewer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mgWorkDataViewer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.mgWorkDataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mgWorkDataViewer.DefaultCellStyle = dataGridViewCellStyle17;
            this.mgWorkDataViewer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.mgWorkDataViewer.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mgWorkDataViewer.Location = new System.Drawing.Point(7, 0);
            this.mgWorkDataViewer.MultiSelect = false;
            this.mgWorkDataViewer.Name = "mgWorkDataViewer";
            this.mgWorkDataViewer.ReadOnly = true;
            this.mgWorkDataViewer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mgWorkDataViewer.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.mgWorkDataViewer.RowHeadersWidth = 20;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.mgWorkDataViewer.RowsDefaultCellStyle = dataGridViewCellStyle19;
            this.mgWorkDataViewer.RowTemplate.Height = 25;
            this.mgWorkDataViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.mgWorkDataViewer.Size = new System.Drawing.Size(730, 156);
            this.mgWorkDataViewer.TabIndex = 3;
            this.mgWorkDataViewer.DragDrop += new System.Windows.Forms.DragEventHandler(this.mgWorkDataViewer_DragDrop);
            this.mgWorkDataViewer.DragEnter += new System.Windows.Forms.DragEventHandler(this.mgWorkDataViewer_DragEnter);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1047, 666);
            this.Controls.Add(this.SectionsControl);
            this.Controls.Add(this.BackUserMessanger);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.Text = "universalReader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.RowContext.ResumeLayout(false);
            this.propGrid_stripMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BackUserMessanger)).EndInit();
            this.CellContext.ResumeLayout(false);
            this.ColumnContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusGridView)).EndInit();
            this.splitContainer_rightProps.Panel1.ResumeLayout(false);
            this.splitContainer_rightProps.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_rightProps)).EndInit();
            this.splitContainer_rightProps.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer_bigMain.Panel1.ResumeLayout(false);
            this.splitContainer_bigMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_bigMain)).EndInit();
            this.splitContainer_bigMain.ResumeLayout(false);
            this.splitContainer_dataGrids.Panel1.ResumeLayout(false);
            this.splitContainer_dataGrids.Panel1.PerformLayout();
            this.splitContainer_dataGrids.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_dataGrids)).EndInit();
            this.splitContainer_dataGrids.ResumeLayout(false);
            this.SectionsControl.ResumeLayout(false);
            this.tabExcel.ResumeLayout(false);
            this.tabExcel.PerformLayout();
            this.urToolStrip.ResumeLayout(false);
            this.urToolStrip.PerformLayout();
            this.tabMicrogeneration.ResumeLayout(false);
            this.tabMicrogeneration.PerformLayout();
            this.mgToolStrip.ResumeLayout(false);
            this.mgToolStrip.PerformLayout();
            this.mgSplitContainer_vertical.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mgSplitContainer_vertical)).EndInit();
            this.mgSplitContainer_vertical.ResumeLayout(false);
            this.mgSplitContainer_horizontal.Panel1.ResumeLayout(false);
            this.mgSplitContainer_horizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mgSplitContainer_horizontal)).EndInit();
            this.mgSplitContainer_horizontal.ResumeLayout(false);
            this.MounthTab.ResumeLayout(false);
            this.January.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mgDataViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgWorkDataViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ContextMenuStrip RowContext;
        private ToolStripMenuItem RightClick_HeadsRow;
        private ToolStripMenuItem RightClick_FirstRowData;
        private PropertyGrid optionsGrid;
        private PictureBox BackUserMessanger;
        private ContextMenuStrip CellContext;
        private ContextMenuStrip ColumnContext;
        private ToolStripMenuItem setAsColumn4CheckToolStripMenuItem;
        private ToolStripMenuItem setAsStaticValueToolStripMenuItem;
        private DataGridView dataViewer;
        private StatusGridViewEditMode statusGridView;
        private SplitContainer splitContainer_rightProps;
        private FontDialog fontDialog1;
        private ContextMenuStrip propGrid_stripMenu;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem FileMenu;
        private ToolStripMenuItem importXMLToolStripMenuItem;
        private ToolStripMenuItem OptionsMenu;
        private ToolStripMenuItem showConsoleToolStripMenuItem;
        private ToolStripMenuItem closeAllExcelsToolStripMenuItem;
        private ToolStripMenuItem universalReaderToolStripMenu;
        private ToolStripMenuItem openFileToolStripMenuItem;
        private ToolStripMenuItem MenuAbout;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem regLibOfficeToolStripMenuItem;
        private SplitContainer splitContainer_bigMain;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private ToolStripMenuItem xFAReaderToolStripMenuItem;
        private TabControl SectionsControl;
        private TabPage tabExcel;
        private ContextMenuStrip contextMenuStrip1;
        private SplitContainer splitContainer_dataGrids;
        private TextBox CellViewer;
        private ToolStripMenuItem ExitUR;
        private TabPage tabMicrogeneration;
        private SplitContainer mgSplitContainer_vertical;
        private TabControl MounthTab;
        private TabPage January;
        private DataGridView mgDataViewer;
        private TabPage February;
        private TabPage March;
        private TabPage April;
        private TabPage May;
        private TabPage June;
        private TabPage July;
        private TabPage August;
        private TabPage September;
        private TabPage October;
        private TabPage November;
        private TabPage December;
        private ToolStrip mgToolStrip;
        private ToolStripSplitButton mgBtnImportFile;
        private ToolStripButton toolBtnDictionaryList;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolBtnDictionaryEditor;
        private ToolStrip urToolStrip;
        private ToolStripSplitButton urBtnImportFile;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSplitButton toolBtnConvertFile;
        private SplitContainer mgSplitContainer_horizontal;
        private DataGridView mgWorkDataViewer;
        private ToolStripButton urBtnSaveXML;
        private ToolStripButton urBtnConvert2Tree;
    }
}