namespace dataEditor
{
    partial class inputDataHandle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inputDataHandle));
            this.NavToolStrip = new System.Windows.Forms.ToolStrip();
            this.inputBtnEntry = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.inputTextBox = new System.Windows.Forms.RichTextBox();
            this.inputTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lineNumbersTable = new System.Windows.Forms.TableLayoutPanel();
            this.NavToolStrip.SuspendLayout();
            this.inputTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // NavToolStrip
            // 
            this.NavToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.NavToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputBtnEntry,
            this.toolStripSeparator7,
            this.toolStripComboBox1});
            this.NavToolStrip.Location = new System.Drawing.Point(2, 0);
            this.NavToolStrip.Margin = new System.Windows.Forms.Padding(1);
            this.NavToolStrip.Name = "NavToolStrip";
            this.NavToolStrip.Padding = new System.Windows.Forms.Padding(5, 2, 1, 1);
            this.NavToolStrip.Size = new System.Drawing.Size(460, 27);
            this.NavToolStrip.TabIndex = 81;
            this.NavToolStrip.Text = "mgTools";
            // 
            // inputBtnEntry
            // 
            this.inputBtnEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.inputBtnEntry.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inputBtnEntry.Image = ((System.Drawing.Image)(resources.GetObject("inputBtnEntry.Image")));
            this.inputBtnEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.inputBtnEntry.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.inputBtnEntry.Name = "inputBtnEntry";
            this.inputBtnEntry.Size = new System.Drawing.Size(23, 21);
            this.inputBtnEntry.Text = "Enter";
            this.inputBtnEntry.Click += new System.EventHandler(this.inputBtnEntry_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 24);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.toolStripComboBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStripComboBox1.Margin = new System.Windows.Forms.Padding(1);
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 22);
            // 
            // inputTextBox
            // 
            this.inputTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.inputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputTextBox.DetectUrls = false;
            this.inputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inputTextBox.Location = new System.Drawing.Point(2, 2);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.inputTextBox.Size = new System.Drawing.Size(416, 565);
            this.inputTextBox.TabIndex = 83;
            this.inputTextBox.Text = "";
            this.inputTextBox.WordWrap = false;
            this.inputTextBox.SelectionChanged += new System.EventHandler(this.inputTextBoxHRS_SelectionChanged);
            this.inputTextBox.VScroll += new System.EventHandler(this.inputTextBoxHRS_VScroll);
            this.inputTextBox.TextChanged += new System.EventHandler(this.inputTextBoxHRS_TextChanged);
            this.inputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTextBoxHRS_KeyDown);
            // 
            // inputTableLayout
            // 
            this.inputTableLayout.ColumnCount = 1;
            this.inputTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.inputTableLayout.Controls.Add(this.inputTextBox, 0, 0);
            this.inputTableLayout.Location = new System.Drawing.Point(42, 30);
            this.inputTableLayout.Margin = new System.Windows.Forms.Padding(1);
            this.inputTableLayout.Name = "inputTableLayout";
            this.inputTableLayout.Padding = new System.Windows.Forms.Padding(1);
            this.inputTableLayout.RowCount = 1;
            this.inputTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.inputTableLayout.Size = new System.Drawing.Size(420, 569);
            this.inputTableLayout.TabIndex = 84;
            this.inputTableLayout.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.RichTextBoxBorder);
            // 
            // lineNumbersTable
            // 
            this.lineNumbersTable.ColumnCount = 1;
            this.lineNumbersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lineNumbersTable.Location = new System.Drawing.Point(2, 30);
            this.lineNumbersTable.Margin = new System.Windows.Forms.Padding(1);
            this.lineNumbersTable.Name = "lineNumbersTable";
            this.lineNumbersTable.RowCount = 1;
            this.lineNumbersTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lineNumbersTable.Size = new System.Drawing.Size(38, 569);
            this.lineNumbersTable.TabIndex = 85;
            // 
            // inputDataHandle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 601);
            this.Controls.Add(this.lineNumbersTable);
            this.Controls.Add(this.NavToolStrip);
            this.Controls.Add(this.inputTableLayout);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "inputDataHandle";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HandleInputData";
            this.Shown += new System.EventHandler(this.inputDataHandle_Shown);
            this.NavToolStrip.ResumeLayout(false);
            this.NavToolStrip.PerformLayout();
            this.inputTableLayout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ToolStrip NavToolStrip;
        private ToolStripButton inputBtnEntry;
        private ToolStripSeparator toolStripSeparator7;
        private RichTextBox inputTextBox;
        private TableLayoutPanel inputTableLayout;
        private ToolStripComboBox toolStripComboBox1;
        private TableLayoutPanel lineNumbersTable;
    }
}