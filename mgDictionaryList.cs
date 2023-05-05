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
    public partial class mgDatsList : Form
    {
        DataGridViewCell ActiveCell = null;



        public mgDatsList()
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

            dataGridDictionaryList.DataSource = null;
            DataTable DT = (DataTable)dataGridDictionaryList.DataSource;
            if (DT != null)
                DT.Clear();

            dataGridDictionaryList.Rows.Clear();
            dataGridDictionaryList.Refresh();

            if (File.Exists(Environment.CurrentDirectory + "\\contractors_" + dictListGTP.Text +".xml"))
            {
                string xmlFileName = Environment.CurrentDirectory + "\\contractors_" + dictListGTP.Text +".xml";

                XDocument XMLfile = XDocument.Load(xmlFileName);
                ImportDataSet.ReadXml(xmlFileName);

                int rwi = 0;
                foreach (XElement infoElement in XMLfile.Root.Elements(dictListGTP.Text))
                {
                    dataGridDictionaryList.Rows.Add();
                    if (infoElement.Element("Agreement") != null)
                        dataGridDictionaryList.Rows[rwi].Cells["Agreement"].Value = infoElement.Element("Agreement").Value;
                    if (infoElement.Element("DateAgreement") != null)
                        dataGridDictionaryList.Rows[rwi].Cells["Agreement"].Value = infoElement.Element("Agreement").Value;
                    if (infoElement.Element("FullName") != null)
                        dataGridDictionaryList.Rows[rwi].Cells["FullName"].Value = infoElement.Element("FullName").Value;
                    if (infoElement.Element("Type") != null)
                        dataGridDictionaryList.Rows[rwi].Cells["Type"].Value = infoElement.Element("Type").Value;
                    if (infoElement.Element("INN") != null)
                        dataGridDictionaryList.Rows[rwi].Cells["INN"].Value = infoElement.Element("INN").Value;
                    if (infoElement.Element("Other") != null)
                        dataGridDictionaryList.Rows[rwi].Cells["Other"].Value = infoElement.Element("Other").Value;
                    rwi++;
                }
                dataGridDictionaryList.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(dataGridDictionary_RowSelected);
            }
            dataGridDictionaryList.Refresh();
        }

        private void dataGridDictionary_RowSelected(object sender, DataGridViewCellMouseEventArgs e)
        {
            //dataGridDictionaryList.ClearSelection();

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (e.ColumnIndex == -1 && e.RowIndex > -1)
                {
                    dataGridDictionaryList.Rows[e.RowIndex].Selected = true;
                    ActiveCell = dataGridDictionaryList[0, e.RowIndex];
                    mgRightClickMenu.Show(Cursor.Position);
                }
            }
        }

        private void RemoveContractors_Click(object sender, EventArgs e)
        {
            dataGridDictionaryList.Rows.RemoveAt(ActiveCell.RowIndex);
        }


        private void dataGridDictionary_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(CheckKey);
            if (dataGridDictionaryList.CurrentCell.ColumnIndex == 4) //Desired Column
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
                    //ctl.Value = (DateTime)this.Value;
                }
            }

            public override Type EditType
            {
                get
                {
                    return typeof(CalendarEditingControl);
                }
            }

            public override Type ValueType
            {
                get
                {
                    return typeof(DateOnly);
                }
            }

            public override object DefaultNewRowValue
            {
                get
                {
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
                            this.Value = DateTime.Parse((String)value);
                        }
                        catch
                        {
                            this.Value = DateTime.Now;
                        }
                    }
                }
            }


            public object GetEditingControlFormattedValue(
                DataGridViewDataErrorContexts context)
            {
                return EditingControlFormattedValue;
            }


            public void ApplyCellStyleToEditingControl(
                DataGridViewCellStyle dataGridViewCellStyle)
            {
                this.Font = dataGridViewCellStyle.Font;
                this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
                this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
            }


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

            public bool EditingControlWantsInputKey(
                Keys key, bool dataGridViewWantsInputKey)
            {
                
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


            public void PrepareEditingControlForEdit(bool selectAll)
            {
                // No preparation needs to be done.
            }

            public bool RepositionEditingControlOnValueChange
            {
                get
                {
                    return false;
                }
            }

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

            public Cursor EditingPanelCursor
            {
                get
                {
                    return base.Cursor;
                }
            }

            protected override void OnValueChanged(EventArgs eventargs)
            {
                valueChanged = true;
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
                base.OnValueChanged(eventargs);
            }
        }

        private void dictBtnSave_Click(object sender, EventArgs e)
        {
            DataSet DictionaryDataSet = new DataSet("ContractorsDictionary");
            DataTable exportTable = new DataTable();

            DictionaryDataSet.Clear();
            exportTable.Clear();

            exportTable.TableName = dictListGTP.Text;
            DictionaryDataSet.Tables.Add(exportTable);

            //exportTable.Columns.Add("id");
            exportTable.Columns.Add("Agreement");
            exportTable.Columns.Add("DateAgreement");
            exportTable.Columns.Add("FullName");
            exportTable.Columns.Add("Type");
            exportTable.Columns.Add("INN");
            exportTable.Columns.Add("Other");

            foreach (DataGridViewRow rw in dataGridDictionaryList.Rows)
            {
                DataRow row = DictionaryDataSet.Tables[dictListGTP.Text].NewRow();
                //row["id"] = rw.HeaderCell.Value.ToString();
                row["Agreement"] = rw.Cells["Agreement"].Value;
                row["DateAgreement"] = rw.Cells["DateAgreement"].Value;
                row["FullName"] = rw.Cells["FullName"].Value;
                row["Type"] = rw.Cells["Type"].Value;
                row["INN"] = rw.Cells["INN"].Value;
                row["Other"] = rw.Cells["Other"].Value;

                DictionaryDataSet.Tables[dictListGTP.Text].Rows.Add(row);
            }

            string xmlFileName = Environment.CurrentDirectory + "\\contractors_" + dictListGTP.Text + ".xml";
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

        private void dictBtnShowFolder_Click(object sender, EventArgs e)
        {
            string filePath = Environment.CurrentDirectory + "\\contractors_" + dictListGTP.Text + ".xml";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found");
                return;
            }

            string argument = "/select, \"" + filePath + "\"";

            System.Diagnostics.Process.Start("explorer.exe", argument);
        }

        private void dictBtnAddElm_Click(object sender, EventArgs e)
        {
            dataGridDictionaryList.Rows.Add();
            dataGridDictionaryList.Refresh();
        }

        private void dictBtnDelElm_Click(object sender, EventArgs e)
        {
            ActiveCell = dataGridDictionaryList[0, dataGridDictionaryList.CurrentCell.RowIndex];
            dataGridDictionaryList.Rows.RemoveAt(ActiveCell.RowIndex);
        }

        private void mgDatsList_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Application.OpenForms["mgDatsList"].Hide();
        }

        private void dictBtnOpen_ButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.DefaultExt = "*.xml";
            ofd.Filter = "XML File (*.xml*)|*.xml*";
            ofd.Title = "Import file XML";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            string xmlFileName = ofd.FileName;

            DataSet ImportDataSet = new DataSet();

            dataGridDictionaryList.DataSource = null;
            DataTable DT = (DataTable)dataGridDictionaryList.DataSource;
            if (DT != null)
                DT.Clear();

            dataGridDictionaryList.Rows.Clear();
            dataGridDictionaryList.Refresh();

            XDocument XMLfile = XDocument.Load(xmlFileName);
            ImportDataSet.ReadXml(xmlFileName);

            int rwi = 0;
            foreach (XElement infoElement in XMLfile.Root.Elements(dictListGTP.Text))
            {
                dataGridDictionaryList.Rows.Add();
                if (infoElement.Element("Agreement") != null)
                    dataGridDictionaryList.Rows[rwi].Cells["Agreement"].Value = infoElement.Element("Agreement").Value;
                if (infoElement.Element("DateAgreement") != null)
                    dataGridDictionaryList.Rows[rwi].Cells["DateAgreement"].Value = infoElement.Element("DateAgreement").Value;
                if (infoElement.Element("FullName") != null)
                    dataGridDictionaryList.Rows[rwi].Cells["FullName"].Value = infoElement.Element("FullName").Value;
                if (infoElement.Element("Type") != null)
                    dataGridDictionaryList.Rows[rwi].Cells["Type"].Value = infoElement.Element("Type").Value;
                if (infoElement.Element("INN") != null)
                    dataGridDictionaryList.Rows[rwi].Cells["INN"].Value = infoElement.Element("INN").Value;
                if (infoElement.Element("Other") != null)
                    dataGridDictionaryList.Rows[rwi].Cells["Other"].Value = infoElement.Element("Other").Value;
                rwi++;
            }

            dataGridDictionaryList.Refresh();
        }
    }
}
