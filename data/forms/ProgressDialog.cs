using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dataEditor
{
    public partial class ProgressDialog : Form
    {
        public string Message
        {
            set { this.stepLabel.Text = value; }
        }

        public int ProgressValue
        {
            set { this.progressBar1.Value = value; }
        }

        public EventHandler stopProgress;
        public ProgressDialog()
        {
            InitializeComponent();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            if (stopProgress != null)
            {
                stopProgress(sender, e);
            }
        }
    }
}
