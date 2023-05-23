using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace dataEditor
{
    public partial class bankDictionary : Form
    {
        public static bool isLoadedBanks;

        public bankDictionary()
        {
            InitializeComponent();
        }

        public void loadDictionaryBanks(bool fl)
        {
            if (!isLoadedBanks)
            {
                DataSet ImportDataSet = new DataSet();

                dataGridBanksList.DataSource = null;
                DataTable DT = (DataTable)dataGridBanksList.DataSource;
                if (DT != null)
                    DT.Clear();

                dataGridBanksList.Rows.Clear();
                dataGridBanksList.Refresh();

                if (File.Exists(Environment.CurrentDirectory + "\\banksDictionary.xml"))
                {
                    string xmlFileName = Environment.CurrentDirectory + "\\banksDictionary.xml";

                    XDocument XMLfile = XDocument.Load(xmlFileName);
                    ImportDataSet.ReadXml(xmlFileName);

                    int rwi = 0;
                    foreach (XElement infoElement in XMLfile.Root.Elements("banksDictionary"))
                    {
                        dataGridBanksList.Rows.Add();
                        if (infoElement.Element("dictBankID") != null)
                            dataGridBanksList.Rows[rwi].Cells["dictBankID"].Value = infoElement.Element("dictBankID").Value;
                        if (infoElement.Element("dictBankName") != null)
                        {
                            dataGridBanksList.Rows[rwi].Cells["dictBankName"].Value = infoElement.Element("dictBankName").Value;
                            mgDatsList.banksList.Add(infoElement.Element("dictBankID").Value + "    " + infoElement.Element("dictBankName").Value.ToString());
                        }
                        if (infoElement.Element("dictBankBIK") != null)
                            dataGridBanksList.Rows[rwi].Cells["dictBankBIK"].Value = infoElement.Element("dictBankBIK").Value;
                        if (infoElement.Element("dictBankCorrAcc") != null)
                            dataGridBanksList.Rows[rwi].Cells["dictBankCorrAcc"].Value = infoElement.Element("dictBankCorrAcc").Value;
                        if (infoElement.Element("dictBankINN") != null)
                            dataGridBanksList.Rows[rwi].Cells["dictBankINN"].Value = infoElement.Element("dictBankINN").Value;
                        rwi++;
                    }
                }
                dataGridBanksList.Refresh();
                isLoadedBanks = true;
            }
        }

        private void bankDictionary_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Application.OpenForms["bankDictionary"].Hide();
        }

        private void dictBankBtnAddElm_Click(object sender, EventArgs e)
        {
            dataGridBanksList.Rows.Add();
            dataGridBanksList.Rows[dataGridBanksList.RowCount-1].Cells[0].Value = dataGridBanksList.RowCount;
            dataGridBanksList.Refresh();
        }

        private void dictBankBtnDelElm_Click(object sender, EventArgs e)
        {
            dataGridBanksList.Rows.RemoveAt(dataGridBanksList.CurrentCell.RowIndex);
            foreach (DataGridViewRow row in dataGridBanksList.Rows)
            {
                dataGridBanksList.Rows[row.Index].Cells[0].Value = row.Index + 1;
            }
        }

        private void dictBankBtnSave_Click(object sender, EventArgs e)
        {
            DataSet DictionaryDataSet = new DataSet("BanksData");
            DataTable exportTable = new DataTable();

            DictionaryDataSet.Clear();
            exportTable.Clear();

            exportTable.TableName = "banksDictionary";
            DictionaryDataSet.Tables.Add(exportTable);
            exportTable.Columns.Add("dictBankID");
            exportTable.Columns.Add("dictBankName");
            exportTable.Columns.Add("dictBankBIK");
            exportTable.Columns.Add("dictBankCorrAcc");
            exportTable.Columns.Add("dictBankINN");


            foreach (DataGridViewRow rw in dataGridBanksList.Rows)
            {
                DataRow row = DictionaryDataSet.Tables["banksDictionary"].NewRow();
                row["dictBankID"] = rw.Cells["dictBankID"].Value;
                row["dictBankName"] = rw.Cells["dictBankName"].Value;
                row["dictBankBIK"] = rw.Cells["dictBankBIK"].Value;
                row["dictBankCorrAcc"] = rw.Cells["dictBankCorrAcc"].Value;
                row["dictBankINN"] = rw.Cells["dictBankINN"].Value;


                DictionaryDataSet.Tables["banksDictionary"].Rows.Add(row);
            }

            string xmlFileName = Environment.CurrentDirectory + "\\banksDictionary.xml";
            try
            {
                mgDatsList.banksList.Clear();
                foreach (DataGridViewRow rws in dataGridBanksList.Rows)
                {
                    mgDatsList.banksList.Add(rws.Cells["dictBankName"].Value.ToString());
                }

                DictionaryDataSet.WriteXml(xmlFileName.ToString());
                Console.WriteLine("The file was saved successfully");
            }
            catch
            {
                Console.WriteLine("Failed to save file");
            }
        }

    }
}
