using System.Diagnostics;
using System.Reflection;

namespace dataEditor
{
    partial class StartScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartScreen));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Excel");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("MKG");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("DAT menu", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.lblCaption = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.ChangeLogBox = new System.Windows.Forms.TextBox();
            this.labelBuild = new System.Windows.Forms.Label();
            this.groupBoxLauncher = new System.Windows.Forms.GroupBox();
            this.NavToolStrip = new System.Windows.Forms.ToolStrip();
            this.navBtnEntry = new System.Windows.Forms.ToolStripButton();
            this.navCmbxAccessList = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.TableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.NavTreeView = new System.Windows.Forms.TreeView();
            this.groupBoxLauncher.SuspendLayout();
            this.NavToolStrip.SuspendLayout();
            this.TableLayoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaption.Font = new System.Drawing.Font("Tahoma", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblCaption.Location = new System.Drawing.Point(1, 1);
            this.lblCaption.Margin = new System.Windows.Forms.Padding(1);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(612, 29);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "dataEditor easy access";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelVersion.Location = new System.Drawing.Point(1, 367);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(1);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(45, 18);
            this.labelVersion.TabIndex = 3;
            this.labelVersion.Text = "version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChangeLogBox
            // 
            this.ChangeLogBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChangeLogBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChangeLogBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChangeLogBox.Location = new System.Drawing.Point(3, 18);
            this.ChangeLogBox.MaxLength = 0;
            this.ChangeLogBox.Multiline = true;
            this.ChangeLogBox.Name = "ChangeLogBox";
            this.ChangeLogBox.ReadOnly = true;
            this.ChangeLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ChangeLogBox.Size = new System.Drawing.Size(396, 308);
            this.ChangeLogBox.TabIndex = 26;
            this.ChangeLogBox.WordWrap = false;
            // 
            // labelBuild
            // 
            this.labelBuild.AutoSize = true;
            this.labelBuild.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelBuild.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelBuild.Location = new System.Drawing.Point(1, 387);
            this.labelBuild.Margin = new System.Windows.Forms.Padding(1);
            this.labelBuild.Name = "labelBuild";
            this.labelBuild.Size = new System.Drawing.Size(32, 18);
            this.labelBuild.TabIndex = 27;
            this.labelBuild.Text = "build";
            this.labelBuild.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxLauncher
            // 
            this.groupBoxLauncher.Controls.Add(this.ChangeLogBox);
            this.groupBoxLauncher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLauncher.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxLauncher.ForeColor = System.Drawing.SystemColors.InfoText;
            this.groupBoxLauncher.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLauncher.Name = "groupBoxLauncher";
            this.groupBoxLauncher.Size = new System.Drawing.Size(402, 329);
            this.groupBoxLauncher.TabIndex = 28;
            this.groupBoxLauncher.TabStop = false;
            this.groupBoxLauncher.Text = "Changelogs:";
            // 
            // NavToolStrip
            // 
            this.NavToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.NavToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navBtnEntry,
            this.navCmbxAccessList,
            this.toolStripSeparator7});
            this.NavToolStrip.Location = new System.Drawing.Point(5, 5);
            this.NavToolStrip.Name = "NavToolStrip";
            this.NavToolStrip.Padding = new System.Windows.Forms.Padding(10, 1, 1, 1);
            this.NavToolStrip.Size = new System.Drawing.Size(614, 25);
            this.NavToolStrip.TabIndex = 80;
            this.NavToolStrip.Text = "mgTools";
            // 
            // navBtnEntry
            // 
            this.navBtnEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navBtnEntry.Image = ((System.Drawing.Image)(resources.GetObject("navBtnEntry.Image")));
            this.navBtnEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navBtnEntry.Name = "navBtnEntry";
            this.navBtnEntry.Size = new System.Drawing.Size(23, 20);
            this.navBtnEntry.Text = "Enter";
            this.navBtnEntry.Click += new System.EventHandler(this.startUR_Click);
            // 
            // navCmbxAccessList
            // 
            this.navCmbxAccessList.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.navCmbxAccessList.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.navCmbxAccessList.Name = "navCmbxAccessList";
            this.navCmbxAccessList.Size = new System.Drawing.Size(150, 23);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // TableLayoutMain
            // 
            this.TableLayoutMain.ColumnCount = 1;
            this.TableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutMain.Controls.Add(this.lblCaption, 0, 0);
            this.TableLayoutMain.Controls.Add(this.splitContainerMain, 0, 1);
            this.TableLayoutMain.Controls.Add(this.labelBuild, 0, 3);
            this.TableLayoutMain.Controls.Add(this.labelVersion, 0, 2);
            this.TableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutMain.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TableLayoutMain.Location = new System.Drawing.Point(5, 30);
            this.TableLayoutMain.Name = "TableLayoutMain";
            this.TableLayoutMain.RowCount = 4;
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutMain.Size = new System.Drawing.Size(614, 406);
            this.TableLayoutMain.TabIndex = 81;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(3, 34);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.NavTreeView);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.groupBoxLauncher);
            this.splitContainerMain.Size = new System.Drawing.Size(608, 329);
            this.splitContainerMain.SplitterDistance = 202;
            this.splitContainerMain.TabIndex = 3;
            // 
            // NavTreeView
            // 
            this.NavTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NavTreeView.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NavTreeView.Location = new System.Drawing.Point(0, 0);
            this.NavTreeView.Name = "NavTreeView";
            treeNode1.Name = "ExcelReader";
            treeNode1.Text = "Excel";
            treeNode2.Name = "Microgeneration";
            treeNode2.Text = "MKG";
            treeNode3.Name = "MainNode";
            treeNode3.Text = "DAT menu";
            this.NavTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.NavTreeView.Size = new System.Drawing.Size(202, 329);
            this.NavTreeView.TabIndex = 1;
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.TableLayoutMain);
            this.Controls.Add(this.NavToolStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartScreen";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dataEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartScreen_FormClosing);
            this.groupBoxLauncher.ResumeLayout(false);
            this.groupBoxLauncher.PerformLayout();
            this.NavToolStrip.ResumeLayout(false);
            this.NavToolStrip.PerformLayout();
            this.TableLayoutMain.ResumeLayout(false);
            this.TableLayoutMain.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblCaption;
        private Label labelVersion;
        private TextBox ChangeLogBox;
        private Label labelBuild;
        private GroupBox groupBoxLauncher;
        private ToolStrip NavToolStrip;
        private ToolStripButton navBtnEntry;
        private ToolStripComboBox navCmbxAccessList;
        private ToolStripSeparator toolStripSeparator7;
        private TableLayoutPanel TableLayoutMain;
        private SplitContainer splitContainerMain;
        private TreeView NavTreeView;
    }
}