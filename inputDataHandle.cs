using NPOI.OpenXmlFormats.Vml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataEditor
{

    public partial class inputDataHandle : Form
    {
        public inputDataHandle()
        {
            InitializeComponent();
        }





        int _linesCount;
        private void inputTextBoxHRS_TextChanged(object sender, EventArgs e)
        {

            if (_linesCount != inputTextBox.Lines.Count())
            {
                _linesCount = inputTextBox.Lines.Count();
                lineNumbersBox.Refresh();
            }
        }

        private void RichTextBoxBorder(object sender, TableLayoutCellPaintEventArgs e)
        {
            var panel = sender as TableLayoutPanel;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            var rectangle = e.ClipRectangle;
            using (var pen = new Pen(Color.Black, 1))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                var topLeft = new Point(rectangle.Left, rectangle.Location.Y);
                var topRight = new Point(rectangle.Right-1, rectangle.Location.Y);
                var bottonRight = new Point(rectangle.Right-1, rectangle.Location.Y + rectangle.Height-1);
                var bottonLeft = new Point(rectangle.Left, rectangle.Location.Y + rectangle.Height-1);

                e.Graphics.DrawLine(pen, topLeft, topRight);
                e.Graphics.DrawLine(pen, topRight, bottonRight);
                e.Graphics.DrawLine(pen, bottonRight, bottonLeft);
                e.Graphics.DrawLine(pen, bottonLeft, topLeft);
            }
        }

        public void DrawLineNumber()
        {
            int lineNum = 0;
            int height = inputTextBox.Size.Height;
            Graphics g = lineNumbersBox.CreateGraphics();
            g.SmoothingMode = SmoothingMode.HighSpeed;

            lineNumbersBox.Refresh();

            int charIndex = inputTextBox.GetCharIndexFromPosition(new Point(0, 0));
            lineNum = inputTextBox.GetLineFromCharIndex(charIndex);

            while (true)
            {
                charIndex = inputTextBox.GetFirstCharIndexFromLine(lineNum);
                if (charIndex == -1)
                    break;
                Point pt = inputTextBox.GetPositionFromCharIndex(charIndex);
                Font f = new Font("Courier New", 8.25F, GraphicsUnit.Point);
                g.DrawString((lineNum + 1).ToString(), f, Brushes.Blue, new PointF(8, inputTextBox.Margin.Top+pt.Y));
                lineNum++;
                if (height < inputTextBox.Margin.Top+pt.Y)
                    break;
            }
            g.Dispose();
        }


        private void inputTextBoxHRS_VScroll(object sender, EventArgs e)
        {
            lineNumbersBox.Refresh();
        }


        private void inputTextBoxHRS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V || e.Shift && e.KeyCode == Keys.I)
            {
                inputTextBox.SuspendLayout();
                int insPt = inputTextBox.SelectionStart;
                string postRTFContent = inputTextBox.Text.Substring(insPt);
                inputTextBox.Text = inputTextBox.Text.Substring(0, insPt);
                inputTextBox.Text += (string)Clipboard.GetData("Text") + postRTFContent;
                inputTextBox.SelectionStart = inputTextBox.TextLength - postRTFContent.Length;
                inputTextBox.ResumeLayout();
                e.Handled = true;
            }
        }

        private void inputTextBoxHRS_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = inputTextBox.GetPositionFromCharIndex(inputTextBox.SelectionStart);
            if (pt.X == 1)
            {
                
            }
        }

        private void inputBtnEntry_Click(object sender, EventArgs e)
        {

        }

        private void inputDataHandle_Shown(object sender, EventArgs e)
        {

        }

        public class DBufferedPanel : Panel
        {
            public DBufferedPanel()
            {
                this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer,
                    true);
            }
        }

        private void lineNumbersBox_Paint(object sender, PaintEventArgs e)
        {
            int lineNum = 0;
            int height = inputTextBox.Size.Height;

            int charIndex = inputTextBox.GetCharIndexFromPosition(new Point(0, 0));
            lineNum = inputTextBox.GetLineFromCharIndex(charIndex);

            while (true)
            {
                charIndex = inputTextBox.GetFirstCharIndexFromLine(lineNum);
                if (charIndex == -1)
                    break;
                Point pt = inputTextBox.GetPositionFromCharIndex(charIndex);
                Font f = new Font("Courier New", 8.25F, GraphicsUnit.Point);
                e.Graphics.DrawString((lineNum + 1).ToString(), f, Brushes.Blue, new PointF(8, inputTextBox.Margin.Top + pt.Y));
                lineNum++;
                if (height < inputTextBox.Margin.Top + pt.Y)
                    break;
            }
        }
    }
}
