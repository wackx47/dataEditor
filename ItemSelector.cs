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
    public partial class ItemSelector : Form
    {
        public ItemSelector()
        {
            InitializeComponent();
        }

        public int selectedIndexSheet
        {
            get { return sheetsList.SelectedIndex; }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (sheetsList.SelectedIndex != -1)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void sheetsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sheetsList.SelectedIndex != -1)
            {
                btnSelect.Enabled = true;
            }
            else
            {
                btnSelect.Enabled = false;
            }
        }
    }
}
