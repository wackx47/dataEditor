namespace dataEditor.data.forms
{
    partial class SignedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignedForm));
            this.TableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.ToolStripMain = new System.Windows.Forms.ToolStrip();
            this.btnOK = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddNew = new System.Windows.Forms.ToolStripButton();
            this.SelectorBox = new System.Windows.Forms.ComboBox();
            this.SignerGroupBox = new System.Windows.Forms.GroupBox();
            this.SignInfo = new System.Windows.Forms.TableLayoutPanel();
            this.txtSignFirstName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSignLastName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSignMidName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSignPosition = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSignAttorney = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSignNumber = new System.Windows.Forms.TextBox();
            this.TableLayoutMain.SuspendLayout();
            this.ToolStripMain.SuspendLayout();
            this.SignerGroupBox.SuspendLayout();
            this.SignInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutMain
            // 
            this.TableLayoutMain.ColumnCount = 1;
            this.TableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutMain.Controls.Add(this.ToolStripMain, 0, 2);
            this.TableLayoutMain.Controls.Add(this.SelectorBox, 0, 0);
            this.TableLayoutMain.Controls.Add(this.SignerGroupBox, 0, 3);
            this.TableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutMain.Name = "TableLayoutMain";
            this.TableLayoutMain.RowCount = 4;
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 209F));
            this.TableLayoutMain.Size = new System.Drawing.Size(391, 358);
            this.TableLayoutMain.TabIndex = 1;
            // 
            // ToolStripMain
            // 
            this.ToolStripMain.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ToolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOK,
            this.toolStripButton1,
            this.btnAddNew});
            this.ToolStripMain.Location = new System.Drawing.Point(1, 34);
            this.ToolStripMain.Margin = new System.Windows.Forms.Padding(1);
            this.ToolStripMain.Name = "ToolStripMain";
            this.ToolStripMain.Size = new System.Drawing.Size(389, 25);
            this.ToolStripMain.TabIndex = 0;
            this.ToolStripMain.Text = "Tools";
            // 
            // btnOK
            // 
            this.btnOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOK.Margin = new System.Windows.Forms.Padding(5, 1, 1, 1);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(23, 23);
            this.btnOK.Text = "Confirm";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAddNew
            // 
            this.btnAddNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.Image")));
            this.btnAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(1);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(23, 23);
            this.btnAddNew.Text = "Добавить";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // SelectorBox
            // 
            this.SelectorBox.BackColor = System.Drawing.SystemColors.Control;
            this.SelectorBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectorBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SelectorBox.FormattingEnabled = true;
            this.SelectorBox.Location = new System.Drawing.Point(3, 3);
            this.SelectorBox.Name = "SelectorBox";
            this.SelectorBox.Size = new System.Drawing.Size(385, 27);
            this.SelectorBox.TabIndex = 3;
            // 
            // SignerGroupBox
            // 
            this.SignerGroupBox.Controls.Add(this.SignInfo);
            this.SignerGroupBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SignerGroupBox.Location = new System.Drawing.Point(3, 63);
            this.SignerGroupBox.Name = "SignerGroupBox";
            this.SignerGroupBox.Size = new System.Drawing.Size(382, 287);
            this.SignerGroupBox.TabIndex = 2;
            this.SignerGroupBox.TabStop = false;
            this.SignerGroupBox.Text = "Подписант";
            // 
            // SignInfo
            // 
            this.SignInfo.AutoSize = true;
            this.SignInfo.ColumnCount = 2;
            this.SignInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.77273F));
            this.SignInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.22727F));
            this.SignInfo.Controls.Add(this.txtSignFirstName, 1, 0);
            this.SignInfo.Controls.Add(this.label8, 0, 0);
            this.SignInfo.Controls.Add(this.label9, 0, 1);
            this.SignInfo.Controls.Add(this.txtSignLastName, 1, 1);
            this.SignInfo.Controls.Add(this.label10, 0, 2);
            this.SignInfo.Controls.Add(this.txtSignMidName, 1, 2);
            this.SignInfo.Controls.Add(this.label11, 0, 3);
            this.SignInfo.Controls.Add(this.txtSignPosition, 1, 3);
            this.SignInfo.Controls.Add(this.label13, 0, 4);
            this.SignInfo.Controls.Add(this.txtSignAttorney, 1, 4);
            this.SignInfo.Controls.Add(this.label12, 0, 5);
            this.SignInfo.Controls.Add(this.txtSignNumber, 1, 5);
            this.SignInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SignInfo.Location = new System.Drawing.Point(3, 19);
            this.SignInfo.Margin = new System.Windows.Forms.Padding(1);
            this.SignInfo.Name = "SignInfo";
            this.SignInfo.RowCount = 7;
            this.SignInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.SignInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.SignInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.SignInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.SignInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.SignInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.SignInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.SignInfo.Size = new System.Drawing.Size(376, 265);
            this.SignInfo.TabIndex = 6;
            this.SignInfo.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.SignInfoBorderColor);
            // 
            // txtSignFirstName
            // 
            this.txtSignFirstName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSignFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSignFirstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSignFirstName.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSignFirstName.Location = new System.Drawing.Point(130, 0);
            this.txtSignFirstName.Margin = new System.Windows.Forms.Padding(0);
            this.txtSignFirstName.Name = "txtSignFirstName";
            this.txtSignFirstName.ShortcutsEnabled = false;
            this.txtSignFirstName.Size = new System.Drawing.Size(246, 21);
            this.txtSignFirstName.TabIndex = 4;
            this.txtSignFirstName.WordWrap = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(4, 2);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 2, 0, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Фамилия";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(4, 32);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 2, 0, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 14);
            this.label9.TabIndex = 1;
            this.label9.Text = "Имя";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSignLastName
            // 
            this.txtSignLastName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSignLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSignLastName.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSignLastName.Location = new System.Drawing.Point(130, 30);
            this.txtSignLastName.Margin = new System.Windows.Forms.Padding(0);
            this.txtSignLastName.Name = "txtSignLastName";
            this.txtSignLastName.ShortcutsEnabled = false;
            this.txtSignLastName.Size = new System.Drawing.Size(246, 21);
            this.txtSignLastName.TabIndex = 6;
            this.txtSignLastName.WordWrap = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(4, 62);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 2, 0, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 14);
            this.label10.TabIndex = 2;
            this.label10.Text = "Отчество";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSignMidName
            // 
            this.txtSignMidName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSignMidName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSignMidName.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSignMidName.Location = new System.Drawing.Point(130, 60);
            this.txtSignMidName.Margin = new System.Windows.Forms.Padding(0);
            this.txtSignMidName.Name = "txtSignMidName";
            this.txtSignMidName.ShortcutsEnabled = false;
            this.txtSignMidName.Size = new System.Drawing.Size(246, 21);
            this.txtSignMidName.TabIndex = 5;
            this.txtSignMidName.WordWrap = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(4, 126);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 2, 0, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 14);
            this.label11.TabIndex = 7;
            this.label11.Text = "Должность";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSignPosition
            // 
            this.txtSignPosition.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSignPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSignPosition.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSignPosition.Location = new System.Drawing.Point(130, 90);
            this.txtSignPosition.Margin = new System.Windows.Forms.Padding(0);
            this.txtSignPosition.Multiline = true;
            this.txtSignPosition.Name = "txtSignPosition";
            this.txtSignPosition.ShortcutsEnabled = false;
            this.txtSignPosition.Size = new System.Drawing.Size(246, 55);
            this.txtSignPosition.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(4, 191);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 2, 0, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 14);
            this.label13.TabIndex = 11;
            this.label13.Text = "Доверенность";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSignAttorney
            // 
            this.txtSignAttorney.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSignAttorney.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSignAttorney.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSignAttorney.Location = new System.Drawing.Point(130, 155);
            this.txtSignAttorney.Margin = new System.Windows.Forms.Padding(0);
            this.txtSignAttorney.Multiline = true;
            this.txtSignAttorney.Name = "txtSignAttorney";
            this.txtSignAttorney.ShortcutsEnabled = false;
            this.txtSignAttorney.Size = new System.Drawing.Size(246, 55);
            this.txtSignAttorney.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(4, 222);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 2, 0, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 14);
            this.label12.TabIndex = 9;
            this.label12.Text = "Табельный номер";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSignNumber
            // 
            this.txtSignNumber.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSignNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSignNumber.Enabled = false;
            this.txtSignNumber.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSignNumber.Location = new System.Drawing.Point(130, 220);
            this.txtSignNumber.Margin = new System.Windows.Forms.Padding(0);
            this.txtSignNumber.Name = "txtSignNumber";
            this.txtSignNumber.ShortcutsEnabled = false;
            this.txtSignNumber.Size = new System.Drawing.Size(107, 21);
            this.txtSignNumber.TabIndex = 10;
            this.txtSignNumber.WordWrap = false;
            // 
            // SignedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 358);
            this.Controls.Add(this.TableLayoutMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SignedForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Подписант";
            this.TableLayoutMain.ResumeLayout(false);
            this.TableLayoutMain.PerformLayout();
            this.ToolStripMain.ResumeLayout(false);
            this.ToolStripMain.PerformLayout();
            this.SignerGroupBox.ResumeLayout(false);
            this.SignerGroupBox.PerformLayout();
            this.SignInfo.ResumeLayout(false);
            this.SignInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel TableLayoutMain;
        private ToolStrip ToolStripMain;
        private ToolStripButton btnOK;
        private ToolStripSeparator toolStripButton1;
        private ToolStripButton btnAddNew;
        private ComboBox SelectorBox;
        private GroupBox SignerGroupBox;
        private TableLayoutPanel SignInfo;
        private TextBox txtSignFirstName;
        private Label label8;
        private Label label9;
        private TextBox txtSignLastName;
        private Label label10;
        private TextBox txtSignMidName;
        private Label label11;
        private TextBox txtSignPosition;
        private Label label13;
        private TextBox txtSignAttorney;
        private Label label12;
        private TextBox txtSignNumber;
    }
}