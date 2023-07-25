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
            cmbxSelectHours.SelectedIndex = 0;
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

        private void btnApplyHours_Click(object sender, EventArgs e)
        {
            SelectedRows();
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
            int[,] rectangles = new int[arraysCount, 4];
            Console.WriteLine("\n" + "Debug new ListSelectedRows");
            for (int i = 0; i < selectedRows.Count; i++)
            {
                if (i == 0)
                {
                    rectangles[arraysCount - 1, 0] = 1;
                    rectangles[arraysCount - 1, 1] = hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Y;
                    rectangles[arraysCount - 1, 2] = hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Width;
                    rectangles[arraysCount - 1, 3] = hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Height;
                    Console.WriteLine(selectedRows[i]);
                }
                else
                {
                    try
                    {
                        int diff = selectedRows[i] - selectedRows[i - 1];
                        if (diff == 1)
                        {
                            rectangles[arraysCount - 1, 3] += hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Height;
                            Console.WriteLine(selectedRows[i]);
                        }
                        else
                        {
                            arraysCount++;
                            rectangles = ResizeArray(rectangles, arraysCount, 4);
                            rectangles[arraysCount - 1, 0] = 1;
                            rectangles[arraysCount - 1, 1] = hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Y;
                            rectangles[arraysCount - 1, 2] = hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Width;
                            rectangles[arraysCount - 1, 3] = hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Height;
                            Console.WriteLine("\n" + selectedRows[i]);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            Console.WriteLine("\n" + "Debug View result array");
            for(int i=0; i<rectangles.GetLength(0); i++)
            {
                Console.Write("{X= " + rectangles[i,0] + "; ");
                Console.Write("Y= " + rectangles[i, 1] + "; ");
                Console.Write("width= " + rectangles[i, 2] + "; ");
                Console.Write("TotalHeight= " + rectangles[i, 3] + "}" + "\n");
            }
            

            return rectangles;
        }

        private void hoursDataGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }
        }

        private void hoursDataGridRowPaint(int row, PaintEventArgs e)
        {
            if (row != -1)
            {
                hoursDataGrid.Refresh();
                Rectangle rowBound = e.ClipRectangle;
                {
                    using (var pen = new Pen(Color.FromArgb(255, 50, 0, 250), 2))
                    {
                        pen.Alignment = PenAlignment.Center;
                        pen.DashStyle = DashStyle.Solid;

                        e.Graphics.DrawLine(pen, rowBound.X, rowBound.Y, rowBound.X, rowBound.Y + 5);
                        e.Graphics.DrawLine(pen, rowBound.X, rowBound.Y, rowBound.X + 5, rowBound.Y);

                        e.Graphics.DrawLine(pen, rowBound.Right, rowBound.Bottom, rowBound.Right, rowBound.Bottom - 5);
                        e.Graphics.DrawLine(pen, rowBound.Right, rowBound.Bottom, rowBound.Right - 5, rowBound.Bottom);


                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Blue)), rowBound);
                    }
                }
            }
        }

        private void hoursDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            //Rectangle rowBound = hoursDataGrid.GetRowDisplayRectangle(hoursDataGrid.CurrentCell.RowIndex, false);
            //hoursDataGridRowPaint(hoursDataGrid.CurrentCell.RowIndex, new PaintEventArgs(hoursDataGrid.CreateGraphics(), rowBound));
        }
    }
}
