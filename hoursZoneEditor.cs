using NPOI.SS.Formula.Functions;
using OfficeOpenXml.Core;
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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace dataEditor
{
    public partial class hoursZoneEditor : Form
    {
        public hoursZoneEditor()
        {
            InitializeComponent();

        }

        private void hoursZoneEditor_Load(object sender, EventArgs e)
        {
            fillTable();
            cmbxSelectGlobalZone.SelectedIndex = 0;
            cmbxSelectTypeZone.Items.AddRange(new[] { "день", "ночь" });
            cmbxSelectTypeZone.SelectedIndex = 0;
            doubleZoneTreeView.ExpandAll();
        }

        private void fillTable()
        {
            for (int hrs=1; hrs <= 24; hrs++)
            {
                string duration = (hrs - 1).ToString() + ":00-" + hrs.ToString() + ":00";
                hoursDataGrid.Rows.Add(duration);
            }
        }

        private void btnAddNew3z_Click(object sender, EventArgs e)
        {

            TreeNode parentNode = TrippleZoneTreeView.SelectedNode ?? TrippleZoneTreeView.Nodes[0];
            
            int nodeCount = 1;
            foreach (var node in TrippleZoneTreeView.SelectedNode.Nodes)
            {
                nodeCount++;
            }
            var childNode = nodeCount + " период";
            switch (parentNode.Text)
            {
                case "ночь":
                    if (parentNode != null && nodeCount == 1)
                    {
                        TreeNode initialChildNode = parentNode.Nodes.Add("с");
                        initialChildNode.NodeFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        TreeNode initialValueNode = initialChildNode.Nodes.Add("0");
                        initialValueNode.NodeFont = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        TreeNode finalChildNode = parentNode.Nodes.Add("до");
                        finalChildNode.NodeFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        TreeNode finalValueNode = finalChildNode.Nodes.Add("0");
                        finalValueNode.NodeFont = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    }
                    break;
                default:
                    if (parentNode != null && parentNode.Text == "пик" || parentNode.Text == "полупик")
                    {
                        TreeNode newZoneNode = parentNode.Nodes.Add(childNode);
                        newZoneNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        TreeNode initialChildNode = newZoneNode.Nodes.Add("с");
                        initialChildNode.NodeFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        TreeNode initialValueNode = initialChildNode.Nodes.Add("0");
                        initialValueNode.NodeFont = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        TreeNode finalChildNode = newZoneNode.Nodes.Add("до");
                        finalChildNode.NodeFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        TreeNode finalValueNode = finalChildNode.Nodes.Add("0");
                        finalValueNode.NodeFont = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    }
                    break;
            }
            TrippleZoneTreeView.ExpandAll();
        }

        private void TrippleZoneTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(TrippleZoneTreeView.SelectedNode != null)
            {
                btnAddNew3z.Enabled = true;
            }
            else
            {
                btnAddNew3z.Enabled = false;
            }
        }

        int[,] _2dayZone = new int[0, 6];
        int[,] _2nightZone = new int[0, 6];

        int[,] _3peakZone = new int[0, 6];
        int[,] _3semiPeakZone = new int[0, 6];
        int[,] _3night = new int[0, 6];


        int[,] _grectangles = new int[0, 6];
        private void btnApplyHours_Click(object sender, EventArgs e)
        {
            switch (cmbxSelectGlobalZone.Text)
            {
                case "2 зоны":
                    if(cmbxSelectTypeZone.Text == "день")
                    {
                        _2dayZone = SelectedRows();
                    }
                    else if (cmbxSelectTypeZone.Text == "ночь")
                    {
                        _2nightZone = SelectedRows();
                    }

                    foreach (DataGridViewRow rows in hoursDataGrid.Rows)
                    {
                        rows.DefaultCellStyle.BackColor = Color.Empty;
                        doubleZoneBackColor();
                    }
                    hoursDataGrid.Refresh();
                    hoursDataGrid.ClearSelection();
                    break;
                case "3 зоны":

                    break;
            }
        }

        private void doubleZoneBackColor()
        {
            if (_2dayZone.GetLength(0) > 0)
            {
                for (int i = 0; i < _2dayZone.GetLength(0); i++)
                {
                    for (int j = _2dayZone[i, 4]; j <= _2dayZone[i, 5]; j++)
                    {
                        if (hoursDataGrid.Rows[j].DefaultCellStyle.BackColor == Color.Empty)
                            hoursDataGrid.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200, 250);
                    }
                }
            }

            if (_2nightZone.GetLength(0) > 0)
            {
                for (int i = 0; i < _2nightZone.GetLength(0); i++)
                {
                    for (int j = _2nightZone[i, 4]; j <= _2nightZone[i, 5]; j++)
                    {
                        if(hoursDataGrid.Rows[j].DefaultCellStyle.BackColor == Color.Empty)
                            hoursDataGrid.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 200, 200);
                    }
                }
            }
        }



        T[,] ResizeArray<T>(T[,] original, int rows, int cols)
        {
            var newArray = new T[rows, cols];
            int minRows = Math.Min(rows, original.GetLength(0));
            int minCols = Math.Min(cols, original.GetLength(1));
            for (int i = 0; i < minRows; i++)
                for (int j = 0; j < minCols; j++)
                    newArray[i, j] = original[i, j];
            return newArray;
        }

        private int[,] SelectedRows()
        {
            List<int> selectedRows = new List<int>();
            foreach(DataGridViewRow row in hoursDataGrid.Rows)
            {
                if(row.Selected)
                {
                    selectedRows.Add(row.Index);
                }
            }

            int arraysCount = 1;
            int[,] rectangles = new int[arraysCount, 6];

            for (int i = 0; i < selectedRows.Count; i++)
            {
                if (i == 0)
                {
                    rectangles[arraysCount - 1, 0] = 1;
                    rectangles[arraysCount - 1, 1] = hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Y;
                    rectangles[arraysCount - 1, 2] = hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Width-1;
                    rectangles[arraysCount - 1, 3] = hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Height;
                    rectangles[arraysCount - 1, 4] = selectedRows[i];
                }
                else
                {
                    try
                    {
                        int diff = selectedRows[i] - selectedRows[i - 1];
                        if (diff == 1)
                        {
                            rectangles[arraysCount - 1, 3] += hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Height;
                            rectangles[arraysCount - 1, 5] = selectedRows[i];
                        }
                        else
                        {
                            arraysCount++;
                            rectangles = ResizeArray(rectangles, arraysCount, 6);
                            rectangles[arraysCount - 1, 0] = 1;
                            rectangles[arraysCount - 1, 1] = hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Y;
                            rectangles[arraysCount - 1, 2] = hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Width-1;
                            rectangles[arraysCount - 1, 3] = hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Height;
                            rectangles[arraysCount - 1, 4] = selectedRows[i];
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            bool printVal = false;
            if (printVal)
            {
                for (int i = 0; i < rectangles.GetLength(0); i++)
                {
                    Console.Write("{X= " + rectangles[i, 0] + "; ");
                    Console.Write("Y= " + rectangles[i, 1] + "; ");
                    Console.Write("width= " + rectangles[i, 2] + "; ");
                    Console.Write("TotalHeight= " + rectangles[i, 3] + "; ");
                    Console.Write("firstIndex= " + rectangles[i, 4] + "; ");
                    Console.Write("lastIndex= " + rectangles[i, 5] + "}" + "\n");
                }
            }
            return rectangles;
        }

        private void hoursDataGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (cmbxSelectGlobalZone.Text)
                {
                    case "2 зоны":
                        switch (cmbxSelectTypeZone.Text)
                        {
                            case "день":
                                foreach(DataGridViewRow row in hoursDataGrid.Rows)
                                {
                                    if(row.DefaultCellStyle.BackColor == Color.FromArgb(255, 200, 200, 250))
                                        row.DefaultCellStyle.BackColor = Color.Empty;
                                }
                                hoursDataGrid.Invalidate();
                                _2dayZone = SelectedRows();
                                break;

                            case "ночь":
                                foreach (DataGridViewRow row in hoursDataGrid.Rows)
                                {
                                    if (row.DefaultCellStyle.BackColor == Color.FromArgb(255, 250, 200, 200))
                                        row.DefaultCellStyle.BackColor = Color.Empty;
                                }
                                hoursDataGrid.Invalidate();
                                _2nightZone = SelectedRows();
                                break;
                        }
                        break;

                    case "3 зоны":

                        break;
                }

            }
        }

        private void hoursDataGridRowPaint(Rectangle rowBound)
        {
            Graphics g = hoursDataGrid.CreateGraphics();
            {
                using (var pen = new Pen(Color.FromArgb(255, 50, 0, 250), 2))
                {
                    pen.Alignment = PenAlignment.Center;
                    pen.DashStyle = DashStyle.Solid;

                    g.DrawLine(pen, rowBound.X, rowBound.Y, rowBound.X, rowBound.Y + 10);
                    g.DrawLine(pen, rowBound.X, rowBound.Y, rowBound.X + 10, rowBound.Y);

                    g.DrawLine(pen, rowBound.Right, rowBound.Bottom, rowBound.Right, rowBound.Bottom - 10);
                    g.DrawLine(pen, rowBound.Right, rowBound.Bottom, rowBound.Right - 10, rowBound.Bottom);
                }
            }
        }

        private void hoursDataGrid_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void hoursDataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void hoursDataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }

        private void hoursDataGrid_Paint(object sender, PaintEventArgs e)
        {
            if (_2dayZone.GetLength(0) > 0)
            {
                for (int i = 0; i < _2dayZone.GetLength(0); i++)
                {
                    Rectangle rowBound = new Rectangle(_2dayZone[i, 0], _2dayZone[i, 1], _2dayZone[i, 2], _2dayZone[i, 3]);
                    using (var pen = new Pen(Color.FromArgb(255, 50, 0, 250), 2))
                    {
                        pen.Alignment = PenAlignment.Center;
                        pen.DashStyle = DashStyle.Solid;

                        e.Graphics.DrawLine(pen, rowBound.X, rowBound.Y, rowBound.X, rowBound.Y + 10);
                        e.Graphics.DrawLine(pen, rowBound.X, rowBound.Y, rowBound.X + 10, rowBound.Y);

                        e.Graphics.DrawLine(pen, rowBound.Right, rowBound.Bottom, rowBound.Right, rowBound.Bottom - 10);
                        e.Graphics.DrawLine(pen, rowBound.Right, rowBound.Bottom, rowBound.Right - 10, rowBound.Bottom);
                    }
                }
            }


            if (_2nightZone.GetLength(0) > 0)
            {
                for (int i = 0; i < _2nightZone.GetLength(0); i++)
                {
                    Rectangle rowBound = new Rectangle(_2nightZone[i, 0], _2nightZone[i, 1], _2nightZone[i, 2], _2nightZone[i, 3]);
                    using (var pen = new Pen(Color.FromArgb(255, 250, 0, 50), 2))
                    {
                        pen.Alignment = PenAlignment.Center;
                        pen.DashStyle = DashStyle.Solid;


                        e.Graphics.DrawLine(pen, rowBound.X, rowBound.Y, rowBound.X, rowBound.Y + 10);
                        e.Graphics.DrawLine(pen, rowBound.X, rowBound.Y, rowBound.X + 10, rowBound.Y);

                        e.Graphics.DrawLine(pen, rowBound.Right, rowBound.Bottom, rowBound.Right, rowBound.Bottom - 10);
                        e.Graphics.DrawLine(pen, rowBound.Right, rowBound.Bottom, rowBound.Right - 10, rowBound.Bottom);
                    }
                }
            }

        }

        private void cmbxSelectHours_SelectedIndexChanged(object sender, EventArgs e)
        {
            hoursDataGrid.Refresh();
        }

        private void cmbxSelectHours_DropDownClosed(object sender, EventArgs e)
        {
            switch (cmbxSelectGlobalZone.Text)
            {
                case "2 зоны":
                    cmbxSelectTypeZone.Items.Clear();
                    cmbxSelectTypeZone.Items.AddRange(new[] { "день", "ночь" });
                    cmbxSelectTypeZone.SelectedIndex = 0;

                    foreach (DataGridViewRow rows in hoursDataGrid.Rows)
                    {
                        rows.DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control);

                        doubleZoneBackColor();

                    }
                    hoursDataGrid.Refresh();
                    hoursDataGrid.ClearSelection();
                    break;

                case "3 зоны":
                    cmbxSelectTypeZone.Items.Clear();

                    foreach (DataGridViewRow rows in hoursDataGrid.Rows)
                    {
                        rows.DefaultCellStyle.BackColor = Color.Empty;
                    }
                    break;
            }
        }
    }
}
