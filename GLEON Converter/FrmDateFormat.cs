using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace WindowsFormsApplication1
{
    public partial class FrmDateFormat : Form
    {
        public FrmDateFormat()
        {
            InitializeComponent();
        }
        public string format = "";
        public string input = "";
        public bool validFormat = false;
        public bool cancel = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            lblIn.Text = input;
            #region setup
            comboFirst.Items.Add("Date Day - short eg 2");
            comboFirst.Items.Add("Date Day - long eg 02");
            comboFirst.Items.Add("Date Month - short eg 2");
            comboFirst.Items.Add("Date Month - long eg 02");
            comboFirst.Items.Add("Date Year - short eg 13");
            comboFirst.Items.Add("Date Year - long eg 2013");
            comboFirst.Items.Add("Time 24hr - short - no seconds - eg 2:15");
            comboFirst.Items.Add("Time 24hr - short - seconds - eg 2:15:30");
            comboFirst.Items.Add("Time 24hr - long - no seconds - eg 02:15");
            comboFirst.Items.Add("Time 24hr - long  - seconds - eg 02:15:30");
            comboFirst.Items.Add("Time 12hr - no am/pm - no seconds - eg 2:15");
            comboFirst.Items.Add("Time 12hr - no am/pm - seconds - eg 2:15:30");
            comboFirst.Items.Add("Time 12hr - am/pm - no seconds - eg 2:15 am");
            comboFirst.Items.Add("Time 12hr - am/pm - seconds - eg 2:15:30 am");
            comboFirst.SelectedItem = "Date Year - long eg 2013";

            comboSecond.Items.Add("Date Day - short eg 2");
            comboSecond.Items.Add("Date Day - long eg 02");
            comboSecond.Items.Add("Date Month - short eg 2");
            comboSecond.Items.Add("Date Month - long eg 02");
            comboSecond.Items.Add("Date Year - short eg 13");
            comboSecond.Items.Add("Date Year - long eg 2013");
            comboSecond.Items.Add("Time 24hr - short - no seconds - eg 2:15");
            comboSecond.Items.Add("Time 24hr - short - seconds - eg 2:15:30");
            comboSecond.Items.Add("Time 24hr - long - no seconds - eg 02:15");
            comboSecond.Items.Add("Time 24hr - long  - seconds - eg 02:15:30");
            comboSecond.Items.Add("Time 12hr - no am/pm - no seconds - eg 2:15");
            comboSecond.Items.Add("Time 12hr - no am/pm - seconds - eg 2:15:30");
            comboSecond.Items.Add("Time 12hr - am/pm - no seconds - eg 2:15 am");
            comboSecond.Items.Add("Time 12hr - am/pm - seconds - eg 2:15:30 am");
            comboSecond.SelectedItem = "Date Month - long eg 02";

            comboThird.Items.Add("Date Day - short eg 2");
            comboThird.Items.Add("Date Day - long eg 02");
            comboThird.Items.Add("Date Month - short eg 2");
            comboThird.Items.Add("Date Month - long eg 02");
            comboThird.Items.Add("Date Year - short eg 13");
            comboThird.Items.Add("Date Year - long eg 2013");
            comboThird.Items.Add("Time 24hr - short - no seconds - eg 2:15");
            comboThird.Items.Add("Time 24hr - short - seconds - eg 2:15:30");
            comboThird.Items.Add("Time 24hr - long - no seconds - eg 02:15");
            comboThird.Items.Add("Time 24hr - long  - seconds - eg 02:15:30");
            comboThird.Items.Add("Time 12hr - no am/pm - no seconds - eg 2:15");
            comboThird.Items.Add("Time 12hr - no am/pm - seconds - eg 2:15:30");
            comboThird.Items.Add("Time 12hr - am/pm - no seconds - eg 2:15 am");
            comboThird.Items.Add("Time 12hr - am/pm - seconds - eg 2:15:30 am");
            comboThird.SelectedItem = "Date Day - long eg 02";

            comboFourth.Items.Add("Date Day - short eg 2");
            comboFourth.Items.Add("Date Day - long eg 02");
            comboFourth.Items.Add("Date Month - short eg 2");
            comboFourth.Items.Add("Date Month - long eg 02");
            comboFourth.Items.Add("Date Year - short eg 13");
            comboFourth.Items.Add("Date Year - long eg 2013");
            comboFourth.Items.Add("Time 24hr - short - no seconds - eg 2:15");
            comboFourth.Items.Add("Time 24hr - short - seconds - eg 2:15:30");
            comboFourth.Items.Add("Time 24hr - long - no seconds - eg 02:15");
            comboFourth.Items.Add("Time 24hr - long  - seconds - eg 02:15:30");
            comboFourth.Items.Add("Time 12hr - no am/pm - no seconds - eg 2:15");
            comboFourth.Items.Add("Time 12hr - no am/pm - seconds - eg 2:15:30");
            comboFourth.Items.Add("Time 12hr - am/pm - no seconds - eg 2:15 am");
            comboFourth.Items.Add("Time 12hr - am/pm - seconds - eg 2:15:30 am");
            comboFourth.SelectedItem = "Time 24hr - long  - seconds - eg 02:15:30";
#endregion

            Graphics gFirst = comboFirst.CreateGraphics();
            Graphics gSecond = comboSecond.CreateGraphics();
            Graphics gThird = comboThird.CreateGraphics();
            Graphics gFourth = comboFourth.CreateGraphics();
            int ddWidthFirst = comboFirst.DropDownWidth;
            int ddWidthSecond = comboSecond.DropDownWidth;
            int ddWidthThird = comboThird.DropDownWidth;
            int ddWidthFourth = comboFourth.DropDownWidth;

            int vertScrollBarWidth = (comboFirst.Items.Count > comboFirst.MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0;
            int newWidth = 0;

            foreach (string s in comboFirst.Items)
            {
                newWidth = (int)gFirst.MeasureString(s, comboFirst.Font).Width + vertScrollBarWidth;
                if (ddWidthFirst < newWidth)
                {
                    ddWidthFirst = newWidth;
                }

            }
            comboFirst.DropDownWidth = ddWidthFirst;

            newWidth = 0;
            foreach (string s in comboSecond.Items)
            {
                newWidth = (int)gSecond.MeasureString(s, comboSecond.Font).Width + vertScrollBarWidth;
                if (ddWidthSecond < newWidth)
                {
                    ddWidthSecond = newWidth;
                }

            }
            comboSecond.DropDownWidth = ddWidthSecond;

            newWidth = 0;
            foreach (string s in comboThird.Items)
            {
                newWidth = (int)gThird.MeasureString(s, comboThird.Font).Width + vertScrollBarWidth;
                if (ddWidthThird < newWidth)
                {
                    ddWidthThird = newWidth;
                }

            }
            comboThird.DropDownWidth = ddWidthThird;

            newWidth = 0;
            foreach (string s in comboFourth.Items)
            {
                newWidth = (int)gFourth.MeasureString(s, comboFourth.Font).Width + vertScrollBarWidth;
                if (ddWidthFourth < newWidth)
                {
                    ddWidthFourth = newWidth;
                }

            }
            comboFourth.DropDownWidth = ddWidthFourth;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            update();
            DialogResult result = DialogResult.Ignore;
            if (lblOut.Text == "" && checkCustom.Checked == false)
            {
                result = MessageBox.Show("You have not selected a valid dateTime format. Do you wish to continue without converting you time column to a standard format?", "", MessageBoxButtons.YesNo);
            }
            if (checkCustom.Checked == true)
            {
                format = txtCustomFormat.Text;
                validFormat = true;
            }
            if(validFormat == true || result == DialogResult.Yes)
            {
                            this.Hide();
            }

        }
        private void update()
        {
            //Update format
            if (checkCustom.Checked == true)
            {
                format = txtCustomFormat.Text;
            }
            else
            {
                format = getValue(comboFirst.Text);
                if (comboSecond.Text != "")
                    format += " ";
                format += getValue(comboSecond.Text);
                if (comboThird.Text != "")
                    format += " ";
                format += getValue(comboThird.Text);
                if (comboFourth.Text != "")
                    format += " ";
                format += getValue(comboFourth.Text);
            }
            DateTime ConvertedDate;
            input = input.Replace('/', ' ');
            input = input.Replace('-', ' ');
            if (DateTime.TryParseExact(input, format, null, DateTimeStyles.None, out ConvertedDate))
            {
                string output = ConvertedDate.ToString("yyyy-MM-dd HH:mm:ss");
                lblOut.Text = output;
                validFormat = true;
            }
            else
            {
                lblOut.Text = "Invalid format. Please reselect fields above or enter custom format below.";
                validFormat = false;
            }
        }

        private string getValue(string input)
        {
            switch(input){
                case "Date Day - short eg 2":
                    return "d";
                case "Date Day - long eg 02":
                    return "dd";
                case "Date Month - short eg 2":
                    return "M";
                case "Date Month - long eg 02":
                    return "MM";
                case "Date Year - short eg 13":
                    return "yy";
                case "Date Year - long eg 2013":
                    return "yyyy";
                case "Time 24hr - short - no seconds - eg 2:15":
                    return "H:mm";
                case "Time 24hr - short - seconds - eg 2:15:30":
                    return "H:mm:ss";
                case "Time 24hr - long - no seconds - eg 02:15":
                    return "HH:mm:ss";
                case "Time 24hr - long  - seconds - eg 02:15:30":
                    return "HH:mm:ss";
                case "Time 12hr - no am/pm - no seconds - eg 2:15":
                    return "h:mm";
                case "Time 12hr - no am/pm - seconds - eg 2:15:30":
                    return "h:mm:ss";
                case "Time 12hr - am/pm - no seconds - eg 2:15 am":
                    return "h:mm:ss";
                case "Time 12hr - am/pm - seconds - eg 2:15:30 am":
                    return "h:mm:ss";
                default:
                    break;
            }
            return null;
        }

        private void comboFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            //update();
        }

        private void comboSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            update();
        }

        private void comboThird_SelectedIndexChanged(object sender, EventArgs e)
        {
            update();
        }

        private void comboFourth_SelectedIndexChanged(object sender, EventArgs e)
        {
            update();
        }

        private void comboFirst_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void txtCustomFormat_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancel = true;
            this.Hide();
        }
    }
}
