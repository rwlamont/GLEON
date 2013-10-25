using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class FrmLoadIn : Form
    {
        public bool exitByCancel;
        public string metaFileLoc;
        public string dataFileLoc;
        public bool noMeta;
        public string lastPath;

        public FrmLoadIn()
        {
            InitializeComponent();
            btnNext.Enabled = true;
            lastPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Data Files (*.csv,*.tsv,*.txt)|*.txt;*.txt;*.csv|csv files (*.csv)|*.csv|tsv files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.InitialDirectory = lastPath;
            dialog.Title = "Please select a Data File";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtData.Text = dialog.FileName;
                btnNext.Enabled = true;
                lastPath = Path.GetDirectoryName(dialog.FileName);
            }  
            else
            {
                MessageBox.Show("No data file was selected, please select your data file.", "Data file needed");
            }
        }

        private void btnMeta_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Metadata files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.InitialDirectory = lastPath;
            dialog.Title = "Please select a Data File";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtMeta.Text = dialog.FileName;
                lastPath = Path.GetDirectoryName(dialog.FileName);
            }
            else
            {
                MessageBox.Show("No meta file was selected, please select your meta file.", "Meta file error");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtData.Text))
            {

                if (!String.IsNullOrWhiteSpace(txtMeta.Text))
                {
                    dataFileLoc = txtData.Text;
                    metaFileLoc = txtMeta.Text;
                    this.Hide();
                }
                else
                {
                    dataFileLoc = txtData.Text;
                    noMeta = true;
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("No data file was selected, please select your data file.", "Data file needed");
            }


        }

        private void brnCancel_Click(object sender, EventArgs e)
        {
            exitByCancel = true;
            this.Hide();
        }

        private void FrmLoadIn_Load(object sender, EventArgs e)
        {

        }


    }
}
