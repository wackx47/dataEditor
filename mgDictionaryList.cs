using dataEditor.Properties;
using MathNet.Numerics.LinearAlgebra.Factorization;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using OfficeOpenXml.DataValidation;
using Org.BouncyCastle.Asn1.X500;
using Org.BouncyCastle.Bcpg.Sig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Xml.Linq;

namespace dataEditor
{
    public partial class mgDatsList : Form
    {
        public static bankDictionary dictBankForm = new bankDictionary();
        public static List<string> banksList = new List<string>();

        MainForm main = (MainForm)Application.OpenForms["MainForm"];
        Settings settingsForm = (Settings)Application.OpenForms["Settings"];

        DataGridViewCell ActiveCell = null;
        public static bool isLoaded;

        public mgDatsList()
        {
            InitializeComponent();
        }

        private void mgDatsEditor_Load(object sender, EventArgs e)
        {
            loadDictionary(isLoaded);
            dictBankForm.loadDictionaryBanks(bankDictionary.isLoadedBanks);

            bankNAME.DataSource = banksList;
            PhoneNumber.Mask = "+7(000)000-00-00;";
        }

        public void loadDictionary(bool fl)
        {
            if (!isLoaded)
            {
                main = StartScreen.universalReaderForm;
                settingsForm = MainForm.SettingsForm;

                main.prepareOptionsGridOthersForm();
                MicrogenerationSettings mgSettings = (MicrogenerationSettings)settingsForm.optionsGrid.SelectedObject;

                DataSet ImportDataSet = new DataSet();

                dataGridDictionaryList.DataSource = null;
                DataTable DT = (DataTable)dataGridDictionaryList.DataSource;
                if (DT != null)
                    DT.Clear();

                dataGridDictionaryList.Rows.Clear();
                dataGridDictionaryList.Refresh();

                if (File.Exists(mgSettings.mgFolderAgreeDict.fullPathAgreeDictionary + "\\contractors_" + dictListGTP.Text + ".xml"))
                {
                    string xmlFileName = mgSettings.mgFolderAgreeDict.fullPathAgreeDictionary + "\\contractors_" + dictListGTP.Text + ".xml";

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
                        if (infoElement.Element("NumCC") != null)
                            dataGridDictionaryList.Rows[rwi].Cells["NumCC"].Value = infoElement.Element("NumCC").Value;
                        rwi++;
                    }

                    dataGridDictionaryList.Refresh();
                    isLoaded = true;
                    Console.WriteLine("DictionaryLoaded, path to Dictionary: " + mgSettings.mgFolderAgreeDict.fullPathAgreeDictionary + "\\contractors_" + dictListGTP.Text + ".xml");
                }
                else
                {
                    Console.WriteLine("Dictionary is not Loaded, path to Dictionary: " + mgSettings.mgFolderAgreeDict.fullPathAgreeDictionary + "\\contractors_" + dictListGTP.Text + ".xml");
                }
            }
        }

        private void mgLocalPhone_Click(object sender, EventArgs e)
        {
            if (ActiveCell.Value != null)
            {
                string resultString = null;
                try
                {
                    Regex regexObj = new Regex(@"[^\d]");
                    resultString = regexObj.Replace(ActiveCell.Value.ToString(), "");
                    if (mgLocalPhone.Checked)
                    {
                        resultString = Int64.Parse(resultString).ToString("+0(000)000-00-00");
                        ActiveCell.Value = resultString + ";";
                    }
                    else
                    {
                        resultString = Int64.Parse(resultString).ToString("+0(0000)00-00-00");
                        ActiveCell.Value = resultString + ";";
                    }
                }
                catch (ArgumentException ex)
                {

                }
            }
        }


        private void dataGridDictionaryList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (e.ColumnIndex == 9 && e.RowIndex >= 0 && dataGridDictionaryList[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    dataGridDictionaryList.ClearSelection();
                    dataGridDictionaryList[e.ColumnIndex, e.RowIndex].Selected = true;
                    ActiveCell = dataGridDictionaryList[e.ColumnIndex, e.RowIndex];
                    mgMenuDelete.Visible = false;
                    mgLocalPhone.Visible = true;
                    char c = ActiveCell.Value.ToString()[6];
                    if (c.ToString() == ")")
                    {
                        mgLocalPhone.Checked = false;
                        mgRightClickMenu.Show(Cursor.Position);
                    }
                    else
                    {
                        mgLocalPhone.Checked = true;
                        mgRightClickMenu.Show(Cursor.Position);
                    }
                }
            }
        }

        private void dataGridDictionaryList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (e.ColumnIndex == -1 && e.RowIndex > -1)
                {
                    dataGridDictionaryList.ClearSelection();
                    dataGridDictionaryList.Rows[e.RowIndex].Selected = true;
                    ActiveCell = dataGridDictionaryList[1, e.RowIndex];
                    mgMenuDelete.Visible = true;
                    mgLocalPhone.Visible = false;
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
            if (dataGridDictionaryList.Columns[dataGridDictionaryList.CurrentCell.ColumnIndex].Name == "INN" | 
            dataGridDictionaryList.Columns[dataGridDictionaryList.CurrentCell.ColumnIndex].Name == "NumCC" |
            dataGridDictionaryList.Columns[dataGridDictionaryList.CurrentCell.ColumnIndex].Name == "PhoneNumber")
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
            exportTable.Columns.Add("NumCC");

            foreach (DataGridViewRow rw in dataGridDictionaryList.Rows)
            {
                DataRow row = DictionaryDataSet.Tables[dictListGTP.Text].NewRow();
                //row["id"] = rw.HeaderCell.Value.ToString();
                row["Agreement"] = rw.Cells["Agreement"].Value;
                row["DateAgreement"] = rw.Cells["DateAgreement"].Value;
                row["FullName"] = rw.Cells["FullName"].Value;
                row["Type"] = rw.Cells["Type"].Value;
                row["INN"] = rw.Cells["INN"].Value;
                row["NumCC"] = rw.Cells["NumCC"].Value;

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

            public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
            {
                // Set the value of the editing control to the current cell value.
                base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
                CalendarEditingControl ctl = DataGridView.EditingControl as CalendarEditingControl;
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

        public class MaskedEditColumn : DataGridViewColumn
        {
            public MaskedEditColumn()
                : base(new MaskedEditCell())
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
                    if ((value != null) && !value.GetType().IsAssignableFrom(typeof(MaskedEditCell)))
                    {
                        throw new InvalidCastException("Must be a MaskedEditCell");
                    }
                    base.CellTemplate = value;
                }
            }
            private string mask;

            public string Mask
            {
                get { return mask; }
                set { mask = value; }
            }
            private Type validatingType;

            public Type ValidatingType
            {
                get { return validatingType; }
                set { validatingType = value; }
            }

            private char promtChar = '_';

            public char PromtChar
            {
                get { return promtChar; }
                set { promtChar = value; }
            }
            private MaskedEditCell MaskedEditCellTemplate
            {
                get { return this.CellTemplate as MaskedEditCell; }
            }
        }

        class MaskedEditCell : DataGridViewTextBoxCell
        {
            public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
            {
                base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
                MaskedEditColumn mec = OwningColumn as MaskedEditColumn;
                MaskedEditControl mectrl = (MaskedEditControl)DataGridView.EditingControl;
                try
                {
                    mectrl.Text = this.Value.ToString();
                }
                catch (Exception)
                {
                    mectrl.Text = string.Empty;
                }
                mectrl.Mask = mec.Mask;
                mectrl.PromptChar = mec.PromtChar;
                mectrl.ValidatingType = mec.ValidatingType;
            }
            public override Type EditType
            {
                get
                {
                    return typeof(MaskedEditControl);
                }
            }
            public override Type ValueType
            {
                get
                {
                    return typeof(string);
                }
            }
            public override object DefaultNewRowValue
            {
                get
                {
                    return string.Empty;
                }
            }
            protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            }
        }

        class MaskedEditControl : MaskedTextBox, IDataGridViewEditingControl
        {
            private DataGridView dataGridViewControl;
            private bool valueIsChanged = false;
            private int rowIndexNum;
            public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
            {
                this.Font = dataGridViewCellStyle.Font;
                this.BackColor = dataGridViewCellStyle.BackColor;
                this.ForeColor = dataGridViewCellStyle.ForeColor;
            }

            public DataGridView EditingControlDataGridView
            {
                get
                {
                    return dataGridViewControl;
                }
                set
                {
                    dataGridViewControl = value;
                }
            }

            public object EditingControlFormattedValue
            {
                get
                {
                    return this.Text;
                }
                set
                {
                    this.Text = value.ToString();
                }
            }

            public int EditingControlRowIndex
            {
                get
                {
                    return rowIndexNum;
                }
                set
                {
                    rowIndexNum = value;
                }
            }

            public bool EditingControlValueChanged
            {
                get
                {
                    return valueIsChanged;
                }
                set
                {
                    valueIsChanged = value;
                }
            }

            public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
            {
                return true;
            }

            public Cursor EditingPanelCursor
            {
                get { return base.Cursor; }
            }

            public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
            {
                return this.Text;
            }

            public void PrepareEditingControlForEdit(bool selectAll)
            {
                //throw new NotImplementedException();
            }

            public bool RepositionEditingControlOnValueChange
            {
                get { return false; }
            }
            protected override void OnTextChanged(EventArgs e)
            {
                valueIsChanged = true;
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
                base.OnTextChanged(e);
            }
        }

        private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            Image SomeImage = ((System.Drawing.Image)(resources.GetObject("toolBtnDictionaryEditor.Image")));

            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = SomeImage.Width;
                var h = SomeImage.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w)/2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h)/1;

                e.Graphics.DrawImage(SomeImage, new Rectangle(x, y-3, w, h));
                e.Handled = true;
            }
        }

        private void dictBtnBankData_Click(object sender, EventArgs e)
        {
            dictBankForm.Show();
        }

        private void mgDatsList_FormClosed(object sender, FormClosedEventArgs e)
        {
            dictBankForm.Dispose();
        }

        private void dictBtnImportFromExcel_Click(object sender, EventArgs e)
        {
            main = StartScreen.universalReaderForm;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.DefaultExt = "*.xls;*.xlsx";
            ofd.Filter = "Microsoft Excel (*.xls*)|*.xls*";
            ofd.Title = "Выберите документ Excel";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string xlFileName = ofd.FileName;
            
            DataTable dataExtraction = new DataTable();
            main.commonImportEXCL(this, new EventArgs(), dataExtraction, xlFileName);

            //Console.WriteLine(xlFileName);
            //foreach (DataRow row in dataExtraction.Rows)
            //{
            //    foreach (DataColumn column in dataExtraction.Columns)
            //    {
            //        Console.Write("\t{0}", row[column]);
            //    }
            //    Console.WriteLine();
            //}

            dataGridDictionaryList.Rows.Clear();

            dataExtraction.Rows[0].Delete();
            foreach (DataRow rows in dataExtraction.Rows)
            {
                if (rows[1] != DBNull.Value)
                {
                    dataGridDictionaryList.Rows.Add("", rows[1], DateOnly.FromDateTime(Convert.ToDateTime(rows[2])), rows[3],
                        ConvertToBoolRU(rows[4].ToString()), rows[5].ToString(), rows[6], rows[7], rows[8], PhoneNumberParse(rows[9].ToString()), 
                        rows[10].ToString().Split(";").First(), ComboBoxParse(rows[11].ToString()), ComboBoxParse(rows[12].ToString()), rows[13]);
                }
            }
            
        }

        private static string ComboBoxParse(string input)
        {
            if (input != "")
            {
                switch (input[0].ToString())
                {
                    case "1":
                        return "1ЦК";
                    case "2":
                        return "2 зоны";
                    case "3":
                        return "3 зоны";
                    case "д":
                        return "Действует";
                    case "р":
                        return "Расторгнут";
                    case "э":
                        return "";
                    default:
                        return "";
                }
            }
            else
            {
                return "";
            }
        }

        private static string PhoneNumberParse(string input)
        {
            Regex regexObj = new Regex(@"[^\d]");
            string result = regexObj.Replace(input.ToString().Split(";").First(), "");

            if (result[0].ToString() == "8")
            {
                result = Int64.Parse(result.Substring(1)).ToString("+7(000)000-00-00");
                return result + ";";
            }
            else if (result[0].ToString() == "7" )
            {
                result = Int64.Parse(result.Substring(1)).ToString("+7(000)000-00-00");
                return result + ";";
            }
            else
            {
                result = Int64.Parse(result).ToString("+7(000)000-00-00");
                return result + ";";
            }
        }

        private static bool ConvertToBoolRU(string input)
        {
            if (input.Equals("да", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (input.Equals("нет", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
