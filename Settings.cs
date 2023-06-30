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
        
        public Settings()
        {
            InitializeComponent();
            optionsGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(optionsGrid_PropertyValueChanged);
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
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

    }
}
