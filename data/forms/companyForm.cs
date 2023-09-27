using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataEditor.data.forms
{
    public partial class companyForm : Form
    {
        public companyForm()
        {
            InitializeComponent();
        }


        private void MainInfoBorderColor(object sender, TableLayoutCellPaintEventArgs e)
        {
            TableLayoutRowStyleCollection styles = MainInfo.RowStyles;

            var panel = sender as TableLayoutPanel;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            using (var pen = new Pen(Color.FromArgb(255, 100, 100, 100), 1))
            {
                pen.Alignment = PenAlignment.Center;
                pen.DashStyle = DashStyle.Solid;

                if (e.Column == 0)
                {
                    var bottomLeft = new Point(e.CellBounds.Left + 2, e.CellBounds.Bottom - (Convert.ToInt32(styles[e.Row].Height) - 20));
                    var bottomRight = new Point(e.CellBounds.Right, e.CellBounds.Bottom - (Convert.ToInt32(styles[e.Row].Height) - 20));
                    e.Graphics.DrawLine(pen, bottomLeft, bottomRight);
                }
            }
        }

        private void BankInfoBorderColor(object sender, TableLayoutCellPaintEventArgs e)
        {
            TableLayoutRowStyleCollection styles = BankInfo.RowStyles;

            var panel = sender as TableLayoutPanel;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            using (var pen = new Pen(Color.FromArgb(255, 100, 100, 100), 1))
            {
                pen.Alignment = PenAlignment.Center;
                pen.DashStyle = DashStyle.Solid;

                if (e.Column == 0)
                {
                    var bottomLeft = new Point(e.CellBounds.Left + 2, e.CellBounds.Bottom - (Convert.ToInt32(styles[e.Row].Height) - 20));
                    var bottomRight = new Point(e.CellBounds.Right, e.CellBounds.Bottom - (Convert.ToInt32(styles[e.Row].Height) - 20));
                    e.Graphics.DrawLine(pen, bottomLeft, bottomRight);
                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {

        }
    }
}
