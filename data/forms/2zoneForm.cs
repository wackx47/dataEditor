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
    public partial class FormType2 : Form
    {
        public FormType2()
        {
            InitializeComponent();
        }

        bool runtime = false;

        private void FormType2_Load(object sender, EventArgs e)
        {
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

        private void reCalculation(bool runtime)
        {
            if (runtime)
            {
                List<RadioButton> radioButtons = new List<RadioButton> { this.useIntervals, this.useHours };

                decimal k1 = 0;
                decimal k2 = 0;

                decimal k3 = 0;

                decimal k4 = 0;
                decimal k5 = 0;

                decimal intgDiffSellDay = 0;
                decimal intgDiffBuyDay = 0;
                decimal intgDiffSellNight = 0;
                decimal intgDiffBuyNight = 0;

                decimal hrsDiffSellDay = 0;
                decimal hrsDiffBuyDay = 0;
                decimal hrsDiffSellNight = 0;
                decimal hrsDiffBuyNight = 0;

                decimal ConSummDayDiff = 0;
                decimal ConSummNightDiff = 0;
                decimal GenSummDayDiff = 0;
                decimal GenSummNightDiff = 0;

                decimal ConSummDay = 0;
                decimal ConSummNight = 0;
                decimal GenSummDay = 0;
                decimal GenSummNight = 0;

                ConSummDayDiff = decimal.Parse(this.txtConDayDiff.Text);
                ConSummNightDiff = decimal.Parse(this.txtConNightDiff.Text);

                GenSummDayDiff = decimal.Parse(this.txtGenDayDiff.Text);
                GenSummNightDiff = decimal.Parse(this.txtGenNightDiff.Text);

                ConSummDay = decimal.Parse(this.txtConSummDayHH.Text);
                ConSummNight = decimal.Parse(this.txtConSummNightHH.Text);

                GenSummDay = decimal.Parse(this.txtGenSummDayHH.Text);
                GenSummNight = decimal.Parse(this.txtGenSummNightHH.Text);

                var checkedButton = radioButtons.FirstOrDefault(r => r.Checked);

                try
                {
                    switch (checkedButton.Name)
                    {
                        case "useIntervals":
                            if (ConSummDayDiff > GenSummDayDiff)
                            {
                                intgDiffSellDay = ConSummDayDiff - GenSummDayDiff;
                            }
                            else
                            {
                                intgDiffBuyDay = GenSummDayDiff - ConSummDayDiff;
                            }

                            if (ConSummNightDiff > GenSummNightDiff)
                            {
                                intgDiffSellNight = ConSummNightDiff - GenSummNightDiff;
                            }
                            else
                            {
                                intgDiffBuyNight = GenSummNightDiff - ConSummNightDiff;
                            }

                            this.txtSELLday.Text = Math.Round(intgDiffSellDay, 0).ToString();
                            this.txtSELLnight.Text = Math.Round(intgDiffSellNight, 0).ToString();
                            this.txtBUYday.Text = Math.Round(intgDiffBuyDay, 0).ToString();
                            this.txtBUYnight.Text = Math.Round(intgDiffBuyNight, 0).ToString();

                            this.lblSell.Text = Math.Round((intgDiffSellDay + intgDiffSellNight), 0).ToString();
                            this.lblBuy.Text = Math.Round((intgDiffBuyDay + intgDiffBuyNight), 0).ToString();

                            break;

                        case "useHours":
                            if (ConSummDay > GenSummDay)
                            {
                                hrsDiffSellDay = ConSummDay - GenSummDay;
                            }
                            else
                            {
                                hrsDiffBuyDay = GenSummDay - ConSummDay;
                            }

                            if (ConSummNight > GenSummNight)
                            {
                                hrsDiffSellNight = ConSummNight - GenSummNight;
                            }
                            else
                            {
                                hrsDiffBuyNight = GenSummNight - ConSummNight;
                            }

                            this.txtSELLday.Text = Math.Round(hrsDiffSellDay, 0).ToString();
                            this.txtSELLnight.Text = Math.Round(hrsDiffSellNight, 0).ToString();
                            this.txtBUYday.Text = Math.Round(hrsDiffBuyDay, 0).ToString();
                            this.txtBUYnight.Text = Math.Round(hrsDiffBuyNight, 0).ToString();

                            this.lblSell.Text = Math.Round((hrsDiffSellDay + hrsDiffSellNight), 0).ToString();
                            this.lblBuy.Text = Math.Round((hrsDiffBuyDay + hrsDiffBuyNight), 0).ToString();

                            break;
                    }
                }
                catch (Exception ex)
                {
                    
                }


                decimal PriceNight = 0;
                decimal PriceDay = 0;
                decimal ResultCost = 0;

                try
                {
                    k1 = decimal.Parse(this.txtDiffEEoremNight.Text);
                    k2 = decimal.Parse(this.txtDiffEEoremDay.Text);

                    k3 = decimal.Parse(this.txtSvncPorem.Text);

                    k4 = decimal.Parse(this.txtKFnight.Text);
                    k5 = decimal.Parse(this.txtKFday.Text);
                }
                catch(Exception ex)
                {
                    
                }

                PriceNight = Math.Round((k1 + (k3 * k4)) / 1000, 5);
                PriceDay = Math.Round((k2 + (k3 * k5)) / 1000, 5);

                ResultCost = PriceNight * decimal.Parse(this.txtBUYnight.Text) + PriceDay * decimal.Parse(this.txtBUYday.Text);

                this.txtResultPriceNight.Text = PriceNight.ToString();
                this.txtResultPriceDay.Text = PriceDay.ToString();
                this.txtResultCost.Text = Math.Round(ResultCost, 2).ToString();

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
    }
}
