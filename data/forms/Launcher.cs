using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataEditor
{

    public partial class StartScreen : Form
    {
        
        public static mgForm betaForm = new mgForm();
        public static MainForm universalReaderForm = new MainForm();

        public StartScreen()
        {
            InitializeComponent();

            //universalReaderForm.Text = ((AssemblyProductAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0]).Product + "  ver." + Application.ProductVersion;
            this.labelVersion.Text = String.Format("version {0}", Application.ProductVersion);
            this.labelBuild.Text = String.Format("build: {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            this.navCmbxAccessList.Text = "MKG_REALESE_CLOSE";

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "dataEditor.data.text.RELEASE-NOTES.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                ChangeLogBox.Text = reader.ReadToEnd();
            }
        }


        private void startUR_Click(object sender, EventArgs e)
        {
            //universalReaderForm.SectionsControl.TabPages[0].Parent = null;
            universalReaderForm.Show();
            this.Hide();
        }

        private void StartScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
             Application.Exit();
        }
    }
}
