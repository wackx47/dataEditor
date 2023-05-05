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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMG = new System.Windows.Forms.ToolStripMenuItem();
            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer_horizontal = new System.Windows.Forms.SplitContainer();
            this.splitContainer_bottom_vertical = new System.Windows.Forms.SplitContainer();
            this.menuStrip1.SuspendLayout();
            this.tableMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_horizontal)).BeginInit();
            this.splitContainer_horizontal.Panel2.SuspendLayout();
            this.splitContainer_horizontal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_bottom_vertical)).BeginInit();
            this.splitContainer_bottom_vertical.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(944, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitMG});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // ExitMG
            // 
            this.ExitMG.Name = "ExitMG";
            this.ExitMG.Size = new System.Drawing.Size(93, 22);
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
            this.tableMain.Size = new System.Drawing.Size(920, 562);
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
            this.splitContainer_horizontal.Panel1MinSize = 100;
            // 
            // splitContainer_horizontal.Panel2
            // 
            this.splitContainer_horizontal.Panel2.Controls.Add(this.splitContainer_bottom_vertical);
            this.splitContainer_horizontal.Panel2MinSize = 0;
            this.splitContainer_horizontal.Size = new System.Drawing.Size(914, 556);
            this.splitContainer_horizontal.SplitterDistance = 273;
            this.splitContainer_horizontal.TabIndex = 0;
            // 
            // splitContainer_bottom_vertical
            // 
            this.splitContainer_bottom_vertical.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer_bottom_vertical.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_bottom_vertical.Name = "splitContainer_bottom_vertical";
            this.splitContainer_bottom_vertical.Panel1MinSize = 200;
            this.splitContainer_bottom_vertical.Panel2MinSize = 285;
            this.splitContainer_bottom_vertical.Size = new System.Drawing.Size(914, 279);
            this.splitContainer_bottom_vertical.SplitterDistance = 625;
            this.splitContainer_bottom_vertical.TabIndex = 0;
            // 
            // mgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(944, 601);
            this.Controls.Add(this.tableMain);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "mgForm";
            this.Text = "betaForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mgForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableMain.ResumeLayout(false);
            this.splitContainer_horizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_horizontal)).EndInit();
            this.splitContainer_horizontal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_bottom_vertical)).EndInit();
            this.splitContainer_bottom_vertical.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem ExitMG;
        private TableLayoutPanel tableMain;
        private SplitContainer splitContainer_bottom_vertical;
        private SplitContainer splitContainer_horizontal;
    }
}