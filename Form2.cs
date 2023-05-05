using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataEditor
{
    public partial class mgForm : Form
    {
        public mgForm()
        {
            InitializeComponent();
        }

        private void mgForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void ExitMG_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            Application.OpenForms["mgForm"].Hide();
        }

        private void importFile_Click(object sender, EventArgs e)
        {

        }
    }
}
