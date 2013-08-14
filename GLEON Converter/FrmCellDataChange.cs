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
    public partial class FrmCellDataChange : Form
    {
        public bool save;
        public FrmCellDataChange()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save = true;
            this.Hide();
        }
        public void setText(string input)
        {
            txtDataValue.Text = input;
        }
        public string getText()
        {
            return txtDataValue.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            save = false;
            this.Hide();
        }

        private void FrmCellDataChange_Load(object sender, EventArgs e)
        {
            save = false;
        }
    }
}
