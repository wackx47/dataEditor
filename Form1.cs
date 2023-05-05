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

namespace dataEditor
{
    public partial class MainForm : Form
    {
        Version OsMinVersion = new Version(10, 0, 15063, 0);

        iniFile INI = new iniFile("config.ini");
        Form TreeView = new Form();
        Form TableView = new Form();
        TextBox TextExtractColumns = new TextBox();
        DataGridView TreeColViewer = new DataGridView();
        DataSet UniversalDataSet = new DataSet("UniversalFileReader");
        Button ConfirmCols = new Button();

        public static mgDatsList DictionaryForm = new mgDatsList();

        int cntShows = 0;
        int HFR = 0;
        int prvCntHedRw = 2;
        int RowsCnt = 0;
        int ColsCnt = 0;
        int FirstUsedRow = 1;
        int FirstUsedColumn = 1;
        bool allowVoid = false;
        bool lockVoid = false;
        bool useOleDB = false;
        string xmlFileName = "";
        string ExlFileName = null;
        string memSQLlist = null;
        string defaultSQL = null;
        string OpenFileKey = null;

        CheckBox headerCheckBox = new CheckBox();
        DataGridViewCell ActiveCell = null;
        DataGridViewColumn ActiveColumn = null;

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
        String[] SQLdbTemp = { };
        String[] SQLdbTempB = { };
        String[] SQLdbTempC = { };

        DataTable dt_db_shema = new DataTable();

        PropertySet PropGrid = new PropertySet();

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

        public MainForm()
        {
            InitializeComponent();
            AllocConsole();
            Magician.DisappearConsole();
            ReadINI();
            optionsGrid.SelectedObject = PropGrid;
            splitContainer_rightProps.Panel1Collapsed = true;
            Console.WriteLine("Soft powered by 47 5'9 (ver. " + PropGrid.AppVersion + ") //.build for GitHub");
            ImportList.CheckProviders();
            StartPage();
            addAvailableProviders(this, new EventArgs());
            TypeDescriptor.GetProperties(this.optionsGrid.SelectedObject)["ExtraColCnt"].SetReadOnlyAttribute(true);
            PropGrid.ImportMode = ImportList.AvailableMode[0];
            PropGrid.Region = "KUBANESK";
            DictionaryForm.dictListGTP.Text = PropGrid.Region;
        }

        public static void ScaleControlElements(DataGridView ScaleSource, SizeF ScaleFactor)
        {
            foreach (DataGridViewColumn Column in ScaleSource.Columns)
            {
                Column.Width = (int)Math.Round(Column.Width * ScaleFactor.Width);
            }
        }

        protected override void ScaleControl(SizeF ScalingFactor, BoundsSpecified Bounds)
        {
            base.ScaleControl(ScalingFactor, Bounds);
            ScaleControlElements(dataViewer, ScalingFactor);
            Console.WriteLine("DPI scaling enabled");
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {

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

            foreach (string s in PropGrid.sqlArray)
                memSQLlist += s + ";";

            if (defaultSQL != null | defaultSQL != "")
            {
                string[] loadSQLarray = defaultSQL.Split(';');
                loadSQLarray = loadSQLarray.SkipLast(1).ToArray();
                PropGrid.sqlArray = loadSQLarray;
            }
            AutoFillList();
            CheckRegLib();

            tempPropColors.Add(PropGrid.ColorHeads);
            tempPropColors.Add(PropGrid.ColorDataRows);
            tempPropColors.Add(PropGrid.ColorStaticDat);
            tempPropColors.Add(PropGrid.SecondColorHeads);

            if (PropGrid.ShowHelpPropetryGrid == true)
            {
                optionsGrid.HelpVisible = !optionsGrid.HelpVisible;
                helpToolStripMenuItem.Checked = !helpToolStripMenuItem.Checked;
            }

            if (PropGrid.ShowConsoleOnStartUp == true)
            {
                Magician.AppearConsole();
                DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
                showConsoleToolStripMenuItem.Checked = true;
            }

            if (ImportList.ProvidersList.Count != 0)
                PropGrid.OleDBImportMode.VersionOleDB = ImportList.ProvidersList[0];
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
                    if (rws.DefaultCellStyle.BackColor == PropGrid.ColorHeads | rws.DefaultCellStyle.BackColor == PropGrid.ColorHeads | rws.DefaultCellStyle.BackColor == PropGrid.ColorDataRows | rws.DefaultCellStyle.BackColor == PropGrid.ColorDataRows)
                    {
                        rws.DefaultCellStyle.BackColor = Color.Empty;
                        rws.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                if (Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value) > 0)
                {
                    HFR = Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value)- (FirstUsedRow-1);

                    int ls = (Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value) + PropGrid.cntHeadsRows);
                    if (ls >= FirstUsedRow + RowsCnt)
                        mxRw = ls - 1;
                    else
                        mxRw = ls;

                    statusGridView.Rows[3].Cells[1].Value = null;
                    statusGridView.Rows[3].Cells[1] = new NumericUpDownDataGrid.NumericUpDownCell(mxRw, FirstUsedRow - 1 + RowsCnt);

                    dataViewer.Rows[Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value) - (FirstUsedRow)].DefaultCellStyle.BackColor = PropGrid.ColorHeads;
                    dataViewer.Rows[Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value) - (FirstUsedRow)].DefaultCellStyle.ForeColor = fntCl;

                    if (PropGrid.DRow == true)
                    {
                        for (int i = 1; i < Convert.ToInt32(PropGrid.cntHeadsRows); i++)
                        {
                            if (Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value) - (FirstUsedRow) + i < dataViewer.RowCount)
                            {
                                dataViewer.Rows[Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value) - (FirstUsedRow) + i].DefaultCellStyle.BackColor = PropGrid.ColorHeads;
                                dataViewer.Rows[Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value) - (FirstUsedRow) + i].DefaultCellStyle.ForeColor = fntCl;
                            }
                        }
                    }
                }
                TreeFormDestroyer();
                dataViewer.ClearSelection();
                optionsGrid.Refresh();
                urBtnConvert2Tree.Enabled = true;
            }

            if (dataViewer.DataSource != null && statusGridView.Rows[3].Cells[1].Value != null && statusGridView.CurrentCellAddress.X == 1 && statusGridView.CurrentCellAddress.Y == 3 || statusGridView.CurrentCellAddress.Y == 4)
            {
                foreach (DataGridViewRow row in dataViewer.Rows)
                {
                    if (row.DefaultCellStyle.BackColor == PropGrid.ColorDataRows | row.DefaultCellStyle.BackColor == PropGrid.ColorDataRows)
                    {
                        row.DefaultCellStyle.BackColor = Color.Empty;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }

                if (Convert.ToInt32(statusGridView.Rows[3].Cells[1].Value) > 0)
                {
                    dataViewer.Rows[Convert.ToInt32(statusGridView.Rows[3].Cells[1].Value)-(FirstUsedRow)].DefaultCellStyle.BackColor = PropGrid.ColorDataRows;
                    dataViewer.Rows[Convert.ToInt32(statusGridView.Rows[3].Cells[1].Value)-(FirstUsedRow)].DefaultCellStyle.ForeColor = fntClDat;

                    for (int i = (Convert.ToInt32(statusGridView.Rows[3].Cells[1].Value)-(FirstUsedRow) + Convert.ToInt32(statusGridView.Rows[4].Cells[1].Value) + 1); i < RowsCnt-(FirstUsedRow); i += Convert.ToInt32(statusGridView.Rows[4].Cells[1].Value) + 1)
                    {
                        if (dataViewer.Rows[i].Cells[1].Value != DBNull.Value)
                        {
                            dataViewer.Rows[i].DefaultCellStyle.BackColor = PropGrid.ColorDataRows;
                            dataViewer.Rows[i].DefaultCellStyle.ForeColor = fntClDat;
                        }
                    }
                }
                dataViewer.ClearSelection();
                optionsGrid.Refresh();
            }
        }

        private void AutoFillList()
        {
            SQLdata.Clear();
            memSQLlist = null;
            string[] subs = PropGrid.sqlArray;
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
                    PropGrid.ColorHeads = Color.FromName(INI.ReadINI("Visuals", "ColorHeaders"));
                }
                if (INI.KeyExists("ColorHeaders(ListView)", "Visuals"))
                {
                    PropGrid.SecondColorHeads = Color.FromName(INI.ReadINI("Visuals", "ColorHeaders(ListView)"));
                }
                if (INI.KeyExists("ColorDataRows", "Visuals"))
                {
                    PropGrid.ColorDataRows = Color.FromName(INI.ReadINI("Visuals", "ColorDataRows"));
                }
                if (INI.KeyExists("ColorStaticCell", "Visuals"))
                {
                    PropGrid.ColorStaticDat = Color.FromName(INI.ReadINI("Visuals", "ColorStaticCell"));
                }
                if (INI.KeyExists("ForceCloseAllExcel", "Other"))
                {
                    PropGrid.ForceCloseExl = bool.Parse(INI.ReadINI("Other", "ForceCloseAllExcel"));
                }
                if (INI.KeyExists("ShowConsoleOnStartUp", "Other"))
                {
                    PropGrid.ShowConsoleOnStartUp = bool.Parse(INI.ReadINI("Other", "ShowConsoleOnStartUp"));
                }
                if (INI.KeyExists("ShowHelpPropetryGrid", "Other"))
                {
                    PropGrid.ShowHelpPropetryGrid = bool.Parse(INI.ReadINI("Other", "ShowHelpPropetryGrid"));
                }
                if (INI.KeyExists("UseOLEDBprovider", "Other"))
                {
                    //PropGrid.OleDBImportMode.useOleDBMode = bool.Parse(INI.ReadINI("Other", "UseOLEDBprovider"));
                }

                if (defaultSQL == null | defaultSQL == "")
                    defaultSQL = "Name;Dat8;Type;Is_fact;OAO;GTP_Kod;GTP;Nomer_Dog;Kontragent;K_GTP_Kod;K_GTP;Dog_V;V;S;S_NDS";

                autoFontColor();
                optionsGrid.Refresh();
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
            if (optionsGrid.SelectedGridItem.GridItemType == GridItemType.Category)
            {
                categories = optionsGrid.SelectedGridItem.Parent.GridItems;
            }
            else
            {
                categories = optionsGrid.SelectedGridItem.Parent.Parent.GridItems;
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
                if (PropGrid.DRow == true)
                {
                    dataViewer.Rows[e.RowIndex + 1].DefaultCellStyle.BackColor = Color.PowderBlue;
                    dataViewer.Rows[e.RowIndex + 1].Cells[0].Value = true;
                    RightClick_HeadsRow.Enabled = true;
                }
            }
            optionsGrid.Refresh();
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
            optionsGrid.Refresh();
        }

        private void DynamicCycleData_Click(object sender, EventArgs e)
        {

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
            if(dataViewer.Rows[ActiveCell.RowIndex].Cells[ActiveCell.ColumnIndex].Style.BackColor == PropGrid.ColorStaticDat)
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
                dataViewer.Rows[ActiveCell.RowIndex].Cells[ActiveCell.ColumnIndex].Style.BackColor = PropGrid.ColorStaticDat;
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

        private void cellStripMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
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
                string[] SQLdataTemp = PropGrid.sqlArray;


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
            DataTable dt = new DataTable();
            DataTable dte = new DataTable();


            if (statusGridView.Rows[5].Cells[1].Value == null)
            {
                dt.TableName = "usedColumns";
                dte.TableName = "commonSettings";
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
            rwe["extraColumns"] = PropGrid.ExtraColCnt;
            rwe["headsRow"] = statusGridView.Rows[2].Cells[1].Value;
            rwe["firstData"] = statusGridView.Rows[3].Cells[1].Value;
            rwe["columnsCount"] = statusGridView.Rows[1].Cells[1].Value;
            rwe["columnsCheck"] = statusGridView.Rows[6].Cells[1].Value;
            dte.Rows.Add(rwe);

            TreeView.Hide();
            optionsGrid.Refresh();
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
                    rw.DefaultCellStyle.BackColor = PropGrid.SecondColorHeads;
                    rw.DefaultCellStyle.ForeColor = fntTreeCl;
                    rw.Cells[2].ReadOnly = false;
                    rowsChkCounts++;
                }
                if (rw.Cells[2].Value == null && rw.Cells[0].Value != "" && Convert.ToBoolean(rw.Cells[0].EditedFormattedValue) == true)
                {
                    DataGridViewComboBoxCell cellSQL = new DataGridViewComboBoxCell();
                    cellSQL.DataSource = SQLdbTemp;
                    TextExtractColumns.Text += rw.HeaderCell.Value + ";";
                    rw.DefaultCellStyle.BackColor = PropGrid.SecondColorHeads;
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
                            TreeColViewer.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(255, PropGrid.SecondColorHeads.R / 2, PropGrid.SecondColorHeads.G / 2, PropGrid.SecondColorHeads.B / 2);
                            if (PropGrid.SecondColorHeads.R / 2 < 120 | PropGrid.SecondColorHeads.G / 2 < 120 | PropGrid.SecondColorHeads.B / 2 < 120)
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
                    if (rowsChkCounts >= SQLdata.Count + PropGrid.ExtraColCnt && rw.Cells[0].Value != "" && Convert.ToBoolean(rw.Cells[0].EditedFormattedValue) == false)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)rw.Cells[0];
                        chk.FlatStyle = FlatStyle.Flat;
                        chk.Style.ForeColor = Color.DarkGray;
                        chk.ReadOnly = true;
                    }
                    if (rowsChkCounts < SQLdata.Count + PropGrid.ExtraColCnt && rw.Cells[0].Value != "")
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
            if (File.Exists(Environment.CurrentDirectory + "\\contractors_" + PropGrid.Region + ".xml"))
            {
                string xmlFileName = Environment.CurrentDirectory + "\\contractors_" + PropGrid.Region + ".xml";

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
            Console.WriteLine(label + "\n");
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
                    PropGrid.ImportMode = "Excel Interop";
                    optionsGrid.Refresh();
                    break;

                case "NPOI":
                    PropGrid.ImportMode = "NPOI";
                    optionsGrid.Refresh();
                    break;

                case "EPPlus":
                    PropGrid.ImportMode = "EPPlus";
                    optionsGrid.Refresh();
                    break;

                case "OleDB":
                    PropGrid.ImportMode = "OleDB";
                    optionsGrid.Refresh();
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

            Console.WriteLine("Open new Excel file: " + ExlFileName + " by " + PropGrid.ImportMode.ToString());

            switch (PropGrid.ImportMode)
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
                            if (Path.GetExtension(xlFileName) == ".xlsx")
                            {
                                XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
                                XSSFFormulaEvaluator xsseva = new XSSFFormulaEvaluator(xssWorkbook);
                                wSheet = xssWorkbook.GetSheetAt(0);
                                NPOIModeImport(dataExtraction, xlFileName, wSheet, xsseva, null);
                            }
                            else
                            {
                                HSSFWorkbook hssWorkbook = new HSSFWorkbook(stream);
                                HSSFFormulaEvaluator hsseva = new HSSFFormulaEvaluator(hssWorkbook);
                                wSheet = hssWorkbook.GetSheetAt(0);
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
                    if (Path.GetExtension(xlFileName) == ".xlsx" && PropGrid.OleDBImportMode.VersionOleDB == "Microsoft.Jet.OLEDB.4.0")
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

            DataGridView mgDt = mgWorkDataViewer;
            mgWorkDataViewer.DataSource = null;
            DataTable dataExtraction = new DataTable();
            DataTable DT = (DataTable)mgWorkDataViewer.DataSource;
            if (DT != null)
                DT.Clear();

            mgWorkDataViewer.Rows.Clear();
            mgWorkDataViewer.Refresh();
            int count = this.mgWorkDataViewer.Columns.Count;
            for (int i = 0; i < count; i++)
                this.mgWorkDataViewer.Columns.RemoveAt(0);

            commonImportEXCL(this, new EventArgs(), dataExtraction, xlFileName);
            mgWorkDataViewer.DataSource = dataExtraction;
            dataViewerFillHeadres(FirstUsedRow, FirstUsedColumn, mgDt);

            mgWorkDataViewer.AllowUserToAddRows = false;
            mgWorkDataViewer.AllowUserToDeleteRows = false;
            mgWorkDataViewer.EnableHeadersVisualStyles = false;
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

            tempPropVal.Add(PropGrid.cntHeadsRows);
            splitContainer_rightProps.Panel1Collapsed = false;
            optionsGrid.Refresh();

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
            xlWB = xlApp.Workbooks.Add(xlFileName);
            xlSht = xlWB.Worksheets[1];
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

            if (PropGrid.CheckEmptyRows.SwitchChecks == true)
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
                    
            if (PropGrid.OleDBImportMode.VersionOleDB == "Microsoft.Jet.OLEDB.4.0")    
                ExlVer = "8";
                    strConnect = @"Provider=" + PropGrid.OleDBImportMode.VersionOleDB + ";" +
                                 @"Data Source=" + xlFileName + ";" +
                                 @"Extended Properties=" + Convert.ToChar(34).ToString() +
                                 @"Excel " + ExlVer + ".0;HDR=" + PropGrid.OleDBImportMode.strHDR + ";IMEX=" + PropGrid.OleDBImportMode.IMEX.ToString() + ";" + Convert.ToChar(34).ToString() + ";";

             int xlColCount = 0;

                    using (OleDbConnection connect = new OleDbConnection(strConnect))
                    {
                        connect.Open();
                        DataTable schemaTable = connect.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                        string sheetName = schemaTable.Rows[0]["TABLE_NAME"].ToString();
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
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.First();
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

                            if (PropGrid.CheckEmptyRows.SwitchChecks == true)
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
                if (RowEmptyStrike <= PropGrid.CheckEmptyRows.EmptyRowsLimit)
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
                    if (ColmEmptyStrike >= PropGrid.CheckEmptyRows.EmptyColmLimit)
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
            statusGridView.Rows[2].Cells[1] = new NumericUpDownDataGrid.NumericUpDownCell(FirstUsedRow, ((FirstUsedRow+maxRows) - PropGrid.cntHeadsRows));

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
            TypeDescriptor.GetProperties(this.optionsGrid.SelectedObject)["DRow"].SetReadOnlyAttribute(false);
            TypeDescriptor.GetProperties(this.optionsGrid.SelectedObject)["cntHeadsRows"].SetReadOnlyAttribute(false);
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
                if (rws.DefaultCellStyle.BackColor == PropGrid.ColorHeads | rws.DefaultCellStyle.BackColor == PropGrid.ColorHeads | rws.DefaultCellStyle.BackColor == PropGrid.ColorDataRows | rws.DefaultCellStyle.BackColor == PropGrid.ColorDataRows)
                {
                    rws.DefaultCellStyle.BackColor = Color.Empty;
                    rws.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            if (ActiveCell.RowIndex >= 0 && ActiveCell.ColumnIndex == 0 && ActiveCell.RowIndex+ Convert.ToInt32(PropGrid.cntHeadsRows) <= RowsCnt)
            {
                HFR = ActiveCell.RowIndex + 1;
                statusGridView.Rows[2].Cells[1].Value = Convert.ToInt32(dataViewer.Rows[ActiveCell.RowIndex].HeaderCell.Value.ToString().Split(' ').Last());

                int ls = (Convert.ToInt32(statusGridView.Rows[2].Cells[1].Value) + PropGrid.cntHeadsRows);
                if (ls >= FirstUsedRow + RowsCnt)
                    mxRw = ls - 1;
                else
                    mxRw = ls;

                statusGridView.Rows[3].Cells[1].Value = null;
                statusGridView.Rows[3].Cells[1] = new NumericUpDownDataGrid.NumericUpDownCell(mxRw, FirstUsedRow+RowsCnt);

                dataViewer.Rows[ActiveCell.RowIndex].DefaultCellStyle.BackColor = PropGrid.ColorHeads;
                dataViewer.Rows[ActiveCell.RowIndex].DefaultCellStyle.ForeColor = fntCl;

                if (PropGrid.DRow == true)
                {
                    for (int i = 1; i < Convert.ToInt32(PropGrid.cntHeadsRows); i++)
                    {
                        dataViewer.Rows[ActiveCell.RowIndex + i].DefaultCellStyle.BackColor = PropGrid.ColorHeads;
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
            optionsGrid.Refresh();
        }

        private void StripMenuFirstData_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataViewer.Rows)
            {
                if (row.DefaultCellStyle.BackColor == PropGrid.ColorDataRows | row.DefaultCellStyle.BackColor == PropGrid.ColorDataRows)
                {
                    row.DefaultCellStyle.BackColor = Color.Empty;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            if (ActiveCell != null && ActiveCell.RowIndex <= RowsCnt)
            {
                statusGridView.Rows[3].Cells[1].Value = Convert.ToInt32(dataViewer.Rows[(ActiveCell.RowIndex)].HeaderCell.Value.ToString().Split(' ').Last());
                dataViewer.Rows[(ActiveCell.RowIndex)].DefaultCellStyle.BackColor = PropGrid.ColorDataRows;
                dataViewer.Rows[(ActiveCell.RowIndex)].DefaultCellStyle.ForeColor = fntClDat;

                for (int i = (ActiveCell.RowIndex + Convert.ToInt32(statusGridView.Rows[4].Cells[1].Value) + 1); i < RowsCnt-1; i += Convert.ToInt32(statusGridView.Rows[4].Cells[1].Value) + 1)
                {
                    if (dataViewer.Rows[i].Cells[1].Value != DBNull.Value)
                    {
                        dataViewer.Rows[i].DefaultCellStyle.BackColor = PropGrid.ColorDataRows;
                        dataViewer.Rows[i].DefaultCellStyle.ForeColor = fntClDat;
                    }
                }
                dataViewer.ClearSelection();
                statusGridView.ClearSelection();
                optionsGrid.Refresh();
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
                optionsGrid.HelpVisible = !optionsGrid.HelpVisible;
                helpToolStripMenuItem.Checked = !helpToolStripMenuItem.Checked;
        }

        private void optionsGrid_PropertyValueChanged(Object sender, PropertyValueChangedEventArgs e)
        {

            if (PropGrid.useExtraCol == true)
            {
                TypeDescriptor.GetProperties(this.optionsGrid.SelectedObject)["ExtraColCnt"].SetReadOnlyAttribute(false);
            }
            
            if (PropGrid.useExtraCol == false)
            {
                TypeDescriptor.GetProperties(this.optionsGrid.SelectedObject)["ExtraColCnt"].SetReadOnlyAttribute(true);
                PropGrid.ExtraColCnt = 0;
            }

            if (PropGrid.DRow == true && PropGrid.cntHeadsRows < 2)
            {
                TypeDescriptor.GetProperties(this.optionsGrid.SelectedObject)["cntHeadsRows"].SetReadOnlyAttribute(false);
                PropGrid.cntHeadsRows = 2;
            }

            if (PropGrid.DRow == false)
            {
                TypeDescriptor.GetProperties(this.optionsGrid.SelectedObject)["cntHeadsRows"].SetReadOnlyAttribute(true);
                PropGrid.cntHeadsRows = 1;
            }

            if (PropGrid.ExtraColCnt > 10)
                PropGrid.ExtraColCnt = 10;

            

            if (PropGrid.cntHeadsRows != prvCntHedRw)
            {
                prvCntHedRw = PropGrid.cntHeadsRows;
                TreeFormDestroyer();
            }

            string temp = null;
            foreach (string s in PropGrid.sqlArray)
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
                if (PropGrid.cntHeadsRows > RowsCnt)
                { PropGrid.cntHeadsRows = RowsCnt; }
                updateStatusGrid(PropGrid.cntHeadsRows);
            }
            optionsGrid.Refresh();
        }

        private void updateDataGridColors()
        {
            foreach (DataGridViewRow row in dataViewer.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.FromName(tempPropColors[0].Name))
                {
                    row.DefaultCellStyle.BackColor = PropGrid.ColorHeads;
                    row.DefaultCellStyle.ForeColor = fntCl;
                }
                if (row.DefaultCellStyle.BackColor == Color.FromName(tempPropColors[1].Name))
                {
                    row.DefaultCellStyle.BackColor = PropGrid.ColorDataRows;
                    row.DefaultCellStyle.ForeColor = fntClDat;
                }
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Style.BackColor == Color.FromName(tempPropColors[2].Name))
                    {
                        cell.Style.BackColor = PropGrid.ColorStaticDat;
                        cell.Style.ForeColor = fntClStaticDat;
                    }
                }
            }
            tempPropColors[0] = PropGrid.ColorHeads;
            tempPropColors[1] = PropGrid.ColorDataRows;
            tempPropColors[2] = PropGrid.ColorStaticDat;
            tempPropColors[3] = PropGrid.SecondColorHeads;
        }

        private void updateStatusGrid(int lastVal)
        {
            if (tempPropVal[0] != lastVal && TypeDescriptor.GetProperties(this.optionsGrid.SelectedObject)["cntHeadsRows"].IsReadOnly == false)
            {
                statusGridView.Rows[2].Cells[1].Value = null;
                statusGridView.Rows[2].Cells[1] = new NumericUpDownDataGrid.NumericUpDownCell(FirstUsedRow, (RowsCnt - PropGrid.cntHeadsRows) + 1);
                statusGridView.Rows[5].Cells[1].Value = null;

                foreach (DataGridViewRow rws in dataViewer.Rows)
                {
                    if (rws.DefaultCellStyle.BackColor == PropGrid.ColorHeads | rws.DefaultCellStyle.BackColor == PropGrid.ColorHeads)
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
            if (PropGrid.ColorHeads.R < 120 | PropGrid.ColorHeads.G < 120 | PropGrid.ColorHeads.B < 120)
                fntCl = Color.White;
            else
                fntCl = Color.Black;

            if (PropGrid.ColorDataRows.R < 120 | PropGrid.ColorDataRows.G < 120 | PropGrid.ColorDataRows.B < 120)
                fntClDat = Color.White;
            else
                fntClDat = Color.Black;

            if (PropGrid.SecondColorHeads.R < 100 | PropGrid.SecondColorHeads.G < 100 | PropGrid.SecondColorHeads.B < 120)
                fntTreeCl = Color.White;
            else
                fntTreeCl = Color.Black;

            if (PropGrid.ColorStaticDat.R < 100 | PropGrid.ColorStaticDat.G < 100 | PropGrid.ColorStaticDat.B < 120)
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
                //Thread.Sleep(5);
                }
            }
            if (PropGrid.CheckEmptyRows.SwitchChecks == true)
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

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressDlg.Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DictionaryForm.Dispose();
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;

            if (PropGrid.ForceCloseExl == true)
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

        private void MounthTab_Selected(object sender, TabControlEventArgs e)
        {
            mgDataViewer.Parent = e.TabPage;
        }

        private void SectionsControl_Selected(object sender, TabControlEventArgs e)
        {
            switch (SectionsControl.SelectedIndex)
            {
                case 1:
                    optionsGrid.Parent = mgSplitContainer_vertical.Panel2;
                    break;

                case 0:
                    optionsGrid.Parent = splitContainer_rightProps.Panel2;
                    break;
            }
        }

        private void OpenDictionaryList_Click(object sender, EventArgs e)
        {
            DictionaryForm.Show();
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

                    tempPropVal.Add(PropGrid.cntHeadsRows);
                    splitContainer_rightProps.Panel1Collapsed = false;
                    optionsGrid.Refresh();

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

        private void toolBtnConvertFile_ButtonClick(object sender, EventArgs e)
        {
            int BigCycle = 0;
            int SmallCycle = 0;
            int number;
            decimal ConsumptionValue;
            decimal GenerationValue;
            DataTable mgDictionaryTable = new DataTable();


            if (File.Exists(Environment.CurrentDirectory + "\\contractors_" + PropGrid.Region + ".xml"))
            {
                string xmlFileName = Environment.CurrentDirectory + "\\contractors_" + PropGrid.Region + ".xml";

                DataSet ExportsDats = new DataSet();
                ExportsDats.ReadXml(xmlFileName);

                mgDictionaryTable = ExportsDats.Tables[0];
                DataRow[] results = mgDictionaryTable.Select("Agreement like '%" + "MG003" + "%'");
                int residx = mgDictionaryTable.Rows.IndexOf(results[0]);
                Console.WriteLine(residx);
            }
            else
            {
                Console.WriteLine("Failed to upload counterparty data");
            }




            DataTable ConvertExcel = new DataTable();
            ConvertExcel.Clear();
            //ConvertExcel.Columns.Add("id");
            ConvertExcel.Columns.Add(new DataColumn("Agreement", typeof(string)));
            ConvertExcel.Columns.Add(new DataColumn("DateIntoForce", typeof(DateOnly)));
            ConvertExcel.Columns.Add(new DataColumn("Name", typeof(string)));
            ConvertExcel.Columns.Add(new DataColumn("Type", typeof(string)));
            ConvertExcel.Columns.Add(new DataColumn("inn", typeof(int)));
            ConvertExcel.Columns.Add(new DataColumn("ConsumptionSumm", typeof(decimal)));
            ConvertExcel.Columns.Add(new DataColumn("GenerationSumm", typeof(decimal)));
            ConvertExcel.Columns.Add(new DataColumn("Sell", typeof(decimal)));
            ConvertExcel.Columns.Add(new DataColumn("Buy", typeof(decimal)));
            ConvertExcel.Columns.Add(new DataColumn("Price", typeof(decimal)));
            ConvertExcel.Columns.Add(new DataColumn("Cost", typeof(decimal)));


            for (int i = 0; i < mgWorkDataViewer.RowCount; i++)
            {
                bool result = Int32.TryParse(mgWorkDataViewer.Rows[i].Cells[0].Value.ToString(), out number);
                if (mgWorkDataViewer.Rows[i].Cells[0].Value != DBNull.Value && result)
                {
                    BigCycle = i;

                    DataRow row = ConvertExcel.NewRow();
                    //row["id"] = number;
                    Console.WriteLine("AddToTableRowWithID: " + number);
                    row["Name"] = mgWorkDataViewer.Rows[i].Cells[2].Value.ToString().Split(',').First();

                    if (mgWorkDataViewer.Rows[i].Cells[7].Value.ToString() == "A+, к¬т*ч" && mgWorkDataViewer.Rows[i + 1].Cells[7].Value.ToString() == "A-, к¬т*ч")
                    {
                        decimal.TryParse(mgWorkDataViewer.Rows[i].Cells[11].Value.ToString(), out ConsumptionValue);
                        row["ConsumptionSumm"] = Math.Round(ConsumptionValue, 0);
                        Console.WriteLine("ConsumptionSumm: " + mgWorkDataViewer.Rows[i].Cells[11].Value.ToString());

                        decimal.TryParse(mgWorkDataViewer.Rows[i + 1].Cells[11].Value.ToString(), out GenerationValue);
                        row["GenerationSumm"] = Math.Round(GenerationValue, 0);
                        Console.WriteLine("GenerationSumm: " + mgWorkDataViewer.Rows[i + 1].Cells[11].Value.ToString() + "\n");
                    }
                    else
                    {
                        BigCycle++;
                        while (BigCycle < mgWorkDataViewer.Rows.Count && mgWorkDataViewer.Rows[BigCycle].Cells[0].Value == DBNull.Value)
                        {
                            if (BigCycle < mgWorkDataViewer.Rows.Count && mgWorkDataViewer.Rows[BigCycle].Cells[7].Value.ToString() == "A-, к¬т*ч")
                            {
                                decimal.TryParse(mgWorkDataViewer.Rows[BigCycle - 1].Cells[11].Value.ToString(), out ConsumptionValue);
                                row["ConsumptionSumm"] = Math.Round(ConsumptionValue, 0);
                                Console.WriteLine("ConsumptionSumm: " + mgWorkDataViewer.Rows[BigCycle - 1].Cells[11].Value.ToString());

                                SmallCycle = BigCycle + 1;

                                while (SmallCycle < mgWorkDataViewer.Rows.Count && mgWorkDataViewer.Rows[SmallCycle].Cells[7].Value == DBNull.Value)
                                {
                                    if (mgWorkDataViewer.Rows[SmallCycle].Cells[8].Value.ToString() == "—умма")
                                    {
                                        decimal.TryParse(mgWorkDataViewer.Rows[SmallCycle].Cells[11].Value.ToString(), out GenerationValue);
                                        row["GenerationSumm"] = Math.Round(GenerationValue, 0);
                                        Console.WriteLine("GenerationSumm: " + mgWorkDataViewer.Rows[SmallCycle].Cells[11].Value.ToString() + "\n");
                                        BigCycle = SmallCycle;
                                    }
                                    SmallCycle++;
                                }
                            }
                            BigCycle++;
                        }
                    }
                    ConvertExcel.Rows.Add(row);
                }
            }

            mgDataViewer.DataSource = null;
            DataTable DT = (DataTable)mgDataViewer.DataSource;
            if (DT != null)
                DT.Clear();

            mgDataViewer.Rows.Clear();
            mgDataViewer.Refresh();
            int count = this.mgDataViewer.Columns.Count;
            for (int i = 0; i < count; i++)
                this.mgDataViewer.Columns.RemoveAt(0);


            mgDataViewer.DataSource = ConvertExcel;

            mgDataViewer.Columns["Agreement"].Width = 120;
            mgDataViewer.Columns["DateIntoForce"].Width = 60;
            mgDataViewer.Columns["Name"].Width = 300;
            mgDataViewer.Columns["Type"].Width = 40;
            mgDataViewer.Columns["inn"].Width = 100;
            mgDataViewer.Columns["ConsumptionSumm"].Width = 50;
            mgDataViewer.Columns["GenerationSumm"].Width = 50;
            mgDataViewer.Columns["Sell"].Width = 50;
            mgDataViewer.Columns["Buy"].Width = 50;
            mgDataViewer.Columns["Price"].Width = 50;
            mgDataViewer.Columns["Cost"].Width = 100;

            this.Width = 1300;

            foreach (DataGridViewRow dr in mgDataViewer.Rows)
            {
                dr.HeaderCell.Value = (dr.Index + 1).ToString();
                try
                {
                    if (Convert.ToInt32(dr.Cells["GenerationSumm"].Value) > Convert.ToInt32(dr.Cells["ConsumptionSumm"].Value))
                    {
                        dr.Cells["Sell"].Value = 0;
                        dr.Cells["Buy"].Value = Convert.ToInt32(dr.Cells["GenerationSumm"].Value) - Convert.ToInt32(dr.Cells["ConsumptionSumm"].Value);
                    }
                    else
                    {
                        dr.Cells["Sell"].Value = Convert.ToInt32(dr.Cells["ConsumptionSumm"].Value) - Convert.ToInt32(dr.Cells["GenerationSumm"].Value);
                        dr.Cells["Buy"].Value = 0;
                    }
                }
                catch
                {

                }
            }

            foreach (DataGridViewColumn cl in mgDataViewer.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            mgDataViewer.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            mgDataViewer.Columns["Agreement"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void mgWorkDataViewer_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filePath in files)
                {
                    Console.WriteLine(filePath);
                }
            }
        }

        private void mgWorkDataViewer_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    
        private void StartPage()
        {
            foreach (TabPage page in SectionsControl.TabPages)
            {
                ImportList.AvailablePages.Add(page.Text.ToString());
            }
            PropGrid.StartPage = ImportList.AvailablePages[1];
            SectionsControl.SelectedTab = SectionsControl.TabPages["tab"+ PropGrid.StartPage];
            switch (SectionsControl.SelectedIndex)
            {
                case 1:
                    optionsGrid.Parent = mgSplitContainer_vertical.Panel2;
                    break;

                case 0:
                    optionsGrid.Parent = splitContainer_rightProps.Panel2;
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
                        BackUserMessanger.BackColor = Color.LightGreen;
                    }
                    catch
                    {
                        BackUserMessanger.BackColor = Color.IndianRed;
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

                if (PropGrid.DRow == true)
                {
                    for (int j = (Convert.ToInt32(HFR) - 1); j < ((Convert.ToInt32(HFR) - 1) + Convert.ToInt32(PropGrid.cntHeadsRows)); j++)
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
            optionsGrid.Refresh();
            TreeColViewer.ClearSelection();
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