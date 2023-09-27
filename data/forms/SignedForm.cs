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
using Microsoft.VisualBasic;

namespace dataEditor.data.forms
{
    public partial class SignedForm : Form
    {

        public DataSet tempSignaturesDataSet = new DataSet("Signatures");
        public SignedForm()
        {
            InitializeComponent();
        }

        private void SignInfoBorderColor(object sender, TableLayoutCellPaintEventArgs e)
        {
            TableLayoutRowStyleCollection styles = SignInfo.RowStyles;

            var panel = sender as TableLayoutPanel;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            using (var pen = new Pen(Color.FromArgb(255, 100, 100, 100), 1))
            {
                pen.Alignment = PenAlignment.Center;
                pen.DashStyle = DashStyle.Solid;

                if (e.Column == 0 && e.Row != 3 && e.Row != 4)
                {
                    var bottomLeft = new Point(e.CellBounds.Left + 2, e.CellBounds.Bottom - (Convert.ToInt32(styles[e.Row].Height) - 20));
                    var bottomRight = new Point(e.CellBounds.Right, e.CellBounds.Bottom - (Convert.ToInt32(styles[e.Row].Height) - 20));
                    e.Graphics.DrawLine(pen, bottomLeft, bottomRight);
                }
                else if (e.Column == 0)
                {
                    var bottomLeft = new Point(e.CellBounds.Left + 2, e.CellBounds.Bottom - (Convert.ToInt32(styles[e.Row].Height) - 54));
                    var bottomRight = new Point(e.CellBounds.Right, e.CellBounds.Bottom - (Convert.ToInt32(styles[e.Row].Height) - 54));
                    e.Graphics.DrawLine(pen, bottomLeft, bottomRight);
                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            string SignNumber = Interaction.InputBox("Введите табельный номер", "Новый подписант");
            

            if (!string.IsNullOrEmpty(SignNumber))
            {
                SelectorBox.Items.Add(SignNumber);

                txtSignNumber.Text = SignNumber;
                DataTable newSign = new DataTable(txtSignNumber.Text);
                newSign.Columns.Add("FirstName");
                newSign.Columns.Add("LastName");
                newSign.Columns.Add("MidName");
                newSign.Columns.Add("Position");
                newSign.Columns.Add("Attorney");

                DataRow rwe = newSign.NewRow();
                rwe["FirstName"] = txtSignFirstName.Text;
                rwe["LastName"] = txtSignLastName.Text;
                rwe["MidName"] = txtSignMidName.Text;
                rwe["Position"] = txtSignPosition.Text;
                rwe["Attorney"] = txtSignAttorney.Text;
                newSign.Rows.Add(rwe);

                tempSignaturesDataSet.Tables.Add(newSign);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
