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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("treeViewLine1", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("treeViewLine2", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("treeViewLine3", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("ночная зона суток", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("полупиковая зона суток", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("пиковая зона суток", new System.Windows.Forms.TreeNode[] {
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("treeViewLine4", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode10,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("ночная зона суток", new System.Windows.Forms.TreeNode[] {
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("дневная зона суток", new System.Windows.Forms.TreeNode[] {
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("treeViewLine5", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("ночная зона суток", new System.Windows.Forms.TreeNode[] {
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("полупиковая зона суток", new System.Windows.Forms.TreeNode[] {
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("пиковая зона суток", new System.Windows.Forms.TreeNode[] {
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("treeViewLine6", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode22,
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("ночная зона суток", new System.Windows.Forms.TreeNode[] {
            treeNode26});
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("дневная зона суток", new System.Windows.Forms.TreeNode[] {
            treeNode28});
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("treeViewLine7", new System.Windows.Forms.TreeNode[] {
            treeNode27,
            treeNode29});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.RowContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RightClick_HeadsRow = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClick_FirstRowData = new System.Windows.Forms.ToolStripMenuItem();
            this.propGrid_stripMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CellContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAsStaticValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAsColumn4CheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.importXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitUR = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.showConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllExcelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regLibOfficeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.universalReaderToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xFAReaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabMicrogeneration = new System.Windows.Forms.TabPage();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblMainName = new System.Windows.Forms.Label();
            this.mgSplitContainer_insideHorizontal = new System.Windows.Forms.SplitContainer();
            this.mgSplitContainer_inside_vertical = new System.Windows.Forms.SplitContainer();
            this.groupBoxTable = new System.Windows.Forms.GroupBox();
            this.mgDataViewer = new dataEditor.MainForm.DoubleBufferedDataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectID = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataExcel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataAct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GlobalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Agreement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateAgreement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TariffZone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SELL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BUY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NDS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Method = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.intgStatusError = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hrsStatusError = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FlowTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.mgFlowPanelResult = new System.Windows.Forms.FlowLayoutPanel();
            this.FlowPanelTools = new System.Windows.Forms.ToolStrip();
            this.FlowPanelButtonAddTable = new System.Windows.Forms.ToolStripButton();
            this.FlowPanelButtonDeleteAllTables = new System.Windows.Forms.ToolStripButton();
            this.inputTableLoyaut = new System.Windows.Forms.TableLayoutPanel();
            this.datsTreeView = new System.Windows.Forms.TreeView();
            this.mgToolStripInputData = new System.Windows.Forms.ToolStrip();
            this.mgBtnEntryDatFiles = new System.Windows.Forms.ToolStripSplitButton();
            this.mgFileSPUNC = new System.Windows.Forms.ToolStripMenuItem();
            this.mgFileSVNC = new System.Windows.Forms.ToolStripMenuItem();
            this.mgFileKF = new System.Windows.Forms.ToolStripMenuItem();
            this.mgFileSPUNCbtn = new System.Windows.Forms.ToolStripButton();
            this.mgFileSPUNCselector = new System.Windows.Forms.ToolStripComboBox();
            this.mgFileSVNCbtn = new System.Windows.Forms.ToolStripButton();
            this.mgFileKFbtn = new System.Windows.Forms.ToolStripButton();
            this.imgStatusOk = new System.Windows.Forms.ToolStripButton();
            this.imgStatusDwnld = new System.Windows.Forms.ToolStripButton();
            this.imgStatusFailed = new System.Windows.Forms.ToolStripButton();
            this.mgMainToolStrip = new System.Windows.Forms.ToolStrip();
            this.mgBtnNewProject = new System.Windows.Forms.ToolStripButton();
            this.mgBtnOpenFile = new System.Windows.Forms.ToolStripButton();
            this.mgBtnSaveDats = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mgBtnImportFile = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnDictionaryList = new System.Windows.Forms.ToolStripButton();
            this.toolBtnDictionaryEditor = new System.Windows.Forms.ToolStripButton();
            this.mgBtnOpenFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnStartProccess = new System.Windows.Forms.ToolStripButton();
            this.mgOpenDataTable = new System.Windows.Forms.ToolStripButton();
            this.mgDataСalculation = new System.Windows.Forms.ToolStripButton();
            this.mgDataAct = new System.Windows.Forms.ToolStripButton();
            this.tabControlCurrentProject = new System.Windows.Forms.TabControl();
            this.tabBasic = new System.Windows.Forms.TabPage();
            this.upperTableLayoutMainData = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.textBoxGTPcode = new System.Windows.Forms.TextBox();
            this.textBoxNameGP = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblGTPcode = new System.Windows.Forms.Label();
            this.lblNameGP = new System.Windows.Forms.Label();
            this.tabDetail = new System.Windows.Forms.TabPage();
            this.groupBoxProp = new System.Windows.Forms.GroupBox();
            this.propTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbxMethod = new System.Windows.Forms.ComboBox();
            this.groupBoxRes = new System.Windows.Forms.GroupBox();
            this.ResourcesTreeView = new System.Windows.Forms.TreeView();
            this.imgListData = new System.Windows.Forms.ImageList(this.components);
            this.ProjectInfoBox = new System.Windows.Forms.GroupBox();
            this.ProjectInfoTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.txtProjectInfoName = new System.Windows.Forms.TextBox();
            this.txtProjectMonth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProjectYear = new System.Windows.Forms.TextBox();
            this.appInfo = new System.Windows.Forms.Label();
            this.tabExcel = new System.Windows.Forms.TabPage();
            this.urToolStrip = new System.Windows.Forms.ToolStrip();
            this.urBtnImportFile = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.urBtnSaveXML = new System.Windows.Forms.ToolStripButton();
            this.urBtnConvert2Tree = new System.Windows.Forms.ToolStripButton();
            this.splitContainer_bigMain = new System.Windows.Forms.SplitContainer();
            this.splitContainer_dataGrids = new System.Windows.Forms.SplitContainer();
            this.CellViewer = new System.Windows.Forms.TextBox();
            this.dataViewer = new dataEditor.MainForm.DoubleBufferedDataGridView();
            this.splitContainer_rightProps = new System.Windows.Forms.SplitContainer();
            this.statusGridView = new dataEditor.MainForm.StatusGridViewEditMode();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urOptionsGrid = new System.Windows.Forms.PropertyGrid();
            this.SectionsControl = new System.Windows.Forms.TabControl();
            this.buttonBackground = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuOpenTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.RowContext.SuspendLayout();
            this.propGrid_stripMenu.SuspendLayout();
            this.CellContext.SuspendLayout();
            this.ColumnContext.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabMicrogeneration.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.MainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mgSplitContainer_insideHorizontal)).BeginInit();
            this.mgSplitContainer_insideHorizontal.Panel1.SuspendLayout();
            this.mgSplitContainer_insideHorizontal.Panel2.SuspendLayout();
            this.mgSplitContainer_insideHorizontal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mgSplitContainer_inside_vertical)).BeginInit();
            this.mgSplitContainer_inside_vertical.Panel1.SuspendLayout();
            this.mgSplitContainer_inside_vertical.Panel2.SuspendLayout();
            this.mgSplitContainer_inside_vertical.SuspendLayout();
            this.groupBoxTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mgDataViewer)).BeginInit();
            this.FlowTableLayout.SuspendLayout();
            this.groupBoxData.SuspendLayout();
            this.FlowPanelTools.SuspendLayout();
            this.inputTableLoyaut.SuspendLayout();
            this.mgToolStripInputData.SuspendLayout();
            this.mgMainToolStrip.SuspendLayout();
            this.tabControlCurrentProject.SuspendLayout();
            this.tabBasic.SuspendLayout();
            this.upperTableLayoutMainData.SuspendLayout();
            this.tabDetail.SuspendLayout();
            this.groupBoxProp.SuspendLayout();
            this.propTableLayout.SuspendLayout();
            this.groupBoxRes.SuspendLayout();
            this.ProjectInfoBox.SuspendLayout();
            this.ProjectInfoTableLayoutPanel.SuspendLayout();
            this.tabExcel.SuspendLayout();
            this.urToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_bigMain)).BeginInit();
            this.splitContainer_bigMain.Panel1.SuspendLayout();
            this.splitContainer_bigMain.Panel2.SuspendLayout();
            this.splitContainer_bigMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_dataGrids)).BeginInit();
            this.splitContainer_dataGrids.Panel1.SuspendLayout();
            this.splitContainer_dataGrids.Panel2.SuspendLayout();
            this.splitContainer_dataGrids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_rightProps)).BeginInit();
            this.splitContainer_rightProps.Panel1.SuspendLayout();
            this.splitContainer_rightProps.Panel2.SuspendLayout();
            this.splitContainer_rightProps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusGridView)).BeginInit();
            this.SectionsControl.SuspendLayout();
            this.buttonBackground.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importXMLToolStripMenuItem,
            this.ExitUR});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(36, 20);
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
            this.ExitUR.Image = ((System.Drawing.Image)(resources.GetObject("ExitUR.Image")));
            this.ExitUR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
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
            this.regLibOfficeToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.Size = new System.Drawing.Size(48, 20);
            this.OptionsMenu.Text = "Tools";
            // 
            // showConsoleToolStripMenuItem
            // 
            this.showConsoleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showConsoleToolStripMenuItem.Image")));
            this.showConsoleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showConsoleToolStripMenuItem.Name = "showConsoleToolStripMenuItem";
            this.showConsoleToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.showConsoleToolStripMenuItem.Text = "Show Console";
            this.showConsoleToolStripMenuItem.Click += new System.EventHandler(this.ShowConsole_Click);
            // 
            // closeAllExcelsToolStripMenuItem
            // 
            this.closeAllExcelsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeAllExcelsToolStripMenuItem.Image")));
            this.closeAllExcelsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.closeAllExcelsToolStripMenuItem.Name = "closeAllExcelsToolStripMenuItem";
            this.closeAllExcelsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.closeAllExcelsToolStripMenuItem.Text = "Close all Excel";
            this.closeAllExcelsToolStripMenuItem.Click += new System.EventHandler(this.CloseAllExcel_Click);
            // 
            // regLibOfficeToolStripMenuItem
            // 
            this.regLibOfficeToolStripMenuItem.Enabled = false;
            this.regLibOfficeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.regLibOfficeToolStripMenuItem.Name = "regLibOfficeToolStripMenuItem";
            this.regLibOfficeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.regLibOfficeToolStripMenuItem.Text = "RegLibOffice";
            this.regLibOfficeToolStripMenuItem.Click += new System.EventHandler(this.RigesterCOMfix);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("settingsToolStripMenuItem.Image")));
            this.settingsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // universalReaderToolStripMenu
            // 
            this.universalReaderToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.xFAReaderToolStripMenuItem});
            this.universalReaderToolStripMenu.Name = "universalReaderToolStripMenu";
            this.universalReaderToolStripMenu.Size = new System.Drawing.Size(108, 20);
            this.universalReaderToolStripMenu.Text = "Universal Reader";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.FileWriter);
            // 
            // xFAReaderToolStripMenuItem
            // 
            this.xFAReaderToolStripMenuItem.Enabled = false;
            this.xFAReaderToolStripMenuItem.Name = "xFAReaderToolStripMenuItem";
            this.xFAReaderToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.xFAReaderToolStripMenuItem.Text = "XFA reader";
            // 
            // MenuAbout
            // 
            this.MenuAbout.Name = "MenuAbout";
            this.MenuAbout.Size = new System.Drawing.Size(53, 20);
            this.MenuAbout.Text = "About";
            this.MenuAbout.Click += new System.EventHandler(this.aboutShow);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.OptionsMenu,
            this.universalReaderToolStripMenu,
            this.MenuAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabMicrogeneration
            // 
            this.tabMicrogeneration.Controls.Add(this.MainPanel);
            this.tabMicrogeneration.Location = new System.Drawing.Point(4, 24);
            this.tabMicrogeneration.Name = "tabMicrogeneration";
            this.tabMicrogeneration.Padding = new System.Windows.Forms.Padding(1);
            this.tabMicrogeneration.Size = new System.Drawing.Size(1176, 584);
            this.tabMicrogeneration.TabIndex = 1;
            this.tabMicrogeneration.Text = "Microgeneration";
            // 
            // MainPanel
            // 
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Controls.Add(this.MainTableLayoutPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(1, 1);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(1);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1174, 582);
            this.MainPanel.TabIndex = 6;
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.AutoSize = true;
            this.MainTableLayoutPanel.ColumnCount = 2;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 724F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.MainTableLayoutPanel.Controls.Add(this.lblMainName, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.mgSplitContainer_insideHorizontal, 0, 3);
            this.MainTableLayoutPanel.Controls.Add(this.mgMainToolStrip, 0, 1);
            this.MainTableLayoutPanel.Controls.Add(this.tabControlCurrentProject, 0, 2);
            this.MainTableLayoutPanel.Controls.Add(this.ProjectInfoBox, 1, 2);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(1);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 4;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(1172, 580);
            this.MainTableLayoutPanel.TabIndex = 5;
            // 
            // lblMainName
            // 
            this.lblMainName.AutoSize = true;
            this.lblMainName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MainTableLayoutPanel.SetColumnSpan(this.lblMainName, 2);
            this.lblMainName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMainName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMainName.Location = new System.Drawing.Point(1, 1);
            this.lblMainName.Margin = new System.Windows.Forms.Padding(1);
            this.lblMainName.Name = "lblMainName";
            this.lblMainName.Size = new System.Drawing.Size(1170, 23);
            this.lblMainName.TabIndex = 1;
            this.lblMainName.Text = "Transaction MKG_REALESE_CLOSE: june 2023";
            this.lblMainName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mgSplitContainer_insideHorizontal
            // 
            this.MainTableLayoutPanel.SetColumnSpan(this.mgSplitContainer_insideHorizontal, 2);
            this.mgSplitContainer_insideHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mgSplitContainer_insideHorizontal.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.mgSplitContainer_insideHorizontal.Location = new System.Drawing.Point(3, 180);
            this.mgSplitContainer_insideHorizontal.Name = "mgSplitContainer_insideHorizontal";
            this.mgSplitContainer_insideHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mgSplitContainer_insideHorizontal.Panel1
            // 
            this.mgSplitContainer_insideHorizontal.Panel1.AutoScroll = true;
            this.mgSplitContainer_insideHorizontal.Panel1.Controls.Add(this.mgSplitContainer_inside_vertical);
            this.mgSplitContainer_insideHorizontal.Panel1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.mgSplitContainer_insideHorizontal.Panel1MinSize = 150;
            // 
            // mgSplitContainer_insideHorizontal.Panel2
            // 
            this.mgSplitContainer_insideHorizontal.Panel2.Controls.Add(this.inputTableLoyaut);
            this.mgSplitContainer_insideHorizontal.Panel2.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.mgSplitContainer_insideHorizontal.Size = new System.Drawing.Size(1166, 397);
            this.mgSplitContainer_insideHorizontal.SplitterDistance = 368;
            this.mgSplitContainer_insideHorizontal.TabIndex = 3;
            this.mgSplitContainer_insideHorizontal.Paint += new System.Windows.Forms.PaintEventHandler(this.SplitterPaint);
            // 
            // mgSplitContainer_inside_vertical
            // 
            this.mgSplitContainer_inside_vertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mgSplitContainer_inside_vertical.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.mgSplitContainer_inside_vertical.Location = new System.Drawing.Point(0, 1);
            this.mgSplitContainer_inside_vertical.Name = "mgSplitContainer_inside_vertical";
            // 
            // mgSplitContainer_inside_vertical.Panel1
            // 
            this.mgSplitContainer_inside_vertical.Panel1.Controls.Add(this.groupBoxTable);
            this.mgSplitContainer_inside_vertical.Panel1MinSize = 500;
            // 
            // mgSplitContainer_inside_vertical.Panel2
            // 
            this.mgSplitContainer_inside_vertical.Panel2.Controls.Add(this.FlowTableLayout);
            this.mgSplitContainer_inside_vertical.Panel2MinSize = 200;
            this.mgSplitContainer_inside_vertical.Size = new System.Drawing.Size(1166, 366);
            this.mgSplitContainer_inside_vertical.SplitterDistance = 956;
            this.mgSplitContainer_inside_vertical.TabIndex = 0;
            // 
            // groupBoxTable
            // 
            this.groupBoxTable.AutoSize = true;
            this.groupBoxTable.Controls.Add(this.mgDataViewer);
            this.groupBoxTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTable.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxTable.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTable.Name = "groupBoxTable";
            this.groupBoxTable.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
            this.groupBoxTable.Size = new System.Drawing.Size(956, 366);
            this.groupBoxTable.TabIndex = 3;
            this.groupBoxTable.TabStop = false;
            this.groupBoxTable.Text = "Abonents: Selected - / -";
            this.groupBoxTable.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_Paint);
            // 
            // mgDataViewer
            // 
            this.mgDataViewer.AllowDrop = true;
            this.mgDataViewer.AllowUserToAddRows = false;
            this.mgDataViewer.AllowUserToDeleteRows = false;
            this.mgDataViewer.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.mgDataViewer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.mgDataViewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mgDataViewer.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.mgDataViewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mgDataViewer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mgDataViewer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.mgDataViewer.ColumnHeadersHeight = 25;
            this.mgDataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.mgDataViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.SelectID,
            this.dataTable,
            this.dataExcel,
            this.dataAct,
            this.OpenFolder,
            this.GlobalStatus,
            this.Agreement,
            this.FullName,
            this.DateAgreement,
            this.type,
            this.TariffZone,
            this.NumCC,
            this.REC,
            this.GEN,
            this.SELL,
            this.BUY,
            this.Price,
            this.Cost,
            this.baseDoc,
            this.NDS,
            this.Method,
            this.intgStatusError,
            this.hrsStatusError});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.Format = "N6";
            dataGridViewCellStyle7.NullValue = null;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mgDataViewer.DefaultCellStyle = dataGridViewCellStyle7;
            this.mgDataViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mgDataViewer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.mgDataViewer.EnableHeadersVisualStyles = false;
            this.mgDataViewer.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mgDataViewer.Location = new System.Drawing.Point(2, 19);
            this.mgDataViewer.MultiSelect = false;
            this.mgDataViewer.Name = "mgDataViewer";
            this.mgDataViewer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mgDataViewer.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.mgDataViewer.RowHeadersVisible = false;
            this.mgDataViewer.RowHeadersWidth = 20;
            this.mgDataViewer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.mgDataViewer.RowTemplate.Height = 20;
            this.mgDataViewer.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.mgDataViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mgDataViewer.Size = new System.Drawing.Size(952, 345);
            this.mgDataViewer.TabIndex = 2;
            this.mgDataViewer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mgDataViewer_CellClick);
            this.mgDataViewer.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.mgDataViewer_CellPainting);
            this.mgDataViewer.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.mgDataViewer_RowEnter);
            this.mgDataViewer.SelectionChanged += new System.EventHandler(this.mgDataViewer_SelectionChanged);
            this.mgDataViewer.DragDrop += new System.Windows.Forms.DragEventHandler(this.mgDataViewer_DragDrop);
            this.mgDataViewer.DragEnter += new System.Windows.Forms.DragEventHandler(this.mgDataViewer_DragEnter);
            this.mgDataViewer.DragOver += new System.Windows.Forms.DragEventHandler(this.mgDataViewer_DragOver);
            this.mgDataViewer.DragLeave += new System.EventHandler(this.mgDataViewer_DragLeave);
            this.mgDataViewer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mgDataViewer_MouseDown);
            this.mgDataViewer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mgDataViewer_MouseMove);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.id.DefaultCellStyle = dataGridViewCellStyle3;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Width = 25;
            // 
            // SelectID
            // 
            this.SelectID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SelectID.HeaderText = "Select";
            this.SelectID.MinimumWidth = 25;
            this.SelectID.Name = "SelectID";
            this.SelectID.ReadOnly = true;
            this.SelectID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SelectID.Width = 25;
            // 
            // dataTable
            // 
            this.dataTable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataTable.HeaderText = "Resources";
            this.dataTable.MinimumWidth = 25;
            this.dataTable.Name = "dataTable";
            this.dataTable.ReadOnly = true;
            this.dataTable.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataTable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataTable.Width = 25;
            // 
            // dataExcel
            // 
            this.dataExcel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataExcel.HeaderText = "Excel";
            this.dataExcel.MinimumWidth = 25;
            this.dataExcel.Name = "dataExcel";
            this.dataExcel.ReadOnly = true;
            this.dataExcel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataExcel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataExcel.Width = 25;
            // 
            // dataAct
            // 
            this.dataAct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataAct.HeaderText = "Doc";
            this.dataAct.MinimumWidth = 25;
            this.dataAct.Name = "dataAct";
            this.dataAct.ReadOnly = true;
            this.dataAct.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataAct.Width = 25;
            // 
            // OpenFolder
            // 
            this.OpenFolder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OpenFolder.HeaderText = "Folder";
            this.OpenFolder.MinimumWidth = 25;
            this.OpenFolder.Name = "OpenFolder";
            this.OpenFolder.ReadOnly = true;
            this.OpenFolder.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OpenFolder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OpenFolder.Width = 25;
            // 
            // GlobalStatus
            // 
            this.GlobalStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.GlobalStatus.HeaderText = "Status";
            this.GlobalStatus.Name = "GlobalStatus";
            this.GlobalStatus.ReadOnly = true;
            this.GlobalStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GlobalStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GlobalStatus.ToolTipText = "NotStarted";
            this.GlobalStatus.Width = 25;
            // 
            // Agreement
            // 
            this.Agreement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Agreement.HeaderText = "Agreement";
            this.Agreement.Name = "Agreement";
            this.Agreement.ReadOnly = true;
            this.Agreement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Agreement.Width = 74;
            // 
            // FullName
            // 
            this.FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FullName.HeaderText = "Name";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FullName.Width = 43;
            // 
            // DateAgreement
            // 
            this.DateAgreement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.DateAgreement.DefaultCellStyle = dataGridViewCellStyle4;
            this.DateAgreement.HeaderText = "Date";
            this.DateAgreement.Name = "DateAgreement";
            this.DateAgreement.ReadOnly = true;
            this.DateAgreement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DateAgreement.Width = 38;
            // 
            // type
            // 
            this.type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.type.DefaultCellStyle = dataGridViewCellStyle5;
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.type.Width = 40;
            // 
            // TariffZone
            // 
            this.TariffZone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TariffZone.HeaderText = "Tariff";
            this.TariffZone.Name = "TariffZone";
            this.TariffZone.ReadOnly = true;
            this.TariffZone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TariffZone.Width = 40;
            // 
            // NumCC
            // 
            this.NumCC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NumCC.HeaderText = "№Counter";
            this.NumCC.Name = "NumCC";
            this.NumCC.ReadOnly = true;
            this.NumCC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NumCC.Width = 70;
            // 
            // REC
            // 
            this.REC.HeaderText = "REC";
            this.REC.MinimumWidth = 30;
            this.REC.Name = "REC";
            this.REC.ReadOnly = true;
            this.REC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GEN
            // 
            this.GEN.HeaderText = "GEN";
            this.GEN.MinimumWidth = 30;
            this.GEN.Name = "GEN";
            this.GEN.ReadOnly = true;
            this.GEN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SELL
            // 
            this.SELL.HeaderText = "SELL";
            this.SELL.MinimumWidth = 30;
            this.SELL.Name = "SELL";
            this.SELL.ReadOnly = true;
            this.SELL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BUY
            // 
            this.BUY.HeaderText = "BUY";
            this.BUY.MinimumWidth = 30;
            this.BUY.Name = "BUY";
            this.BUY.ReadOnly = true;
            this.BUY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 30;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Cost
            // 
            this.Cost.HeaderText = "Cost";
            this.Cost.MinimumWidth = 30;
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            this.Cost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // baseDoc
            // 
            this.baseDoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.baseDoc.HeaderText = "base";
            this.baseDoc.Name = "baseDoc";
            this.baseDoc.ReadOnly = true;
            this.baseDoc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.baseDoc.Visible = false;
            this.baseDoc.Width = 25;
            // 
            // NDS
            // 
            this.NDS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NDS.HeaderText = "NDS";
            this.NDS.Name = "NDS";
            this.NDS.ReadOnly = true;
            this.NDS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NDS.Visible = false;
            this.NDS.Width = 25;
            // 
            // Method
            // 
            this.Method.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Method.HeaderText = "Method";
            this.Method.Name = "Method";
            this.Method.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Method.Visible = false;
            this.Method.Width = 50;
            // 
            // intgStatusError
            // 
            this.intgStatusError.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.intgStatusError.DefaultCellStyle = dataGridViewCellStyle6;
            this.intgStatusError.FalseValue = "";
            this.intgStatusError.HeaderText = "intgS";
            this.intgStatusError.IndeterminateValue = "";
            this.intgStatusError.Name = "intgStatusError";
            this.intgStatusError.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.intgStatusError.ThreeState = true;
            this.intgStatusError.TrueValue = "";
            this.intgStatusError.Visible = false;
            this.intgStatusError.Width = 25;
            // 
            // hrsStatusError
            // 
            this.hrsStatusError.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.hrsStatusError.HeaderText = "hrsS";
            this.hrsStatusError.Name = "hrsStatusError";
            this.hrsStatusError.ThreeState = true;
            this.hrsStatusError.Visible = false;
            this.hrsStatusError.Width = 25;
            // 
            // FlowTableLayout
            // 
            this.FlowTableLayout.ColumnCount = 1;
            this.FlowTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FlowTableLayout.Controls.Add(this.groupBoxData, 0, 1);
            this.FlowTableLayout.Controls.Add(this.FlowPanelTools, 0, 0);
            this.FlowTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowTableLayout.Location = new System.Drawing.Point(0, 0);
            this.FlowTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.FlowTableLayout.Name = "FlowTableLayout";
            this.FlowTableLayout.RowCount = 2;
            this.FlowTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.FlowTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FlowTableLayout.Size = new System.Drawing.Size(206, 366);
            this.FlowTableLayout.TabIndex = 4;
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.mgFlowPanelResult);
            this.groupBoxData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxData.Location = new System.Drawing.Point(1, 28);
            this.groupBoxData.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(204, 338);
            this.groupBoxData.TabIndex = 2;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Extracted data";
            this.groupBoxData.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_Paint);
            // 
            // mgFlowPanelResult
            // 
            this.mgFlowPanelResult.AllowDrop = true;
            this.mgFlowPanelResult.AutoScroll = true;
            this.mgFlowPanelResult.AutoSize = true;
            this.mgFlowPanelResult.BackColor = System.Drawing.SystemColors.Control;
            this.mgFlowPanelResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mgFlowPanelResult.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mgFlowPanelResult.Location = new System.Drawing.Point(3, 18);
            this.mgFlowPanelResult.Name = "mgFlowPanelResult";
            this.mgFlowPanelResult.Size = new System.Drawing.Size(198, 317);
            this.mgFlowPanelResult.TabIndex = 1;
            this.mgFlowPanelResult.DragDrop += new System.Windows.Forms.DragEventHandler(this.mgFlowPanelResult_DragDrop);
            this.mgFlowPanelResult.DragEnter += new System.Windows.Forms.DragEventHandler(this.mgFlowPanelResult_DragEnter);
            // 
            // FlowPanelTools
            // 
            this.FlowPanelTools.BackColor = System.Drawing.Color.Transparent;
            this.FlowPanelTools.Dock = System.Windows.Forms.DockStyle.None;
            this.FlowPanelTools.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FlowPanelTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.FlowPanelTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FlowPanelButtonAddTable,
            this.FlowPanelButtonDeleteAllTables});
            this.FlowPanelTools.Location = new System.Drawing.Point(1, 1);
            this.FlowPanelTools.Margin = new System.Windows.Forms.Padding(1);
            this.FlowPanelTools.Name = "FlowPanelTools";
            this.FlowPanelTools.Padding = new System.Windows.Forms.Padding(4, 0, 1, 0);
            this.FlowPanelTools.Size = new System.Drawing.Size(53, 25);
            this.FlowPanelTools.TabIndex = 3;
            // 
            // FlowPanelButtonAddTable
            // 
            this.FlowPanelButtonAddTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FlowPanelButtonAddTable.Image = ((System.Drawing.Image)(resources.GetObject("FlowPanelButtonAddTable.Image")));
            this.FlowPanelButtonAddTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FlowPanelButtonAddTable.Name = "FlowPanelButtonAddTable";
            this.FlowPanelButtonAddTable.Size = new System.Drawing.Size(23, 22);
            this.FlowPanelButtonAddTable.Text = "Add Table";
            this.FlowPanelButtonAddTable.Click += new System.EventHandler(this.FlowPanelButtonAddTable_Click);
            // 
            // FlowPanelButtonDeleteAllTables
            // 
            this.FlowPanelButtonDeleteAllTables.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FlowPanelButtonDeleteAllTables.Image = ((System.Drawing.Image)(resources.GetObject("FlowPanelButtonDeleteAllTables.Image")));
            this.FlowPanelButtonDeleteAllTables.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FlowPanelButtonDeleteAllTables.Name = "FlowPanelButtonDeleteAllTables";
            this.FlowPanelButtonDeleteAllTables.Size = new System.Drawing.Size(23, 22);
            this.FlowPanelButtonDeleteAllTables.Text = "Remove Tables";
            this.FlowPanelButtonDeleteAllTables.Click += new System.EventHandler(this.FlowPanelButtonDeleteAllTables_Click);
            // 
            // inputTableLoyaut
            // 
            this.inputTableLoyaut.ColumnCount = 1;
            this.inputTableLoyaut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.inputTableLoyaut.Controls.Add(this.datsTreeView, 0, 1);
            this.inputTableLoyaut.Controls.Add(this.mgToolStripInputData, 0, 0);
            this.inputTableLoyaut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputTableLoyaut.Location = new System.Drawing.Point(0, 1);
            this.inputTableLoyaut.Name = "inputTableLoyaut";
            this.inputTableLoyaut.RowCount = 2;
            this.inputTableLoyaut.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputTableLoyaut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.inputTableLoyaut.Size = new System.Drawing.Size(1166, 23);
            this.inputTableLoyaut.TabIndex = 0;
            // 
            // datsTreeView
            // 
            this.datsTreeView.BackColor = System.Drawing.SystemColors.Control;
            this.datsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datsTreeView.LabelEdit = true;
            this.datsTreeView.Location = new System.Drawing.Point(3, 28);
            this.datsTreeView.Name = "datsTreeView";
            treeNode1.Name = "treeViewLine1e1val";
            treeNode1.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            treeNode1.Text = "null";
            treeNode2.Name = "treeViewLine1";
            treeNode2.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode2.Text = "treeViewLine1";
            treeNode3.Name = "treeViewLine2e1val";
            treeNode3.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            treeNode3.Text = "null";
            treeNode4.Name = "treeViewLine2";
            treeNode4.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode4.Text = "treeViewLine2";
            treeNode5.Name = "treeViewLine3e1val";
            treeNode5.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            treeNode5.Text = "null";
            treeNode6.Name = "treeViewLine3";
            treeNode6.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode6.Text = "treeViewLine3";
            treeNode7.Name = "treeViewLine4e1val";
            treeNode7.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            treeNode7.Text = "null";
            treeNode8.Name = "treeViewLine4e1";
            treeNode8.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode8.Text = "ночная зона суток";
            treeNode9.Name = "treeViewLine4e2val";
            treeNode9.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            treeNode9.Text = "null";
            treeNode10.Name = "treeViewLine4e2";
            treeNode10.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode10.Text = "полупиковая зона суток";
            treeNode11.Name = "treeViewLine4e3val";
            treeNode11.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            treeNode11.Text = "null";
            treeNode12.Name = "treeViewLine4e3";
            treeNode12.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode12.Text = "пиковая зона суток";
            treeNode13.Name = "treeViewLine4";
            treeNode13.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode13.Text = "treeViewLine4";
            treeNode14.Name = "treeViewLine5e1val";
            treeNode14.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            treeNode14.Text = "null";
            treeNode15.Name = "treeViewLine5e1";
            treeNode15.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode15.Text = "ночная зона суток";
            treeNode16.Name = "treeViewLine5e2val";
            treeNode16.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            treeNode16.Text = "null";
            treeNode17.Name = "treeViewLine5e2";
            treeNode17.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode17.Text = "дневная зона суток";
            treeNode18.Name = "treeViewLine5";
            treeNode18.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode18.Text = "treeViewLine5";
            treeNode19.Name = "treeViewLine6e1val";
            treeNode19.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            treeNode19.Text = "null";
            treeNode20.Name = "treeViewLine6e1";
            treeNode20.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode20.Text = "ночная зона суток";
            treeNode21.Name = "treeViewLine6e2val";
            treeNode21.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            treeNode21.Text = "null";
            treeNode22.Name = "treeViewLine6e2";
            treeNode22.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode22.Text = "полупиковая зона суток";
            treeNode23.Name = "treeViewLine6e3val";
            treeNode23.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            treeNode23.Text = "null";
            treeNode24.Name = "treeViewLine6e3";
            treeNode24.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode24.Text = "пиковая зона суток";
            treeNode25.Name = "treeViewLine6";
            treeNode25.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode25.Text = "treeViewLine6";
            treeNode26.Name = "treeViewLine7e1val";
            treeNode26.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            treeNode26.Text = "null";
            treeNode27.Name = "treeViewLine7e1";
            treeNode27.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode27.Text = "ночная зона суток";
            treeNode28.Name = "treeViewLine7e2val";
            treeNode28.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            treeNode28.Text = "null";
            treeNode29.Name = "treeViewLine7e2";
            treeNode29.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode29.Text = "дневная зона суток";
            treeNode30.Name = "treeViewLine7";
            treeNode30.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            treeNode30.Text = "treeViewLine7";
            this.datsTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode6,
            treeNode13,
            treeNode18,
            treeNode25,
            treeNode30});
            this.datsTreeView.Size = new System.Drawing.Size(1160, 1);
            this.datsTreeView.TabIndex = 2;
            // 
            // mgToolStripInputData
            // 
            this.mgToolStripInputData.BackColor = System.Drawing.SystemColors.Control;
            this.mgToolStripInputData.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mgToolStripInputData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mgBtnEntryDatFiles,
            this.mgFileSPUNCbtn,
            this.mgFileSPUNCselector,
            this.mgFileSVNCbtn,
            this.mgFileKFbtn,
            this.imgStatusOk,
            this.imgStatusDwnld,
            this.imgStatusFailed});
            this.mgToolStripInputData.Location = new System.Drawing.Point(0, 0);
            this.mgToolStripInputData.Name = "mgToolStripInputData";
            this.mgToolStripInputData.Size = new System.Drawing.Size(1166, 25);
            this.mgToolStripInputData.TabIndex = 3;
            // 
            // mgBtnEntryDatFiles
            // 
            this.mgBtnEntryDatFiles.BackColor = System.Drawing.SystemColors.Control;
            this.mgBtnEntryDatFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mgBtnEntryDatFiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mgFileSPUNC,
            this.mgFileSVNC,
            this.mgFileKF});
            this.mgBtnEntryDatFiles.Enabled = false;
            this.mgBtnEntryDatFiles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mgBtnEntryDatFiles.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mgBtnEntryDatFiles.Image = ((System.Drawing.Image)(resources.GetObject("mgBtnEntryDatFiles.Image")));
            this.mgBtnEntryDatFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mgBtnEntryDatFiles.Name = "mgBtnEntryDatFiles";
            this.mgBtnEntryDatFiles.Size = new System.Drawing.Size(32, 22);
            this.mgBtnEntryDatFiles.Text = "Данные";
            this.mgBtnEntryDatFiles.ButtonClick += new System.EventHandler(this.mgBtnEntryDatFiles_ButtonClick);
            // 
            // mgFileSPUNC
            // 
            this.mgFileSPUNC.Name = "mgFileSPUNC";
            this.mgFileSPUNC.Size = new System.Drawing.Size(160, 22);
            this.mgFileSPUNC.Text = "СПУНЦ";
            // 
            // mgFileSVNC
            // 
            this.mgFileSVNC.Name = "mgFileSVNC";
            this.mgFileSVNC.Size = new System.Drawing.Size(160, 22);
            this.mgFileSVNC.Text = "СВНЦ (АТС)";
            // 
            // mgFileKF
            // 
            this.mgFileKF.Name = "mgFileKF";
            this.mgFileKF.Size = new System.Drawing.Size(160, 22);
            this.mgFileKF.Text = "Коэффициенты";
            // 
            // mgFileSPUNCbtn
            // 
            this.mgFileSPUNCbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mgFileSPUNCbtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mgFileSPUNCbtn.Image = ((System.Drawing.Image)(resources.GetObject("mgFileSPUNCbtn.Image")));
            this.mgFileSPUNCbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mgFileSPUNCbtn.Name = "mgFileSPUNCbtn";
            this.mgFileSPUNCbtn.Size = new System.Drawing.Size(91, 22);
            this.mgFileSPUNCbtn.Text = "СВНЦ (сбыт)";
            this.mgFileSPUNCbtn.ToolTipText = "СПУНЦ";
            this.mgFileSPUNCbtn.Visible = false;
            this.mgFileSPUNCbtn.Click += new System.EventHandler(this.mgFileSPUNCbtn_Click);
            // 
            // mgFileSPUNCselector
            // 
            this.mgFileSPUNCselector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mgFileSPUNCselector.DropDownWidth = 75;
            this.mgFileSPUNCselector.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.mgFileSPUNCselector.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mgFileSPUNCselector.Name = "mgFileSPUNCselector";
            this.mgFileSPUNCselector.Size = new System.Drawing.Size(75, 25);
            this.mgFileSPUNCselector.Visible = false;
            this.mgFileSPUNCselector.DropDownClosed += new System.EventHandler(this.mgFileSPUNCselector_DropDownClosed);
            // 
            // mgFileSVNCbtn
            // 
            this.mgFileSVNCbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mgFileSVNCbtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mgFileSVNCbtn.Image = ((System.Drawing.Image)(resources.GetObject("mgFileSVNCbtn.Image")));
            this.mgFileSVNCbtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mgFileSVNCbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mgFileSVNCbtn.Name = "mgFileSVNCbtn";
            this.mgFileSVNCbtn.Size = new System.Drawing.Size(84, 22);
            this.mgFileSVNCbtn.Text = "СВНЦ (АТС)";
            this.mgFileSVNCbtn.ToolTipText = "СВНЦ";
            this.mgFileSVNCbtn.Visible = false;
            this.mgFileSVNCbtn.Click += new System.EventHandler(this.mgFileSVNC_Click);
            // 
            // mgFileKFbtn
            // 
            this.mgFileKFbtn.BackColor = System.Drawing.SystemColors.Control;
            this.mgFileKFbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mgFileKFbtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mgFileKFbtn.Image = ((System.Drawing.Image)(resources.GetObject("mgFileKFbtn.Image")));
            this.mgFileKFbtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mgFileKFbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mgFileKFbtn.Name = "mgFileKFbtn";
            this.mgFileKFbtn.Size = new System.Drawing.Size(48, 22);
            this.mgFileKFbtn.Text = "Коэф.";
            this.mgFileKFbtn.ToolTipText = "Коэффициенты";
            this.mgFileKFbtn.Visible = false;
            this.mgFileKFbtn.Click += new System.EventHandler(this.mgFileKF_Click);
            // 
            // imgStatusOk
            // 
            this.imgStatusOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imgStatusOk.Image = ((System.Drawing.Image)(resources.GetObject("imgStatusOk.Image")));
            this.imgStatusOk.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imgStatusOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imgStatusOk.Name = "imgStatusOk";
            this.imgStatusOk.Size = new System.Drawing.Size(23, 22);
            this.imgStatusOk.Visible = false;
            // 
            // imgStatusDwnld
            // 
            this.imgStatusDwnld.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imgStatusDwnld.Image = ((System.Drawing.Image)(resources.GetObject("imgStatusDwnld.Image")));
            this.imgStatusDwnld.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imgStatusDwnld.Name = "imgStatusDwnld";
            this.imgStatusDwnld.Size = new System.Drawing.Size(23, 22);
            this.imgStatusDwnld.Visible = false;
            // 
            // imgStatusFailed
            // 
            this.imgStatusFailed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imgStatusFailed.Image = ((System.Drawing.Image)(resources.GetObject("imgStatusFailed.Image")));
            this.imgStatusFailed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imgStatusFailed.Name = "imgStatusFailed";
            this.imgStatusFailed.Size = new System.Drawing.Size(23, 22);
            this.imgStatusFailed.Visible = false;
            // 
            // mgMainToolStrip
            // 
            this.mgMainToolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.mgMainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mgMainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mgMainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mgBtnNewProject,
            this.mgBtnOpenFile,
            this.mgBtnSaveDats,
            this.toolStripSeparator5,
            this.mgBtnImportFile,
            this.toolStripSeparator4,
            this.toolBtnDictionaryList,
            this.toolBtnDictionaryEditor,
            this.mgBtnOpenFolder,
            this.toolStripButton3,
            this.toolBtnStartProccess,
            this.mgOpenDataTable,
            this.mgDataСalculation,
            this.mgDataAct});
            this.mgMainToolStrip.Location = new System.Drawing.Point(5, 26);
            this.mgMainToolStrip.Margin = new System.Windows.Forms.Padding(5, 1, 1, 1);
            this.mgMainToolStrip.Name = "mgMainToolStrip";
            this.mgMainToolStrip.Size = new System.Drawing.Size(214, 25);
            this.mgMainToolStrip.TabIndex = 4;
            this.mgMainToolStrip.Text = "mgTools";
            // 
            // mgBtnNewProject
            // 
            this.mgBtnNewProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mgBtnNewProject.Image = ((System.Drawing.Image)(resources.GetObject("mgBtnNewProject.Image")));
            this.mgBtnNewProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mgBtnNewProject.Name = "mgBtnNewProject";
            this.mgBtnNewProject.Size = new System.Drawing.Size(23, 22);
            this.mgBtnNewProject.Text = "New Project";
            this.mgBtnNewProject.Click += new System.EventHandler(this.mgBtnNewProject_Click);
            // 
            // mgBtnOpenFile
            // 
            this.mgBtnOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mgBtnOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("mgBtnOpenFile.Image")));
            this.mgBtnOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mgBtnOpenFile.Name = "mgBtnOpenFile";
            this.mgBtnOpenFile.Size = new System.Drawing.Size(23, 22);
            this.mgBtnOpenFile.Text = "Open File";
            // 
            // mgBtnSaveDats
            // 
            this.mgBtnSaveDats.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mgBtnSaveDats.Enabled = false;
            this.mgBtnSaveDats.Image = ((System.Drawing.Image)(resources.GetObject("mgBtnSaveDats.Image")));
            this.mgBtnSaveDats.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mgBtnSaveDats.Name = "mgBtnSaveDats";
            this.mgBtnSaveDats.Size = new System.Drawing.Size(23, 22);
            this.mgBtnSaveDats.Text = "Save Data";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // mgBtnImportFile
            // 
            this.mgBtnImportFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mgBtnImportFile.Enabled = false;
            this.mgBtnImportFile.Image = ((System.Drawing.Image)(resources.GetObject("mgBtnImportFile.Image")));
            this.mgBtnImportFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mgBtnImportFile.Name = "mgBtnImportFile";
            this.mgBtnImportFile.Size = new System.Drawing.Size(32, 22);
            this.mgBtnImportFile.Text = "ImportFile";
            this.mgBtnImportFile.ButtonClick += new System.EventHandler(this.mgBtnImportFile_ButtonClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
            this.toolBtnDictionaryEditor.Enabled = false;
            this.toolBtnDictionaryEditor.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnDictionaryEditor.Image")));
            this.toolBtnDictionaryEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnDictionaryEditor.Name = "toolBtnDictionaryEditor";
            this.toolBtnDictionaryEditor.Size = new System.Drawing.Size(23, 22);
            this.toolBtnDictionaryEditor.Text = "DictionaryEditor";
            this.toolBtnDictionaryEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolBtnDictionaryEditor.Click += new System.EventHandler(this.toolBtnDictionaryEditor_Click);
            // 
            // mgBtnOpenFolder
            // 
            this.mgBtnOpenFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mgBtnOpenFolder.Enabled = false;
            this.mgBtnOpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("mgBtnOpenFolder.Image")));
            this.mgBtnOpenFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mgBtnOpenFolder.Name = "mgBtnOpenFolder";
            this.mgBtnOpenFolder.Size = new System.Drawing.Size(23, 22);
            this.mgBtnOpenFolder.Text = "Show in Windows";
            this.mgBtnOpenFolder.Click += new System.EventHandler(this.mgBtnOpenFolder_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolBtnStartProccess
            // 
            this.toolBtnStartProccess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnStartProccess.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnStartProccess.Image")));
            this.toolBtnStartProccess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnStartProccess.Name = "toolBtnStartProccess";
            this.toolBtnStartProccess.Size = new System.Drawing.Size(23, 22);
            this.toolBtnStartProccess.Text = "Run";
            this.toolBtnStartProccess.Click += new System.EventHandler(this.toolBtnStartProccess_Click);
            // 
            // mgOpenDataTable
            // 
            this.mgOpenDataTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mgOpenDataTable.Image = ((System.Drawing.Image)(resources.GetObject("mgOpenDataTable.Image")));
            this.mgOpenDataTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mgOpenDataTable.Name = "mgOpenDataTable";
            this.mgOpenDataTable.Size = new System.Drawing.Size(23, 22);
            this.mgOpenDataTable.Text = "OpenDataTable";
            this.mgOpenDataTable.Visible = false;
            // 
            // mgDataСalculation
            // 
            this.mgDataСalculation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mgDataСalculation.Image = ((System.Drawing.Image)(resources.GetObject("mgDataСalculation.Image")));
            this.mgDataСalculation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mgDataСalculation.Name = "mgDataСalculation";
            this.mgDataСalculation.Size = new System.Drawing.Size(23, 22);
            this.mgDataСalculation.Text = "OpenСalculation";
            this.mgDataСalculation.Visible = false;
            // 
            // mgDataAct
            // 
            this.mgDataAct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mgDataAct.Image = ((System.Drawing.Image)(resources.GetObject("mgDataAct.Image")));
            this.mgDataAct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mgDataAct.Name = "mgDataAct";
            this.mgDataAct.Size = new System.Drawing.Size(23, 22);
            this.mgDataAct.Text = "OpenAct";
            this.mgDataAct.Visible = false;
            // 
            // tabControlCurrentProject
            // 
            this.tabControlCurrentProject.Controls.Add(this.tabBasic);
            this.tabControlCurrentProject.Controls.Add(this.tabDetail);
            this.tabControlCurrentProject.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControlCurrentProject.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControlCurrentProject.Location = new System.Drawing.Point(1, 53);
            this.tabControlCurrentProject.Margin = new System.Windows.Forms.Padding(1);
            this.tabControlCurrentProject.Name = "tabControlCurrentProject";
            this.tabControlCurrentProject.Padding = new System.Drawing.Point(10, 3);
            this.tabControlCurrentProject.SelectedIndex = 0;
            this.tabControlCurrentProject.Size = new System.Drawing.Size(719, 123);
            this.tabControlCurrentProject.TabIndex = 4;
            // 
            // tabBasic
            // 
            this.tabBasic.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabBasic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabBasic.Controls.Add(this.upperTableLayoutMainData);
            this.tabBasic.Location = new System.Drawing.Point(4, 23);
            this.tabBasic.Margin = new System.Windows.Forms.Padding(0);
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.Padding = new System.Windows.Forms.Padding(1, 4, 1, 1);
            this.tabBasic.Size = new System.Drawing.Size(711, 96);
            this.tabBasic.TabIndex = 0;
            this.tabBasic.Text = "Basic data";
            // 
            // upperTableLayoutMainData
            // 
            this.upperTableLayoutMainData.AutoSize = true;
            this.upperTableLayoutMainData.ColumnCount = 2;
            this.upperTableLayoutMainData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.77273F));
            this.upperTableLayoutMainData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.22727F));
            this.upperTableLayoutMainData.Controls.Add(this.textBoxSubject, 1, 0);
            this.upperTableLayoutMainData.Controls.Add(this.textBoxGTPcode, 1, 1);
            this.upperTableLayoutMainData.Controls.Add(this.textBoxNameGP, 1, 2);
            this.upperTableLayoutMainData.Controls.Add(this.lblSubject, 0, 0);
            this.upperTableLayoutMainData.Controls.Add(this.lblGTPcode, 0, 1);
            this.upperTableLayoutMainData.Controls.Add(this.lblNameGP, 0, 2);
            this.upperTableLayoutMainData.Location = new System.Drawing.Point(1, 4);
            this.upperTableLayoutMainData.Margin = new System.Windows.Forms.Padding(1);
            this.upperTableLayoutMainData.Name = "upperTableLayoutMainData";
            this.upperTableLayoutMainData.RowCount = 3;
            this.upperTableLayoutMainData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.upperTableLayoutMainData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.upperTableLayoutMainData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.upperTableLayoutMainData.Size = new System.Drawing.Size(446, 90);
            this.upperTableLayoutMainData.TabIndex = 0;
            this.upperTableLayoutMainData.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.TitleInfoBorderColor);
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSubject.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSubject.Location = new System.Drawing.Point(155, 0);
            this.textBoxSubject.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.ShortcutsEnabled = false;
            this.textBoxSubject.Size = new System.Drawing.Size(291, 21);
            this.textBoxSubject.TabIndex = 4;
            this.textBoxSubject.WordWrap = false;
            // 
            // textBoxGTPcode
            // 
            this.textBoxGTPcode.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxGTPcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGTPcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxGTPcode.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxGTPcode.Location = new System.Drawing.Point(155, 30);
            this.textBoxGTPcode.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxGTPcode.Name = "textBoxGTPcode";
            this.textBoxGTPcode.ShortcutsEnabled = false;
            this.textBoxGTPcode.Size = new System.Drawing.Size(291, 21);
            this.textBoxGTPcode.TabIndex = 5;
            this.textBoxGTPcode.WordWrap = false;
            // 
            // textBoxNameGP
            // 
            this.textBoxNameGP.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxNameGP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNameGP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNameGP.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxNameGP.Location = new System.Drawing.Point(155, 60);
            this.textBoxNameGP.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxNameGP.Name = "textBoxNameGP";
            this.textBoxNameGP.ShortcutsEnabled = false;
            this.textBoxNameGP.Size = new System.Drawing.Size(291, 21);
            this.textBoxNameGP.TabIndex = 6;
            this.textBoxNameGP.WordWrap = false;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.BackColor = System.Drawing.Color.Transparent;
            this.lblSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSubject.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubject.Location = new System.Drawing.Point(4, 2);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(4, 2, 0, 10);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(151, 18);
            this.lblSubject.TabIndex = 0;
            this.lblSubject.Text = "Субъект РФ";
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGTPcode
            // 
            this.lblGTPcode.AutoSize = true;
            this.lblGTPcode.BackColor = System.Drawing.Color.Transparent;
            this.lblGTPcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGTPcode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGTPcode.Location = new System.Drawing.Point(4, 32);
            this.lblGTPcode.Margin = new System.Windows.Forms.Padding(4, 2, 0, 10);
            this.lblGTPcode.Name = "lblGTPcode";
            this.lblGTPcode.Size = new System.Drawing.Size(151, 18);
            this.lblGTPcode.TabIndex = 2;
            this.lblGTPcode.Text = "Код ГТП";
            this.lblGTPcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNameGP
            // 
            this.lblNameGP.AutoSize = true;
            this.lblNameGP.BackColor = System.Drawing.Color.Transparent;
            this.lblNameGP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNameGP.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNameGP.Location = new System.Drawing.Point(4, 62);
            this.lblNameGP.Margin = new System.Windows.Forms.Padding(4, 2, 0, 10);
            this.lblNameGP.Name = "lblNameGP";
            this.lblNameGP.Size = new System.Drawing.Size(151, 18);
            this.lblNameGP.TabIndex = 1;
            this.lblNameGP.Text = "Наименование участника";
            this.lblNameGP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabDetail
            // 
            this.tabDetail.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabDetail.Controls.Add(this.groupBoxProp);
            this.tabDetail.Controls.Add(this.groupBoxRes);
            this.tabDetail.Location = new System.Drawing.Point(4, 23);
            this.tabDetail.Margin = new System.Windows.Forms.Padding(0);
            this.tabDetail.Name = "tabDetail";
            this.tabDetail.Padding = new System.Windows.Forms.Padding(4);
            this.tabDetail.Size = new System.Drawing.Size(711, 96);
            this.tabDetail.TabIndex = 1;
            this.tabDetail.Text = "Detail";
            // 
            // groupBoxProp
            // 
            this.groupBoxProp.Controls.Add(this.propTableLayout);
            this.groupBoxProp.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxProp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxProp.Location = new System.Drawing.Point(265, 4);
            this.groupBoxProp.Margin = new System.Windows.Forms.Padding(5, 17, 2, 2);
            this.groupBoxProp.Name = "groupBoxProp";
            this.groupBoxProp.Size = new System.Drawing.Size(440, 86);
            this.groupBoxProp.TabIndex = 6;
            this.groupBoxProp.TabStop = false;
            this.groupBoxProp.Text = "Properties";
            this.groupBoxProp.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_Paint);
            // 
            // propTableLayout
            // 
            this.propTableLayout.ColumnCount = 4;
            this.propTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.71429F));
            this.propTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.5023F));
            this.propTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.97235F));
            this.propTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.58064F));
            this.propTableLayout.Controls.Add(this.label3, 0, 0);
            this.propTableLayout.Controls.Add(this.cmbxMethod, 1, 0);
            this.propTableLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.propTableLayout.Location = new System.Drawing.Point(3, 18);
            this.propTableLayout.Margin = new System.Windows.Forms.Padding(1);
            this.propTableLayout.Name = "propTableLayout";
            this.propTableLayout.RowCount = 1;
            this.propTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.propTableLayout.Size = new System.Drawing.Size(434, 30);
            this.propTableLayout.TabIndex = 2;
            this.propTableLayout.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.propertiesBorderColor);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(4, 2);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 2, 0, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Использовать данные";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbxMethod
            // 
            this.cmbxMethod.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cmbxMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxMethod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbxMethod.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbxMethod.FormattingEnabled = true;
            this.cmbxMethod.Location = new System.Drawing.Point(155, 0);
            this.cmbxMethod.Margin = new System.Windows.Forms.Padding(0);
            this.cmbxMethod.Name = "cmbxMethod";
            this.cmbxMethod.Size = new System.Drawing.Size(102, 23);
            this.cmbxMethod.TabIndex = 1;
            this.cmbxMethod.DropDownClosed += new System.EventHandler(this.cmbxMethod_DropDownClosed);
            // 
            // groupBoxRes
            // 
            this.groupBoxRes.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxRes.Controls.Add(this.ResourcesTreeView);
            this.groupBoxRes.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxRes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxRes.Location = new System.Drawing.Point(4, 4);
            this.groupBoxRes.Name = "groupBoxRes";
            this.groupBoxRes.Size = new System.Drawing.Size(251, 86);
            this.groupBoxRes.TabIndex = 0;
            this.groupBoxRes.TabStop = false;
            this.groupBoxRes.Text = "Resources manager";
            this.groupBoxRes.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_Paint);
            // 
            // ResourcesTreeView
            // 
            this.ResourcesTreeView.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ResourcesTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ResourcesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResourcesTreeView.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ResourcesTreeView.ImageKey = "FolderOpened.png";
            this.ResourcesTreeView.ImageList = this.imgListData;
            this.ResourcesTreeView.Location = new System.Drawing.Point(3, 18);
            this.ResourcesTreeView.Name = "ResourcesTreeView";
            this.ResourcesTreeView.SelectedImageIndex = 3;
            this.ResourcesTreeView.Size = new System.Drawing.Size(245, 65);
            this.ResourcesTreeView.TabIndex = 2;
            // 
            // imgListData
            // 
            this.imgListData.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imgListData.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListData.ImageStream")));
            this.imgListData.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListData.Images.SetKeyName(0, "TableGroup.png");
            this.imgListData.Images.SetKeyName(1, "ShowDataPreview.png");
            this.imgListData.Images.SetKeyName(2, "StatusReady.png");
            this.imgListData.Images.SetKeyName(3, "FolderOpened.png");
            this.imgListData.Images.SetKeyName(4, "StatusError.png");
            this.imgListData.Images.SetKeyName(5, "TableError.png");
            this.imgListData.Images.SetKeyName(6, "StatusWarning.png");
            this.imgListData.Images.SetKeyName(7, "StatusWarningOutline.png");
            this.imgListData.Images.SetKeyName(8, "StatusOK.png");
            this.imgListData.Images.SetKeyName(9, "StatusInformation.png");
            this.imgListData.Images.SetKeyName(10, "StatusErrorOutline.png");
            this.imgListData.Images.SetKeyName(11, "StatusExcluded.png");
            this.imgListData.Images.SetKeyName(12, "StatusOKOutline.png");
            this.imgListData.Images.SetKeyName(13, "StatusAlertOutline.png");
            this.imgListData.Images.SetKeyName(14, "OnlineStatusUnknown.png");
            this.imgListData.Images.SetKeyName(15, "StatusInvalid.png");
            this.imgListData.Images.SetKeyName(16, "StatusRequired.png");
            this.imgListData.Images.SetKeyName(17, "OnlineStatusOffline.png");
            this.imgListData.Images.SetKeyName(18, "StatusNotStarted.png");
            this.imgListData.Images.SetKeyName(19, "StatusInvalidOutline.png");
            this.imgListData.Images.SetKeyName(20, "StatusRequiredOutline.png");
            this.imgListData.Images.SetKeyName(21, "TableOK.png");
            this.imgListData.Images.SetKeyName(22, "TableWarning.png");
            // 
            // ProjectInfoBox
            // 
            this.ProjectInfoBox.Controls.Add(this.ProjectInfoTableLayoutPanel);
            this.ProjectInfoBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ProjectInfoBox.Location = new System.Drawing.Point(729, 69);
            this.ProjectInfoBox.Margin = new System.Windows.Forms.Padding(5, 17, 2, 2);
            this.ProjectInfoBox.Name = "ProjectInfoBox";
            this.ProjectInfoBox.Size = new System.Drawing.Size(279, 103);
            this.ProjectInfoBox.TabIndex = 5;
            this.ProjectInfoBox.TabStop = false;
            this.ProjectInfoBox.Text = "Project";
            this.ProjectInfoBox.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_Paint);
            // 
            // ProjectInfoTableLayoutPanel
            // 
            this.ProjectInfoTableLayoutPanel.ColumnCount = 4;
            this.ProjectInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.ProjectInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.ProjectInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.ProjectInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.ProjectInfoTableLayoutPanel.Controls.Add(this.txtProjectInfoName, 1, 0);
            this.ProjectInfoTableLayoutPanel.Controls.Add(this.txtProjectMonth, 1, 1);
            this.ProjectInfoTableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.ProjectInfoTableLayoutPanel.Controls.Add(this.label2, 0, 1);
            this.ProjectInfoTableLayoutPanel.Controls.Add(this.label4, 2, 1);
            this.ProjectInfoTableLayoutPanel.Controls.Add(this.txtProjectYear, 3, 1);
            this.ProjectInfoTableLayoutPanel.Location = new System.Drawing.Point(14, 25);
            this.ProjectInfoTableLayoutPanel.Margin = new System.Windows.Forms.Padding(1);
            this.ProjectInfoTableLayoutPanel.Name = "ProjectInfoTableLayoutPanel";
            this.ProjectInfoTableLayoutPanel.RowCount = 2;
            this.ProjectInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ProjectInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ProjectInfoTableLayoutPanel.Size = new System.Drawing.Size(249, 60);
            this.ProjectInfoTableLayoutPanel.TabIndex = 2;
            this.ProjectInfoTableLayoutPanel.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.ProjectInfoBorderColor);
            // 
            // txtProjectInfoName
            // 
            this.txtProjectInfoName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtProjectInfoName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProjectInfoTableLayoutPanel.SetColumnSpan(this.txtProjectInfoName, 3);
            this.txtProjectInfoName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProjectInfoName.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtProjectInfoName.Location = new System.Drawing.Point(82, 0);
            this.txtProjectInfoName.Margin = new System.Windows.Forms.Padding(0);
            this.txtProjectInfoName.Name = "txtProjectInfoName";
            this.txtProjectInfoName.ShortcutsEnabled = false;
            this.txtProjectInfoName.Size = new System.Drawing.Size(167, 21);
            this.txtProjectInfoName.TabIndex = 4;
            this.txtProjectInfoName.WordWrap = false;
            // 
            // txtProjectMonth
            // 
            this.txtProjectMonth.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtProjectMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProjectMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProjectMonth.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtProjectMonth.Location = new System.Drawing.Point(82, 30);
            this.txtProjectMonth.Margin = new System.Windows.Forms.Padding(0);
            this.txtProjectMonth.Name = "txtProjectMonth";
            this.txtProjectMonth.ReadOnly = true;
            this.txtProjectMonth.ShortcutsEnabled = false;
            this.txtProjectMonth.Size = new System.Drawing.Size(67, 21);
            this.txtProjectMonth.TabIndex = 5;
            this.txtProjectMonth.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(4, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 2, 0, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Проект";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(4, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 2, 0, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Месяц";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(155, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 2, 0, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Год";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProjectYear
            // 
            this.txtProjectYear.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtProjectYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProjectYear.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtProjectYear.Location = new System.Drawing.Point(206, 30);
            this.txtProjectYear.Margin = new System.Windows.Forms.Padding(0);
            this.txtProjectYear.Name = "txtProjectYear";
            this.txtProjectYear.ReadOnly = true;
            this.txtProjectYear.ShortcutsEnabled = false;
            this.txtProjectYear.Size = new System.Drawing.Size(43, 21);
            this.txtProjectYear.TabIndex = 6;
            this.txtProjectYear.WordWrap = false;
            // 
            // appInfo
            // 
            this.appInfo.AutoSize = true;
            this.appInfo.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.appInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.appInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.appInfo.ForeColor = System.Drawing.SystemColors.InfoText;
            this.appInfo.Location = new System.Drawing.Point(1129, 1);
            this.appInfo.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.appInfo.Name = "appInfo";
            this.appInfo.Size = new System.Drawing.Size(52, 23);
            this.appInfo.TabIndex = 77;
            this.appInfo.Text = "appName";
            this.appInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabExcel
            // 
            this.tabExcel.BackColor = System.Drawing.Color.Transparent;
            this.tabExcel.Controls.Add(this.urToolStrip);
            this.tabExcel.Controls.Add(this.splitContainer_bigMain);
            this.tabExcel.Location = new System.Drawing.Point(4, 24);
            this.tabExcel.Name = "tabExcel";
            this.tabExcel.Padding = new System.Windows.Forms.Padding(1);
            this.tabExcel.Size = new System.Drawing.Size(1176, 584);
            this.tabExcel.TabIndex = 0;
            // 
            // urToolStrip
            // 
            this.urToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.urToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.urBtnImportFile,
            this.toolStripSeparator2,
            this.urBtnSaveXML,
            this.urBtnConvert2Tree});
            this.urToolStrip.Location = new System.Drawing.Point(1, 1);
            this.urToolStrip.Name = "urToolStrip";
            this.urToolStrip.Padding = new System.Windows.Forms.Padding(4, 0, 1, 0);
            this.urToolStrip.Size = new System.Drawing.Size(1174, 25);
            this.urToolStrip.TabIndex = 76;
            this.urToolStrip.Text = "mgTools";
            // 
            // urBtnImportFile
            // 
            this.urBtnImportFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.urBtnImportFile.Image = global::dataEditor.Properties.Resources.OpenFile;
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
            this.urBtnSaveXML.Image = global::dataEditor.Properties.Resources.XmlFile;
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
            this.urBtnConvert2Tree.Image = global::dataEditor.Properties.Resources.TransformListItem;
            this.urBtnConvert2Tree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.urBtnConvert2Tree.Name = "urBtnConvert2Tree";
            this.urBtnConvert2Tree.Size = new System.Drawing.Size(23, 22);
            this.urBtnConvert2Tree.Text = "Tree View";
            this.urBtnConvert2Tree.Click += new System.EventHandler(this.urBtnConvert2Tree_Click);
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
            this.splitContainer_bigMain.Panel2MinSize = 300;
            this.splitContainer_bigMain.Size = new System.Drawing.Size(1170, 544);
            this.splitContainer_bigMain.SplitterDistance = 866;
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
            this.splitContainer_dataGrids.Size = new System.Drawing.Size(866, 544);
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
            this.CellViewer.Size = new System.Drawing.Size(866, 25);
            this.CellViewer.TabIndex = 0;
            // 
            // dataViewer
            // 
            this.dataViewer.AllowDrop = true;
            this.dataViewer.AllowUserToAddRows = false;
            this.dataViewer.AllowUserToDeleteRows = false;
            this.dataViewer.AllowUserToResizeRows = false;
            this.dataViewer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataViewer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataViewer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataViewer.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataViewer.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataViewer.Location = new System.Drawing.Point(0, 0);
            this.dataViewer.MultiSelect = false;
            this.dataViewer.Name = "dataViewer";
            this.dataViewer.ReadOnly = true;
            this.dataViewer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataViewer.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataViewer.RowHeadersWidth = 20;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataViewer.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataViewer.RowTemplate.Height = 25;
            this.dataViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataViewer.Size = new System.Drawing.Size(866, 515);
            this.dataViewer.TabIndex = 1;
            this.dataViewer.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataViewer_DragDrop);
            this.dataViewer.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataViewer_DragEnter);
            // 
            // splitContainer_rightProps
            // 
            this.splitContainer_rightProps.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer_rightProps.Dock = System.Windows.Forms.DockStyle.Right;
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
            this.splitContainer_rightProps.Panel2.Controls.Add(this.urOptionsGrid);
            this.splitContainer_rightProps.Panel2MinSize = 0;
            this.splitContainer_rightProps.Size = new System.Drawing.Size(300, 544);
            this.splitContainer_rightProps.SplitterDistance = 150;
            this.splitContainer_rightProps.TabIndex = 74;
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
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.statusGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.statusGridView.ColumnHeadersHeight = 20;
            this.statusGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.statusGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.statusGridView.DefaultCellStyle = dataGridViewCellStyle17;
            this.statusGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.statusGridView.EnableHeadersVisualStyles = false;
            this.statusGridView.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.statusGridView.Location = new System.Drawing.Point(0, 0);
            this.statusGridView.MultiSelect = false;
            this.statusGridView.Name = "statusGridView";
            this.statusGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.statusGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.statusGridView.RowHeadersVisible = false;
            this.statusGridView.RowHeadersWidth = 130;
            this.statusGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.statusGridView.RowsDefaultCellStyle = dataGridViewCellStyle19;
            this.statusGridView.RowTemplate.Height = 17;
            this.statusGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.statusGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.statusGridView.Size = new System.Drawing.Size(300, 150);
            this.statusGridView.TabIndex = 70;
            this.statusGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.statusGridView_CellCmbxValueChanged);
            this.statusGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.statusGridView_CurrentCellDirtyStateChanged);
            // 
            // Column1
            // 
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle14;
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 104;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle15;
            this.Column2.HeaderText = "Value";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle16;
            this.Column3.HeaderText = "Status";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 50;
            // 
            // urOptionsGrid
            // 
            this.urOptionsGrid.BackColor = System.Drawing.SystemColors.Control;
            this.urOptionsGrid.CommandsBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.urOptionsGrid.CommandsVisibleIfAvailable = false;
            this.urOptionsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urOptionsGrid.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.urOptionsGrid.HelpBorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.urOptionsGrid.LineColor = System.Drawing.SystemColors.ControlLight;
            this.urOptionsGrid.Location = new System.Drawing.Point(0, 0);
            this.urOptionsGrid.Name = "urOptionsGrid";
            this.urOptionsGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.urOptionsGrid.Size = new System.Drawing.Size(300, 390);
            this.urOptionsGrid.TabIndex = 66;
            this.urOptionsGrid.ToolbarVisible = false;
            this.urOptionsGrid.UseCompatibleTextRendering = true;
            this.urOptionsGrid.ViewBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.urOptionsGrid.ViewBorderColor = System.Drawing.SystemColors.ActiveBorder;
            // 
            // SectionsControl
            // 
            this.SectionsControl.Controls.Add(this.tabExcel);
            this.SectionsControl.Controls.Add(this.tabMicrogeneration);
            this.SectionsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SectionsControl.ItemSize = new System.Drawing.Size(20, 20);
            this.SectionsControl.Location = new System.Drawing.Point(0, 24);
            this.SectionsControl.Name = "SectionsControl";
            this.SectionsControl.Padding = new System.Drawing.Point(10, 3);
            this.SectionsControl.SelectedIndex = 0;
            this.SectionsControl.Size = new System.Drawing.Size(1184, 612);
            this.SectionsControl.TabIndex = 76;
            this.SectionsControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.SectionsControl_Selected);
            // 
            // buttonBackground
            // 
            this.buttonBackground.BackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonBackground.ColumnCount = 1;
            this.buttonBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonBackground.Controls.Add(this.appInfo, 0, 0);
            this.buttonBackground.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonBackground.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.buttonBackground.Location = new System.Drawing.Point(0, 636);
            this.buttonBackground.Name = "buttonBackground";
            this.buttonBackground.RowCount = 1;
            this.buttonBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonBackground.Size = new System.Drawing.Size(1184, 25);
            this.buttonBackground.TabIndex = 78;
            // 
            // contextMenuOpenTable
            // 
            this.contextMenuOpenTable.Name = "contextMenuOpenTable";
            this.contextMenuOpenTable.ShowItemToolTips = false;
            this.contextMenuOpenTable.Size = new System.Drawing.Size(61, 4);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.77273F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.22727F));
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(69, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(131, 21);
            this.textBox1.TabIndex = 4;
            this.textBox1.WordWrap = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(69, 21);
            this.textBox2.Margin = new System.Windows.Forms.Padding(0);
            this.textBox2.Name = "textBox2";
            this.textBox2.ShortcutsEnabled = false;
            this.textBox2.Size = new System.Drawing.Size(131, 21);
            this.textBox2.TabIndex = 5;
            this.textBox2.WordWrap = false;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox3.Location = new System.Drawing.Point(69, 0);
            this.textBox3.Margin = new System.Windows.Forms.Padding(0);
            this.textBox3.Name = "textBox3";
            this.textBox3.ShortcutsEnabled = false;
            this.textBox3.Size = new System.Drawing.Size(131, 21);
            this.textBox3.TabIndex = 4;
            this.textBox3.WordWrap = false;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox4.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox4.Location = new System.Drawing.Point(69, 21);
            this.textBox4.Margin = new System.Windows.Forms.Padding(0);
            this.textBox4.Name = "textBox4";
            this.textBox4.ShortcutsEnabled = false;
            this.textBox4.Size = new System.Drawing.Size(131, 21);
            this.textBox4.TabIndex = 5;
            this.textBox4.WordWrap = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.77273F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.22727F));
            this.tableLayoutPanel2.Controls.Add(this.textBox3, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.SectionsControl);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.buttonBackground);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dataEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.RowContext.ResumeLayout(false);
            this.propGrid_stripMenu.ResumeLayout(false);
            this.CellContext.ResumeLayout(false);
            this.ColumnContext.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabMicrogeneration.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainTableLayoutPanel.PerformLayout();
            this.mgSplitContainer_insideHorizontal.Panel1.ResumeLayout(false);
            this.mgSplitContainer_insideHorizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mgSplitContainer_insideHorizontal)).EndInit();
            this.mgSplitContainer_insideHorizontal.ResumeLayout(false);
            this.mgSplitContainer_inside_vertical.Panel1.ResumeLayout(false);
            this.mgSplitContainer_inside_vertical.Panel1.PerformLayout();
            this.mgSplitContainer_inside_vertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mgSplitContainer_inside_vertical)).EndInit();
            this.mgSplitContainer_inside_vertical.ResumeLayout(false);
            this.groupBoxTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mgDataViewer)).EndInit();
            this.FlowTableLayout.ResumeLayout(false);
            this.FlowTableLayout.PerformLayout();
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.FlowPanelTools.ResumeLayout(false);
            this.FlowPanelTools.PerformLayout();
            this.inputTableLoyaut.ResumeLayout(false);
            this.inputTableLoyaut.PerformLayout();
            this.mgToolStripInputData.ResumeLayout(false);
            this.mgToolStripInputData.PerformLayout();
            this.mgMainToolStrip.ResumeLayout(false);
            this.mgMainToolStrip.PerformLayout();
            this.tabControlCurrentProject.ResumeLayout(false);
            this.tabBasic.ResumeLayout(false);
            this.tabBasic.PerformLayout();
            this.upperTableLayoutMainData.ResumeLayout(false);
            this.upperTableLayoutMainData.PerformLayout();
            this.tabDetail.ResumeLayout(false);
            this.groupBoxProp.ResumeLayout(false);
            this.propTableLayout.ResumeLayout(false);
            this.propTableLayout.PerformLayout();
            this.groupBoxRes.ResumeLayout(false);
            this.ProjectInfoBox.ResumeLayout(false);
            this.ProjectInfoTableLayoutPanel.ResumeLayout(false);
            this.ProjectInfoTableLayoutPanel.PerformLayout();
            this.tabExcel.ResumeLayout(false);
            this.tabExcel.PerformLayout();
            this.urToolStrip.ResumeLayout(false);
            this.urToolStrip.PerformLayout();
            this.splitContainer_bigMain.Panel1.ResumeLayout(false);
            this.splitContainer_bigMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_bigMain)).EndInit();
            this.splitContainer_bigMain.ResumeLayout(false);
            this.splitContainer_dataGrids.Panel1.ResumeLayout(false);
            this.splitContainer_dataGrids.Panel1.PerformLayout();
            this.splitContainer_dataGrids.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_dataGrids)).EndInit();
            this.splitContainer_dataGrids.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).EndInit();
            this.splitContainer_rightProps.Panel1.ResumeLayout(false);
            this.splitContainer_rightProps.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_rightProps)).EndInit();
            this.splitContainer_rightProps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusGridView)).EndInit();
            this.SectionsControl.ResumeLayout(false);
            this.buttonBackground.ResumeLayout(false);
            this.buttonBackground.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ContextMenuStrip RowContext;
        private ToolStripMenuItem RightClick_HeadsRow;
        private ToolStripMenuItem RightClick_FirstRowData;
        private ContextMenuStrip CellContext;
        private ContextMenuStrip ColumnContext;
        private ToolStripMenuItem setAsColumn4CheckToolStripMenuItem;
        private ToolStripMenuItem setAsStaticValueToolStripMenuItem;
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
        private ToolStripMenuItem xFAReaderToolStripMenuItem;
        private ToolStripMenuItem ExitUR;
        private TabPage tabMicrogeneration;
        private ToolStrip mgMainToolStrip;
        private ToolStripSplitButton mgBtnImportFile;
        private ToolStripButton toolBtnDictionaryList;
        private ToolStripButton toolBtnDictionaryEditor;
        private ToolStripSeparator toolStripButton3;
        private TextBox textBoxNameGP;
        private Label lblNameGP;
        private TextBox textBoxGTPcode;
        private Label lblSubject;
        private TextBox textBoxSubject;
        private Label lblGTPcode;
        private SplitContainer mgSplitContainer_insideHorizontal;
        private TreeView datsTreeView;
        private TabPage tabExcel;
        private ToolStrip urToolStrip;
        private ToolStripSplitButton urBtnImportFile;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton urBtnSaveXML;
        private ToolStripButton urBtnConvert2Tree;
        private SplitContainer splitContainer_bigMain;
        private SplitContainer splitContainer_dataGrids;
        private TextBox CellViewer;
        private SplitContainer splitContainer_rightProps;
        private StatusGridViewEditMode statusGridView;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private ToolStripButton mgBtnOpenFolder;
        private ToolStripButton mgBtnSaveDats;
        private ToolStripSeparator toolStripSeparator4;
        private FlowLayoutPanel mgFlowPanelResult;
        private ToolStripButton mgBtnNewProject;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton mgBtnOpenFile;
        private ToolStripButton toolBtnStartProccess;
        private ToolStripButton mgOpenDataTable;
        private ToolStripButton mgDataСalculation;
        private ToolStripButton mgDataAct;
        private DoubleBufferedDataGridView mgDataViewer;
        private DoubleBufferedDataGridView dataViewer;
        private Label appInfo;
        private TableLayoutPanel buttonBackground;
        private TableLayoutPanel inputTableLoyaut;
        private ToolStrip mgToolStripInputData;
        private ToolStripSplitButton mgBtnEntryDatFiles;
        private ToolStripMenuItem mgFileSPUNC;
        private ToolStripMenuItem mgFileSVNC;
        private ToolStripMenuItem mgFileKF;
        private ToolStripButton mgFileSVNCbtn;
        private ToolStripButton mgFileKFbtn;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private SplitContainer mgSplitContainer_inside_vertical;
        public PropertyGrid urOptionsGrid;
        private ToolStripButton imgStatusOk;
        private ToolStripButton imgStatusDwnld;
        private ToolStripButton imgStatusFailed;
        private TreeView ResourcesTreeView;
        private GroupBox groupBoxRes;
        private GroupBox groupBoxData;
        private ContextMenuStrip contextMenuOpenTable;
        public TabControl SectionsControl;
        private ImageList imgListData;
        private TabControl tabControlCurrentProject;
        private TabPage tabBasic;
        private TabPage tabDetail;
        private TableLayoutPanel upperTableLayoutMainData;
        private Label lblMainName;
        private Panel MainPanel;
        private TableLayoutPanel MainTableLayoutPanel;
        private TableLayoutPanel ProjectInfoTableLayoutPanel;
        private TextBox txtProjectMonth;
        private Label label1;
        private Label label2;
        private Label label4;
        private TextBox txtProjectYear;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox ProjectInfoBox;
        private ToolStripButton mgFileSPUNCbtn;
        private ToolStripComboBox mgFileSPUNCselector;
        private GroupBox groupBoxTable;
        private GroupBox groupBoxProp;
        private TableLayoutPanel propTableLayout;
        private Label label3;
        private TextBox txtProjectInfoName;
        private ComboBox cmbxMethod;
        private TableLayoutPanel FlowTableLayout;
        private ToolStrip FlowPanelTools;
        private ToolStripButton FlowPanelButtonAddTable;
        private DataGridViewTextBoxColumn id;
        private DataGridViewCheckBoxColumn SelectID;
        private DataGridViewTextBoxColumn dataTable;
        private DataGridViewTextBoxColumn dataExcel;
        private DataGridViewTextBoxColumn dataAct;
        private DataGridViewTextBoxColumn OpenFolder;
        private DataGridViewTextBoxColumn GlobalStatus;
        private DataGridViewTextBoxColumn Agreement;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn DateAgreement;
        private DataGridViewTextBoxColumn type;
        private DataGridViewTextBoxColumn TariffZone;
        private DataGridViewTextBoxColumn NumCC;
        private DataGridViewTextBoxColumn REC;
        private DataGridViewTextBoxColumn GEN;
        private DataGridViewTextBoxColumn SELL;
        private DataGridViewTextBoxColumn BUY;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Cost;
        private DataGridViewTextBoxColumn baseDoc;
        private DataGridViewTextBoxColumn NDS;
        private DataGridViewComboBoxColumn Method;
        private DataGridViewCheckBoxColumn intgStatusError;
        private DataGridViewCheckBoxColumn hrsStatusError;
        private ToolStripButton FlowPanelButtonDeleteAllTables;
    }
}