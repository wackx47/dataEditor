namespace dataEditor
{
    partial class mgForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mgMenuOpenDatsList = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMG = new System.Windows.Forms.ToolStripMenuItem();
            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer_horizontal = new System.Windows.Forms.SplitContainer();
            this.MounthTab = new System.Windows.Forms.TabControl();
            this.January = new System.Windows.Forms.TabPage();
            this.dataViewer = new System.Windows.Forms.DataGridView();
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
            this.splitContainer_bottom_vertical = new System.Windows.Forms.SplitContainer();
            this.optionsGrid = new System.Windows.Forms.PropertyGrid();
            this.importFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_horizontal)).BeginInit();
            this.splitContainer_horizontal.Panel1.SuspendLayout();
            this.splitContainer_horizontal.Panel2.SuspendLayout();
            this.splitContainer_horizontal.SuspendLayout();
            this.MounthTab.SuspendLayout();
            this.January.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_bottom_vertical)).BeginInit();
            this.splitContainer_bottom_vertical.Panel2.SuspendLayout();
            this.splitContainer_bottom_vertical.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1204, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFile,
            this.mgMenuOpenDatsList,
            this.ExitMG});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mgMenuOpenDatsList
            // 
            this.mgMenuOpenDatsList.Name = "mgMenuOpenDatsList";
            this.mgMenuOpenDatsList.Size = new System.Drawing.Size(180, 22);
            this.mgMenuOpenDatsList.Text = "OpenDictionaryList";
            // 
            // ExitMG
            // 
            this.ExitMG.Name = "ExitMG";
            this.ExitMG.Size = new System.Drawing.Size(180, 22);
            this.ExitMG.Text = "Exit";
            this.ExitMG.Click += new System.EventHandler(this.ExitMG_Click);
            // 
            // tableMain
            // 
            this.tableMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableMain.ColumnCount = 1;
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMain.Controls.Add(this.splitContainer_horizontal, 0, 0);
            this.tableMain.Location = new System.Drawing.Point(12, 27);
            this.tableMain.Name = "tableMain";
            this.tableMain.RowCount = 1;
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMain.Size = new System.Drawing.Size(1180, 513);
            this.tableMain.TabIndex = 1;
            // 
            // splitContainer_horizontal
            // 
            this.splitContainer_horizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer_horizontal.Location = new System.Drawing.Point(3, 3);
            this.splitContainer_horizontal.Name = "splitContainer_horizontal";
            this.splitContainer_horizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_horizontal.Panel1
            // 
            this.splitContainer_horizontal.Panel1.Controls.Add(this.MounthTab);
            this.splitContainer_horizontal.Panel1MinSize = 100;
            // 
            // splitContainer_horizontal.Panel2
            // 
            this.splitContainer_horizontal.Panel2.Controls.Add(this.splitContainer_bottom_vertical);
            this.splitContainer_horizontal.Panel2MinSize = 0;
            this.splitContainer_horizontal.Size = new System.Drawing.Size(1174, 507);
            this.splitContainer_horizontal.SplitterDistance = 250;
            this.splitContainer_horizontal.TabIndex = 0;
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
            this.MounthTab.Size = new System.Drawing.Size(1174, 250);
            this.MounthTab.TabIndex = 1;
            this.MounthTab.Selected += new System.Windows.Forms.TabControlEventHandler(this.MounthTab_Selected);
            this.MounthTab.TabIndexChanged += new System.EventHandler(this.MounthTab_TabIndexChanged);
            // 
            // January
            // 
            this.January.BackColor = System.Drawing.Color.Transparent;
            this.January.Controls.Add(this.dataViewer);
            this.January.Location = new System.Drawing.Point(4, 25);
            this.January.Name = "January";
            this.January.Padding = new System.Windows.Forms.Padding(3);
            this.January.Size = new System.Drawing.Size(1166, 221);
            this.January.TabIndex = 0;
            this.January.Text = "January";
            // 
            // dataViewer
            // 
            this.dataViewer.AllowUserToAddRows = false;
            this.dataViewer.AllowUserToDeleteRows = false;
            this.dataViewer.AllowUserToResizeRows = false;
            this.dataViewer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataViewer.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataViewer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataViewer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataViewer.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataViewer.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataViewer.Location = new System.Drawing.Point(3, 3);
            this.dataViewer.MultiSelect = false;
            this.dataViewer.Name = "dataViewer";
            this.dataViewer.ReadOnly = true;
            this.dataViewer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataViewer.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataViewer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataViewer.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataViewer.RowTemplate.Height = 25;
            this.dataViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataViewer.Size = new System.Drawing.Size(1160, 215);
            this.dataViewer.TabIndex = 2;
            // 
            // February
            // 
            this.February.BackColor = System.Drawing.Color.Transparent;
            this.February.Location = new System.Drawing.Point(4, 25);
            this.February.Name = "February";
            this.February.Padding = new System.Windows.Forms.Padding(3);
            this.February.Size = new System.Drawing.Size(1166, 221);
            this.February.TabIndex = 1;
            this.February.Text = "February";
            // 
            // March
            // 
            this.March.Location = new System.Drawing.Point(4, 25);
            this.March.Name = "March";
            this.March.Padding = new System.Windows.Forms.Padding(3);
            this.March.Size = new System.Drawing.Size(1166, 221);
            this.March.TabIndex = 2;
            this.March.Text = "March";
            this.March.UseVisualStyleBackColor = true;
            // 
            // April
            // 
            this.April.Location = new System.Drawing.Point(4, 25);
            this.April.Name = "April";
            this.April.Padding = new System.Windows.Forms.Padding(3);
            this.April.Size = new System.Drawing.Size(1166, 221);
            this.April.TabIndex = 3;
            this.April.Text = "April";
            this.April.UseVisualStyleBackColor = true;
            // 
            // May
            // 
            this.May.Location = new System.Drawing.Point(4, 25);
            this.May.Name = "May";
            this.May.Padding = new System.Windows.Forms.Padding(3);
            this.May.Size = new System.Drawing.Size(1166, 221);
            this.May.TabIndex = 4;
            this.May.Text = "May";
            this.May.UseVisualStyleBackColor = true;
            // 
            // June
            // 
            this.June.Location = new System.Drawing.Point(4, 25);
            this.June.Name = "June";
            this.June.Padding = new System.Windows.Forms.Padding(3);
            this.June.Size = new System.Drawing.Size(1166, 221);
            this.June.TabIndex = 5;
            this.June.Text = "June";
            this.June.UseVisualStyleBackColor = true;
            // 
            // July
            // 
            this.July.Location = new System.Drawing.Point(4, 25);
            this.July.Name = "July";
            this.July.Padding = new System.Windows.Forms.Padding(3);
            this.July.Size = new System.Drawing.Size(1166, 221);
            this.July.TabIndex = 6;
            this.July.Text = "July";
            this.July.UseVisualStyleBackColor = true;
            // 
            // August
            // 
            this.August.Location = new System.Drawing.Point(4, 25);
            this.August.Name = "August";
            this.August.Padding = new System.Windows.Forms.Padding(3);
            this.August.Size = new System.Drawing.Size(1166, 221);
            this.August.TabIndex = 7;
            this.August.Text = "August";
            this.August.UseVisualStyleBackColor = true;
            // 
            // September
            // 
            this.September.Location = new System.Drawing.Point(4, 25);
            this.September.Name = "September";
            this.September.Padding = new System.Windows.Forms.Padding(3);
            this.September.Size = new System.Drawing.Size(1166, 221);
            this.September.TabIndex = 8;
            this.September.Text = "September";
            this.September.UseVisualStyleBackColor = true;
            // 
            // October
            // 
            this.October.Location = new System.Drawing.Point(4, 25);
            this.October.Name = "October";
            this.October.Padding = new System.Windows.Forms.Padding(3);
            this.October.Size = new System.Drawing.Size(1166, 221);
            this.October.TabIndex = 9;
            this.October.Text = "October";
            this.October.UseVisualStyleBackColor = true;
            // 
            // November
            // 
            this.November.Location = new System.Drawing.Point(4, 25);
            this.November.Name = "November";
            this.November.Padding = new System.Windows.Forms.Padding(3);
            this.November.Size = new System.Drawing.Size(1166, 221);
            this.November.TabIndex = 10;
            this.November.Text = "November";
            this.November.UseVisualStyleBackColor = true;
            // 
            // December
            // 
            this.December.Location = new System.Drawing.Point(4, 25);
            this.December.Name = "December";
            this.December.Padding = new System.Windows.Forms.Padding(3);
            this.December.Size = new System.Drawing.Size(1166, 221);
            this.December.TabIndex = 11;
            this.December.Text = "December";
            this.December.UseVisualStyleBackColor = true;
            // 
            // splitContainer_bottom_vertical
            // 
            this.splitContainer_bottom_vertical.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer_bottom_vertical.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_bottom_vertical.Name = "splitContainer_bottom_vertical";
            this.splitContainer_bottom_vertical.Panel1MinSize = 200;
            // 
            // splitContainer_bottom_vertical.Panel2
            // 
            this.splitContainer_bottom_vertical.Panel2.Controls.Add(this.optionsGrid);
            this.splitContainer_bottom_vertical.Panel2MinSize = 285;
            this.splitContainer_bottom_vertical.Size = new System.Drawing.Size(1174, 253);
            this.splitContainer_bottom_vertical.SplitterDistance = 883;
            this.splitContainer_bottom_vertical.TabIndex = 0;
            // 
            // optionsGrid
            // 
            this.optionsGrid.BackColor = System.Drawing.SystemColors.Control;
            this.optionsGrid.CommandsBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.optionsGrid.CommandsVisibleIfAvailable = false;
            this.optionsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsGrid.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.optionsGrid.HelpBorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.optionsGrid.HelpVisible = false;
            this.optionsGrid.LineColor = System.Drawing.SystemColors.ControlLight;
            this.optionsGrid.Location = new System.Drawing.Point(0, 0);
            this.optionsGrid.Name = "optionsGrid";
            this.optionsGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.optionsGrid.Size = new System.Drawing.Size(287, 253);
            this.optionsGrid.TabIndex = 65;
            this.optionsGrid.UseCompatibleTextRendering = true;
            this.optionsGrid.ViewBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.optionsGrid.ViewBorderColor = System.Drawing.SystemColors.ActiveBorder;
            // 
            // importFile
            // 
            this.importFile.Name = "importFile";
            this.importFile.Size = new System.Drawing.Size(180, 22);
            this.importFile.Text = "Import";
            this.importFile.Click += new System.EventHandler(this.importFile_Click);
            // 
            // mgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1204, 552);
            this.Controls.Add(this.tableMain);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "mgForm";
            this.Text = "microgeneration";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mgForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableMain.ResumeLayout(false);
            this.splitContainer_horizontal.Panel1.ResumeLayout(false);
            this.splitContainer_horizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_horizontal)).EndInit();
            this.splitContainer_horizontal.ResumeLayout(false);
            this.MounthTab.ResumeLayout(false);
            this.January.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).EndInit();
            this.splitContainer_bottom_vertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_bottom_vertical)).EndInit();
            this.splitContainer_bottom_vertical.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem mgMenuOpenDatsList;
        private ToolStripMenuItem ExitMG;
        private TableLayoutPanel tableMain;
        private SplitContainer splitContainer_bottom_vertical;
        private DataGridView dataViewer;
        private PropertyGrid optionsGrid;
        private TabControl MounthTab;
        private TabPage January;
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
        private SplitContainer splitContainer_horizontal;
        private ToolStripMenuItem importFile;
    }
}