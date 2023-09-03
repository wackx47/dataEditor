using System.Windows.Forms;

namespace dataEditor
{
    partial class Settings
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Common");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("ExcelReader");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Microgeneration");
            this.optionsGrid = new System.Windows.Forms.PropertyGrid();
            this.SettingsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SettingsTreeView = new System.Windows.Forms.TreeView();
            this.setBtnSave = new System.Windows.Forms.Button();
            this.setBtnCancel = new System.Windows.Forms.Button();
            this.SettingsLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // optionsGrid
            // 
            this.optionsGrid.BackColor = System.Drawing.SystemColors.Control;
            this.optionsGrid.CommandsBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.optionsGrid.CommandsVisibleIfAvailable = false;
            this.optionsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsGrid.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.optionsGrid.HelpBorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.optionsGrid.LineColor = System.Drawing.SystemColors.ControlLight;
            this.optionsGrid.Location = new System.Drawing.Point(173, 3);
            this.optionsGrid.Name = "optionsGrid";
            this.optionsGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.optionsGrid.Size = new System.Drawing.Size(508, 395);
            this.optionsGrid.TabIndex = 65;
            this.optionsGrid.ToolbarVisible = false;
            this.optionsGrid.UseCompatibleTextRendering = true;
            this.optionsGrid.ViewBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.optionsGrid.ViewBorderColor = System.Drawing.SystemColors.ActiveBorder;
            // 
            // SettingsLayoutPanel
            // 
            this.SettingsLayoutPanel.ColumnCount = 2;
            this.SettingsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.SettingsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.SettingsLayoutPanel.Controls.Add(this.SettingsTreeView, 0, 0);
            this.SettingsLayoutPanel.Controls.Add(this.optionsGrid, 1, 0);
            this.SettingsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SettingsLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.SettingsLayoutPanel.Name = "SettingsLayoutPanel";
            this.SettingsLayoutPanel.RowCount = 2;
            this.SettingsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 401F));
            this.SettingsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SettingsLayoutPanel.Size = new System.Drawing.Size(684, 403);
            this.SettingsLayoutPanel.TabIndex = 66;
            // 
            // SettingsTreeView
            // 
            this.SettingsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsTreeView.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SettingsTreeView.Location = new System.Drawing.Point(3, 3);
            this.SettingsTreeView.Name = "SettingsTreeView";
            treeNode1.Name = "setCommon";
            treeNode1.Text = "Common";
            treeNode2.Name = "setExcelReader";
            treeNode2.Text = "ExcelReader";
            treeNode3.Name = "setMicrogeneration";
            treeNode3.Text = "Microgeneration";
            this.SettingsTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.SettingsTreeView.Size = new System.Drawing.Size(164, 395);
            this.SettingsTreeView.TabIndex = 66;
            this.SettingsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SettingsTreeView_AfterSelect);
            // 
            // setBtnSave
            // 
            this.setBtnSave.Location = new System.Drawing.Point(525, 404);
            this.setBtnSave.Name = "setBtnSave";
            this.setBtnSave.Size = new System.Drawing.Size(75, 26);
            this.setBtnSave.TabIndex = 67;
            this.setBtnSave.Text = "Save";
            this.setBtnSave.UseVisualStyleBackColor = true;
            this.setBtnSave.Click += new System.EventHandler(this.setBtnSave_Click);
            // 
            // setBtnCancel
            // 
            this.setBtnCancel.Location = new System.Drawing.Point(606, 404);
            this.setBtnCancel.Name = "setBtnCancel";
            this.setBtnCancel.Size = new System.Drawing.Size(75, 26);
            this.setBtnCancel.TabIndex = 68;
            this.setBtnCancel.Text = "Cancel";
            this.setBtnCancel.UseVisualStyleBackColor = true;
            this.setBtnCancel.Click += new System.EventHandler(this.setBtnCancel_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 435);
            this.Controls.Add(this.SettingsLayoutPanel);
            this.Controls.Add(this.setBtnSave);
            this.Controls.Add(this.setBtnCancel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(430, 469);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.SettingsLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public PropertyGrid optionsGrid;
        private TableLayoutPanel SettingsLayoutPanel;
        public TreeView SettingsTreeView;
        private Button setBtnSave;
        private Button setBtnCancel;
    }
}