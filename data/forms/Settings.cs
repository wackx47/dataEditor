using dataEditor.Properties;
using MathNet.Numerics.LinearAlgebra.Factorization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataEditor
{
    public partial class Settings : Form
    {
        MainForm main = (MainForm)Application.OpenForms["MainForm"];

        public int[,] _settings2dayZone_00 = new int[0, 6];
        public int[,] _settings2nightZone_00 = new int[0, 6];
        public int[,] _settings3peakZone_00 = new int[0, 6];
        public int[,] _settings3semiPeakZone_00 = new int[0, 6];
        public int[,] _settings3nightZone_00 = new int[0, 6];

        public int[,] _settings2dayZone_01 = new int[0, 6];
        public int[,] _settings2nightZone_01 = new int[0, 6];
        public int[,] _settings3peakZone_01 = new int[0, 6];
        public int[,] _settings3semiPeakZone_01 = new int[0, 6];
        public int[,] _settings3nightZone_01 = new int[0, 6];

        public Settings()
        {
            InitializeComponent();
            optionsGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(optionsGrid_PropertyValueChanged);
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Focus();
            e.Cancel = true;
            Application.OpenForms["Settings"].Hide();
        }

        private void SettingsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            main = StartScreen.universalReaderForm;
            main.switchOptionsGridSettingsGroup();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            TreeNode startNode = SettingsTreeView.Nodes[0];
            SettingsTreeView.SelectedNode = startNode;
        }

        private void optionsGrid_PropertyValueChanged(Object sender, PropertyValueChangedEventArgs e)
        {
            main = StartScreen.universalReaderForm;
            main.settingsPropertyValueChanged();
        }

        private void setBtnSave_Click(object sender, EventArgs e)
        {
            main = StartScreen.universalReaderForm;

            main._main2dayZone_00 = _settings2dayZone_00;
            main._main2nightZone_00 = _settings2nightZone_00;
            main._main3peakZone_00 = _settings3peakZone_00;
            main._main3semiPeakZone_00 = _settings3semiPeakZone_00;
            main._main3nightZone_00 = _settings3nightZone_00;

            main._main2dayZone_01 = _settings2dayZone_01;
            main._main2nightZone_01 = _settings2nightZone_01;
            main._main3peakZone_01 = _settings3peakZone_01;
            main._main3semiPeakZone_01 = _settings3semiPeakZone_01;
            main._main3nightZone_01 = _settings3nightZone_01;

            main.Focus();

            this.Close();

        }

        private void setBtnCancel_Click(object sender, EventArgs e)
        {
            main.Focus();

            this.Close();
        }
    }
}
