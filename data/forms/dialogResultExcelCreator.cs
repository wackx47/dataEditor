using NPOI.POIFS.Crypt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataEditor.data.forms
{
    public partial class dialogResultExcelCreator : Form
    {

        public dialogResultExcelCreator()
        {
            InitializeComponent();
        }

        public int key = 0;

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            key = 1;
            DialogResult = DialogResult.OK;
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            key = 2;
            DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            key = 0;
            DialogResult = DialogResult.Cancel;
        }
    }
}
