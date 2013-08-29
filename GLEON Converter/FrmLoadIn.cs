using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FrmLoadIn : Form
    {
        public FrmLoadIn()
        {
            InitializeComponent();
            btnNext.Enabled = true;
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Title = "Please select a Data File";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtData.Text = dialog.FileName;
                btnNext.Enabled = true;
            } 
        }

        private void btnMeta_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "meta files (*.meta)|*.meta|All files (*.*)|*.*";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Title = "Please select a Data File";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtMeta.Text = dialog.FileName;
            } 
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtData.Text))
            {

                if (!String.IsNullOrWhiteSpace(txtMeta.Text))
                {
                    FrmMain m = new FrmMain();
                    m.OpenFile = txtData.Text;
                    
                    m.openFile(txtData.Text);
                    
                    m.standardizeDateColumn();
                    m.openMeta(txtMeta.Text);
                    m.Show();
                }
            }

        }


    }
}
