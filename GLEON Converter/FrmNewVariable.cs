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
    public partial class FrmNewVariable : Form
    {
        private int numUnits;

        public string testCode;
        public string testName;
        public List<string> possibleUnits;
        public string RecommendedUnits;
        public bool exitByCancel = false;

        public FrmNewVariable()
        {
            InitializeComponent();
            numUnits = 2;
        }

        private void btnMoreUnits_Click(object sender, EventArgs e)
        {
            numUnits++;

            Label lblUnitsNew = new Label();
            lblUnitsNew.Text = "Secondary Units";
            panelUnits.Controls.Add(lblUnitsNew);
            lblUnitsNew.Location = new Point(10, 3 + 26 * (numUnits-1));

            TextBox txtUnitsNew = new TextBox();
            txtUnitsNew.Width = 100;
            txtUnitsNew.Height =  20;
            txtUnitsNew.Name = "txtUnits" + numUnits;
            panelUnits.Controls.Add(txtUnitsNew);
            txtUnitsNew.Location = new Point(117, 26 * (numUnits-1));

            btnMoreUnits.Location = new Point(117, 26*(numUnits));

            panelUnits.Height += 26;
            this.Height += 26;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            testName = txtVariableName.Text;
            testCode = txtVariableCode.Text;
            RecommendedUnits = txtUnits1.Text;
            foreach (Control txtbox in panelUnits.Controls)
            {
                TextBox posUnits = txtbox as TextBox;
                possibleUnits.Add(txtbox.Text);
            }
            this.Hide();
        }

        private void txtVariableCode_TextChanged(object sender, EventArgs e)
        {
            TextBox textChanged = sender as TextBox;
            if (textChanged.Text.Length > 6)
            {
                textChanged.Text = textChanged.Text.Substring(0, 6);
            }
            textChanged.SelectionStart = textChanged.Text.Length;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            exitByCancel = true;
            this.Hide();
        }
    }
}
