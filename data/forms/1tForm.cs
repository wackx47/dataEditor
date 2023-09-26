using dataEditor.data.forms;
using MathNet.Numerics;
using Microsoft.Office.Interop.Excel;
using NPOI;
using NPOI.HPSF;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.Formula.Functions;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using static System.Net.WebRequestMethods;
using Excel = Microsoft.Office.Interop.Excel;
using File = System.IO.File;

namespace dataEditor
{
    public partial class FormType1 : Form
    {
        public FormType1()
        {
            InitializeComponent();
        }

        bool runtime = false;
        public string gName = null;
        public string gCurrentFolder = null;

        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;

        private void closeWindow(string caption)
        {
            // retrieve the handler of the window  
            int iHandle = FindWindow("CabinetWClass", caption);
            if (iHandle > 0)
            {
                // close the window using API        
                SendMessage(iHandle, WM_SYSCOMMAND, SC_CLOSE, 0);
            }
            else MessageBox.Show("The Window is not Found");
        }

        private void FormType1_Load(object sender, EventArgs e)
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
            string CurrentFolder = gCurrentFolder + "\\data\\common\\files\\" + year.ToString() + "\\" + monthString + "\\" + gName + "\\";

            bool resComplete = false;
            int offsetRow = 5;

            List<RadioButton> radioButtons = new List<RadioButton> { this.useIntervals, this.useHours };
            var checkedButton = radioButtons.FirstOrDefault(r => r.Checked);

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
                sheet.Cells["A10"].Value = staticExcelLabels[46];
                sheet.Cells["A10"].Style.Font.Bold = true;
                sheet.Cells["A10"].Style.Font.Size = 16;
                sheet.Cells["A10"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                //Start Table_2
                sheet.Cells["A11:I12"].Merge = true;
                sheet.Cells["A11:I12"].Style.WrapText = true;
                sheet.Cells["A11:I12"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["A11"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["A11"].Value = staticExcelLabels[12];
                
                sheet.Cells["J11:J12"].Merge = true;
                sheet.Cells["J11:J12"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["J11"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                sheet.Cells["J11"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["A13:I14"].Merge = true;
                sheet.Cells["A13:I14"].Style.WrapText = true;
                sheet.Cells["A13:I14"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["A13"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["A13"].Value = staticExcelLabels[13];
                
                sheet.Cells["J13:J14"].Merge = true;
                sheet.Cells["J13:J14"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["J13"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                sheet.Cells["J13"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["A15:I16"].Merge = true;
                sheet.Cells["A15:I16"].Style.WrapText = true;
                sheet.Cells["A15:I16"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["A15"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["A15"].Value = staticExcelLabels[14];
                
                sheet.Cells["J15:J16"].Merge = true;
                sheet.Cells["J15:J16"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["J15"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                sheet.Cells["J15"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                try
                {
                    sheet.Cells["J11"].Value = decimal.Parse(this.txtsvncEEorem.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                    sheet.Cells["J13"].Value = decimal.Parse(this.txtsvncPorem.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                    sheet.Cells["J15"].Value = decimal.Parse(this.txtKF1.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                }
                catch
                {
                    sheet.Cells["J11"].Value = this.txtsvncEEorem.Text;
                    sheet.Cells["J13"].Value = this.txtsvncPorem.Text;
                    sheet.Cells["J15"].Value = this.txtKF1.Text;
                }


                sheet.Column(10).Width = 14;
                //End Table_2

                //----------------------------------------------------------------------------------------------

                //Header Table_3
                sheet.Cells["A20"].Value = staticExcelLabels[15];
                sheet.Cells["A20"].Style.Font.Bold = true;
                sheet.Cells["A20"].Style.Font.Size = 16;
                //Start Table_3
                sheet.Cells["A21"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["A21:A22"].Merge = true;
                sheet.Cells["A21:A22"].Style.Font.Bold = true;
                sheet.Cells["A21"].Value = staticExcelLabels[18];
                sheet.Cells["A21:A22"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["A21:A22"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Bottom;
                sheet.Cells["A21:A22"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["B21:C21"].Merge = true;
                sheet.Cells["B21:C21"].Style.WrapText = true;
                sheet.Cells["B21:C21"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["B21"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["B21"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["B22:C22"].Merge = true;
                sheet.Cells["B22:C22"].Style.WrapText = true;
                sheet.Cells["B22:C22"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["B22"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["B22"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["B21"].Value = staticExcelLabels[16];
                
                sheet.Column(5).Width = 20;
                sheet.Cells["D21:E21"].Merge = true;
                sheet.Cells["D21:E21"].Style.WrapText = true;
                sheet.Cells["D21:E21"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["D21"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["D21"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["D22:E22"].Merge = true;
                sheet.Cells["D22:E22"].Style.WrapText = true;
                sheet.Cells["D22:E22"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["D22"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["D22"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["D21"].Value = staticExcelLabels[17];
                
                //End Table_3

                //----------------------------------------------------------------------------------------------

                //Header Table_4
                sheet.Cells["A26"].Value = staticExcelLabels[19];
                sheet.Cells["A26"].Style.Font.Bold = true;
                sheet.Cells["A26"].Style.Font.Size = 16;
                //Start Table_4
                sheet.Cells["A27:D27"].Merge = true;
                sheet.Cells["A27:D27"].Style.WrapText = true;
                sheet.Cells["A27:D27"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["A27"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["A27"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                sheet.Cells["A28:D28"].Merge = true;
                sheet.Cells["A28:D28"].Style.WrapText = true;
                sheet.Cells["A28:D28"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["A28"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["A28"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                sheet.Cells["A27"].Value = staticExcelLabels[20];
                sheet.Cells["A28"].Value = staticExcelLabels[21];
                sheet.Cells["E27"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["E28"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["E27"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["E27"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["E28"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["E28"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["E27"].Formula = "ROUND((J11+J13*J15)/1000,5)";
                sheet.Cells["E27"].Style.Numberformat.Format = "# ##0.00 ₽;-# ##0.00 ₽";
                sheet.Cells["E28"].Formula = "D12*E27";
                sheet.Cells["E28"].Style.Numberformat.Format = "# ##0.00 ₽;-# ##0.00 ₽";
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

                sheet.Cells["A11:I16"].Style.Font.Name = "Tahoma";
                sheet.Cells["A11:I16"].Style.Font.Size = 10;
                sheet.Cells["J11:J16"].Style.Font.Name = "Courier New";

                sheet.Cells["A21:E22"].Style.Font.Name = "Tahoma";
                sheet.Cells["A21:E21"].Style.Font.Size = 10;
                sheet.Cells["B22:E22"].Style.Font.Name = "Courier New";

                sheet.Cells["A27:D28"].Style.Font.Name = "Tahoma";
                sheet.Cells["A27:D28"].Style.Font.Size = 10;
                sheet.Cells["E27:E28"].Style.Font.Name = "Courier New";
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
                        sheet.Cells["N5"].Value = staticExcelLabels[28];
                        sheet.Cells["N6"].Value = staticExcelLabels[29];
                        sheet.Cells["O5:O6"].Value = staticExcelLabels[30];
                        sheet.Cells["P4"].Value = this.txtDateFirst.Text;
                        sheet.Cells["Q4"].Value = this.txtDateLast.Text;
                        sheet.Cells["P5"].Value = decimal.Parse(this.txtConFirst.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                        sheet.Cells["P5"].Style.Numberformat.Format = "0.000";
                        sheet.Cells["Q5"].Value = decimal.Parse(this.txtConLast.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                        sheet.Cells["Q5"].Style.Numberformat.Format = "0.000";
                        sheet.Cells["P6"].Value = decimal.Parse(this.txtGenFirst.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                        sheet.Cells["P6"].Style.Numberformat.Format = "0.000";
                        sheet.Cells["Q6"].Value = decimal.Parse(this.txtGenLast.Text, NumberStyles.Float, CultureInfo.CurrentCulture);
                        sheet.Cells["Q6"].Style.Numberformat.Format = "0.000";
                        sheet.Cells["R5"].Formula = "Q5 - P5";
                        sheet.Cells["R5"].Style.Numberformat.Format = "0.000";
                        sheet.Cells["R6"].Formula = "Q6 - P6";
                        sheet.Cells["R6"].Style.Numberformat.Format = "0.000";

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

                        sheet.Cells["N5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["N6"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["O5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["O6"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["P6"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["P4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["P5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["P6"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["Q4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["Q5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["Q6"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["R5"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["R6"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        sheet.Cells["N2:R6"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        sheet.Cells["N2:R6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Cells["N2:R6"].Style.WrapText = true;

                        sheet.Column(14).Width = 20;
                        sheet.Column(15).Width = 10;
                        sheet.Column(16).Width = 15;
                        sheet.Column(17).Width = 15;
                        sheet.Column(18).Width = 14;
                        //End Table_Intervals

                        sheet.Cells["B22"].Formula = "ROUND(IF(R5>R6,R5-R6,0),0)";
                        sheet.Cells["D22"].Formula = "ROUND(IF(R6>R5,R6-R5,0),0)";

                        //Exclusive style
                        sheet.Cells["N2:R6"].Style.Font.Name = "Tahoma";
                        sheet.Cells["N2:R6"].Style.Font.Size = 10;
                        sheet.Cells["P4:Q4"].Style.Font.Name = "Courier New";
                        sheet.Cells["P4:Q4"].Style.Font.Size = 11;
                        sheet.Cells["P5:R6"].Style.Font.Name = "Courier New";
                        sheet.Cells["P5:R6"].Style.Font.Size = 11;
                        //

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
                        catch
                        {
                            MessageBox.Show("Не удалось сохранить файл Excel");
                            resComplete = false;
                            return;
                        }
                        
                        break;

                    case "useHours":
                        //Header Table_Hours
                        sheet.Cells["N1"].Value = staticExcelLabels[35];
                        sheet.Cells["N1"].Style.Font.Bold = true;
                        sheet.Cells["N1"].Style.Font.Size = 16;
                        //Start Table_Hours
                        sheet.Cells["P2"].Value = staticExcelLabels[28];
                        sheet.Cells["Q2"].Value = staticExcelLabels[29];
                        sheet.Cells["P2"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["Q2"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["P3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["Q3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Column(14).Width = 11;
                        sheet.Column(15).Width = 11;

                        sheet.Cells["O3"].Value = staticExcelLabels[18];
                        sheet.Cells["O3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["N4"].Value = "Дата";
                        sheet.Cells["N4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["O4"].Value = "Час";
                        sheet.Cells["O4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["P4"].Value = staticExcelLabels[30];
                        sheet.Cells["P4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["Q4"].Value = staticExcelLabels[30];
                        sheet.Cells["Q4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["R5:R28"].Merge = true;
                        sheet.Cells["R5:R28"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Column(18).Width = 4;
                        sheet.Column(14).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Column(15).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Column(16).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Column(17).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        sheet.Cells["N1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                        //End Table_Hours

                        ExcelWorksheet sheet2 = package.Workbook.Worksheets.Add("Данные");
                        sheet2.Cells["I2"].Value = "";
                        sheet2.Column(9).AutoFit();

                        //Header Table_dataHours
                        sheet2.Cells["A1"].Value = staticExcelLabels[35];
                        sheet2.Cells["A1"].Style.Font.Bold = true;
                        sheet2.Cells["A1"].Style.Font.Size = 16;
                        //Start Table_dataHours
                        sheet2.Cells["C2"].Value = staticExcelLabels[28];
                        sheet2.Cells["D2"].Value = staticExcelLabels[29];
                        sheet2.Cells["C2"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Cells["C3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Cells["D2"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Cells["D3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        sheet2.Cells["B3"].Value = staticExcelLabels[18];
                        sheet2.Cells["B3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Cells["A4"].Value = "Дата";
                        sheet2.Cells["A4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Cells["B4"].Value = "Час";
                        sheet2.Cells["B4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Cells["C4"].Value = staticExcelLabels[30];
                        sheet2.Cells["C4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet2.Cells["D4"].Value = staticExcelLabels[30];
                        sheet2.Cells["D4"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        sheet.Cells["B22"].Formula = "ROUND(IF(P3>Q3,P3-Q3,0),0)";
                        sheet.Cells["D22"].Formula = "ROUND(IF(Q3>P3,Q3-P3,0),0)";

                        sheet2.Column(1).Width = 11;
                        sheet2.Column(2).Width = 11;
                        sheet2.Column(3).AutoFit();
                        sheet2.Column(4).AutoFit();


                        foreach (DataGridViewRow row in this.dataHoursViewer.Rows)
                        {
                            sheet2.Cells[offsetRow, 1].Value = row.Cells[0].Value.ToString();
                            sheet2.Cells[offsetRow, 2].Value = row.Cells[1].Value.ToString();
                            sheet2.Cells[offsetRow, 3].Value = decimal.Parse(Convert.ToString(row.Cells[2].Value.ToString()), NumberStyles.Float, CultureInfo.CurrentCulture);
                            sheet2.Cells[offsetRow, 3].Style.Numberformat.Format = "0.000";
                            sheet2.Cells[offsetRow, 4].Value = decimal.Parse(Convert.ToString(row.Cells[3].Value.ToString()), NumberStyles.Float, CultureInfo.CurrentCulture);
                            sheet2.Cells[offsetRow, 4].Style.Numberformat.Format = "0.000";
                            offsetRow++;
                        }

                        sheet2.Cells["C3"].Formula = "SUM(C5:C" + (offsetRow-1) + ")";
                        sheet2.Cells["D3"].Formula = "SUM(D5:D" + (offsetRow-1) + ")";

                        for (int i = 0; i < 24; i++)
                        {
                            sheet.Cells[5 + i, 14].Formula = "=(OFFSET('" + sheet2.Name + "'!" + "A"+ (5+i).ToString() + ",'" + sheet2.Name +"'!J2"+ ",0,1,1))";
                            sheet.Cells[5 + i, 14].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            sheet.Cells[5 + i, 15].Formula = "=(OFFSET('" + sheet2.Name + "'!" + "B" + (5 + i).ToString() + ",'" + sheet2.Name + "'!J2" + ",0,1,1))";
                            sheet.Cells[5 + i, 15].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            sheet.Cells[5 + i, 16].Formula = "=(OFFSET('" + sheet2.Name + "'!" + "C" + (5 + i).ToString() + ",'" + sheet2.Name + "'!J2" + ",0,1,1))";
                            sheet.Cells[5 + i, 16].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            sheet.Cells[5 + i, 16].Style.Numberformat.Format = "0.000";
                            sheet.Cells[5 + i, 17].Formula = "=(OFFSET('" + sheet2.Name + "'!" + "D" + (5 + i).ToString() + ",'" + sheet2.Name + "'!J2" + ",0,1,1))";
                            sheet.Cells[5 + i, 17].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            sheet.Cells[5 + i, 17].Style.Numberformat.Format = "0.000";
                        }

                        sheet.Cells["P3"].Formula = "'" + sheet2.Name + "'!C3";
                        sheet.Cells["Q3"].Formula = "'" + sheet2.Name + "'!D3";

                        sheet2.Column(14).AutoFit();
                        sheet2.Column(15).AutoFit();
                        sheet2.Column(16).AutoFit();
                        sheet2.Column(17).AutoFit();

                        sheet.Column(16).AutoFit();
                        sheet.Column(17).AutoFit();
                        //End Table_Hours


                        //Exclusive style
                        sheet.Cells["P2:Q4"].Style.Font.Name = "Tahoma";
                        sheet.Cells["P2:Q4"].Style.Font.Size = 10;
                        sheet.Cells["N3:O28"].Style.Font.Name = "Tahoma";
                        sheet.Cells["N3:O28"].Style.Font.Size = 10;

                        sheet.Cells["P5:Q28"].Style.Font.Name = "Courier New";
                        sheet.Cells["P3:Q3"].Style.Font.Name = "Courier New";
                        sheet.Cells["P3:Q3"].Style.Font.Size = 11;

                        sheet.Cells["O3:Q3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        sheet.Cells["O3:Q3"].Style.Fill.BackgroundColor.SetColor(Color.FromKnownColor(KnownColor.LightGoldenrodYellow));
                        sheet.Cells["O3:Q3"].Style.Font.Bold = true;
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
                            return;
                        }


                        Excel.Application xlApp = new Excel.Application();
                        Excel.Workbook xlWB = xlApp.Workbooks.Open(CurrentFolder + monthString + year.ToString() + "_" + gName + "_hrs.xlsx");
                        Excel.Worksheet xlSht = xlWB.Worksheets[1];
                        Excel.Worksheet xlSht2 = xlWB.Worksheets[2];

                        Excel.Range UpperLeftCell = (Excel.Range)xlSht.get_Range("R5").Cells[1, 1];

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

        private void DocumentInfoBorderColor(object sender, TableLayoutCellPaintEventArgs e)
        {
            var panel = sender as TableLayoutPanel;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            var rectangle = e.CellBounds;
            using (var pen = new Pen(Color.Black, 1))
            {
                pen.Alignment = PenAlignment.Center;
                pen.DashStyle = DashStyle.Solid;



                if (e.Row == 1 && e.Column != 0)
                {
                    var topLeft = e.CellBounds.Location;
                    var topRight = new System.Drawing.Point(e.CellBounds.Right, e.CellBounds.Top);
                    e.Graphics.DrawLine(pen, topLeft, topRight);
                    if (e.Column == 2 || e.Column == 3)
                    {
                        var bottomLeft = new System.Drawing.Point(e.CellBounds.Left, e.CellBounds.Bottom - 1);
                        var bottomRight = new System.Drawing.Point(e.CellBounds.Right, e.CellBounds.Bottom - 1);
                        e.Graphics.DrawLine(pen, bottomLeft, bottomRight);
                    }
                }

                if (e.Row == 0 && e.Column == 2 || e.Column == 3)
                {
                    var topLeft = e.CellBounds.Location;
                    var topRight = new System.Drawing.Point(e.CellBounds.Right, e.CellBounds.Top);
                    e.Graphics.DrawLine(pen, topLeft, topRight);
                }

                if (e.Column == 2)
                {
                    var topLeft = e.CellBounds.Location;
                    var bottomLeft = new System.Drawing.Point(e.CellBounds.Left, e.CellBounds.Bottom);
                    e.Graphics.DrawLine(pen, topLeft, bottomLeft);

                }

                if (e.Column == 3)
                {
                    var topLeft = e.CellBounds.Location;
                    var bottomLeft = new System.Drawing.Point(e.CellBounds.Left, e.CellBounds.Bottom);
                    e.Graphics.DrawLine(pen, topLeft, bottomLeft);
                    var topRight = new System.Drawing.Point(e.CellBounds.Right - 1, e.CellBounds.Top);
                    var bottomRight = new System.Drawing.Point(e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    e.Graphics.DrawLine(pen, topRight, bottomRight);
                }

            }
        }

        private void TableBorderColor(object sender, TableLayoutCellPaintEventArgs e)
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

        private void GetPDFfile_Click(object sender, EventArgs e)
        {
            GenerateFileDocument("PDF");
        }

        private void GetExcelFile_Click(object sender, EventArgs e)
        {
            GenerateFileDocument("Excel");
        }


        private void GenerateFileDocument(string type)
        {
            int year = DateTime.ParseExact(lblAbonentDateYear.Text, "yyyy", CultureInfo.CurrentCulture).Year;
            int month = DateTime.ParseExact(lblAbonentDateMonth.Text, "MMMM", CultureInfo.CurrentCulture).Month;
            string monthString = new DateTime(year, month, 1).ToString("MM");
            string CurrentFolder = gCurrentFolder + "\\data\\common\\files\\" + year.ToString() + "\\" + monthString + "\\" + gName + "\\";

            bool resComplete = false;

            List<RadioButton> radioButtons = new List<RadioButton> { this.useIntervals, this.useHours };
            var checkedButton = radioButtons.FirstOrDefault(r => r.Checked);

            ReadResource("dataEditor.data.text.ExcelStaticLables.txt");

            string fullPathFileName = CurrentFolder + monthString + year.ToString() + "_АПП_" + lblAgreementNumber.Text + ".xlsx";


            switch (type)
            {
                case "PDF":
                    if (File.Exists(CurrentFolder + monthString + year.ToString() + "_АПП_" + lblAgreementNumber.Text + ".pdf"))
                    {
                        DialogResult dialogResult = MessageBox.Show("Файл уже существует, пересоздать файл заново?", "Выберите действие", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            goto CreateFile;
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            resComplete = true;
                            goto completeVoid;
                        }
                    }
                    else
                    {
                        goto CreateFile;
                    }
                    break;

                case "Excel":
                    if (File.Exists(fullPathFileName))
                    {
                        DialogResult dialogResult = MessageBox.Show("Файл уже существует, пересоздать файл заново?", "Выберите действие", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            goto CreateFile;
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            resComplete = true;
                            goto completeVoid;
                        }
                    }
                    else
                    {
                        goto CreateFile;
                    }
                    break;
            }

        CreateFile:

            using (var package = new ExcelPackage())
            {
                ExcelWorksheet sheet = package.Workbook.Worksheets.Add(monthString + "_" + gName);

                sheet.Cells["A1"].Value = staticExcelLabels[54] + ":";
                sheet.Cells["C1"].Value = this.lblSeller.Text;

                sheet.Cells["A2"].Value = staticExcelLabels[56] + ":";
                sheet.Cells["B2"].Value = this.lblINNseller.Text;

                sheet.Cells["A4"].Value = staticExcelLabels[55] + ":";
                sheet.Cells["C4"].Value = this.lblBuyer.Text;

                sheet.Cells["A5"].Value = staticExcelLabels[56] + ":";
                sheet.Cells["B5"].Value = this.lblINNbuyer.Text;

                sheet.Cells["A8"].Value = staticExcelLabels[57];

                sheet.Cells["D8:M8"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                sheet.Cells["N8"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["N9"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["O8:P8"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["O9:P9"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                sheet.Cells["L12:M12"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["N12:O12"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["L13:M13"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["N13:O13"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                sheet.Cells["A15:P16"].Merge = true;
                sheet.Cells["D8:M8"].Merge = true;
                sheet.Cells["D9:M9"].Merge = true;
                sheet.Cells["O8:P8"].Merge = true;
                sheet.Cells["O9:P9"].Merge = true;
                sheet.Cells["B12:K13"].Merge = true;
                sheet.Cells["L12:M12"].Merge = true;
                sheet.Cells["L13:M13"].Merge = true;
                sheet.Cells["N12:O12"].Merge = true;
                sheet.Cells["N13:O13"].Merge = true;

                sheet.Cells["D8"].Value = this.lblAgreementName.Text;
                sheet.Cells["D9"].Value = staticExcelLabels[59];
                sheet.Cells["N8"].Value = staticExcelLabels[60];
                sheet.Cells["N9"].Value = staticExcelLabels[9];

                sheet.Cells["O8"].Value = this.lblAgreementNumber.Text;
                sheet.Cells["O9"].Value = this.lblAgreementDate.Text;

                sheet.Cells["B12"].Value = staticExcelLabels[63] + Environment.NewLine + staticExcelLabels[64];
                sheet.Cells["L12"].Value = staticExcelLabels[61];
                sheet.Cells["N12"].Value = staticExcelLabels[62];

                sheet.Cells["L13"].Value = this.lblDocNumber.Text;
                sheet.Cells["N13"].Value = this.lblDocDate.Text;

                sheet.Cells["A15"].Value = this.lblDescription.Text;

                sheet.Cells["A17"].Value = this.docPDFdataGridView.Columns[0].HeaderCell.Value;
                sheet.Cells["A18"].Value = this.docPDFdataGridView[0, 0].Value;
                sheet.Cells["A17"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["A18"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["B17:D17"].Merge = true;
                sheet.Cells["B18:D18"].Merge = true;
                sheet.Cells["B17:D17"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["B18:D18"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheet.Cells["B17"].Value = this.docPDFdataGridView.Columns[1].HeaderCell.Value;
                sheet.Cells["B18"].Value = this.docPDFdataGridView[1, 0].Value;

                switch (lblAbonentType.Text)
                {
                    case "ФЛ":
                        sheet.Cells["E17:G17"].Merge = true;
                        sheet.Cells["H17:J17"].Merge = true;
                        sheet.Cells["K17:M17"].Merge = true;
                        sheet.Cells["N17:P17"].Merge = true;
                        sheet.Cells["E17:G17"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["H17:J17"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["K17:M17"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["N17:P17"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["E17"].Value = this.docPDFdataGridView.Columns[2].HeaderCell.Value;
                        sheet.Cells["H17"].Value = this.docPDFdataGridView.Columns[3].HeaderCell.Value;
                        sheet.Cells["K17"].Value = this.docPDFdataGridView.Columns[4].HeaderCell.Value;
                        sheet.Cells["N17"].Value = this.docPDFdataGridView.Columns[5].HeaderCell.Value;


                        sheet.Cells["E18:G18"].Merge = true;
                        sheet.Cells["H18:J18"].Merge = true;
                        sheet.Cells["K18:M18"].Merge = true;
                        sheet.Cells["N18:P18"].Merge = true;
                        sheet.Cells["E18:G18"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["H18:J18"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["K18:M18"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["N18:P18"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["E18"].Value = this.docPDFdataGridView[2, 0].Value;
                        sheet.Cells["H18"].Value = this.docPDFdataGridView[3, 0].Value;
                        sheet.Cells["H18"].Style.Numberformat.Format = "0";
                        sheet.Cells["K18"].Value = this.docPDFdataGridView[4, 0].Value;
                        sheet.Cells["K18"].Style.Numberformat.Format = "0.00000";
                        sheet.Cells["N18"].Value = this.docPDFdataGridView[5, 0].Value;
                        sheet.Cells["N18"].Style.Numberformat.Format = "0.00";
                        break;

                    case "ЮЛ":
                        sheet.Cells["E17:F17"].Merge = true;
                        sheet.Cells["G17:H17"].Merge = true;
                        sheet.Cells["I17:J17"].Merge = true;
                        sheet.Cells["K17:L17"].Merge = true;
                        sheet.Cells["M17:N17"].Merge = true;
                        sheet.Cells["O17:P17"].Merge = true;
                        sheet.Cells["E17:F17"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["G17:H17"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["I17:J17"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["K17:L17"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["M17:N17"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["O17:P17"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["E17"].Value = this.docPDFdataGridView.Columns[2].HeaderCell.Value;
                        sheet.Cells["G17"].Value = this.docPDFdataGridView.Columns[3].HeaderCell.Value;
                        sheet.Cells["I17"].Value = this.docPDFdataGridView.Columns[4].HeaderCell.Value;
                        sheet.Cells["K17"].Value = this.docPDFdataGridView.Columns[5].HeaderCell.Value;
                        sheet.Cells["M17"].Value = this.docPDFdataGridView.Columns[6].HeaderCell.Value;
                        sheet.Cells["O17"].Value = this.docPDFdataGridView.Columns[7].HeaderCell.Value;


                        sheet.Cells["E18:F18"].Merge = true;
                        sheet.Cells["G18:H18"].Merge = true;
                        sheet.Cells["I18:J18"].Merge = true;
                        sheet.Cells["K18:L18"].Merge = true;
                        sheet.Cells["M18:N18"].Merge = true;
                        sheet.Cells["O18:P18"].Merge = true;
                        sheet.Cells["E18:F18"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["G18:H18"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["I18:J18"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["K18:L18"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["M18:N18"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["O18:P18"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        sheet.Cells["E18"].Value = this.docPDFdataGridView[2, 0].Value;
                        sheet.Cells["G18"].Value = this.docPDFdataGridView[3, 0].Value;
                        sheet.Cells["G18"].Style.Numberformat.Format = "0";
                        sheet.Cells["I18"].Value = this.docPDFdataGridView[4, 0].Value;
                        sheet.Cells["I18"].Style.Numberformat.Format = "0.00000";
                        sheet.Cells["K18"].Value = this.docPDFdataGridView[5, 0].Value;
                        sheet.Cells["K18"].Style.Numberformat.Format = "0.00";
                        sheet.Cells["M18"].Value = this.docPDFdataGridView[6, 0].Value;
                        sheet.Cells["M18"].Style.Numberformat.Format = "0.00";
                        sheet.Cells["O18"].Value = this.docPDFdataGridView[7, 0].Value;
                        sheet.Cells["O18"].Style.Numberformat.Format = "0.00";


                        sheet.Column(5).Width = 6;
                        sheet.Column(6).Width = 6;
                        sheet.Column(7).Width = 6;
                        sheet.Column(8).Width = 6;

                        sheet.Column(11).Width = 13;
                        sheet.Column(16).Width = 13;
                        break;
                }

                sheet.Cells["A20"].Value = staticExcelLabels[54];
                sheet.Cells["M20"].Value = staticExcelLabels[55];

                sheet.Cells["A21"].Value = this.lblSellerSign.Text;
                sheet.Cells["M21"].Value = this.lblBuyerSign.Text;

                sheet.Cells["M23:P24"].Merge = true;
                sheet.Cells["M23"].Value = this.lblBuyerPosition.Text;
                sheet.Cells["P25"].Value = this.lblBuyerAgent.Text;
                sheet.Cells["A25"].Value = this.lblSellerShortSign.Text;
                sheet.Cells["P26"].Value = this.lblBuyerAttorney.Text;

                sheet.Cells["A1:P26"].Style.Font.Name = "Tahoma";
                sheet.Cells["A1:P26"].Style.Font.Size = 11;
                sheet.Cells["D8:M8"].Style.Font.Size = 10;
                sheet.Cells["D9:M9"].Style.Font.Size = 8;
                sheet.Cells["N8:N9"].Style.Font.Size = 10;

                sheet.Cells["A1:A5"].Style.Font.Bold = true;
                sheet.Cells["B12:O12"].Style.Font.Bold = true;
                sheet.Cells["B12:K13"].Style.Font.Size = 12;
                sheet.Cells["L12:O12"].Style.Font.Size = 10;
                sheet.Cells["O8:P9"].Style.Font.Name = "Courier New";
                sheet.Cells["L13:O13"].Style.Font.Name = "Courier New";


                sheet.Cells["A15:P17"].Style.Font.Size = 10;
                sheet.Cells["A18:P18"].Style.Font.Name = "Courier New";
                sheet.Cells["A20"].Style.Font.Bold = true;
                sheet.Cells["M20"].Style.Font.Bold = true;
                sheet.Cells["A25:P25"].Style.Font.Size = 12;
                sheet.Cells["A26:P26"].Style.Font.Size = 8;

                sheet.Column(3).Width = 16;
                sheet.Column(15).Width = 10;
                sheet.Column(16).Width = 10;
                sheet.Row(17).Height = 30;
                sheet.Row(18).Height = 30;
                sheet.Row(25).Height = 60;

                sheet.Cells["D8:P9"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["D8:P9"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                sheet.Cells["A12:P18"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                sheet.Cells["A12:P18"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                sheet.Cells["A12:P18"].Style.WrapText = true;
                sheet.Cells["M23:M24"].Style.WrapText = true;
                sheet.Cells["M23:M24"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
                sheet.Cells["M23:M24"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                sheet.Cells["A15:P16"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                sheet.Cells["P25:P26"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;


                sheet.PrinterSettings.PrintArea = sheet.Cells["A1:P26"];
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;
                sheet.PrinterSettings.Orientation = eOrientation.Landscape;
                sheet.Row(26).PageBreak = true;
                sheet.Column(16).PageBreak = true;
                sheet.PrinterSettings.FitToPage = true;
                sheet.View.PageBreakView = true;

                try
                {
                    if (!Directory.Exists(CurrentFolder))
                        Directory.CreateDirectory(CurrentFolder);

                    switch (type)
                    {
                        case "Excel":
                            package.SaveAs(new FileInfo(@fullPathFileName));
                            package.Dispose();
                            resComplete = true;
                            break;

                        case "PDF":
                            try
                            {
                                package.SaveAs(new FileInfo(CurrentFolder + monthString + year.ToString() + "_АПП_" + lblAgreementNumber.Text + "_temp_.xlsx"));
                                package.Dispose();

                                Excel.Application xlApp = new Excel.Application();
                                Excel.Workbook xlWB = xlApp.Workbooks.Open(CurrentFolder + monthString + year.ToString() + "_АПП_" + lblAgreementNumber.Text + "_temp_.xlsx");
                                Excel.Worksheet xlSht = xlWB.Worksheets[1];
                                xlSht.PrintOut(1, 1, 1, false, "Microsoft Print to PDF", true, false, CurrentFolder + monthString + year.ToString() + "_АПП_" + lblAgreementNumber.Text + ".pdf");

                                xlWB.Close(true);
                                xlApp.Quit();
                                xlApp = null;
                                xlWB = null;
                                xlSht = null;
                                File.Delete(CurrentFolder + monthString + year.ToString() + "_АПП_" + lblAgreementNumber.Text + "_temp_.xlsx");
                            }
                            catch
                            {
                                package.SaveAs(new FileInfo(CurrentFolder + monthString + year.ToString() + "_АПП_" + lblAgreementNumber.Text + "_temp_.xlsx"));
                                package.Dispose();

                                Excel.Application xlApp = new Excel.Application();
                                Excel.Workbook xlWB = xlApp.Workbooks.Open(CurrentFolder + monthString + year.ToString() + "_АПП_" + lblAgreementNumber.Text + "_temp_.xlsx");
                                xlWB.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, CurrentFolder + monthString + year.ToString() + "_АПП_" + lblAgreementNumber.Text);

                                xlWB.Close(true);
                                xlApp.Quit();
                                xlApp = null;
                                xlWB = null;
                                File.Delete(CurrentFolder + monthString + year.ToString() + "_АПП_" + lblAgreementNumber.Text + "_temp_.xlsx");
                            }
                            finally
                            {
                                resComplete = true;
                            }
                            break;
                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл");
                    resComplete = false;
                    return;
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
                                switch (type)
                                {
                                    case "Excel":
                                        Excel.Application xlApp = new Excel.Application();
                                        xlApp.Application.Visible = true;
                                        Excel.Workbook xlWB = xlApp.Workbooks.Open(fullPathFileName);
                                        break;

                                    case "PDF":
                                        OpenWithDefaultProgram(CurrentFolder + monthString + year.ToString() + "_АПП_" + lblAgreementNumber.Text + ".pdf");
                                        break;
                                }


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

        public static void OpenWithDefaultProgram(string path)
        {
            using Process fileopener = new Process();
            fileopener.StartInfo.FileName = "explorer";
            fileopener.StartInfo.Arguments = "\"" + path + "\"";
            fileopener.Start();
        }


    }

}
