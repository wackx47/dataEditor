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

namespace dataEditor
{
    public partial class FormType1 : Form
    {
        public FormType1()
        {
            InitializeComponent();
        }

        private void FormType1_Load(object sender, EventArgs e)
        {
            DataTableLayout.CellPaint += new TableLayoutCellPaintEventHandler(paintDataTableLayout);
            vResultTableLayout.CellPaint += new TableLayoutCellPaintEventHandler(paintVResultDataTableLayout);
        }

        private void mainTableLayoutGridBorder(object sender, TableLayoutCellPaintEventArgs e)
        {
            var panel = sender as TableLayoutPanel;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            var rectangle = e.CellBounds;
            using (var pen = new Pen(Color.Black, 1))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                if (e.Row == (panel.RowCount - 1))
                {
                    rectangle.Height -= 1;
                }

                if (e.Column == (panel.ColumnCount - 1))
                {
                    rectangle.Width -= 1;
                }

                e.Graphics.DrawRectangle(pen, rectangle);
            }
        }

        private void paintDataTableLayout(object sender, TableLayoutCellPaintEventArgs e)
        {

            if (e.Column == 4 && e.Row != 0 | e.Row != 1)
            {
                var rectangle = e.CellBounds;
                rectangle.Height -= 4;
                rectangle.Width -= 4;
                rectangle.Y += 2;
                rectangle.X += 2;
                e.Graphics.FillRectangle(Brushes.PaleGreen, rectangle);
            }
        }
        private void paintVResultDataTableLayout(object sender, TableLayoutCellPaintEventArgs e)
        {

            if (e.Column != 0 && e.Row != 0)
            {
                var rectangle = e.CellBounds;
                rectangle.Height -= 4;
                rectangle.Width -= 4;
                rectangle.Y += 2;
                rectangle.X += 2;
                e.Graphics.FillRectangle(Brushes.PaleGreen, rectangle);
            }
        }
    }

}
