using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace dataEditor
{


    class PropertySet
        {

        string appVersion = "0.821a";
        [CategoryAttribute("App"), ReadOnlyAttribute(true)]
        public string AppVersion
        {
            get { return appVersion; }
            set { appVersion = value; }
        }
        string appBuild = "1222";
        [CategoryAttribute("App"), ReadOnlyAttribute(true)]
        public string AppBuild
        {
            get { return appBuild; }
            set { appBuild = value; }
        }


        //string m_pressetName;
        //[Browsable(true)]
        //[ReadOnly(false)]
        //[Description("Type your name for new presset")]
        //[DisplayName("PressetName*")]
        //[Category("Extract Options")]
        //public string pressetName
        //{
        //    get { return m_pressetName; }
        //    set { m_pressetName = value; }
        //}

        bool m_DRow = true;
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

        int m_cntHeadsRows=2;
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

        bool m_useExtraCol=false;
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

        int m_ExtraColCnt;
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


        string m_sqlNames;
        [Browsable(true)]
        [ReadOnly(false)]
        [Description("All SQL names")]
        [DisplayName("SQLNamesList")]
        [Category("SQL")]
        public string sqlNames
        {
            get { return m_sqlNames; }
            set { m_sqlNames = value; }
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

        string m_AvailableXML;
        [Browsable(true)]
        [ReadOnly(false)]
        [Description("Available presset for Universal Reader")]
        [DisplayName("AvailableXML")]
        [Category("Other")]
        [TypeConverter(typeof(ListBox))]
        public string AvailablePresset
        {
            get { return m_AvailableXML; }
            set { m_AvailableXML = value; }
        }

        bool m_extdEdit;
        [Browsable(false)]
        [Description("Allow manual editing settings")]
        [DisplayName("UnlockSettings")]
        [Category("Other")]
        public bool AllowEdit
        {
            get { return m_extdEdit; }
            set { m_extdEdit = value; }
        }

        bool m_ForceCloseExl;
        [Browsable(true)]
        [Description("Terminate all Excel processes before closing the program.")]
        [DisplayName("ForceCloseAllExcel")]
        [Category("Other")]
        public bool ForceCloseExl
        {
            get { return m_ForceCloseExl; }
            set { m_ForceCloseExl = value; }
        }

    }
    public class ListBox : TypeConverter
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
}   
