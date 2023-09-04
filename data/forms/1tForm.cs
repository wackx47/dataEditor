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

        bool runtime = false;
        private void FormType1_Load(object sender, EventArgs e)
        {
            //DataTableLayout.CellPaint += new TableLayoutCellPaintEventHandler(paintDataTableLayout);
            //vResultTableLayout.CellPaint += new TableLayoutCellPaintEventHandler(paintVResultDataTableLayout);
            runtime = true;
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

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }


        private void reCalculation(bool runtime)
        {
            if (runtime)
            {
                List<RadioButton> radioButtons = new List<RadioButton> { this.useIntervals, this.useHours };

                decimal SumConFirst = 0;
                decimal SumConLast = 0;
                decimal SumConDiff = 0;
                decimal SumGenFirst = 0;
                decimal SumGenLast = 0;
                decimal SumGenDiff = 0;

                decimal ConSumm = 0;
                decimal GenSumm = 0;

                decimal intgDiffSell = 0;
                decimal intgDiffBuy = 0;
                decimal hrsDiffSell = 0;
                decimal hrsDiffBuy = 0;


                SumConDiff = decimal.Parse(this.txtConSumm.Text);
                SumGenDiff = decimal.Parse(this.txtGenSumm.Text);

                ConSumm = decimal.Parse(this.txtConSummHH.Text);
                GenSumm = decimal.Parse(this.txtGenSummHH.Text);

                var checkedButton = radioButtons.FirstOrDefault(r => r.Checked);

                try
                {
                    switch (checkedButton.Name)
                    {
                        case "useIntervals":
                            if (SumConDiff > SumGenDiff)
                            {
                                intgDiffSell = Math.Round((SumConDiff - SumGenDiff), 0);
                            }
                            else
                            {
                                intgDiffBuy = Math.Round((SumGenDiff - SumConDiff), 0);
                            }
                            this.txtSELL.Text = intgDiffSell.ToString();
                            this.txtBUY.Text = intgDiffBuy.ToString();
                            break;

                        case "useHours":
                            if (ConSumm > GenSumm)
                            {
                                hrsDiffSell = Math.Round((ConSumm - GenSumm), 0);
                            }
                            else
                            {
                                hrsDiffBuy = Math.Round((GenSumm - ConSumm), 0);
                            }
                            this.txtSELL.Text = hrsDiffSell.ToString();
                            this.txtBUY.Text = hrsDiffBuy.ToString();
                            break;
                    }
                }
                catch (Exception ex)
                {

                }


                decimal k1 = 0;
                decimal k2 = 0;
                decimal k3 = 0;

                try
                {
                    k1 = decimal.Parse(this.txtsvncEEorem.Text);
                    k2 = decimal.Parse(this.txtsvncPorem.Text);
                    k3 = decimal.Parse(this.txtKF1.Text);
                }
                catch
                {

                }

                decimal Price = 0;
                decimal ResultCost = 0;

                Price = Math.Round(((k1 + k2 * k3) / 1000), 5);
                ResultCost = Price * decimal.Parse(this.txtBUY.Text);

                this.txtResultPrice.Text = Price.ToString();
                this.txtResultCost.Text = Math.Round(ResultCost, 2).ToString();
            }
        }

        private void useIntervals_CheckedChanged(object sender, EventArgs e)
        {
            if (useIntervals.Checked == true)
                useHours.Checked = false;
            else
                useHours.Checked = true;

            reCalculation(runtime);
        }

        private void useHours_CheckedChanged(object sender, EventArgs e)
        {
            if (useHours.Checked == true)
                useIntervals.Checked = false;
            else
                useIntervals.Checked = true;

            reCalculation(runtime);
        }


    }

}
