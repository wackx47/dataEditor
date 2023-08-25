using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Data.OleDb;
using Excel=Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics.Tracing;
using System.Xml.Linq;
using System;
using System.Windows.Forms;
using System.Reflection;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.DirectoryServices.ActiveDirectory;
using System.Data.Common;
using System.Reflection.Metadata;
using System.Drawing.Imaging;
using System.Linq;
using Microsoft.Win32;
using universalReader;
using System.Text.RegularExpressions;
using OfficeOpenXml;
using System.Linq.Expressions;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.Streaming;
using System.Diagnostics.Metrics;
using NPOI.XSSF.Streaming.Values;
using OfficeOpenXml.Table;
using NPOI.SS.Formula;
using OfficeOpenXml.ConditionalFormatting;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
using System.Globalization;
using System.Net;
using OfficeOpenXml.Utils;
using dataEditor.Properties;
using NPOI.POIFS.Crypt.Dsig;
using NPOI.OpenXmlFormats.Spreadsheet;
using Microsoft.VisualBasic.Devices;
using NPOI.SS.Formula.PTG;
using System.Resources;
using System.Drawing;
using static NPOI.HSSF.Util.HSSFColor;
using System.Security.Policy;
using static System.Windows.Forms.LinkLabel;
using System.Drawing.Drawing2D;
using System.IO.Packaging;
using System.Net.Security;
using IDataObject_Com = System.Runtime.InteropServices.ComTypes.IDataObject;

namespace dataEditor
{
    public partial class MainForm : Form
    {
        Version OsMinVersion = new Version(10, 0, 15063, 0);

        iniFile INI = new iniFile("config.ini");
        Form TreeView = new Form();
        TextBox TextExtractColumns = new TextBox();
        DataGridView TreeColViewer = new DataGridView();
        DataSet UniversalDataSet = new DataSet("UniversalFileReader");
        DataSet HoursDataSet = new DataSet("HoursStore");
        DataSet IntegralsDataSet = new DataSet("IntegralsStore");
        Button ConfirmCols = new Button();

        DataGridViewButtonCell tableRemove;

        public static mgDatsList DictionaryForm = new mgDatsList();
        public static Settings SettingsForm = new Settings();
        

        int cntShows = 0;
        int HFR = 0;
        int prvCntHedRw = 2;
        int RowsCnt = 0;
        int ColsCnt = 0;
        int FirstUsedRow = 1;
        int FirstUsedColumn = 1;
        bool allowVoid = false;
        string xmlFileName = "";
        string ExlFileName = null;
        string memSQLlist = null;
        string defaultSQL = null;

        public int[,] _main2dayZone_00 = new int[0, 6];
        public int[,] _main2nightZone_00 = new int[0, 6];
        public int[,] _main3peakZone_00 = new int[0, 6];
        public int[,] _main3semiPeakZone_00 = new int[0, 6];
        public int[,] _main3nightZone_00 = new int[0, 6];

        public int[,] _main2dayZone_01 = new int[0, 6];
        public int[,] _main2nightZone_01 = new int[0, 6];
        public int[,] _main3peakZone_01 = new int[0, 6];
        public int[,] _main3semiPeakZone_01 = new int[0, 6];
        public int[,] _main3nightZone_01 = new int[0, 6];

        CheckBox headerCheckBox = new CheckBox();
        DataGridViewCell ActiveCell = null;

        XElement strID = null;
        XElement strName = null;
        XElement extraColumns = null;
        XElement headsRow = null;
        XElement firstData = null;
        XElement columnsCount = null;

        int[] objID = new int[] { };
        string[] objName = new string[] { };
        List<int> tempPropVal = new List<int>() { };
        List<Color> tempPropColors = new List<Color>() { };
        List<String> SQLdata = new List<string>() { };
        List<object> urlLinksData = new List<object>() { };
        String[] SQLdbTemp = { };
        String[] SQLdbTempB = { };
        String[] SQLdbTempC = { };

        DataTable dt_db_shema = new DataTable();
        commonSettings cmnSettings = new commonSettings();
        ExcelReaderSettings exclSettings = new ExcelReaderSettings();
        MicrogenerationSettings mgSettings = new MicrogenerationSettings();
        urProperty urProperty = new urProperty();


        Color fntCl = Color.Black;
        Color fntClDat = Color.Black;
        Color fntTreeCl = Color.Black;
        Color fntClStaticDat = Color.Black;

        BackgroundWorker bgWorker;
        ProgressDialog progressDlg;

        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();


        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = false)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FreeConsole();

        public class StatusGridViewEditMode : DataGridView
        {
            protected override bool ProcessDialogKey(Keys keyData)
            {
                if (keyData == Keys.Enter)
                    return base.ProcessDialogKey(Keys.Tab);
                else
                    return base.ProcessDialogKey(keyData);
            }
            protected override bool ProcessDataGridViewKey(KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    return this.ProcessRightKey(e.KeyData);
                }
                return base.ProcessDataGridViewKey(e);
            }
        }

        public class DoubleBufferedDataGridView : DataGridView
        {
            protected override bool DoubleBuffered { get => true; }
        }

        public MainForm()
        {
            InitializeComponent();
            AllocConsole();
            Magician.DisappearConsole();
            ReadINI();

            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            urOptionsGrid.SelectedObject = urProperty;
            splitContainer_rightProps.Panel1Collapsed = true;
            Console.WriteLine("Soft powered by 47 5'9 (ver. " + Application.ProductVersion + ") //.build for GitHub");
            ImportList.CheckProviders();
            StartPage();
            addAvailableProviders(this, new EventArgs());
            TypeDescriptor.GetProperties(urOptionsGrid.SelectedObject)["ExtraColCnt"].SetReadOnlyAttribute(true);
            cmnSettings.ImportMode = ImportList.AvailableMode[0];

            mgSettings.mgCodeName.propGTPname = "KUBANESK";
            cmnSettings.GlobalInfoStandart = "ru-RU";
            DictionaryForm.dictListGTP.Items.AddRange(ImportList.KnownGTPnames.ToArray());
            DictionaryForm.dictListGTP.Text = mgSettings.mgCodeName.propGTPname;

            getNodesName();

            appInfo.Text = "ver." + Application.ProductVersion + " (" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + ")";
        }

        private void getNodesName()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "dataEditor.NodesName.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                try
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string? line;
                        int i = 0;
                        while ((line = reader.ReadLine()) != null)
                        {
                            datsTreeView.Nodes[i].Text = line;
                            i++;
                        }
                    }
                }
                catch(Exception ex) 
                { 
                    Console.WriteLine(ex.ToString());
                }
        }


        public void switchOptionsGridSettingsGroup()
        {
            switch (SettingsForm.SettingsTreeView.SelectedNode.Name)
            {
                case "setCommon":
                    SettingsForm.optionsGrid.SelectedObject = cmnSettings;
                    break;
                case "setExcelReader":
                    SettingsForm.optionsGrid.SelectedObject = exclSettings;
                    break;
                case "setMicrogeneration":
                    SettingsForm.optionsGrid.SelectedObject = mgSettings;
                    break;
            }
        }

        public void prepareOptionsGridOthersForm()
        {
            SettingsForm.optionsGrid.SelectedObject = mgSettings;
        }

        public static void ScaleControlElements(DataGridView ScaleSource, SizeF ScaleFactor)
        {
            foreach (DataGridViewColumn Column in ScaleSource.Columns)
            {
                Column.Width = (int)Math.Round(Column.Width * ScaleFactor.Width);
            }
        }

        private void addAvailableProviders(object sender, EventArgs e)
        {
            foreach (var i in ImportList.AvailableMode)
            {
                ToolStripItem urItem = new ToolStripMenuItem();
                ToolStripItem mgItem = new ToolStripMenuItem();
                urItem.Text = i.ToString();
                urItem.Name = "urBtn" + i.Split().First();
                urItem.Click += new EventHandler(SwitcherMode_Click);
                urBtnImportFile.DropDownItems.Add(urItem);
                mgItem.Text = i.ToString();
                mgItem.Name = "mgBtn" + i.Split().First();
                mgItem.Click += new EventHandler(SwitcherMode_Click);
                mgBtnImportFile.DropDownItems.Add(mgItem);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SettingsNewForm();

            foreach (string s in exclSettings.sqlArray)
                memSQLlist += s + ";";

            if (defaultSQL != null | defaultSQL != "")
            {
                string[] loadSQLarray = defaultSQL.Split(';');
                loadSQLarray = loadSQLarray.SkipLast(1).ToArray();
                exclSettings.sqlArray = loadSQLarray;
            }
            AutoFillList();
            CheckRegLib();

            tempPropColors.Add(exclSettings.ColorHeads);
            tempPropColors.Add(exclSettings.ColorDataRows);
            tempPropColors.Add(exclSettings.ColorStaticDat);
            tempPropColors.Add(exclSettings.SecondColorHeads);

            if (cmnSettings.ShowHelpPropetryGrid == true)
            {
                SettingsForm.optionsGrid.HelpVisible = !SettingsForm.optionsGrid.HelpVisible;
                helpToolStripMenuItem.Checked = !helpToolStripMenuItem.Checked;
            }

            if (cmnSettings.ShowConsoleOnStartUp == true)
            {
                Magician.AppearConsole();
                DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
                showConsoleToolStripMenuItem.Checked = true;
            }

            if (ImportList.ProvidersList.Count != 0)
                cmnSettings.OleDBImportMode.VersionOleDB = ImportList.ProvidersList[0];
        }

        private void statusGridView_CellCmbxValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in statusGridView.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    row.Cells[2].Value = "ok";
                    row.DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                else
                {
                    row.Cells[2].Value = "";
                    row.DefaultCellStyle.BackColor = Color.Empty;
                    statusGridView.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                }
            }
        }

        private void statusGridView_MouseClick(Object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hittestinfo = statusGridView.HitTest(e.X, e.Y);
                if (hittestinfo != null && hittestinfo.Type == DataGridViewHitTestType.Cell)
                {
                    if (statusGridView.Rows[hittestinfo.RowIndex].Cells[2].Value == "ok")
                        {
                            statusGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 91, 201, 91);
                        }
                    else
                        {
                            statusGridView.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                        }
                }
        }

        private void statusGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (statusGridView.Rows[statusGridView.CurrentCellAddress.Y].Cells[statusGridView.CurrentCellAddress.X].Value != null)
            {
                statusGridView.DefaultCellStyle.SelectionBackColor = Color.PaleGreen;
            }
            else
            {
                statusGridView.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            }
        }

        private void statusGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            int mxRw;
            if (dataViewer.DataSource != null && statusGridView.Rows[2].Cells[1].Value != null && statusGridView.CurrentCellAddress.X == 1 && statusGridView.CurrentCellAddress.Y == 2)
            {
                foreach (DataGridViewRow rws in dataViewer.Rows)
                {
                    if (rws.DefaultCellStyle.BackColor == exclSettings.ColorHeads | rws.DefaultCellStyle.BackColor == exclSettings.ColorHeads | rws.DefaultCellStyle.BackColor == exclSettings.ColorDataRows | rws.DefaultCellStyle.BackColor == exclSettings.ColorDataRows)
                    {
                        rws.DefaultCellStyle.BackColor = Color.Empty;
                        rws.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                if (Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value) > 0)
                {
                    HFR = Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value)- (FirstUsedRow-1);

                    int ls = (Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value) + urProperty.cntHeadsRows);
                    if (ls >= FirstUsedRow + RowsCnt)
                        mxRw = ls - 1;
                    else
                        mxRw = ls;

                    statusGridView.Rows[3].Cells[1].Value = null;
                    statusGridView.Rows[3].Cells[1] = new NumericUpDownDataGrid.NumericUpDownCell(mxRw, FirstUsedRow - 1 + RowsCnt);

                    dataViewer.Rows[Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value) - (FirstUsedRow)].DefaultCellStyle.BackColor = exclSettings.ColorHeads;
                    dataViewer.Rows[Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value) - (FirstUsedRow)].DefaultCellStyle.ForeColor = fntCl;

                    if (urProperty.DRow == true)
                    {
                        for (int i = 1; i < Convert.ToInt32(urProperty.cntHeadsRows); i++)
                        {
                            if (Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value) - (FirstUsedRow) + i < dataViewer.RowCount)
                            {
                                dataViewer.Rows[Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value) - (FirstUsedRow) + i].DefaultCellStyle.BackColor = exclSettings.ColorHeads;
                                dataViewer.Rows[Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value) - (FirstUsedRow) + i].DefaultCellStyle.ForeColor = fntCl;
                            }
                        }
                    }
                }
                TreeFormDestroyer();
                dataViewer.ClearSelection();
                SettingsForm.optionsGrid.Refresh();
                urBtnConvert2Tree.Enabled = true;
            }

            if (dataViewer.DataSource != null && statusGridView.Rows[3].Cells[1].Value != null && statusGridView.CurrentCellAddress.X == 1 && statusGridView.CurrentCellAddress.Y == 3 || statusGridView.CurrentCellAddress.Y == 4)
            {
                foreach (DataGridViewRow row in dataViewer.Rows)
                {
                    if (row.DefaultCellStyle.BackColor == exclSettings.ColorDataRows | row.DefaultCellStyle.BackColor == exclSettings.ColorDataRows)
                    {
                        row.DefaultCellStyle.BackColor = Color.Empty;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }

                if (Convert.ToInt32(statusGridView.Rows[3].Cells[1].Value) > 0)
                {
                    dataViewer.Rows[Convert.ToInt32(statusGridView.Rows[3].Cells[1].Value)-(FirstUsedRow)].DefaultCellStyle.BackColor = exclSettings.ColorDataRows;
                    dataViewer.Rows[Convert.ToInt32(statusGridView.Rows[3].Cells[1].Value)-(FirstUsedRow)].DefaultCellStyle.ForeColor = fntClDat;

                    for (int i = (Convert.ToInt32(statusGridView.Rows[3].Cells[1].Value)-(FirstUsedRow) + Convert.ToInt32(statusGridView.Rows[4].Cells[1].Value) + 1); i < RowsCnt-(FirstUsedRow); i += Convert.ToInt32(statusGridView.Rows[4].Cells[1].Value) + 1)
                    {
                        if (dataViewer.Rows[i].Cells[1].Value != DBNull.Value)
                        {
                            dataViewer.Rows[i].DefaultCellStyle.BackColor = exclSettings.ColorDataRows;
                            dataViewer.Rows[i].DefaultCellStyle.ForeColor = fntClDat;
                        }
                    }
                }
                dataViewer.ClearSelection();
                SettingsForm.optionsGrid.Refresh();
            }
        }

        private void AutoFillList()
        {
            SQLdata.Clear();
            memSQLlist = null;
            string[] subs = exclSettings.sqlArray;
            SQLdbTemp = subs;
            SQLdbTempB = subs;

            foreach (var sub in subs)
            {
                if (sub != "")
                {
                    memSQLlist += sub + ";";
                    SQLdata.Add(sub);
                }
            }
        }

        private void ReadINI()
        {
            if (File.Exists(Environment.CurrentDirectory + "\\config.ini"))
            {

                if (INI.KeyExists("SQLcollumns", "SQL"))
                {
                    defaultSQL = INI.ReadINI("SQL", "SQLcollumns");
                }
                if (INI.KeyExists("ColorHeaders", "Visuals"))
                {
                    exclSettings.ColorHeads = Color.FromName(INI.ReadINI("Visuals", "ColorHeaders"));
                }
                if (INI.KeyExists("ColorHeaders(ListView)", "Visuals"))
                {
                    exclSettings.SecondColorHeads = Color.FromName(INI.ReadINI("Visuals", "ColorHeaders(ListView)"));
                }
                if (INI.KeyExists("ColorDataRows", "Visuals"))
                {
                    exclSettings.ColorDataRows = Color.FromName(INI.ReadINI("Visuals", "ColorDataRows"));
                }
                if (INI.KeyExists("ColorStaticCell", "Visuals"))
                {
                    exclSettings.ColorStaticDat = Color.FromName(INI.ReadINI("Visuals", "ColorStaticCell"));
                }
                if (INI.KeyExists("ForceCloseAllExcel", "Other"))
                {
                    cmnSettings.ForceCloseExl = bool.Parse(INI.ReadINI("Other", "ForceCloseAllExcel"));
                }
                if (INI.KeyExists("ShowConsoleOnStartUp", "Other"))
                {
                    cmnSettings.ShowConsoleOnStartUp = bool.Parse(INI.ReadINI("Other", "ShowConsoleOnStartUp"));
                }
                if (INI.KeyExists("ShowHelpPropetryGrid", "Other"))
                {
                    cmnSettings.ShowHelpPropetryGrid = bool.Parse(INI.ReadINI("Other", "ShowHelpPropetryGrid"));
                }
                if (INI.KeyExists("UseOLEDBprovider", "Other"))
                {
                    //PropGrid.OleDBImportMode.useOleDBMode = bool.Parse(INI.ReadINI("Other", "UseOLEDBprovider"));
                }

                if (defaultSQL == null | defaultSQL == "")
                    defaultSQL = "Name;Dat8;Type;Is_fact;OAO;GTP_Kod;GTP;Nomer_Dog;Kontragent;K_GTP_Kod;K_GTP;Dog_V;V;S;S_NDS";

                autoFontColor();
                SettingsForm.optionsGrid.Refresh();
            }
            else
            {
                //Console.WriteLine("Config.ini file not found, all settings was loaded with default values.");
                defaultSQL = "Name;Dat8;Type;Is_fact;OAO;GTP_Kod;GTP;Nomer_Dog;Kontragent;K_GTP_Kod;K_GTP;Dog_V;V;S;S_NDS";
            }
        }

        private void ConfigUpdater_handle()
        {
            INI.Write("SQL", "SQLcollumns", memSQLlist);
            //INI.Write("Other", "UseOLEDBprovider", PropGrid.OleDBImportMode.useOleDBMode.ToString());
        }

        public void ConfigUpdater()
        {
            GridItemCollection categories;
            if (SettingsForm.optionsGrid.SelectedGridItem.GridItemType == GridItemType.Category)
            {
                categories = SettingsForm.optionsGrid.SelectedGridItem.Parent.GridItems;
            }
            else
            {
                categories = SettingsForm.optionsGrid.SelectedGridItem.Parent.Parent.GridItems;
            }

            foreach (var category in categories)
            {
                if (((GridItem)category).GridItemType == GridItemType.Category)
                {
                    foreach (GridItem gi in ((GridItem)category).GridItems)
                    {
                        if (gi.Label.ToString() != "AvailableXML" && gi.Label.ToString() != "ReportsList" && gi.Parent.Label.ToString() != "App" && gi.Parent.Label.ToString() != "Visuals" && gi.Label.ToString() != "SQLcollumns" && gi.Label.ToString() != "OLEDBprovider" && gi.Label.ToString() != "ImportMode")
                        {
                            INI.Write(gi.Parent.Label.ToString(), gi.Label.ToString(), gi.Value.ToString());

                        }
                        if(gi.Parent.Label.ToString() == "Visuals")
                        {
                            var str1 = gi.Value.ToString();
                            string[] strs = str1.Split(new[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                            INI.Write(gi.Parent.Label.ToString(), gi.Label.ToString(), strs[1].ToString());
                        }
                    }
                }
            }
            ConfigUpdater_handle();
        }

        private void CloseAllExcel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This process forcibly terminates all Excel program processes.\nYou are sure?\n", "dataEditor closer", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (Process clsProcess in Process.GetProcesses())
                {
                    if (clsProcess.ProcessName.Equals("EXCEL"))
                    {
                        clsProcess.Kill();
                        //break;
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void KillSpecificExcelFileProcess(string excelFileName)
        {
            var processes = from p in Process.GetProcessesByName("EXCEL")
                            select p;

            foreach (var process in processes)
            {
                if (process.MainWindowTitle == "Microsoft Excel - " + excelFileName)
                    process.Kill();
            }
        }

        private void DataViewer_CheckClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataViewer.Rows[e.RowIndex];
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                HFR = e.RowIndex + 1;
                statusGridView.Rows[2].Cells[1].Value = Convert.ToInt32(dataViewer.Rows[e.RowIndex].HeaderCell.Value.ToString().Split(' ').Last());
                dataViewer.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.SkyBlue;
                RightClick_HeadsRow.Enabled = true;
                if (urProperty.DRow == true)
                {
                    dataViewer.Rows[e.RowIndex + 1].DefaultCellStyle.BackColor = Color.PowderBlue;
                    dataViewer.Rows[e.RowIndex + 1].Cells[0].Value = true;
                    RightClick_HeadsRow.Enabled = true;
                }
            }
            SettingsForm.optionsGrid.Refresh();
        }

        private void DataViewer_ColumnsSelected(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataViewer.ClearSelection();

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (e.ColumnIndex > -1 && e.RowIndex == -1)
                {
                    //dataViewer.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
                    //dataViewer.Columns[e.ColumnIndex].Selected = true;
                    ActiveCell = dataViewer[e.ColumnIndex, 0];
                    ColumnContext.Show(Cursor.Position);
                }
            }
        }

        private void StripMenuHeaderColumnSelect_Click(object sender, EventArgs e)
        {
            Console.WriteLine(dataViewer.Columns[ActiveCell.ColumnIndex].HeaderText.ToString());
            dataViewer.ClearSelection();
            statusGridView.ClearSelection();
            SettingsForm.optionsGrid.Refresh();
        }


        private void DataViewer_RowSelected(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataViewer.ClearSelection();

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (e.ColumnIndex == -1 && e.RowIndex > -1)
                {
                    dataViewer.Rows[e.RowIndex].Selected = true;
                    ActiveCell = dataViewer[0, e.RowIndex];
                    RowContext.Show(Cursor.Position);
                }
            }
        }

        private void DataViewer_SwitchCheckRow(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                int cllc = 0;
                foreach (DataGridViewRow row in dataViewer.Rows)
                {
                    row.Cells[0].Value = false;
                }

                foreach (DataGridViewRow row in dataViewer.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (Convert.ToBoolean(row.Cells[0].EditedFormattedValue) == true)
                    {
                        cllc++;
                    }
                    if (Convert.ToBoolean(row.Cells[0].EditedFormattedValue) == false)
                    {
                        chk.FlatStyle = FlatStyle.Flat;
                        chk.Style.ForeColor = Color.DarkGray;
                        chk.ReadOnly = true;
                    }
                }

                foreach (DataGridViewRow row in dataViewer.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (cllc == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Empty;
                        chk.FlatStyle = FlatStyle.Standard;
                        chk.Style.ForeColor = Color.White;
                        chk.ReadOnly = false;
                    }
                }


                if (cllc != 0)
                {
                    RightClick_HeadsRow.Enabled = true;
                    urBtnConvert2Tree.Enabled = true;
                }
                else
                {
                    urBtnConvert2Tree.Enabled = false;
                    RightClick_HeadsRow.Enabled = false;
                }
            }

        }

        private void dataViewer_MouseClick(Object sender, MouseEventArgs e)
        {
            dataViewer.ClearSelection();

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                System.Windows.Forms.DataGridView.HitTestInfo hittestinfo = dataViewer.HitTest(e.X, e.Y);
                if (hittestinfo != null && hittestinfo.Type == DataGridViewHitTestType.Cell)
                {
                    ActiveCell = dataViewer.Rows[hittestinfo.RowIndex].Cells[hittestinfo.ColumnIndex];
                    ActiveCell.Selected = true;
                    (CellContext.Items[0] as ToolStripMenuItem).DropDownItems.Clear();
                    foreach (string s in SQLdbTempB)
                    {
                        (CellContext.Items[0] as ToolStripMenuItem).DropDownItems.Add(s, null, cellStripSubMenu_Click);
                    }
                    if (dataViewer.Rows[ActiveCell.RowIndex].Cells[ActiveCell.ColumnIndex].Value != DBNull.Value)
                        CellContext.Show(dataViewer, new Point(e.X, e.Y));
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                System.Windows.Forms.DataGridView.HitTestInfo hittestinfo = dataViewer.HitTest(e.X, e.Y);
                if (hittestinfo != null && hittestinfo.Type == DataGridViewHitTestType.Cell)
                {
                    ActiveCell = dataViewer.Rows[hittestinfo.RowIndex].Cells[hittestinfo.ColumnIndex];
                    ActiveCell.Selected = true;
                    CellViewer.Text = ActiveCell.Value.ToString();
                    int count = CellViewer.GetLineFromCharIndex(int.MaxValue) + 1;

                    
                    for (int i = splitContainer_dataGrids.SplitterDistance; i < 18 * (count); i+=5)
                        splitContainer_dataGrids.SplitterDistance = i;

                    for (int i = splitContainer_dataGrids.SplitterDistance; i > 18 * (count); i-=5)
                        splitContainer_dataGrids.SplitterDistance = i;
                }
            }
        }

        private void cellStripSubMenu_Click(object sender, EventArgs e)
        {
            if(dataViewer.Rows[ActiveCell.RowIndex].Cells[ActiveCell.ColumnIndex].Style.BackColor == exclSettings.ColorStaticDat)
            {
                var rg = new Regex(@"\[(.*?)\]");
                var result = rg.Match(dataViewer.Rows[ActiveCell.RowIndex].Cells[ActiveCell.ColumnIndex].Value.ToString()).Groups[1].Value;
                dataViewer.Rows[ActiveCell.RowIndex].Cells[ActiveCell.ColumnIndex].Value = dataViewer.Rows[ActiveCell.RowIndex].Cells[ActiveCell.ColumnIndex].Value.ToString().Split('[').First();
                SQLdbTemp = SQLdbTemp.Append(result.ToString()).ToArray();
                SQLdbTempC = Array.FindAll(SQLdbTempC, i => i != result.ToString()).ToArray();

            }
            if (dataViewer.Rows[ActiveCell.RowIndex].Cells[ActiveCell.ColumnIndex].Value != DBNull.Value) 
            {
                dataViewer.ClearSelection();

                var clickedMenuItem = sender as ToolStripMenuItem;
                var menuText = clickedMenuItem.Text;
                

                dataViewer.Rows[ActiveCell.RowIndex].Cells[ActiveCell.ColumnIndex].Value += "[" + clickedMenuItem.Text + "]";
                dataViewer.Rows[ActiveCell.RowIndex].Cells[ActiveCell.ColumnIndex].Style.BackColor = exclSettings.ColorStaticDat;
                dataViewer.Rows[ActiveCell.RowIndex].Cells[ActiveCell.ColumnIndex].Style.ForeColor = fntClStaticDat;

                SQLdbTempB = Array.FindAll(SQLdbTemp, i => i != clickedMenuItem.Text.ToString()).ToArray();
                SQLdbTempC = SQLdbTempC.Append(clickedMenuItem.Text.ToString()).ToArray();
                SQLdbTemp = SQLdbTempB;


                Console.WriteLine("Selected static Value - " + "columns: " + (ActiveCell.ColumnIndex + 1).ToString() + " // attach to SQL: " + menuText.ToString());
            }
            else
            {
                MessageBox.Show("This cell is empty and cannot using for extract values.");
            }
        }

        private void OnProcessExitTreeView(object sender, EventArgs e)
        {
            TreeColViewer_CellCmbxValueChanged(this.TreeColViewer, new DataGridViewCellEventArgs(this.TreeColViewer.CurrentCell.ColumnIndex, this.TreeColViewer.CurrentRow.Index));
            TreeView.Hide();
        }

        private void TreeColViewer_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridViewColumn col = TreeColViewer.Columns[TreeColViewer.CurrentCell.ColumnIndex];
            if (col is DataGridViewComboBoxColumn)
            {
                SendKeys.Send("{LEFT}");
            }
        }

        private void TreeColViewer_CellCmbxValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (allowVoid == true) {
                string[] SQLdataTemp = exclSettings.sqlArray;


                foreach (var delItem in SQLdbTempC)
                {
                    SQLdataTemp = Array.FindAll(SQLdataTemp, i => i != delItem.ToString()).ToArray();
                }

                foreach (DataGridViewRow rwcb in TreeColViewer.Rows)
                {
                    if (rwcb.Cells[2] is DataGridViewComboBoxCell && rwcb.Cells[2].Value != null)
                    {
                        SQLdataTemp = Array.FindAll(SQLdataTemp, i => i != rwcb.Cells[2].Value.ToString()).ToArray();
                    }
                }

                SQLdbTemp = SQLdataTemp;


                foreach (DataGridViewRow rwcb in TreeColViewer.Rows)
                {
                    if (rwcb.Cells[2] is DataGridViewComboBoxCell)
                    {
                        if (rwcb.Cells[2].Value == null && rwcb.Cells[0].Value != "" && Convert.ToBoolean(rwcb.Cells[0].EditedFormattedValue) == true)
                        {
                            DataGridViewComboBoxCell cellSQL = new DataGridViewComboBoxCell();
                            cellSQL.DataSource = SQLdbTemp;
                            rwcb.Cells[2] = new DataGridViewComboBoxCell();
                            rwcb.Cells[2] = cellSQL;
                        }
                        if (rwcb.Cells[2].Value != null && rwcb.Cells[0].Value != "" && Convert.ToBoolean(rwcb.Cells[0].EditedFormattedValue) == true)
                        {
                            string[] SQLdbTempB = { };
                            SQLdbTempB = SQLdbTemp.Append(rwcb.Cells[2].Value.ToString()).ToArray();
                            DataGridViewComboBoxCell cellSQL = (DataGridViewComboBoxCell)rwcb.Cells[2];
                            cellSQL.DataSource = SQLdbTempB;
                        }
                    }
                }

                SQLdbTempB = SQLdbTemp;
            }
        }

        private void ConfirmCols_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("usedColumns");
            DataTable dte = new DataTable("commonSettings");


            if (statusGridView.Rows[5].Cells[1].Value == null)
            {
                UniversalDataSet.Tables.Add(dt);
                UniversalDataSet.Tables.Add(dte);
            }

            dt.Clear();
            dt.Columns.Add("id");
            dt.Columns.Add(new DataColumn("name", typeof(string)));
            dt.Columns.Add(new DataColumn("link2SQL", typeof(string)));

            dte.Clear();
            dte.Columns.Add("extraColumns");
            dte.Columns.Add("headsRow");
            dte.Columns.Add("firstData");
            dte.Columns.Add("columnsCount");
            dte.Columns.Add("columnsCheck");



            int TagCounts = 0;

            statusGridView.Rows[5].Cells[1].Value = "";

            foreach (DataGridViewRow r in TreeColViewer.Rows)
            {
                if (r.Cells[0].Value != "" && Convert.ToBoolean(r.Cells[0].EditedFormattedValue))
                {
                    DataRow row = UniversalDataSet.Tables["usedColumns"].NewRow();
                    row["id"] = r.HeaderCell.Value.ToString().Split('F').Last();
                    row["name"] = r.Cells[1].Value;
                    row["link2SQL"] = r.Cells[2].Value;
                    UniversalDataSet.Tables["usedColumns"].Rows.Add(row);
                    statusGridView.Rows[5].Cells[1].Value += r.HeaderCell.Value.ToString().Split('F').Last() + ";";
                    TagCounts++;
                }
            }

            DataRow rwe = dte.NewRow();
            rwe["extraColumns"] = urProperty.ExtraColCnt;
            rwe["headsRow"] = statusGridView.Rows[2].Cells[1].Value;
            rwe["firstData"] = statusGridView.Rows[3].Cells[1].Value;
            rwe["columnsCount"] = statusGridView.Rows[1].Cells[1].Value;
            rwe["columnsCheck"] = statusGridView.Rows[6].Cells[1].Value;
            dte.Rows.Add(rwe);

            TreeView.Hide();
            SettingsForm.optionsGrid.Refresh();
            statusGridView.ClearSelection();

            urBtnSaveXML.Enabled = true;
        }

        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {

            TreeColViewer.EndEdit();
            TextExtractColumns.Text = "";

            if (headerCheckBox.Checked)
                ConfirmCols.Enabled = true;
            else
                ConfirmCols.Enabled = false;

            foreach (DataGridViewRow row in TreeColViewer.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells[0] as DataGridViewCheckBoxCell);
                if (row.Cells[0].Value != "")
                    checkBox.Value = headerCheckBox.Checked;

                if (row.Cells[0].Value != "" && Convert.ToBoolean(row.Cells[0].EditedFormattedValue))
                {
                    TextExtractColumns.Text += row.HeaderCell.Value + ";";
                    row.DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Empty;
                }
            }

        }

        private void ColumnsViewer_CheckClick(object sender, DataGridViewCellEventArgs e)
        {
            allowVoid = false;

            TextExtractColumns.Text = "";

            int rowsChkCounts = 0;

            foreach (DataGridViewRow rw in TreeColViewer.Rows)
            {
                if (rw.Cells[2].Value != null && rw.Cells[0].Value != "" && Convert.ToBoolean(rw.Cells[0].EditedFormattedValue) == true)
                {
                    TextExtractColumns.Text += rw.HeaderCell.Value + ";";
                    rw.DefaultCellStyle.BackColor = exclSettings.SecondColorHeads;
                    rw.DefaultCellStyle.ForeColor = fntTreeCl;
                    rw.Cells[2].ReadOnly = false;
                    rowsChkCounts++;
                }
                if (rw.Cells[2].Value == null && rw.Cells[0].Value != "" && Convert.ToBoolean(rw.Cells[0].EditedFormattedValue) == true)
                {
                    DataGridViewComboBoxCell cellSQL = new DataGridViewComboBoxCell();
                    cellSQL.DataSource = SQLdbTemp;
                    TextExtractColumns.Text += rw.HeaderCell.Value + ";";
                    rw.DefaultCellStyle.BackColor = exclSettings.SecondColorHeads;
                    rw.DefaultCellStyle.ForeColor = fntTreeCl;
                    rw.Cells[2] = new DataGridViewComboBoxCell();
                    rw.Cells[2] = cellSQL;
                    rw.Cells[2].ReadOnly = false;
                    rowsChkCounts++;
                }
                if (rw.Cells[0].Value != "" && Convert.ToBoolean(rw.Cells[0].EditedFormattedValue) == false)
                {
                    DataGridViewComboBoxCell cellSQL = new DataGridViewComboBoxCell();
                    cellSQL.DataSource = SQLdata;
                    rw.Cells[2].Value = "";
                    rw.DefaultCellStyle.BackColor = Color.Empty;
                    rw.DefaultCellStyle.ForeColor = Color.Black;
                    rw.Cells[2] = new DataGridViewComboBoxCell();
                    rw.Cells[2] = cellSQL;
                    rw.Cells[2].ReadOnly = true;
                }
            }

            foreach (DataGridViewRow rws in TreeColViewer.Rows)
            {
                if (rws.Cells[0].Value != "" && Convert.ToBoolean(rws.Cells[0].EditedFormattedValue) == true)
                {
                    int rwtrue = rws.Index;
                    for (int n = rwtrue + 1; n < TreeColViewer.Rows.Count; n++)
                    {
                        if (TreeColViewer.Rows[n].HeaderCell.Value == "")
                        {
                            TreeColViewer.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(255, exclSettings.SecondColorHeads.R / 2, exclSettings.SecondColorHeads.G / 2, exclSettings.SecondColorHeads.B / 2);
                            if (exclSettings.SecondColorHeads.R / 2 < 120 | exclSettings.SecondColorHeads.G / 2 < 120 | exclSettings.SecondColorHeads.B / 2 < 120)
                                TreeColViewer.Rows[n].DefaultCellStyle.ForeColor = Color.White;
                        }
                        else
                            break;
                    }
                }
                if (rws.Cells[0].Value != "" && Convert.ToBoolean(rws.Cells[0].EditedFormattedValue) == false)
                {
                    int rwfalse = rws.Index;
                    for (int n = rwfalse + 1; n < TreeColViewer.Rows.Count; n++)
                    {
                        if (TreeColViewer.Rows[n].HeaderCell.Value == "")
                        {
                            TreeColViewer.Rows[n].DefaultCellStyle.BackColor = Color.Empty;
                            TreeColViewer.Rows[n].DefaultCellStyle.ForeColor = Color.Black;
                        }
                        else
                            break;
                    }
                }
                foreach (DataGridViewRow rw in TreeColViewer.Rows)
                {
                    if (rowsChkCounts >= SQLdata.Count + urProperty.ExtraColCnt && rw.Cells[0].Value != "" && Convert.ToBoolean(rw.Cells[0].EditedFormattedValue) == false)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)rw.Cells[0];
                        chk.FlatStyle = FlatStyle.Flat;
                        chk.Style.ForeColor = Color.DarkGray;
                        chk.ReadOnly = true;
                    }
                    if (rowsChkCounts < SQLdata.Count + urProperty.ExtraColCnt && rw.Cells[0].Value != "")
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)rw.Cells[0];
                        chk.FlatStyle = FlatStyle.Standard;
                        chk.Style.ForeColor = Color.White;
                        chk.ReadOnly = false;
                    }
                }

            }
            if (rowsChkCounts > 0)
                ConfirmCols.Enabled = true;
            else
                ConfirmCols.Enabled = false;

            allowVoid = true;
        }

        private void ShowConsole_Click(object sender, EventArgs e)
        {
            if (showConsoleToolStripMenuItem.Checked == false)
            {
                Magician.AppearConsole();
                DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
                showConsoleToolStripMenuItem.Checked = true;
            }
                else 
            {
                showConsoleToolStripMenuItem.Checked = false;
                Magician.DisappearConsole();
            }
        }

        private void LoadXMLforMG()
        {
            if (File.Exists(Environment.CurrentDirectory + "\\contractors_" + mgSettings.mgCodeName.propGTPname + ".xml"))
            {
                string xmlFileName = Environment.CurrentDirectory + "\\contractors_" + mgSettings.mgCodeName.propGTPname + ".xml";

                DataSet ExportsDats = new DataSet();
                ExportsDats.ReadXml(xmlFileName);

                DataTable mgDictionaryTable = ExportsDats.Tables[0];
            }
            else
            {
                Console.WriteLine("Failed to upload counterparty data");
            }
        }

        private static void PrintValues(DataTable table, string label)
        {
            Console.WriteLine(label);
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.Write("\t{0}", row[column]);
                }
                Console.WriteLine();
            }
        }

        private void SwitcherMode_Click(object sender, EventArgs e)
        {
            ToolStripItem clickedItem = sender as ToolStripItem;
            switch (clickedItem.Text)
            {
                case "Excel Interop":
                    cmnSettings.ImportMode = "Excel Interop";
                    SettingsForm.optionsGrid.Refresh();
                    break;

                case "NPOI":
                    cmnSettings.ImportMode = "NPOI";
                    SettingsForm.optionsGrid.Refresh();
                    break;

                case "EPPlus":
                    cmnSettings.ImportMode = "EPPlus";
                    SettingsForm.optionsGrid.Refresh();
                    break;

                case "OleDB":
                    cmnSettings.ImportMode = "OleDB";
                    SettingsForm.optionsGrid.Refresh();
                    break;
            }
            switch (SectionsControl.SelectedIndex)
            {
                case 0:
                    urImportEXCL(this, new EventArgs());
                    break;
                case 1:
                    mgImportEXCL(this, new EventArgs());
                    break;
            }
        }

        public void commonImportEXCL(object sender, EventArgs e, DataTable dataExtraction, string xlFileName)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + "***Starting void: ImportExcelFile***" + "\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Open new Excel file: " + ExlFileName + " by " + cmnSettings.ImportMode.ToString());

            switch (cmnSettings.ImportMode)
            {
                case "EPPlus":
                    try
                    {
                        using (var stream = File.OpenRead(xlFileName))
                        {
                            EPPlusModeImport(dataExtraction, xlFileName);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("The process cannot access the file because it is being used by another process, or file is not supported.");
                    }
                    break;

                case "NPOI":
                    try
                    {
                        using (var stream = File.OpenRead(xlFileName))
                        {
                            ISheet wSheet;
                            int selectedIndexSht = 0;
                            if (Path.GetExtension(xlFileName) == ".xlsx")
                            {
                                XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
                                XSSFFormulaEvaluator xsseva = new XSSFFormulaEvaluator(xssWorkbook);

                                if (cmnSettings.showListExcelSheets)
                                {
                                    using (ItemSelector extractedListForm = new ItemSelector())
                                    {
                                        for (int i =0;  i <xssWorkbook.NumberOfSheets; i++)
                                        {
                                            extractedListForm.sheetsList.Items.Add(xssWorkbook.GetSheetName(i));
                                        }
                                        if (extractedListForm.sheetsList.Items.Count > 1)
                                        {
                                            if (extractedListForm.ShowDialog() == DialogResult.OK)
                                            {
                                                selectedIndexSht = extractedListForm.selectedIndexSheet;
                                            }
                                            else
                                            {
                                                return;
                                            }
                                        }
                                    }
                                }

                                wSheet = xssWorkbook.GetSheetAt(selectedIndexSht);
                                NPOIModeImport(dataExtraction, xlFileName, wSheet, xsseva, null);
                            }
                            else
                            {
                                HSSFWorkbook hssWorkbook = new HSSFWorkbook(stream);
                                HSSFFormulaEvaluator hsseva = new HSSFFormulaEvaluator(hssWorkbook);

                                if (cmnSettings.showListExcelSheets)
                                {
                                    using (ItemSelector extractedListForm = new ItemSelector())
                                    {
                                        for (int i = 0; i < hssWorkbook.NumberOfSheets; i++)
                                        {
                                            extractedListForm.sheetsList.Items.Add(hssWorkbook.GetSheetName(i));
                                        }
                                        if (extractedListForm.sheetsList.Items.Count > 1)
                                        {
                                            if (extractedListForm.ShowDialog() == DialogResult.OK)
                                            {
                                                selectedIndexSht = extractedListForm.selectedIndexSheet;
                                            }
                                            else
                                            {
                                                return;
                                            }
                                        }
                                    }
                                }

                                wSheet = hssWorkbook.GetSheetAt(selectedIndexSht);
                                NPOIModeImport(dataExtraction, xlFileName, wSheet, null, hsseva);
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("The process cannot access the file because it is being used by another process");
                    }
                    break;

                case "Excel Interop":
                    IteropModeImport(dataExtraction, xlFileName);
                    break;

                case "OleDB":
                    if (Path.GetExtension(xlFileName) == ".xlsx" && cmnSettings.OleDBImportMode.VersionOleDB == "Microsoft.Jet.OLEDB.4.0")
                    {
                        Console.WriteLine("Microsoft.Jet.OLEDB.4.0 not supported this file extension");

                    }
                    OLEDBModeImport(xlFileName, dataExtraction);
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + "----------Completed----------" + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void mgImportEXCL(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.DefaultExt = "*.xls;*.xlsx";
            ofd.Filter = "Microsoft Excel (*.xls*)|*.xls*";
            ofd.Title = "¬ыберите документ Excel";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string xlFileName = ofd.FileName;
            ExlFileName = Path.GetFileName(xlFileName);

            DataTable dataExtraction = new DataTable();
            commonImportEXCL(this, new EventArgs(), dataExtraction, xlFileName);
            HoursFile_processing(dataExtraction);
            IntegralsFile_processing(dataExtraction);
            workWithButtonsIntoFlowPanel();
        }

        private static int withoutZeroNumCC(string searchValue)
        {
            int foundRow = -1;
            foreach (DataGridViewRow rowsDict in DictionaryForm.dataGridDictionaryList.Rows)
            {
                string value = null;
                try
                {
                    value = rowsDict.Cells["NumCC"].Value.ToString();
                }
                catch
                {
                    value = "";
                }

                foreach (char c in value)
                {
                    if (c.ToString() != "0")
                    {
                        break;
                    }
                    else
                    {
                        value = value.Substring(1);
                    }
                }

                if (value == searchValue)
                {
                    foundRow = rowsDict.Index;
                    return foundRow;
                    break;
                }
            }
            return foundRow;
        }

        public static int SearchDGV(DataGridView dgv, string SearchValue, string ColName)
        {
            int Result = -1;
            foreach (DataGridViewRow Row in dgv.Rows)
            {
                string value = null;
                try
                {
                    value = Row.Cells[ColName].Value.ToString();
                }
                catch
                {
                    value = "";
                }
                if (value.Equals(SearchValue))
                    Result= Row.Index;
            }
            return Result;
        }

        private void HoursFile_processing(DataTable dataExtraction)
        {
            DictionaryForm.loadDictionary(mgDatsList.isLoaded);

            int unkn = 0;
            foreach (DataColumn extractCols in dataExtraction.Columns)
            {
                if (dataExtraction.Rows[7][extractCols].ToString() == "A+, к¬т")
                {
                    Regex regexObj = new Regex(@"[^\d]");
                    string resultString = regexObj.Replace(dataExtraction.Rows[4][extractCols].ToString(), "");

                    if (resultString == null | resultString == "")
                    {
                        unkn++;
                        resultString = "unknown"+ unkn;
                    }

                    int foundRow = SearchDGV(DictionaryForm.dataGridDictionaryList, resultString, "NumCC");
                    if (foundRow != -1)
                    {
                        foreach (DataGridViewCell dictEqualsCell in DictionaryForm.dataGridDictionaryList.Rows[foundRow].Cells)
                        {
                            //if(dictEqualsCell.Value != null)
                            //Console.Write(dictEqualsCell.OwningColumn.Name + ": " + dictEqualsCell.Value + ";   ");
                        }
                        DataTable newTable = new DataTable("hrs_" + DictionaryForm.dataGridDictionaryList.Rows[foundRow].Cells["Agreement"].Value.ToString().Split(" от ").First());
                        newTable.TableName = expectedTableName(newTable.TableName, "hrs");
                        DataTable headerTable = new DataTable(newTable.TableName + "_Header");
                        
                        PrepareHeaderTable(headerTable);

                        headerTable.Rows[0]["Values"] = DictionaryForm.dataGridDictionaryList.Rows[foundRow].Cells["Agreement"].Value.ToString();
                        headerTable.Rows[1]["Values"] = DictionaryForm.dataGridDictionaryList.Rows[foundRow].Cells["FullName"].Value.ToString();
                        headerTable.Rows[2]["Values"] = dataExtraction.Rows[0][extractCols].ToString();
                        headerTable.Rows[3]["Values"] = resultString;

                        DataColumn Column1 = new DataColumn("date", Type.GetType("System.DateOnly"));
                        DataColumn Column2 = new DataColumn("time", Type.GetType("System.TimeOnly"));
                        DataColumn Column3 = new DataColumn("consumption", Type.GetType("System.Decimal"));
                        DataColumn Column4 = new DataColumn("generation", Type.GetType("System.Decimal"));

                        newTable.Clear();
                        newTable.Columns.Add(Column1);
                        newTable.Columns.Add(Column2);
                        newTable.Columns.Add(Column3);
                        newTable.Columns.Add(Column4);

                        int kTC = Convert.ToInt32(dataExtraction.Rows[5][extractCols].ToString().Split("/").First());
                        int kTV = Convert.ToInt32(dataExtraction.Rows[5][extractCols].ToString().Split("/").Last());

                        headerTable.Rows[4]["Values"] = dataExtraction.Rows[5][extractCols].ToString();

                        decimal ConSumm = 0;
                        decimal GenSumm = 0;

                        int i = dataExtraction.Rows.IndexOf(dataExtraction.Rows[8]);
                        while (i < dataExtraction.Rows.Count && IsDateOnly(dataExtraction.Rows[i][0].ToString()))
                        {
                            DataRow newTableRow = newTable.NewRow();

                            DateOnly.TryParse(dataExtraction.Rows[i][0].ToString(), out DateOnly date);
                            TimeOnly.TryParse(dataExtraction.Rows[i][1].ToString(), out TimeOnly time);
                            newTableRow["date"] = date;
                            newTableRow["time"] = time;

                            if (IsNumeric(dataExtraction.Rows[i][extractCols].ToString()) && IsNumeric(dataExtraction.Rows[i][dataExtraction.Columns.IndexOf(extractCols) + 1].ToString()))
                            {
                                try
                                {
                                    newTableRow["consumption"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][extractCols].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                    newTableRow["generation"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][dataExtraction.Columns.IndexOf(extractCols) + 1].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));

                                    ConSumm += (decimal.Parse(Convert.ToString(dataExtraction.Rows[i][extractCols].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)) * kTC * kTV);
                                    GenSumm += (decimal.Parse(Convert.ToString(dataExtraction.Rows[i][dataExtraction.Columns.IndexOf(extractCols) + 1].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)) * kTC * kTV);
                                }
                                catch
                                {
                                    Console.WriteLine("wrong input data: ROW:" + i + "  COL: " + dataExtraction.Columns.IndexOf(extractCols) + "  data: " + dataExtraction.Rows[i][extractCols].ToString());
                                }
                            }
                            else
                            {
                                try
                                {
                                    newTableRow["consumption"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][extractCols].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                }
                                catch
                                {
                                    newTableRow["consumption"] = 0;
                                }
                                try
                                {
                                    newTableRow["generation"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][dataExtraction.Columns.IndexOf(extractCols) + 1].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                }
                                catch
                                {
                                    newTableRow["generation"] = 0;
                                }
                            }
                            newTable.Rows.Add(newTableRow);
                            i++;
                        }

                        HoursDataSet.Tables.Add(newTable);
                        HoursDataSet.Tables.Add(headerTable);

                        Button newButton = new Button();
                        createNewButtonOnTable(newButton, newTable.TableName);
                        mgFlowPanelResult.Controls.Add(newButton);
                    }
                    else
                    {
                        int foundRow2 = withoutZeroNumCC(resultString);
                        if(foundRow2 == -1)
                        {
                            string tempBtnName = resultString;
                            foreach (char c in tempBtnName)
                            {
                                if (c.ToString() != "0")
                                {
                                    break;
                                }
                                else
                                {
                                    tempBtnName = tempBtnName.Substring(1);
                                }
                            }
                            foundRow2 = withoutZeroNumCC(tempBtnName);
                        }
                        if (foundRow2 != -1)
                        {
                            DataTable newTable = new DataTable("hrs_" + DictionaryForm.dataGridDictionaryList.Rows[foundRow2].Cells["Agreement"].Value.ToString().Split(" от ").First());
                            newTable.TableName = expectedTableName(newTable.TableName, "hrs");
                            DataTable headerTable = new DataTable(newTable.TableName + "_Header");
                            
                            PrepareHeaderTable(headerTable);

                            headerTable.Rows[0]["Values"] = DictionaryForm.dataGridDictionaryList.Rows[foundRow2].Cells["Agreement"].Value.ToString();
                            headerTable.Rows[1]["Values"] = DictionaryForm.dataGridDictionaryList.Rows[foundRow2].Cells["FullName"].Value.ToString();
                            headerTable.Rows[2]["Values"] = dataExtraction.Rows[0][extractCols].ToString();
                            headerTable.Rows[3]["Values"] = resultString;

                            DataColumn Column1 = new DataColumn("date", Type.GetType("System.DateOnly"));
                            DataColumn Column2 = new DataColumn("time", Type.GetType("System.TimeOnly"));
                            DataColumn Column3 = new DataColumn("consumption", Type.GetType("System.Decimal"));
                            DataColumn Column4 = new DataColumn("generation", Type.GetType("System.Decimal"));

                            newTable.Clear();
                            newTable.Columns.Add(Column1);
                            newTable.Columns.Add(Column2);
                            newTable.Columns.Add(Column3);
                            newTable.Columns.Add(Column4);

                            int kTC = Convert.ToInt32(dataExtraction.Rows[5][extractCols].ToString().Split("/").First());
                            int kTV = Convert.ToInt32(dataExtraction.Rows[5][extractCols].ToString().Split("/").Last());

                            headerTable.Rows[4]["Values"] = dataExtraction.Rows[5][extractCols].ToString();

                            decimal ConSumm = 0;
                            decimal GenSumm = 0;

                            int i = dataExtraction.Rows.IndexOf(dataExtraction.Rows[8]);
                            while (i < dataExtraction.Rows.Count && IsDateOnly(dataExtraction.Rows[i][0].ToString()))
                            {
                                DataRow newTableRow = newTable.NewRow();

                                DateOnly.TryParse(dataExtraction.Rows[i][0].ToString(), out DateOnly date);
                                TimeOnly.TryParse(dataExtraction.Rows[i][1].ToString(), out TimeOnly time);
                                newTableRow["date"] = date;
                                newTableRow["time"] = time;

                                if (IsNumeric(dataExtraction.Rows[i][extractCols].ToString()) && IsNumeric(dataExtraction.Rows[i][dataExtraction.Columns.IndexOf(extractCols) + 1].ToString()))
                                {
                                    try
                                    {
                                        newTableRow["consumption"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][extractCols].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                        newTableRow["generation"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][dataExtraction.Columns.IndexOf(extractCols) + 1].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));

                                        ConSumm += (decimal.Parse(Convert.ToString(dataExtraction.Rows[i][extractCols].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)) * kTC * kTV);
                                        GenSumm += (decimal.Parse(Convert.ToString(dataExtraction.Rows[i][dataExtraction.Columns.IndexOf(extractCols) + 1].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)) * kTC * kTV);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("wrong input data: ROW:" + i + "  COL: " + dataExtraction.Columns.IndexOf(extractCols) + "  data: " + dataExtraction.Rows[i][extractCols].ToString());
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        newTableRow["consumption"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][extractCols].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                    }
                                    catch
                                    {
                                        newTableRow["consumption"] = 0;
                                    }
                                    try
                                    {
                                        newTableRow["generation"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][dataExtraction.Columns.IndexOf(extractCols) + 1].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                    }
                                    catch
                                    {
                                        newTableRow["generation"] = 0;
                                    }
                                }
                                newTable.Rows.Add(newTableRow);
                                i++;
                            }

                            HoursDataSet.Tables.Add(newTable);
                            HoursDataSet.Tables.Add(headerTable);

                            Button newButton = new Button();
                            createNewButtonOnTable(newButton, newTable.TableName);
                            mgFlowPanelResult.Controls.Add(newButton);
                        }
                        else
                        {
                            DataTable newTable = new DataTable("hrs_" + resultString);
                            newTable.TableName = expectedTableName(newTable.TableName, "hrs");
                            DataTable headerTable = new DataTable(newTable.TableName + "_Header");

                            PrepareHeaderTable(headerTable);

                            headerTable.Rows[2]["Values"] = dataExtraction.Rows[0][extractCols].ToString();
                            headerTable.Rows[3]["Values"] = resultString;

                            DataColumn Column1 = new DataColumn("date", Type.GetType("System.DateOnly"));
                            DataColumn Column2 = new DataColumn("time", Type.GetType("System.TimeOnly"));
                            DataColumn Column3 = new DataColumn("consumption", Type.GetType("System.Decimal"));
                            DataColumn Column4 = new DataColumn("generation", Type.GetType("System.Decimal"));

                            newTable.Clear();
                            newTable.Columns.Add(Column1);
                            newTable.Columns.Add(Column2);
                            newTable.Columns.Add(Column3);
                            newTable.Columns.Add(Column4);

                            int kTC = Convert.ToInt32(dataExtraction.Rows[5][extractCols].ToString().Split("/").First());
                            int kTV = Convert.ToInt32(dataExtraction.Rows[5][extractCols].ToString().Split("/").Last());

                            headerTable.Rows[4]["Values"] = dataExtraction.Rows[5][extractCols].ToString();

                            decimal ConSumm = 0;
                            decimal GenSumm = 0;

                            int i = dataExtraction.Rows.IndexOf(dataExtraction.Rows[8]);
                            while (i < dataExtraction.Rows.Count && IsDateOnly(dataExtraction.Rows[i][0].ToString()))
                            {
                                DataRow newTableRow = newTable.NewRow();
                                DateOnly.TryParse(dataExtraction.Rows[i][0].ToString(), out DateOnly date);
                                TimeOnly.TryParse(dataExtraction.Rows[i][1].ToString(), out TimeOnly time);
                                newTableRow["date"] = date;
                                newTableRow["time"] = time;

                                if (IsNumeric(dataExtraction.Rows[i][extractCols].ToString()) && IsNumeric(dataExtraction.Rows[i][dataExtraction.Columns.IndexOf(extractCols) + 1].ToString()))
                                {
                                    try
                                    {
                                        newTableRow["consumption"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][extractCols].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                        newTableRow["generation"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][dataExtraction.Columns.IndexOf(extractCols) + 1].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));

                                        ConSumm += (decimal.Parse(Convert.ToString(dataExtraction.Rows[i][extractCols].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)) * kTC * kTV);
                                        GenSumm += (decimal.Parse(Convert.ToString(dataExtraction.Rows[i][dataExtraction.Columns.IndexOf(extractCols) + 1].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)) * kTC * kTV);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("wrong input data: ROW:" + i + "  COL: " + dataExtraction.Columns.IndexOf(extractCols) + "  data: " + dataExtraction.Rows[i][extractCols].ToString());
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        newTableRow["consumption"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][extractCols].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                    }
                                    catch
                                    {
                                        newTableRow["consumption"] = 0;
                                    }
                                    try
                                    {
                                        newTableRow["generation"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][dataExtraction.Columns.IndexOf(extractCols) + 1].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                    }
                                    catch
                                    {
                                        newTableRow["generation"] = 0;
                                    }
                                }
                                newTable.Rows.Add(newTableRow);
                                i++;
                            }
                            HoursDataSet.Tables.Add(newTable);
                            HoursDataSet.Tables.Add(headerTable);

                            Button newButton = new Button();
                            createNewButtonOnTable(newButton, newTable.TableName);
                            mgFlowPanelResult.Controls.Add(newButton);
                        }
                    }
                }
            }
        }

        private void IntegralsFile_processing(DataTable dataExtraction)
        {
            int number;

            DictionaryForm.loadDictionary(mgDatsList.isLoaded);
            int unkn = 0;
            foreach (DataRow extractRows in dataExtraction.Rows)
            {
                bool result = Int32.TryParse(extractRows[0].ToString(), out number);
                if (extractRows[0] != DBNull.Value && result)
                {
                    string resultString = null;
                    try
                    {
                        Regex regexObj = new Regex(@"[^\d]");
                        resultString = regexObj.Replace(extractRows[3].ToString().Split(",").Last(), "");

                        if (resultString == null | resultString == "")
                        {
                            unkn++;
                            resultString = "unknown_" + unkn;
                        }

                        int foundRow = SearchDGV(DictionaryForm.dataGridDictionaryList, resultString, "NumCC");
                        if (foundRow != -1)
                        {
                            int i = dataExtraction.Rows.IndexOf(extractRows) + 1;
                            DataTable newTable = new DataTable("intg_"+DictionaryForm.dataGridDictionaryList.Rows[foundRow].Cells["Agreement"].Value.ToString().Split(" от ").First());
                            newTable.TableName = expectedTableName(newTable.TableName, "intg");
                            DataTable headerTable = new DataTable(newTable.TableName + "_Header");

                            prepareNewIntegralTables(headerTable, newTable);

                            int kTC = Convert.ToInt32(extractRows[4].ToString());
                            int kTV = Convert.ToInt32(extractRows[5].ToString());

                            headerTable.Rows[0]["Values"] = DictionaryForm.dataGridDictionaryList.Rows[foundRow].Cells["Agreement"].Value.ToString();
                            if(DictionaryForm.dataGridDictionaryList.Rows[foundRow].Cells["FullName"].Value.ToString() == extractRows[2].ToString().Split(",").First())
                                headerTable.Rows[1]["Values"] = DictionaryForm.dataGridDictionaryList.Rows[foundRow].Cells["FullName"].Value.ToString();
                            headerTable.Rows[2]["Values"] = extractRows[1].ToString();
                            headerTable.Rows[3]["Values"] = resultString;
                            headerTable.Rows[4]["Values"] = kTC + "/" + kTV;

                            if (extractRows[7].ToString().Split(" ").Last() != "к¬јр*ч")
                            {
                                DataRow newTableFirstRow = newTable.NewRow();
                                newTableFirstRow["measure"] = extractRows[7].ToString();
                                newTableFirstRow["zone"] = extractRows[8].ToString();
                                newTableFirstRow["initial"] = decimal.Parse(Convert.ToString(extractRows[9].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                newTableFirstRow["final"] = decimal.Parse(Convert.ToString(extractRows[10].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                if (decimal.Parse(Convert.ToString(extractRows[9].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)) < decimal.Parse(Convert.ToString(extractRows[10].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)))
                                {
                                    newTableFirstRow["consumption"] = (decimal.Parse(Convert.ToString(extractRows[10].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)) - decimal.Parse(Convert.ToString(extractRows[9].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)))*kTC*kTV;
                                }
                                newTable.Rows.Add(newTableFirstRow);
                            }


                            while (i < dataExtraction.Rows.Count && dataExtraction.Rows[i][0] == DBNull.Value)
                            {
                                if (dataExtraction.Rows[i][7] == DBNull.Value & dataExtraction.Rows[i][8].ToString() == "—умма")
                                {

                                }
                                else
                                {
                                    if (dataExtraction.Rows[i][7].ToString().Split(" ").Last() == "к¬јр*ч")
                                    {
                                        break;
                                    }
                                    DataRow newTableRow = newTable.NewRow();
                                    newTableRow["measure"] = dataExtraction.Rows[i][7].ToString();
                                    newTableRow["zone"] = dataExtraction.Rows[i][8].ToString();
                                    newTableRow["initial"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][9].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                    newTableRow["final"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][10].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                    if (decimal.Parse(Convert.ToString(dataExtraction.Rows[i][9].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)) < decimal.Parse(Convert.ToString(dataExtraction.Rows[i][10].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)))
                                    {
                                        newTableRow["consumption"] = (decimal.Parse(Convert.ToString(dataExtraction.Rows[i][10].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)) - decimal.Parse(Convert.ToString(dataExtraction.Rows[i][9].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)))*kTC*kTV;
                                    }
                                    newTable.Rows.Add(newTableRow);
                                }
                                i++;
                            }

                            Button newButton = new Button();
                            createNewButtonOnTable(newButton, newTable.TableName);
                            mgFlowPanelResult.Controls.Add(newButton);

                            IntegralsDataSet.Tables.Add(newTable);
                            IntegralsDataSet.Tables.Add(headerTable);
                        }
                        else
                        {
                            int i = dataExtraction.Rows.IndexOf(extractRows) + 1;
                            DataTable newTable = new DataTable("intg_" + resultString);
                            newTable.TableName = expectedTableName(newTable.TableName, "intg");
                            DataTable headerTable = new DataTable(newTable.TableName + "_Header");

                            prepareNewIntegralTables(headerTable, newTable);

                            int kTC = Convert.ToInt32(extractRows[4].ToString());
                            int kTV = Convert.ToInt32(extractRows[5].ToString());

                            headerTable.Rows[1]["Values"] = extractRows[2].ToString().Split(",").First();
                            headerTable.Rows[2]["Values"] = extractRows[1].ToString();
                            headerTable.Rows[3]["Values"] = resultString;
                            headerTable.Rows[4]["Values"] = kTC + "/" + kTV;

                            if (extractRows[7].ToString() != "R+, к¬јр*ч" | extractRows[7].ToString() != "R-, к¬јр*ч")
                            {
                                DataRow newTableFirstRow = newTable.NewRow();
                                newTableFirstRow["measure"] = extractRows[7].ToString();
                                newTableFirstRow["zone"] = extractRows[8].ToString();
                                newTableFirstRow["initial"] = decimal.Parse(Convert.ToString(extractRows[9].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                newTableFirstRow["final"] = decimal.Parse(Convert.ToString(extractRows[10].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                if (decimal.Parse(Convert.ToString(extractRows[9].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)) < decimal.Parse(Convert.ToString(extractRows[10].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)))
                                {
                                    newTableFirstRow["consumption"] = (decimal.Parse(Convert.ToString(extractRows[10].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)) - decimal.Parse(Convert.ToString(extractRows[9].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)))*kTC*kTV;
                                }
                                newTable.Rows.Add(newTableFirstRow);
                            }

                            while (i < dataExtraction.Rows.Count && dataExtraction.Rows[i][0] == DBNull.Value)
                            {
                                if (dataExtraction.Rows[i][7] == DBNull.Value & dataExtraction.Rows[i][8].ToString() == "—умма")
                                {

                                }
                                else
                                {
                                    if (dataExtraction.Rows[i][7].ToString().Split(" ").Last() == "к¬јр*ч")
                                    {
                                        break;
                                    }
                                    DataRow newTableRow = newTable.NewRow();
                                    newTableRow["measure"] = dataExtraction.Rows[i][7].ToString();
                                    newTableRow["zone"] = dataExtraction.Rows[i][8].ToString();
                                    newTableRow["initial"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][9].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                    newTableRow["final"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][10].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                    if (decimal.Parse(Convert.ToString(dataExtraction.Rows[i][9].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)) < decimal.Parse(Convert.ToString(dataExtraction.Rows[i][10].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)))
                                    {
                                        newTableRow["consumption"] = (decimal.Parse(Convert.ToString(dataExtraction.Rows[i][10].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)) - decimal.Parse(Convert.ToString(dataExtraction.Rows[i][9].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)))*kTC*kTV;
                                    }
                                    newTable.Rows.Add(newTableRow);
                                }
                                i++;
                            }

                            Button newButton = new Button();
                            createNewButtonOnTable(newButton, newTable.TableName);
                            mgFlowPanelResult.Controls.Add(newButton);

                            IntegralsDataSet.Tables.Add(newTable);
                            IntegralsDataSet.Tables.Add(headerTable);
                        }
                    }
                    catch
                    {
                        try
                        {
                            int foundRow = SearchDGV(DictionaryForm.dataGridDictionaryList, resultString, "NumCC");
                            if (foundRow != -1)
                            {
                                int i = dataExtraction.Rows.IndexOf(extractRows) + 1;
                                DataTable newTable = new DataTable("intg_" + DictionaryForm.dataGridDictionaryList.Rows[foundRow].Cells["Agreement"].Value.ToString().Split(" от ").First());
                                newTable.TableName = expectedTableName(newTable.TableName, "intg");
                                DataTable headerTable = new DataTable(newTable.TableName + "_Header");

                                prepareNewIntegralTables(headerTable, newTable);

                                int kTC = Convert.ToInt32(extractRows[4].ToString());
                                int kTV = Convert.ToInt32(extractRows[5].ToString());

                                headerTable.Rows[0]["Values"] = DictionaryForm.dataGridDictionaryList.Rows[foundRow].Cells["Agreement"].Value.ToString();
                                if (DictionaryForm.dataGridDictionaryList.Rows[foundRow].Cells["FullName"].Value.ToString() == extractRows[2].ToString().Split(",").First())
                                    headerTable.Rows[1]["Values"] = DictionaryForm.dataGridDictionaryList.Rows[foundRow].Cells["FullName"].Value.ToString();
                                headerTable.Rows[2]["Values"] = extractRows[1].ToString();
                                headerTable.Rows[3]["Values"] = resultString;
                                headerTable.Rows[4]["Values"] = kTC + "/" + kTV;

                                int mesStrID = i - 1;
                                while (i < dataExtraction.Rows.Count && dataExtraction.Rows[i][0] == DBNull.Value)
                                {
                                    if (dataExtraction.Rows[i][7].ToString().Split(" ").Last() == "к¬јр*ч")
                                    {
                                        break;
                                    }
                                    if (dataExtraction.Rows[i][8].ToString() == "—умма")
                                    {
                                        DataRow newTableRow = newTable.NewRow();
                                        newTableRow["measure"] = dataExtraction.Rows[mesStrID][7].ToString();
                                        newTableRow["zone"] = dataExtraction.Rows[i][8].ToString();
                                        newTableRow["initial"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][9].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                        newTableRow["final"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][10].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                        if (decimal.Parse(Convert.ToString(dataExtraction.Rows[i][9].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)) < decimal.Parse(Convert.ToString(dataExtraction.Rows[i][10].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)))
                                        {
                                            newTableRow["consumption"] = (decimal.Parse(Convert.ToString(dataExtraction.Rows[i][10].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)) - decimal.Parse(Convert.ToString(dataExtraction.Rows[i][9].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)))*kTC*kTV;
                                        }
                                        mesStrID = i + 1;
                                        newTable.Rows.Add(newTableRow);
                                    }
                                    i++;
                                }

                                Button newButton = new Button();
                                createNewButtonOnTable(newButton, newTable.TableName);
                                mgFlowPanelResult.Controls.Add(newButton);

                                IntegralsDataSet.Tables.Add(newTable);
                                IntegralsDataSet.Tables.Add(headerTable);
                            }
                            else
                            {
                                int i = dataExtraction.Rows.IndexOf(extractRows) + 1;
                                DataTable newTable = new DataTable("intg_" + resultString);
                                newTable.TableName = expectedTableName(newTable.TableName, "intg");
                                DataTable headerTable = new DataTable(newTable.TableName + "_Header");

                                prepareNewIntegralTables(headerTable, newTable);

                                int kTC = Convert.ToInt32(extractRows[4].ToString());
                                int kTV = Convert.ToInt32(extractRows[5].ToString());

                                headerTable.Rows[1]["Values"] = extractRows[2].ToString().Split(",").First();
                                headerTable.Rows[2]["Values"] = extractRows[1].ToString();
                                headerTable.Rows[3]["Values"] = resultString;
                                headerTable.Rows[4]["Values"] = kTC + "/" + kTV;

                                int mesStrID = i-1;
                                while (i < dataExtraction.Rows.Count && dataExtraction.Rows[i][0] == DBNull.Value)
                                {
                                    if (dataExtraction.Rows[i][7].ToString().Split(" ").Last() == "к¬јр*ч")
                                    {
                                        break;
                                    }
                                    if (dataExtraction.Rows[i][8].ToString() == "—умма")
                                    {
                                        DataRow newTableRow = newTable.NewRow();
                                        newTableRow["measure"] = dataExtraction.Rows[mesStrID][7].ToString();
                                        newTableRow["zone"] = dataExtraction.Rows[i][8].ToString();
                                        newTableRow["initial"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][9].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                        newTableRow["final"] = decimal.Parse(Convert.ToString(dataExtraction.Rows[i][10].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart));
                                        if (decimal.Parse(Convert.ToString(dataExtraction.Rows[i][9].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)) < decimal.Parse(Convert.ToString(dataExtraction.Rows[i][10].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)))
                                        {
                                            newTableRow["consumption"] = (decimal.Parse(Convert.ToString(dataExtraction.Rows[i][10].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)) - decimal.Parse(Convert.ToString(dataExtraction.Rows[i][9].ToString()), NumberStyles.Float, CultureInfo.GetCultureInfo(cmnSettings.GlobalInfoStandart)))*kTC*kTV;
                                        }
                                        mesStrID = i+1;
                                        newTable.Rows.Add(newTableRow);
                                    }
                                    i++;
                                }

                                Button newButton = new Button();
                                createNewButtonOnTable(newButton, newTable.TableName);
                                mgFlowPanelResult.Controls.Add(newButton);

                                IntegralsDataSet.Tables.Add(newTable);
                                IntegralsDataSet.Tables.Add(headerTable);
                            }
                        }
                        catch
                        {
                            
                        }
                    }
                }
            }
        }

        private string expectedTableName(string expTableName, string type)
        {
            int existCount = 0;
            switch (type)
            {
                case "intg":
                    foreach (DataTable Table in IntegralsDataSet.Tables)
                    {
                        if (expTableName.Split("#").First() == Table.TableName)
                        {
                            existCount++;
                        }
                    }
                    break;

                case "hrs":
                    foreach (DataTable Table in HoursDataSet.Tables)
                    {
                        if (expTableName.Split("#").First() == Table.TableName)
                        {
                            existCount++;
                        }
                    }
                    break;
            }
            if (existCount > 0)
            {
                expTableName += "#" + (existCount + 1);
            }
            return expTableName;
        }

        private void createNewButtonOnTable(Button newButton, string name)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));

            newButton.Text = name;
            newButton.FlatStyle = FlatStyle.Flat;
            newButton.Image = (Image)resources.GetObject("mgOpenDataTable.Image");
            newButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            newButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            newButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            newButton.UseVisualStyleBackColor = true;
            newButton.AutoSize = true;
            newButton.Click += new EventHandler(ShowTableInDataGridView);
            newButton.MouseMove += new MouseEventHandler(TableButton_MouseMove);
            newButton.GiveFeedback += new GiveFeedbackEventHandler(TableButton_GiveFeedback);
        }

        private void workWithButtonsIntoFlowPanel()
        {
            int max = 0;
            List<Button> listOfButtons = new List<Button>();
            foreach (Button buttons in mgFlowPanelResult.Controls.OfType<Button>())
            {
                Size len = TextRenderer.MeasureText(buttons.Text, buttons.Font);
                if (len.Width > max)
                {
                    max = len.Width;
                }

                int SearchRowName = -1;
                switch (buttons.Text.Split("_").First())
                {
                    case "intg":
                        SearchRowName = SearchDGV(mgDataViewer, IntegralsDataSet.Tables[buttons.Text + "_header"].Rows[0][1].ToString(), "Agreement");
                        if (SearchRowName != -1)
                        {
                            var methodCell = (DataGridViewComboBoxCell)mgDataViewer.Rows[SearchRowName].Cells["Method"];
                            string validatedStatus = null;
                            try
                            {
                                validatedStatus = validateTable(buttons.Text, Convert.ToInt32(Convert.ToString(mgDataViewer.Rows[SearchRowName].Cells["TariffZone"].Value)[0].ToString()));
                            }
                            catch
                            {
                                validatedStatus = "TableError";
                            }
                            
                            if (validatedStatus != "TableError")
                            {

                                if (mgDataViewer.Rows[SearchRowName].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"])].GetType().Name != "DataGridViewButtonCell")
                                {
                                    DataGridViewButtonCell btnCell = new DataGridViewButtonCell();
                                    btnCell.UseColumnTextForButtonValue = false;
                                    btnCell.ToolTipText = buttons.Text;
                                    mgDataViewer.Rows[SearchRowName].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"])] = btnCell;
                                    mgDataViewer.Rows[SearchRowName].Cells["GlobalStatus"].ToolTipText = validatedStatus;
                                    methodCell.Items.Add("intg");
                                    createExcelButton(SearchRowName);
                                    listOfButtons.Add(buttons);
                                }
                                else
                                {
                                    if (!mgDataViewer.Rows[SearchRowName].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"])].ToolTipText.Contains('+') &&
                                        !mgDataViewer.Rows[SearchRowName].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"])].ToolTipText.Contains("intg_"))
                                    {
                                        mgDataViewer.Rows[SearchRowName].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"])].ToolTipText += "+" + buttons.Text;
                                        //mgDataViewer.Rows[SearchRowName].Cells["GlobalStatus"].ToolTipText = validatedStatus;
                                        methodCell.Items.Add("intg");
                                        createExcelButton(SearchRowName);
                                        listOfButtons.Add(buttons);
                                    }
                                }
                            }
                        }
                        break;
                    case "hrs":
                        SearchRowName = SearchDGV(mgDataViewer, HoursDataSet.Tables[buttons.Text + "_header"].Rows[0][1].ToString(), "Agreement");
                        if (SearchRowName != -1)
                        {
                            var methodCell = (DataGridViewComboBoxCell)mgDataViewer.Rows[SearchRowName].Cells["Method"];
                            string validatedStatus = null;
                            try
                            {
                                validatedStatus = validateTable(buttons.Text, Convert.ToInt32(Convert.ToString(mgDataViewer.Rows[SearchRowName].Cells["TariffZone"].Value)[0].ToString()));
                            }
                            catch
                            {
                                validatedStatus = "TableError";
                            }

                            if (mgDataViewer.Rows[SearchRowName].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"])].GetType().Name != "DataGridViewButtonCell")
                            {
                                DataGridViewButtonCell btnCell = new DataGridViewButtonCell();
                                btnCell.UseColumnTextForButtonValue = false;
                                btnCell.ToolTipText = buttons.Text;
                                mgDataViewer.Rows[SearchRowName].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"])] = btnCell;
                                mgDataViewer.Rows[SearchRowName].Cells["GlobalStatus"].ToolTipText = validatedStatus;
                                methodCell.Items.Add("hrs");
                                createExcelButton(SearchRowName);
                                listOfButtons.Add(buttons);
                            }
                            else
                            {
                                if (!mgDataViewer.Rows[SearchRowName].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"])].ToolTipText.Contains('+') &&
                                    !mgDataViewer.Rows[SearchRowName].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"])].ToolTipText.Contains("hrs_"))
                                {
                                    mgDataViewer.Rows[SearchRowName].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"])].ToolTipText += "+" + buttons.Text;
                                    //mgDataViewer.Rows[SearchRowName].Cells["GlobalStatus"].ToolTipText = validatedStatus;
                                    methodCell.Items.Add("hrs");
                                    createExcelButton(SearchRowName);
                                    listOfButtons.Add(buttons);
                                }
                            }
                        }
                        break;
                }


                string tempBtnName = buttons.Text.Split("_").Last();
                foreach (char c in tempBtnName)
                {
                    if (c.ToString() != "0")
                    {
                        break;
                    }
                    else
                    {
                        tempBtnName = tempBtnName.Substring(1);
                    }
                }

                int SearchRowNumCC = SearchDGV(mgDataViewer, tempBtnName, "NumCC");
                if (SearchRowNumCC != -1)
                {
                    
                    var methodCell = (DataGridViewComboBoxCell)mgDataViewer.Rows[SearchRowNumCC].Cells["Method"];
                    string validatedStatus = null;
                    try
                    {
                        validatedStatus = validateTable(buttons.Text, Convert.ToInt32(Convert.ToString(mgDataViewer.Rows[SearchRowNumCC].Cells["TariffZone"].Value)[0].ToString()));
                    }
                    catch
                    {
                        validatedStatus = "TableError";
                    }

                    switch (buttons.Text.Split("_").First())
                    {
                        case "intg":
                            if (validatedStatus != "TableError")
                            {

                                if (mgDataViewer.Rows[SearchRowNumCC].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"])].GetType().Name != "DataGridViewButtonCell")
                                {
                                    DataGridViewButtonCell btnCell = new DataGridViewButtonCell();
                                    btnCell.UseColumnTextForButtonValue = false;
                                    btnCell.ToolTipText = buttons.Text;
                                    mgDataViewer.Rows[SearchRowNumCC].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"])] = btnCell;
                                    mgDataViewer.Rows[SearchRowNumCC].Cells["GlobalStatus"].ToolTipText = validatedStatus;
                                    methodCell.Items.Add("intg");
                                    createExcelButton(SearchRowNumCC);
                                    listOfButtons.Add(buttons);
                                }
                                else
                                {
                                    if (!mgDataViewer.Rows[SearchRowNumCC].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"])].ToolTipText.Contains('+'))
                                    {
                                        mgDataViewer.Rows[SearchRowNumCC].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"])].ToolTipText += "+" + buttons.Text;
                                        methodCell.Items.Add("intg");
                                        createExcelButton(SearchRowNumCC);
                                        listOfButtons.Add(buttons);
                                    }
                                }
                            }

                            IntegralsDataSet.Tables[buttons.Text + "_header"].Rows[0][1] = mgDataViewer.Rows[SearchRowNumCC].Cells["Agreement"].Value.ToString();
                            IntegralsDataSet.Tables[buttons.Text + "_header"].Rows[0][1] = mgDataViewer.Rows[SearchRowNumCC].Cells["FullName"].Value.ToString();
                            break;

                        case "hrs":
                            if (mgDataViewer.Rows[SearchRowNumCC].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"])].GetType().Name != "DataGridViewButtonCell")
                            {
                                DataGridViewButtonCell btnCell = new DataGridViewButtonCell();
                                btnCell.UseColumnTextForButtonValue = false;
                                btnCell.ToolTipText = buttons.Text;
                                mgDataViewer.Rows[SearchRowNumCC].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"])] = btnCell;
                                mgDataViewer.Rows[SearchRowNumCC].Cells["GlobalStatus"].ToolTipText = validatedStatus;
                                methodCell.Items.Add("hrs");
                                createExcelButton(SearchRowNumCC);
                                listOfButtons.Add(buttons);
                            }
                            else
                            {
                                if (!mgDataViewer.Rows[SearchRowNumCC].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"])].ToolTipText.Contains('+'))
                                {
                                    mgDataViewer.Rows[SearchRowNumCC].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"])].ToolTipText += "+" + buttons.Text;
                                    methodCell.Items.Add("hrs");
                                    createExcelButton(SearchRowNumCC);
                                    listOfButtons.Add(buttons);
                                }
                            }
                            HoursDataSet.Tables[buttons.Text + "_header"].Rows[0][1] = mgDataViewer.Rows[SearchRowNumCC].Cells["Agreement"].Value.ToString();
                            HoursDataSet.Tables[buttons.Text + "_header"].Rows[0][1] = mgDataViewer.Rows[SearchRowNumCC].Cells["FullName"].Value.ToString();
                            break;
                    }
                }
            }
            foreach(Button removed in listOfButtons)
            {
                mgFlowPanelResult.Controls.Remove(removed);
            }

            mgSplitContainer_inside_vertical.SplitterDistance = mgSplitContainer_inside_vertical.SplitterDistance - (max/4);
            mgSplitContainer_inside_vertical.Panel2MinSize = max+50;
            mgDataViewer.Refresh();
            autoSelectedMethod();
        }

        private void autoSelectedMethod()
        {
            DataGridViewComboBoxCell methodCell = null;
            foreach (DataGridViewRow row in mgDataViewer.Rows)
            {
                methodCell = (DataGridViewComboBoxCell)row.Cells["Method"];
                if (row.Cells["Method"].GetType().Name == "DataGridViewComboBoxCell")
                {
                    switch (methodCell.Items.Count)
                    {
                        case 2:
                            foreach (var item in methodCell.Items)
                            {
                                if (item.ToString() == "intg")
                                {
                                    row.Cells["Method"].Value = "intg";
                                    break;
                                }
                            }
                            break;
                        case 1:
                            row.Cells["Method"].Value = methodCell.Items[0].ToString();
                            break;
                        case 0:
                            
                            break;
                    }
                }
            }
        }

        private static void prepareNewIntegralTables(DataTable headerTable, DataTable newTable)
        {
            DataColumn hdrColumn1 = new DataColumn("Header");
            DataColumn hdrColumn2 = new DataColumn("Values");
            headerTable.Clear();
            headerTable.Columns.Add(hdrColumn1);
            headerTable.Columns.Add(hdrColumn2);

            List<string> headersRowName = new List<string>() { "ƒоговор:", "јбонент:", "“очка учЄта:", "ѕ” є:", " ““/ “Ќ:" };

            for (int i = 0; i < 5; i++)
            {
                DataRow newRow = headerTable.NewRow();
                newRow["Header"] = headersRowName[i];
                headerTable.Rows.Add(newRow);
            }

            DataColumn Column1 = new DataColumn("measure");
            DataColumn Column2 = new DataColumn("zone");
            DataColumn Column3 = new DataColumn("initial", Type.GetType("System.Decimal"));
            DataColumn Column4 = new DataColumn("final", Type.GetType("System.Decimal"));
            DataColumn Column5 = new DataColumn("consumption", Type.GetType("System.Decimal"));

            newTable.Clear();
            newTable.Columns.Add(Column1);
            newTable.Columns.Add(Column2);
            newTable.Columns.Add(Column3);
            newTable.Columns.Add(Column4);
            newTable.Columns.Add(Column5);
        }

        public static bool IsDateOnly(string inputS)
        {
                bool result = DateOnly.TryParse(inputS, out DateOnly date);
                return result;

        }

        public static bool IsNumeric(object Expression)
        {
            decimal retNum;

            bool isNum = decimal.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }


        private void TableButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Button btn = sender as Button;
                btn.Tag = new Point(e.X, e.Y);
                btn.DoDragDrop(sender, DragDropEffects.Move);
            }
        }


        private void mgDataViewer_MouseDown(object sender, MouseEventArgs e)
        {
            tableRemove = null;

            DataGridView.HitTestInfo hittest = mgDataViewer.HitTest(e.X, e.Y);
            if (hittest.ColumnIndex == mgDataViewer.Columns["dataTable"].Index && hittest.RowIndex != -1)
            {
                if(mgDataViewer.Rows[hittest.RowIndex].Cells[hittest.ColumnIndex].ToolTipText != "")
                {
                    tableRemove = mgDataViewer.Rows[hittest.RowIndex].Cells[hittest.ColumnIndex] as DataGridViewButtonCell;
                }
            }
        }

        private void mgDataViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (tableRemove != null)
                {
                    DragDropEffects dropCell = mgDataViewer.DoDragDrop(tableRemove, DragDropEffects.Move);
                }
            }
        }

        string btnMoveName = null;
        private void mgDataViewer_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (mgDataViewer.RectangleToScreen(e.RowBounds).Contains(MousePosition))
            {
                var r = e.RowBounds; r.Width = GetGridWidth(mgDataViewer); r.Height -= 2;
                switch (mgDataViewer.Rows[e.RowIndex].Cells[mgDataViewer.Columns["dataTable"].Index].GetType().Name)
                {
                    case "DataGridViewButtonCell":
                        
                        if (!mgDataViewer.Rows[e.RowIndex].Cells[mgDataViewer.Columns["dataTable"].Index].ToolTipText.Contains('+') &&
                            mgDataViewer.Rows[e.RowIndex].Cells[mgDataViewer.Columns["dataTable"].Index].ToolTipText.Split("_").First() != btnMoveName.Split("_").First())
                        {
                            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Blue)), r);
                            e.Graphics.DrawRectangle(new Pen(Color.Blue), r);
                        }
                        break;

                    case "DataGridViewTextBoxCell":
                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Blue)), r);
                        e.Graphics.DrawRectangle(new Pen(Color.Blue), r);
                        break;
                }
            }
        }

        private void mgDataViewerRowPaint(int row, PaintEventArgs e)
        {
            if (row != -1)
            {
                Rectangle rowBound = e.ClipRectangle;
                switch (mgDataViewer.Rows[row].Cells[mgDataViewer.Columns["dataTable"].Index].GetType().Name)
                {
                    case "DataGridViewButtonCell":

                        if (!mgDataViewer.Rows[row].Cells[mgDataViewer.Columns["dataTable"].Index].ToolTipText.Contains('+') &&
                            mgDataViewer.Rows[row].Cells[mgDataViewer.Columns["dataTable"].Index].ToolTipText.Split("_").First() != btnMoveName.Split("_").First())
                        {
                            using (var pen = new Pen(Color.FromArgb(255, 50, 0, 250), 2))
                            {
                                pen.Alignment = PenAlignment.Center;
                                pen.DashStyle = DashStyle.Solid;

                                e.Graphics.DrawLine(pen, rowBound.X, rowBound.Y, rowBound.X, rowBound.Y + 5);
                                e.Graphics.DrawLine(pen, rowBound.X, rowBound.Y, rowBound.X + 5, rowBound.Y);

                                e.Graphics.DrawLine(pen, rowBound.X, rowBound.Bottom, rowBound.X, rowBound.Bottom - 5);
                                e.Graphics.DrawLine(pen, rowBound.X, rowBound.Bottom, rowBound.X + 5, rowBound.Bottom);

                                e.Graphics.DrawLine(pen, rowBound.Right, rowBound.Y, rowBound.Right, rowBound.Y + 5);
                                e.Graphics.DrawLine(pen, rowBound.Right, rowBound.Y, rowBound.Right - 5, rowBound.Y);

                                e.Graphics.DrawLine(pen, rowBound.Right, rowBound.Bottom, rowBound.Right, rowBound.Bottom - 5);
                                e.Graphics.DrawLine(pen, rowBound.Right, rowBound.Bottom, rowBound.Right - 5, rowBound.Bottom);


                                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Blue)), rowBound);
                            }

                            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                            //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Blue)), rowBound);
                            //e.Graphics.DrawRectangle(new Pen(Color.Blue), rowBound);
                        }
                        break;

                    case "DataGridViewTextBoxCell":
                        using (var pen = new Pen(Color.FromArgb(255, 50, 0, 250), 2))
                        {
                            pen.Alignment = PenAlignment.Center;
                            pen.DashStyle = DashStyle.Solid;

                            e.Graphics.DrawLine(pen, rowBound.X, rowBound.Y, rowBound.X, rowBound.Y + 5);
                            e.Graphics.DrawLine(pen, rowBound.X, rowBound.Y, rowBound.X+5, rowBound.Y);

                            e.Graphics.DrawLine(pen, rowBound.X, rowBound.Bottom, rowBound.X, rowBound.Bottom - 5);
                            e.Graphics.DrawLine(pen, rowBound.X, rowBound.Bottom, rowBound.X + 5, rowBound.Bottom);

                            e.Graphics.DrawLine(pen, rowBound.Right, rowBound.Y, rowBound.Right, rowBound.Y + 5);
                            e.Graphics.DrawLine(pen, rowBound.Right, rowBound.Y, rowBound.Right - 5, rowBound.Y);

                            e.Graphics.DrawLine(pen, rowBound.Right, rowBound.Bottom, rowBound.Right, rowBound.Bottom - 5);
                            e.Graphics.DrawLine(pen, rowBound.Right, rowBound.Bottom, rowBound.Right - 5, rowBound.Bottom);

                            
                            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Blue)), rowBound);
                        }

                        //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                        //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Blue)), rowBound);
                        //e.Graphics.DrawRectangle(new Pen(Color.Blue), rowBound);

                        break;
                }
            }
        }

        private int GetGridWidth(DataGridView grid)
        {
            int width = 0;
            foreach (DataGridViewColumn column in grid.Columns)
            {
                if(column.Visible)
                width += column.Width;
            }

            return width;
        }


        private int _selectedRowIndex;
        public int SelectedRowIndex
        {
            get => _selectedRowIndex;
            set
            {
                if (value != _selectedRowIndex)
                {
                    _selectedRowIndex = value;
                    Rectangle rowBound = mgDataViewer.GetRowDisplayRectangle(SelectedRowIndex, false);
                    if (GetGridWidth(mgDataViewer) > mgDataViewer.Width)
                    {
                        rowBound.Width = mgDataViewer.Width-1;
                    }
                    else
                    {
                        rowBound.Width = GetGridWidth(mgDataViewer)-1;
                    }

                    mgDataViewer.Refresh();
                    mgDataViewerRowPaint(SelectedRowIndex, new PaintEventArgs(mgDataViewer.CreateGraphics(), rowBound));

                }
            }
        }

        private void TableButton_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            Point cursorLocation = mgDataViewer.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            int rowIndex = mgDataViewer.HitTest(cursorLocation.X, cursorLocation.Y).RowIndex;
            SelectedRowIndex = rowIndex;
        }


        private void mgFlowPanelResult_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataGridViewButtonCell)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void mgDataViewer_DragLeave(object sender, EventArgs e)
        {
            mgDataViewer.Refresh();
        }

        private void mgDataViewer_DragOver(object sender, DragEventArgs e)
        {
            if (Control.MouseButtons.ToString() == "Left")
            {
                e.Effect = DragDropEffects.Move;
                int mousepos = PointToClient(Cursor.Position).Y;
                if (mousepos > (MainTableLayoutPanel.Bottom - (mgSplitContainer_insideHorizontal.Height - mgSplitContainer_insideHorizontal.Panel2MinSize - mgSplitContainer_insideHorizontal.SplitterDistance)) * 0.995)
                {
                    if (mgDataViewer.FirstDisplayedScrollingRowIndex < mgDataViewer.RowCount - 1)
                    {
                        mgDataViewer.FirstDisplayedScrollingRowIndex += 1;
                    }
                }

                if (mousepos < (MainTableLayoutPanel.Top + 270))
                {
                    if (mgDataViewer.FirstDisplayedScrollingRowIndex > 0)
                    {
                        mgDataViewer.FirstDisplayedScrollingRowIndex -= 1;
                    }
                }

            }
        }

        private void mgDataViewer_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            if (e.Data.GetDataPresent(typeof(Button)))
            {
                e.Effect = DragDropEffects.Move;
                var table = (Button)e.Data.GetData(typeof(Button));
                btnMoveName = table.Text;
                mgDataViewer.ClearSelection();
            }
        }

        private void mgFlowPanelResult_DragDrop(object sender, DragEventArgs e)
        {
            Button btn = (Button)e.Data.GetData(typeof(Button));
            DataGridViewButtonCell btnTable = (DataGridViewButtonCell)e.Data.GetData(typeof(DataGridViewButtonCell));

            FlowLayoutPanel _destination = (FlowLayoutPanel)sender;

            if (e.Data.GetDataPresent(typeof(DataGridViewButtonCell)))
            {
                var methodCell = (DataGridViewComboBoxCell)mgDataViewer.Rows[tableRemove.RowIndex].Cells["Method"];
                if (!btnTable.ToolTipText.Contains('+'))
                {
                    Button newButton = new Button();
                    createNewButtonOnTable(newButton, btnTable.ToolTipText);
                    _destination.Controls.Add(newButton);
                    switch (btnTable.ToolTipText.Split("_").First())
                    {
                        case "intg":
                            mgDataViewer.Rows[tableRemove.RowIndex].Cells["intgStatusError"].Value = CheckState.Unchecked;
                            break;

                        case "hrs":
                            mgDataViewer.Rows[tableRemove.RowIndex].Cells["hrsStatusError"].Value = CheckState.Unchecked;
                            break;
                    }
                    mgDataViewer.Rows[tableRemove.RowIndex].Cells["GlobalStatus"].ToolTipText = "created";
                }
                else
                {
                    string[] Name = btnTable.ToolTipText.Split("+");
                    foreach(string name in Name)
                    {
                        Button newButton = new Button();
                        createNewButtonOnTable(newButton, name);
                        _destination.Controls.Add(newButton);

                        switch (name.Split("_").First())
                        {
                            case "intg":
                                mgDataViewer.Rows[tableRemove.RowIndex].Cells["intgStatusError"].Value = CheckState.Unchecked;
                                break;

                            case "hrs":
                                mgDataViewer.Rows[tableRemove.RowIndex].Cells["hrsStatusError"].Value = CheckState.Unchecked;
                                break;
                        }
                    }

                    mgDataViewer.Rows[tableRemove.RowIndex].Cells["GlobalStatus"].ToolTipText = "created";
                }
                mgDataViewer.Rows[tableRemove.RowIndex].Cells["dataExcel"] = new DataGridViewTextBoxCell();
                mgDataViewer.Rows[tableRemove.RowIndex].Cells["SelectID"].Value = false;
                mgDataViewer.Rows[tableRemove.RowIndex].Cells[tableRemove.ColumnIndex] = new DataGridViewTextBoxCell();
                methodCell.Value = null;
                methodCell.Items.Clear();
                cmbxMethod.Items.Clear();
                cmbxMethod.Text = null;
                mgDataViewer.ClearSelection();
                mgDataViewer.Invalidate();
                tableRemove = null;
            }
        }

        private void mgDataViewer_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1)
                {
                    string xlFileName = files[0].ToString();
                    ExlFileName = Path.GetFileName(xlFileName);

                    DataTable dataExtraction = new DataTable();
                    commonImportEXCL(this, new EventArgs(), dataExtraction, xlFileName);
                    HoursFile_processing(dataExtraction);

                    mgDataViewer.Update();
                }
            }
            if (e.Data.GetDataPresent(typeof(Button)))
            {
                var table = (Button)e.Data.GetData(typeof(Button));
                Point cursorLocation = mgDataViewer.PointToClient(new Point(e.X, e.Y));
                DataGridView.HitTestInfo hittest = mgDataViewer.HitTest(cursorLocation.X, cursorLocation.Y);
                if (hittest.ColumnIndex != -1 && hittest.RowIndex != -1)
                {
                    int TariffZone = 1;
                    try
                    {
                        TariffZone = Convert.ToInt32(Convert.ToString(mgDataViewer.Rows[hittest.RowIndex].Cells["TariffZone"].Value)[0].ToString());
                    }
                    catch
                    {
                        mgDataViewer.Refresh();
                        return;
                    }
                    
                    var methodCell = (DataGridViewComboBoxCell)mgDataViewer.Rows[hittest.RowIndex].Cells["Method"];

                    if (mgDataViewer.Rows[hittest.RowIndex].Cells[mgDataViewer.Columns["dataTable"].Index].GetType().Name != "DataGridViewButtonCell")
                    {
                        DataGridViewButtonCell btnCell = new DataGridViewButtonCell();
                        btnCell.UseColumnTextForButtonValue = false;
                        btnCell.ToolTipText = table.Text;
                        mgDataViewer.Rows[hittest.RowIndex].Cells[mgDataViewer.Columns["dataTable"].Index] = btnCell;

                        mgDataViewer.Rows[hittest.RowIndex].Cells["GlobalStatus"].ToolTipText = validateTable(table.Text, TariffZone);

                        switch (table.Text.Split("_").First())
                        {
                            case "intg":
                                IntegralsDataSet.Tables[btnCell.ToolTipText + "_header"].Rows[0][1] = mgDataViewer.Rows[hittest.RowIndex].Cells[mgDataViewer.Columns["Agreement"].Index].Value.ToString();
                                if (Convert.ToString(IntegralsDataSet.Tables[btnCell.ToolTipText + "_header"].Rows[3][1]) != Convert.ToString(mgDataViewer.Rows[hittest.RowIndex].Cells["NumCC"].Value))
                                {
                                    mgDataViewer.Rows[hittest.RowIndex].Cells["intgStatusError"].Value = CheckState.Indeterminate;
                                }
                                if(singleTableStatus(mgDataViewer.Rows[hittest.RowIndex].Cells["GlobalStatus"].ToolTipText))
                                {
                                    mgDataViewer.Rows[hittest.RowIndex].Cells["intgStatusError"].Value = CheckState.Checked;
                                }
                                else
                                {
                                    methodCell.Items.Add("intg");
                                    createExcelButton(hittest.RowIndex);
                                }
                                break;
                            case "hrs":
                                HoursDataSet.Tables[btnCell.ToolTipText + "_header"].Rows[0][1] = mgDataViewer.Rows[hittest.RowIndex].Cells[mgDataViewer.Columns["Agreement"].Index].Value.ToString();
                                if (Convert.ToString(HoursDataSet.Tables[btnCell.ToolTipText + "_header"].Rows[3][1]) != Convert.ToString(mgDataViewer.Rows[hittest.RowIndex].Cells["NumCC"].Value))
                                {
                                    mgDataViewer.Rows[hittest.RowIndex].Cells["hrsStatusError"].Value = CheckState.Indeterminate;
                                }
                                if (singleTableStatus(mgDataViewer.Rows[hittest.RowIndex].Cells["GlobalStatus"].ToolTipText))
                                {
                                    mgDataViewer.Rows[hittest.RowIndex].Cells["hrsStatusError"].Value = CheckState.Checked;
                                }
                                else
                                {
                                    methodCell.Items.Add("hrs");
                                    createExcelButton(hittest.RowIndex);
                                }
                                break;
                        }

                        if (Convert.ToString(mgDataViewer.Rows[hittest.RowIndex].Cells[table.Text.Split("_").First() + "StatusError"].Value) == CheckState.Indeterminate.ToString())
                        {
                            mgDataViewer.Rows[hittest.RowIndex].Cells["GlobalStatus"].ToolTipText = "TableWarning";
                        }
                        mgDataViewer.Refresh();
                        mgFlowPanelResult.Controls.Remove((Button)e.Data.GetData(typeof(Button)));
                    }
                    else
                    {
                        if (!mgDataViewer.Rows[hittest.RowIndex].Cells[mgDataViewer.Columns["dataTable"].Index].ToolTipText.Contains('+') &&
                            mgDataViewer.Rows[hittest.RowIndex].Cells[mgDataViewer.Columns["dataTable"].Index].ToolTipText.Split("_").First() != table.Text.Split("_").First())
                        {
                            mgDataViewer.Rows[hittest.RowIndex].Cells[mgDataViewer.Columns["dataTable"].Index].ToolTipText += "+" + table.Text;

                            switch (table.Text.Split("_").First())
                            {
                                case "intg":
                                    IntegralsDataSet.Tables[table.Text + "_header"].Rows[0][1] = mgDataViewer.Rows[hittest.RowIndex].Cells[mgDataViewer.Columns["Agreement"].Index].Value.ToString();
                                    if (Convert.ToString(IntegralsDataSet.Tables[table.Text + "_header"].Rows[3][1]) != Convert.ToString(mgDataViewer.Rows[hittest.RowIndex].Cells["NumCC"].Value))
                                    {
                                        mgDataViewer.Rows[hittest.RowIndex].Cells["intgStatusError"].Value = CheckState.Indeterminate;
                                        mgDataViewer.Rows[hittest.RowIndex].Cells["GlobalStatus"].ToolTipText = "TableWarning";
                                    }
                                    if (singleTableStatus(validateTable(table.Text, TariffZone)))
                                    {
                                        mgDataViewer.Rows[hittest.RowIndex].Cells["intgStatusError"].Value = CheckState.Checked;
                                    }
                                    else
                                    {
                                        methodCell.Items.Add("intg");
                                        createExcelButton(hittest.RowIndex);
                                    }
                                    break;
                                case "hrs":
                                    HoursDataSet.Tables[table.Text + "_header"].Rows[0][1] = mgDataViewer.Rows[hittest.RowIndex].Cells[mgDataViewer.Columns["Agreement"].Index].Value.ToString();
                                    if (Convert.ToString(HoursDataSet.Tables[table.Text + "_header"].Rows[3][1]) != Convert.ToString(mgDataViewer.Rows[hittest.RowIndex].Cells["NumCC"].Value))
                                    {
                                        mgDataViewer.Rows[hittest.RowIndex].Cells["hrsStatusError"].Value = CheckState.Indeterminate;
                                        mgDataViewer.Rows[hittest.RowIndex].Cells["GlobalStatus"].ToolTipText = "TableWarning";
                                    }
                                    if (singleTableStatus(validateTable(table.Text, TariffZone)))
                                    {
                                        mgDataViewer.Rows[hittest.RowIndex].Cells["hrsgStatusError"].Value = CheckState.Checked;
                                    }
                                    else
                                    {
                                        methodCell.Items.Add("hrs");
                                        createExcelButton(hittest.RowIndex);
                                    }
                                    break;
                            }
                            if (Convert.ToString(mgDataViewer.Rows[hittest.RowIndex].Cells["hrsStatusError"].Value) == CheckState.Checked.ToString() |
                                Convert.ToString(mgDataViewer.Rows[hittest.RowIndex].Cells["intgStatusError"].Value) == CheckState.Checked.ToString())
                            {
                                mgDataViewer.Rows[hittest.RowIndex].Cells["GlobalStatus"].ToolTipText = "TableError";
                            }
                            mgDataViewer.Refresh();

                            mgFlowPanelResult.Controls.Remove((Button)e.Data.GetData(typeof(Button)));
                        }
                        else
                        {
                            mgDataViewer.Refresh();
                        }
                    }
                    autoSelectedMethod();
                }
            }
        }

        private void createExcelButton(int row)
        {
            var cellMethod = (DataGridViewComboBoxCell)mgDataViewer.Rows[row].Cells["Method"];

            if (cellMethod.Items.Count != 0)
            {
                mgDataViewer.Rows[row].Cells["SelectID"].Value = true;
                DataGridViewButtonCell btnCell = new DataGridViewButtonCell();
                btnCell.UseColumnTextForButtonValue = false;
                btnCell.ToolTipText = "Preview File";
                mgDataViewer.Rows[row].Cells["dataExcel"] = btnCell;
            }
        }


        private static bool singleTableStatus(string validateStatus)
        {
            if (validateStatus == "TableError")
                return true;
            else
                return false;
        }

        private string validateTable(string tableName, int TariffZone)
        {
            string result = null;
            switch (TariffZone)
            {
                case 1:
                    if (tableName.Split("_").First() == "intg")
                    {
                        if (IntegralsDataSet.Tables[tableName].Rows.Count == 2)
                            result = "TableOK";
                        else
                            result = "TableOK";
                    }
                    else
                    {
                        result = "TableOK";
                    }
                    break;

                case 2:
                    if (tableName.Split("_").First() == "intg")
                    {
                        if (IntegralsDataSet.Tables[tableName].Rows.Count == 4)
                            result = "TableOK";
                        else
                            result = "TableError";
                    }
                    else
                    {
                        result = "TableOK";
                    }
                    break;

                case 3:
                    if (tableName.Split("_").First() == "intg")
                    {
                        if (IntegralsDataSet.Tables[tableName].Rows.Count == 6)
                            result = "TableOK";
                        else
                            result = "TableError";
                    }
                    else
                    {
                        result = "TableOK";
                    }
                    break;

            }
            return result;
        }


        private void PrepareHeaderTable(DataTable headerTable)
        {
            DataColumn Column1 = new DataColumn("Header");
            DataColumn Column2 = new DataColumn("Values");
            headerTable.Clear();
            headerTable.Columns.Add(Column1);
            headerTable.Columns.Add(Column2);

            List<string> headersRowName = new List<string>() { "ƒоговор:", "јбонент:", "“очка учЄта:", "ѕ” є:", " ““/ “Ќ:" };

            for (int i =0; i <5; i++)
            {
                DataRow newRow = headerTable.NewRow();
                newRow["Header"] = headersRowName[i];
                headerTable.Rows.Add(newRow);
            }
        }

        private void ShowTable(string text)
        {
            Form TableView = new Form();
            DataGridView headerDataGridView = new DataGridView();
            DoubleBufferedDataGridView tablesDataGridView = new DoubleBufferedDataGridView();

            SettingsNewFormTablesResult(TableView, tablesDataGridView, headerDataGridView);

            int hSize = tablesDataGridView.Size.Height;

            switch (text.Split("_").First())
            {
                case "intg":
                    tablesDataGridView.DataSource = IntegralsDataSet;
                    headerDataGridView.DataSource = IntegralsDataSet;
                    hSize = 147 + ((IntegralsDataSet.Tables[text].Rows.Count * tablesDataGridView.RowTemplate.Height) + tablesDataGridView.ColumnHeadersHeight);
                    TableView.MinimumSize = new Size(TableView.Width, hSize);
                    break;
                case "hrs":
                    tablesDataGridView.DataSource = HoursDataSet;
                    headerDataGridView.DataSource = HoursDataSet;
                    hSize = 860;
                    TableView.MinimumSize = new Size(TableView.Width, hSize / 2);
                    break;
            }


            tablesDataGridView.DataMember = text;
            tablesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            headerDataGridView.DataMember = text + "_Header";

            headerDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            headerDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            headerDataGridView.Columns[0].Resizable = DataGridViewTriState.False;
            headerDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            int SearchRowNumCC = SearchDGV(mgDataViewer, headerDataGridView.Rows[2].Cells[1].Value.ToString(), "NumCC");
            if (SearchRowNumCC != -1)
            {
                TableView.Text = mgDataViewer.Rows[SearchRowNumCC].Cells["FullName"].Value.ToString();
            }
            else
            {
                TableView.Text = text.Split("_").Last() + " extracted data research";
            }
            TableView.Size = new Size(480, hSize);


            foreach (DataGridViewColumn cols in tablesDataGridView.Columns)
            {
                cols.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            }

            tablesDataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.tablesDataGridView_RowPrePaint);
           
            TableView.StartPosition = FormStartPosition.CenterScreen;
            TableView.Show();
        }

        private void tablesDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var tablesDataGridView = (DoubleBufferedDataGridView)sender;

            int lim1 = 0;
            int lim2 = 0;
            int start = 0;
            foreach (DataGridViewRow rows in tablesDataGridView.Rows)
            {
                if (start >= 24)
                {
                    if (lim1 < 24)
                    {
                        rows.DefaultCellStyle.BackColor = Color.LightGray;
                        lim1++;
                        lim2++;
                    }
                    else if (lim2 != 47)
                    {
                        lim2++;
                    }
                    else
                    {
                        lim1 = 0;
                        lim2 = 0;
                    }
                }
                else
                {
                    start++;
                }
            }

            tablesDataGridView.ClearSelection();
            tablesDataGridView.RowPrePaint -= new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.tablesDataGridView_RowPrePaint);
        }

        private void ShowTableInDataGridView(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string text = button.Text;
            ShowTable(text);
        }

        private void ShowSelectedTableInDataGridView(object sender, EventArgs e)
        {
            var button = (ToolStripItem)sender;
            string text = button.Text;
            ShowTable(text);
        }

        private void mgDataViewer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1 && e.ColumnIndex == mgDataViewer.Columns["dataTable"].Index && mgDataViewer.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType().Name == "DataGridViewButtonCell")
            {
                contextMenuOpenTable.Items.Clear();

                if (e.ColumnIndex == mgDataViewer.Columns["dataTable"].Index && mgDataViewer.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText.Contains('+'))
                {
                    var pos = mgDataViewer.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    contextMenuOpenTable.Items.Add(mgDataViewer.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText.Split("+").First(), imgListData.Images["ShowDataPreview.png"], ShowSelectedTableInDataGridView);
                    contextMenuOpenTable.Items.Add(mgDataViewer.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText.Split("+").Last(), imgListData.Images["ShowDataPreview.png"], ShowSelectedTableInDataGridView);
                    contextMenuOpenTable.Show(mgDataViewer, new Point(pos.X+10, pos.Y+10));
                }
                else
                {
                    var button = (DataGridViewButtonCell)mgDataViewer.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    string text = button.ToolTipText;
                    ShowTable(text);
                }
            }

            if (e.RowIndex != -1 && e.ColumnIndex == mgDataViewer.Columns["dataExcel"].Index && mgDataViewer.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType().Name == "DataGridViewButtonCell")
            {
                switch(Convert.ToString(mgDataViewer.Rows[e.RowIndex].Cells["TariffZone"].Value)[0].ToString())
                {
                    case "1":
                        try
                        {
                            openFormType1(e.RowIndex);
                        }
                        catch (Exception ex) { Console.WriteLine(ex); }
                        break; 

                    case "2":
                        try
                        {
                            openFormType2(e.RowIndex);
                        }
                        catch(Exception ex) { Console.WriteLine(ex); }
                        break;
                        
                    case "3":
                        try
                        {
                            openFormType3(e.RowIndex);
                        }
                        catch(Exception ex) { Console.WriteLine(ex); }
                        break;
                        
                    default:
                        Console.Error.WriteLine("Ќе удалось определить ценовую категорию.");
                        break;
                }
            }
        }




        private void openFormType1(int eRowIndex)
        {
            FormType1 formType1 = new FormType1();
            List<RadioButton> radioButtons = new List<RadioButton> { formType1.useIntervals, formType1.useHours };

            DateTime date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddSeconds(-1);

            string hrsTable = null;
            string intgTable = null;
            if (!mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.ToString().Contains('+'))
            {
                switch (mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("_").First())
                {
                    case "intg":
                        intgTable = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText);
                        break;

                    case "hrs":
                        hrsTable = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText);
                        break;
                }
            }
            else
            {
                switch (mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("+").First().Split("_").First())
                {
                    case "intg":
                        intgTable = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("+").First());
                        break;

                    case "hrs":
                        hrsTable = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("+").First());
                        break;
                }
                switch (mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("+").Last().Split("_").First())
                {
                    case "intg":
                        intgTable = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("+").Last());
                        break;

                    case "hrs":
                        hrsTable = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("+").Last());
                        break;
                }
            }

            int kTC = 1;
            int kTV = 1;


            switch (cmbxMethod.Text)
            {
                case "»нтервалы":
                    formType1.useIntervals.Checked = true;
                    kTC = Convert.ToInt32(IntegralsDataSet.Tables[intgTable + "_Header"].Rows[4][1].ToString().Split("/").First());
                    kTV = Convert.ToInt32(IntegralsDataSet.Tables[intgTable + "_Header"].Rows[4][1].ToString().Split("/").Last());
                    if (cmbxMethod.Items.Count != 2)
                    {
                        formType1.useHours.Enabled = false;
                    }
                    break;

                case "„асы":
                    formType1.useHours.Checked = true;
                    kTC = Convert.ToInt32(HoursDataSet.Tables[hrsTable + "_Header"].Rows[4][1].ToString().Split("/").First());
                    kTV = Convert.ToInt32(HoursDataSet.Tables[hrsTable + "_Header"].Rows[4][1].ToString().Split("/").Last());
                    if (cmbxMethod.Items.Count != 2)
                    {
                        formType1.useIntervals.Enabled = false;
                    }
                    break;
            }

            var checkedButton = radioButtons.FirstOrDefault(r => r.Checked);
            int kT = kTC * kTV;

            int RowInDict = SearchDGV(DictionaryForm.dataGridDictionaryList, mgDataViewer.Rows[eRowIndex].Cells["FullName"].Value.ToString(), "FullName");

            formType1.lblAbonentName.Text = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["FullName"].Value);
            formType1.lblAbonentINN.Text = Convert.ToString(DictionaryForm.dataGridDictionaryList.Rows[RowInDict].Cells["INN"].Value);
            formType1.lblAbonentAddress.Text = Convert.ToString(DictionaryForm.dataGridDictionaryList.Rows[RowInDict].Cells["Address"].Value);
            formType1.lblAbonentNumberCC.Text = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["NumCC"].Value);
            formType1.lblAbonentType.Text = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["type"].Value);
            formType1.lblAbonentKF.Text = (kT).ToString();
            formType1.lblAbonentTarif.Text = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["TariffZone"].Value);
            formType1.lblAbonentDateDay.Text = firstDayOfMonth.ToString("dd");
            formType1.lblAbonentDateMonth.Text = date.ToString("MMMM");
            formType1.lblAbonentDateYear.Text = date.ToString("yyyy");

            formType1.InfoTableLayout.RowStyles[2].Height = TextRenderer.MeasureText(formType1.lblAbonentAddress.Text, formType1.lblAbonentAddress.Font, formType1.lblAbonentAddress.ClientSize, TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl).Height + 10;

            formType1.txtDateFirst.Text = firstDayOfMonth.ToString("d");
            formType1.txtDateLast.Text = lastDayOfMonth.ToString("d");

            decimal SumConFirst = 0;
            decimal SumConLast = 0;
            decimal SumConDiff = 0;
            decimal SumGenFirst = 0;
            decimal SumGenLast = 0;
            decimal SumGenDiff = 0;

            if (intgTable != null && Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["intgStatusError"].Value) != CheckState.Checked.ToString())
            {
                foreach (DataRow rows in IntegralsDataSet.Tables[intgTable].Rows)
                {
                    if (rows[1].ToString() != "—умма")
                    {
                        switch (rows[0].ToString())
                        {
                            case "A+, к¬т*ч":
                                SumConFirst += decimal.Parse(rows[2].ToString());
                                SumConLast += decimal.Parse(rows[3].ToString());
                                break;

                            case "A-, к¬т*ч":
                                SumGenFirst += decimal.Parse(rows[2].ToString());
                                SumGenLast += decimal.Parse(rows[3].ToString());
                                break;
                        }
                    }
                    else
                    {
                        switch (rows[0].ToString())
                        {
                            case "A+, к¬т*ч":
                                SumConFirst = decimal.Parse(rows[2].ToString());
                                SumConLast = decimal.Parse(rows[3].ToString());
                                break;

                            case "A-, к¬т*ч":
                                SumGenFirst = decimal.Parse(rows[2].ToString());
                                SumGenLast = decimal.Parse(rows[3].ToString());
                                break;
                        }
                    }
                }

                SumConDiff = Math.Round(((SumConLast - SumConFirst) * kT), 3);
                SumGenDiff = Math.Round(((SumGenLast - SumGenFirst) * kT), 3);

                formType1.txtConFirst.Text = Math.Round(SumConFirst, 3).ToString();
                formType1.txtConLast.Text = Math.Round(SumConLast, 3).ToString();
                formType1.txtGenFirst.Text = Math.Round(SumGenFirst, 3).ToString();
                formType1.txtGenLast.Text = Math.Round(SumGenLast, 3).ToString();

                formType1.txtConSumm.Text = SumConDiff.ToString();
                formType1.txtGenSumm.Text = SumGenDiff.ToString();
            }

            int hrs = 1;
            decimal ConSumm = 0;
            decimal GenSumm = 0;

            if (hrsTable != null && Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["hrsStatusError"].Value) != CheckState.Checked.ToString())
            {
                formType1.dataHoursViewer.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DataHoursViewer_RowPrePaint);

                foreach (DataRow rows in HoursDataSet.Tables[hrsTable].Rows)
                {
                    if (hrs <= 24)
                    {
                        string duration = (hrs - 1).ToString() + ":00-" + hrs.ToString() + ":00";
                        formType1.dataHoursViewer.Rows.Add(rows[0], duration, rows[2], rows[3]);

                        ConSumm += Convert.ToDecimal(rows[2].ToString());
                        GenSumm += Convert.ToDecimal(rows[3].ToString());
                        hrs++;
                    }
                    else
                    {
                        hrs = 1;
                        string duration = (hrs - 1).ToString() + ":00-" + hrs.ToString() + ":00";
                        formType1.dataHoursViewer.Rows.Add(rows[0], duration, rows[2], rows[3]);

                        ConSumm += Convert.ToDecimal(rows[2].ToString());
                        GenSumm += Convert.ToDecimal(rows[3].ToString());
                        hrs++;
                    }
                }

                ConSumm = Math.Round(ConSumm * kT, 3);
                GenSumm = Math.Round(GenSumm * kT, 3);

                formType1.txtConSummHH.Text = ConSumm.ToString();
                formType1.txtGenSummHH.Text = GenSumm.ToString();
            }


            decimal intgDiffSell = 0;
            decimal intgDiffBuy = 0;
            decimal hrsDiffSell = 0;
            decimal hrsDiffBuy = 0;

            try
            {
                switch (checkedButton.Name)
                {
                    case "useIntervals":
                        if(SumConDiff> SumGenDiff)
                        {
                            intgDiffSell = Math.Round((SumConDiff - SumGenDiff), 0);
                        }
                        else
                        {
                            intgDiffBuy = Math.Round((SumGenDiff - SumConDiff), 0);
                        }
                        formType1.txtSELL.Text = intgDiffSell.ToString();
                        formType1.txtBUY.Text = intgDiffBuy.ToString();
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
                        formType1.txtSELL.Text = hrsDiffSell.ToString();
                        formType1.txtBUY.Text = hrsDiffBuy.ToString();
                        break;
                }
            }
            catch (Exception ex)
            {

            }


            formType1.txtsvncEEorem.Text = datsTreeView.Nodes["treeViewLine3"].Nodes["treeViewLine3e1val"].Text;
            formType1.txtsvncPorem.Text = datsTreeView.Nodes["treeViewLine2"].Nodes["treeViewLine2e1val"].Text;
            formType1.txtKF1.Text = datsTreeView.Nodes["treeViewLine1"].Nodes["treeViewLine1e1val"].Text;


            decimal k1 = 0;
            decimal k2 = 0;
            decimal k3 = 0;

            try
            {
                k1 = decimal.Parse(formType1.txtsvncEEorem.Text);
                k2 = decimal.Parse(formType1.txtsvncPorem.Text);
                k3 = decimal.Parse(formType1.txtKF1.Text);
            }
            catch
            {

            }

            decimal Price = 0;
            decimal ResultCost = 0;

            Price = Math.Round(((k1 + k2 * k3) / 1000), 5);
            ResultCost = Price * decimal.Parse(formType1.txtBUY.Text);

            formType1.txtResultPrice.Text = Price.ToString();
            formType1.txtResultCost.Text = Math.Round(ResultCost, 2).ToString();

            formType1.Show();
        }

        private void openFormType2(int eRowIndex)
        {
            FormType2 formType2 = new FormType2();
            List<RadioButton> radioButtons = new List<RadioButton> { formType2.useIntervals, formType2.useHours };


            DateTime date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddSeconds(-1);

            string hrsTable = null;
            string intgTable = null;
            if (!mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.ToString().Contains('+'))
            {
                switch (mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("_").First())
                {
                    case "intg":
                        intgTable = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText);
                        break;

                    case "hrs":
                        hrsTable = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText);
                        break;
                }
            }
            else
            {
                switch (mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("+").First().Split("_").First())
                {
                    case "intg":
                        intgTable = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("+").First());
                        break;

                    case "hrs":
                        hrsTable = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("+").First());
                        break;
                }
                switch (mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("+").Last().Split("_").First())
                {
                    case "intg":
                        intgTable = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("+").Last());
                        break;

                    case "hrs":
                        hrsTable = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("+").Last());
                        break;
                }
            }


            int kTC = 1;
            int kTV = 1;

            switch (cmbxMethod.Text)
            {
                case "»нтервалы":
                    formType2.useIntervals.Checked = true;
                    kTC = Convert.ToInt32(IntegralsDataSet.Tables[intgTable + "_Header"].Rows[4][1].ToString().Split("/").First());
                    kTV = Convert.ToInt32(IntegralsDataSet.Tables[intgTable + "_Header"].Rows[4][1].ToString().Split("/").Last());
                    if (cmbxMethod.Items.Count != 2)
                    {
                        formType2.useHours.Enabled = false;
                    }
                    break;

                case "„асы":
                    formType2.useHours.Checked = true;
                    kTC = Convert.ToInt32(HoursDataSet.Tables[hrsTable + "_Header"].Rows[4][1].ToString().Split("/").First());
                    kTV = Convert.ToInt32(HoursDataSet.Tables[hrsTable + "_Header"].Rows[4][1].ToString().Split("/").Last());
                    if (cmbxMethod.Items.Count != 2)
                    {
                        formType2.useIntervals.Enabled = false;
                    }
                    break;
            }

            var checkedButton = radioButtons.FirstOrDefault(r => r.Checked);
            int kT = kTC * kTV;

            int RowInDict = SearchDGV(DictionaryForm.dataGridDictionaryList, mgDataViewer.Rows[eRowIndex].Cells["FullName"].Value.ToString(), "FullName");

            formType2.lblAbonentName.Text = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["FullName"].Value);
            formType2.lblAbonentINN.Text = Convert.ToString(DictionaryForm.dataGridDictionaryList.Rows[RowInDict].Cells["INN"].Value);
            formType2.lblAbonentAddress.Text = Convert.ToString(DictionaryForm.dataGridDictionaryList.Rows[RowInDict].Cells["Address"].Value);
            formType2.lblAbonentNumberCC.Text = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["NumCC"].Value);
            formType2.lblAbonentType.Text = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["type"].Value);
            formType2.lblAbonentKF.Text = (kT).ToString();
            formType2.lblAbonentTarif.Text = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["TariffZone"].Value);
            formType2.lblAbonentDateDay.Text = firstDayOfMonth.ToString("dd");
            formType2.lblAbonentDateMonth.Text = date.ToString("MMMM");
            formType2.lblAbonentDateYear.Text = date.ToString("yyyy");

            formType2.InfoTableLayout.RowStyles[2].Height = TextRenderer.MeasureText(formType2.lblAbonentAddress.Text, formType2.lblAbonentAddress.Font, formType2.lblAbonentAddress.ClientSize, TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl).Height + 10;

            formType2.txtDateFirst.Text = firstDayOfMonth.ToString("d");
            formType2.txtDateLast.Text = lastDayOfMonth.ToString("d");

            decimal SumConFirst = 0;
            decimal SumConLast = 0;
            decimal SumGenFirst = 0;
            decimal SumGenLast = 0;

            decimal ConSummDayDiff = 0;
            decimal ConSummNightDiff = 0;
            decimal GenSummDayDiff = 0;
            decimal GenSummNightDiff = 0;


            if (intgTable != null && Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["intgStatusError"].Value) != CheckState.Checked.ToString())
            {
                decimal txtConDayFirst = 0;
                decimal txtConDayLast = 0;
                decimal txtConNightFirst = 0;
                decimal txtConNightLast = 0;

                decimal txtGenDayFirst = 0;
                decimal txtGenDayLast = 0;
                decimal txtGenNightFirst = 0;
                decimal txtGenNightLast = 0;

                try
                {
                    txtConDayFirst = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[0][2]));
                    txtConDayLast = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[0][3]));
                    txtConNightFirst = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[1][2]));
                    txtConNightLast = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[1][3]));

                    txtGenDayFirst = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[2][2]));
                    txtGenDayLast = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[2][3]));
                    txtGenNightFirst = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[3][2]));
                    txtGenNightLast = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[3][3]));
                }
                catch (Exception ex){}

                formType2.txtConDayFirst.Text = Math.Round(txtConDayFirst,3).ToString();
                formType2.txtConDayLast.Text = Math.Round(txtConDayLast,3).ToString();
                formType2.txtConNightFirst.Text = Math.Round(txtConNightFirst,3).ToString();
                formType2.txtConNightLast.Text = Math.Round(txtConNightLast,3).ToString();

                ConSummDayDiff = decimal.Parse(IntegralsDataSet.Tables[intgTable].Rows[0][4].ToString())*kT;
                ConSummNightDiff = decimal.Parse(IntegralsDataSet.Tables[intgTable].Rows[1][4].ToString())*kT;

                formType2.txtConDayDiff.Text = Math.Round(ConSummDayDiff,3).ToString();
                formType2.txtConNightDiff.Text = Math.Round(ConSummNightDiff,3).ToString();

                SumConFirst = txtConDayFirst + txtConNightFirst;
                SumConLast = txtConDayLast + txtConNightLast;

                formType2.txtGenDayFirst.Text = Math.Round(txtGenDayFirst,3).ToString();
                formType2.txtGenDayLast.Text = Math.Round(txtGenDayLast,3).ToString();
                formType2.txtGenNightFirst.Text = Math.Round(txtGenNightFirst,3).ToString();
                formType2.txtGenNightLast.Text = Math.Round(txtGenNightLast,3).ToString();
                
                GenSummDayDiff = decimal.Parse(IntegralsDataSet.Tables[intgTable].Rows[2][4].ToString())*kT;
                GenSummNightDiff = decimal.Parse(IntegralsDataSet.Tables[intgTable].Rows[3][4].ToString())*kT;

                formType2.txtGenDayDiff.Text = Math.Round(GenSummDayDiff,3).ToString();
                formType2.txtGenNightDiff.Text = Math.Round(GenSummNightDiff,3).ToString();

                SumGenFirst = txtGenDayFirst + txtGenNightFirst;
                SumGenLast = txtGenDayLast + txtGenNightLast;

                formType2.txtConSummFirst.Text = Math.Round((SumConFirst * kT), 3).ToString();
                formType2.txtConSummLast.Text = Math.Round((SumConLast * kT), 3).ToString();
                formType2.txtConSummDiff.Text = Math.Round(((SumConLast - SumConFirst) * kT), 3).ToString();

                formType2.txtGenSummFirst.Text = Math.Round((SumGenFirst * kT), 3).ToString();
                formType2.txtGenSummLast.Text = Math.Round((SumGenLast * kT), 3).ToString();
                formType2.txtGenSummDiff.Text = Math.Round(((SumGenLast - SumGenFirst) * kT), 3).ToString();
            }



            int hrs = 1;
            decimal ConSummDay = 0;
            decimal ConSummNight = 0;
            decimal GenSummDay = 0;
            decimal GenSummNight = 0;

            TimeSpan dayStart = new TimeSpan(mgSettings.mgHoursDoubleTariffZone.day.initial, 0, 0);
            TimeSpan dayEnd = new TimeSpan(mgSettings.mgHoursDoubleTariffZone.day.final, 0, 0);

            if (hrsTable != null && Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["hrsStatusError"].Value) != CheckState.Checked.ToString())
            {
                formType2.dataHoursViewer.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DataHoursViewer_RowPrePaint);

                foreach (DataRow rows in HoursDataSet.Tables[hrsTable].Rows)
                {
                    if (hrs <= 24)
                    {
                        string duration = (hrs - 1).ToString() + ":00-" + hrs.ToString() + ":00";
                        if (TimeIsBetween(hrs, dayStart, dayEnd))
                        {
                            formType2.dataHoursViewer.Rows.Add(rows[0], duration, rows[2], null, rows[3], null);
                            ConSummDay += Convert.ToDecimal(rows[2].ToString());
                            GenSummDay += Convert.ToDecimal(rows[3].ToString());
                        }
                        else
                        {
                            formType2.dataHoursViewer.Rows.Add(rows[0], duration, null, rows[2], null, rows[3]);
                            ConSummNight += Convert.ToDecimal(rows[2].ToString());
                            GenSummNight += Convert.ToDecimal(rows[3].ToString());
                        }
                        hrs++;
                    }
                    else
                    {
                        hrs = 1;
                        string duration = (hrs - 1).ToString() + ":00-" + hrs.ToString() + ":00";
                        if (TimeIsBetween(hrs, dayStart, dayEnd))
                        {
                            formType2.dataHoursViewer.Rows.Add(rows[0], duration, rows[2], null, rows[3], null);
                            ConSummDay += Convert.ToDecimal(rows[2].ToString());
                            GenSummDay += Convert.ToDecimal(rows[3].ToString());
                        }
                        else
                        {
                            formType2.dataHoursViewer.Rows.Add(rows[0], duration, null, rows[2], null, rows[3]);
                            ConSummNight += Convert.ToDecimal(rows[2].ToString());
                            GenSummNight += Convert.ToDecimal(rows[3].ToString());
                        }
                        hrs++;
                    }
                }

                ConSummDay = Math.Round(ConSummDay * kT, 3);
                ConSummNight = Math.Round(ConSummNight * kT, 3);
                GenSummDay = Math.Round(GenSummDay * kT, 3);
                GenSummNight = Math.Round(GenSummNight * kT, 3);

                formType2.txtConSummDayHH.Text = ConSummDay.ToString();
                formType2.txtGenSummDayHH.Text = GenSummDay.ToString();
                formType2.txtConSummNightHH.Text = ConSummNight.ToString();
                formType2.txtGenSummNightHH.Text = GenSummNight.ToString();
            }


            formType2.txtDiffEEoremNight.Text = datsTreeView.Nodes["treeViewLine5"].Nodes["treeViewLine5e1"].Nodes["treeViewLine5e1val"].Text;
            formType2.txtDiffEEoremDay.Text = datsTreeView.Nodes["treeViewLine5"].Nodes["treeViewLine5e2"].Nodes["treeViewLine5e2val"].Text;

            formType2.txtSvncPorem.Text = datsTreeView.Nodes["treeViewLine2"].Nodes["treeViewLine2e1val"].Text;

            formType2.txtKFnight.Text = datsTreeView.Nodes["treeViewLine7"].Nodes["treeViewLine7e1"].Nodes["treeViewLine7e1val"].Text;
            formType2.txtKFday.Text = datsTreeView.Nodes["treeViewLine7"].Nodes["treeViewLine7e2"].Nodes["treeViewLine7e2val"].Text;

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

                        if(ConSummNightDiff > GenSummNightDiff)
                        {
                            intgDiffSellNight = ConSummNightDiff - GenSummNightDiff;
                        }
                        else
                        {
                            intgDiffBuyNight = GenSummNightDiff - ConSummNightDiff;
                        }

                        formType2.txtSELLday.Text = Math.Round(intgDiffSellDay,0).ToString();
                        formType2.txtSELLnight.Text = Math.Round(intgDiffSellNight,0).ToString();
                        formType2.txtBUYday.Text = Math.Round(intgDiffBuyDay,0).ToString();
                        formType2.txtBUYnight.Text = Math.Round(intgDiffBuyNight,0).ToString();

                        formType2.lblSell.Text = Math.Round((intgDiffSellDay + intgDiffSellNight),0).ToString();
                        formType2.lblBuy.Text = Math.Round((intgDiffBuyDay + intgDiffBuyNight),0).ToString();
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

                        formType2.txtSELLday.Text = Math.Round(hrsDiffSellDay,0).ToString();
                        formType2.txtSELLnight.Text = Math.Round(hrsDiffSellNight,0).ToString();
                        formType2.txtBUYday.Text = Math.Round(hrsDiffBuyDay,0).ToString();
                        formType2.txtBUYnight.Text = Math.Round(hrsDiffBuyNight,0).ToString();

                        formType2.lblSell.Text = Math.Round((hrsDiffSellDay + hrsDiffSellNight),0).ToString();
                        formType2.lblBuy.Text = Math.Round((hrsDiffBuyDay + hrsDiffBuyNight),0).ToString();
                        break;
                }
            }
            catch(Exception ex)
            {

            }

            decimal PriceNight = 0;
            decimal PriceDay = 0;
            decimal ResultCost = 0;

            try
            {
                k1 = decimal.Parse(formType2.txtDiffEEoremNight.Text);
                k2 = decimal.Parse(formType2.txtDiffEEoremDay.Text);

                k3 = decimal.Parse(formType2.txtSvncPorem.Text);

                k4 = decimal.Parse(formType2.txtKFnight.Text);
                k5 = decimal.Parse(formType2.txtKFday.Text);


                PriceNight = Math.Round((k1 + (k3 * k4)) / 1000,5);
                PriceDay = Math.Round((k2 + (k3 * k5)) / 1000,5);

                ResultCost = PriceNight * decimal.Parse(formType2.txtBUYnight.Text) + PriceDay * decimal.Parse(formType2.txtBUYday.Text);

                formType2.txtResultPriceNight.Text = PriceNight.ToString();
                formType2.txtResultPriceDay.Text = PriceDay.ToString();
                formType2.txtResultCost.Text = Math.Round(ResultCost,2).ToString();
            }
            catch
            {

            }

            formType2.Show();
        }

        private void DataHoursViewer_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var tablesDataGridView = (DoubleBufferedDataGridView)sender;

            int lim1 = 0;
            int lim2 = 0;
            int start = 0;

            foreach (DataGridViewRow rows in tablesDataGridView.Rows)
            {
                if (start >= 24)
                {
                    if (lim1 < 24)
                    {
                        rows.DefaultCellStyle.BackColor = Color.LightGray;
                        lim1++;
                        lim2++;
                    }
                    else if (lim2 != 47)
                    {
                        lim2++;
                    }
                    else
                    {
                        lim1 = 0;
                        lim2 = 0;
                    }
                }
                else
                {
                    start++;
                }
            }
            tablesDataGridView.ClearSelection();
            tablesDataGridView.RowPrePaint -= new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DataHoursViewer_RowPrePaint);
        }

        private void openFormType3(int eRowIndex)
        {
            FormType3 formType3 = new FormType3();

            List<RadioButton> radioButtons = new List<RadioButton> { formType3.useIntervals, formType3.useHours };

            DateTime date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddSeconds(-1);

            string hrsTable = null;
            string intgTable = null;
            if (!mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.ToString().Contains('+'))
            {
                switch (mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("_").First())
                {
                    case "intg":
                        intgTable = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText);
                        break;

                    case "hrs":
                        hrsTable = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText);
                        break;
                }
            }
            else
            {
                switch (mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("+").First().Split("_").First())
                {
                    case "intg":
                        intgTable = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("+").First());
                        break;

                    case "hrs":
                        hrsTable = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("+").First());
                        break;
                }
                switch (mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("+").Last().Split("_").First())
                {
                    case "intg":
                        intgTable = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("+").Last());
                        break;

                    case "hrs":
                        hrsTable = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["dataTable"].ToolTipText.Split("+").Last());
                        break;
                }
            }

            int kTC = 1;
            int kTV = 1;

            switch (cmbxMethod.Text)
            {
                case "»нтервалы":
                    formType3.useIntervals.Checked = true;
                    kTC = Convert.ToInt32(IntegralsDataSet.Tables[intgTable + "_Header"].Rows[4][1].ToString().Split("/").First());
                    kTV = Convert.ToInt32(IntegralsDataSet.Tables[intgTable + "_Header"].Rows[4][1].ToString().Split("/").Last());
                    if (cmbxMethod.Items.Count != 2)
                    {
                        formType3.useHours.Enabled = false;
                    }
                    break;

                case "„асы":
                    formType3.useHours.Checked = true;
                    kTC = Convert.ToInt32(HoursDataSet.Tables[hrsTable + "_Header"].Rows[4][1].ToString().Split("/").First());
                    kTV = Convert.ToInt32(HoursDataSet.Tables[hrsTable + "_Header"].Rows[4][1].ToString().Split("/").Last());
                    if (cmbxMethod.Items.Count != 2)
                    {
                        formType3.useIntervals.Enabled = false;
                    }
                    break;
            }


            var checkedButton = radioButtons.FirstOrDefault(r => r.Checked);
            int kT = kTC * kTV;

            int RowInDict = SearchDGV(DictionaryForm.dataGridDictionaryList, mgDataViewer.Rows[eRowIndex].Cells["FullName"].Value.ToString(), "FullName");

            formType3.lblAbonentName.Text = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["FullName"].Value);
            formType3.lblAbonentINN.Text = Convert.ToString(DictionaryForm.dataGridDictionaryList.Rows[RowInDict].Cells["INN"].Value);
            formType3.lblAbonentAddress.Text = Convert.ToString(DictionaryForm.dataGridDictionaryList.Rows[RowInDict].Cells["Address"].Value);
            formType3.lblAbonentNumberCC.Text = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["NumCC"].Value);
            formType3.lblAbonentType.Text = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["type"].Value);
            formType3.lblAbonentKF.Text = (kT).ToString();
            formType3.lblAbonentTarif.Text = Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["TariffZone"].Value);
            formType3.lblAbonentDateDay.Text = firstDayOfMonth.ToString("dd");
            formType3.lblAbonentDateMonth.Text = date.ToString("MMMM");
            formType3.lblAbonentDateYear.Text = date.ToString("yyyy");

            formType3.InfoTableLayout.RowStyles[2].Height = TextRenderer.MeasureText(formType3.lblAbonentAddress.Text, formType3.lblAbonentAddress.Font, formType3.lblAbonentAddress.ClientSize, TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl).Height + 10;

            formType3.txtDateFirst.Text = firstDayOfMonth.ToString("d");
            formType3.txtDateLast.Text = lastDayOfMonth.ToString("d");

            decimal SumConFirst = 0;
            decimal SumConLast = 0;
            decimal SumGenFirst = 0;
            decimal SumGenLast = 0;

            decimal ConPeakDiff = 0;
            decimal ConSemiPeakDiff = 0;
            decimal ConNightDiff = 0;

            decimal GenPeakDiff = 0;
            decimal GenSemiPeakDiff = 0;
            decimal GenNightDiff = 0;

            if (intgTable != null && Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["intgStatusError"].Value) != CheckState.Checked.ToString())
            {
                decimal txtConPeakFirst = 0;
                decimal txtConPeakLast = 0;
                decimal txtConSemiPeakFirst = 0;
                decimal txtConSemiPeakLast = 0;
                decimal txtConNightFirst = 0;
                decimal txtConNightLast = 0;

                decimal txtGenPeakFirst = 0;
                decimal txtGenPeakLast = 0;
                decimal txtGenSemiPeakFirst = 0;
                decimal txtGenSemiPeakLast = 0;
                decimal txtGenNightFirst = 0;
                decimal txtGenNightLast = 0;

                try
                {
                    txtConPeakFirst = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[0][2]));
                    txtConPeakLast = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[0][3]));
                    txtConSemiPeakFirst = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[1][2]));
                    txtConSemiPeakLast = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[1][3]));
                    txtConNightFirst = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[2][2]));
                    txtConNightLast = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[2][3]));

                    txtGenPeakFirst = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[3][2]));
                    txtGenPeakLast = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[3][3]));
                    txtGenSemiPeakFirst = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[4][2]));
                    txtGenSemiPeakLast = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[4][3]));
                    txtGenNightFirst = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[5][2]));
                    txtGenNightLast = decimal.Parse(Convert.ToString(IntegralsDataSet.Tables[intgTable].Rows[5][3]));
                }
                catch (Exception ex) { }

                formType3.txtConPeakFirst.Text = txtConPeakFirst.ToString();
                formType3.txtConPeakLast.Text = txtConPeakLast.ToString();
                formType3.txtConSemiPeakFirst.Text = txtConSemiPeakFirst.ToString();
                formType3.txtConSemiPeakLast.Text = txtConSemiPeakLast.ToString();
                formType3.txtConNightFirst.Text = txtConNightFirst.ToString();
                formType3.txtConNightLast.Text = txtConNightLast.ToString();

                SumConFirst = txtConPeakFirst + txtConSemiPeakFirst + txtConNightFirst;
                SumConLast = txtConPeakLast + txtConSemiPeakLast + txtConNightLast;
                
                ConPeakDiff = decimal.Parse(IntegralsDataSet.Tables[intgTable].Rows[0][4].ToString())*kT;
                ConSemiPeakDiff = decimal.Parse(IntegralsDataSet.Tables[intgTable].Rows[1][4].ToString())*kT;
                ConNightDiff = decimal.Parse(IntegralsDataSet.Tables[intgTable].Rows[2][4].ToString())*kT;

                formType3.txtGenPeakFirst.Text = txtGenPeakFirst.ToString();
                formType3.txtGenPeakLast.Text = txtGenPeakLast.ToString();
                formType3.txtGenSemiPeakFirst.Text = txtGenSemiPeakFirst.ToString();
                formType3.txtGenSemiPeakLast.Text = txtGenSemiPeakLast.ToString();
                formType3.txtGenNightFirst.Text = txtGenNightFirst.ToString();
                formType3.txtGenNightLast.Text = txtGenNightLast.ToString();

                SumGenFirst = txtGenPeakFirst + txtGenSemiPeakFirst + txtGenNightFirst;
                SumGenLast = txtGenPeakLast + txtGenSemiPeakLast + txtGenNightLast;
                
                GenPeakDiff = decimal.Parse(IntegralsDataSet.Tables[intgTable].Rows[3][4].ToString())*kT;
                GenSemiPeakDiff = decimal.Parse(IntegralsDataSet.Tables[intgTable].Rows[4][4].ToString())*kT;
                GenNightDiff = decimal.Parse(IntegralsDataSet.Tables[intgTable].Rows[5][4].ToString())*kT;


                formType3.txtConSummFirst.Text = Math.Round((SumConFirst * kT), 3).ToString();
                formType3.txtConSummLast.Text = Math.Round((SumConLast * kT), 3).ToString();
                formType3.txtConSummDiff.Text = Math.Round(((SumConLast - SumConFirst) * kT), 3).ToString();

                formType3.txtGenSummFirst.Text = Math.Round((SumGenFirst * kT), 3).ToString();
                formType3.txtGenSummLast.Text = Math.Round((SumGenLast * kT), 3).ToString();
                formType3.txtGenSummDiff.Text = Math.Round(((SumGenLast - SumGenFirst) * kT), 3).ToString();
            }

            int hrs = 0;
            decimal ConSummPeak = 0;
            decimal ConSummSemiPeak = 0;
            decimal ConSummNight = 0;
            decimal GenSummPeak = 0;
            decimal GenSummSemiPeak = 0;
            decimal GenSummNight = 0;

            TimeSpan nightStart = new TimeSpan(mgSettings.mgHoursTripleTariffZone.night.initial,0,0);
            TimeSpan nightEnd = new TimeSpan(mgSettings.mgHoursTripleTariffZone.night.final, 0, 0);

            TimeSpan peakStart1 = new TimeSpan(mgSettings.mgHoursTripleTariffZone.peak.initial1, 0, 0);
            TimeSpan peakEnd1 = new TimeSpan(mgSettings.mgHoursTripleTariffZone.peak.final1, 0, 0);
            TimeSpan peakStart2 = new TimeSpan(mgSettings.mgHoursTripleTariffZone.peak.initial2, 0, 0);
            TimeSpan peakEnd2 = new TimeSpan(mgSettings.mgHoursTripleTariffZone.peak.final2, 0, 0);

            TimeSpan semiPeakStart1 = new TimeSpan(mgSettings.mgHoursTripleTariffZone.semiPeak.initial1, 0, 0);
            TimeSpan semiPeakEnd1 = new TimeSpan(mgSettings.mgHoursTripleTariffZone.semiPeak.final1, 0, 0);
            TimeSpan semiPeakStart2 = new TimeSpan(mgSettings.mgHoursTripleTariffZone.semiPeak.initial2, 0, 0);
            TimeSpan semiPeakEnd2 = new TimeSpan(mgSettings.mgHoursTripleTariffZone.semiPeak.final2, 0, 0);

            if (hrsTable != null && Convert.ToString(mgDataViewer.Rows[eRowIndex].Cells["hrsStatusError"].Value) != CheckState.Checked.ToString())
            {
                formType3.dataHoursViewer.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DataHoursViewer_RowPrePaint);

                foreach (DataRow rows in HoursDataSet.Tables[hrsTable].Rows)
                {
                    hrs++;
                    if (hrs <= 24)
                    {
                        string duration = (hrs - 1).ToString() + ":00-" + hrs.ToString() + ":00";
                        if (TimeIsBetween(hrs, peakStart1, peakEnd1))
                        {
                            formType3.dataHoursViewer.Rows.Add(rows[0], duration, rows[2], null, null, rows[3], null, null);
                            ConSummPeak += Convert.ToDecimal(rows[2].ToString());
                            GenSummPeak += Convert.ToDecimal(rows[3].ToString());
                            continue;
                        }
                        if (TimeIsBetween(hrs, peakStart2, peakEnd2))
                        {
                            formType3.dataHoursViewer.Rows.Add(rows[0], duration, rows[2], null, null, rows[3], null, null);
                            ConSummPeak += Convert.ToDecimal(rows[2].ToString());
                            GenSummPeak += Convert.ToDecimal(rows[3].ToString());
                            continue;
                        }
                        if (TimeIsBetween(hrs, semiPeakStart1, semiPeakEnd1))
                        {
                            formType3.dataHoursViewer.Rows.Add(rows[0], duration, null, rows[2], null, null, rows[3], null);
                            ConSummSemiPeak += Convert.ToDecimal(rows[2].ToString());
                            GenSummSemiPeak += Convert.ToDecimal(rows[3].ToString());
                            continue;
                        }
                        if (TimeIsBetween(hrs, semiPeakStart2, semiPeakEnd2))
                        {
                            formType3.dataHoursViewer.Rows.Add(rows[0], duration, null, rows[2], null, null, rows[3], null);
                            ConSummSemiPeak += Convert.ToDecimal(rows[2].ToString());
                            GenSummSemiPeak += Convert.ToDecimal(rows[3].ToString());
                            continue;
                        }
                        if (TimeIsBetween(hrs, nightStart, nightEnd))
                        {
                            formType3.dataHoursViewer.Rows.Add(rows[0], duration, null, null, rows[2], null, null, rows[3]);
                            ConSummNight += Convert.ToDecimal(rows[2].ToString());
                            GenSummNight += Convert.ToDecimal(rows[3].ToString());
                            continue;
                        }
                    }
                    else
                    {
                        hrs = 1;
                        string duration = (hrs - 1).ToString() + ":00-" + hrs.ToString() + ":00";
                        if (TimeIsBetween(hrs, peakStart1, peakEnd1))
                        {
                            formType3.dataHoursViewer.Rows.Add(rows[0], duration, rows[2], null, null, rows[3], null, null);
                            ConSummPeak += Convert.ToDecimal(rows[2].ToString());
                            GenSummPeak += Convert.ToDecimal(rows[3].ToString());
                            continue;
                        }
                        if (TimeIsBetween(hrs, peakStart2, peakEnd2))
                        {
                            formType3.dataHoursViewer.Rows.Add(rows[0], duration, rows[2], null, null, rows[3], null, null);
                            ConSummPeak += Convert.ToDecimal(rows[2].ToString());
                            GenSummPeak += Convert.ToDecimal(rows[3].ToString());
                            continue;
                        }
                        if (TimeIsBetween(hrs, semiPeakStart1, semiPeakEnd1))
                        {
                            formType3.dataHoursViewer.Rows.Add(rows[0], duration, null, rows[2], null, null, rows[3], null);
                            ConSummSemiPeak += Convert.ToDecimal(rows[2].ToString());
                            GenSummSemiPeak += Convert.ToDecimal(rows[3].ToString());
                            continue;
                        }
                        if (TimeIsBetween(hrs, semiPeakStart2, semiPeakEnd2))
                        {
                            formType3.dataHoursViewer.Rows.Add(rows[0], duration, null, rows[2], null, null, rows[3], null);
                            ConSummSemiPeak += Convert.ToDecimal(rows[2].ToString());
                            GenSummSemiPeak += Convert.ToDecimal(rows[3].ToString());
                            continue;
                        }
                        if (TimeIsBetween(hrs, nightStart, nightEnd))
                        {
                            formType3.dataHoursViewer.Rows.Add(rows[0], duration, null, null, rows[2], null, null, rows[3]);
                            ConSummNight += Convert.ToDecimal(rows[2].ToString());
                            GenSummNight += Convert.ToDecimal(rows[3].ToString());
                            continue;
                        }
                    }
                }

                ConSummPeak = Math.Round(ConSummPeak * kT, 3);
                ConSummSemiPeak = Math.Round(ConSummSemiPeak * kT, 3);
                ConSummNight = Math.Round(ConSummNight * kT, 3);
                GenSummPeak = Math.Round(GenSummPeak * kT, 3);
                GenSummSemiPeak = Math.Round(GenSummSemiPeak * kT, 3);
                GenSummNight = Math.Round(GenSummNight * kT, 3);

                formType3.txtConSummPeakHH.Text = ConSummPeak.ToString();
                formType3.txtConSummSemiPeakHH.Text = ConSummSemiPeak.ToString();
                formType3.txtConSummNightHH.Text = ConSummNight.ToString();
                formType3.txtGenSummPeakHH.Text = GenSummPeak.ToString();
                formType3.txtGenSummSemiPeakHH.Text = GenSummSemiPeak.ToString();
                formType3.txtGenSummNightHH.Text = GenSummNight.ToString();
            }
            

            formType3.txtDiffEEoremPeak.Text = datsTreeView.Nodes["treeViewLine4"].Nodes["treeViewLine4e1"].Nodes["treeViewLine4e1val"].Text;
            formType3.txtDiffEEoremSemiPeak.Text = datsTreeView.Nodes["treeViewLine4"].Nodes["treeViewLine4e2"].Nodes["treeViewLine4e2val"].Text;
            formType3.txtDiffEEoremNight.Text = datsTreeView.Nodes["treeViewLine4"].Nodes["treeViewLine4e3"].Nodes["treeViewLine4e3val"].Text;


            formType3.txtSvncPorem.Text = datsTreeView.Nodes["treeViewLine2"].Nodes["treeViewLine2e1val"].Text;

            formType3.txtKFpeak.Text = datsTreeView.Nodes["treeViewLine6"].Nodes["treeViewLine6e1"].Nodes["treeViewLine6e1val"].Text;
            formType3.txtKFsemiPeak.Text = datsTreeView.Nodes["treeViewLine6"].Nodes["treeViewLine6e2"].Nodes["treeViewLine6e2val"].Text;
            formType3.txtKFnight.Text = datsTreeView.Nodes["treeViewLine6"].Nodes["treeViewLine6e3"].Nodes["treeViewLine6e3val"].Text;


            decimal k1 = 0;
            decimal k2 = 0;
            decimal k3 = 0;

            decimal k4 = 0;

            decimal k5 = 0;
            decimal k6 = 0;
            decimal k7 = 0;

            decimal intgDiffSellPeak = 0;
            decimal intgDiffSellSemiPeak = 0;
            decimal intgDiffSellNight = 0;

            decimal intgDiffBuyPeak = 0;
            decimal intgDiffBuySemiPeak = 0;
            decimal intgDiffBuyNight = 0;

            decimal hrsDiffSellPeak = 0;
            decimal hrsDiffSellSemiPeak = 0;
            decimal hrsDiffSellNight = 0;

            decimal hrsDiffBuyPeak = 0;
            decimal hrsDiffBuySemiPeak = 0;
            decimal hrsDiffBuyNight = 0;

            try
            {
                switch (checkedButton.Name)
                {
                    case "useIntervals":
                        if (ConPeakDiff > GenPeakDiff)
                        {
                            intgDiffSellPeak = ConPeakDiff - GenPeakDiff;
                        }
                        else
                        {
                            intgDiffBuyPeak = GenPeakDiff - ConPeakDiff;
                        }

                        if (ConSemiPeakDiff > GenSemiPeakDiff)
                        {
                            intgDiffSellSemiPeak = ConSemiPeakDiff - GenSemiPeakDiff;
                        }
                        else
                        {
                            intgDiffBuySemiPeak = GenSemiPeakDiff - ConSemiPeakDiff;
                        }

                        if (ConNightDiff > GenNightDiff)
                        {
                            intgDiffSellNight = ConNightDiff - GenNightDiff;
                        }
                        else
                        {
                            intgDiffBuyNight = GenNightDiff - ConNightDiff;
                        }

                        formType3.txtSELLpeak.Text = Math.Round(intgDiffSellPeak,0).ToString();
                        formType3.txtSELLsemiPeak.Text = Math.Round(intgDiffSellSemiPeak,0).ToString();
                        formType3.txtSELLnight.Text = Math.Round(intgDiffSellNight,0).ToString();

                        formType3.txtBUYpeak.Text = Math.Round(intgDiffBuyPeak,0).ToString();
                        formType3.txtBUYsemiPeak.Text = Math.Round(intgDiffSellSemiPeak,0).ToString();
                        formType3.txtBUYnight.Text = Math.Round(intgDiffBuyNight,0).ToString();

                        formType3.lblSell.Text = (intgDiffSellPeak + intgDiffSellSemiPeak + intgDiffSellNight).ToString();
                        formType3.lblBuy.Text = (intgDiffBuyPeak + intgDiffSellSemiPeak + intgDiffBuyNight).ToString();
                        break;

                    case "useHours":
                        if (ConSummPeak > GenSummPeak)
                        {
                            hrsDiffSellPeak = ConSummPeak - GenSummPeak;
                        }
                        else
                        {
                            hrsDiffBuyPeak = GenSummPeak - ConSummPeak;
                        }

                        if (ConSummSemiPeak > GenSummSemiPeak)
                        {
                            hrsDiffSellSemiPeak = ConSummSemiPeak - GenSummSemiPeak;
                        }
                        else
                        {
                            hrsDiffBuySemiPeak = GenSummSemiPeak - ConSummSemiPeak;
                        }

                        if (ConSummNight > GenSummNight)
                        {
                            hrsDiffSellNight = ConSummNight - GenSummNight;
                        }
                        else
                        {
                            hrsDiffBuyNight = GenSummNight - ConSummNight;
                        }

                        formType3.txtSELLpeak.Text = Math.Round(hrsDiffSellPeak,0).ToString();
                        formType3.txtSELLsemiPeak.Text = Math.Round(hrsDiffSellSemiPeak,0).ToString();
                        formType3.txtSELLnight.Text = Math.Round(hrsDiffSellNight,0).ToString();

                        formType3.txtBUYpeak.Text = Math.Round(hrsDiffBuyPeak,0).ToString();
                        formType3.txtBUYsemiPeak.Text = Math.Round(hrsDiffBuySemiPeak, 0).ToString();
                        formType3.txtBUYnight.Text = Math.Round(hrsDiffBuyNight,0).ToString();

                        formType3.lblSell.Text = (hrsDiffSellPeak + hrsDiffSellSemiPeak + hrsDiffSellNight).ToString();
                        formType3.lblBuy.Text = (hrsDiffBuyPeak + hrsDiffBuySemiPeak + hrsDiffBuyNight).ToString();

                        break;
                }
            }
            catch (Exception ex)
            {

            }

            decimal PriceNight = 0;
            decimal PriceSemiPeak = 0;
            decimal PricePeak = 0;
            decimal ResultCost = 0;

            try
            {
                k1 = decimal.Parse(formType3.txtDiffEEoremNight.Text);
                k2 = decimal.Parse(formType3.txtDiffEEoremPeak.Text);
                k3 = decimal.Parse(formType3.txtDiffEEoremSemiPeak.Text);

                k4 = decimal.Parse(formType3.txtSvncPorem.Text);

                k5 = decimal.Parse(formType3.txtKFnight.Text);
                k6 = decimal.Parse(formType3.txtKFpeak.Text);
                k7 = decimal.Parse(formType3.txtKFsemiPeak.Text);


                PriceNight = Math.Round((k1 + (k4 * k5)) / 1000,5);
                PricePeak = Math.Round((k2 + (k4 * k6)) / 1000,5);
                PriceSemiPeak = Math.Round((k3 + (k4 * k7)) / 1000,5);

                ResultCost = PriceNight * decimal.Parse(formType3.txtBUYnight.Text) + PricePeak * decimal.Parse(formType3.txtBUYpeak.Text) + PriceSemiPeak * decimal.Parse(formType3.txtBUYsemiPeak.Text);

                formType3.txtResultPriceNight.Text = PriceNight.ToString();
                formType3.txtResultPricePeak.Text = PricePeak.ToString();
                formType3.txtResultPriceSemiPeak.Text = PriceSemiPeak.ToString();
                formType3.txtResultCost.Text = Math.Round(ResultCost, 2).ToString();
            }
            catch
            {

            }

            formType3.Show();
        }

        public static bool TimeIsBetween(int hrs, TimeSpan start, TimeSpan end)
        {
            var time = hrs;
            if (start.Hours <= end.Hours)
                return time > start.Hours && time <= end.Hours;
            return time > start.Hours || time <= end.Hours;
        }

        private void mainAutomaticResultProccess()
        {
            foreach (DataGridViewRow mainRows in mgDataViewer.Rows)
            {
                if (Convert.ToBoolean(mainRows.Cells["SelectID"].Value))
                {
                    if (mainRows.Cells["dataTable"].GetType().Name == "DataGridViewButtonCell")
                    {
                        
                    }
                }
            }
        }

        private void toolBtnStartProccess_Click(object sender, EventArgs e)
        {
            mainAutomaticResultProccess();
        }

        private void SettingsNewFormTablesResult(Form TableView, DataGridView tablesDataGridView, DataGridView headerDataGridView)
        {
            TableLayoutPanel layoutPanel = new TableLayoutPanel();

            TableView.Name = "TableViewer";
            
            TableView.WindowState = FormWindowState.Normal;
            TableView.FormBorderStyle = FormBorderStyle.Sizable;
            TableView.MaximizeBox = false;

            headerDataGridView.Dock = DockStyle.Fill;
            headerDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            headerDataGridView.Location = new Point(5, 40);
            headerDataGridView.ColumnHeadersVisible = false;
            headerDataGridView.RowHeadersVisible = false;
            headerDataGridView.ScrollBars = ScrollBars.Both;
            headerDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            headerDataGridView.RowTemplate.MinimumHeight = 18;
            headerDataGridView.RowTemplate.Height = 18;
            headerDataGridView.AllowUserToAddRows = false;
            headerDataGridView.AllowUserToDeleteRows = false;
            headerDataGridView.AllowUserToResizeRows = false;
            headerDataGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            headerDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            headerDataGridView.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            headerDataGridView.ReadOnly = true;
            headerDataGridView.EnableHeadersVisualStyles = false;
            headerDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            headerDataGridView.DefaultCellStyle.SelectionBackColor = headerDataGridView.DefaultCellStyle.BackColor;
            headerDataGridView.DefaultCellStyle.SelectionForeColor = headerDataGridView.DefaultCellStyle.ForeColor;

            headerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            headerDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            headerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            headerDataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            headerDataGridView.RowHeadersWidth = 70;

            tablesDataGridView.Dock = DockStyle.Fill;
            tablesDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            tablesDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tablesDataGridView.Location = new Point(5, 40);
            tablesDataGridView.ColumnHeadersVisible = true;
            tablesDataGridView.RowHeadersVisible = false;
            tablesDataGridView.ScrollBars = ScrollBars.Both;
            tablesDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tablesDataGridView.RowTemplate.MinimumHeight = 18;
            tablesDataGridView.RowTemplate.Height = 18;
            tablesDataGridView.AllowUserToAddRows = false;
            tablesDataGridView.AllowUserToDeleteRows = false;
            tablesDataGridView.AllowUserToResizeRows = false;
            tablesDataGridView.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            tablesDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            tablesDataGridView.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            tablesDataGridView.ReadOnly = true;
            tablesDataGridView.EnableHeadersVisualStyles = false;
            tablesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;

            tablesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            tablesDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            tablesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tablesDataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            tablesDataGridView.RowHeadersWidth = 70;

            layoutPanel.Dock = DockStyle.Fill;
            layoutPanel.ColumnCount = 1;
            layoutPanel.RowCount = 2;
            layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));

            TableView.Controls.Add(layoutPanel);
            layoutPanel.Controls.Add(headerDataGridView, 0, 0);
            layoutPanel.Controls.Add(tablesDataGridView,0,1);
        }


        private void toolBtnDictionaryEditor_Click(object sender, EventArgs e)
        {
            foreach (DataTable tbl in IntegralsDataSet.Tables)
            {
                if (tbl.Rows.Count > 0)
                {
                    Console.WriteLine(tbl.TableName);
                }
            }
        }


        public void urImportEXCL(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.DefaultExt = "*.xls;*.xlsx";
            ofd.Filter = "Microsoft Excel (*.xls*)|*.xls*";
            ofd.Title = "¬ыберите документ Excel";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string xlFileName = ofd.FileName;
            ExlFileName = Path.GetFileName(xlFileName);

            DataGridView urDt = dataViewer;
            dataViewer.DataSource = null;
            DataTable dataExtraction = new DataTable();
            DataTable DT = (DataTable)dataViewer.DataSource;
            if (DT != null)
                DT.Clear();

            dataViewer.Rows.Clear();
            dataViewer.Refresh();
            int count = this.dataViewer.Columns.Count;
            for (int i = 0; i < count; i++)
                this.dataViewer.Columns.RemoveAt(0);

            commonImportEXCL(this, new EventArgs(), dataExtraction, xlFileName);
            dataViewer.DataSource = dataExtraction;
            dataViewerFillHeadres(FirstUsedRow, FirstUsedColumn, urDt);
            FillStatusGrid(RowsCnt, ColsCnt);

            tempPropVal.Add(urProperty.cntHeadsRows);
            splitContainer_rightProps.Panel1Collapsed = false;
            SettingsForm.optionsGrid.Refresh();

            statusGridView.Rows[1].Cells[1].Value = ColsCnt;
            statusGridView.Rows[4].Cells[1].Value = 0;
            statusGridView.ClearSelection();

            dataViewer.AllowUserToAddRows = false;
            dataViewer.AllowUserToDeleteRows = false;
            dataViewer.EnableHeadersVisualStyles = false;

            dataViewer.MouseDown += new MouseEventHandler(dataViewer_MouseClick);
            dataViewer.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(DataViewer_RowSelected);
            dataViewer.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(DataViewer_ColumnsSelected);
            dataViewer.Update();
        }

        public void IteropModeImport(DataTable dataVariantB, string xlFileName)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWB;
            Excel.Worksheet xlSht;

            xlWB = xlApp.Workbooks.Open(xlFileName);

            int selectedIndexSht = 1;
            if (cmnSettings.showListExcelSheets)
            {
                using (ItemSelector extractedListForm = new ItemSelector())
                {
                    foreach (Excel.Worksheet wSheet in xlWB.Worksheets)
                    {
                        extractedListForm.sheetsList.Items.Add(wSheet.Name);
                    }
                    if (extractedListForm.sheetsList.Items.Count > 1)
                    {
                        if (extractedListForm.ShowDialog() == DialogResult.OK)
                        {
                            selectedIndexSht = extractedListForm.selectedIndexSheet + 1;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }

            xlSht = xlWB.Worksheets[selectedIndexSht];

            Excel.Range ExcelRange = xlSht.UsedRange;
            int xlRowCount = ExcelRange.Rows.Count;
            int xlColCount = ExcelRange.Columns.Count;
            RowsCnt = xlRowCount;
            ColsCnt = xlColCount;

            string Range = (ExcelRange.get_Address(true, true, Excel.XlReferenceStyle.xlR1C1, false, false).ToString().Split(':').First()).Split('R').Last();
            FirstUsedRow = Convert.ToInt32(Range.Split('C').First());
            FirstUsedColumn = Convert.ToInt32(Range.Split('C').Last());
            String SheetName = xlSht.Name;

            List<object> arguments = new List<object>();
            arguments.Add(dataVariantB);
            arguments.Add(xlRowCount);
            arguments.Add(xlColCount);
            arguments.Add(ExcelRange);

            bgWorker = new BackgroundWorker();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_Interop);

            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);

            bgWorker.RunWorkerAsync(arguments);

            progressDlg = new ProgressDialog();
            progressDlg.stopProgress = new EventHandler((s, e1) => {
                switch (progressDlg.DialogResult)
                {
                    case DialogResult.Cancel:
                        bgWorker.CancelAsync();
                        progressDlg.Close();
                        break;
                }
            });
            progressDlg.ShowDialog();

            if (cmnSettings.CheckEmptyRows.SwitchChecks == true)
            {
                CheckingRealDat(dataVariantB);
                xlRowCount = dataVariantB.Rows.Count;
                xlColCount = dataVariantB.Columns.Count;
            }

            xlWB.Close(false, false, false);
            xlApp.Quit();
            xlApp = null;
            xlWB = null;
            xlSht = null;
        }

        public void OLEDBModeImport(string xlFileName, DataTable dataVariantOLEDB)
        {
            string strConnect = string.Empty;
             string ExlVer = "12";
                    
            if (cmnSettings.OleDBImportMode.VersionOleDB == "Microsoft.Jet.OLEDB.4.0")    
                ExlVer = "8";
                    strConnect = @"Provider=" + cmnSettings.OleDBImportMode.VersionOleDB + ";" +
                                 @"Data Source=" + xlFileName + ";" +
                                 @"Extended Properties=" + Convert.ToChar(34).ToString() +
                                 @"Excel " + ExlVer + ".0;HDR=" + cmnSettings.OleDBImportMode.strHDR + ";IMEX=" + cmnSettings.OleDBImportMode.IMEX.ToString() + ";" + Convert.ToChar(34).ToString() + ";";

             int xlColCount = 0;

            using (OleDbConnection connect = new OleDbConnection(strConnect))
            {
                connect.Open();
                DataTable schemaTable = connect.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                int selectedIndexSht = 0;
                if (cmnSettings.showListExcelSheets)
                {
                    using (ItemSelector extractedListForm = new ItemSelector())
                    {
                        foreach (DataRow row in schemaTable.Rows)
                        {
                            if (!row["TABLE_NAME"].ToString().EndsWith("$") && !row["TABLE_NAME"].ToString().EndsWith("$'"))
                                continue;
                            extractedListForm.sheetsList.Items.Add(row["TABLE_NAME"].ToString());
                        }
                        if (extractedListForm.sheetsList.Items.Count > 1)
                        {
                            if (extractedListForm.ShowDialog() == DialogResult.OK)
                            {
                                selectedIndexSht = extractedListForm.selectedIndexSheet;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }

                string sheetName = schemaTable.Rows[selectedIndexSht]["TABLE_NAME"].ToString();
                OleDbCommand cmd = connect.CreateCommand();
                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                OleDbDataReader reader = cmd.ExecuteReader();



                dataVariantOLEDB.Load(reader);
                connect.Close();
                connect.Dispose();
            }

            xlColCount = dataVariantOLEDB.Columns.Count;
            RowsCnt = dataVariantOLEDB.Rows.Count;
        }

        public void EPPlusModeImport(DataTable dataExport, string xlFileName)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            FileInfo existingFile = new FileInfo(xlFileName);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                try
                {
                    using (var stream = File.OpenRead(xlFileName))
                    {
                        package.Load(stream);
                    }

                    int selectedIndexSht = 0;
                    if (cmnSettings.showListExcelSheets)
                    {
                        using (ItemSelector extractedListForm = new ItemSelector())
                        {
                            foreach (ExcelWorksheet ws in package.Workbook.Worksheets)
                            {
                                extractedListForm.sheetsList.Items.Add(ws.Name);
                            }
                            if (extractedListForm.sheetsList.Items.Count > 1)
                            {
                                if (extractedListForm.ShowDialog() == DialogResult.OK)
                                {
                                    selectedIndexSht = extractedListForm.selectedIndexSheet;
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }

                    ExcelWorksheet worksheet = package.Workbook.Worksheets[selectedIndexSht];
                    string ErrorMessage = string.Empty;
                    int xlColCount = worksheet.Dimension.End.Column;  //get Column Count
                    int xlRowCount = worksheet.Dimension.End.Row;     //get row count
                    RowsCnt = xlRowCount;
                    ColsCnt = xlColCount;

                    List<object> arguments = new List<object>();
                    arguments.Add(dataExport);
                    arguments.Add(xlRowCount);
                    arguments.Add(xlColCount);
                    arguments.Add(worksheet);

                    bgWorker = new BackgroundWorker();
                    bgWorker.WorkerReportsProgress = true;
                    bgWorker.WorkerSupportsCancellation = true;
                    bgWorker.DoWork += new DoWorkEventHandler(bgWorker_EEPlus);

                    bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
                    bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);

                    bgWorker.RunWorkerAsync(arguments);

                    progressDlg = new ProgressDialog();
                    progressDlg.stopProgress = new EventHandler((s, e1) => {
                        switch (progressDlg.DialogResult)
                        {
                            case DialogResult.Cancel:
                                bgWorker.CancelAsync();
                                progressDlg.Close();
                                break;
                        }
                    });
                    progressDlg.ShowDialog();

                    if (cmnSettings.CheckEmptyRows.SwitchChecks == true)
                    {
                        CheckingRealDat(dataExport);
                        xlRowCount = dataExport.Rows.Count;
                        xlColCount = dataExport.Columns.Count;
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Not working");
                }
            }
        }

        public void NPOIModeImport(DataTable dataExport, string xlFileName, ISheet wSheet, XSSFFormulaEvaluator xsseva, HSSFFormulaEvaluator hsseva)
        {
            DataRow xlrow = null;

            using (FileStream stream = new FileStream(xlFileName, FileMode.Open, FileAccess.Read))
            {

                FirstUsedRow = wSheet.FirstRowNum + 1;

                int xlRowCount = wSheet.PhysicalNumberOfRows;
                int xlColCount = (wSheet.GetRow(wSheet.FirstRowNum).LastCellNum - wSheet.GetRow(wSheet.FirstRowNum).FirstCellNum) + 1;
                RowsCnt = xlRowCount;
                ColsCnt = xlColCount;
                int cellCnt = 0;
                int ColCreat = 0;

                List<object> arguments = new List<object>();
                arguments.Add(dataExport);
                arguments.Add(xlRowCount);
                arguments.Add(xlColCount);
                arguments.Add(wSheet);
                arguments.Add(xsseva);
                arguments.Add(hsseva);
                arguments.Add(cellCnt);
                arguments.Add(ColCreat);
                arguments.Add(xlFileName);

                bgWorker = new BackgroundWorker();
                bgWorker.WorkerReportsProgress = true;
                bgWorker.WorkerSupportsCancellation = true;
                bgWorker.DoWork += new DoWorkEventHandler(bgWorker_NPOI);

                bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
                bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);

                bgWorker.RunWorkerAsync(arguments);

                progressDlg = new ProgressDialog();
                progressDlg.stopProgress = new EventHandler((s, e1) => {
                    switch (progressDlg.DialogResult)
                    {
                        case DialogResult.Cancel:
                            bgWorker.CancelAsync();
                            progressDlg.Close();
                            break;
                    }
                });
                progressDlg.ShowDialog();
            }
        }

        private void CheckingRealDat(DataTable ExportsDatTable)
        {
            List<DataRow> removeRowIndex = new List<DataRow>();
            int RowCounter = 0;
            int indexForStarts= 0;
            int RowEmptyStrike = 0;
            int ColmEmptyStrike = 0;
            int RowStrike = 0;
            int colStrike = 0;

            foreach (DataRow dRow in ExportsDatTable.Rows)
            {
                if (RowEmptyStrike <= cmnSettings.CheckEmptyRows.EmptyRowsLimit)
                {
                    colStrike = 0;
                    for (int index = 0; index < ExportsDatTable.Columns.Count; index++)
                    {
                        if (dRow[index] != DBNull.Value)
                        {
                            RowEmptyStrike = 0;
                            indexForStarts++;
                            continue;
                        }
                        else
                        {
                            indexForStarts++;
                            colStrike++;
                        }
                    }
                    if (colStrike == ExportsDatTable.Columns.Count)
                    {
                        RowEmptyStrike++;
                    }
                }
                else
                {
                    colStrike = 0;
                    for (int index = 0; index < ExportsDatTable.Columns.Count; index++)
                    {
                        if (dRow[index] != DBNull.Value)
                        {
                            break;
                        }
                        if (dRow[index] == DBNull.Value)
                        {
                            colStrike++;
                            if (colStrike == ExportsDatTable.Columns.Count)
                            {
                                removeRowIndex.Add(dRow);
                                break;
                            }
                        }
                        else if (string.IsNullOrEmpty(dRow[index].ToString().Trim()))
                        {
                            colStrike++;
                            if (colStrike == ExportsDatTable.Columns.Count)
                            {
                                removeRowIndex.Add(dRow);
                                break;
                            }
                        }
                    }
                }
            }


            foreach (DataRow rowIndex in removeRowIndex)
            {
                 ExportsDatTable.Rows.Remove(rowIndex);
            }


            for (int i = ExportsDatTable.Columns.Count - 1; i >= 0; i--)
            {
                DataColumn row = ExportsDatTable.Columns[i];
                if (ExportsDatTable.AsEnumerable().All(r => r.IsNull(row) || string.IsNullOrWhiteSpace(r[row].ToString())))
                {
                    ColmEmptyStrike++;
                    if (ColmEmptyStrike >= cmnSettings.CheckEmptyRows.EmptyColmLimit)
                        ExportsDatTable.Columns.RemoveAt(i);
                }
            }

        }

        private void backWorkerDialog()
        {
            bgWorker = new BackgroundWorker();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);

            bgWorker.RunWorkerAsync();

            progressDlg = new ProgressDialog();
            progressDlg.stopProgress = new EventHandler((s, e1) =>
            {
                switch (progressDlg.DialogResult)
                {
                    case DialogResult.Cancel:
                        bgWorker.CancelAsync();
                        progressDlg.Close();
                        break;
                }

            });
            progressDlg.ShowDialog();
        }

        private void dataViewerFillHeadres(int FirstUsedRow, int FirstUsedColumn, DataGridView dtViewer)
        {
            int RowIndex = Convert.ToInt32(FirstUsedRow);
            foreach (DataGridViewRow row in dtViewer.Rows)
            {
                row.HeaderCell.Value = "ROW " + RowIndex.ToString();
                RowIndex++;
            }

            int ColumnsIndex = Convert.ToInt32(FirstUsedColumn);
            foreach (DataGridViewColumn cols in dtViewer.Columns)
            {
                cols.SortMode = DataGridViewColumnSortMode.NotSortable;
                cols.Width = 120;
                cols.HeaderText = "F" + ColumnsIndex.ToString();
                ColumnsIndex++;
            }
        }

        private void FillStatusGrid(int maxRows, int maxCols)
        {
            statusGridView.Rows.Add();
            statusGridView.Rows[0].HeaderCell.Value = "PressetName";
            statusGridView.Rows[0].Cells[0].Value = "PressetName";

            statusGridView.Rows.Add();
            statusGridView.Rows[1].HeaderCell.Value = "ColumnsCounts";
            statusGridView.Rows[1].Cells[0].Value = "ColumnsCounts";
            statusGridView.Rows[1].Cells[1] = new NumericUpDownDataGrid.NumericUpDownCell(0, maxCols);

            statusGridView.Rows.Add();
            statusGridView.Rows[2].HeaderCell.Value = "FirstHeaderRow";
            statusGridView.Rows[2].Cells[0].Value = "FirstHeaderRow";
            statusGridView.Rows[2].Cells[1] = new NumericUpDownDataGrid.NumericUpDownCell(FirstUsedRow, ((FirstUsedRow+maxRows) - urProperty.cntHeadsRows));

            statusGridView.Rows.Add();
            statusGridView.Rows[3].HeaderCell.Value = "FirstDataRow";
            statusGridView.Rows[3].Cells[0].Value = "FirstDataRow";
            statusGridView.Rows[3].Cells[1] = new NumericUpDownDataGrid.NumericUpDownCell(FirstUsedRow, FirstUsedRow+maxRows);

            statusGridView.Rows.Add();
            statusGridView.Rows[4].HeaderCell.Value = "Steps";
            statusGridView.Rows[4].Cells[0].Value = "Steps";
            statusGridView.Rows[4].Cells[1] = new NumericUpDownDataGrid.NumericUpDownCell(0, 10);

            statusGridView.Rows.Add();
            statusGridView.Rows[5].HeaderCell.Value = "ExportColumns";
            statusGridView.Rows[5].Cells[0].Value = "ExportColumns";

            statusGridView.Rows.Add();
            statusGridView.Rows[6].HeaderCell.Value = "ColumnsChecks";
            statusGridView.Rows[6].Cells[0].Value = "ColumnsChecks";

            statusGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            statusGridView.CellEndEdit += statusGridView_CellEndEdit;
            statusGridView.MouseDown += new MouseEventHandler(statusGridView_MouseClick);

            statusGridView.ClearSelection();
            TypeDescriptor.GetProperties(urOptionsGrid.SelectedObject)["DRow"].SetReadOnlyAttribute(false);
            TypeDescriptor.GetProperties(urOptionsGrid.SelectedObject)["cntHeadsRows"].SetReadOnlyAttribute(false);
        }

        private void SettingsNewForm()
        {
            TreeView.Name = "Form3";
            TreeView.Text = "Extracted columns";
            TreeView.WindowState = FormWindowState.Normal;
            TreeView.FormBorderStyle = FormBorderStyle.FixedSingle;
            TreeView.MaximizeBox = false;

            TreeColViewer.Location = new Point(5, 40);
            TreeColViewer.ColumnHeadersVisible = true;
            TreeColViewer.RowHeadersVisible = true;
            TreeColViewer.ScrollBars = ScrollBars.None;
            TreeColViewer.RowTemplate.DefaultCellStyle.Font = new Font("Arial", 9);
            TreeColViewer.RowTemplate.MinimumHeight = 18;
            TreeColViewer.RowTemplate.Height = 18;

            TreeColViewer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            TreeColViewer.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            TreeColViewer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            TreeColViewer.EditMode = DataGridViewEditMode.EditOnEnter;
            TreeColViewer.RowHeadersWidth = 70;
            TreeView.Controls.Add(TreeColViewer);

            TextExtractColumns.Location = new Point(5, 10);
            TreeView.Controls.Add(TextExtractColumns);

            ConfirmCols.Text = "Confirm";
            ConfirmCols.Size = new Size(120, 30);
            ConfirmCols.Enabled = false;
        }

        private void StripMenuHeaderRow_Click(object sender, EventArgs e)
        {
            TreeFormDestroyer();
            int mxRw;

            foreach (DataGridViewRow rws in dataViewer.Rows)
            {
                if (rws.DefaultCellStyle.BackColor == exclSettings.ColorHeads | rws.DefaultCellStyle.BackColor == exclSettings.ColorHeads | rws.DefaultCellStyle.BackColor == exclSettings.ColorDataRows | rws.DefaultCellStyle.BackColor == exclSettings.ColorDataRows)
                {
                    rws.DefaultCellStyle.BackColor = Color.Empty;
                    rws.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            if (ActiveCell.RowIndex >= 0 && ActiveCell.ColumnIndex == 0 && ActiveCell.RowIndex+ Convert.ToInt32(urProperty.cntHeadsRows) <= RowsCnt)
            {
                HFR = ActiveCell.RowIndex + 1;
                statusGridView.Rows[2].Cells[1].Value = Convert.ToInt32(dataViewer.Rows[ActiveCell.RowIndex].HeaderCell.Value.ToString().Split(' ').Last());

                int ls = (Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value) + urProperty.cntHeadsRows);
                if (ls >= FirstUsedRow + RowsCnt)
                    mxRw = ls - 1;
                else
                    mxRw = ls;

                statusGridView.Rows[3].Cells[1].Value = null;
                statusGridView.Rows[3].Cells[1] = new NumericUpDownDataGrid.NumericUpDownCell(mxRw, FirstUsedRow+RowsCnt);

                dataViewer.Rows[ActiveCell.RowIndex].DefaultCellStyle.BackColor = exclSettings.ColorHeads;
                dataViewer.Rows[ActiveCell.RowIndex].DefaultCellStyle.ForeColor = fntCl;

                if (urProperty.DRow == true)
                {
                    for (int i = 1; i < Convert.ToInt32(urProperty.cntHeadsRows); i++)
                    {
                        dataViewer.Rows[ActiveCell.RowIndex + i].DefaultCellStyle.BackColor = exclSettings.ColorHeads;
                        dataViewer.Rows[ActiveCell.RowIndex+i].DefaultCellStyle.ForeColor = fntCl;
                    }
                }
            }
            if (HFR != 0)
            {
                urBtnConvert2Tree.Enabled = true;
            }


            tempPropVal.Add(Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value)); //[1] - Rows counts take Header
            dataViewer.ClearSelection();
            statusGridView.ClearSelection();
            SettingsForm.optionsGrid.Refresh();
        }

        private void StripMenuFirstData_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataViewer.Rows)
            {
                if (row.DefaultCellStyle.BackColor == exclSettings.ColorDataRows | row.DefaultCellStyle.BackColor == exclSettings.ColorDataRows)
                {
                    row.DefaultCellStyle.BackColor = Color.Empty;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            if (ActiveCell != null && ActiveCell.RowIndex <= RowsCnt)
            {
                statusGridView.Rows[3].Cells[1].Value = Convert.ToInt32(dataViewer.Rows[(ActiveCell.RowIndex)].HeaderCell.Value.ToString().Split(' ').Last());
                dataViewer.Rows[(ActiveCell.RowIndex)].DefaultCellStyle.BackColor = exclSettings.ColorDataRows;
                dataViewer.Rows[(ActiveCell.RowIndex)].DefaultCellStyle.ForeColor = fntClDat;

                for (int i = (ActiveCell.RowIndex + Convert.ToInt32(statusGridView.Rows[4].Cells[1].Value) + 1); i < RowsCnt-1; i += Convert.ToInt32(statusGridView.Rows[4].Cells[1].Value) + 1)
                {
                    if (dataViewer.Rows[i].Cells[1].Value != DBNull.Value)
                    {
                        dataViewer.Rows[i].DefaultCellStyle.BackColor = exclSettings.ColorDataRows;
                        dataViewer.Rows[i].DefaultCellStyle.ForeColor = fntClDat;
                    }
                }
                dataViewer.ClearSelection();
                statusGridView.ClearSelection();
                SettingsForm.optionsGrid.Refresh();
            }
        }

        private void import2Universal_Click(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory + "\\";
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            ofd.Multiselect = false;
            ofd.DefaultExt = "*.xml";
            ofd.Filter = "XML data (*.xml*)|*.xml*";
            ofd.Title = "Open XML file";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            xmlFileName = ofd.FileName;

            XMLParser();
        }

        private void FileWriter(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Multiselect = false;
            ofd.DefaultExt = "*.xls;*.xlsx";
            ofd.Filter = "Microsoft Excel (*.xls*)|*.xls*";
            ofd.Title = "¬ыберите документ Excel";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            string xlFileName = ofd.FileName;


            if (File.Exists(xmlFileName))
            {
                XMLParser();

                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWB;
                Excel.Worksheet xlSht;
                xlWB = xlApp.Workbooks.Add(xlFileName);
                xlSht = xlWB.Worksheets[1];

                int we = dt_db_shema.Rows.Count;
                int ww = 0;


                for (int i = 0; i < objID.Length + Convert.ToInt32(extraColumns.Value); i++)
                {
                    dt_db_shema.Columns.Add();
                }


                for (int i = Convert.ToInt32(firstData.Value); xlSht.Cells[i, 1].Text != string.Empty || xlSht.Cells[i, 4].Text != string.Empty || xlSht.Cells[i, 2].Text != string.Empty; i++)
                {

                    if (xlSht.Cells[i, 1].Text != string.Empty && xlSht.Cells[i, 4].Text != string.Empty)
                    {
                        ww++;
                        dt_db_shema.Rows.Add();
                        for (int j = 0; j <= Convert.ToInt32(extraColumns.Value); j++)
                        {
                            dt_db_shema.Rows[we][j] = xlSht.Cells[4, 3].Value;
                        }
                        for (int c = 0; c < objID.Length; c++)
                        {
                            if (xlSht.Cells[i, objID[c]].Text != string.Empty)
                            {
                                dt_db_shema.Rows[we][c + Convert.ToInt32(extraColumns.Value)] = xlSht.Cells[i, objID[c]].Value;
                            }
                            else
                            {
                                dt_db_shema.Rows[we][c + Convert.ToInt32(extraColumns.Value)] = 0;
                            }
                        }
                        we++;
                    }
                }

                dataViewer.DataSource = null;
                DataTable DT = (DataTable)dataViewer.DataSource;
                if (DT != null)
                    DT.Clear();

                dataViewer.Rows.Clear();
                dataViewer.Refresh();
                int count = this.dataViewer.Columns.Count;
                for (int i = 0; i < count; i++)
                    this.dataViewer.Columns.RemoveAt(0);


                foreach (DataGridViewColumn column in dataViewer.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                dataViewer.DataSource = dt_db_shema;
                dataViewer.AllowUserToAddRows = false;
                dataViewer.AllowUserToDeleteRows = false;
                dataViewer.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

                xlWB.Close(false, false, false);
                xlApp.Quit();
                xlApp = null;
                xlWB = null;
                xlSht = null;
                GC.Collect();
            }
            else
            {
                Console.WriteLine("XML file not found, be sure that the folder contains the necessary files.");
            }

        }

        private void XMLParser()
        {

            Console.WriteLine("Starting XML parsing...");

                XDocument XMLfile = XDocument.Load(xmlFileName);

                    DataSet ds = new DataSet();

                    int idn = 0;
                    int nameN = 0;
                    ds.ReadXml(xmlFileName);

            Console.WriteLine("\n" + "///New section in XML (usedColumns ID) ///" + "\n");

                    foreach (XElement infoElement in XMLfile.Root.Elements("usedColumns"))
                    {
                        strID = infoElement.Element("id");
                        Array.Resize(ref objID, idn + 1);
                        objID[idn] = Convert.ToInt32(strID.Value);
                        Console.WriteLine(objID[idn].ToString() + "; ");
                        idn++;
                    }

            Console.WriteLine("\n" + "///New section in XML (usedColumns NAME) ///" + "\n");

                    foreach (XElement infoElement in XMLfile.Root.Elements("usedColumns"))
                    {
                        strName = infoElement.Element("name");
                        Array.Resize(ref objName, nameN + 1);
                        objName[nameN] = Convert.ToString(strName.Value);
                        Console.WriteLine(objName[nameN].ToString() + "; ");
                        nameN++;
                    }

            Console.WriteLine("\n" + "///New section in XML (commonSettings) ///" + "\n");

                    foreach (XElement infoElement in XMLfile.Root.Elements("commonSettings"))
                    {
                        extraColumns = infoElement.Element("extraColumns");
                        headsRow = infoElement.Element("headsRow");
                        //firstData = infoElement.Element("firstData");
                        columnsCount = infoElement.Element("columnsCount");
                        Console.WriteLine("extraColumns: " + extraColumns.Value + "; \n headsRow: " + headsRow.Value + "; \n firstData: not used /// " + "; \n columnsCount: " + columnsCount.Value + "; \n");
                    }
                    return;
        }

        private void TreeFormDestroyer()
        {
            cntShows = 0;
            
            TreeColViewer.Columns.Clear();
            TreeColViewer.Rows.Clear();
            TextExtractColumns.Text = "";
            allowVoid = false;
            urBtnConvert2Tree.Enabled = false;
        }

        private void ColsChecker()
        {
            string clck = statusGridView.Rows[6].Cells[1].Value.ToString();
            string[] spclck = clck.Split(';');
            foreach(string sp in spclck)
            Console.WriteLine(sp + " | ");
        }

        private void propGrid_stripHelp(object sender, EventArgs e)
        {
            SettingsForm.optionsGrid.HelpVisible = !SettingsForm.optionsGrid.HelpVisible;
                helpToolStripMenuItem.Checked = !helpToolStripMenuItem.Checked;
        }

        public void oldUpdateOptionsGrid()
        {

            if (urProperty.useExtraCol == true)
            {
                TypeDescriptor.GetProperties(urOptionsGrid.SelectedObject)["ExtraColCnt"].SetReadOnlyAttribute(false);
            }

            if (urProperty.useExtraCol == false)
            {
                TypeDescriptor.GetProperties(urOptionsGrid.SelectedObject)["ExtraColCnt"].SetReadOnlyAttribute(true);
                urProperty.ExtraColCnt = 0;
            }

            if (urProperty.DRow == true && urProperty.cntHeadsRows < 2)
            {
                TypeDescriptor.GetProperties(urOptionsGrid.SelectedObject)["cntHeadsRows"].SetReadOnlyAttribute(false);
                urProperty.cntHeadsRows = 2;
            }

            if (urProperty.DRow == false)
            {
                TypeDescriptor.GetProperties(urOptionsGrid.SelectedObject)["cntHeadsRows"].SetReadOnlyAttribute(true);
                urProperty.cntHeadsRows = 1;
            }



            if (urProperty.ExtraColCnt > 10)
                urProperty.ExtraColCnt = 10;



            if (urProperty.cntHeadsRows != prvCntHedRw)
            {
                prvCntHedRw = urProperty.cntHeadsRows;
                TreeFormDestroyer();
            }

            string temp = null;
            foreach (string s in exclSettings.sqlArray)
            {
                temp += s + ";";
            }

            if (temp != memSQLlist)
                AutoFillList();

            autoFontColor();
            ConfigUpdater();
            updateDataGridColors();

            if (dataViewer.DataSource != null)
            {
                if (urProperty.cntHeadsRows > RowsCnt)
                { urProperty.cntHeadsRows = RowsCnt; }
                updateStatusGrid(urProperty.cntHeadsRows);
            }
            SettingsForm.optionsGrid.Refresh();

            
        }

        public void settingsPropertyValueChanged()
        {
            switch (mgSettings.mgCodeName.propGTPname)
            {
                case "KUBANESK":
                    textBoxSubject.PlaceholderText = " раснодарский край";
                    textBoxGTPcode.PlaceholderText = "PKUBANEN";
                    textBoxNameGP.PlaceholderText = "ѕјќ “Ќ— энерго  убань";
                    break;
            }

            mgSettings.defaultSiteLink = ImportList.defaultSiteLinks[ImportList.KnownGTPnames.IndexOf(mgSettings.mgCodeName.propGTPname)];
        }


        private void updateDataGridColors()
        {
            foreach (DataGridViewRow row in dataViewer.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.FromName(tempPropColors[0].Name))
                {
                    row.DefaultCellStyle.BackColor = exclSettings.ColorHeads;
                    row.DefaultCellStyle.ForeColor = fntCl;
                }
                if (row.DefaultCellStyle.BackColor == Color.FromName(tempPropColors[1].Name))
                {
                    row.DefaultCellStyle.BackColor = exclSettings.ColorDataRows;
                    row.DefaultCellStyle.ForeColor = fntClDat;
                }
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Style.BackColor == Color.FromName(tempPropColors[2].Name))
                    {
                        cell.Style.BackColor = exclSettings.ColorStaticDat;
                        cell.Style.ForeColor = fntClStaticDat;
                    }
                }
            }
            tempPropColors[0] = exclSettings.ColorHeads;
            tempPropColors[1] = exclSettings.ColorDataRows;
            tempPropColors[2] = exclSettings.ColorStaticDat;
            tempPropColors[3] = exclSettings.SecondColorHeads;
        }

        private void updateStatusGrid(int lastVal)
        {
            if (tempPropVal[0] != lastVal && TypeDescriptor.GetProperties(urOptionsGrid.SelectedObject)["cntHeadsRows"].IsReadOnly == false)
            {
                statusGridView.Rows[2].Cells[1].Value = null;
                statusGridView.Rows[2].Cells[1] = new NumericUpDownDataGrid.NumericUpDownCell(FirstUsedRow, (RowsCnt - urProperty.cntHeadsRows) + 1);
                statusGridView.Rows[5].Cells[1].Value = null;

                foreach (DataGridViewRow rws in dataViewer.Rows)
                {
                    if (rws.DefaultCellStyle.BackColor == exclSettings.ColorHeads | rws.DefaultCellStyle.BackColor == exclSettings.ColorHeads)
                    {
                        rws.DefaultCellStyle.BackColor = Color.Empty;
                        rws.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                tempPropVal[0] = lastVal;
                TreeFormDestroyer();
            }
        }

        private void autoFontColor()
        {
            if (exclSettings.ColorHeads.R < 120 | exclSettings.ColorHeads.G < 120 | exclSettings.ColorHeads.B < 120)
                fntCl = Color.White;
            else
                fntCl = Color.Black;

            if (exclSettings.ColorDataRows.R < 120 | exclSettings.ColorDataRows.G < 120 | exclSettings.ColorDataRows.B < 120)
                fntClDat = Color.White;
            else
                fntClDat = Color.Black;

            if (exclSettings.SecondColorHeads.R < 100 | exclSettings.SecondColorHeads.G < 100 | exclSettings.SecondColorHeads.B < 120)
                fntTreeCl = Color.White;
            else
                fntTreeCl = Color.Black;

            if (exclSettings.ColorStaticDat.R < 100 | exclSettings.ColorStaticDat.G < 100 | exclSettings.ColorStaticDat.B < 120)
                fntClStaticDat = Color.White;
            else
                fntClStaticDat = Color.Black;
        }

        private void CheckRegLib()
        {
            RegistryKey root = Registry.ClassesRoot;
            RegistryKey TypeLib = root.OpenSubKey("TypeLib");

            RegistryKey OleDB = TypeLib.OpenSubKey("{00020813-0000-0000-C000-000000000046}");
            try
            {
                //Console.WriteLine("Checked sub: {0}.", OleDB.Name + " check status Ч ok.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.GetType());

                //Console.WriteLine("Sub with ID {00020813-0000-0000-C000-000000000046} not registred, check status Ч failed.");
            }

            RegistryKey lastKey = OleDB.OpenSubKey("1.9");
            try
            {
                //Console.WriteLine("Checked sub: {0}.", lastKey.Name + " check status Ч ok.");

                lastKey.Close();
                OleDB.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.GetType());

                Console.WriteLine("Lib ver.1.9 not registred, check status Ч failed.");
                OleDB.Close();
            }
            TypeLib.Close();
            root.Close();
        }

        private void RigesterCOMfix(object sender, EventArgs e)
        {
            RegistryKey root = Registry.ClassesRoot;
            RegistryKey TypeLib = root.OpenSubKey("TypeLib", true);

            RegistryKey OleDB = TypeLib.OpenSubKey("{00020813-0000-0000-C000-000000000046}", true);
            try
            {
                Console.WriteLine("Open sub: {0}.", OleDB.Name);
            }
            catch (Exception d)
            {
                Console.WriteLine(d.Message);
                Console.WriteLine(d.GetType());

                TypeLib.CreateSubKey("{00020813-0000-0000-C000-000000000046}");
                OleDB = TypeLib.OpenSubKey("{00020813-0000-0000-C000-000000000046}", true);

                Console.WriteLine("SubKey: " + OleDB.Name + " was created.");
            }

            RegistryKey lastKey = OleDB.OpenSubKey("1.9", true);
            try
            {
                Console.WriteLine("Open sub: {0}.", lastKey.Name);
                lastKey.Close();
                OleDB.Close();
            }
            catch (Exception d)
            {
                Console.WriteLine(d.Message);
                Console.WriteLine(d.GetType());

                OleDB = TypeLib.OpenSubKey("{00020813-0000-0000-C000-000000000046}", true);
                OleDB.CreateSubKey("1.9");
                lastKey = OleDB.OpenSubKey("1.9", true);
                lastKey.SetValue(default, "Microsoft Excel 16.0 Object Library");
                lastKey.SetValue("PrimaryInteropAssemblyName", "Microsoft.Office.Interop.Excel, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71E9BCE111E9429C");


                Console.WriteLine("SubKey: " + lastKey.Name + " was created.");

                lastKey.Close();
                OleDB.Close();
            }
            TypeLib.Close();
            root.Close();
        }

        private void aboutShow(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.Show();
        }

        protected void callXFA(object sender, EventArgs eArgs)
        {
            MessageBox.Show("got to MainResponse");
        }

        class Magician
        {
            [DllImport("kernel32.dll")]
            static extern IntPtr GetConsoleWindow();

            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

            const int HIDE = 0;
            const int SHOW = 5;

            public static void DisappearConsole()
            {
                ShowWindow(GetConsoleWindow(), HIDE);
            }

            public static void AppearConsole()
            {
                ShowWindow(GetConsoleWindow(), SHOW);
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 1; i <= 100; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    Thread.Sleep(1);
                    worker.ReportProgress(i);
                }
            }
        }

        private void bgWorker_Interop(object sender, DoWorkEventArgs e)
        {
            List<object> genericlist = e.Argument as List<object>;
            DataTable dataVariantB = (DataTable)genericlist[0];
            int xlRowCount = (int)genericlist[1];
            int xlColCount = (int)genericlist[2];
            Excel.Range ExcelRange = (Excel.Range)genericlist[3];

            BackgroundWorker worker = sender as BackgroundWorker;
            DataRow xlrow = null;

            for (int j = 1; j <= xlColCount; j++)
            {
                dataVariantB.Columns.Add();
            }

            for (int i = 1; i <= xlRowCount; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    xlrow = dataVariantB.NewRow();
                    for (int j = 1; j <= xlColCount; j++)
                    {
                        xlrow[j - 1] = ExcelRange.Cells[i, j].Value;
                    }
                    dataVariantB.Rows.Add(xlrow);
                    int percentage = (i * 100) / xlRowCount;
                    worker.ReportProgress(percentage);
                }
            }
        }

        private void bgWorker_NPOI(object sender, DoWorkEventArgs e)
        {
            List<object> genericlist = e.Argument as List<object>;
            DataTable dataExport = (DataTable)genericlist[0];
            int xlRowCount = (int)genericlist[1];
            int xlColCount = (int)genericlist[2];
            ISheet wSheet = (ISheet)genericlist[3];
            XSSFFormulaEvaluator xsseva = (XSSFFormulaEvaluator)genericlist[4];
            HSSFFormulaEvaluator hsseva = (HSSFFormulaEvaluator)genericlist[5];
            int cellCnt = (int)genericlist[6];
            int ColCreat = (int)genericlist[7];
            string xlFileName = (string)genericlist[8];

            BackgroundWorker worker = sender as BackgroundWorker;
            DataRow xlrow = null;

            for (int row = wSheet.FirstRowNum; row <= wSheet.PhysicalNumberOfRows; row++)
            {
                if (wSheet.GetRow(row) != null)
                {
                    foreach (ICell cell in wSheet.GetRow(row))
                    {
                        cellCnt++;
                        if (cell.ColumnIndex > ColCreat)
                            ColCreat = cell.ColumnIndex;
                        if (cell.ColumnIndex < FirstUsedColumn)
                            FirstUsedColumn = cell.ColumnIndex + 1;
                    }
                }
            }
            xlColCount = ColCreat + 1;

            for (int col = 0; col <= ColCreat; col++)
            {
                dataExport.Columns.Add();
            }
            for (int row = wSheet.FirstRowNum; row <= wSheet.LastRowNum; row++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    if (wSheet.GetRow(row) != null)
                    {
                        xlrow = dataExport.NewRow();
                        foreach (ICell cell in wSheet.GetRow(row))
                        {
                            if (Path.GetExtension(xlFileName) == ".xlsx")
                            {
                                xsseva.EvaluateInCell(cell);
                            }
                            else
                            {
                                hsseva.EvaluateInCell(cell);
                            }

                            var cellType = wSheet.GetRow(row).GetCell(cell.ColumnIndex);
                            switch (cellType.CellType)
                            {
                                case CellType.Numeric:
                                    xlrow[cell.ColumnIndex] = wSheet.GetRow(row).GetCell(cell.ColumnIndex).NumericCellValue;
                                    break;
                                case CellType.String:
                                    xlrow[cell.ColumnIndex] = wSheet.GetRow(row).GetCell(cell.ColumnIndex).StringCellValue;
                                    break;
                                case CellType.Unknown:
                                    xlrow[cell.ColumnIndex] = wSheet.GetRow(row).GetCell(cell.ColumnIndex).StringCellValue;
                                    break;
                                case CellType.Blank:
                                    xlrow[cell.ColumnIndex] = null;
                                    break;
                            }
                        }
                        dataExport.Rows.Add(xlrow);
                    }
                int percentage = (row * 100) / wSheet.LastRowNum;
                worker.ReportProgress(percentage);
                }
            }
            if (cmnSettings.CheckEmptyRows.SwitchChecks == true)
            {
                CheckingRealDat(dataExport);
                xlRowCount = dataExport.Rows.Count;
                xlColCount = dataExport.Columns.Count;
            }
        }

        private void bgWorker_EEPlus(object sender, DoWorkEventArgs e)
        {
            List<object> genericlist = e.Argument as List<object>;
            DataTable dataExport = (DataTable)genericlist[0];
            int xlRowCount = (int)genericlist[1];
            int xlColCount = (int)genericlist[2];
            ExcelWorksheet worksheet = (ExcelWorksheet)genericlist[3];


            BackgroundWorker worker = sender as BackgroundWorker;
            DataRow xlrow = null;

            for (int col = 1; col <= xlColCount; col++)
            {
                dataExport.Columns.Add();
            }
            for (int row = 1; row <= xlRowCount; row++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    xlrow = dataExport.NewRow();
                    for (int col = 1; col <= xlColCount; col++)
                    {
                        xlrow[col - 1] = worksheet.Cells[row, col].Value;
                        //Console.WriteLine(" Row:" + row + " column:" + col + " Value:" + worksheet.Cells[row, col].Value?.ToString().Trim());
                    }
                    dataExport.Rows.Add(xlrow);
                    int percentage = (row * 100) / xlRowCount;
                    worker.ReportProgress(percentage);
                }
            }
        }

        private void bgWorker_OleDB(object sender, DoWorkEventArgs e)
        {

        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressDlg.Message = ("Extracting data: " + e.ProgressPercentage.ToString() + "%");
            progressDlg.ProgressValue = e.ProgressPercentage;
        }

        private void bgWorker_DownloadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressDlg.Message = ("Downloading: " + e.ProgressPercentage.ToString() + "%");
            progressDlg.ProgressValue = e.ProgressPercentage;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressDlg.Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DictionaryForm.Dispose();
            SettingsForm.Dispose();
            mgDatsList.dictBankForm.Dispose();
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;

            if (cmnSettings.ForceCloseExl == true)
            {
                foreach (Process clsProcess in Process.GetProcesses())
                {
                    if (clsProcess.ProcessName.Equals("EXCEL"))
                    {
                        clsProcess.Kill();
                    }
                }
            }
            else
            {
                KillSpecificExcelFileProcess(ExlFileName);
            }
        }

        private void ExitUR_Click(object sender, EventArgs e)
        {
            Application.OpenForms["MainForm"].Hide();
            Application.OpenForms[0].Show();
        }

        private void SectionsControl_Selected(object sender, TabControlEventArgs e)
        {
            switch (SectionsControl.SelectedIndex)
            {
                case 1:
                    
                    break;

                case 0:
                    
                    break;
            }
        }

        private void OpenDictionaryList_Click(object sender, EventArgs e)
        {
            DictionaryForm.Show();
        }

        private void openPDFviewer_Click(object sender, EventArgs e)
        {
            FormType2 formType2 = new FormType2();
            formType2.Show();
        }

        private void dataViewer_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1)
                {
                    string xlFileName = files[0].ToString();
                    ExlFileName = Path.GetFileName(xlFileName);

                    DataGridView urDt = dataViewer;
                    dataViewer.DataSource = null;
                    DataTable dataExtraction = new DataTable();
                    DataTable DT = (DataTable)dataViewer.DataSource;
                    if (DT != null)
                        DT.Clear();

                    dataViewer.Rows.Clear();
                    dataViewer.Refresh();
                    int count = this.dataViewer.Columns.Count;
                    for (int i = 0; i < count; i++)
                        this.dataViewer.Columns.RemoveAt(0);

                    commonImportEXCL(this, new EventArgs(), dataExtraction, xlFileName);
                    dataViewer.DataSource = dataExtraction;
                    dataViewerFillHeadres(FirstUsedRow, FirstUsedColumn, urDt);
                    FillStatusGrid(RowsCnt, ColsCnt);

                    tempPropVal.Add(urProperty.cntHeadsRows);
                    splitContainer_rightProps.Panel1Collapsed = false;
                    SettingsForm.optionsGrid.Refresh();

                    statusGridView.Rows[1].Cells[1].Value = ColsCnt;
                    statusGridView.Rows[4].Cells[1].Value = 0;
                    statusGridView.ClearSelection();

                    dataViewer.AllowUserToAddRows = false;
                    dataViewer.AllowUserToDeleteRows = false;
                    dataViewer.EnableHeadersVisualStyles = false;

                    dataViewer.MouseDown += new MouseEventHandler(dataViewer_MouseClick);
                    dataViewer.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(DataViewer_RowSelected);
                    dataViewer.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(DataViewer_ColumnsSelected);
                    dataViewer.Update();
                }
            }
        }

        private void dataViewer_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void urBtnImportFile_ButtonClick(object sender, EventArgs e)
        {
            urImportEXCL(this, new EventArgs());
        }

        private void mgBtnImportFile_ButtonClick(object sender, EventArgs e)
        {
            mgImportEXCL(this, new EventArgs());
        }

    
        private void StartPage()
        {
            foreach (TabPage page in SectionsControl.TabPages)
            {
                ImportList.AvailablePages.Add(page.Text.ToString());
            }
            cmnSettings.StartPage = ImportList.AvailablePages[1];
            SectionsControl.SelectedTab = SectionsControl.TabPages["tab"+ cmnSettings.StartPage];
        }

        private void mgImportEntryDats(object sender, EventArgs e, string type, string path, string fileTypeTarget)
        {
            string xlFileName = "";
            if (type == "ofd")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.DefaultExt = "*.xls;*.xlsx";
                ofd.Filter = "Microsoft Excel (*.xls*)|*.xls*";
                ofd.Title = "¬ыберите документ Excel";
                if (ofd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                xlFileName = ofd.FileName;
            }
            else if (type == "dwn")
            {
               xlFileName = path;
            }
            else
            {
                Console.WriteLine("Type not set");
                return;
            }

            DataTable dataExtraction = new DataTable();
            commonImportEXCL(this, new EventArgs(), dataExtraction, xlFileName);

            //string[] components = Path.GetFileNameWithoutExtension(xlFileName).Split("_");

            switch (fileTypeTarget)
            {
                case "KOEFF":

                    if (DateTime.ParseExact(txtProjectMonth.Text, "MMMM", CultureInfo.CurrentCulture).Month != DateTime.ParseExact(dataExtraction.Rows[1][5].ToString().Split(" ").First(), "MMMM", CultureInfo.CurrentCulture).Month)
                    {
                        //MessageBox.Show("¬ыбранный мес€ц не совпадает с указанным расчетным периодом в загружаемом файле.");
                    }
                    if (txtProjectYear.Text != dataExtraction.Rows[1][5].ToString().Split(" ").Last())
                    {
                        //MessageBox.Show("¬ыбранный год не совпадает с указанным расчетным периодом в загружаемом файле.");
                    }

                    DataRow[] filteredRows = dataExtraction.Select(string.Format("{0} LIKE '%{1}%'", dataExtraction.Columns[3].ColumnName.ToString(), mgSettings.mgCodeName.propGTPcode));

                    foreach (DataRow row in filteredRows)
                    {
                        textBoxSubject.Text = row[1].ToString();
                        textBoxGTPcode.Text = row[3].ToString();
                        textBoxNameGP.Text = row[2].ToString();

                        datsTreeView.Nodes["treeViewLine6"].Nodes["treeViewLine6e1"].Nodes["treeViewLine6e1val"].Text = row[4].ToString();
                        datsTreeView.Nodes["treeViewLine6"].Nodes["treeViewLine6e2"].Nodes["treeViewLine6e2val"].Text = row[5].ToString();
                        datsTreeView.Nodes["treeViewLine6"].Nodes["treeViewLine6e3"].Nodes["treeViewLine6e3val"].Text = row[6].ToString();

                        datsTreeView.Nodes["treeViewLine7"].Nodes["treeViewLine7e1"].Nodes["treeViewLine7e1val"].Text = row[7].ToString();
                        datsTreeView.Nodes["treeViewLine7"].Nodes["treeViewLine7e2"].Nodes["treeViewLine7e2val"].Text = row[8].ToString();
                    }

                    mgFileKF.Checked = true;

                    break;

                case "SVNC":

                    textBoxGTPcode.Text = dataExtraction.Rows[3][1].ToString();
                    textBoxNameGP.Text = dataExtraction.Rows[4][1].ToString();

                    if (DateTime.ParseExact(txtProjectMonth.Text, "MMMM", CultureInfo.CurrentCulture).Month != DateTime.ParseExact(dataExtraction.Rows[2][1].ToString().Split(" ").First(), "MMMM", CultureInfo.CurrentCulture).Month)
                    {
                        //MessageBox.Show("¬ыбранный мес€ц не совпадает с указанным расчетным периодом в загружаемом файле.");
                    }
                    if (txtProjectYear.Text != dataExtraction.Rows[2][1].ToString().Split(" ").Last())
                    {
                        //MessageBox.Show("¬ыбранный год не совпадает с указанным расчетным периодом в загружаемом файле.");
                    }

                    datsTreeView.Nodes["treeViewLine2"].Nodes["treeViewLine2e1val"].Text = dataExtraction.Rows[31][1].ToString();
                    datsTreeView.Nodes["treeViewLine3"].Nodes["treeViewLine3e1val"].Text = dataExtraction.Rows[33][1].ToString();

                    datsTreeView.Nodes["treeViewLine4"].Nodes["treeViewLine4e1"].Nodes["treeViewLine4e1val"].Text = dataExtraction.Rows[25][1].ToString();
                    datsTreeView.Nodes["treeViewLine4"].Nodes["treeViewLine4e2"].Nodes["treeViewLine4e2val"].Text = dataExtraction.Rows[26][1].ToString();
                    datsTreeView.Nodes["treeViewLine4"].Nodes["treeViewLine4e3"].Nodes["treeViewLine4e3val"].Text = dataExtraction.Rows[27][1].ToString();

                    datsTreeView.Nodes["treeViewLine5"].Nodes["treeViewLine5e1"].Nodes["treeViewLine5e1val"].Text = dataExtraction.Rows[29][1].ToString();
                    datsTreeView.Nodes["treeViewLine5"].Nodes["treeViewLine5e2"].Nodes["treeViewLine5e2val"].Text = dataExtraction.Rows[30][1].ToString();

                    mgFileSVNC.Checked = true;

                    break;

                case "SPUNC":
                    DataRow[] findRows = dataExtraction.Select(string.Format("{0} LIKE '%{1}%'", dataExtraction.Columns[0].ColumnName.ToString(), "расчеты по первой ценовой категории"));
                    datsTreeView.Nodes["treeViewLine1"].Nodes["treeViewLine1e1val"].Text = findRows[0][4].ToString();
                    break;
            }

        }

        private void urBtnSaveXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Environment.CurrentDirectory;
            sfd.Filter = "XML File (*.xml*)|*.xml*";
            sfd.Title = "Save as XML";
            sfd.FileName = statusGridView.Rows[0].Cells[1].Value.ToString() + ".xml";


            if (statusGridView.Rows[0].Cells[1].Value != null && statusGridView.Rows[5].Cells[1].Value != null)
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {

                    string xlFileName = sfd.FileName;

                    try
                    {
                        //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
                        UniversalDataSet.WriteXml(xlFileName.ToString());

                    }
                    catch
                    {

                    }
                }
            }
            else
            {
                MessageBox.Show("Please, fill in all the necessary data");
            }
        }

        private void urBtnConvert2Tree_Click(object sender, EventArgs e)
        {
            if (cntShows != 0)
            {
                SendKeys.Send("{LEFT}");
                TreeColViewer_CellCmbxValueChanged(this.TreeColViewer, new DataGridViewCellEventArgs(this.TreeColViewer.CurrentCell.ColumnIndex, this.TreeColViewer.CurrentRow.Index));
                TreeView.ShowDialog();
                return;
            }


            DataGridViewTextBoxColumn Col1 = new DataGridViewTextBoxColumn();
            Col1.Width = 400;
            Col1.Name = "Columns names";
            TreeColViewer.Columns.Add(Col1);
            TreeColViewer.AllowUserToAddRows = false;
            TreeColViewer.AllowUserToDeleteRows = false;


            foreach (DataGridViewColumn column in TreeColViewer.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            for (int i = 0; i < dataViewer.Columns.Count; i++)
            {
                int rc = TreeColViewer.RowCount;
                int HVC = 0;

                if (urProperty.DRow == true)
                {
                    for (int j = (Convert.ToInt32(HFR) - 1); j < ((Convert.ToInt32(HFR) - 1) + Convert.ToInt32(urProperty.cntHeadsRows)); j++)
                    {
                        if (dataViewer.Rows[j].Cells[i].Value != DBNull.Value)
                        {
                            TreeColViewer.Rows.Add();
                            TreeColViewer.Rows[rc].Cells[0].Value = dataViewer.Rows[j].Cells[i].Value;
                            HVC++;
                            if (HVC >= 2)
                            {
                                TreeColViewer.Rows[rc].HeaderCell.Value = "";
                            }
                            else
                            {
                                TreeColViewer.Rows[rc].HeaderCell.Value = dataViewer.Columns[i].HeaderCell.Value;
                            }
                            rc++;
                        }
                    }
                }
                else
                {
                    if (dataViewer.Rows[Convert.ToInt32(HFR) - 1].Cells[i].Value != DBNull.Value)
                    {
                        TreeColViewer.Rows.Add();
                        TreeColViewer.Rows[rc].HeaderCell.Value = dataViewer.Columns[i].HeaderCell.Value;
                        TreeColViewer.Rows[rc].Cells[0].Value = dataViewer.Rows[Convert.ToInt32(HFR) - 1].Cells[i].Value;
                    }
                }
            }

            foreach (DataGridViewRow row in TreeColViewer.Rows)
            {
                if (row.Cells[0].Value == DBNull.Value)
                {
                    TreeColViewer.Rows.RemoveAt(row.Index);
                }
            }


            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            DataGridViewComboBoxColumn bindColumn = new DataGridViewComboBoxColumn();
            checkBoxColumn.Width = 22;
            bindColumn.DataSource = SQLdata;
            bindColumn.Name = "Attachment to SQL columns";
            bindColumn.Width = 120;
            TreeColViewer.Columns.Insert(0, checkBoxColumn);
            TreeColViewer.Columns.Add(bindColumn);

            foreach (DataGridViewRow rw in TreeColViewer.Rows)
            {
                if (rw.HeaderCell.Value == "")
                {
                    rw.Cells[0] = new DataGridViewTextBoxCell();
                    rw.Cells[0].ReadOnly = true;
                    rw.Cells[0].Value = "";
                    rw.Cells[2] = new DataGridViewTextBoxCell();
                    rw.Cells[2].ReadOnly = true;
                    rw.Cells[2].Value = "";
                }
            }

            TreeColViewer.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            Point headerCellLocation = TreeColViewer.GetCellDisplayRectangle(0, 0, true).Location;
            headerCheckBox.Location = new Point(headerCellLocation.X + (TreeColViewer.RowHeadersWidth + 5), headerCellLocation.Y + 5);
            headerCheckBox.BackColor = Color.White;
            headerCheckBox.Size = new Size(18, 18);
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            //TreeColViewer.Controls.Add(headerCheckBox);

            var TreeHeight = TreeColViewer.Rows.GetRowsHeight(DataGridViewElementStates.None) + TreeColViewer.ColumnHeadersHeight;
            var TreeWidth = TreeColViewer.Columns.GetColumnsWidth(DataGridViewElementStates.None) + TreeColViewer.RowHeadersWidth;

            if (TreeHeight > 640)
            {
                TreeHeight = 640;
                TreeWidth += 18;
                TreeColViewer.ScrollBars = ScrollBars.Vertical;
            }
            else
            {
                TreeColViewer.ScrollBars = ScrollBars.None;
            }

            TreeColViewer.Size = new Size(TreeWidth, TreeHeight);
            TextExtractColumns.Size = new Size(TreeWidth, 23);
            TreeView.Size = new Size(TreeWidth + 30, TreeHeight + 120);

            ConfirmCols.Location = new Point(5, TreeHeight + 45);
            ConfirmCols.Click += new EventHandler(ConfirmCols_Click);
            TreeView.Controls.Add(ConfirmCols);
            ConfirmCols.Enabled = false;

            TreeColViewer.Columns[1].ReadOnly = true;
            TreeColViewer.Columns[1].Resizable = DataGridViewTriState.False;
            TreeColViewer.Columns[2].ReadOnly = true;
            TreeColViewer.Columns[2].Resizable = DataGridViewTriState.False;

            TreeColViewer.CellContentClick += new DataGridViewCellEventHandler(ColumnsViewer_CheckClick);
            TreeColViewer.CurrentCellDirtyStateChanged += new EventHandler(TreeColViewer_CurrentCellDirtyStateChanged);
            TreeView.FormClosed += new System.Windows.Forms.FormClosedEventHandler(OnProcessExitTreeView);
            TreeColViewer.CellValueChanged += new DataGridViewCellEventHandler(TreeColViewer_CellCmbxValueChanged);

            allowVoid = true;
            cntShows++;

            TreeView.ShowDialog();
            SettingsForm.optionsGrid.Refresh();
            TreeColViewer.ClearSelection();
        }

        private void getURLlinks()
        {
            string firstDate = mgSettings.rDateSVNC.Year + ((mgSettings.rDateSVNC.Month - 1).ToString("00")) + "01/";
            string secondDate = mgSettings.rDateSVNC.Year + mgSettings.rDateSVNC.Month.ToString("00") + mgSettings.rDateSVNC.Day.ToString("00") + "_";
            string thridDate = "_" + ((mgSettings.rDateSVNC.Month - 1).ToString("00")) + mgSettings.rDateSVNC.Year;
            string fileNameSVNC = mgSettings.mgCodeName.propGTPname + "_" + mgSettings.mgCodeName.propGTPcode + thridDate + "_gtp_1st_stage.xls";
            string urlLinkSVNC = "https://www.atsenergo.ru/dload/retail/" + firstDate + secondDate + fileNameSVNC;
            urlLinksData.Add(urlLinkSVNC);
            string fileNameKF = mgSettings.rDateSVNC.Year + mgSettings.rDateSVNC.Month.ToString("00") + mgSettings.rDateSVNC.Day.ToString("00") + "_" + ((mgSettings.rDateSVNC.Month - 1).ToString("00")) + mgSettings.rDateSVNC.Year + "_koeff.xls";
            string urlLinkKF = "https://www.atsenergo.ru/sites/default/files/uchfsk/" + fileNameKF;
            urlLinksData.Add(urlLinkKF);
            getPageForExtractLinks();
        }

        private void mgFileSPUNCbtn_Click(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            Image statusOK = ((System.Drawing.Image)(resources.GetObject("imgStatusOk.Image")));
            Image statusDwnld = ((System.Drawing.Image)(resources.GetObject("imgStatusDwnld.Image")));
            Image statusFailed = ((System.Drawing.Image)(resources.GetObject("imgStatusFailed.Image")));
            string Status = null;

            List<object> arguments = new List<object>();

            int selectedIndexItem = 0;
            object[] array = new object[mgFileSPUNCselector.Items.Count];
            using (ItemSelector extractedListForm = new ItemSelector())
            {
                mgFileSPUNCselector.Items.CopyTo(array,0);
                extractedListForm.sheetsList.Items.AddRange(array);

                if (extractedListForm.sheetsList.Items.Count > 1)
                {
                    extractedListForm.Size = new Size(DropDownWidth(mgFileSPUNCselector) + 120, extractedListForm.Size.Height);
                    if (extractedListForm.ShowDialog() == DialogResult.OK)
                    {
                        selectedIndexItem = extractedListForm.selectedIndexSheet;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            string urlLink = (string)urlLinksData[selectedIndexItem + 2];
            arguments.Add(urlLink);

            Uri url = new Uri(urlLink);
            string sFileName = Path.GetFileName(url.LocalPath);

            bgWorker = new BackgroundWorker();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += new DoWorkEventHandler(DownloadFile);

            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_DownloadProgressChanged);

            bgWorker.RunWorkerAsync(arguments);

            progressDlg = new ProgressDialog();
            progressDlg.stopProgress = new EventHandler((s, e1) => {
                switch (progressDlg.DialogResult)
                {
                    case DialogResult.Cancel:
                        bgWorker.CancelAsync();
                        progressDlg.Close();
                        break;
                }
            });
            progressDlg.ShowDialog();


            if (File.Exists(mgSettings.mgFolderDonwloads.fullPathDownloads + "\\" + sFileName))
            {
                mgFileSPUNCbtn.Image = statusDwnld;
                string path = mgSettings.mgFolderDonwloads.fullPathDownloads + "\\" + sFileName;
                try
                {
                    mgImportEntryDats(this, new EventArgs(), "dwn", path, "SPUNC");
                    mgFileSPUNCbtn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    mgFileSPUNCselector.Visible = false;
                    Status = "Completed";
                }
                catch
                {
                    Status = "Downloaded";
                }
            }
            else
            {
                Status = "Failed";
            }

            switch (Status)
            {
                case "Completed":
                    mgFileSPUNCbtn.Image = statusOK;
                    mgFileSPUNCbtn.ToolTipText = "‘айл обработан";
                    mgFileSPUNCselector.Visible = false;
                    break;
                case "Downloaded":
                    mgFileSPUNCbtn.Image = statusDwnld;
                    mgFileSPUNCbtn.ToolTipText = "‘айл загружен";
                    mgFileSPUNCselector.Visible = false;
                    break;
                case "Failed":
                    mgFileSPUNCbtn.Image = statusFailed;
                    mgFileSPUNCbtn.ToolTipText = "ќшибка";
                    break;
            }
        }

        private void mgFileSVNC_Click(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            Image statusOK = ((System.Drawing.Image)(resources.GetObject("imgStatusOk.Image")));
            Image statusDwnld = ((System.Drawing.Image)(resources.GetObject("imgStatusDwnld.Image")));
            Image statusFailed = ((System.Drawing.Image)(resources.GetObject("imgStatusFailed.Image")));
            string Status = null;

            List<object> arguments = new List<object>();
            string firstDate = mgSettings.rDateSVNC.Year + ((mgSettings.rDateSVNC.Month-1).ToString("00")) + "01/";
            string secondDate = mgSettings.rDateSVNC.Year + mgSettings.rDateSVNC.Month.ToString("00") + mgSettings.rDateSVNC.Day.ToString("00") + "_";
            string thridDate = "_" + ((mgSettings.rDateSVNC.Month - 1).ToString("00")) + mgSettings.rDateSVNC.Year;
            string fileName = mgSettings.mgCodeName.propGTPname + "_" + mgSettings.mgCodeName.propGTPcode + thridDate + "_gtp_1st_stage.xls";
            string urlLink = (string)urlLinksData[0];
            arguments.Add(urlLink);

            bgWorker = new BackgroundWorker();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += new DoWorkEventHandler(DownloadFile);

            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_DownloadProgressChanged);

            bgWorker.RunWorkerAsync(arguments);

            progressDlg = new ProgressDialog();
            progressDlg.stopProgress = new EventHandler((s, e1) => {
                switch (progressDlg.DialogResult)
                {
                    case DialogResult.Cancel:
                        bgWorker.CancelAsync();
                        progressDlg.Close();
                        break;
                }
            });
            progressDlg.ShowDialog();


            if (File.Exists(mgSettings.mgFolderDonwloads.fullPathDownloads + "\\" + secondDate+fileName))
            {
                mgFileSVNCbtn.Image = statusDwnld;
                string path = mgSettings.mgFolderDonwloads.fullPathDownloads + "\\" + secondDate+fileName;
                try
                {
                    mgImportEntryDats(this, new EventArgs(), "dwn", path, "SVNC");
                    mgFileSVNCbtn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    Status = "Completed";
                }
                catch
                {
                    Status = "Downloaded";
                }
            }
            else
            {
                Status = "Failed";
            }

            switch (Status)
            {
                case "Completed":
                    mgFileSVNCbtn.Image = statusOK;
                    mgFileSVNCbtn.ToolTipText = "‘айл обработан";
                    break;
                case "Downloaded":
                    mgFileSVNCbtn.Image = statusDwnld;
                    mgFileSVNCbtn.ToolTipText = "‘айл загружен";
                    break;
                case "Failed":
                    mgFileSVNCbtn.Image = statusFailed;
                    mgFileSVNCbtn.ToolTipText = "ќшибка";
                    break;
            }
        }

        private void mgFileKF_Click(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            Image statusOK = ((System.Drawing.Image)(resources.GetObject("imgStatusOk.Image")));
            Image statusDwnld = ((System.Drawing.Image)(resources.GetObject("imgStatusDwnld.Image")));
            Image statusFailed = ((System.Drawing.Image)(resources.GetObject("imgStatusFailed.Image")));
            string Status = null;

            List<object> arguments = new List<object>();
            string fileName = mgSettings.rDateSVNC.Year + mgSettings.rDateSVNC.Month.ToString("00") + mgSettings.rDateSVNC.Day.ToString("00") + "_" + ((mgSettings.rDateSVNC.Month - 1).ToString("00")) + mgSettings.rDateSVNC.Year + "_koeff.xls";
            
            string urlLink = (string)urlLinksData[1];
            arguments.Add(urlLink);

            bgWorker = new BackgroundWorker();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += new DoWorkEventHandler(DownloadFile);

            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_DownloadProgressChanged);

            bgWorker.RunWorkerAsync(arguments);

            progressDlg = new ProgressDialog();
            progressDlg.stopProgress = new EventHandler((s, e1) => {
                switch (progressDlg.DialogResult)
                {
                    case DialogResult.Cancel:
                        bgWorker.CancelAsync();
                        progressDlg.Close();
                        break;
                }
            });
            progressDlg.ShowDialog();


            if (File.Exists(mgSettings.mgFolderDonwloads.fullPathDownloads + "\\" + fileName))
            {
                mgFileKFbtn.Image = statusDwnld;
                string path = mgSettings.mgFolderDonwloads.fullPathDownloads + "\\" + fileName;
                try
                {
                    mgImportEntryDats(this, new EventArgs(), "dwn", path, "KOEFF");
                    mgFileKFbtn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    Status = "Completed";
                }
                catch
                {
                    Status = "Downloaded";
                }
            }
            else
            {
                Status = "Failed";
            }

            switch (Status)
            {
                case "Completed":
                    mgFileKFbtn.Image = statusOK;
                    mgFileKFbtn.ToolTipText = "‘айл обработан";
                    break;
                case "Downloaded":
                    mgFileKFbtn.Image = statusDwnld;
                    mgFileKFbtn.ToolTipText = "‘айл загружен";
                    break;
                case "Failed":
                    mgFileKFbtn.Image = statusFailed;
                    mgFileKFbtn.ToolTipText = "ќшибка";
                    break;
            }
        }

        private bool checkRealeseFiles(string url)
        {
            bool result = false;

            var request = WebRequest.Create(url);
            request.Timeout = 1200;
            request.Method = "HEAD";

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                result = true;
            }
            catch (WebException webException)
            {

            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }

            return result;
        }

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private void DownloadFile(object sender, DoWorkEventArgs e)
        {
            List<object> genericlist = e.Argument as List<object>;
            string urlLink = (string)genericlist[0];

            string sUrlToDnldFile = urlLink;
            string sFileSavePath;
            BackgroundWorker worker = sender as BackgroundWorker;

            try
            {
                Uri url = new Uri(sUrlToDnldFile);

                string sFileName = Path.GetFileName(url.LocalPath);
                sFileSavePath = mgSettings.mgFolderDonwloads.fullPathDownloads + "\\" + sFileName;

                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();

                long iSize = response.ContentLength;
                long iRunningByteTotal = 0;

                WebClient client = new WebClient();
                Stream strRemote = client.OpenRead(url);
                FileStream strLocal = new FileStream(sFileSavePath, FileMode.Create, FileAccess.Write, FileShare.None);

                int iByteSize = 0;
                byte[] byteBuffer = new byte[1024];

                while ((iByteSize = strRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                {
                    strLocal.Write(byteBuffer, 0, iByteSize);
                    iRunningByteTotal += iByteSize;

                    double dIndex = (double)(iRunningByteTotal);
                    double dTotal = (double)iSize;
                    double dProgressPercentage = (dIndex / dTotal);
                    int iProgressPercentage = (int)(dProgressPercentage * 100);

                    worker.ReportProgress(iProgressPercentage);
                }
                strRemote.Close();
                strLocal.Close();
                response.Close();
            }
            catch (Exception exM)
            {
                MessageBox.Show("Error: " + exM.Message);
            }
        }

        private void mgBtnOpenFolder_Click(object sender, EventArgs e)
        {
            string filePath = Environment.CurrentDirectory;
            string argument = "\"" + filePath + "\"";

            System.Diagnostics.Process.Start("explorer.exe", argument);
        }

        private void mgBtnNewProject_Click(object sender, EventArgs e)
        {
            bool rFileKF;
            bool rFileSVNC;
            bool rFileSPUNC;
            DateTime date = DateTime.Now;

            urlLinksData.Clear();


            checkFolders();
            settingsPropertyValueChanged();

            txtProjectInfoName.Text = "mkg_" + mgSettings.mgCodeName.propGTPcode + "_" + date.ToString("MM") + date.ToString("yyyy");
            txtProjectMonth.Text = date.ToString("MMMM");
            txtProjectYear.Text = date.ToString("yyyy");

            getURLlinks();
            string urlLinkSVNC = (string)urlLinksData[0];
            string urlLinkKF = (string)urlLinksData[1];

            string urlLinkSPUNC = null;
            if(urlLinksData.Count >2)
            {
                urlLinkSPUNC = (string)urlLinksData[3];
            }

            rFileKF = checkRealeseFiles(urlLinkKF);
            if (rFileKF)
            {
                mgFileKFbtn.Visible = true;
                mgFileKFbtn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                mgToolStripInputData.Refresh();
            }
            else
            {
                mgFileKFbtn.Visible = false;
                mgFileKFbtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
                mgToolStripInputData.Refresh();
            }

            rFileSVNC = checkRealeseFiles(urlLinkSVNC);
            if (rFileSVNC)
            {
                mgFileSVNCbtn.Visible = true;
                mgFileSVNCbtn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                mgToolStripInputData.Refresh();
            }
            else
            {
                mgFileSVNCbtn.Visible = false;
                mgFileSVNCbtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
                mgToolStripInputData.Refresh();
            }

            rFileSPUNC = checkRealeseFiles(urlLinkSPUNC);
            if (rFileSPUNC)
            {
                mgFileSPUNCbtn.Visible = true;
                mgFileSPUNCbtn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                mgToolStripInputData.Refresh();
            }
            else
            {
                mgFileSPUNCbtn.Visible = false;
                mgFileSPUNCbtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
                mgToolStripInputData.Refresh();
            }

            DictionaryForm.loadDictionary(mgDatsList.isLoaded);

            mgDataViewer.DataSource = null;
            DataTable DT = (DataTable)mgDataViewer.DataSource;
            if (DT != null)
                DT.Clear();
            
            mgDataViewer.Rows.Clear();
            mgDataViewer.Refresh();

            mgBtnImportFile.Enabled = true;
            mgBtnEntryDatFiles.Enabled = true;
            toolBtnDictionaryList.Enabled = true;
            toolBtnDictionaryEditor.Enabled = true;
            mgBtnOpenFolder.Enabled = true;

            int idRow = 1;
            foreach (DataGridViewRow dictRow in DictionaryForm.dataGridDictionaryList.Rows)
            {
                if (!Convert.ToString(dictRow.Cells["Status"].Value).Equals("–асторгнут") && Convert.ToBoolean(dictRow.Cells["DocTC"].Value))
                {
                    mgDataViewer.Rows.Add(
                        idRow.ToString(),
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        dictRow.Cells["Agreement"].Value,
                        dictRow.Cells["FullName"].Value,
                        dictRow.Cells["DateAgreement"].Value,
                        dictRow.Cells["Type"].Value,
                        dictRow.Cells["TariffZone"].Value,
                        dictRow.Cells["NumCC"].Value,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        CheckState.Unchecked,
                        CheckState.Unchecked);
                    
                    mgDataViewer.Rows[idRow-1].Cells["GlobalStatus"].ToolTipText = "created";
                    idRow++;
                }
            }
        }

        private void checkFolders()
        {
            if (mgSettings.mgFolderProject.fullPathProject == null)
            {
                if (!Directory.Exists(Environment.CurrentDirectory + "\\" + mgSettings.mgCodeName.propGTPname))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\" + mgSettings.mgCodeName.propGTPname);
                    mgSettings.mgFolderProject.fullPathProject = Environment.CurrentDirectory + "\\" + mgSettings.mgCodeName.propGTPname;
                }
                else
                {
                    mgSettings.mgFolderProject.fullPathProject = Environment.CurrentDirectory + "\\" + mgSettings.mgCodeName.propGTPname;
                }
            }

            if (mgSettings.mgFolderAgreeDict.fullPathAgreeDictionary == null)
            {
                if (!Directory.Exists(Environment.CurrentDirectory + "\\" + mgSettings.mgCodeName.propGTPname + "\\data"))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\" + mgSettings.mgCodeName.propGTPname + "\\data");
                    mgSettings.mgFolderAgreeDict.fullPathAgreeDictionary = Environment.CurrentDirectory + "\\" + mgSettings.mgCodeName.propGTPname + "\\data";
                }
                else
                {
                    mgSettings.mgFolderAgreeDict.fullPathAgreeDictionary = Environment.CurrentDirectory + "\\" + mgSettings.mgCodeName.propGTPname + "\\data";
                }
            }

            if (mgSettings.mgFolderBanksDict.fullPathBanksDictionary == null)
            {
                if (!Directory.Exists(Environment.CurrentDirectory + "\\" + mgSettings.mgCodeName.propGTPname + "\\data"))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\" + mgSettings.mgCodeName.propGTPname + "\\data");
                    mgSettings.mgFolderBanksDict.fullPathBanksDictionary = Environment.CurrentDirectory + "\\" + mgSettings.mgCodeName.propGTPname + "\\data";
                }
                else
                {
                    mgSettings.mgFolderBanksDict.fullPathBanksDictionary = Environment.CurrentDirectory + "\\" + mgSettings.mgCodeName.propGTPname + "\\data";
                }
            }

            if (mgSettings.mgFolderDonwloads.fullPathDownloads == null)
            {
                if (!Directory.Exists(Environment.CurrentDirectory + "\\" + mgSettings.mgCodeName.propGTPname + "\\Downloads"))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\" + mgSettings.mgCodeName.propGTPname + "\\Downloads");
                    mgSettings.mgFolderDonwloads.fullPathDownloads = Environment.CurrentDirectory + "\\" + mgSettings.mgCodeName.propGTPname + "\\Downloads";
                }
                else
                {
                    mgSettings.mgFolderDonwloads.fullPathDownloads = Environment.CurrentDirectory + "\\" + mgSettings.mgCodeName.propGTPname + "\\Downloads";
                }
            }

            SettingsForm.optionsGrid.Refresh();
        }

        private void groupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Black, Color.FromArgb(255,100,100,100));
        }
        private void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);
                // Clear text and border
                g.Clear(box.BackColor);
                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);
                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }

        private void SplitterPaint(object sender, PaintEventArgs e)
        {
            SplitContainer l_SplitContainer = sender as SplitContainer;

            if (l_SplitContainer != null)
            {
                Rectangle ll_ShrinkedSplitterRectangle = l_SplitContainer.SplitterRectangle;
                ll_ShrinkedSplitterRectangle.Offset((ll_ShrinkedSplitterRectangle.Width/2)-20, 2);
                ll_ShrinkedSplitterRectangle.Height = ll_ShrinkedSplitterRectangle.Height - 2;
                ll_ShrinkedSplitterRectangle.Width = 40;
                e.Graphics.FillRectangle(Brushes.Gray, ll_ShrinkedSplitterRectangle);
            }
        }

        private void mgDataViewer_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            Image imgOpenFolder = (Image)resources.GetObject("mgBtnOpenFolder.Image");
            Image imgDataCalculation = (Image)resources.GetObject("mgData—alculation.Image");
            Image imgDataAct = (Image)resources.GetObject("mgDataAct.Image");

            if (e.RowIndex < 0)
                return;

            if (mgDataViewer.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType().Name == "DataGridViewButtonCell" && e.ColumnIndex == mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataTable"]))
            {
                if (!mgDataViewer.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText.Contains('+')) 
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    var w = imgListData.Images["ShowDataPreview.png"].Width;
                    var h = imgListData.Images["ShowDataPreview.png"].Height;
                    var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 1;
                    e.Graphics.DrawImage(imgListData.Images["ShowDataPreview.png"], new Rectangle(x, y - 2, w, h));
                    e.Handled = true;
                }
                else
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    var w = imgListData.Images["TableGroup.png"].Width;
                    var h = imgListData.Images["TableGroup.png"].Height;
                    var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 1;
                    e.Graphics.DrawImage(imgListData.Images["TableGroup.png"], new Rectangle(x, y - 2, w, h));
                    e.Handled = true;
                }
            }
            if (mgDataViewer.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType().Name == "DataGridViewButtonCell" && e.ColumnIndex == mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataExcel"]))
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = imgDataCalculation.Width;
                var h = imgDataCalculation.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 1;

                e.Graphics.DrawImage(imgDataCalculation, new Rectangle(x, y - 3, w, h));
                e.Handled = true;
            }
            if (mgDataViewer.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType().Name == "DataGridViewButtonCell" && e.ColumnIndex == mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["dataAct"]))
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = imgDataAct.Width;
                var h = imgDataAct.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 1;

                e.Graphics.DrawImage(imgDataAct, new Rectangle(x, y - 3, w, h));
                e.Handled = true;
            }
            if (mgDataViewer.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType().Name == "DataGridViewButtonCell" && e.ColumnIndex == mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["OpenFolder"]))
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = imgOpenFolder.Width;
                var h = imgOpenFolder.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 1;

                e.Graphics.DrawImage(imgOpenFolder, new Rectangle(x, y - 3, w, h));
                e.Handled = true;
            }
            if (e.ColumnIndex == mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["GlobalStatus"]))
            {
                var w = imgListData.ImageSize.Width;
                var h = imgListData.ImageSize.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 1;
                switch (mgDataViewer.Rows[e.RowIndex].Cells[mgDataViewer.Columns.IndexOf(mgDataViewer.Columns["GlobalStatus"])].ToolTipText.ToString())
                {
                    case "created":
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                        e.Graphics.DrawImage(imgListData.Images["OnlineStatusOffline.png"], new Rectangle(x, y - 2, w, h));
                        e.Handled = true;
                        break;
                    case "TableOK":
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                        e.Graphics.DrawImage(imgListData.Images["TableOK.png"], new Rectangle(x, y - 2, w, h));
                        e.Handled = true;
                        break;
                    case "TableWarning":
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                        e.Graphics.DrawImage(imgListData.Images["TableWarning.png"], new Rectangle(x, y - 2, w, h));
                        e.Handled = true;
                        break;
                    case "TableError":
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                        e.Graphics.DrawImage(imgListData.Images["TableError.png"], new Rectangle(x, y - 2, w, h));
                        e.Handled = true;
                        break;
                }
            }
        }



        private void mgBtnEntryDatFiles_ButtonClick(object sender, EventArgs e)
        {

        }

        private void getPageForExtractLinks()
        {
            string link = null;
            if (!mgSettings.defaultSiteLink.Contains("{%22YEAR%22:[%22"))
            {
                link = mgSettings.defaultSiteLink + "{%22YEAR%22:[%22" + txtProjectYear.Text + "%22]}";
            }
            else
            {
                link = mgSettings.defaultSiteLink;
            }

            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string page = client.DownloadString(link);
            DumpHRefs(page);
        }

        public void DumpHRefs(string page)
        {
            mgFileSPUNCselector.Items.Clear();
            System.Text.RegularExpressions.Match m;
            string HRefPattern = "<a href=\"https://cdn.tns-e.ru/iblock/(.*?/.*?)/(.*?)\">.*?</a>";

            try
            {
                m = Regex.Match(page, HRefPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline, TimeSpan.FromSeconds(1));
                while (m.Success)
                {
                    urlLinksData.Add("https://cdn.tns-e.ru/iblock/" + Convert.ToString(m.Groups[1]) + "/" + Convert.ToString(m.Groups[2]));
                    mgFileSPUNCselector.Items.Add(Convert.ToString(m.Groups[2]));
                    m = m.NextMatch();
                }

            }
            catch (RegexMatchTimeoutException)
            {
                Console.WriteLine("The matching operation timed out.");
            }
            if(mgFileSPUNCselector.Items.Count != 0)
            {
                mgFileSPUNCselector.Visible = false;
                mgFileSPUNCselector.SelectedIndex = 0;
                mgFileSPUNCselector.Size = new Size(DropDownWidth(mgFileSPUNCselector)+ 20, 25);
                mgFileSPUNCselector.DropDownWidth = DropDownWidth(mgFileSPUNCselector) + 20;
                mgToolStripInputData.Refresh();
            }
        }

        private void mgFileSPUNCselector_DropDownClosed(object sender, EventArgs e)
        {
            mgToolStripInputData.Focus();
        }

        int DropDownWidth(ToolStripComboBox myCombo)
        {
            int maxWidth = 0, temp = 0;
            foreach (var obj in myCombo.Items)
            {
                temp = TextRenderer.MeasureText(obj.ToString(), myCombo.Font).Width;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            return maxWidth;
        }

        public string currentGTP
        {
            get { return mgSettings.mgCodeName.propGTPname; }
        }

        public string currentProjectFolder
        {
            get { return mgSettings.mgFolderProject.fullPathProject; }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm.Owner = this;
            SettingsForm.Show();
        }

        private int GetTextHeight(TextBox tBox)
        {
            return TextRenderer.MeasureText(tBox.Text, tBox.Font, tBox.ClientSize,
                     TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl).Height;
        }

        private void TitleInfoBorderColor(object sender, TableLayoutCellPaintEventArgs e)
        {
            TableLayoutRowStyleCollection styles = upperTableLayoutMainData.RowStyles;

            var panel = sender as TableLayoutPanel;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            using (var pen = new Pen(Color.FromArgb(255,100,100,100), 1))
            {
                pen.Alignment = PenAlignment.Center;
                pen.DashStyle = DashStyle.Solid;

                if (e.Column == 0)
                {
                    var bottomLeft = new Point(e.CellBounds.Left+2, e.CellBounds.Bottom - (Convert.ToInt32(styles[e.Row].Height) - 20));
                    var bottomRight = new Point(e.CellBounds.Right, e.CellBounds.Bottom - (Convert.ToInt32(styles[e.Row].Height) - 20));
                    e.Graphics.DrawLine(pen, bottomLeft, bottomRight);
                }
            }
        }

        private void ProjectInfoBorderColor(object sender, TableLayoutCellPaintEventArgs e)
        {
            TableLayoutRowStyleCollection styles = ProjectInfoTableLayoutPanel.RowStyles;

            var panel = sender as TableLayoutPanel;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            var rectangle = e.CellBounds;
            using (var pen = new Pen(Color.FromArgb(255, 100, 100, 100), 1))
            {
                pen.Alignment = PenAlignment.Center;
                pen.DashStyle = DashStyle.Solid;

                if (e.Column == 0 || e.Column == 2)
                {
                    var bottomLeft = new Point(e.CellBounds.Left+2, e.CellBounds.Bottom - (Convert.ToInt32(styles[e.Row].Height) - 20));
                    var bottomRight = new Point(e.CellBounds.Right, e.CellBounds.Bottom - (Convert.ToInt32(styles[e.Row].Height) - 20));
                    e.Graphics.DrawLine(pen, bottomLeft, bottomRight);
                }
            }
        }

        private void propertiesBorderColor(object sender, TableLayoutCellPaintEventArgs e)
        {
            TableLayoutRowStyleCollection styles = ProjectInfoTableLayoutPanel.RowStyles;

            var panel = sender as TableLayoutPanel;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            var rectangle = e.CellBounds;
            using (var pen = new Pen(Color.FromArgb(255, 173, 173, 173), 1))
            {
                pen.Alignment = PenAlignment.Center;
                pen.DashStyle = DashStyle.Solid;

                if (e.Column == 0)
                {
                    var bottomLeft = new Point(e.CellBounds.Left + 2, e.CellBounds.Bottom - (Convert.ToInt32(styles[e.Row].Height) - 22));
                    var bottomRight = new Point(e.CellBounds.Right, e.CellBounds.Bottom - (Convert.ToInt32(styles[e.Row].Height) - 22));
                    e.Graphics.DrawLine(pen, bottomLeft, bottomRight);
                }
            }
        }


        private void mgDataViewer_SelectionChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ResourcesTreeView.Nodes.Count; i++)
                ResourcesTreeView.Nodes[i].Remove();

            ResourcesTreeView.BeginUpdate();
            ResourcesTreeView.Nodes.Add(mgDataViewer.Rows[mgDataViewer.CurrentCell.RowIndex].Cells["Agreement"].Value.ToString());
            ResourcesTreeView.EndUpdate();

            if (mgDataViewer.Rows[mgDataViewer.CurrentCell.RowIndex].Cells["dataTable"].GetType().Name == "DataGridViewButtonCell")
            {
                TreeNode parentNode = ResourcesTreeView.SelectedNode ?? ResourcesTreeView.Nodes[0];
                if (parentNode != null)
                {
                    if (mgDataViewer.Rows[mgDataViewer.CurrentCell.RowIndex].Cells["dataTable"].ToolTipText.Contains('+'))
                    {
                        parentNode.Nodes.Add(mgDataViewer.Rows[mgDataViewer.CurrentCell.RowIndex].Cells["dataTable"].ToolTipText.Split("+").First());
                        parentNode.Nodes[0].ImageIndex = detectErrorTable(mgDataViewer.CurrentCell.RowIndex, parentNode.Nodes[0].Text.Split("_").First());
                        parentNode.Nodes[0].SelectedImageIndex = detectErrorTable(mgDataViewer.CurrentCell.RowIndex, parentNode.Nodes[0].Text.Split("_").First());
                        parentNode.Nodes.Add(mgDataViewer.Rows[mgDataViewer.CurrentCell.RowIndex].Cells["dataTable"].ToolTipText.Split("+").Last());
                        parentNode.Nodes[1].ImageIndex = detectErrorTable(mgDataViewer.CurrentCell.RowIndex, parentNode.Nodes[1].Text.Split("_").First());
                        parentNode.Nodes[1].SelectedImageIndex = detectErrorTable(mgDataViewer.CurrentCell.RowIndex, parentNode.Nodes[1].Text.Split("_").First());
                        ResourcesTreeView.ExpandAll();
                    }
                    else
                    {
                        parentNode.Nodes.Add(mgDataViewer.Rows[mgDataViewer.CurrentCell.RowIndex].Cells["dataTable"].ToolTipText);
                        parentNode.Nodes[0].ImageIndex = detectErrorTable(mgDataViewer.CurrentCell.RowIndex, parentNode.Nodes[0].Text.Split("_").First());
                        parentNode.Nodes[0].SelectedImageIndex = detectErrorTable(mgDataViewer.CurrentCell.RowIndex, parentNode.Nodes[0].Text.Split("_").First());
                        ResourcesTreeView.ExpandAll();
                    }
                }
            }
        }

        private int detectErrorTable(int row, string type)
        {
            int index = 1;
            switch (Convert.ToString(mgDataViewer.Rows[row].Cells[type + "StatusError"].Value))
            {
                case "Checked":
                    index = 5;
                    break;

                case "Unchecked":
                    index = 21;
                    break;
                    
                case "Indeterminate":
                    index = 22;
                    break;
                case "False":
                    index = 21;
                    break;
            }
            return index;
        }


        private void mgDataViewer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var cellMethod = (DataGridViewComboBoxCell)mgDataViewer.Rows[e.RowIndex].Cells["Method"];
            cmbxMethod.Items.Clear();
            if (cellMethod.Items.Count != 0)
            {
                foreach (var item in cellMethod.Items)
                {
                    switch (item.ToString())
                    {
                        case "intg":
                            cmbxMethod.Items.Add("»нтервалы");
                            break;

                        case "hrs":
                            cmbxMethod.Items.Add("„асы");
                            break;
                    }
                }
            }

            int indx = cellMethod.Items.IndexOf(Convert.ToString(mgDataViewer.Rows[e.RowIndex].Cells["Method"].Value));
            if (indx != -1)
            {
                cmbxMethod.Text = cmbxMethod.Items[indx].ToString();
            }

        }

        private void cmbxMethod_DropDownClosed(object sender, EventArgs e)
        {
            if(cmbxMethod.SelectedIndex != -1)
            {
                var methodCell = (DataGridViewComboBoxCell)mgDataViewer.Rows[mgDataViewer.CurrentCell.RowIndex].Cells["Method"];
                methodCell.Value = methodCell.Items[cmbxMethod.SelectedIndex];
            }
            
        }

        private void FlowPanelButtonAddTable_Click(object sender, EventArgs e)
        {
            inputDataHandle inputDatForm = new inputDataHandle();
            inputDatForm.Show();
        }

        private void FlowPanelButtonDeleteAllTables_Click(object sender, EventArgs e)
        {
            List<Button> listOfButtons = new List<Button>();
            foreach (Button buttons in mgFlowPanelResult.Controls.OfType<Button>())
            {
                switch(buttons.Text.Split('_').First())
                {
                    case "hrs":
                        if (HoursDataSet.Tables.Contains(buttons.Text))
                        {
                            DataTable dtDelete = HoursDataSet.Tables[buttons.Text];
                            DataTable dtDeleteHeader = HoursDataSet.Tables[buttons.Text + "_header"];
                            if (HoursDataSet.Tables.CanRemove(dtDelete))
                            {
                                listOfButtons.Add(buttons);
                                HoursDataSet.Tables.Remove(dtDelete);
                                HoursDataSet.Tables.Remove(dtDeleteHeader);
                            }
                        }
                        break;

                    case "intg":
                        if (IntegralsDataSet.Tables.Contains(buttons.Text))
                        {
                            DataTable dtDelete = IntegralsDataSet.Tables[buttons.Text];
                            DataTable dtDeleteHeader = IntegralsDataSet.Tables[buttons.Text+"_header"];
                            if (IntegralsDataSet.Tables.CanRemove(dtDelete))
                            {
                                listOfButtons.Add(buttons);
                                IntegralsDataSet.Tables.Remove(dtDelete);
                                IntegralsDataSet.Tables.Remove(dtDeleteHeader);
                            }
                        }
                        break;
                }
            }
            foreach (Button removed in listOfButtons)
            {
                mgFlowPanelResult.Controls.Remove(removed);
            }
        }
    }
    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }

    public class ImportList
    {
        public static List<string> ProvidersList = new List<string>() { };
        public static List<string> AvailableMode = new List<string>() { };
        public static List<string> AvailablePages = new List<string>() { };
        public static List<string> KnownGTPnames = new List<string>() { "KUBANESK", "ROSTOVEN", "YARENERG", "TULAENSK", "ENTREDIN", "NIGNOVEN", "MARIENER", "KARELENE", "VORNEGEN", "GARENERC" };
        public static List<string> KnownGTPcode = new List<string>() { "PKUBANEN", "PROSTOVE", "PYARENER", "PTULENER", "PPENZAEN", "PNIGNOVE", "PMARIENE", "PKARELEN", "PVORNEGE", "PNOVGORE" };
        public static List<string> defaultSiteLinks = new List<string>() {
            "https://kuban.tns-e.ru/disclosure/reporting/predelnye-urovni-nereguliruemykh-tsen-na-elektroenergiyu-moshchnost-postavlyaemuyu-potrebitelyam-pok/?PARAMS=",
            "https://rostov.tns-e.ru/disclosure/reporting/nereguliruem-tsen/?PARAMS=",
            "https://yar.tns-e.ru/disclosure/reporting/sredn-nereguliruemaya-tsena/?PARAMS=",
            "https://tula.tns-e.ru/disclosure/reporting/nereguliruem-tsen/?PARAMS=",
            "https://penza.tns-e.ru/disclosure/reporting/sred-nereg-tsena/?PARAMS=",
            "https://nn.tns-e.ru/disclosure/reporting/predelnye-urovni/?PARAMS=",
            "https://mari-el.tns-e.ru/disclosure/reporting/sostavlyayushchie-tseny-na-elektricheskuyu-energiyu-moshchnost-differentsirovannoy-v-zavisimosti-ot-/?PARAMS=",
            "https://karelia.tns-e.ru/disclosure/reporting/nereg-sostav-pokupki-poter/?PARAMS=",
            "https://voronezh.tns-e.ru/disclosure/reporting/predelnye-urovni-nereguliruemykh-tsen/?PARAMS=",
            "https://novgorod.tns-e.ru/disclosure/reporting/predelnye-urovni-nereguliruemykh-tsen-na-elektricheskuyu-energiyu-moshchnost/?PARAMS=" };

        public static void CheckProviders()
        {
            int i = 0;
            DataTable table = new OleDbEnumerator().GetElements();
            foreach (DataRow row in table.Rows)
            {
                if (row["SOURCES_NAME"].ToString() == "Microsoft.ACE.OLEDB.12.0" | row["SOURCES_NAME"].ToString() == "Microsoft.Jet.OLEDB.4.0")
                {
                    Console.WriteLine("Provider registred: " + row["SOURCES_NAME"]);
                    ProvidersList.Add(row["SOURCES_NAME"].ToString());
                    i++;
                }
            }

            Type officeType = Type.GetTypeFromProgID("Excel.Application");
            if (officeType != null)
            {
                AvailableMode.Add("Excel Interop");
            }

            AvailableMode.Add("NPOI");
            AvailableMode.Add("EPPlus");

            if (i != 0)
            {
                AvailableMode.Add("OleDB");
            }
        }
    }
}