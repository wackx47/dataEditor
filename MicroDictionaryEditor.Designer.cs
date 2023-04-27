using System.Windows.Forms;

namespace dataEditor
{
    partial class mgDatsEditor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridDictionary = new System.Windows.Forms.DataGridView();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mgMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mgMenuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mgMenuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mgMenuShowInWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.mgElementAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listGTP = new System.Windows.Forms.ComboBox();
            this.mgRightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mgMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.Agreement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateIntoForce = new dataEditor.mgDatsEditor.CalendarColumn();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PWR = new dataEditor.NumericUpDownDataGrid.NumericUpDownColumn();
            this.Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Other = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDictionary)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.mgRightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridDictionary
            // 
            this.dataGridDictionary.AllowUserToAddRows = false;
            this.dataGridDictionary.AllowUserToResizeRows = false;
            this.dataGridDictionary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridDictionary.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridDictionary.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridDictionary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDictionary.ColumnHeadersHeight = 30;
            this.dataGridDictionary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridDictionary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Agreement,
            this.DateIntoForce,
            this.Type,
            this.FullName,
            this.PhoneNumber,
            this.Mail,
            this.INN,
            this.PWR,
            this.Status,
            this.Other});
            this.dataGridDictionary.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridDictionary.EnableHeadersVisualStyles = false;
            this.dataGridDictionary.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridDictionary.Location = new System.Drawing.Point(12, 27);
            this.dataGridDictionary.Name = "dataGridDictionary";
            this.dataGridDictionary.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridDictionary.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridDictionary.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridDictionary.RowTemplate.Height = 20;
            this.dataGridDictionary.Size = new System.Drawing.Size(1133, 385);
            this.dataGridDictionary.TabIndex = 0;
            this.dataGridDictionary.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridDictionary_EditingControlShowing);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddNew.Location = new System.Drawing.Point(12, 418);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 1;
            this.btnAddNew.Text = "AddNew";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mgMenuFile,
            this.mgElementAdd});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1157, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mgMenuFile
            // 
            this.mgMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mgMenuFileOpen,
            this.mgMenuFileSave,
            this.mgMenuShowInWindows});
            this.mgMenuFile.Name = "mgMenuFile";
            this.mgMenuFile.Size = new System.Drawing.Size(37, 20);
            this.mgMenuFile.Text = "File";
            // 
            // mgMenuFileOpen
            // 
            this.mgMenuFileOpen.Name = "mgMenuFileOpen";
            this.mgMenuFileOpen.Size = new System.Drawing.Size(168, 22);
            this.mgMenuFileOpen.Text = "Open";
            this.mgMenuFileOpen.Click += new System.EventHandler(this.mgMenuFileOpen_Click);
            // 
            // mgMenuFileSave
            // 
            this.mgMenuFileSave.Name = "mgMenuFileSave";
            this.mgMenuFileSave.Size = new System.Drawing.Size(168, 22);
            this.mgMenuFileSave.Text = "Save";
            this.mgMenuFileSave.Click += new System.EventHandler(this.mgMenuFileSave_Click);
            // 
            // mgMenuShowInWindows
            // 
            this.mgMenuShowInWindows.Name = "mgMenuShowInWindows";
            this.mgMenuShowInWindows.Size = new System.Drawing.Size(168, 22);
            this.mgMenuShowInWindows.Text = "Show in Windows";
            this.mgMenuShowInWindows.Click += new System.EventHandler(this.mgMenuShowInWindows_Click);
            // 
            // mgElementAdd
            // 
            this.mgElementAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1});
            this.mgElementAdd.Name = "mgElementAdd";
            this.mgElementAdd.Size = new System.Drawing.Size(67, 20);
            this.mgElementAdd.Text = "Elements";
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(96, 22);
            this.addToolStripMenuItem1.Text = "Add";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.addToolStripMenuItem1_Click);
            // 
            // listGTP
            // 
            this.listGTP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listGTP.FormattingEnabled = true;
            this.listGTP.Items.AddRange(new object[] {
            "KUBANESK"});
            this.listGTP.Location = new System.Drawing.Point(93, 418);
            this.listGTP.Name = "listGTP";
            this.listGTP.Size = new System.Drawing.Size(121, 23);
            this.listGTP.TabIndex = 3;
            // 
            // mgRightClickMenu
            // 
            this.mgRightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mgMenuDelete});
            this.mgRightClickMenu.Name = "mgRightClickMenu";
            this.mgRightClickMenu.Size = new System.Drawing.Size(183, 26);
            // 
            // mgMenuDelete
            // 
            this.mgMenuDelete.Name = "mgMenuDelete";
            this.mgMenuDelete.Size = new System.Drawing.Size(182, 22);
            this.mgMenuDelete.Text = "Remove Contractors";
            this.mgMenuDelete.Click += new System.EventHandler(this.RemoveContractors_Click);
            // 
            // Agreement
            // 
            this.Agreement.HeaderText = "Agreement";
            this.Agreement.Name = "Agreement";
            this.Agreement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Agreement.Width = 140;
            // 
            // DateIntoForce
            // 
            this.DateIntoForce.HeaderText = "Date";
            this.DateIntoForce.Name = "DateIntoForce";
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Items.AddRange(new object[] {
            "ФЗ",
            "ЮЛ"});
            this.Type.Name = "Type";
            this.Type.Width = 50;
            // 
            // FullName
            // 
            this.FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FullName.HeaderText = "Name";
            this.FullName.Name = "FullName";
            this.FullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PhoneNumber.HeaderText = "PhoneNumber";
            this.PhoneNumber.Name = "PhoneNumber";
            // 
            // Mail
            // 
            this.Mail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Mail.HeaderText = "Mail";
            this.Mail.Name = "Mail";
            // 
            // INN
            // 
            this.INN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.INN.HeaderText = "INN";
            this.INN.Name = "INN";
            this.INN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.INN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PWR
            // 
            this.PWR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PWR.HeaderText = "Pmax";
            this.PWR.Name = "PWR";
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Status.HeaderText = "Status";
            this.Status.Items.AddRange(new object[] {
            "Действует",
            "Расторгнут"});
            this.Status.Name = "Status";
            // 
            // Other
            // 
            this.Other.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Other.HeaderText = "Other";
            this.Other.Name = "Other";
            this.Other.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Other.Width = 44;
            // 
            // mgDatsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 450);
            this.Controls.Add(this.listGTP);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.dataGridDictionary);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mgDatsEditor";
            this.Text = "DatsEditor";
            this.Load += new System.EventHandler(this.mgDatsEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDictionary)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mgRightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridDictionary;
        private Button btnAddNew;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mgMenuFile;
        private ToolStripMenuItem mgMenuFileOpen;
        private ToolStripMenuItem mgMenuFileSave;
        private ToolStripMenuItem mgElementAdd;
        private ToolStripMenuItem addToolStripMenuItem1;
        public ComboBox listGTP;
        private ContextMenuStrip mgRightClickMenu;
        private ToolStripMenuItem mgMenuDelete;
        private ToolStripMenuItem mgMenuShowInWindows;
        private DataGridViewTextBoxColumn Agreement;
        private CalendarColumn DateIntoForce;
        private DataGridViewComboBoxColumn Type;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Mail;
        private DataGridViewTextBoxColumn INN;
        private NumericUpDownDataGrid.NumericUpDownColumn PWR;
        private DataGridViewComboBoxColumn Status;
        private DataGridViewTextBoxColumn Other;
    }
}