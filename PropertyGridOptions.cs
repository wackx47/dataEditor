using dataEditor.Properties;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing.Design;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace dataEditor
{
    class PropertySet
        {
        string appVersion = "0.876a";
        [Browsable(true)]
        [CategoryAttribute("App"), ReadOnlyAttribute(true)]
        public string AppVersion
        {
            get { return appVersion; }
            set { appVersion = value; }
        }
        string appBuild = "2302";
        [Browsable(true)]
        [CategoryAttribute("App"), ReadOnlyAttribute(true)]
        public string AppBuild
        {
            get { return appBuild; }
            set { appBuild = value; }
        }

        private bool m_DRow = true;
            [Browsable(true)]
            [ReadOnly(true)]
            [Description("Headers takes over 2 rows in table")]
            [DisplayName("MultiRowHeaders")]
            [Category("Explore Mode")]
            public bool DRow
                {
                get { return m_DRow; }
                set { m_DRow = value; }
                }

        private int m_cntHeadsRows=2;
        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Count of rows takes header")]
        [DisplayName("CountHeadresRow")]
        [Category("Explore Mode")]
        public int cntHeadsRows
        {
            get { return m_cntHeadsRows; }
            set { m_cntHeadsRows = value; }
        }

        //int m_HeadFirstRow;
        //[Browsable(true)]
        //[ReadOnly(false)]
        //[Description("Rows which contains headers columns")]
        //[DisplayName("HeadresRow*")]
        //[Category("Extract Options")]
        //public int HeadFirstRow
       // {
       //     get { return m_HeadFirstRow; }
       //     set { m_HeadFirstRow = value; }
       // }

        private bool m_useExtraCol=false;
            [Browsable(true)]
            [ReadOnly(true)]
            [Description("Enable extra columns")]
            [DisplayName("UseExtraColumns")]
            [Category("Extra Columns")]
            public bool useExtraCol
                {
                 get { return m_useExtraCol; }
                 set { m_useExtraCol = value; }
                }

        private int m_ExtraColCnt;
            [Browsable(true)]
            [Description("Count extra columns")]
            [DisplayName("CountExtraColumns")]
            [Category("Extra Columns")]
            public int ExtraColCnt
            {
                 get { return m_ExtraColCnt; }
                 set { m_ExtraColCnt = value; }
            }



        //int m_FirstRowNum;
        //    [Browsable(true)]
        //    [ReadOnly(false)]
        //    [Description("First row contains data")]
        //    [DisplayName("FirstDataRow*")]
        //    [Category("Extract Options")]
        //    public int FirstRow
        //    {
        //        get { return m_FirstRowNum; }
        //        set { m_FirstRowNum = value; }
        //    }

        //int m_loop = 0;
        //[Browsable(true)]
        //[ReadOnly(false)]
        //[Description("The cycle of repeating filled lines")]
        //[DisplayName("Steps*")]
        //[Category("Extract Options")]
        //public int propLoop
        //{
        //    get { return m_loop; }
        //    set { m_loop = value; }
        //}

        //int m_ColumnsNum;
        //    [Browsable(true)]
        //    [ReadOnly(false)]
        //    [Description("Columns count in table")]
        //    [DisplayName("ColumnsCount*")]
        //    [Category("Extract Options")]
        //    public int ColumnsCounts
        //    {
        //        get { return m_ColumnsNum; }
        //        set { m_ColumnsNum = value; }
        //    }

        //string m_colChecks;
        //[Browsable(true)]
        //[ReadOnly(false)]
        //[Description("Select columns which using for checks files")]
        //[DisplayName("ColumnsChecks*")]
        //[Category("Extract Options")]
        //public string colChecks
        //{
        //    get { return m_colChecks; }
        //    set { m_colChecks = value; }
        //}


        //string m_TextExportColumns;
        //[Browsable(true)]
        //[ReadOnly(true)]
        //[Description("Returns columns which contains 'obj1'")]
        //[DisplayName("ExportColumns*")]
        //[Category("Extract Options")]
        //public string TextExportColumns
        //{
        //    get { return m_TextExportColumns; }
        //    set { m_TextExportColumns = value; }
        //}        

        //string m_sqlNames;
        //[Browsable(true)]
        //[ReadOnly(true)]
        //[Description("All SQL names")]
        //[DisplayName("SQLNamesList")]
        //[Category("SQL")]
        //public string sqlNames { get { return m_sqlNames; } set { m_sqlNames = value; } }

        private string m_atsReports;
        [Browsable(true)]
        [ReadOnly(false)]
        [Description("The most used reports from ATS")]
        [DisplayName("ReportsList")]
        [TypeConverter(typeof(ListBoxForReports))]
        [Category("Common")]
        public string atsReports
        {
            get { return m_atsReports; }
            set { m_atsReports = value; }
        }


        Color m_ColorHeads = Color.Gray;
        [Browsable(true)]
        [Description("Color for choosing rows contains Headers")]
        [DisplayName("ColorHeaders")]
        [Category("Visuals")]

        public Color ColorHeads
        {
            get { return m_ColorHeads; }
            set { m_ColorHeads = value; }
        }

        Color m_SecondColorHeads=Color.PaleGreen;
        [Browsable(true)]
        [Description("Color for next rows in Header")]
        [DisplayName("ColorHeaders(ListView)")]
        [Category("Visuals")]

        public Color SecondColorHeads
        {
            get { return m_SecondColorHeads; }
            set { m_SecondColorHeads = value; }
        }

        Color m_ColorDataRows = Color.Silver;
        [Browsable(true)]
        [Description("Color for rows contains data")]
        [DisplayName("ColorDataRows")]
        [Category("Visuals")]

        public Color ColorDataRows
        {
            get { return m_ColorDataRows; }
            set { m_ColorDataRows = value; }
        }

        Color m_ColorStaticDat = Color.Violet;
        [Browsable(true)]
        [Description("Color selected cells using for static values")]
        [DisplayName("ColorStaticCell")]
        [Category("Visuals")]

        public Color ColorStaticDat
        {
            get { return m_ColorStaticDat; }
            set { m_ColorStaticDat = value; }
        }

        private string m_ImportMode;
        [Browsable(true)]
        [ReadOnly(false)]
        [Description("Available import methods")]
        [DisplayName("ImportMode")]
        [Category("ImportSettings")]
        [TypeConverter(typeof(ImportMode))]
        public string ImportMode
        {
            get { return m_ImportMode; }
            set { m_ImportMode = value; }
        }

        public OleDBModeSets m_OleDBImportMode = new OleDBModeSets("", false, 1);
        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Alternative method imports using provider Microsoft Access for fill dataGrid and available only with installed and registered Microsoft.ACE.OLEDB.12.0")]
        [DisplayName("OLEDBprovider")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Category("ImportSettings")]
        public OleDBModeSets OleDBImportMode
        {
            get { return m_OleDBImportMode; }
            set { m_OleDBImportMode = value; }
        }

        private bool m_extdEdit;
        [Browsable(false)]
        [Description("Allow manual editing settings")]
        [DisplayName("UnlockSettings")]
        [Category("Other")]
        public bool AllowEdit
        {
            get { return m_extdEdit; }
            set { m_extdEdit = value; }
        }

        private bool m_ForceCloseExl;
        [Browsable(true)]
        [Description("Terminate all Excel processes before closing the program")]
        [DisplayName("ForceCloseAllExcel")]
        [Category("Other")]
        public bool ForceCloseExl
        {
            get { return m_ForceCloseExl; }
            set { m_ForceCloseExl = value; }
        }

        private bool m_ShowConsoleOnStartUp = false;
        [Browsable(true)]
        [ReadOnly(false)]
        [Description("Open console whith starts programm")]
        [DisplayName("ShowConsoleOnStartUp")]
        [Category("Other")]
        public bool ShowConsoleOnStartUp
        {
            get { return m_ShowConsoleOnStartUp; }
            set { m_ShowConsoleOnStartUp = value; }
        }

        private bool m_ShowHelpPropetryGrid = false;
        [Browsable(false)]
        [ReadOnly(false)]
        [Description("Show help area in property grid")]
        [DisplayName("ShowHelpPropetryGrid")]
        [Category("Other")]
        public bool ShowHelpPropetryGrid
        {
            get { return m_ShowHelpPropetryGrid; }
            set { m_ShowHelpPropetryGrid = value; }
        }


        string[] m_sqlArray = {};
        [Browsable(true)]
        [ReadOnly(false)]
        [Description("Used SQL collumns")]
        [DisplayName("SQLcollumns")]
        [Category("SQL")]
        [TypeConverter(typeof(CollectionTypeConverter))]
        public string[] sqlArray { get { return m_sqlArray; } set { m_sqlArray = value; } }


        private string m_AvailableXML;
        [Browsable(true)]
        [ReadOnly(false)]
        [Description("Available presset for Universal Reader")]
        [DisplayName("AvailableXML")]
        [Category("Other")]
        [TypeConverter(typeof(ListBoxForXml))]
        public string AvailablePresset
        {
            get { return m_AvailableXML; }
            set { m_AvailableXML = value; }
        }
    }

    class OleDBModeSets
    {
        public OleDBModeSets(string Version, bool HDR, uint IMEX)
        {
            _verOleDB = Version;
            _HDR = HDR;
            _IMEX = IMEX;
        }

        private string _verOleDB;
        [Browsable(true)]
        [ReadOnly(false)]
        [Description("The Microsoft OLE DB Provider for SQL Server, SQLOLEDB, allows ADO to access Microsoft SQL Server.")]
        [DisplayName("Provider")]
        [TypeConverter(typeof(ProvidersList))]
        public string VersionOleDB
        {
            get { return _verOleDB; }
            set { _verOleDB = value; }
        }

        private string[] ver { get { return VersionOleDB.Split('.'); } }

        private bool _HDR;
        [Browsable(true)]
        [DisplayName("HDR")]
        [Description("Indicates that the first row contains columnnames, not data")]
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool HDR
        {
            get { return _HDR; }
            set { _HDR = value; }
        }

        [Browsable(false)]
        public string strHDR { get { return _HDR ? "Yes" : "No"; } }
            

        private uint _IMEX;
        [Browsable(true)]
        [DisplayName("IMEX")]
        [Description("Tells the driver to always read “intermixed” (numbers, dates, strings etc) data columns as text")]
        public uint IMEX
        {
            get { return _IMEX; }
            set { _IMEX = value; }
        }

        public override string ToString()
        {
            if (VersionOleDB != "")
                return ver[3] + "." + ver[4] + " (HDR=" + strHDR + "; IMEX=" + IMEX + ")";
            else
                return "Method not available";
        }
    }

    class BooleanTypeConverter : BooleanConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
        {
            return (bool)value ?
              "Yes" : "No";
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return (string)value == "Yes";
        }
    }


    class CollectionTypeConverter : TypeConverter
    {
        
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            return destType == typeof(string);
        }
            
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
        {
            return "(...)";
        }
    }


    public class ListBoxForXml : TypeConverter
        {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            string path = Environment.CurrentDirectory + "\\";
            var dir = new DirectoryInfo(path);
            List<string> files = new List<string>();
            foreach (FileInfo file in dir.GetFiles("*.xml"))
            {
                files.Add(Path.GetFileName(file.FullName));
            }

            return new StandardValuesCollection(files);
            return base.GetStandardValues(context);
        }
    }

    public class ListBoxForReports : TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            string[] reports = { "buy_norem", "cfrliab", "cfrliabdpg", "CESSM", "CFR_PART_LIAB_DEL_NOTICE", "svnc_part_s_plan", "PROGN_LIAB_FRSFG", "power_consumer_3_fact", "frs_dev_factcost" };

            return new StandardValuesCollection(reports);
            return base.GetStandardValues(context);
        }
    }

    class ImportMode : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(ImportList.AvailableMode);
        }
    }

    class ProvidersList : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(ImportList.ProvidersList);
        }
    }
}   
