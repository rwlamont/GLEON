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
    public partial class FrmColAggType : Form
    {
        public FrmColAggType()
        {
            InitializeComponent();
        }
        public bool exitByCancel;
        public void generateColHeaders(HeaderInfo [] colHeaders)
        {
            int locationY = 33;
            foreach (HeaderInfo header in colHeaders)
            {
                //ComboBox
                string comboboxName = header.colNum + "ComboBox";
                ComboBox newCombo = new ComboBox();
                newCombo.Name = comboboxName;
                newCombo.Width = 116;
                newCombo.Height = 21;
                newCombo.Location = new Point(194, locationY);
                newCombo.Items.Add("Sum");
                newCombo.Items.Add("Mean");
                newCombo.Items.Add("Nearest timestamp");
                panelMain.Controls.Add(newCombo);

                //Label
                string labelName = header.colNum + "Label";
                Label newLabel = new Label();
                newLabel.Name = labelName;
                newLabel.Text = header.headerText;
                newLabel.Location = new Point(3, locationY + 3);
                panelMain.Controls.Add(newLabel);

                locationY += 27;
            }
        }
        public string retrieveAggType(int colNum)
        {
            return (panelMain.Controls[colNum + "ComboBox"] as ComboBox).Text;
        }

        private void FrmColAggType_Load(object sender, EventArgs e)
        {
            exitByCancel = false;
        }

        private void btnAggregate_Click(object sender, EventArgs e)
        {
            int unSet = 0;
            foreach (Control temp in panelMain.Controls)
            {
                if (temp.GetType() == typeof(ComboBox))
                {
                    if (temp.Text == "")
                        unSet++;
                }
            }
            if (unSet == 0)
                this.Hide();
            else
                MessageBox.Show("Some Variables have not been set!");
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            foreach (Control temp in panelMain.Controls)
            {
                if (temp.GetType() == typeof(ComboBox))
                    temp.Text = "Sum";
            }

        }

        private void btnAverage_Click(object sender, EventArgs e)
        {
            foreach (Control temp in panelMain.Controls)
            {
                if (temp.GetType() == typeof(ComboBox))
                    temp.Text = "Mean";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Control temp in panelMain.Controls)
            {
                if (temp.GetType() == typeof(ComboBox))
                    temp.Text = "Nearest timestamp";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            exitByCancel = true;
            this.Hide();
        }
    }
}
