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
            this.startUR = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.ChangeLogBox = new System.Windows.Forms.TextBox();
            this.labelBuild = new System.Windows.Forms.Label();
            this.groupBoxLauncher = new System.Windows.Forms.GroupBox();
            this.groupBoxLauncher.SuspendLayout();
            this.SuspendLayout();
            // 
            // startUR
            // 
            this.startUR.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.startUR.Location = new System.Drawing.Point(12, 294);
            this.startUR.Name = "startUR";
            this.startUR.Size = new System.Drawing.Size(182, 55);
            this.startUR.TabIndex = 0;
            this.startUR.Text = "universalReader";
            this.startUR.UseVisualStyleBackColor = true;
            this.startUR.Click += new System.EventHandler(this.startUR_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Arial Narrow", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblCaption.Location = new System.Drawing.Point(12, 12);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(182, 29);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "dataEditor project";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelVersion.Location = new System.Drawing.Point(200, 300);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(51, 20);
            this.labelVersion.TabIndex = 3;
            this.labelVersion.Text = "version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChangeLogBox
            // 
            this.ChangeLogBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChangeLogBox.Location = new System.Drawing.Point(3, 31);
            this.ChangeLogBox.MaxLength = 0;
            this.ChangeLogBox.Multiline = true;
            this.ChangeLogBox.Name = "ChangeLogBox";
            this.ChangeLogBox.ReadOnly = true;
            this.ChangeLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ChangeLogBox.Size = new System.Drawing.Size(554, 210);
            this.ChangeLogBox.TabIndex = 26;
            this.ChangeLogBox.WordWrap = false;
            // 
            // labelBuild
            // 
            this.labelBuild.AutoSize = true;
            this.labelBuild.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelBuild.Location = new System.Drawing.Point(202, 320);
            this.labelBuild.Name = "labelBuild";
            this.labelBuild.Size = new System.Drawing.Size(36, 20);
            this.labelBuild.TabIndex = 27;
            this.labelBuild.Text = "build";
            this.labelBuild.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxLauncher
            // 
            this.groupBoxLauncher.Controls.Add(this.ChangeLogBox);
            this.groupBoxLauncher.Location = new System.Drawing.Point(12, 44);
            this.groupBoxLauncher.Name = "groupBoxLauncher";
            this.groupBoxLauncher.Size = new System.Drawing.Size(560, 244);
            this.groupBoxLauncher.TabIndex = 28;
            this.groupBoxLauncher.TabStop = false;
            this.groupBoxLauncher.Text = "Changelogs:";
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.groupBoxLauncher);
            this.Controls.Add(this.labelBuild);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.startUR);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dataEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartScreen_FormClosing);
            this.groupBoxLauncher.ResumeLayout(false);
            this.groupBoxLauncher.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button startUR;
        private Label lblCaption;
        private Label labelVersion;
        private TextBox ChangeLogBox;
        private Label labelBuild;
        private GroupBox groupBoxLauncher;
    }
}