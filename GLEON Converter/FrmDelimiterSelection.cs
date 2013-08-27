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
    public partial class FrmDelimiterSelection : Form
    {
        public FrmDelimiterSelection()
        {
            InitializeComponent();
        }
        private DataTable InputTable;
        public bool exitByCancel;
        public string _filename;
        public char newDelimiter;
        public bool OpenEmptyRowStrip;
        public bool OpenHeaderRowDetect;
        private void Form1_Load(object sender, EventArgs e)
        {
            exitByCancel = false;
            comboDelimiters.Items.Add("Tab");
            comboDelimiters.Items.Add("Comma");
            comboDelimiters.Items.Add("Space");
            comboDelimiters.Items.Add("Semicolon");
            comboDelimiters.Sorted = true;
            if (Path.GetExtension(_filename) == ".csv")
            {
                comboDelimiters.SelectedText = "Comma";
                newDelimiter = ',';
                LoadData(',');
            }
            else
            {
                comboDelimiters.SelectedText = "Tab";
                newDelimiter = '\t';
                LoadData('\t');
            }

        }
        private void LoadData(char newDelim)
        {
            InputTable = new DataTable();
            string line;
            int lineCount = 0;
            int m_iColumnCount = 0;
            string[] row;
            try
            {
                StreamReader reader = new StreamReader(_filename);
                
                for(int lineNum = 1; lineNum <=30; lineNum++)
                {
                    line = reader.ReadLine();
                    lineCount++;
                    row = line.Split(newDelim);
                    if (lineCount == 1)
                    {
                        m_iColumnCount = row.Length;
                        int headerindex = 0;
                        foreach (String colHeader in row)
                        {
                            InputTable.Columns.Add(headerindex.ToString());
                            headerindex++;
                        }
                    }

                    int numValues = row.Length;

                    if (numValues > m_iColumnCount)
                    {
                        for (int i = 0; i < (numValues - m_iColumnCount); i++)
                        {
                            String strColumnName = (m_iColumnCount + i).ToString();
                            InputTable.Columns.Add(strColumnName);
                        }
                        m_iColumnCount = numValues;
                    }

                    int index = 0;
                    DataRow dRow = InputTable.NewRow();
                    foreach (string value in row)
                    {
                        dRow[index.ToString()] = value.Trim();
                        index++;
                        

                    }
                    InputTable.Rows.Add(dRow);

                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.ToString());
            }
            dataTemp.DataSource = InputTable;
            foreach (DataGridViewColumn column in dataTemp.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void comboDelimiters_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDelimiter.Text = "";
            if (comboDelimiters.Text == "Tab")
            {
                LoadData('\t');
                newDelimiter = '\t';
            }
            else if (comboDelimiters.Text == "Comma")
            {
                LoadData(',');
                newDelimiter = ',';
            }
            else if (comboDelimiters.Text == "Space")
            {
                LoadData(' ');
                newDelimiter = ' ';
            }
            else if (comboDelimiters.Text == "Semicolon")
            {
                LoadData(';');
                newDelimiter = ';';
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            OpenEmptyRowStrip = checkBoxRowStripping.Checked;
            OpenHeaderRowDetect = checkBoxHeaderDetect.Checked;
            this.Hide();
        }

        private void txtDelimiter_TextChanged(object sender, EventArgs e)
        {
            if (txtDelimiter.Text != "")
            {
                comboDelimiters.Text = "";
                if (txtDelimiter.Text.Length > 1)
                {
                    txtDelimiter.Text = txtDelimiter.Text.Substring(0, 1);
                }
                txtDelimiter.SelectionStart = 0;
                LoadData(Convert.ToChar(txtDelimiter.Text));
                newDelimiter = Convert.ToChar(txtDelimiter.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exitByCancel = true;
            this.Hide();
        }
    }
}
