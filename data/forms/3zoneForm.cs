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
    public partial class FormType3 : Form
    {
        public FormType3()
        {
            InitializeComponent();
        }

        bool runtime = false;
        private void FormType3_Load(object sender, EventArgs e)
        {
            runtime = true;
        }

        private void reCalculation(bool runtime)
        {
            if (runtime)
            {
                List<RadioButton> radioButtons = new List<RadioButton> { this.useIntervals, this.useHours };

                decimal ConPeakDiff = 0;
                decimal ConSemiPeakDiff = 0;
                decimal ConNightDiff = 0;

                decimal GenPeakDiff = 0;
                decimal GenSemiPeakDiff = 0;
                decimal GenNightDiff = 0;

                decimal ConSummPeak = 0;
                decimal ConSummSemiPeak = 0;
                decimal ConSummNight = 0;
                decimal GenSummPeak = 0;
                decimal GenSummSemiPeak = 0;
                decimal GenSummNight = 0;

                decimal k1 = 0;
                decimal k2 = 0;
                decimal k3 = 0;

                decimal k4 = 0;

                decimal k5 = 0;
                decimal k6 = 0;
                decimal k7 = 0;

                decimal intgDiffSellPeak = 0;
                decimal intgDiffSellSemiPeak = 0;
                decimal intgDiffSellNight = 0;

                decimal intgDiffBuyPeak = 0;
                decimal intgDiffBuySemiPeak = 0;
                decimal intgDiffBuyNight = 0;

                decimal hrsDiffSellPeak = 0;
                decimal hrsDiffSellSemiPeak = 0;
                decimal hrsDiffSellNight = 0;

                decimal hrsDiffBuyPeak = 0;
                decimal hrsDiffBuySemiPeak = 0;
                decimal hrsDiffBuyNight = 0;

                var checkedButton = radioButtons.FirstOrDefault(r => r.Checked);
                try
                {
                    switch (checkedButton.Name)
                    {
                        case "useIntervals":
                            ConPeakDiff = decimal.Parse(this.txtConPeakDiff.Text);
                            ConSemiPeakDiff = decimal.Parse(this.txtConSemiPeakDiff.Text);
                            ConNightDiff = decimal.Parse(this.txtConNightDiff.Text);

                            GenPeakDiff = decimal.Parse(this.txtGenPeakDiff.Text);
                            GenSemiPeakDiff = decimal.Parse(this.txtGenSemiPeakDiff.Text);
                            GenNightDiff = decimal.Parse(this.txtGenNightDiff.Text);

                            if (ConPeakDiff > GenPeakDiff)
                            {
                                intgDiffSellPeak = ConPeakDiff - GenPeakDiff;
                            }
                            else
                            {
                                intgDiffBuyPeak = GenPeakDiff - ConPeakDiff;
                            }

                            if (ConSemiPeakDiff > GenSemiPeakDiff)
                            {
                                intgDiffSellSemiPeak = ConSemiPeakDiff - GenSemiPeakDiff;
                            }
                            else
                            {
                                intgDiffBuySemiPeak = GenSemiPeakDiff - ConSemiPeakDiff;
                            }

                            if (ConNightDiff > GenNightDiff)
                            {
                                intgDiffSellNight = ConNightDiff - GenNightDiff;
                            }
                            else
                            {
                                intgDiffBuyNight = GenNightDiff - ConNightDiff;
                            }

                            this.txtSELLpeak.Text = Math.Round(intgDiffSellPeak, 0).ToString();
                            this.txtSELLsemiPeak.Text = Math.Round(intgDiffSellSemiPeak, 0).ToString();
                            this.txtSELLnight.Text = Math.Round(intgDiffSellNight, 0).ToString();

                            this.txtBUYpeak.Text = Math.Round(intgDiffBuyPeak, 0).ToString();
                            this.txtBUYsemiPeak.Text = Math.Round(intgDiffSellSemiPeak, 0).ToString();
                            this.txtBUYnight.Text = Math.Round(intgDiffBuyNight, 0).ToString();

                            this.lblSell.Text = (intgDiffSellPeak + intgDiffSellSemiPeak + intgDiffSellNight).ToString();
                            this.lblBuy.Text = (intgDiffBuyPeak + intgDiffSellSemiPeak + intgDiffBuyNight).ToString();

                            break;

                        case "useHours":
                            if (ConSummPeak > GenSummPeak)
                            {
                                hrsDiffSellPeak = ConSummPeak - GenSummPeak;
                            }
                            else
                            {
                                hrsDiffBuyPeak = GenSummPeak - ConSummPeak;
                            }

                            if (ConSummSemiPeak > GenSummSemiPeak)
                            {
                                hrsDiffSellSemiPeak = ConSummSemiPeak - GenSummSemiPeak;
                            }
                            else
                            {
                                hrsDiffBuySemiPeak = GenSummSemiPeak - ConSummSemiPeak;
                            }

                            if (ConSummNight > GenSummNight)
                            {
                                hrsDiffSellNight = ConSummNight - GenSummNight;
                            }
                            else
                            {
                                hrsDiffBuyNight = GenSummNight - ConSummNight;
                            }

                            this.txtSELLpeak.Text = Math.Round(hrsDiffSellPeak, 0).ToString();
                            this.txtSELLsemiPeak.Text = Math.Round(hrsDiffSellSemiPeak, 0).ToString();
                            this.txtSELLnight.Text = Math.Round(hrsDiffSellNight, 0).ToString();

                            this.txtBUYpeak.Text = Math.Round(hrsDiffBuyPeak, 0).ToString();
                            this.txtBUYsemiPeak.Text = Math.Round(hrsDiffBuySemiPeak, 0).ToString();
                            this.txtBUYnight.Text = Math.Round(hrsDiffBuyNight, 0).ToString();

                            this.lblSell.Text = (hrsDiffSellPeak + hrsDiffSellSemiPeak + hrsDiffSellNight).ToString();
                            this.lblBuy.Text = (hrsDiffBuyPeak + hrsDiffBuySemiPeak + hrsDiffBuyNight).ToString();

                            break;
                    }
                }
                catch (Exception ex)
                {

                }

                decimal PriceNight = 0;
                decimal PriceSemiPeak = 0;
                decimal PricePeak = 0;
                decimal ResultCost = 0;

                try
                {
                    k1 = decimal.Parse(this.txtDiffEEoremNight.Text);
                    k2 = decimal.Parse(this.txtDiffEEoremPeak.Text);
                    k3 = decimal.Parse(this.txtDiffEEoremSemiPeak.Text);

                    k4 = decimal.Parse(this.txtSvncPorem.Text);

                    k5 = decimal.Parse(this.txtKFnight.Text);
                    k6 = decimal.Parse(this.txtKFpeak.Text);
                    k7 = decimal.Parse(this.txtKFsemiPeak.Text);


                    PriceNight = Math.Round((k1 + (k4 * k5)) / 1000, 5);
                    PricePeak = Math.Round((k2 + (k4 * k6)) / 1000, 5);
                    PriceSemiPeak = Math.Round((k3 + (k4 * k7)) / 1000, 5);
                }
                catch
                {

                }

                ResultCost = PriceNight * decimal.Parse(this.txtBUYnight.Text) + PricePeak * decimal.Parse(this.txtBUYpeak.Text) + PriceSemiPeak * decimal.Parse(this.txtBUYsemiPeak.Text);

                this.txtResultPriceNight.Text = PriceNight.ToString();
                this.txtResultPricePeak.Text = PricePeak.ToString();
                this.txtResultPriceSemiPeak.Text = PriceSemiPeak.ToString();
                this.txtResultCost.Text = Math.Round(ResultCost, 2).ToString();

            }
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

        private void useIntervals_CheckedChanged(object sender, EventArgs e)
        {
            if (useIntervals.Checked == true)
            {
                useHours.Checked = false;
                reCalculation(runtime);
            }
               
            else
                useHours.Checked = true;
        }

        private void useHours_CheckedChanged(object sender, EventArgs e)
        {
            if (useHours.Checked == true)
            {
                useIntervals.Checked = false;
                reCalculation(runtime);
            }
            else
                useIntervals.Checked = true;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }
    }
}
