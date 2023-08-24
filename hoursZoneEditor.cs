using NPOI.SS.Formula.Functions;
using OfficeOpenXml.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace dataEditor
{
    public partial class hoursZoneEditor : Form
    {
        MainForm main = (MainForm)Application.OpenForms["MainForm"];

        public hoursZoneEditor()
        {
            InitializeComponent();
        }


        public int[,] _2dayZone_00 = new int[0, 6];
        public int[,] _2nightZone_00 = new int[0, 6];

        public int[,] _3peakZone_00 = new int[0, 6];
        public int[,] _3semiPeakZone_00 = new int[0, 6];
        public int[,] _3nightZone_00 = new int[0, 6];

        public int[,] _2dayZone_01 = new int[0, 6];
        public int[,] _2nightZone_01 = new int[0, 6];

        public int[,] _3peakZone_01 = new int[0, 6];
        public int[,] _3semiPeakZone_01 = new int[0, 6];
        public int[,] _3nightZone_01 = new int[0, 6];

        private void hoursZoneEditor_Load(object sender, EventArgs e)
        {
            fillTable();
            cmbxSelectGlobalZone.SelectedIndex = 0;
            cmbxSelectTypeZone.Items.AddRange(new[] { "день", "ночь" });
            cmbxSelectTypeZone.SelectedIndex = 0;
            doubleZoneTreeView.ExpandAll();

            typeList.Text = typeList.Items[0].ToString();

            loadXMLfiles();
        }

        private void loadXMLfiles()
        {
            main = StartScreen.universalReaderForm;
            string currentGTP = main.currentGTP;
            string currentFolder = main.currentProjectFolder + "\\data\\common\\TimesZones\\";

            string doubleName = "doubleZone_" + currentGTP;
            string trippleName = "trippleZone_" + currentGTP;

            if (File.Exists(currentFolder + doubleName + "_00.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(currentFolder + doubleName + "_00.xml");
                parsingXMl(doubleZoneTreeView, xmlDoc);
                parsingTreeViewDoubleZoneForPaint(ref _2dayZone_00, ref _2nightZone_00);
            }

            if (File.Exists(currentFolder + trippleName + "_00.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(currentFolder + trippleName + "_00.xml");
                parsingXMl(trippleZoneTreeView, xmlDoc);
                parsingTreeViewTrippleZoneForPaint(ref _3peakZone_00, ref _3semiPeakZone_00, ref _3nightZone_00);
            }

            if (File.Exists(currentFolder + doubleName + "_01.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(currentFolder + doubleName + "_01.xml");
                parsingXMl(doubleZoneTreeView, xmlDoc);
                parsingTreeViewDoubleZoneForPaint(ref _2dayZone_01, ref _2nightZone_01);
            }

            if (File.Exists(currentFolder + trippleName + "_01.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(currentFolder + trippleName + "_01.xml");
                parsingXMl(trippleZoneTreeView, xmlDoc);
                parsingTreeViewTrippleZoneForPaint(ref _3peakZone_01, ref _3semiPeakZone_01, ref _3nightZone_01);
            }
        }

        private void parsingXMl(System.Windows.Forms.TreeView treeViewControl,  XmlDocument xmlDoc)
        {
            try
            {
                treeViewControl.Nodes.Clear();
                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    if (node.Name == "namespace" && node.ChildNodes.Count == 0 && string.IsNullOrEmpty(GetAttributeText(node, "name")))
                        continue;
                        

                    AddNode(treeViewControl.Nodes, node);
                }
                treeViewControl.ExpandAll();
                treeViewControl.ItemHeight = 15;
            }
            catch (Exception ex)
            {

            }
        }


        static string GetAttributeText(XmlNode inXmlNode, string name)
        {
            XmlAttribute attr = (inXmlNode.Attributes == null ? null : inXmlNode.Attributes[name]);
            return attr == null ? null : attr.Value;
        }

        private void AddNode(TreeNodeCollection nodes, XmlNode inXmlNode)
        {
            if (inXmlNode.HasChildNodes)
            {
                string name = GetAttributeText(inXmlNode, "name");
                string text = inXmlNode.Attributes["Text"].Value;

                if (string.IsNullOrEmpty(name))
                    name = inXmlNode.Name;

                TreeNode newNode = nodes.Add(name);
                XmlNodeList nodeList = inXmlNode.ChildNodes;

                newNode.Name = name;
                newNode.Text = text;

                for (int i = 0; i <= nodeList.Count - 1; i++)
                {
                    XmlNode xNode = inXmlNode.ChildNodes[i];
                    if (xNode.NodeType is XmlNodeType.Element)
                    {
                        newNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                    }    
                        
                    else
                        newNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    AddNode(newNode.Nodes, xNode);
                    
                }
            }
            else
            {
                string text = GetAttributeText(inXmlNode, "name");
                if (string.IsNullOrEmpty(text))
                    text = (inXmlNode.OuterXml).Trim();
                TreeNode newNode = nodes.Add(text);
                newNode.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            }
        }
        private void parsingTreeViewTrippleZoneForPaint(ref int[,] _3peakZone, ref int[,] _3semiPeakZone, ref int[,] _3nightZone)
        {
            foreach (TreeNode mainNode in trippleZoneTreeView.Nodes)
            {
                switch (mainNode.Name)
                {
                    case "peak":
                        if (mainNode.FirstNode.Name == "initial")
                        {
                            _3peakZone = ResizeArray(_3peakZone, mainNode.GetNodeCount(false) / 2, 6);
                        }
                        else
                        {
                            _3peakZone = ResizeArray(_3peakZone, mainNode.GetNodeCount(false), 6);
                        }

                        for (int i = 0; i < _3peakZone.GetLength(0); i++)
                        {
                            int initialIndex = 0;
                            int finalIndex = 0;

                            TreeNode nodeLevelOne = mainNode.Nodes[i];

                            initialIndex = Convert.ToInt32(nodeLevelOne.Nodes[0].LastNode.Text);
                            finalIndex = Convert.ToInt32(nodeLevelOne.Nodes[1].LastNode.Text);

                            _3peakZone[i, 0] = 1;
                            _3peakZone[i, 1] = hoursDataGrid.GetRowDisplayRectangle(initialIndex, false).Y;
                            _3peakZone[i, 2] = hoursDataGrid.GetRowDisplayRectangle(initialIndex, false).Width - 1;
                            _3peakZone[i, 3] = hoursDataGrid.Rows[initialIndex].Height * (finalIndex - initialIndex);
                            _3peakZone[i, 4] = initialIndex;
                            _3peakZone[i, 5] = finalIndex - 1;
                        }
                        break;

                    case "semiPeak":
                        if (mainNode.FirstNode.Name == "initial")
                        {
                            _3semiPeakZone = ResizeArray(_3semiPeakZone, mainNode.GetNodeCount(false) / 2, 6);
                        }
                        else
                        {
                            _3semiPeakZone = ResizeArray(_3semiPeakZone, mainNode.GetNodeCount(false), 6);
                        }

                        for (int i = 0; i < _3semiPeakZone.GetLength(0); i++)
                        {
                            int initialIndex = 0;
                            int finalIndex = 0;

                            TreeNode nodeLevelOne = mainNode.Nodes[i];

                            initialIndex = Convert.ToInt32(nodeLevelOne.Nodes[0].LastNode.Text);
                            finalIndex = Convert.ToInt32(nodeLevelOne.Nodes[1].LastNode.Text);

                            _3semiPeakZone[i, 0] = 1;
                            _3semiPeakZone[i, 1] = hoursDataGrid.GetRowDisplayRectangle(initialIndex, false).Y;
                            _3semiPeakZone[i, 2] = hoursDataGrid.GetRowDisplayRectangle(initialIndex, false).Width - 1;
                            _3semiPeakZone[i, 3] = hoursDataGrid.Rows[initialIndex].Height * (finalIndex - initialIndex);
                            _3semiPeakZone[i, 4] = initialIndex;
                            _3semiPeakZone[i, 5] = finalIndex - 1;
                        }
                        break;

                    case "night":
                        if (mainNode.FirstNode.Name == "initial")
                        {
                            _3nightZone = ResizeArray(_3nightZone, mainNode.GetNodeCount(false) / 2 + 1, 6);
                        }
                        else
                        {
                            _3nightZone = ResizeArray(_3nightZone, mainNode.GetNodeCount(false) + 1, 6);
                        }

                        int initialIndexNight = 0;
                        int finalIndexNight = 0;

                        foreach (TreeNode nodeLevelOne in mainNode.Nodes)
                        {
                            switch (nodeLevelOne.Name)
                            {
                                case "initial":
                                    initialIndexNight = Convert.ToInt32(nodeLevelOne.LastNode.Text);
                                    break;

                                case "final":
                                    finalIndexNight = Convert.ToInt32(nodeLevelOne.LastNode.Text);
                                    break;
                            }
                        }

                        _3nightZone[0, 0] = 1;
                        _3nightZone[0, 1] = hoursDataGrid.GetRowDisplayRectangle(initialIndexNight, false).Y;
                        _3nightZone[0, 2] = hoursDataGrid.GetRowDisplayRectangle(initialIndexNight, false).Width - 1;
                        _3nightZone[0, 3] = hoursDataGrid.Rows[initialIndexNight].Height * (24 - initialIndexNight);
                        _3nightZone[0, 4] = initialIndexNight;
                        _3nightZone[0, 5] = 23;

                        _3nightZone[1, 0] = 1;
                        _3nightZone[1, 1] = hoursDataGrid.GetRowDisplayRectangle(0, false).Y;
                        _3nightZone[1, 2] = hoursDataGrid.GetRowDisplayRectangle(0, false).Width - 1;
                        _3nightZone[1, 3] = hoursDataGrid.Rows[0].Height * (finalIndexNight - 0);
                        _3nightZone[1, 4] = 0;
                        _3nightZone[1, 5] = finalIndexNight;
                        break;

                }
            }

            _chg3peakZone = _3peakZone;
            _chg3semiPeakZone = _3semiPeakZone;
            _chg3nightZone = _3nightZone;
        }


        private void parsingTreeViewDoubleZoneForPaint(ref int[,] _2dayZone, ref int[,] _2nightZone)
        {
            foreach (TreeNode mainNode in doubleZoneTreeView.Nodes)
            {
                switch(mainNode.Name)
                {
                    case "day":
                        if(mainNode.FirstNode.Name == "initial")
                        {
                            _2dayZone = ResizeArray(_2dayZone, mainNode.GetNodeCount(false) / 2, 6);
                        }
                        else
                        {
                            _2dayZone = ResizeArray(_2dayZone, mainNode.GetNodeCount(false), 6);
                        }

                        for (int i = 0; i < _2dayZone.GetLength(0); i++)
                        {
                            int initialIndex = 0;
                            int finalIndex = 0;

                            TreeNode nodeLevelOne = mainNode;

                            initialIndex = Convert.ToInt32(nodeLevelOne.Nodes[0].LastNode.Text);
                            finalIndex = Convert.ToInt32(nodeLevelOne.Nodes[1].LastNode.Text);

                            _2dayZone[i, 0] = 1;
                            _2dayZone[i, 1] = hoursDataGrid.GetRowDisplayRectangle(initialIndex, false).Y;
                            _2dayZone[i, 2] = hoursDataGrid.GetRowDisplayRectangle(initialIndex, false).Width - 1;
                            _2dayZone[i, 3] = hoursDataGrid.Rows[initialIndex].Height * (finalIndex - initialIndex);
                            _2dayZone[i, 4] = initialIndex;
                            _2dayZone[i, 5] = finalIndex - 1;
                        }
                        break;

                    case "night":
                        if (mainNode.FirstNode.Name == "initial")
                        {
                            _2nightZone = ResizeArray(_2nightZone, mainNode.GetNodeCount(false) / 2+1, 6);
                        }
                        else
                        {
                            _2nightZone = ResizeArray(_2nightZone, mainNode.GetNodeCount(false)+1, 6);
                        }

                        int initialIndexNight = 0;
                        int finalIndexNight = 0;

                        foreach (TreeNode nodeLevelOne in mainNode.Nodes)
                        {
                            switch (nodeLevelOne.Name)
                            {
                                case "initial":
                                    initialIndexNight = Convert.ToInt32(nodeLevelOne.LastNode.Text);
                                    break;

                                case "final":
                                    finalIndexNight = Convert.ToInt32(nodeLevelOne.LastNode.Text);
                                    break;
                            }
                        }

                        _2nightZone[0, 0] = 1;
                        _2nightZone[0, 1] = hoursDataGrid.GetRowDisplayRectangle(initialIndexNight, false).Y;
                        _2nightZone[0, 2] = hoursDataGrid.GetRowDisplayRectangle(initialIndexNight, false).Width-1;
                        _2nightZone[0, 3] = hoursDataGrid.Rows[initialIndexNight].Height * (24 - initialIndexNight);
                        _2nightZone[0, 4] = initialIndexNight;
                        _2nightZone[0, 5] = 23;

                        _2nightZone[1, 0] = 1;
                        _2nightZone[1, 1] = hoursDataGrid.GetRowDisplayRectangle(0, false).Y;
                        _2nightZone[1, 2] = hoursDataGrid.GetRowDisplayRectangle(0, false).Width-1;
                        _2nightZone[1, 3] = hoursDataGrid.Rows[0].Height * (finalIndexNight - 0);
                        _2nightZone[1, 4] = 0;
                        _2nightZone[1, 5] = finalIndexNight;
                        break;
                }
            }
            _chg2dayZone = _2dayZone;
            _chg2nightZone = _2nightZone;
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
            TreeNode parentNode = trippleZoneTreeView.SelectedNode ?? trippleZoneTreeView.Nodes[0];

            int nodeCount = 1;
            foreach (var node in trippleZoneTreeView.SelectedNode.Nodes)
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
                        initialChildNode.Name = "initial";
                        initialChildNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        TreeNode initialValueNode = initialChildNode.Nodes.Add("0");
                        initialValueNode.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        TreeNode finalChildNode = parentNode.Nodes.Add("до");
                        finalChildNode.Name = "final";
                        finalChildNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        TreeNode finalValueNode = finalChildNode.Nodes.Add("0");
                        finalValueNode.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    }
                    break;
                default:
                    if (parentNode != null && parentNode.Text == "пик" || parentNode.Text == "полупик")
                    {
                        TreeNode newZoneNode = parentNode.Nodes.Add(childNode);
                        newZoneNode.Name = "zone_" + nodeCount;
                        newZoneNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        TreeNode initialChildNode = newZoneNode.Nodes.Add("с");
                        initialChildNode.Name = "initial";
                        initialChildNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        TreeNode initialValueNode = initialChildNode.Nodes.Add("0");
                        initialValueNode.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        TreeNode finalChildNode = newZoneNode.Nodes.Add("до");
                        finalChildNode.Name = "final";
                        finalChildNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        TreeNode finalValueNode = finalChildNode.Nodes.Add("0");
                        finalValueNode.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    }
                    break;
            }
            trippleZoneTreeView.ExpandAll();
        }

        private void saveData(int typePerson, int typeZone)
        {
            main = StartScreen.universalReaderForm;
            string currentGTP = main.currentGTP;
            string currentFolder = main.currentProjectFolder+"\\data\\common\\TimesZones\\";

            string doubleName = "doubleZone_" + currentGTP + "_0" + typePerson;
            string trippleName = "trippleZone_" + currentGTP + "_0" + typePerson;

            try
            {
                if (!Directory.Exists(currentFolder))
                {
                    Directory.CreateDirectory(currentFolder);
                }

                var document = new XDocument();

                switch (typeZone)
                {
                    case 0:
                        document = new XDocument(new XElement(doubleName, CreateXmlElement(doubleZoneTreeView.Nodes)));
                        document.Save(currentFolder + doubleName + ".xml");
                        break;

                    case 1:
                        document = new XDocument(new XElement(trippleName, CreateXmlElement(trippleZoneTreeView.Nodes)));
                        document.Save(currentFolder + trippleName + ".xml");
                        break;

                    case 2:
                        document = new XDocument(new XElement(doubleName, CreateXmlElement(doubleZoneTreeView.Nodes)));
                        document.Save(currentFolder + doubleName + ".xml");

                        document = new XDocument(new XElement(trippleName, CreateXmlElement(trippleZoneTreeView.Nodes)));
                        document.Save(currentFolder + trippleName + ".xml");
                        break;

                    default:
                        document = new XDocument(new XElement(doubleName, CreateXmlElement(doubleZoneTreeView.Nodes)));
                        document.Save(currentFolder + doubleName + ".xml");

                        document = new XDocument(new XElement(trippleName, CreateXmlElement(trippleZoneTreeView.Nodes)));
                        document.Save(currentFolder + trippleName + ".xml");
                        break; 
                }

            }
            catch
            {

            }
        }

        private static List<XElement> CreateXmlElement(TreeNodeCollection treeViewNodes)
        {
            var elements = new List<XElement>();
            foreach (TreeNode treeViewNode in treeViewNodes)
            {
                var element = new XElement(treeViewNode.Name);
                element.SetAttributeValue("Text", treeViewNode.Text);
                if (treeViewNode.GetNodeCount(true) == 1)
                {
                    element.Value = treeViewNode.Nodes[0].Text;
                } 
                else
                    element.Add(CreateXmlElement(treeViewNode.Nodes));
                elements.Add(element);
            }
            return elements;
        }

        private void doubleZoneTreeView_Enter(object sender, EventArgs e)
        {
            cmbxSelectGlobalZone.SelectedIndex = 0;
            cmbxSelectTypeZone.Items.Clear();
            cmbxSelectTypeZone.Items.AddRange(new[] { "день", "ночь" });

            selectDoubleTreeNode();

            foreach (DataGridViewRow rows in hoursDataGrid.Rows)
            {
                rows.DefaultCellStyle.BackColor = Color.Empty;
                doubleZoneBackColor();
            }
            hoursDataGrid.Refresh();
            hoursDataGrid.ClearSelection();

            groupDoubleZone.ForeColor = Color.Black;
            groupTrippleZone.ForeColor = Color.Gray;
        }

        private void TrippleZoneTreeView_Enter(object sender, EventArgs e)
        {
            cmbxSelectGlobalZone.SelectedIndex = 1;
            cmbxSelectTypeZone.Items.Clear();
            cmbxSelectTypeZone.Items.AddRange(new[] { "пик", "полупик", "ночь" });

            selectTrippleTreeNode();

            foreach (DataGridViewRow rows in hoursDataGrid.Rows)
            {
                rows.DefaultCellStyle.BackColor = Color.Empty;
                trippleZoneBackColor();
            }
            hoursDataGrid.Refresh();
            hoursDataGrid.ClearSelection();

            groupDoubleZone.ForeColor = Color.Gray;
            groupTrippleZone.ForeColor = Color.Black;
        }

        private void doubleZoneTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectDoubleTreeNode();
        }

        private void TrippleZoneTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectTrippleTreeNode();
        }

        public int[,] _chg2dayZone = new int[0, 6];
        public int[,] _chg2nightZone = new int[0, 6];

        public int[,] _chg3peakZone = new int[0, 6];
        public int[,] _chg3semiPeakZone = new int[0, 6];
        public int[,] _chg3nightZone = new int[0, 6];

        private void btnApplyHours_Click(object sender, EventArgs e)
        {

            switch (cmbxSelectGlobalZone.Text)
            {
                case "2 зоны":
                    if(cmbxSelectTypeZone.Text == "день")
                    {
                        _chg2dayZone = SelectedRows(_chg2dayZone, false);
                        try
                        {
                            doubleZoneTreeView.Nodes[0].Nodes[0].Nodes[0].Text = _chg2dayZone[0, 4].ToString();
                            doubleZoneTreeView.Nodes[0].Nodes[1].Nodes[0].Text = (_chg2dayZone[0, 5] + 1).ToString();
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    else if (cmbxSelectTypeZone.Text == "ночь")
                    {
                        _chg2nightZone = SelectedRows(_chg2nightZone, true);
                        try
                        {
                            TreeNode parentNode = doubleZoneTreeView.Nodes[1];
                            parentNode.Nodes.Clear();

                            if (_chg2nightZone.GetLength(0) == 2)
                            {
                                TreeNode initialChildNode = parentNode.Nodes.Add("с");
                                initialChildNode.Name = "initial";
                                initialChildNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                TreeNode initialValueNode = initialChildNode.Nodes.Add(_chg2nightZone[1, 4].ToString());
                                initialValueNode.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                TreeNode finalChildNode = parentNode.Nodes.Add("до");
                                finalChildNode.Name = "final";
                                finalChildNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                TreeNode finalValueNode = finalChildNode.Nodes.Add((_chg2nightZone[0, 5] + 1).ToString());
                                finalValueNode.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                            }
                            else if (_chg2nightZone.GetLength(0) == 1)
                            {
                                TreeNode initialChildNode = parentNode.Nodes.Add("с");
                                initialChildNode.Name = "initial";
                                initialChildNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                TreeNode initialValueNode = initialChildNode.Nodes.Add(_chg2nightZone[0, 4].ToString());
                                initialValueNode.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                TreeNode finalChildNode = parentNode.Nodes.Add("до");
                                finalChildNode.Name = "final";
                                finalChildNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                TreeNode finalValueNode = finalChildNode.Nodes.Add((_chg2nightZone[0, 5] + 1).ToString());
                                finalValueNode.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                            }

                            doubleZoneTreeView.ExpandAll();

                            //doubleZoneTreeView.Nodes[1].Nodes[0].Nodes[0].Text = _chg2nightZone[1, 4].ToString();
                            //doubleZoneTreeView.Nodes[1].Nodes[1].Nodes[0].Text = (_chg2nightZone[0, 5] + 1).ToString();
                        }
                        catch (Exception ex)
                        {
                            TreeNode parentNode = doubleZoneTreeView.Nodes[1];
                            parentNode.Nodes.Clear();
                        }
                    }

                    foreach (DataGridViewRow rows in hoursDataGrid.Rows)
                    {
                        rows.DefaultCellStyle.BackColor = Color.Empty;
                    }
                    doubleZoneBackColor();
                    hoursDataGrid.Refresh();
                    hoursDataGrid.ClearSelection();
                    break;
                case "3 зоны":
                    if (cmbxSelectTypeZone.Text == "пик")
                    {
                        _chg3peakZone = SelectedRows(_chg3peakZone, true);
                        try
                        {
                            if (_chg3peakZone.GetLength(0) == trippleZoneTreeView.Nodes[0].Nodes.Count)
                            {
                                for (int i = 0; i < _chg3peakZone.GetLength(0); i++)
                                {
                                    trippleZoneTreeView.Nodes[0].Nodes[i].Nodes[0].Nodes[0].Text = _chg3peakZone[i, 4].ToString();
                                    trippleZoneTreeView.Nodes[0].Nodes[i].Nodes[1].Nodes[0].Text = (_chg3peakZone[i, 5] + 1).ToString();
                                }
                            }
                            else
                            {

                                TreeNode parentNode = trippleZoneTreeView.Nodes[0];

                                parentNode.Nodes.Clear();

                                for (int i = 0; i < _chg3peakZone.GetLength(0); i++)
                                {
                                    var childNode = (i+1) + " период";
                                    TreeNode newZoneNode = parentNode.Nodes.Add(childNode);
                                    newZoneNode.Name = "zone_" + (i+1);
                                    newZoneNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                    TreeNode initialChildNode = newZoneNode.Nodes.Add("с");
                                    initialChildNode.Name = "initial";
                                    initialChildNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                    TreeNode initialValueNode = initialChildNode.Nodes.Add(_chg3peakZone[i, 4].ToString());
                                    initialValueNode.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                    TreeNode finalChildNode = newZoneNode.Nodes.Add("до");
                                    finalChildNode.Name = "final";
                                    finalChildNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                    TreeNode finalValueNode = finalChildNode.Nodes.Add((_chg3peakZone[i, 5] + 1).ToString());
                                    finalValueNode.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                }
                                trippleZoneTreeView.ExpandAll();
                            }

                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else if (cmbxSelectTypeZone.Text == "полупик")
                    {
                        _chg3semiPeakZone = SelectedRows(_chg3semiPeakZone, true);
                        try
                        {
                            if (_chg3semiPeakZone.GetLength(0) == trippleZoneTreeView.Nodes[1].Nodes.Count)
                            {
                                for (int i = 0; i < _chg3semiPeakZone.GetLength(0); i++)
                                {
                                    trippleZoneTreeView.Nodes[1].Nodes[i].Nodes[0].Nodes[0].Text = _chg3semiPeakZone[i, 4].ToString();
                                    trippleZoneTreeView.Nodes[1].Nodes[i].Nodes[1].Nodes[0].Text = (_chg3semiPeakZone[i, 5] + 1).ToString();
                                }
                            }
                            else
                            {
                                TreeNode parentNode = trippleZoneTreeView.Nodes[1];

                                parentNode.Nodes.Clear();

                                for (int i = 0; i < _chg3semiPeakZone.GetLength(0); i++)
                                {
                                    var childNode = (i + 1) + " период";
                                    TreeNode newZoneNode = parentNode.Nodes.Add(childNode);
                                    newZoneNode.Name = "zone_" + (i + 1);
                                    newZoneNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                    TreeNode initialChildNode = newZoneNode.Nodes.Add("с");
                                    initialChildNode.Name = "initial";
                                    initialChildNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                    TreeNode initialValueNode = initialChildNode.Nodes.Add(_chg3semiPeakZone[i, 4].ToString());
                                    initialValueNode.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                    TreeNode finalChildNode = newZoneNode.Nodes.Add("до");
                                    finalChildNode.Name = "final";
                                    finalChildNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                    TreeNode finalValueNode = finalChildNode.Nodes.Add((_chg3semiPeakZone[i, 5] + 1).ToString());
                                    finalValueNode.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                }
                                trippleZoneTreeView.ExpandAll();
                            }

                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else
                    {
                        _chg3nightZone = SelectedRows(_chg3nightZone, true);
                        try
                        {
                            TreeNode parentNode = trippleZoneTreeView.Nodes[2];
                            parentNode.Nodes.Clear();

                            if (_chg3nightZone.GetLength(0) == 2)
                            {
                                TreeNode initialChildNode = parentNode.Nodes.Add("с");
                                initialChildNode.Name = "initial";
                                initialChildNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                TreeNode initialValueNode = initialChildNode.Nodes.Add(_chg3nightZone[1, 4].ToString());
                                initialValueNode.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                TreeNode finalChildNode = parentNode.Nodes.Add("до");
                                finalChildNode.Name = "final";
                                finalChildNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                TreeNode finalValueNode = finalChildNode.Nodes.Add((_chg3nightZone[0, 5] + 1).ToString());
                                finalValueNode.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                            }
                            else if (_chg3nightZone.GetLength(0) == 1)
                            {
                                TreeNode initialChildNode = parentNode.Nodes.Add("с");
                                initialChildNode.Name = "initial";
                                initialChildNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                TreeNode initialValueNode = initialChildNode.Nodes.Add(_chg3nightZone[0, 4].ToString());
                                initialValueNode.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                TreeNode finalChildNode = parentNode.Nodes.Add("до");
                                finalChildNode.Name = "final";
                                finalChildNode.NodeFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                                TreeNode finalValueNode = finalChildNode.Nodes.Add((_chg3nightZone[0, 5] + 1).ToString());
                                finalValueNode.NodeFont = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                            }
                            
                            trippleZoneTreeView.ExpandAll();
                            //trippleZoneTreeView.Nodes[2].Nodes[0].Nodes[0].Text = _chg3nightZone[1, 4].ToString();
                            //trippleZoneTreeView.Nodes[2].Nodes[1].Nodes[0].Text = (_chg3nightZone[0, 5] + 1).ToString();
                        }
                        catch (Exception ex)
                        {
                            TreeNode parentNode = trippleZoneTreeView.Nodes[2];
                            parentNode.Nodes.Clear();
                        }
                    }

                    foreach (DataGridViewRow rows in hoursDataGrid.Rows)
                    {
                        rows.DefaultCellStyle.BackColor = Color.Empty;
                    }
                    trippleZoneBackColor();
                    hoursDataGrid.Refresh();
                    hoursDataGrid.ClearSelection();
                    break;
            }


            switch (typeList.SelectedIndex)
            {
                case 0:
                    _2dayZone_00 = _chg2dayZone;
                    _2nightZone_00 = _chg2nightZone;

                    _3peakZone_00 = _chg3peakZone;
                    _3semiPeakZone_00 = _chg3semiPeakZone;
                    _3nightZone_00 = _chg3nightZone;
                    break;

                case 1:
                    _2dayZone_01 = _chg2dayZone;
                    _2nightZone_01 = _chg2nightZone;

                    _3peakZone_01 = _chg3peakZone;
                    _3semiPeakZone_01 = _chg3semiPeakZone;
                    _3nightZone_01 = _chg3nightZone;
                    break;
            }
        }

        private void doubleZoneBackColor()
        {
            if (_chg2dayZone.GetLength(0) > 0)
            {
                for (int i = 0; i < _chg2dayZone.GetLength(0); i++)
                {
                    for (int j = _chg2dayZone[i, 4]; j <= _chg2dayZone[i, 5]; j++)
                    {
                        if (hoursDataGrid.Rows[j].DefaultCellStyle.BackColor == Color.Empty)
                            hoursDataGrid.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 200, 200);
                    }
                }
            }

            if (_chg2nightZone.GetLength(0) > 0)
            {
                for (int i = 0; i < _chg2nightZone.GetLength(0); i++)
                {
                    for (int j = _chg2nightZone[i, 4]; j <= _chg2nightZone[i, 5]; j++)
                    {
                        if(hoursDataGrid.Rows[j].DefaultCellStyle.BackColor == Color.Empty)
                        {
                            hoursDataGrid.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200, 250);
                        }
                    }
                }
            }
        }

        private void trippleZoneBackColor()
        {
            if (_chg3peakZone.GetLength(0) > 0)
            {
                for (int i = 0; i < _chg3peakZone.GetLength(0); i++)
                {
                    for (int j = _chg3peakZone[i, 4]; j <= _chg3peakZone[i, 5]; j++)
                    {
                        if (hoursDataGrid.Rows[j].DefaultCellStyle.BackColor == Color.Empty)
                            hoursDataGrid.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 200, 200);
                    }
                }
            }

            if (_chg3semiPeakZone.GetLength(0) > 0)
            {
                for (int i = 0; i < _chg3semiPeakZone.GetLength(0); i++)
                {
                    for (int j = _chg3semiPeakZone[i, 4]; j <= _chg3semiPeakZone[i, 5]; j++)
                    {
                        if (hoursDataGrid.Rows[j].DefaultCellStyle.BackColor == Color.Empty)
                            hoursDataGrid.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 215, 180);
                    }
                }
            }

            if (_chg3nightZone.GetLength(0) > 0)
            {
                for (int i = 0; i < _chg3nightZone.GetLength(0); i++)
                {
                    for (int j = _chg3nightZone[i, 4]; j <= _chg3nightZone[i, 5]; j++)
                    {
                        if (hoursDataGrid.Rows[j].DefaultCellStyle.BackColor == Color.Empty)
                            hoursDataGrid.Rows[j].DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200, 250);
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

        private int[,] SelectedRows(int[,] rectangles, bool multiRange)
        {
            List<int> selectedRows = new List<int>();
            foreach(DataGridViewRow row in hoursDataGrid.Rows)
            {
                if(row.Selected)
                {
                    selectedRows.Add(row.Index);
                }
            }
            if (selectedRows.Count == 0)
                return rectangles;


            int arraysCount = 1;
            rectangles = new int[arraysCount, 6];


            for (int i = 0; i < selectedRows.Count; i++)
            {
                if (i == 0)
                {
                    rectangles[arraysCount - 1, 0] = 1;
                    rectangles[arraysCount - 1, 1] = hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Y;
                    rectangles[arraysCount - 1, 2] = hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Width-1;
                    rectangles[arraysCount - 1, 3] = hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Height;
                    rectangles[arraysCount - 1, 4] = selectedRows[i];
                    rectangles[arraysCount - 1, 5] = selectedRows[i];
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
                        else if (multiRange)
                        {
                            arraysCount++;
                            rectangles = ResizeArray(rectangles, arraysCount, 6);
                            rectangles[arraysCount - 1, 0] = 1;
                            rectangles[arraysCount - 1, 1] = hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Y;
                            rectangles[arraysCount - 1, 2] = hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Width-1;
                            rectangles[arraysCount - 1, 3] = hoursDataGrid.GetRowDisplayRectangle(selectedRows[i], false).Height;
                            rectangles[arraysCount - 1, 4] = selectedRows[i];
                            rectangles[arraysCount - 1, 5] = selectedRows[i];
                        }
                        else
                        {
                            hoursDataGrid.ClearSelection();
                            for(int k = rectangles[arraysCount - 1, 4]; k<= rectangles[arraysCount - 1, 5]; k++)
                            {
                                hoursDataGrid.Rows[k].Selected = true;
                            }
                            return rectangles;
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
                                    if(row.DefaultCellStyle.BackColor == Color.FromArgb(255, 250, 200, 200))
                                        row.DefaultCellStyle.BackColor = Color.Empty;
                                }
                                hoursDataGrid.Invalidate();
                                _chg2dayZone = SelectedRows(_chg2dayZone, false);
                                break;

                            case "ночь":
                                foreach (DataGridViewRow row in hoursDataGrid.Rows)
                                {
                                    if (row.DefaultCellStyle.BackColor == Color.FromArgb(255, 200, 200, 250))
                                        row.DefaultCellStyle.BackColor = Color.Empty;
                                }
                                hoursDataGrid.Invalidate();
                                _chg2nightZone = SelectedRows(_chg2nightZone, true);
                                break;
                        }
                        break;

                    case "3 зоны":
                        switch (cmbxSelectTypeZone.Text)
                        {
                            case "пик":
                                foreach (DataGridViewRow row in hoursDataGrid.Rows)
                                {
                                    if (row.DefaultCellStyle.BackColor == Color.FromArgb(255, 250, 200, 200))
                                        row.DefaultCellStyle.BackColor = Color.Empty;
                                }
                                hoursDataGrid.Invalidate();
                                _chg3peakZone = SelectedRows(_chg3peakZone, true);
                                break;

                            case "полупик":
                                foreach (DataGridViewRow row in hoursDataGrid.Rows)
                                {
                                    if (row.DefaultCellStyle.BackColor == Color.FromArgb(255, 250, 215, 180))
                                        row.DefaultCellStyle.BackColor = Color.Empty;
                                }
                                hoursDataGrid.Invalidate();
                                _chg3semiPeakZone = SelectedRows(_chg3semiPeakZone, true);
                                break;

                            case "ночь":
                                foreach (DataGridViewRow row in hoursDataGrid.Rows)
                                {
                                    if (row.DefaultCellStyle.BackColor == Color.FromArgb(255, 200, 200, 250))
                                        row.DefaultCellStyle.BackColor = Color.Empty;
                                }
                                hoursDataGrid.Invalidate();
                                _chg3nightZone = SelectedRows(_chg3nightZone, true);
                                break;
                        }
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

        private void hoursDataGrid_Paint(object sender, PaintEventArgs e)
        {
            switch (cmbxSelectGlobalZone.Text)
            {
                case "2 зоны":
                    if (_chg2dayZone.GetLength(0) > 0)
                    {
                        for (int i = 0; i < _chg2dayZone.GetLength(0); i++)
                        {
                            Rectangle rowBound = new Rectangle(_chg2dayZone[i, 0], _chg2dayZone[i, 1], _chg2dayZone[i, 2], _chg2dayZone[i, 3]);
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


                    if (_chg2nightZone.GetLength(0) > 0)
                    {
                        for (int i = 0; i < _chg2nightZone.GetLength(0); i++)
                        {
                            Rectangle rowBound = new Rectangle(_chg2nightZone[i, 0], _chg2nightZone[i, 1], _chg2nightZone[i, 2], _chg2nightZone[i, 3]);
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
                    break;

                case "3 зоны":
                    if (_chg3peakZone.GetLength(0) > 0)
                    {
                        for (int i = 0; i < _chg3peakZone.GetLength(0); i++)
                        {
                            Rectangle rowBound = new Rectangle(_chg3peakZone[i, 0], _chg3peakZone[i, 1], _chg3peakZone[i, 2], _chg3peakZone[i, 3]);
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

                    if (_chg3semiPeakZone.GetLength(0) > 0)
                    {
                        for (int i = 0; i < _chg3semiPeakZone.GetLength(0); i++)
                        {
                            Rectangle rowBound = new Rectangle(_chg3semiPeakZone[i, 0], _chg3semiPeakZone[i, 1], _chg3semiPeakZone[i, 2], _chg3semiPeakZone[i, 3]);
                            using (var pen = new Pen(Color.FromArgb(255, 250, 150, 50), 2))
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

                    if (_chg3nightZone.GetLength(0) > 0)
                    {
                        for (int i = 0; i < _chg3nightZone.GetLength(0); i++)
                        {
                            Rectangle rowBound = new Rectangle(_chg3nightZone[i, 0], _chg3nightZone[i, 1], _chg3nightZone[i, 2], _chg3nightZone[i, 3]);
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
                    break;
            }
        }

        private void cmbxSelectGlobalZone_DropDownClosed(object sender, EventArgs e)
        {
            switch (cmbxSelectGlobalZone.Text)
            {
                case "2 зоны":
                    cmbxSelectTypeZone.Items.Clear();
                    cmbxSelectTypeZone.Items.AddRange(new[] { "день", "ночь" });

                    selectDoubleTreeNode();

                    foreach (DataGridViewRow rows in hoursDataGrid.Rows)
                    {
                        rows.DefaultCellStyle.BackColor = Color.Empty;
                    }
                    doubleZoneBackColor();
                    hoursDataGrid.Refresh();
                    hoursDataGrid.ClearSelection();
                    break;

                case "3 зоны":
                    cmbxSelectTypeZone.Items.Clear();
                    cmbxSelectTypeZone.Items.AddRange(new[] { "пик", "полупик", "ночь" });
                    
                    selectTrippleTreeNode();

                    foreach (DataGridViewRow rows in hoursDataGrid.Rows)
                    {
                        rows.DefaultCellStyle.BackColor = Color.Empty;
                    }
                    trippleZoneBackColor();
                    hoursDataGrid.Refresh();
                    hoursDataGrid.ClearSelection();
                    break;
            }
        }


        private void selectDoubleTreeNode()
        {
            TreeNode autoSelectNode = null;
            if (doubleZoneTreeView.SelectedNode == null)
            {
                autoSelectNode = doubleZoneTreeView.Nodes[0];
                doubleZoneTreeView.SelectedNode = autoSelectNode;
                cmbxSelectTypeZone.SelectedIndex = 0;
                btnAddNew3z.Enabled = false;
                btnAddNew3z.Visible = false;
            }
            else
            {
                btnAddNew3z.Enabled = false;
                btnAddNew3z.Visible = false;
                switch (doubleZoneTreeView.SelectedNode.FullPath.Split('\\').First())
                {
                    case "день":
                        cmbxSelectTypeZone.SelectedIndex = 0;
                        break;

                    case "ночь":
                        cmbxSelectTypeZone.SelectedIndex = 1;
                        break;
                }
            }

            groupDoubleZone.ForeColor = Color.Black;
            groupTrippleZone.ForeColor = Color.Gray;
        }

        private void selectTrippleTreeNode()
        {
            if (trippleZoneTreeView.SelectedNode == null)
            {
                TreeNode autoSelectNode = trippleZoneTreeView.Nodes[0];
                trippleZoneTreeView.SelectedNode = autoSelectNode;
                cmbxSelectTypeZone.SelectedIndex = 0;
                btnAddNew3z.Enabled = true;
                btnAddNew3z.Visible = true;
            }
            else
            {
                btnAddNew3z.Enabled = true;
                btnAddNew3z.Visible = true;
                switch (trippleZoneTreeView.SelectedNode.FullPath.Split('\\').First())
                {
                    case "пик":
                        cmbxSelectTypeZone.SelectedIndex = 0;
                        break;

                    case "полупик":
                        cmbxSelectTypeZone.SelectedIndex = 1;
                        break;

                    case "ночь":
                        cmbxSelectTypeZone.SelectedIndex = 2;
                        break;
                }
            }

            groupDoubleZone.ForeColor = Color.Gray;
            groupTrippleZone.ForeColor = Color.Black;
        }

        private void cmbxSelectTypeZone_DropDownClosed(object sender, EventArgs e)
        {
            TreeNode autoSelectNode = null;
            switch (cmbxSelectGlobalZone.Text)
            {
                case "2 зоны":
                    autoSelectNode = doubleZoneTreeView.Nodes[cmbxSelectTypeZone.SelectedIndex];
                    doubleZoneTreeView.SelectedNode = autoSelectNode;
                    break;

                case "3 зоны":
                    autoSelectNode = trippleZoneTreeView.Nodes[cmbxSelectTypeZone.SelectedIndex];
                    trippleZoneTreeView.SelectedNode = autoSelectNode;
                    break;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void typeList_DropDownClosed(object sender, EventArgs e)
        {
            switch(typeList.SelectedIndex)
            {
                case 0:
                    _chg2dayZone = _2dayZone_00;
                    _chg2nightZone = _2nightZone_00;

                    _chg3peakZone = _3peakZone_00;
                    _chg3semiPeakZone = _3semiPeakZone_00;
                    _chg3nightZone = _3nightZone_00;

                    foreach (DataGridViewRow rows in hoursDataGrid.Rows)
                    {
                        rows.DefaultCellStyle.BackColor = Color.Empty;
                    }

                    switch (cmbxSelectGlobalZone.Text)
                    {
                        case "2 зоны":
                            doubleZoneBackColor();
                            break;
                        case "3 зоны":
                            trippleZoneBackColor();
                            break;
                    }

                            hoursDataGrid.Refresh();
                    hoursDataGrid.ClearSelection();
                    break;

                case 1:
                    _chg2dayZone = _2dayZone_01;
                    _chg2nightZone = _2nightZone_01;

                    _chg3peakZone = _3peakZone_01;
                    _chg3semiPeakZone = _3semiPeakZone_01;
                    _chg3nightZone = _3nightZone_01;

                    foreach (DataGridViewRow rows in hoursDataGrid.Rows)
                    {
                        rows.DefaultCellStyle.BackColor = Color.Empty;
                    }

                    switch (cmbxSelectGlobalZone.Text)
                    {
                        case "2 зоны":
                            doubleZoneBackColor();
                            break;
                        case "3 зоны":
                            trippleZoneBackColor();
                            break;
                    }

                    hoursDataGrid.Refresh();
                    hoursDataGrid.ClearSelection();
                    break;

                default:
                    foreach (DataGridViewRow rows in hoursDataGrid.Rows)
                    {
                        rows.DefaultCellStyle.BackColor = Color.Empty;
                    }

                    switch (cmbxSelectGlobalZone.Text)
                    {
                        case "2 зоны":
                            doubleZoneBackColor();
                            break;
                        case "3 зоны":
                            trippleZoneBackColor();
                            break;
                    }

                    hoursDataGrid.Refresh();
                    hoursDataGrid.ClearSelection();
                    break;
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveData(typeList.SelectedIndex,cmbxSelectGlobalZone.SelectedIndex);
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            saveData(typeList.SelectedIndex,2);
        }
    }
}
