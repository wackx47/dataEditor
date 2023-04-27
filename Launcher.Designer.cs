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
            this.startMG = new System.Windows.Forms.Button();
            this.startUR = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.ChangeLogBox = new System.Windows.Forms.TextBox();
            this.labelBuild = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startMG
            // 
            this.startMG.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.startMG.Location = new System.Drawing.Point(12, 294);
            this.startMG.Name = "startMG";
            this.startMG.Size = new System.Drawing.Size(182, 55);
            this.startMG.TabIndex = 1;
            this.startMG.Text = "microgeneration";
            this.startMG.UseVisualStyleBackColor = true;
            this.startMG.Click += new System.EventHandler(this.startMG_Click);
            // 
            // startUR
            // 
            this.startUR.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.startUR.Location = new System.Drawing.Point(12, 233);
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
            this.lblCaption.Location = new System.Drawing.Point(12, 23);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(182, 29);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "dataEditor project";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelVersion.Location = new System.Drawing.Point(21, 52);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(51, 20);
            this.labelVersion.TabIndex = 3;
            this.labelVersion.Text = "version";
            // 
            // ChangeLogBox
            // 
            this.ChangeLogBox.Location = new System.Drawing.Point(200, 31);
            this.ChangeLogBox.MaxLength = 0;
            this.ChangeLogBox.Multiline = true;
            this.ChangeLogBox.Name = "ChangeLogBox";
            this.ChangeLogBox.ReadOnly = true;
            this.ChangeLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ChangeLogBox.Size = new System.Drawing.Size(372, 318);
            this.ChangeLogBox.TabIndex = 26;
            this.ChangeLogBox.WordWrap = false;
            // 
            // labelBuild
            // 
            this.labelBuild.AutoSize = true;
            this.labelBuild.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelBuild.Location = new System.Drawing.Point(21, 75);
            this.labelBuild.Name = "labelBuild";
            this.labelBuild.Size = new System.Drawing.Size(36, 20);
            this.labelBuild.TabIndex = 27;
            this.labelBuild.Text = "build";
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.labelBuild);
            this.Controls.Add(this.ChangeLogBox);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.startUR);
            this.Controls.Add(this.startMG);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimizeBox = false;
            this.Name = "StartScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dataEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button startMG;
        private Button startUR;
        private Label lblCaption;
        private Label labelVersion;
        private TextBox ChangeLogBox;
        private Label labelBuild;
    }
}