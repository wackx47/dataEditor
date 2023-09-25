using dataEditor.data.forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace dataEditor
{
    public partial class FormType2 : Form
    {
        public FormType2()
        {
            InitializeComponent();
        }

        bool runtime = false;
        public string gName = null;
        public string gCurrentFolder = null;
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

        List<String> staticExcelLabels = new List<string>() { };
        private void ReadResource(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourcePath = name;

            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
                try
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string? line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            staticExcelLabels.Add(line);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            int year = DateTime.ParseExact(lblAbonentDateYear.Text, "yyyy", CultureInfo.CurrentCulture).Year;
            int month = DateTime.ParseExact(lblAbonentDateMonth.Text, "MMMM", CultureInfo.CurrentCulture).Month;
            string monthString = new DateTime(year, month, 1).ToString("MM");
            string CurrentFolder = gCurrentFolder + "\\data\\common\\files\\" + year.ToString() + "\\" + monthString + "\\";

            List<RadioButton> radioButtons = new List<RadioButton> { this.useIntervals, this.useHours };
            var checkedButton = radioButtons.FirstOrDefault(r => r.Checked);

            bool resComplete = false;
            int offsetRow = 5;

            ReadResource("dataEditor.data.text.ExcelStaticLables.txt");

            string fullPathFileName = null;

            switch (checkedButton.Name)
            {
                case "useIntervals":
                    fullPathFileName = CurrentFolder + monthString + year.ToString() + "_" + gName + "_intg.xlsx";
                    break;

                case "useHours":
                    fullPathFileName = CurrentFolder + monthString + year.ToString() + "_" + gName + "_hrs.xlsx";
                    break;
            }

            if (File.Exists(fullPathFileName))
            {
                DialogResult dialogResult = MessageBox.Show("Файл Excel уже существует, пересоздать файл заново?", "Выберите действие", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    goto CreateExcel;
                }
                else if (dialogResult == DialogResult.No)
                {
                    resComplete = true;
                    goto completeVoid;
                }
            }
            else
            {
                goto CreateExcel;
            }

        CreateExcel:
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet sheet = package.Workbook.Worksheets.Add(monthString + "_" + gName);

                //Start Table_1
                sheet.Cells["A1"].Value = staticExcelLabels[0];
                sheet.Cells[1, 1, 2, 1].Merge = true;
                sheet.Cells["B1"].Value = staticExcelLabels[1];
                sheet.Cells["A1:B1"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["C1"].Value = this.lblAbonentName.Text;
                sheet.Cells["B2"].Value = staticExcelLabels[2];
                sheet.Cells["A2:B2"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                sheet.Cells["A3"].Value = staticExcelLabels[3];
                sheet.Cells["C3:J3"].Merge = true;
                sheet.Cells["A3:B3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["C3"].Value = this.lblAbonentAddress.Text;
                sheet.Cells["C3"].Style.WrapText = true;
                sheet.Cells[3, 1, 3, 2].Merge = true;
                sheet.Cells["A4"].Value = staticExcelLabels[4];
                sheet.Cells["A4:B4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                sheet.Cells[4, 1, 4, 2].Merge = true;
                sheet.Cells["A5"].Value = staticExcelLabels[5];
                sheet.Cells["A5:B5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["C5"].Value = this.lblAbonentType.Text;
                sheet.Cells[5, 1, 5, 2].Merge = true;
                sheet.Cells["A6"].Value = staticExcelLabels[6];
                sheet.Cells["A6:B6"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                sheet.Cells[6, 1, 6, 2].Merge = true;
                sheet.Cells["A7"].Value = staticExcelLabels[7];
                sheet.Cells["A7:B7"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["C7"].Value = this.lblAbonentTarif.Text;
                sheet.Cells[7, 1, 7, 2].Merge = true;

                try
                {
                    sheet.Cells["C2"].Value = decimal.Parse(this.lblAbonentINN.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                    sheet.Cells["C4"].Value = decimal.Parse(this.lblAbonentNumberCC.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                    sheet.Cells["C6"].Value = decimal.Parse(this.lblAbonentKF.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                    sheet.Cells["C2"].Style.Numberformat.Format = "0";
                    sheet.Cells["C4"].Style.Numberformat.Format = "0";
                    sheet.Cells["C6"].Style.Numberformat.Format = "0";
                }
                catch
                {
                    sheet.Cells["C2"].Value = this.lblAbonentINN.Text;
                    sheet.Cells["C4"].Value = this.lblAbonentNumberCC.Text;
                    sheet.Cells["C6"].Value = this.lblAbonentKF.Text;
                }

                sheet.Cells["B8"].Value = staticExcelLabels[8];
                sheet.Cells["B8"].Style.Font.Bold = true;
                sheet.Cells["B8"].Style.Font.Size = 12;
                sheet.Cells["C8"].Value = this.lblAbonentDateMonth.Text + " " + this.lblAbonentDateYear.Text;
                sheet.Cells["C8"].Style.Font.Bold = true;
                sheet.Cells["C8"].Style.Font.Size = 12;

                sheet.Cells["A1:B10"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                sheet.Cells["A1:A2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["A8:A10"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["A1:B10"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["A1:A10"].AutoFitColumns();
                sheet.Column(2).Width = 20;
                sheet.Column(3).Style.Font.Bold = true;

                sheet.Cells["A1:A2"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                sheet.Cells["C1:J7"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                sheet.Cells["C1:J7"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["C1:J1"].Merge = true;
                sheet.Cells["C2:J2"].Merge = true;
                sheet.Cells["C3:J3"].Merge = true;
                sheet.Cells["C4:J4"].Merge = true;
                sheet.Cells["C5:J5"].Merge = true;
                sheet.Cells["C6:J6"].Merge = true;
                sheet.Cells["C7:J7"].Merge = true;
                //End Table_1

                //----------------------------------------------------------------------------------------------

                //Header Table_2
                sheet.Cells["B10"].Value = staticExcelLabels[46];
                sheet.Cells["B10"].Style.Font.Bold = true;
                sheet.Cells["B10"].Style.Font.Size = 16;
                sheet.Cells["B10"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                //Start Table_2
                sheet.Cells["B11:I12"].Merge = true;
                sheet.Cells["B11:I12"].Style.WrapText = true;
                sheet.Cells["B11:I12"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["B11"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["B11"].Value = staticExcelLabels[12];
                sheet.Cells["J11"].Value = staticExcelLabels[42];
                sheet.Cells["J12"].Value = staticExcelLabels[43];
                sheet.Cells["J11"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["K11"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["J11"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["J11"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["K11"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                sheet.Cells["K11"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["J12"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["K12"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["J12"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["J12"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["K12"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                sheet.Cells["K12"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["B13:J13"].Merge = true;
                sheet.Cells["B13:J13"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["B13"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["B13"].Value = staticExcelLabels[13];
                sheet.Cells["K13"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["K13"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["K13"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["B14:I15"].Merge = true;
                sheet.Cells["B14:I15"].Style.WrapText = true;
                sheet.Cells["B14:I15"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["B14"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["B14"].Value = staticExcelLabels[14];
                sheet.Cells["J14"].Value = staticExcelLabels[42];
                sheet.Cells["J15"].Value = staticExcelLabels[43];
                sheet.Cells["J14"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["J14"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["J14"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["J15"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["J15"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["J15"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["K14"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["K14"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                sheet.Cells["K14"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["K15"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["K15"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                sheet.Cells["K15"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                try
                {
                    sheet.Cells["K11"].Value = decimal.Parse(this.txtDiffEEoremNight.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                    sheet.Cells["K12"].Value = decimal.Parse(this.txtDiffEEoremDay.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                    sheet.Cells["K13"].Value = decimal.Parse(this.txtSvncPorem.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                    sheet.Cells["K14"].Value = decimal.Parse(this.txtKFnight.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                    sheet.Cells["K15"].Value = decimal.Parse(this.txtKFday.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                }
                catch
                {
                    sheet.Cells["K11"].Value = this.txtDiffEEoremNight.Text;
                    sheet.Cells["K12"].Value = this.txtDiffEEoremDay.Text;
                    sheet.Cells["K13"].Value = this.txtSvncPorem.Text;
                    sheet.Cells["K14"].Value = this.txtKFnight.Text;
                    sheet.Cells["K15"].Value = this.txtKFday.Text;
                }

                sheet.Cells["K11:K15"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                sheet.Column(10).AutoFit();
                sheet.Column(11).AutoFit();
                //End Table_2

                //----------------------------------------------------------------------------------------------

                //Header Table_3
                sheet.Cells["B18"].Value = staticExcelLabels[15];
                sheet.Cells["B18"].Style.Font.Bold = true;
                sheet.Cells["B18"].Style.Font.Size = 16;
                //Start Table_3
                sheet.Column(5).Width = 20;
                sheet.Cells["B19:D19"].Merge = true;
                sheet.Cells["B19:D19"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin); 
                sheet.Cells["B19"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["B19"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["B19"].Value = staticExcelLabels[16];

                sheet.Cells["E19:G19"].Merge = true;
                sheet.Cells["E19:G19"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["E19"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["E19"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["E19"].Value = staticExcelLabels[17];

                sheet.Cells["B20"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["B20"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["B20"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["B20"].Value = staticExcelLabels[31];
                sheet.Cells["E20"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["E20"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["E20"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["E20"].Value = staticExcelLabels[31];

                sheet.Cells["C20:D20"].Merge = true;
                sheet.Cells["C20:D20"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["C20"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["C20"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["C20"].Value = staticExcelLabels[32];

                sheet.Cells["F20:G20"].Merge = true;
                sheet.Cells["F20:G20"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["F20"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["F20"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["F20"].Value = staticExcelLabels[32];

                sheet.Cells["B21"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["B21"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["B21"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["E21"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["E21"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["E21"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                sheet.Cells["C21:D21"].Merge = true;
                sheet.Cells["C21:D21"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["D21"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["D21"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                sheet.Cells["F21:G21"].Merge = true;
                sheet.Cells["F21:G21"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["F21"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["F21"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                sheet.Cells["B22:D22"].Merge = true;
                sheet.Cells["B22:D22"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["B22"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["B22"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                sheet.Cells["E22:G22"].Merge = true;
                sheet.Cells["E22:G22"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["E22"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["E22"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                //sheet.Cells["B21"].Value = decimal.Parse(this.txtSELLday.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                //sheet.Cells["C21"].Value = decimal.Parse(this.txtSELLnight.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                //sheet.Cells["E21"].Value = decimal.Parse(this.txtBUYday.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                //sheet.Cells["F21"].Value = decimal.Parse(this.txtBUYnight.Text, NumberStyles.Float, CultureInfo.CurrentCulture);

                sheet.Cells["B22"].Formula = "B21+C21";
                sheet.Cells["E22"].Formula = "E21+F21";

                sheet.Cells["B20:G22"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["B20:G22"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["B21:G22"].Style.Font.Bold = true;
                sheet.Cells["B19:G20"].Style.Font.Bold = false;
                //End Table_3

                //----------------------------------------------------------------------------------------------

                //Header Table_4
                sheet.Cells["B25"].Value = staticExcelLabels[19];
                sheet.Cells["B25"].Style.Font.Bold = true;
                sheet.Cells["B25"].Style.Font.Size = 16;
                //Start Table_4
                sheet.Cells["B26:D27"].Merge = true;
                sheet.Cells["B26:D27"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["B26"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["B26"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                sheet.Cells["B26"].Value = staticExcelLabels[20];

                sheet.Cells["E26"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["E26"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["E26"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["E26"].Value = staticExcelLabels[42];

                sheet.Cells["F26:G26"].Merge = true;
                sheet.Cells["F26:G26"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["F26"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["F26"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                sheet.Cells["E27"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["E27"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["E27"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["E27"].Value = staticExcelLabels[43];

                sheet.Cells["F27:G27"].Merge = true;
                sheet.Cells["F27:G27"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["F27"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["F27"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                sheet.Cells["B28:E28"].Merge = true;
                sheet.Cells["B28:E28"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["B28"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["B28"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                sheet.Cells["B28"].Value = staticExcelLabels[21];

                sheet.Cells["F28:G28"].Merge = true;
                sheet.Cells["F28:G28"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["F28"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["F28"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                sheet.Cells["F26"].Formula = "(K11+K13*K14)/1000";
                sheet.Cells["F26"].Style.Numberformat.Format = "# ##0.00 ₽;-# ##0.00 ₽";
                sheet.Cells["F27"].Formula = "(K12+K13*K15)/1000";
                sheet.Cells["F27"].Style.Numberformat.Format = "# ##0.00 ₽;-# ##0.00 ₽";

                sheet.Cells["F28"].Formula = "ROUND(F26*F21,2)+ROUND(F27*E21,2)";
                sheet.Cells["F28"].Style.Numberformat.Format = "# ##0.00 ₽;-# ##0.00 ₽";
                //End Table_4

                //Exclusive style
                sheet.Cells["A1:B7"].Style.Font.Name = "Tahoma";
                sheet.Cells["A1:B7"].Style.Font.Size = 10;

                sheet.Cells["C1:J7"].Style.Font.Name = "Courier New";
                sheet.Cells["C1:J8"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                sheet.Cells["C1:J8"].Style.Fill.BackgroundColor.SetColor(Color.FromKnownColor(KnownColor.WhiteSmoke));
                sheet.Cells["B8"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                sheet.Cells["B8"].Style.Fill.BackgroundColor.SetColor(Color.FromKnownColor(KnownColor.WhiteSmoke));
                sheet.Cells["C1:J8"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                sheet.Cells["B8:C8"].Style.Font.Name = "Tahoma";
                sheet.Cells["B8:C8"].Style.Font.Size = 11;
                sheet.Cells["B8:C8"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["C8:J8"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                sheet.Cells["B11:J15"].Style.Font.Name = "Tahoma";
                sheet.Cells["B11:J15"].Style.Font.Size = 10;
                sheet.Cells["K11:K15"].Style.Font.Name = "Courier New";

                sheet.Cells["A19:G20"].Style.Font.Name = "Tahoma";
                sheet.Cells["A19:G20"].Style.Font.Size = 10;
                sheet.Cells["B21:G22"].Style.Font.Name = "Courier New";

                sheet.Cells["B26:E28"].Style.Font.Name = "Tahoma";
                sheet.Cells["B26:E28"].Style.Font.Size = 10;
                sheet.Cells["F26:G28"].Style.Font.Name = "Courier New";
                //

                switch (checkedButton.Name)
                {
                    case "useIntervals":
                        //Header Table_Intervals
                        sheet.Cells["N1"].Value = staticExcelLabels[22];
                        sheet.Cells["N1"].Style.Font.Bold = true;
                        sheet.Cells["N1"].Style.Font.Size = 16;
                        //Start Table_Intervals
                        sheet.Cells["N2"].Value = staticExcelLabels[23];
                        sheet.Cells["O2"].Value = staticExcelLabels[24];
                        sheet.Cells["P2"].Value = staticExcelLabels[25];
                        sheet.Cells["Q2"].Value = staticExcelLabels[26];
                        sheet.Cells["R2"].Value = staticExcelLabels[27];

                        sheet.Cells["O5"].Value = staticExcelLabels[31];
                        sheet.Cells["O8"].Value = staticExcelLabels[31];
                        sheet.Cells["O6"].Value = staticExcelLabels[32];
                        sheet.Cells["O9"].Value = staticExcelLabels[32];
                        sheet.Cells["O7"].Value = staticExcelLabels[30];
                        sheet.Cells["O10"].Value = staticExcelLabels[30];

                        sheet.Cells["P4"].Value = this.txtDateFirst.Text;
                        sheet.Cells["Q4"].Value = this.txtDateLast.Text;

                        sheet.Cells["P5"].Value = decimal.Parse(this.txtConDayFirst.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                        sheet.Cells["Q5"].Value = decimal.Parse(this.txtConDayLast.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                        sheet.Cells["P6"].Value = decimal.Parse(this.txtConNightFirst.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                        sheet.Cells["Q6"].Value = decimal.Parse(this.txtConNightLast.Text, NumberStyles.Float, CultureInfo.CurrentCulture);

                        sheet.Cells["P7"].Value = decimal.Parse(this.txtConSummFirst.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                        sheet.Cells["Q7"].Value = decimal.Parse(this.txtConSummLast.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                        sheet.Cells["P8"].Value = decimal.Parse(this.txtGenDayFirst.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                        sheet.Cells["Q8"].Value = decimal.Parse(this.txtGenDayLast.Text, NumberStyles.Float, CultureInfo.CurrentCulture);

                        sheet.Cells["P9"].Value = decimal.Parse(this.txtGenNightFirst.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                        sheet.Cells["Q9"].Value = decimal.Parse(this.txtGenNightLast.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                        sheet.Cells["P10"].Value = decimal.Parse(this.txtGenSummFirst.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                        sheet.Cells["Q10"].Value = decimal.Parse(this.txtGenSummLast.Text, NumberStyles.Float, CultureInfo.CurrentCulture);

                        sheet.Cells["R5"].Formula = "Q5 - P5";
                        sheet.Cells["R6"].Formula = "Q6 - P6";
                        sheet.Cells["R7"].Formula = "Q7 - P7";
                        sheet.Cells["R8"].Formula = "Q8 - P8";
                        sheet.Cells["R9"].Formula = "Q9 - P9";
                        sheet.Cells["R10"].Formula = "Q10 - P10";
                        sheet.Cells["P5:R10"].Style.Numberformat.Format = "0.000";

                        sheet.Cells["N2:N4"].Merge = true;
                        sheet.Cells["N2:N4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        sheet.Cells["O2:O4"].Merge = true;
                        sheet.Cells["O2:O4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        sheet.Cells["P2:P3"].Merge = true;
                        sheet.Cells["P2:P3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        sheet.Cells["Q2:Q3"].Merge = true;
                        sheet.Cells["Q2:Q3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        sheet.Cells["R2:R4"].Merge = true;
                        sheet.Cells["R2:R4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        sheet.Cells["N5"].Value = staticExcelLabels[28];
                        sheet.Cells["N8"].Value = staticExcelLabels[29];
                        sheet.Cells["N5:N7"].Merge = true;
                        sheet.Cells["N5:N7"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["N8:N10"].Merge = true;
                        sheet.Cells["N8:N10"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        sheet.Cells["O5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["O6"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["O7"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["O8"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["O9"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["O10"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        sheet.Cells["P4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["P5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["P6"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["P7"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["P8"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["P9"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["P10"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        sheet.Cells["Q4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["Q5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["Q6"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["Q7"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["Q8"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["Q9"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["Q10"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        sheet.Cells["R5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["R6"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["R7"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["R8"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["R9"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["R10"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        sheet.Cells["N2:R10"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        sheet.Cells["N2:R10"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Cells["N2:R10"].Style.WrapText = true;

                        sheet.Column(14).Width = 20;
                        sheet.Column(15).Width = 10;
                        sheet.Column(16).Width = 15;
                        sheet.Column(17).Width = 15;
                        sheet.Column(18).Width = 14;
                        //End Table_Intervals

                        sheet.Cells["B21"].Formula = "ROUND(IF(R5>R8,R5-R8,0),0)";
                        sheet.Cells["C21"].Formula = "ROUND(IF(R6>R9,R6-R9,0),0)";
                        sheet.Cells["E21"].Formula = "ROUND(IF(R8>R5,R8-R5,0),0)";
                        sheet.Cells["F21"].Formula = "ROUND(IF(R9>R6,R9-R6,0),0)";

                        if (!Directory.Exists(CurrentFolder))
                        {
                            Directory.CreateDirectory(CurrentFolder);
                        }
                        try
                        {
                            package.SaveAs(new FileInfo(@fullPathFileName));
                            package.Dispose();
                            resComplete = true;
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Не удалось сохранить файл Excel" + "\\n" + ex);
                            resComplete = false;
                        }
                        break;

                    case "useHours":
                        //Header Table_Hours
                        sheet.Cells["N1"].Value = staticExcelLabels[35];
                        sheet.Cells["N1"].Style.Font.Bold = true;
                        sheet.Cells["N1"].Style.Font.Size = 16;
                        //Start Table_Hours
                        sheet.Cells["P2"].Value = staticExcelLabels[28];
                        sheet.Cells["R2"].Value = staticExcelLabels[29];
                        sheet.Cells["P2:Q2"].Merge = true;
                        sheet.Cells["R2:S2"].Merge = true;


                        sheet.Cells["P2:Q2"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["R2:S2"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["P3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["Q3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["R3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["S3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Column(14).Width = 11;
                        sheet.Column(15).Width = 11;
                        sheet.Column(16).Width = 11;
                        sheet.Column(17).Width = 11;
                        sheet.Column(18).Width = 11;
                        sheet.Column(19).Width = 11;

                        sheet.Cells["O3"].Value = staticExcelLabels[18];
                        sheet.Cells["O3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["N4"].Value = "Дата";
                        sheet.Cells["N4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["O4"].Value = "Час";
                        sheet.Cells["O4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["P4"].Value = staticExcelLabels[31];
                        sheet.Cells["P4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["Q4"].Value = staticExcelLabels[32];
                        sheet.Cells["Q4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["R4"].Value = staticExcelLabels[31];
                        sheet.Cells["R4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["S4"].Value = staticExcelLabels[32];
                        sheet.Cells["S4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["T5:T28"].Merge = true;
                        sheet.Cells["T5:T28"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Column(20).Width = 4;
                        sheet.Column(14).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Column(15).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Column(16).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Column(17).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Column(18).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Column(19).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Cells["N1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                        //End Table_Hours

                        ExcelWorksheet sheet2 = package.Workbook.Worksheets.Add("Данные");
                        sheet2.Cells["I2"].Value = "#scrollPos";
                        sheet2.Column(9).AutoFit();

                        //Header Table_dataHours
                        sheet2.Cells["A1"].Value = staticExcelLabels[35];
                        sheet2.Cells["A1"].Style.Font.Bold = true;
                        sheet2.Cells["A1"].Style.Font.Size = 16;
                        //Start Table_dataHours
                        sheet2.Cells["C2"].Value = staticExcelLabels[28];
                        sheet2.Cells["E2"].Value = staticExcelLabels[29];
                        sheet2.Cells["C2:D2"].Merge = true;
                        sheet2.Cells["E2:F2"].Merge = true;


                        sheet2.Cells["C2:D2"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Cells["E2:F2"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Cells["C3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Cells["D3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Cells["E3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Cells["F3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Column(1).Width = 11;
                        sheet2.Column(2).Width = 11;
                        sheet2.Column(3).Width = 11;
                        sheet2.Column(4).Width = 11;
                        sheet2.Column(5).Width = 11;
                        sheet2.Column(6).Width = 11;

                        sheet2.Cells["B3"].Value = staticExcelLabels[18];
                        sheet2.Cells["B3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Cells["A4"].Value = "Дата";
                        sheet2.Cells["A4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Cells["B4"].Value = "Час";
                        sheet2.Cells["B4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Cells["C4"].Value = staticExcelLabels[31];
                        sheet2.Cells["C4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Cells["D4"].Value = staticExcelLabels[32];
                        sheet2.Cells["D4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Cells["E4"].Value = staticExcelLabels[31];
                        sheet2.Cells["E4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Cells["F4"].Value = staticExcelLabels[32];
                        sheet2.Cells["F4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        sheet2.Column(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet2.Column(2).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet2.Column(3).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet2.Column(4).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet2.Column(5).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet2.Column(6).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet2.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                        foreach (DataGridViewRow row in this.dataHoursViewer.Rows)
                        {
                            sheet2.Cells[offsetRow, 1].Value = row.Cells[0].Value.ToString();
                            sheet2.Cells[offsetRow, 2].Value = row.Cells[1].Value.ToString();
                            try
                            {
                                sheet2.Cells[offsetRow, 3].Value = decimal.Parse(Convert.ToString(row.Cells[2].Value.ToString()), NumberStyles.Float, CultureInfo.CurrentCulture);
                            }
                            catch
                            {
                                sheet2.Cells[offsetRow, 3].Value = "—";
                            }
                            try
                            {
                                sheet2.Cells[offsetRow, 4].Value = decimal.Parse(Convert.ToString(row.Cells[3].Value.ToString()), NumberStyles.Float, CultureInfo.CurrentCulture);
                            }
                            catch
                            {
                                sheet2.Cells[offsetRow, 4].Value = "—";
                            }
                            try
                            {
                                sheet2.Cells[offsetRow, 5].Value = decimal.Parse(Convert.ToString(row.Cells[4].Value.ToString()), NumberStyles.Float, CultureInfo.CurrentCulture);
                            }
                            catch
                            {
                                sheet2.Cells[offsetRow, 5].Value = "—";
                            }
                            try
                            {
                                sheet2.Cells[offsetRow, 6].Value = decimal.Parse(Convert.ToString(row.Cells[5].Value.ToString()), NumberStyles.Float, CultureInfo.CurrentCulture);
                            }
                            catch
                            {
                                sheet2.Cells[offsetRow, 6].Value = "—";
                            }

                            sheet2.Cells[offsetRow, 3].Style.Numberformat.Format = "0.000";
                            sheet2.Cells[offsetRow, 4].Style.Numberformat.Format = "0.000";
                            sheet2.Cells[offsetRow, 5].Style.Numberformat.Format = "0.000";
                            sheet2.Cells[offsetRow, 6].Style.Numberformat.Format = "0.000";
                            offsetRow++;
                        }

                        sheet2.Cells["C3"].Formula = "SUM(C5:C" + (offsetRow - 1) + ")";
                        sheet2.Cells["D3"].Formula = "SUM(D5:D" + (offsetRow - 1) + ")";

                        sheet2.Cells["E3"].Formula = "SUM(E5:E" + (offsetRow - 1) + ")";
                        sheet2.Cells["F3"].Formula = "SUM(F5:F" + (offsetRow - 1) + ")";

                        for (int i = 0; i < 24; i++)
                        {
                            sheet.Cells[5 + i, 14].Formula = "=(OFFSET('" + sheet2.Name + "'!" + "A" + (5 + i).ToString() + ",'" + sheet2.Name + "'!J2" + ",0,1,1))";
                            sheet.Cells[5 + i, 14].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            sheet.Cells[5 + i, 15].Formula = "=(OFFSET('" + sheet2.Name + "'!" + "B" + (5 + i).ToString() + ",'" + sheet2.Name + "'!J2" + ",0,1,1))";
                            sheet.Cells[5 + i, 15].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            sheet.Cells[5 + i, 16].Formula = "=(OFFSET('" + sheet2.Name + "'!" + "C" + (5 + i).ToString() + ",'" + sheet2.Name + "'!J2" + ",0,1,1))";
                            sheet.Cells[5 + i, 16].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            sheet.Cells[5 + i, 16].Style.Numberformat.Format = "0.000";
                            sheet.Cells[5 + i, 17].Formula = "=(OFFSET('" + sheet2.Name + "'!" + "D" + (5 + i).ToString() + ",'" + sheet2.Name + "'!J2" + ",0,1,1))";
                            sheet.Cells[5 + i, 17].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            sheet.Cells[5 + i, 17].Style.Numberformat.Format = "0.000";
                            sheet.Cells[5 + i, 18].Formula = "=(OFFSET('" + sheet2.Name + "'!" + "E" + (5 + i).ToString() + ",'" + sheet2.Name + "'!J2" + ",0,1,1))";
                            sheet.Cells[5 + i, 18].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            sheet.Cells[5 + i, 18].Style.Numberformat.Format = "0.000";
                            sheet.Cells[5 + i, 19].Formula = "=(OFFSET('" + sheet2.Name + "'!" + "F" + (5 + i).ToString() + ",'" + sheet2.Name + "'!J2" + ",0,1,1))";
                            sheet.Cells[5 + i, 19].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            sheet.Cells[5 + i, 19].Style.Numberformat.Format = "0.000";
                        }

                        sheet.Cells["P3"].Formula = "'" + sheet2.Name + "'!C3";
                        sheet.Cells["Q3"].Formula = "'" + sheet2.Name + "'!D3";
                        sheet.Cells["R3"].Formula = "'" + sheet2.Name + "'!E3";
                        sheet.Cells["S3"].Formula = "'" + sheet2.Name + "'!F3";

                        sheet.Cells["B21"].Formula = "ROUND(IF(P3>R3,P3-R3,0),0)";
                        sheet.Cells["C21"].Formula = "ROUND(IF(Q3>S3,Q3-S3,0),0)";
                        sheet.Cells["E21"].Formula = "ROUND(IF(R3>P3,R3-P3,0),0)";
                        sheet.Cells["F21"].Formula = "ROUND(IF(S3>Q3,S3-Q3,0),0)";

                        sheet2.Column(2).AutoFit();
                        sheet2.Column(3).AutoFit();
                        sheet2.Column(4).AutoFit();
                        sheet2.Column(5).AutoFit();
                        sheet2.Column(6).AutoFit();
                        //End Table_Hours

                        //Exclusive style
                        sheet.Cells["N2:S4"].Style.Font.Name = "Tahoma";
                        sheet.Cells["N2:S4"].Style.Font.Size = 10;
                        sheet.Cells["N2:O28"].Style.Font.Name = "Tahoma";
                        sheet.Cells["N2:O28"].Style.Font.Size = 10;

                        sheet.Cells["P5:S28"].Style.Font.Name = "Courier New";
                        sheet.Cells["P3:S3"].Style.Font.Name = "Courier New";
                        sheet.Cells["P3:S3"].Style.Font.Size = 11;

                        sheet.Cells["O3:S3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        sheet.Cells["O3:S3"].Style.Fill.BackgroundColor.SetColor(Color.FromKnownColor(KnownColor.LightGoldenrodYellow));
                        sheet.Cells["O3:S3"].Style.Font.Bold = true;
                        //


                        if (!Directory.Exists(CurrentFolder))
                        {
                            Directory.CreateDirectory(CurrentFolder);
                        }

                        try
                        {
                            package.SaveAs(new FileInfo(@fullPathFileName));
                            package.Dispose();
                        }
                        catch
                        {
                            MessageBox.Show("Не удалось сохранить файл Excel");
                            resComplete = false;
                        }


                        Excel.Application xlApp = new Excel.Application();

                        Excel.Workbook xlWB = xlApp.Workbooks.Open(CurrentFolder + monthString + year.ToString() + "_" + gName + "_hrs.xlsx");
                        Excel.Worksheet xlSht = xlWB.Worksheets[1];
                        Excel.Worksheet xlSht2 = xlWB.Worksheets[2];

                        Excel.Range UpperLeftCell = (Excel.Range)xlSht.get_Range("T5").Cells[1, 1];

                        Excel.ControlFormat Scrollbar = xlSht.Shapes.AddFormControl(Excel.XlFormControl.xlScrollBar, UpperLeftCell.Left+2, UpperLeftCell.Top+2, 18, 377).ControlFormat;


                        Scrollbar.Value = 0;
                        Scrollbar.Min = 0;
                        Scrollbar.Max = offsetRow - 29;
                        Scrollbar.SmallChange = 1;
                        Scrollbar.LargeChange = 10;
                        Scrollbar.LinkedCell = "Данные!$J$2";

                        xlWB.Close(true);
                        xlApp.Quit();
                        xlApp = null;
                        xlWB = null;
                        xlSht = null;



                        foreach (Process clsProcess in Process.GetProcesses())
                        {
                            if (clsProcess.ProcessName.Equals("EXCEL"))
                            {
                                clsProcess.Kill();
                            }
                        }

                        resComplete = true;
                        break;
                }
            }

        completeVoid:
            if (resComplete)
            {
                using (dialogResultExcelCreator dlgForm = new dialogResultExcelCreator())
                {

                    if (dlgForm.ShowDialog() == DialogResult.OK)
                    {
                        switch (dlgForm.key)
                        {
                            case 1:
                                Excel.Application xlApp = new Excel.Application();
                                xlApp.Application.Visible = true;
                                Excel.Workbook xlWB = xlApp.Workbooks.Open(fullPathFileName);

                                break;

                            case 2:
                                Process.Start("explorer.exe", CurrentFolder);
                                break;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }

        }
    }
}
