using MathNet.Numerics.LinearAlgebra.Factorization;
using NPOI.SS.Formula.Functions;
using OfficeOpenXml.DataValidation;
using Org.BouncyCastle.Asn1.X500;
using Org.BouncyCastle.Bcpg.Sig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace dataEditor
{
    public partial class mgDatsEditor : Form
    {
        DataGridViewCell ActiveCell = null;



        public mgDatsEditor()
        {
            InitializeComponent();
        }

        private void mgDatsEditor_Load(object sender, EventArgs e)
        {
            loadDictionary();
        }

        private void loadDictionary()
        {
            DataSet ImportDataSet = new DataSet();

            dataGridDictionary.DataSource = null;
            DataTable DT = (DataTable)dataGridDictionary.DataSource;
            if (DT != null)
                DT.Clear();

            dataGridDictionary.Rows.Clear();
            dataGridDictionary.Refresh();

            if (File.Exists(Environment.CurrentDirectory + "\\contractors_" + listGTP.Text +".xml"))
            {
                string xmlFileName = Environment.CurrentDirectory + "\\contractors_" + listGTP.Text +".xml";

                XDocument XMLfile = XDocument.Load(xmlFileName);
                ImportDataSet.ReadXml(xmlFileName);

                int rwi = 0;
                foreach (XElement infoElement in XMLfile.Root.Elements(listGTP.Text))
                {
                    dataGridDictionary.Rows.Add();
                    if (infoElement.Element("Agreement") != null)
                        dataGridDictionary.Rows[rwi].Cells["Agreement"].Value = infoElement.Element("Agreement").Value;
                    if (infoElement.Element("DateIntoForce") != null)
                        dataGridDictionary.Rows[rwi].Cells["DateIntoForce"].Value = infoElement.Element("DateIntoForce").Value;
                    if (infoElement.Element("FullName") != null)
                        dataGridDictionary.Rows[rwi].Cells["FullName"].Value = infoElement.Element("FullName").Value;
                    if (infoElement.Element("Type") != null)
                        dataGridDictionary.Rows[rwi].Cells["Type"].Value = infoElement.Element("Type").Value;
                    if (infoElement.Element("INN") != null)
                        dataGridDictionary.Rows[rwi].Cells["INN"].Value = infoElement.Element("INN").Value;
                    if (infoElement.Element("Other") != null)
                        dataGridDictionary.Rows[rwi].Cells["Other"].Value = infoElement.Element("Other").Value;
                    rwi++;
                }
                dataGridDictionary.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(dataGridDictionary_RowSelected);
            }
            dataGridDictionary.Refresh();
        }

        private void dataGridDictionary_RowSelected(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridDictionary.ClearSelection();

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (e.ColumnIndex == -1 && e.RowIndex > -1)
                {
                    dataGridDictionary.Rows[e.RowIndex].Selected = true;
                    ActiveCell = dataGridDictionary[0, e.RowIndex];
                    mgRightClickMenu.Show(Cursor.Position);
                }
            }
        }


        private void btnAddNew_Click(object sender, EventArgs e)
        {
            dataGridDictionary.Rows.Add();
            dataGridDictionary.Refresh();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridDictionary.Rows.Add();
            dataGridDictionary.Refresh();
        }

        private void RemoveContractors_Click(object sender, EventArgs e)
        {
            dataGridDictionary.Rows.RemoveAt(ActiveCell.RowIndex);
        }

        private void mgMenuShowInWindows_Click(object sender, EventArgs e)
        {
            string filePath = Environment.CurrentDirectory + "\\contractors_" + listGTP.Text + ".xml";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found");
                return;
            }

            string argument = "/select, \"" + filePath + "\"";

            System.Diagnostics.Process.Start("explorer.exe", argument);
        }


        private void mgMenuFileSave_Click(object sender, EventArgs e)
        {
            DataSet DictionaryDataSet = new DataSet("ContractorsDictionary");
            DataTable exportTable = new DataTable();

            DictionaryDataSet.Clear();
            exportTable.Clear();

            exportTable.TableName = listGTP.Text;
            DictionaryDataSet.Tables.Add(exportTable);

            //exportTable.Columns.Add("id");
            exportTable.Columns.Add("Agreement");
            exportTable.Columns.Add("DateIntoForce");
            exportTable.Columns.Add("FullName");
            exportTable.Columns.Add("Type");
            exportTable.Columns.Add("INN");
            exportTable.Columns.Add("Other");

            foreach (DataGridViewRow rw in dataGridDictionary.Rows)
            {
                    DataRow row = DictionaryDataSet.Tables[listGTP.Text].NewRow();
                    //row["id"] = rw.HeaderCell.Value.ToString();
                    row["Agreement"] = rw.Cells["Agreement"].Value;
                    row["DateIntoForce"] = rw.Cells["DateIntoForce"].Value;
                    row["FullName"] = rw.Cells["FullName"].Value;
                    row["Type"] = rw.Cells["Type"].Value;
                    row["INN"] = rw.Cells["INN"].Value;
                    row["Other"] = rw.Cells["Other"].Value;

                    DictionaryDataSet.Tables[listGTP.Text].Rows.Add(row);
            }

            string xmlFileName = Environment.CurrentDirectory + "\\contractors_" + listGTP.Text + ".xml";
            try
            {
                DictionaryDataSet.WriteXml(xmlFileName.ToString());
                Console.WriteLine("The file was saved successfully");
            }
            catch
            {
                Console.WriteLine("Failed to save file");
            }
        }

        private void mgMenuFileOpen_Click(object sender, EventArgs e)
        {
            DataSet ImportDataSet = new DataSet();

            dataGridDictionary.DataSource = null;
            DataTable DT = (DataTable)dataGridDictionary.DataSource;
            if (DT != null)
                DT.Clear();

            dataGridDictionary.Rows.Clear();
            dataGridDictionary.Refresh();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.DefaultExt = "*.xml";
            ofd.Filter = "XML File (*.xml*)|*.xml*";
            ofd.Title = "Import file XML";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            string xmlFileName = ofd.FileName;

            XDocument XMLfile = XDocument.Load(xmlFileName);
            ImportDataSet.ReadXml(xmlFileName);

            int rwi = 0;
            foreach (XElement infoElement in XMLfile.Root.Elements(listGTP.Text))
            {
                dataGridDictionary.Rows.Add();
                if (infoElement.Element("Agreement") != null)
                    dataGridDictionary.Rows[rwi].Cells["Agreement"].Value = infoElement.Element("Agreement").Value;
                if (infoElement.Element("DateIntoForce") != null)
                    dataGridDictionary.Rows[rwi].Cells["DateIntoForce"].Value = infoElement.Element("DateIntoForce").Value;
                if (infoElement.Element("FullName") != null)
                    dataGridDictionary.Rows[rwi].Cells["FullName"].Value = infoElement.Element("FullName").Value;
                if (infoElement.Element("Type") != null)
                    dataGridDictionary.Rows[rwi].Cells["Type"].Value = infoElement.Element("Type").Value;
                if (infoElement.Element("INN") != null)
                    dataGridDictionary.Rows[rwi].Cells["INN"].Value = infoElement.Element("INN").Value;
                if (infoElement.Element("Other") != null)
                    dataGridDictionary.Rows[rwi].Cells["Other"].Value = infoElement.Element("Other").Value;
                rwi++;
            }

            dataGridDictionary.Refresh();
        }

        private void dataGridDictionary_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(CheckKey);
            if (dataGridDictionary.CurrentCell.ColumnIndex == 4) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(CheckKey);
                }
            }
        }
        private void CheckKey(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        public class CalendarColumn : DataGridViewColumn
        {
            public CalendarColumn()
                : base(new CalendarCell())
            {
            }

            public override DataGridViewCell CellTemplate
            {
                get
                {
                    return base.CellTemplate;
                }
                set
                {
                    // Ensure that the cell used for the template is a CalendarCell.
                    if (value != null &&
                        !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
                    {
                        throw new InvalidCastException("Must be a CalendarCell");
                    }
                    base.CellTemplate = value;
                }
            }
        }


        public class CalendarCell : DataGridViewTextBoxCell
        {

            public CalendarCell()
                : base()
            {
                // Use the short date format.
                this.Style.Format = "d";
            }

            public override void InitializeEditingControl(int rowIndex, object
                initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
            {
                // Set the value of the editing control to the current cell value.
                base.InitializeEditingControl(rowIndex, initialFormattedValue,
                    dataGridViewCellStyle);
                CalendarEditingControl ctl =
                    DataGridView.EditingControl as CalendarEditingControl;
                // Use the default row value when Value property is null.
                if (this.Value == null)
                {
                    ctl.Value = (DateTime)this.DefaultNewRowValue;
                }
                else
                {
                    ctl.Value = (DateTime)this.Value;
                }
            }

            public override Type EditType
            {
                get
                {
                    // Return the type of the editing control that CalendarCell uses.
                    return typeof(CalendarEditingControl);
                }
            }

            public override Type ValueType
            {
                get
                {
                    // Return the type of the value that CalendarCell contains.

                    return typeof(DateOnly);
                }
            }

            public override object DefaultNewRowValue
            {
                get
                {
                    // Use the current date and time as the default value.
                    return DateTime.Now;
                }
            }
        }

        class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
        {
            DataGridView dataGridView;
            private bool valueChanged = false;
            int rowIndex;

            public CalendarEditingControl()
            {
                this.Format = DateTimePickerFormat.Short;
            }

            // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
            // property.
            public object EditingControlFormattedValue
            {
                get
                {
                    return this.Value.ToShortDateString();
                }
                set
                {
                    if (value is String)
                    {
                        try
                        {
                            // This will throw an exception of the string is 
                            // null, empty, or not in the format of a date.
                            this.Value = DateTime.Parse((String)value);
                        }
                        catch
                        {
                            // In the case of an exception, just use the 
                            // default value so we're not left with a null
                            // value.
                            this.Value = DateTime.Now;
                        }
                    }
                }
            }

            // Implements the 
            // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
            public object GetEditingControlFormattedValue(
                DataGridViewDataErrorContexts context)
            {
                return EditingControlFormattedValue;
            }

            // Implements the 
            // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
            public void ApplyCellStyleToEditingControl(
                DataGridViewCellStyle dataGridViewCellStyle)
            {
                this.Font = dataGridViewCellStyle.Font;
                this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
                this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
            }

            // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
            // property.
            public int EditingControlRowIndex
            {
                get
                {
                    return rowIndex;
                }
                set
                {
                    rowIndex = value;
                }
            }

            // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
            // method.
            public bool EditingControlWantsInputKey(
                Keys key, bool dataGridViewWantsInputKey)
            {
                // Let the DateTimePicker handle the keys listed.
                switch (key & Keys.KeyCode)
                {
                    case Keys.Left:
                    case Keys.Up:
                    case Keys.Down:
                    case Keys.Right:
                    case Keys.Home:
                    case Keys.End:
                    case Keys.PageDown:
                    case Keys.PageUp:
                        return true;
                    default:
                        return !dataGridViewWantsInputKey;
                }
            }

            // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
            // method.
            public void PrepareEditingControlForEdit(bool selectAll)
            {
                // No preparation needs to be done.
            }

            // Implements the IDataGridViewEditingControl
            // .RepositionEditingControlOnValueChange property.
            public bool RepositionEditingControlOnValueChange
            {
                get
                {
                    return false;
                }
            }

            // Implements the IDataGridViewEditingControl
            // .EditingControlDataGridView property.
            public DataGridView EditingControlDataGridView
            {
                get
                {
                    return dataGridView;
                }
                set
                {
                    dataGridView = value;
                }
            }

            // Implements the IDataGridViewEditingControl
            // .EditingControlValueChanged property.
            public bool EditingControlValueChanged
            {
                get
                {
                    return valueChanged;
                }
                set
                {
                    valueChanged = value;
                }
            }

            // Implements the IDataGridViewEditingControl
            // .EditingPanelCursor property.
            public Cursor EditingPanelCursor
            {
                get
                {
                    return base.Cursor;
                }
            }

            protected override void OnValueChanged(EventArgs eventargs)
            {
                // Notify the DataGridView that the contents of the cell
                // have changed.
                valueChanged = true;
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
                base.OnValueChanged(eventargs);
            }
        }

    }
}
