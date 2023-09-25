using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataEditor
{
    public partial class pdfDocument : Form
    {
        public pdfDocument()
        {
            InitializeComponent();
        }

        private Stream streamToPrint;

        string streamType;

        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt
        (
            IntPtr hdcDest, // handle to destination DC
            int nXDest, // x-coord of destination upper-left corner
            int nYDest, // y-coord of destination upper-left corner
            int nWidth, // width of destination rectangle
            int nHeight, // height of destination rectangle
            IntPtr hdcSrc, // handle to source DC
            int nXSrc, // x-coordinate of source upper-left corner
            int nYSrc, // y-coordinate of source upper-left corner
            System.Int32 dwRop // raster operation code
        );


        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Image image = Image.FromStream(this.streamToPrint);

            int x = e.MarginBounds.X;
            int y = e.MarginBounds.Y;

            int width = image.Width;
            int height = image.Height;
            if ((width / e.MarginBounds.Width) > (height / e.MarginBounds.Height))
            {
                width = e.MarginBounds.Width;
                height = image.Height * e.MarginBounds.Width / image.Width;
            }
            else
            {
                height = e.MarginBounds.Height;
                width = image.Width * e.MarginBounds.Height / image.Height;
            }
            Rectangle destRect = new System.Drawing.Rectangle(x, y, width, height);
            e.Graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
        }
        public void PreviewDocument(Stream streamToPrint, string streamType)
        {
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            this.streamToPrint = streamToPrint;
            this.streamType = streamType;

            printDocument.DefaultPageSettings.Landscape = true;
            PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
            printPrvDlg.Document = printDocument;
            printPrvDlg.ShowDialog();
        }

        public void StartPrint(Stream streamToPrint, string streamType)
        {
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

            this.streamToPrint = streamToPrint;
            this.streamType = streamType;

            PrintDialog PrintDialog = new PrintDialog();

            PrintDialog.AllowSomePages = true;
            PrintDialog.ShowHelp = true;
            PrintDialog.Document = printDocument;
            DialogResult result = PrintDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void pdfBtnPrint_Click(object sender, EventArgs e)
        {
            String filename = System.IO.Path.GetTempFileName();

            Graphics g1 = this.CreateGraphics();
            Image MyImage = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height, g1);
            Graphics g2 = Graphics.FromImage(MyImage);
            IntPtr dc1 = g1.GetHdc();
            IntPtr dc2 = g2.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            g1.ReleaseHdc(dc1);
            g2.ReleaseHdc(dc2);
            MyImage.Save(filename, ImageFormat.Png);
            FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            PreviewDocument(fileStream, "Image");
            fileStream.Close();
            if (System.IO.File.Exists(filename))
            {
                System.IO.File.Delete(filename);
            }
        }

        private void pdfDocument_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void CreateExcel_Click(object sender, EventArgs e)
        {

            
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
                    var topRight = new Point(e.CellBounds.Right, e.CellBounds.Top);
                    e.Graphics.DrawLine(pen, topLeft, topRight);
                    if(e.Column == 2 || e.Column == 3)
                    {
                        var bottomLeft = new Point(e.CellBounds.Left, e.CellBounds.Bottom-1);
                        var bottomRight = new Point(e.CellBounds.Right, e.CellBounds.Bottom-1);
                        e.Graphics.DrawLine(pen, bottomLeft, bottomRight);
                    }
                }

                if (e.Row == 0 && e.Column == 2 || e.Column == 3)
                {
                    var topLeft = e.CellBounds.Location;
                    var topRight = new Point(e.CellBounds.Right, e.CellBounds.Top);
                    e.Graphics.DrawLine(pen, topLeft, topRight);
                }

                if (e.Column == 2)
                {
                    var topLeft = e.CellBounds.Location;
                    var bottomLeft = new Point(e.CellBounds.Left, e.CellBounds.Bottom);
                    e.Graphics.DrawLine(pen, topLeft, bottomLeft);

                }

                if (e.Column == 3)
                {
                    var topLeft = e.CellBounds.Location;
                    var bottomLeft = new Point(e.CellBounds.Left, e.CellBounds.Bottom);
                    e.Graphics.DrawLine(pen, topLeft, bottomLeft);
                    var topRight = new Point(e.CellBounds.Right-1, e.CellBounds.Top);
                    var bottomRight = new Point(e.CellBounds.Right-1, e.CellBounds.Bottom);
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
    }
}
