using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Resources;

/*
 * Fix dataViewer_CellDoubleClick
 * 
 */
namespace WindowsFormsApplication1
{
    public partial class FrmMain : Form
    {
        public HeaderInfo [] ColHeaders;
        public List <ComboBox> comboBoxes = new List<ComboBox>();
        public List<testTypeUnits> GLEONCodeData;
        public List<countryCodesTimes> countriesData;
        public List<string> siteNameSuggestions;
        bool HeaderSelected;
        public DataTable InputTable;
        private DataTable aggregatedTable;
        public string OpenFile;
        public char delimiter;
        private bool OpenEmptyRowStrip;
        private bool OpenHeaderDetect;
        private string blankPhrase;
        public FrmMain()
        {
            InitializeComponent();
        }
        public int m_iColumnCount;
        public void Form1_Load(object sender, EventArgs e)
        {
            checkFoldersExist();
            HeaderSelected = false;
            getAbbreviations();
            getCountries();
            getSiteNameSuggestions();
            setcomboEmpty();
            comboFileExtension.Items.Add(".gln");
            comboFileExtension.Items.Add(".wtr");
            comboFileExtension.Items.Add(".wnd");
            comboFileExtension.Items.Add(".sal");
            comboFileExtension.Items.Add(".txt");
            comboFileExtension.Items.Add(".csv");
            comboFileExtension.SelectedText = ".gln";

            txtGPSLat.Text = "Decimal";
            txtGPSLat.ForeColor = Color.Gray;
            txtGPSLong.Text = "Decimal";
            txtGPSLong.ForeColor = Color.Gray;

            txtAggregatorPeriodNumber.ForeColor = Color.Gray;
            txtAggregatorPeriodNumber.Text = "Quantity";
            comboAggregatorPeriod.Items.Add("Second/s");
            comboAggregatorPeriod.Items.Add("Minute/s");
            comboAggregatorPeriod.Items.Add("Hour/s");
            comboAggregatorPeriod.Items.Add("Day/s");
            comboAggregatorPeriod.Items.Add("Month/s");
            comboAggregatorPeriod.Items.Add("Year/s");

            dateTimeAggregateStart.Format = DateTimePickerFormat.Custom;
            dateTimeAggregateStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimeAggregateEnd.Format = DateTimePickerFormat.Custom;
            dateTimeAggregateEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            sitePropSiteName = "";
            sitePropOwnerName = "";
            sitePropContactName = "";
            sitePropContactNumber = "";
            sitePropElevation = "";
            sitePropNotes = "";
            sitePropGPSLat = "";
            sitePropGPSLong = "";

            blankPhrase = "!Empty";
        }
        #region OpenFile
        private void openFile()
        {
            string filepath = getFiletoRead("All Files (*.*)|*.*",null);
            if (filepath != "")
            {
                FrmDelimiterSelection dSelect = new FrmDelimiterSelection();
                dSelect._filename = filepath;
                dSelect.ShowDialog();
                if (dSelect.exitByCancel == false)
                {
                    delimiter = dSelect.newDelimiter;
                    OpenEmptyRowStrip = dSelect.OpenEmptyRowStrip;
                    OpenHeaderDetect = dSelect.OpenHeaderRowDetect;
                    dSelect.Close();
                    this.Focus();
                    Cursor.Current = Cursors.WaitCursor;
                    ReadinNewFile(filepath);
                    setVarBoxesInPanel();
                    if (OpenHeaderDetect)
                    {
                        headerRowDetection();
                    }
                    if (OpenEmptyRowStrip)
                    {
                        stripMetadata();
                    }
                    getStartEndDates();
                    openMetaForDataSet();
                    openNotes();
                    setColOrderingToNatural();
                    Cursor.Current = Cursors.Default;
                }
                
            }
        }
        public string getFiletoRead(string filter,string startLocation)
        {
            string filepath = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = filter;
            if (startLocation == null)
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            else
                dialog.InitialDirectory = startLocation;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filepath = dialog.FileName;
                OpenFile = dialog.SafeFileName;
            }
            return filepath;
        }
        public void ReadinNewFile(string _filename)
        {
            InputTable = new DataTable();
            string line;
            int lineCount = 0;
            string[] row;
            try
            {
                StreamReader reader = new StreamReader(_filename);

                while ((line = reader.ReadLine()) != null)
                {
                    lineCount++;
                    row = line.Split(delimiter);
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
                if (Regex.IsMatch(OpenFile, @".*\([A-Z]{2}\)_[0-9]{6}-[0-9]{6}(_.*)?\.gln"))
                {
                    sitePropSiteName = OpenFile.Substring(0, OpenFile.IndexOf("("));
                    comboSiteName.Text = sitePropSiteName;
                    string countryCode = Regex.Match(OpenFile, @"\(([^)]*)\)").Groups[1].Value;
                    foreach (countryCodesTimes country in countriesData)
                    {
                        if (countryCode == country.countryCode)
                        {
                            comboCountries.Text = country.countryName + " (" + country.countryCode + ")";
                        }
                    }
                }

            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.ToString());
            }
            dataViewer.DataSource = InputTable;
            btnAggregate.Text = "Aggregate";
            foreach (DataGridViewColumn column in dataViewer.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
        private DateTime startDate = DateTime.MaxValue;
        private DateTime endDate = DateTime.MinValue;
        public void getStartEndDates()
        {
            int timeCol = -1;
            //Find Time column
            foreach (DataGridViewCell dCell in dataViewer.Rows[0].Cells)
            {
                if (dCell.Value.ToString().IndexOf("datetime", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    timeCol = dCell.ColumnIndex;
                }
                
            }
            if (timeCol != -1)
            {
                foreach (DataGridViewRow dRow in dataViewer.Rows)
                {
                    foreach (DataGridViewCell dCell in dRow.Cells)
                    {
                        if (dCell.ColumnIndex == timeCol && dCell.RowIndex != 0)
                        {
                            DateTime outDT;
                            if (DateTime.TryParse(dCell.Value.ToString(), out outDT))
                            {
                                if (outDT < startDate)
                                    startDate = outDT;
                                if (outDT > endDate)
                                    endDate = outDT;
                            }
                        }
                    }
                }
                if (startDate != DateTime.MaxValue && endDate != DateTime.MinValue && endDate > startDate)
                {
                    dateTimeAggregateStart.Value = startDate;
                    dateTimeAggregateEnd.Value = endDate;
                }
            }
            else
            {
                dateTimeAggregateStart.Text = "";
                dateTimeAggregateEnd.Text = "";
            }
        }
        public void openMetaForDataSet()
        {
            if (OpenFile.Contains("("))
            {
                string siteName = OpenFile.Substring(0, OpenFile.IndexOf("("));
                string metaFile = siteName + ".meta";
                if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\Meta\" + metaFile))
                {
                    try
                    {
                        StreamReader reader = new StreamReader(System.Windows.Forms.Application.StartupPath + @"\Meta\" + metaFile);
                        sitePropOwnerName = reader.ReadLine();
                        sitePropContactName = reader.ReadLine();
                        sitePropContactNumber = reader.ReadLine();
                        sitePropContactEmail = reader.ReadLine();
                        sitePropElevation = reader.ReadLine();
                        sitePropGPSLat = reader.ReadLine();
                        sitePropGPSLong = reader.ReadLine();
                        sitePropNotes = reader.ReadToEnd();

                        txtOwner.Text = sitePropOwnerName;
                        txtContactName.Text = sitePropContactName;
                        txtContactNumber.Text = sitePropContactNumber;
                        txtContactEmail.Text = sitePropContactEmail;
                        txtElevation.Text = sitePropElevation;
                        txtGPSLat.Text = sitePropGPSLat.ToString();
                        txtGPSLong.Text = sitePropGPSLong.ToString();
                        txtSiteNotes.Text = sitePropNotes;

                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.ToString());
                    }
                }

            }
        }
        /// <summary>
        /// removes the parts of the meta file that make it user firendly to read 
        /// </summary>
        /// <param name="raw">the string as it is inputed</param>
        /// <param name="toRemove">the number of characters to remove</param>
        /// <returns></returns>
        static string CleanMetaIn(string raw, int toRemove)
        {
            string clean;
            clean = raw.Substring(toRemove);
            return clean;
        }

        public void openMeta(string filepath)
        {
               //  if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\Meta\" + OpenFile))
               // {
                    try
                    {
                        int iss;
                        string numSensors, loopStr;
                        StreamReader reader = new StreamReader(filepath);
                        reader.ReadLine(); // Throwing away asscoiated file
                        sitePropName = reader.ReadLine();
                        sitePropOwnerName = reader.ReadLine();
                        sitePropGPSLat = reader.ReadLine();
                        sitePropGPSLong = reader.ReadLine();
                        sitePropGPSGrid = reader.ReadLine();
                        sitePropElevation = reader.ReadLine();
                        reader.ReadLine(); // Throwing away contact header
                        sitePropContactName = reader.ReadLine();
                        reader.ReadLine(); // throwing away contact org
                        sitePropContactNumber = reader.ReadLine();
                        sitePropContactEmail = reader.ReadLine();
                        //sitePropNotes = reader.ReadToEnd();
                        numSensors = reader.ReadLine();

                        iss = Int32.Parse(CleanMetaIn(numSensors, 19));
                        reader.ReadLine();
                        string[] arr4 = new string[iss + 1];
                        for (int i = 0; i <= iss; i++)
                        {
                            loopStr = reader.ReadLine();
                            arr4[i] = loopStr;
                            
                            while (!string.IsNullOrEmpty(loopStr))
                            {

                                loopStr = reader.ReadLine();

                            }
                        }

                        
                        comboSiteName.Text = CleanMetaIn(sitePropName, 11);
                        txtOwner.Text = CleanMetaIn(sitePropOwnerName, 7);
                        txtContactName.Text = CleanMetaIn(sitePropContactName, 6);
                        txtContactNumber.Text = CleanMetaIn(sitePropContactNumber, 7);
                        txtContactEmail.Text = CleanMetaIn(sitePropContactEmail, 7);
                        txtElevation.Text = CleanMetaIn(sitePropElevation, 17);
                        txtGPSLat.Text = CleanMetaIn(sitePropGPSLat.ToString(), 19);
                        txtGPSLong.Text = CleanMetaIn(sitePropGPSLong.ToString(), 19);
                        txtSiteNotes.Text = sitePropNotes;



                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.ToString());
                    }
               // }
        }
        private void openNotes()
        {
            if (File.Exists(OpenFile.Substring(0, OpenFile.IndexOf('.')) + ".notes"))
            {
                try
                {
                    StreamReader reader = new StreamReader(OpenFile.Substring(0, OpenFile.IndexOf('.')) + ".notes");
                    txtDataSetNotes.Text = reader.ReadToEnd();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString());
                }
            }
        }

        //Only scans the first 30 rows for strings the fit the header pattern.
        private void headerRowDetection()
        {
            int currentHeaderRowGuess = -1;
            int currentHeaderFreq = 0;
            int acceptedHeaderFreq = 0;
            HeaderRecgonition hRec = new HeaderRecgonition();
            for (int index = 0; index <= 30 && index < dataViewer.Rows.Count; index++)
            {
                DataGridViewRow dRow = dataViewer.Rows[index];
                acceptedHeaderFreq = 0;
                foreach (DataGridViewCell dCell in dRow.Cells)
                {
                    if (Regex.IsMatch(dCell.Value.ToString(), @"([a-z]|[A-Z]){2,6}_[d,h,e,m]([0-9]|[.])+([^),^(]*)") ||
                        Regex.IsMatch(dCell.Value.ToString(), @"([a-z]|[A-Z]){2,6}_i([0-9]|[.])+\-([0-9]|[.])+([^),^(]*)") ||
                        Regex.IsMatch(dCell.Value.ToString(), @"([a-z]|[A-Z]){2,6}_[v,n]([^),^(]*)") ||
                        Regex.IsMatch(dCell.Value.ToString(), @"DateTime[A-Z]{3}\+[0-9]{1,2}") ||
                        hRec.checkforHeaderWords(dCell.Value.ToString()))
                    {
                        acceptedHeaderFreq++;
                    }
                }
                if (acceptedHeaderFreq > currentHeaderFreq)
                {
                    currentHeaderFreq = acceptedHeaderFreq;
                    currentHeaderRowGuess = dRow.Index;
                }
            }
            if (currentHeaderFreq != 0)
            {
                DataRow dRow = InputTable.NewRow();
                dRow.ItemArray = InputTable.Rows[currentHeaderRowGuess].ItemArray;
                InputTable.Rows.RemoveAt(currentHeaderRowGuess);
                InputTable.Rows.InsertAt(dRow, 0);
            }
            foreach (DataGridViewCell dCell in dataViewer.Rows[0].Cells)
            {
                dCell.Style.BackColor = Color.LightYellow;
            }
            HeaderSelected = true;

        }
        #endregion

        #region Buttons
        private void btnSetHeader_Click(object sender, EventArgs e)
        {
            

        }
        private void stripMetadata()
        {
            if (InputTable != null)
            {
                int tableHeight = InputTable.Rows.Count;
                int tableWidth = InputTable.Columns.Count;
                for (int i = tableHeight - 1; i >= 0; i--)
                {
                    int rowWastage = 0;
                    for (int j = 0; j < tableWidth; j++)
                    {
                        if (InputTable.Rows[i].ItemArray[j].ToString() == "")
                        {

                            rowWastage++;
                        }

                    }
                    if (rowWastage > (tableWidth / 2))
                    {
                        InputTable.Rows[i].Delete();
                    }
                }
            }
            else
            {
                MessageBox.Show("No data table has been opened yet");
            }
        }
        private void HeaderGuess()
        {

            List<string> unRecHeaders = new List<string>();
            HeaderRecgonition Hrec = new HeaderRecgonition();
            foreach (DataGridViewCell dCell in dataViewer.Rows[0].Cells)
            {
                if (Hrec.isHeaderInStandardFormat(dCell.Value.ToString()) == false)
                {

                    string guess = Hrec.RoughGuess(dCell.Value.ToString());
                    if (guess != dCell.Value.ToString())
                    {
                        if (guess != "")
                        {
                            DialogResult result = MessageBox.Show("Header '"+ dCell.Value.ToString()+"' was recognized as \"" + guess + "\"\n\rUse the recognized header?\n\r(If you click \"No\" the old header will be retained.", "Recognition made", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                InputTable.Rows[dCell.RowIndex][dCell.ColumnIndex] = guess;
                            }
                        }
                        else
                        {
                            unRecHeaders.Add(dCell.ColumnIndex.ToString());
                        }
                    }
                }
            }
            if (unRecHeaders.Count != 0)
            {
                string unRecWarning = "";
                unRecWarning = "Some columns have unrecognized headers\n\r";
                foreach (string colNum in unRecHeaders)
                {
                    unRecWarning += colNum + " ";
                }
                MessageBox.Show(unRecWarning, "Invalid Column Headers", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            for (int i = 0; i < dataViewer.Columns.Count; i++)
            {
                setBoxesFromGLEONCoding(i, dataViewer.Rows[0].Cells[i].Value.ToString());
            }

        }
        #endregion

        #region Initialization
        private void SwitchRows(DataTable dt, int i, int j)
        {
            object[] irow = dt.Rows[i].ItemArray;
            object[] jrow = dt.Rows[j].ItemArray;
            dt.Rows[i].ItemArray = jrow;
            dt.Rows[j].ItemArray = irow;
        }
        private void checkFoldersExist()
        {
            if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + @"\Control Files\"))
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + @"\Control Files\");
            if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + @"\Headers\"))
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + @"\Headers\");
            if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + @"\Meta\"))
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + @"\Meta\");
            if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + @"\Output\"))
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + @"\Output\");
                


        }
        private bool getAbbreviations()
        {
            int lineCount = 0;
            string line;
            string[] lineparts;
            string[] otherunits;
            GLEONCodeData = new List<testTypeUnits>();
            try
            {
                StreamReader reader = new StreamReader(System.Windows.Forms.Application.StartupPath+ @"\Control Files\ABBREVIATIONS.txt");

                while ((line = reader.ReadLine()) != null)
                {
                    lineCount++;
                    lineparts = line.Split('\t');
                    if (lineCount != 1)
                    {
                        string recUnit;
                        testTypeUnits units = new testTypeUnits();
                        units.possibleUnits = new List<string>();
                        units.testCode = lineparts[0];
                        units.testName = lineparts[1];
                        if (lineparts.Count() >= 3)
                            recUnit = lineparts[2];
                        else
                            recUnit = "";
                        units.RecommendedUnits = recUnit;
                        units.possibleUnits.Add(recUnit);
                        if (lineparts.Count() == 4)
                        {
                            otherunits = lineparts[3].Split(',');
                            for (int i = 0; i < otherunits.Count(); i++)
                            {
                                units.possibleUnits.Add(otherunits[i]);
                            }
                        }
                        GLEONCodeData.Add(units);
                    }

                }
                return true;
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.ToString());
                return false;
            }
        }

        public void getCountries()
        {
            string line;
            string[] lineparts;
            countriesData = new List<countryCodesTimes>();
            try
            {
                StreamReader reader = new StreamReader(System.Windows.Forms.Application.StartupPath + @"\Control Files\COUNTRY CODE.txt");

                while ((line = reader.ReadLine()) != null)
                {
                    countryCodesTimes newCountry = new countryCodesTimes();
                    newCountry.countryTimeZone = new List<string>();
                    lineparts = line.Split('\t');
                    if (lineparts.Count() >= 2)
                    {
                        newCountry.countryName = lineparts[1];
                        newCountry.countryCode = lineparts[0];
                        for (int i = 2; i <= (lineparts.Count() - 1); i++)
                        {
                            if (lineparts[i] != "")
                            {
                                newCountry.countryTimeZone.Add(lineparts[i]);
                            }
                        }
                        countriesData.Add(newCountry);
                        comboCountries.Items.Add(newCountry.countryName + " (" + newCountry.countryCode + ")");
                    }
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.ToString());
            }
        }
        public void getSiteNameSuggestions()
        {
            string line;
            try
            {
                if (File.Exists(System.Windows.Forms.Application.StartupPath+ @"\Control Files\SiteNameSuggestions.txt"))
                {
                    StreamReader reader = new StreamReader(System.Windows.Forms.Application.StartupPath + @"\Control Files\SiteNameSuggestions.txt");
                    siteNameSuggestions = new List<string>();
                    while ((line = reader.ReadLine()) != null)
                    {
                        siteNameSuggestions.Add(line);
                        comboSiteName.Items.Add(line);
                    }
                    comboSiteName.AutoCompleteMode = AutoCompleteMode.Suggest;
                    comboSiteName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    var siteSource = new AutoCompleteStringCollection();
                    siteSource.AddRange(siteNameSuggestions.ToArray());
                    comboSiteName.AutoCompleteCustomSource = siteSource;


                    
                }
                else
                {
                    File.Create(System.Windows.Forms.Application.StartupPath+ @"\Control Files\SiteNameSuggestions.txt");
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.ToString());
            }
        }
        public void setcomboEmpty()
        {
            comboEmpty.Items.Add("!Empty");
            comboEmpty.Items.Add("N/A");
            comboEmpty.Items.Add("#N/A");
            comboEmpty.Items.Add("(blank)");
            comboEmpty.Items.Add("na");
            comboEmpty.Items.Add("nan");
            comboEmpty.Items.Add("Nan");
        }
        #endregion

        #region Scrolling Horizontally
        private void panelVariableControls_Scroll(object sender, ScrollEventArgs e)
        {
            dataViewer.HorizontalScrollingOffset = panelVariableControls.HorizontalScroll.Value;
        }

        private void dataViewer_Scroll(object sender, ScrollEventArgs e)
        {
            panelVariableControls.HorizontalScroll.Value = dataViewer.HorizontalScrollingOffset;
        }
        #endregion

        #region HeaderControlsInPanel
        public void setVarBoxesInPanel()
        {
            panelVariableControls.Controls.Clear();
            int locationX = dataViewer.RowHeadersWidth;
            int colNum = 0;
            for (int i = 0; i <= dataViewer.Columns.Count - 1; i++)
            {
                int defaultWidth = dataViewer.Columns[colNum].Width;
                int defaultHeight = 21;
                int currentYLoc = 0;
                //Main comboBox
                string comboboxName = i + "ComboMain";
                ComboBox newCombo = new ComboBox();
                newCombo.Name = comboboxName;
                newCombo.Width = defaultWidth;
                newCombo.Height = defaultHeight;
                newCombo.Location = new Point(locationX, currentYLoc);
                currentYLoc += defaultHeight;
                newCombo.Items.Add("Variable");
                newCombo.Items.Add("DateTime");
                newCombo.Items.Add("Date");
                newCombo.Items.Add("Time");
                panelVariableControls.Controls.Add(newCombo);
                EventInfo comboMainChanged = newCombo.GetType().GetEvent("TextChanged");
                comboMainChanged.AddEventHandler(newCombo, new EventHandler(this.comboMainChanged));
                comboBoxes.Add(newCombo);

                //Secondary comboBox (Variable Name/DateTime format)
                comboboxName = i + "Combo2";
                ComboBox newCombo2 = new ComboBox();
                newCombo2.Name = comboboxName;
                newCombo2.Width = defaultWidth;
                newCombo2.Height = defaultHeight;
                newCombo2.Enabled = false;
                newCombo2.Location = new Point(locationX, currentYLoc);
                currentYLoc += defaultHeight;
                panelVariableControls.Controls.Add(newCombo2);
                EventInfo combo2Changed = newCombo2.GetType().GetEvent("TextChanged");
                combo2Changed.AddEventHandler(newCombo2, new EventHandler(this.combo2Changed));

                //3rd comboBox (Units)
                comboboxName = i + "Combo3";
                ComboBox newCombo3 = new ComboBox();
                newCombo3.Name = comboboxName;
                newCombo3.Width = defaultWidth;
                newCombo3.Height = defaultHeight;
                newCombo3.Enabled = false;
                newCombo3.Location = new Point(locationX, currentYLoc);
                currentYLoc += defaultHeight;
                panelVariableControls.Controls.Add(newCombo3);
                EventInfo combo3Changed = newCombo3.GetType().GetEvent("TextChanged");
                combo3Changed.AddEventHandler(newCombo3, new EventHandler(this.combo3Changed));

                //4th comboBox (Sensor Location Type)
                comboboxName = i + "Combo4";
                ComboBox newCombo4 = new ComboBox();
                newCombo4.Name = comboboxName;
                newCombo4.Width = defaultWidth;
                newCombo4.Height = defaultHeight;
                newCombo4.Enabled = false;
                newCombo4.Location = new Point(locationX, currentYLoc);
                newCombo4.Items.Add("d - Depth below surface");
                newCombo4.Items.Add("h - Height above surface");
                newCombo4.Items.Add("e - Elevation from bottom");
                newCombo4.Items.Add("m - Masl");
                newCombo4.Items.Add("i - Integrated depth range");
                newCombo4.Items.Add("v - Variable depth");
                newCombo4.Items.Add("n - Position NA");
                currentYLoc += defaultHeight;
                panelVariableControls.Controls.Add(newCombo4);
                EventInfo combo4Changed = newCombo4.GetType().GetEvent("TextChanged");
                combo4Changed.AddEventHandler(newCombo4, new EventHandler(this.combo4Changed));

                //TextBox (Sensor Displacement 1)
                comboboxName = i + "Text1";
                TextBox newCombo5 = new TextBox();
                newCombo5.Name = comboboxName;
                newCombo5.Width = defaultWidth;
                newCombo5.Height = defaultHeight;
                newCombo5.Enabled = false;
                newCombo5.Location = new Point(locationX, currentYLoc);
                currentYLoc += defaultHeight;
                panelVariableControls.Controls.Add(newCombo5);
                EventInfo Text1Changed = newCombo5.GetType().GetEvent("TextChanged");
                Text1Changed.AddEventHandler(newCombo5, new EventHandler(this.Text1Changed));

                //TextBox2 (Sensor Displacement 2)
                comboboxName = i + "Text2";
                TextBox newCombo6 = new TextBox();
                newCombo6.Name = comboboxName;
                newCombo6.Width = defaultWidth;
                newCombo6.Height = defaultHeight;
                newCombo6.Enabled = false;
                newCombo6.Location = new Point(locationX, currentYLoc);
                currentYLoc += defaultHeight;
                panelVariableControls.Controls.Add(newCombo6);
                EventInfo Text2Changed = newCombo6.GetType().GetEvent("TextChanged");
                Text2Changed.AddEventHandler(newCombo6, new EventHandler(this.Text2Changed));

                //Button (Accept new Header)
                comboboxName = i + "Btn";
                Button newButton = new Button();
                newButton.Name = comboboxName;
                newButton.Width = defaultWidth;
                newButton.Height = defaultHeight;
                newButton.Enabled = false;
                newButton.Location = new Point(locationX, currentYLoc);
                currentYLoc += defaultHeight;
                panelVariableControls.Controls.Add(newButton);
                EventInfo useNewHeaderClicked = newButton.GetType().GetEvent("Click");
                useNewHeaderClicked.AddEventHandler(newButton, new EventHandler(this.useNewHeaderClicked));
                EventInfo hoverNewHeaderButton = newButton.GetType().GetEvent("MouseHover");
                hoverNewHeaderButton.AddEventHandler(newButton, new EventHandler(this.hoverNewHeaderButton));

                locationX += defaultWidth;
                colNum++;
            }
        }
        private void autoDetectHeadersForPanel()
        {
            HeaderRecgonition hRec = new HeaderRecgonition();
            foreach(DataGridCell header in dataViewer.Rows[0].Cells)
            {
                    int index = Convert.ToInt16(header.ColumnNumber);
                    string comboMainName = index + "ComboMain";
                    Control comboMaintemp = panelVariableControls.Controls[comboMainName];
                    ComboBox comboMain = comboMaintemp as ComboBox;
                    string combo2Name = index + "Combo2";
                    Control combo2temp = panelVariableControls.Controls[combo2Name];
                    ComboBox combo2 = combo2temp as ComboBox;
                    string combo3Name = index + "Combo3";
                    Control combo3temp = panelVariableControls.Controls[combo3Name];
                    ComboBox combo3 = combo3temp as ComboBox;
                    string combo4Name = index + "Combo4";
                    Control combo4temp = panelVariableControls.Controls[combo4Name];
                    ComboBox combo4 = combo4temp as ComboBox;
                    string Text1Name = index + "Text1";
                    Control Text1temp = panelVariableControls.Controls[Text1Name];
                    TextBox Text1 = Text1temp as TextBox;
                    string Text2Name = index + "Text2";
                    Control Text2temp = panelVariableControls.Controls[Text2Name];
                    TextBox Text2 = Text2temp as TextBox;
                    if(hRec.getHeaderType(header.ToString()) == "DateTime")
                    {
                        comboMain.Text = "DateTime";
                    }
                    else if(hRec.getHeaderType(header.ToString()) == "dhem" || hRec.getHeaderType(header.ToString()) == "i" || hRec.getHeaderType(header.ToString()) == "vn")
                    {
                        comboMain.Text = "Variable";
                    }
            }
        }
        private void setBoxesFromGLEONCoding(int index, string input)
        {
            HeaderRecgonition hRec = new HeaderRecgonition();
            if(hRec.isHeaderInStandardVariableFormat(input))
            {
                string comboMainName = index + "ComboMain";
                Control comboMaintemp = panelVariableControls.Controls[comboMainName];
                ComboBox comboMain = comboMaintemp as ComboBox;
                string combo2Name = index + "Combo2";
                Control combo2temp = panelVariableControls.Controls[combo2Name];
                ComboBox combo2 = combo2temp as ComboBox;
                string combo3Name = index + "Combo3";
                Control combo3temp = panelVariableControls.Controls[combo3Name];
                ComboBox combo3 = combo3temp as ComboBox;
                string combo4Name = index + "Combo4";
                Control combo4temp = panelVariableControls.Controls[combo4Name];
                ComboBox combo4 = combo4temp as ComboBox;
                string Text1Name = index + "Text1";
                Control Text1temp = panelVariableControls.Controls[Text1Name];
                TextBox Text1 = Text1temp as TextBox;
                string Text2Name = index + "Text2";
                Control Text2temp = panelVariableControls.Controls[Text2Name];
                TextBox Text2 = Text2temp as TextBox;
                string temp = "";
                comboMain.Text = "Variable";
                foreach(testTypeUnits tTU in GLEONCodeData)
                {
                    if(tTU.testCode == input.Substring(0,input.IndexOf("_")))
                    {
                        combo2.Text = tTU.testName;
                    }
                }
                combo3.Text = input.Substring(input.IndexOf("(") + 1, (input.IndexOf(")") - (input.IndexOf("(") + 1)));
                foreach (string displacement in combo4.Items)
                {
                    if (input.Substring(input.IndexOf("_") + 1, 1) == displacement.Substring(0,1))
                    {
                        combo4.Text = displacement;
                        temp = input.Substring(input.IndexOf("_") + 1, 1);
                        if (hRec.getHeaderType(input) == "dhem")
                        {
                            Text1.Text = input.Substring(input.IndexOf(temp) + 1, input.IndexOf("(") - input.IndexOf(temp) + 1);
                        }
                        if(hRec.getHeaderType(input) == "i")
                        {
                            Text1.Text = input.Substring(input.IndexOf(temp) + 1, input.IndexOf("-") - input.IndexOf(temp) + 1);
                            Text2.Text = input.Substring(input.IndexOf("-") + 1, input.IndexOf("(") - input.IndexOf("-") + 1);
                        }

                    }
                }

                
            }
        }
        private void comboMainChanged(object sender, EventArgs e)
        {
            ComboBox comboChanged = sender as ComboBox;
            int index;
            index = Convert.ToInt16(comboChanged.Name.Substring(0, comboChanged.Name.IndexOf("C")));
            string combo2Name = index + "Combo2";
            Control combo2temp =panelVariableControls.Controls[combo2Name];
            ComboBox combo2 = combo2temp as ComboBox;
            string combo3Name = index + "Combo3";
            Control combo3temp = panelVariableControls.Controls[combo3Name];
            ComboBox combo3 = combo3temp as ComboBox;
            string combo4Name = index + "Combo4";
            Control combo4temp = panelVariableControls.Controls[combo4Name];
            ComboBox combo4 = combo4temp as ComboBox;
            string Text1Name = index + "Text1";
            Control Text1temp = panelVariableControls.Controls[Text1Name];
            TextBox Text1 = Text1temp as TextBox;
            string Text2Name = index + "Text2";
            Control Text2temp = panelVariableControls.Controls[Text2Name];
            TextBox Text2 = Text2temp as TextBox;
            combo2.Items.Clear();
            combo2.Text = "";
            combo3.Items.Clear();
            combo3.Text = "";
            combo3.Enabled = false;
            combo4.Items.Clear();
            combo4.Text = "";
            combo4.Enabled = false;
            Text1.Text = "";
            Text1.Enabled = false;
            Text2.Text = "";
            Text2.Enabled = false;

            if (comboChanged.Text == "Variable")
            {
                combo2.Enabled = true;
                combo3.Enabled = true;
                combo4.Enabled = true;
                foreach (testTypeUnits units in GLEONCodeData)
                {
                    combo2.Items.Add(units.testName);
                }
                combo2.Sorted = true;
                combo2.DropDownHeight = Screen.PrimaryScreen.Bounds.Height;
                combo4.Items.Add("d - Depth below surface");
                combo4.Items.Add("h - Height above surface");
                combo4.Items.Add("e - Elevation from bottom");
                combo4.Items.Add("m - Masl");
                combo4.Items.Add("i - Integrated depth range");
                combo4.Items.Add("v - Variable depth");
                combo4.Items.Add("n - Position NA");
            }
            else if (comboChanged.Text == "DateTime")
            {
                combo2.Enabled = true;
                combo2.Items.Add("UTC");
                combo2.Text = "UTC";
                combo3.Enabled = true;
                setAllOthersToVariableDateTime(index);
            }
            else if (comboChanged.Text == "Time")
            {
                combo2.Enabled = true;
                combo2.Items.Add("UTC");
                combo2.Text = "UTC";
                combo3.Enabled = true;
                setAllOthersToVariableDateAndTime();
            }
            else if (comboChanged.Text == "Date")
            {
                setAllOthersToVariableDateAndTime();
            }
            updateComboWidths(index);
            updateNewHeaderButton(index);
        }

        private void setAllOthersToVariableDateTime(int index)
        {
            for (int i = 0; i <= dataViewer.Columns.Count - 1; i++)
            {
                if (i != index)
                {
                    string comboToSetName = i + "ComboMain";
                    Control comboToSettemp = panelVariableControls.Controls[comboToSetName];
                    ComboBox comboToSet = comboToSettemp as ComboBox;
                    comboToSet.Text = "Variable";
                }
            }
        }
        private void setAllOthersToVariableDateAndTime()
        {
            int indexTime = -1;
            int indexDate = -1;
            for (int i = 0; i <= dataViewer.Columns.Count - 1; i++)
            {
                    string comboToCheckName = i + "ComboMain";
                    Control comboToChecktemp = panelVariableControls.Controls[comboToCheckName];
                    ComboBox comboToCheck = comboToChecktemp as ComboBox;
                    if (comboToCheck.Text == "Date")
                    {
                        if (indexDate == -1)
                        {
                            indexDate = i;
                        }
                        else
                        {
                            MessageBox.Show("More than one Date column is set");
                            return;
                        }
                    }
                    else if (comboToCheck.Text == "Time")
                    {
                        if (indexTime == -1)
                        {
                            indexTime = i;
                        }
                        else
                        {
                            MessageBox.Show("More than one Time column is set");
                            return;
                        }
                    }
            }
            if (indexDate != -1 && indexTime != -1)
            {
                for (int i = 0; i <= dataViewer.Columns.Count - 1; i++)
                {
                    if (i != indexDate && i != indexTime)
                    {
                        string comboToSetName = i + "ComboMain";
                        Control comboToSettemp = panelVariableControls.Controls[comboToSetName];
                        ComboBox comboToSet = comboToSettemp as ComboBox;
                        comboToSet.Text = "Variable";
                    }
                }
            }
        }
        private void combo2Changed(object sender, EventArgs e)
        {
            ComboBox comboChanged = sender as ComboBox;
            int index;
            index = Convert.ToInt16(comboChanged.Name.Substring(0, comboChanged.Name.IndexOf("C")));
            string combo1Name = index + "ComboMain";
            Control combo1temp = panelVariableControls.Controls[combo1Name];
            ComboBox combo1 = combo1temp as ComboBox;
            string combo3Name = index + "Combo3";
            Control combo3temp = panelVariableControls.Controls[combo3Name];
            ComboBox combo3 = combo3temp as ComboBox;
            combo3.Items.Clear();
            combo3.Text = "";
            if (comboChanged.Text == "")
            {
                string combo4Name = index + "Combo4";
                Control combo4temp = panelVariableControls.Controls[combo4Name];
                ComboBox combo4 = combo4temp as ComboBox;
                string Text1Name = index + "Text1";
                Control Text1temp = panelVariableControls.Controls[Text1Name];
                TextBox Text1 = Text1temp as TextBox;
                string Text2Name = index + "Text2";
                Control Text2temp = panelVariableControls.Controls[Text2Name];
                TextBox Text2 = Text2temp as TextBox;
                combo4.Items.Clear();
                combo4.Text = "";
                Text1.Text = "";
                Text1.Enabled = false;
                Text2.Text = "";
                Text2.Enabled = false;
            }
            else if (combo1.Text == "Variable")
            {
                foreach (testTypeUnits GLEON in GLEONCodeData)
                {
                    if (GLEON.testName == comboChanged.Text)
                    {
                        foreach (string newUnits in GLEON.possibleUnits)
                        {
                            combo3.Items.Add(newUnits);
                        }
                        combo3.Text = GLEON.RecommendedUnits;
                    }
                }
            }
            else if (combo1.Text == "DateTime" || combo1.Text == "Time")
            {
                if (comboCountries.Text != "" && comboChanged.Text == "UTC")
                {
                    combo3.Enabled = true;
                    string countryCode = Regex.Match(comboCountries.Text, @"\(([^)]*)\)").Groups[1].Value;
                    foreach (countryCodesTimes testCountry in countriesData)
                    {
                        if (testCountry.countryCode == countryCode)
                        {
                            foreach (string timeZone in testCountry.countryTimeZone)
                            {
                                combo3.Items.Add(timeZone);
                            }

                        }
                    }
                    if (combo3.Items.Count == 1)
                    {
                        combo3.Text = combo3.Items[0].ToString();
                    }
                }
            }
            updateComboWidths(index);
            updateNewHeaderButton(index);
        }
        private void combo3Changed(object sender, EventArgs e)
        {
            ComboBox comboChanged = sender as ComboBox;
            int index = Convert.ToInt16(comboChanged.Name.Substring(0, comboChanged.Name.IndexOf("C")));
            updateComboWidths(index);
            updateNewHeaderButton(index);
        }
        private void combo4Changed(object sender, EventArgs e)
        {
            ComboBox comboChanged = sender as ComboBox;
            int index;
            index = index = Convert.ToInt16(comboChanged.Name.Substring(0, comboChanged.Name.IndexOf("C")));
            if (comboChanged.Text.Length > 0)
            {
                string sensorLocationIndicator = comboChanged.Text.Substring(0, 1);
                string Text1Name = index + "Text1";
                Control Text1temp = panelVariableControls.Controls[Text1Name];
                TextBox Text1 = Text1temp as TextBox;
                string Text2Name = index + "Text2";
                Control Text2temp = panelVariableControls.Controls[Text2Name];
                TextBox Text2 = Text2temp as TextBox;

                if (sensorLocationIndicator == "d" || sensorLocationIndicator == "h" || sensorLocationIndicator == "e" || sensorLocationIndicator == "m")
                {
                    Text1.Enabled = true;
                    Text2.Enabled = false;
                }
                else if (sensorLocationIndicator == "i")
                {
                    Text1.Enabled = true;
                    Text2.Enabled = true;
                }
                else if (sensorLocationIndicator == "v" || sensorLocationIndicator == "n")
                {
                    Text1.Enabled = false;
                    Text2.Enabled = false;
                }
            }
            updateComboWidths(index);
            updateNewHeaderButton(index);
        }
        private void Text1Changed(object sender, EventArgs e)
        {
            string outString = "";
            TextBox textChanged = sender as TextBox;
            foreach (Char input in textChanged.Text)
            {
                if ((input < '0' || input > '9') && input != '.')
                    textChanged.Text.Replace(input, '\0');
                else
                    outString += input;
            }
            textChanged.Text = outString;
            textChanged.SelectionStart = textChanged.Text.Length;
            updateNewHeaderButton(Convert.ToInt32(textChanged.Name.Substring(0, textChanged.Name.IndexOf("T"))));
        }
        private void Text2Changed(object sender, EventArgs e)
        {
            string outString = "";
            TextBox textChanged = sender as TextBox;
            foreach (Char input in textChanged.Text)
            {
                if ((input < '0' || input > '9') && input != '.')
                    textChanged.Text.Replace(input, '\0');
                else
                    outString += input;
            }
            textChanged.Text = outString;
            textChanged.SelectionStart = textChanged.Text.Length;
            updateNewHeaderButton(Convert.ToInt32(textChanged.Name.Substring(0, textChanged.Name.IndexOf("T"))));
        }

        private void updateComboWidths(int index)
        {
            string combo1Name = index + "ComboMain";
            Control combo1temp = panelVariableControls.Controls[combo1Name];
            ComboBox combo1 = combo1temp as ComboBox;
            string combo2Name = index + "Combo2";
            Control combo2temp = panelVariableControls.Controls[combo2Name];
            ComboBox combo2 = combo2temp as ComboBox;
            string combo3Name = index + "Combo3";
            Control combo3temp = panelVariableControls.Controls[combo3Name];
            ComboBox combo3 = combo3temp as ComboBox;
            string combo4Name = index + "Combo4";
            Control combo4temp = panelVariableControls.Controls[combo4Name];
            ComboBox combo4 = combo4temp as ComboBox;

            Graphics g1 = combo1.CreateGraphics();
            Graphics g2 = combo2.CreateGraphics();
            Graphics g3 = combo3.CreateGraphics();
            Graphics g4 = combo4.CreateGraphics();
            int ddWidth1 = combo1.DropDownWidth;
            int ddWidth2 = combo2.DropDownWidth;
            int ddWidth3 = combo3.DropDownWidth;
            int ddWidth4 = combo4.DropDownWidth;

            int vertScrollBarWidth = (combo1.Items.Count > combo1.MaxDropDownItems)? SystemInformation.VerticalScrollBarWidth : 0;
            int newWidth = 0;

            foreach (string s in combo1.Items)
            {
                newWidth = (int)g1.MeasureString(s, combo1.Font).Width + vertScrollBarWidth;
                if (ddWidth1 < newWidth)
                {
                    ddWidth1 = newWidth;
                } 

            }
            combo1.DropDownWidth = ddWidth1;

            newWidth = 0;
            foreach (string s in combo2.Items)
            {
                newWidth = (int)g2.MeasureString(s, combo2.Font).Width + vertScrollBarWidth;
                if (ddWidth2 < newWidth)
                {
                    ddWidth2 = newWidth;
                }

            }
            combo2.DropDownWidth = ddWidth2;

            newWidth = 0;
            foreach (string s in combo3.Items)
            {
                newWidth = (int)g3.MeasureString(s, combo3.Font).Width + vertScrollBarWidth;
                if (ddWidth3 < newWidth)
                {
                    ddWidth3 = newWidth;
                }

            }
            combo3.DropDownWidth = ddWidth3;

            newWidth = 0;
            foreach (string s in combo4.Items)
            {
                newWidth = (int)g4.MeasureString(s, combo4.Font).Width + vertScrollBarWidth;
                if (ddWidth4 < newWidth)
                {
                    ddWidth4 = newWidth;
                }

            }
            combo4.DropDownWidth = ddWidth4;
        }
        private void useNewHeaderClicked(object sender, EventArgs e)
        {
            if (HeaderSelected)
            {
                Button btnClicked = sender as Button;
                int index = Convert.ToInt32(btnClicked.Name.Substring(0, 1));
                InputTable.Rows[0][index] = btnClicked.Text;
                if(Regex.IsMatch(btnClicked.Text,@"DateTime[a-z,A-Z]{3}[\+,\-][[0]?[1-9]|1[0-4]](:[1,3,4][0,5])?"))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    standardizeDateColumn();
                    getStartEndDates();
                    Cursor.Current = Cursors.Default;
                }
            }
            else
                MessageBox.Show("You cannot edit header values until a header row has been selected.");
        }
        private void updateNewHeaderButton(int colNum)
        {
            string comboMainName = colNum + "ComboMain";
            Control comboMaintemp = panelVariableControls.Controls[comboMainName];
            ComboBox comboMain = comboMaintemp as ComboBox;
            string combo2Name = colNum + "Combo2";
            Control combo2temp = panelVariableControls.Controls[combo2Name];
            ComboBox combo2 = combo2temp as ComboBox;
            string combo3Name = colNum + "Combo3";
            Control combo3temp = panelVariableControls.Controls[combo3Name];
            ComboBox combo3 = combo3temp as ComboBox;
            string combo4Name = colNum + "Combo4";
            Control combo4temp = panelVariableControls.Controls[combo4Name];
            ComboBox combo4 = combo4temp as ComboBox;
            string Text1Name = colNum + "Text1";
            Control Text1temp = panelVariableControls.Controls[Text1Name];
            TextBox Text1 = Text1temp as TextBox;
            string Text2Name = colNum + "Text2";
            Control Text2temp = panelVariableControls.Controls[Text2Name];
            TextBox Text2 = Text2temp as TextBox;
            string ButtonName = colNum + "Btn";
            Control ButtonTemp = panelVariableControls.Controls[ButtonName];
            Button ButtonNewHeader = ButtonTemp as Button;
            if (comboMain.Text == "Variable")
            {
                string testName = "";
                foreach (testTypeUnits testType in GLEONCodeData)
                {
                    if (testType.testName == combo2.Text)
                    {
                        testName = testType.testCode;
                    }
                }
                string units = combo3.Text;
                string locationIndicator = combo4.Text;
                if (locationIndicator != "")
                    locationIndicator = combo4.Text.Substring(0, 1);
                string sensorD1 = Text1.Text;
                string sensorD2 = Text2.Text;
                switch (locationIndicator)
                {
                    case "d":
                        ButtonNewHeader.Text = testName + "_" + locationIndicator + sensorD1;
                        if (testName != ""  && locationIndicator != "" && sensorD1 != "")
                            ButtonNewHeader.Enabled = true;
                        else
                            ButtonNewHeader.Enabled = false;
                        break;
                    case "h":
                        ButtonNewHeader.Text = testName + "_" + locationIndicator + sensorD1;
                        if (testName != ""  && locationIndicator != "" && sensorD1 != "")
                            ButtonNewHeader.Enabled = true;
                        else
                            ButtonNewHeader.Enabled = false;
                        break;
                    case "e":
                        ButtonNewHeader.Text = testName + "_" + locationIndicator + sensorD1;
                        if (testName != ""  && locationIndicator != "" && sensorD1 != "")
                            ButtonNewHeader.Enabled = true;
                        else
                            ButtonNewHeader.Enabled = false;
                        break;
                    case "m":
                        ButtonNewHeader.Text = testName + "_" + locationIndicator + sensorD1;
                        if (testName != ""  && locationIndicator != "" && sensorD1 != "")
                            ButtonNewHeader.Enabled = true;
                        else
                            ButtonNewHeader.Enabled = false;
                        break;
                    case "i":
                        ButtonNewHeader.Text = testName + "_" + locationIndicator + sensorD1 + "-" + sensorD2;
                        if (testName != ""  && locationIndicator != "" && sensorD1 != "" && sensorD2 != "")
                            ButtonNewHeader.Enabled = true;
                        else
                            ButtonNewHeader.Enabled = false;
                        break;
                    case "v":
                        ButtonNewHeader.Text = testName + "_" + locationIndicator;
                        if (testName != ""  && locationIndicator != "")
                            ButtonNewHeader.Enabled = true;
                        else
                            ButtonNewHeader.Enabled = false;
                        break;
                    case "n":
                        ButtonNewHeader.Text = testName + "_" + locationIndicator;
                        if (testName != ""  && locationIndicator != "")
                            ButtonNewHeader.Enabled = true;
                        else
                            ButtonNewHeader.Enabled = false;
                        break;
                    default:
                        ButtonNewHeader.Text = testName + "_" + locationIndicator + sensorD1;
                        ButtonNewHeader.Enabled = false;
                        break;
                }
                if (units != "")
                {
                    ButtonNewHeader.Text += "(" + units + ")";
                }
            }
            else if (comboMain.Text == "DateTime")
            {
                ButtonNewHeader.Text = "DateTime" + combo2.Text+ combo3.Text;
                if (Regex.IsMatch(ButtonNewHeader.Text, @"DateTime[a-z,A-Z]{3}[\+,\-][[0]?[1-9]|1[0-4]](:[1,3,4][0,5])?"))
                {
                    ButtonNewHeader.Enabled = true;
                }
                else
                {
                    ButtonNewHeader.Enabled = false;
                }
            }
            else if (comboMain.Text == "Time")
            {
                ButtonNewHeader.Text = "Time" + combo2.Text + combo3.Text;
                if (Regex.IsMatch(ButtonNewHeader.Text, @"Time[a-z,A-Z]{3}[\+,\-][[0]?[1-9]|1[0-4]](:[1,3,4][0,5])?"))
                {
                    ButtonNewHeader.Enabled = true;
                }
                else
                {
                    ButtonNewHeader.Enabled = false;
                }
            }
            else if (comboMain.Text == "Date")
            {
                ButtonNewHeader.Text = "Date";
                ButtonNewHeader.Enabled = true;
            }


        }
        private void hoverNewHeaderButton(object sender, EventArgs e)
        {
            Button ButtonNewHeader = sender as Button;
            ToolTip btnToolTip = new ToolTip();
            btnToolTip.SetToolTip(ButtonNewHeader, ButtonNewHeader.Text);
        }
        #endregion

        #region Menu Strip
        private void convertDatesToStandardFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InputTable == null)
                MessageBox.Show("You have not opened a valid Datatable yet", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            standardizeDateColumn();
        }

        private void headerGuessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InputTable == null)
                MessageBox.Show("You have not opened a valid Datatable yet", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            HeaderGuess();
        }

        private void openSiteInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (, System.Windows.Forms.Application.StartupPath + @"\Meta\") != null)
            //{
            openMeta(getFiletoRead("Meta Files (*.meta)| *.meta", System.Windows.Forms.Application.StartupPath));
            //}
        }
        #endregion
        #region dataViewer

        private void dataViewer_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int colNum = e.Column.Index;
            string comboMainName = colNum + "ComboMain";
            Control comboMaintemp = panelVariableControls.Controls[comboMainName];
            ComboBox comboMain = comboMaintemp as ComboBox;
            int locationX = comboMain.Location.X;
            for (int i = colNum; i <= dataViewer.Columns.Count - 1; i++)
            {
                comboMainName = i + "ComboMain";
                comboMaintemp = panelVariableControls.Controls[comboMainName];
                comboMain = comboMaintemp as ComboBox;
                string combo2Name = i + "Combo2";
                Control combo2temp = panelVariableControls.Controls[combo2Name];
                ComboBox combo2 = combo2temp as ComboBox;
                string combo3Name = i + "Combo3";
                Control combo3temp = panelVariableControls.Controls[combo3Name];
                ComboBox combo3 = combo3temp as ComboBox;
                string combo4Name = i + "Combo4";
                Control combo4temp = panelVariableControls.Controls[combo4Name];
                ComboBox combo4 = combo4temp as ComboBox;
                string Text1Name = i + "Text1";
                Control Text1temp = panelVariableControls.Controls[Text1Name];
                TextBox Text1 = Text1temp as TextBox;
                string Text2Name = i + "Text2";
                Control Text2temp = panelVariableControls.Controls[Text2Name];
                TextBox Text2 = Text2temp as TextBox;
                string BtnName = i + "Btn";
                Control Btntemp = panelVariableControls.Controls[BtnName];
                Button Btn = Btntemp as Button;

                comboMain.Location = new Point (locationX,comboMain.Location.Y);
                combo2.Location = new Point(locationX, combo2.Location.Y);
                combo3.Location = new Point(locationX, combo3.Location.Y);
                combo4.Location = new Point(locationX, combo4.Location.Y);
                Text1.Location = new Point(locationX, Text1.Location.Y);
                Text2.Location = new Point(locationX, Text2.Location.Y);
                Btn.Location = new Point(locationX, Btn.Location.Y);
                comboMain.Width = dataViewer.Columns[i].Width;
                combo2.Width = dataViewer.Columns[i].Width;
                combo3.Width = dataViewer.Columns[i].Width;
                combo4.Width = dataViewer.Columns[i].Width;
                Text1.Width = dataViewer.Columns[i].Width;
                Text2.Width = dataViewer.Columns[i].Width;
                Btn.Width = dataViewer.Columns[i].Width;

                locationX += dataViewer.Columns[i].Width;
            }
            
        }
        private void dataViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dataViewer.SelectedRows.Count >= 1)
                {
                    DialogResult result = MessageBox.Show("WARNING: You have attempted to delete one or more rows, deleting rows is permanent and cannot be undone.\n\r\n\rAre you sure you wish to make this deletion?", "Deleting rows warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow dRow in dataViewer.SelectedRows)
                        {
                            InputTable.Rows[dRow.Index].Delete();
                        }
                    }
                }
                else if (dataViewer.SelectedColumns.Count >= 1)
                {
                        DialogResult result = MessageBox.Show("WARNING: You have attempted to delete one or more columns, deleting rows is permanent and cannot be undone.\n\r\n\rAre you sure you wish to make this deletion?", "Deleting rows warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.Yes)
                        {
                            foreach (DataGridViewColumn dCol in dataViewer.SelectedColumns)
                            {
                                InputTable.Columns.RemoveAt(dCol.Index) ;
                                setVarBoxesInPanel();
                            }
                        }
                }
                else if (dataViewer.SelectedRows.Count == 0)
                    MessageBox.Show("You must select atleast one row or column to delete.");
            }
        }
        private void resetColumnNames()
        {
            int index = 0;
            foreach( DataGridViewColumn dCol in dataViewer.Columns)
            {
                dCol.HeaderText = index.ToString();
                dCol.Name = index.ToString();
                index++;
            }
        }
        #endregion

        #region Saving
        private void btnExport_Click(object sender, EventArgs e)
        {
            string siteName = comboSiteName.Text;
            string countryCode = Regex.Match(comboCountries.Text, @"\(([^)]*)\)").Groups[1].Value;
            string startDate = dateTimeAggregateStart.Value.ToString("yyyyMM");
            string endDate = dateTimeAggregateEnd.Value.ToString("yyyyMM");
            string fileExtension = comboFileExtension.Text;
            if (InputTable == null)
                MessageBox.Show("You have not opened a valid Datatable yet", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (siteName == "")
                MessageBox.Show("Please enter a Site Name", "Invalid Metadata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (countryCode.Length != 2)
                MessageBox.Show("Country format is invalid.\n\rPlease enter a valid Country and Country code in the format:.\n\r\"Country (CountryCode)\" or just \"(CountryCode)\"\n\rCountry Codes may only be 2 letters", "Invalid Metadata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (Convert.ToInt32(endDate) < Convert.ToInt32(startDate))
                MessageBox.Show("End date is earlier than start date.", "Invalid Metadata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (fileExtension == "")
                MessageBox.Show("Please enter a file extension", "Invalid Metadata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (HeaderSelected == false)
                MessageBox.Show("Please select a header row.\n\rThis is to guarantee the header row you want is used.","", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (wasteCheck())
                MessageBox.Show("Some of your rows have been detected as 'waste rows'.\n\rYou can clear these rows by using the 'Strip Metadata button'.","Your table contains waste rows" ,MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (checkData.Checked == true)
                {
                    if (checkExportEmpty.Checked)
                    {
                        FillMissingRows();
                    }
                    string fileName;
                    if (txtFileNameAppend.Text == "")
                    {
                        fileName = @"Output\" + siteName + "(" + countryCode + ")_" + startDate + "-" + endDate +fileExtension;
                    }
                    else
                    {
                        fileName = @"Output\" + siteName + "(" + countryCode + ")_" + startDate + "-" + endDate + "_" + txtFileNameAppend.Text + fileExtension;
                    }
                    if (File.Exists(fileName))
                    {
                        DialogResult result = MessageBox.Show("File \"" + fileName + "\" already exists.\n\rDo you want to overwrite this file?", "File already exists", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.Yes)
                        {
                            saveOutput(fileName);
                        }
                    }
                    else
                        saveOutput(fileName);
                }
                if (checkMeta.Checked == true)
                {
                    string fileName = siteName + "(" + countryCode + ").meta";
                    MessageBox.Show(fileName);
                    if (File.Exists(@"Meta\" + fileName))
                    {
                        DialogResult result = MessageBox.Show("File \"" + fileName + "\" already exists.\n\rDo you want to overwrite this file?", "File already exists", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.Yes)
                        {
                            saveMeta();
                        }
                    }
                    else
                        saveMeta();
                }
            }
            
        }
        public void FillMissingRows()
        {
            int numDateTimeCols = 0;
            int dateTimeColNum = -1;
            foreach (DataGridViewCell dCell in dataViewer.Rows[0].Cells)
            {
                if (dCell.Value.ToString().Length >= 8 && dCell.Value.ToString().Substring(0, 8) == "DateTime")
                {
                    numDateTimeCols++;
                    dateTimeColNum = dCell.ColumnIndex;
                }
            }
            if (numDateTimeCols == 1)
            {
                List <TimeSpan> DataCollectTimeDifference = new List<TimeSpan>();
                for (int i = 1; i < dataViewer.Rows.Count -1; i++)
                {
                    DataCollectTimeDifference.Add(Convert.ToDateTime(dataViewer.Rows[i + 1].Cells[dateTimeColNum].Value.ToString()) - Convert.ToDateTime(dataViewer.Rows[i].Cells[dateTimeColNum].Value.ToString()));
                }
                TimeSpan mostCommon = mostCommonTimeSpanInList(DataCollectTimeDifference);
                int currentRow = 1;
                for (DateTime currentTime = startDate; currentTime < endDate;currentTime = currentTime.Add(mostCommon))
                {
                    while (Convert.ToDateTime(InputTable.Rows[currentRow].ItemArray[dateTimeColNum].ToString()) < currentTime)
                    {
                        currentRow++;
                    }
                    if(Convert.ToDateTime(InputTable.Rows[currentRow].ItemArray[dateTimeColNum].ToString()) != currentTime)
                    {
                        DataRow tempRow = InputTable.NewRow();
                        for(int i =0; i < InputTable.Columns.Count ; i ++)
                        {
                            tempRow[i] = blankPhrase;
                        }
                        tempRow[dateTimeColNum] = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
                        InputTable.Rows.InsertAt(tempRow, currentRow);
                    }
                }
            }
            else
            {
                MessageBox.Show("No DateTime column found.");
            }
            
        }
        public TimeSpan mostCommonTimeSpanInList(List <TimeSpan> timeSpanList)
        {
            var Counter = from s in timeSpanList group s by s into g select new { Item = g.Key, Count = g.Count() };
            var groupsSorted = Counter.OrderByDescending(g => g.Count);
            return (groupsSorted.First().Item);
        }

        /// <summary>
        /// Checks if there are any rows that would be considered to be 'waste'.
        /// A row of waste is anything with less than half its cells containing items.
        /// </summary>
        /// <returns>
        /// True if there are any rows containing waste.
        /// False if there are no waste rows.
        /// </returns>
        public bool wasteCheck()
        {
            int tableHeight = InputTable.Rows.Count;
            int tableWidth = InputTable.Columns.Count;
            for (int i = tableHeight - 1; i >= 0; i--)
            {
                int rowWastage = 0;
                for (int j = 0; j < tableWidth; j++)
                {
                    if (InputTable.Rows[i].ItemArray[j].ToString() == "")
                    {
                        rowWastage++;
                    }

                }
                if (rowWastage > (tableWidth / 2))
                {
                    return true;
                }
            }
            return false;
        }

        public void saveOutput(string fileName)
        {
            HeaderRecgonition hRec = new HeaderRecgonition();
                bool headersFormatedCorrectly = true;
                foreach (DataGridViewCell dCell in dataViewer.Rows[0].Cells)
                {
                    if (hRec.isHeaderInStandardFormat(dCell.Value.ToString()) != true)
                    {
                        headersFormatedCorrectly = false;
                    }
                }
                if (headersFormatedCorrectly)
                {
                        saveDataSetNotes(fileName);
                        switch (comboFileExtension.Text)
                        {
                            case (".wtr"):
                                saveWater(fileName);
                                break;
                            case (".wnd"):
                                saveWind(fileName);
                                break;
                            case (".sal"):
                                saveSalinity(fileName);
                                break;
                            case(".csv"):
                                saveCSV(fileName);
                                break;
                            default:
                                saveStandard(fileName);
                                break;
                        }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Some of your headers appear to be incorrectly formatted.\n\rDo you wish to save anyway?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        saveDataSetNotes(fileName);
                        switch (comboFileExtension.Text)
                        {
                            case (".wtr"):
                                saveWater(fileName);
                                break;
                            case (".wnd"):
                                saveWind(fileName);
                                break;
                            case (".sal"):
                                saveSalinity(fileName);
                                break;
                            case (".csv"):
                                saveCSV(fileName);
                                break;
                            default:
                                saveStandard(fileName);
                                break;
                        }
                    }
                }

                    
        }

        private void saveSiteNameSuggestions()
        {
            try
            {
                StreamWriter writer = File.AppendText(@"Control Files\SiteNameSuggestions.txt");
                writer.WriteLine(comboSiteName.Text);
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.ToString());
            }
        }

        /// <summary>
        /// Performs the standard save procedure, saving all columns.
        /// Tab delimited.
        /// </summary>
        /// <param name="fileName">The passed in string will be the resulting files name and extension.</param>
        private void saveStandard(string fileName)
        {
            string line;
            int timeColumn = -1;
            foreach (DataGridViewCell dCell in dataViewer.Rows[0].Cells)
            {
                if (dCell.Value.ToString().Contains("DateTime"))
                {
                    timeColumn = dCell.ColumnIndex;
                }
            }
            if (timeColumn != -1)
            {
                    using (StreamWriter sWriter = new StreamWriter(fileName))
                    {
                        foreach (DataGridViewRow dRow in dataViewer.Rows)
                        {
                            line = "";
                            foreach (DataGridViewCell dCell in dRow.Cells)
                            {
                                //Get time value for row.
                                if (dCell.ColumnIndex == timeColumn)
                                {
                                    line += dCell.Value;
                                }
                            }
                            foreach (DataGridViewCell dCell in dRow.Cells)
                            {
                                //Get all non-time values for row.
                                if (dCell.ColumnIndex != timeColumn)
                                {
                                    line += "\t" + dCell.Value;
                                }
                            }
                            sWriter.WriteLine(line);
                        }
                        MessageBox.Show("File saved");
                    }
            }
            else
                MessageBox.Show("Time Column not found");
        }
        /// <summary>
        /// Save file in comma delimited
        /// </summary>
        /// <param name="fileName"></param>
        private void saveCSV(string fileName)
        {
            string line;
            int timeColumn = -1;
            foreach (DataGridViewCell dCell in dataViewer.Rows[0].Cells)
            {
                if (dCell.Value.ToString().Contains("DateTime"))
                {
                    timeColumn = dCell.ColumnIndex;
                }
            }
            if (timeColumn != -1)
            {
                using (StreamWriter sWriter = new StreamWriter(fileName))
                {
                    foreach (DataGridViewRow dRow in dataViewer.Rows)
                    {
                        line = "";
                        foreach (DataGridViewCell dCell in dRow.Cells)
                        {
                            //Get time value for row.
                            if (dCell.ColumnIndex == timeColumn)
                            {
                                if(dRow.Index == 0)//Temp fix until B3 can be upgraded
                                    line = "DD/MM/YYYY hh:mm";
                                else
                                    line = dCell.Value.ToString();
                            }
                        }
                        foreach (DataGridViewCell dCell in dRow.Cells)
                        {
                            //Get all non-time values for row.
                            if (dCell.ColumnIndex != timeColumn)
                            {
                                line += "," + dCell.Value.ToString();
                            }
                        }
                        sWriter.WriteLine(line);
                    }
                    MessageBox.Show("File saved");
                }
            }
            else
                MessageBox.Show("Time Column not found");
        }
        /// <summary>
        /// Performs the WaterTemperature save procedure, saving only water temperature and date columns.
        /// Tab delimited.
        /// </summary>
        /// <param name="fileName">The passed in string will be the resulting files name and extension.</param>
        private void saveWater(string fileName)
        {
            List<int> includedColumns = new List<int>();
            int timeColumn = -1;
            string line;
            foreach (DataGridViewCell dCell in dataViewer.Rows[0].Cells)
            {
                if(dCell.Value.ToString().Contains("DateTime"))
                {
                    timeColumn = dCell.ColumnIndex;
                }
                if (dCell.Value.ToString().Contains("TmpWtr"))
                {
                    includedColumns.Add(dCell.ColumnIndex);
                }
            }
            if (timeColumn != -1)
            {
                if (includedColumns.Count != 0)
                {
                    using (StreamWriter sWriter = new StreamWriter(fileName))
                    {
                        foreach (DataGridViewRow dRow in dataViewer.Rows)
                        {
                            line = "";
                            foreach (DataGridViewCell dCell in dRow.Cells)
                            {
                                //Get time value for row.
                                if (dCell.ColumnIndex == timeColumn)
                                {
                                        line += dCell.Value.ToString();
                                }
                            }
                            foreach (DataGridViewCell dCell in dRow.Cells)
                            {
                                //Get water temp values for row.
                                if (includedColumns.Contains(dCell.ColumnIndex))
                                {
                                    line += "\t" + dCell.Value;
                                }
                            }
                            sWriter.WriteLine(line);
                        }
                        MessageBox.Show("Data file saved");
                    }
                }
                else
                    MessageBox.Show("No Water Temperature columns were found.");
            }
            else
                MessageBox.Show("Time Column not found");
        }
        /// <summary>
        /// Performs the WindSpeed save procedure, saving only wind speed and date columns.
        /// Tab delimited.
        /// </summary>
        /// <param name="fileName">The passed in string will be the resulting files name and extension.</param>
        private void saveWind(string fileName)
        {
            List<int> includedColumns = new List<int>();
            int timeColumn = -1;
            string line;
            foreach (DataGridViewCell dCell in dataViewer.Rows[0].Cells)
            {
                if (dCell.Value.ToString().Contains("DateTime"))
                {
                    timeColumn = dCell.ColumnIndex;
                }
                if (dCell.Value.ToString().Contains("WndSpd"))
                {
                    includedColumns.Add(dCell.ColumnIndex);
                }
            }
            if (timeColumn != -1)
            {
                if (includedColumns.Count != 0)
                {
                    using (StreamWriter sWriter = new StreamWriter(fileName))
                    {
                        foreach (DataGridViewRow dRow in dataViewer.Rows)
                        {
                            line = "";
                            foreach (DataGridViewCell dCell in dRow.Cells)
                            {
                                //Get time value for row.
                                if (dCell.ColumnIndex == timeColumn)
                                {
                                    line += dCell.Value;
                                }
                            }
                            foreach (DataGridViewCell dCell in dRow.Cells)
                            {
                                //Get wind speed values for row.
                                if (includedColumns.Contains(dCell.ColumnIndex))
                                {
                                    line += "\t" + dCell.Value;
                                }
                            }
                            sWriter.WriteLine(line);
                        }
                        MessageBox.Show("Data file saved");
                    }
                }
                else
                    MessageBox.Show("No Wind Speed columns were found.");
            }
            else
                MessageBox.Show("Time Column not found");
        }
        /// <summary>
        /// Performs the Salinity save procedure, saving only salinity and date columns.
        /// Tab delimited.
        /// </summary>
        /// <param name="fileName">The passed in string will be the resulting files name and extension.</param>
        private void saveSalinity(string fileName)
        {
            List<int> includedColumns = new List<int>();
            int timeColumn = -1;
            string line;
            foreach (DataGridViewCell dCell in dataViewer.Rows[0].Cells)
            {
                if (dCell.Value.ToString().Contains("DateTime"))
                {
                    timeColumn = dCell.ColumnIndex;
                }
                if (dCell.Value.ToString().Contains("Sal"))
                {
                    includedColumns.Add(dCell.ColumnIndex);
                }
            }
            if (timeColumn != -1)
            {
                if (includedColumns.Count != 0)
                {
                    using (StreamWriter sWriter = new StreamWriter(fileName))
                    {
                        foreach (DataGridViewRow dRow in dataViewer.Rows)
                        {
                            line = "";
                            foreach (DataGridViewCell dCell in dRow.Cells)
                            {
                                //Get time value for row.
                                if (dCell.ColumnIndex == timeColumn)
                                {
                                    line += dCell.Value;
                                }
                            }
                            foreach (DataGridViewCell dCell in dRow.Cells)
                            {
                                //Get salinity values for row.
                                if (includedColumns.Contains(dCell.ColumnIndex))
                                {
                                    line += "\t" + dCell.Value;
                                }
                            }
                            sWriter.WriteLine(line);
                        }
                        MessageBox.Show("Data file saved");
                    }
                }
                else
                    MessageBox.Show("No Salinity columns were found.");
            }
            else
                MessageBox.Show("Time Column not found");
        }
        private void saveMeta()
        {
            using (StreamWriter sWriter = new StreamWriter(@"Meta\" + comboSiteName.Text + ".meta"))
            {
                sWriter.WriteLine(sitePropOwnerName);
                sWriter.WriteLine(sitePropContactName);
                sWriter.WriteLine(sitePropContactNumber);
                sWriter.WriteLine(sitePropContactEmail);
                sWriter.WriteLine(sitePropElevation);
                sWriter.WriteLine(sitePropGPSLat.ToString());
                sWriter.WriteLine(sitePropGPSLong.ToString());
                sWriter.WriteLine(sitePropNotes);
                sWriter.Close();
            }
        }
        private void saveDataSetNotes(string fileName)
        {
            using (StreamWriter sWriter = new StreamWriter(fileName.Substring(0, fileName.IndexOf('.')) + ".notes"))
            {
                sWriter.WriteLine(txtDataSetNotes.Text);
            }
        }
#endregion

        #region Site MetaData
        public string sitePropSiteName, sitePropOwnerName, sitePropContactName, sitePropContactNumber, sitePropGPSGrid, sitePropName, sitePropContactEmail, sitePropElevation, sitePropNotes, sitePropGPSLat, sitePropGPSLong;

        private void comboFileExtension_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateFileNameLabel();
        }
        private void comboSiteName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\Meta\" + comboSiteName.Text + ".meta"))
                {
                    StreamReader reader = new StreamReader(System.Windows.Forms.Application.StartupPath + @"\Meta\" + comboSiteName.Text + ".meta");
                    sitePropOwnerName = reader.ReadLine();
                    sitePropContactName = reader.ReadLine();
                    sitePropContactNumber = reader.ReadLine();
                    sitePropElevation = reader.ReadLine();
                    sitePropGPSLat = reader.ReadLine();
                    sitePropGPSLong = reader.ReadLine();
                    sitePropNotes = reader.ReadLine();

                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.ToString());
            }
        }

        private void txtGPSLat_TextChanged(object sender, EventArgs e)
        {
            txtGPSLat.ForeColor = Color.Black;
            string outString = "";
            TextBox textChanged = sender as TextBox;
            if (textChanged.Text != "Decimal")
            {
                foreach (Char input in textChanged.Text)
                {
                    if ((input < '0' || input > '9') && input != '.' && input != '-')
                        textChanged.Text.Replace(input, '\0');
                    else
                        outString += input;
                }
                textChanged.Text = outString;
                textChanged.SelectionStart = textChanged.Text.Length;
                sitePropGPSLat = txtGPSLat.Text;
            }
        }

        private void txtGPSLong_TextChanged(object sender, EventArgs e)
        {
            txtGPSLong.ForeColor = Color.Black;
            string outString = "";
            TextBox textChanged = sender as TextBox;
            if (textChanged.Text != "Decimal")
            {
                foreach (Char input in textChanged.Text)
                {
                    if ((input < '0' || input > '9') && input != '.' && input != '-')
                        textChanged.Text.Replace(input, '\0');
                    else
                        outString += input;
                }
                textChanged.Text = outString;
                textChanged.SelectionStart = textChanged.Text.Length;
                sitePropGPSLong = txtGPSLong.Text;
            }
        }

        private void txtOwner_TextChanged(object sender, EventArgs e)
        {
            sitePropOwnerName = txtOwner.Text;
        }

        private void txtContactName_TextChanged(object sender, EventArgs e)
        {
            sitePropContactName = txtContactName.Text;
        }

        private void txtContactNumber_TextChanged(object sender, EventArgs e)
        {
            sitePropContactNumber = txtContactNumber.Text;
        }

        private void txtContactEmail_TextChanged(object sender, EventArgs e)
        {
            sitePropContactEmail = txtContactEmail.Text;
        }

        private void txtElevation_TextChanged(object sender, EventArgs e)
        {
            sitePropElevation = txtElevation.Text;
        }

        private void txtSiteNotes_TextChanged(object sender, EventArgs e)
        {
            sitePropNotes = txtSiteNotes.Text;
        }

        private void txtDataSetNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboSiteName_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateFileNameLabel();
        }
        #endregion

        #region Other
        private string DateTimeConversion(string inDateTime)
        {
            string outDateTime = "";
            DateTime DTHolder;
            if(DateTime.TryParse(inDateTime, out DTHolder))
                outDateTime = DTHolder.ToString("yyyy-MM-dd hh:mm:ss");
            return outDateTime;
        }

        private void comboCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control controlTemp in panelVariableControls.Controls)
            {
                if (controlTemp.Name.Length == 10 && controlTemp.Name.Substring(1, 9) == "ComboMain")
                {
                    ComboBox combo = controlTemp as ComboBox;
                    if (combo.Text == "DateTime")
                    {
                        string colNum = combo.Name.Substring(0, 1);
                        string combo3Name = colNum + "Combo3";
                        Control combo3temp = panelVariableControls.Controls[combo3Name];
                        ComboBox combo3 = combo3temp as ComboBox;
                        combo3.Enabled = true;
                        combo3.Items.Clear();
                        if (comboCountries.Text != "")
                        {
                            string countryCode = Regex.Match(comboCountries.Text, @"\(([^)]*)\)").Groups[1].Value;
                            foreach (countryCodesTimes testCountry in countriesData)
                            {
                                if (testCountry.countryCode == countryCode)
                                {
                                    foreach (string timeZone in testCountry.countryTimeZone)
                                    {
                                        combo3.Items.Add(timeZone);
                                    }

                                }
                            }
                        }
                    }
                }
            }
            updateFileNameLabel();
        }

        private void btnDateFormatConverter_Click(object sender, EventArgs e)
        {
            
        }
        public void standardizeDateColumn()
        {
            DateConverter dateConverter = new DateConverter();
            int dateCol = -1;
            foreach (DataGridViewCell dCell in dataViewer.Rows[0].Cells)
            {
                if (dCell.Value.ToString().Contains("DateTime"))
                {
                    dateCol = dCell.ColumnIndex;
                }
            }
            if (dateCol == -1)
            {
                MergeDateTime();
                resetColumnNames();
                standardizeDateColumn();
            }
            else
            {
                bool errorRows = false;
                FrmDateFormat getDateFormat = new FrmDateFormat();
                getDateFormat.input = dataViewer.Rows[1].Cells[dateCol].Value.ToString();
                getDateFormat.ShowDialog();
                if (getDateFormat.cancel == false)
                {
                    if (getDateFormat.validFormat)
                    {
                        dateConverter.acceptedFormat = getDateFormat.format;
                    }
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (DataGridViewRow dRow in dataViewer.Rows)
                    {
                        if (dRow.Index != 0)
                        {
                            string convertedDate = dateConverter.ConvertDateToStandard(dRow.Cells[dateCol].Value.ToString());
                            if (convertedDate != null)
                            {
                                InputTable.Rows[dRow.Cells[dateCol].RowIndex][dRow.Cells[dateCol].ColumnIndex] = convertedDate;
                            }
                            else
                            {
                                errorRows = true;
                            }
                        }
                    }
                    Cursor.Current = Cursors.Default;
                    if (errorRows)
                    {
                        MessageBox.Show("Conversion incomplete.An unconvertable value was encountered.\n\rPlease add the date format to the 'Formats.txt' Control File.\n\rAlternatively remove the errored row before attempting to standardize dates.");
                    }
                }
                getDateFormat.Close();
            }
        }

        private void comboSiteName_TextChanged(object sender, EventArgs e)
        {
            updateFileNameLabel();
        }
        private void updateFileNameLabel()
        {
            string siteName = comboSiteName.Text;
            string countryCode = Regex.Match(comboCountries.Text, @"\(([^)]*)\)").Groups[1].Value;
            string startDate = dateTimeAggregateStart.Value.ToString("yyyyMM");
            string endDate = dateTimeAggregateEnd.Value.ToString("yyyyMM");
            string fileExtension = comboFileExtension.Text;
            string fileNameAppenedText = txtFileNameAppend.Text;
            if (siteName == "")
                lblFileName.ForeColor = Color.Red;
            else if (countryCode.Length != 2)
                lblFileName.ForeColor = Color.Red;
            else if (Convert.ToInt32(endDate) < Convert.ToInt32(startDate))
                lblFileName.ForeColor = Color.Red;
            else
            {
                lblFileName.ForeColor = Color.Green;
            }
            if (fileNameAppenedText == "")
            {
                lblFileName.Text = siteName + "(" + countryCode + ")_" + startDate + "-" + endDate + fileExtension;
            }
            else
            {
                lblFileName.Text = siteName + "(" + countryCode + ")_" + startDate + "-" + endDate + "_" + fileNameAppenedText + fileExtension;
            }
            
        }

        

        private void btdMergeDateTime_Click(object sender, EventArgs e)
        {
            if (InputTable == null)
                MessageBox.Show("You have not opened a valid Datatable yet", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                MergeSplitDateTime();
                resetColumnNames();
                standardizeDateColumn();
                setVarBoxesInPanel();
                Cursor.Current = Cursors.Default;
            }
        }
        public void MergeSplitDateTime()
        {
            int rowIndex = 0;
            int numDateCols = 0;
            int numTimeCols = 0;
            int numDateTimeCols = 0;
            int timeColNum = -1;
            int dateColNum = -1;
            int dateTimeColNum = -1;
            foreach (DataGridViewCell dCell in dataViewer.Rows[0].Cells)
            {
                if (dCell.Value.ToString() == "Date")
                {
                    numDateCols++;
                    dateColNum = dCell.ColumnIndex;
                }
                else if (dCell.Value.ToString().Length >= 4 && dCell.Value.ToString().Substring(0, 4) == "Time")
                {
                    numTimeCols++;
                    timeColNum = dCell.ColumnIndex;
                }
                else if (dCell.Value.ToString().Contains("DateTime"))
                {
                    numDateTimeCols++;
                    dateTimeColNum = dCell.ColumnIndex;
                }
            }
            if (numDateCols == 1 && numDateTimeCols == 0)
            {
                if (numTimeCols == 1)
                {
                    InputTable.Columns[dateColNum].SetOrdinal(0);
                    dataViewer.Columns[dateColNum].DisplayIndex = 0;
                    foreach (DataRow dRow in InputTable.Rows)
                    {
                        if (rowIndex != 0)
                        {
                            dRow[0] = dRow[0] + " " + dRow[timeColNum].ToString();
                        }
                        else
                        {
                            dRow[0] = "Date" + dRow[timeColNum].ToString();
                        }
                        rowIndex++;

                    }
                    InputTable.Columns.RemoveAt(timeColNum);
                }
                else if (numTimeCols > 1)
                {
                    MessageBox.Show("One Date column found. \n\rMore than 1 Time column was found, please delete excess Time columns.");
                }
                else if (numTimeCols == 0)
                {
                    MessageBox.Show("One Date column found. \n\rNo Time column was found.");
                }
            }
            else if (numDateTimeCols == 1 && numDateCols == 0)
            {
                if (numTimeCols == 0)
                {
                    InputTable.Columns.Add("Time");
                    InputTable.Columns[dateTimeColNum].SetOrdinal(0);
                    dataViewer.Columns[dateTimeColNum].DisplayIndex = 0;
                    InputTable.Columns["Time"].SetOrdinal(1);
                    dataViewer.Columns["Time"].DisplayIndex = 1;
                    dataViewer.Columns["Time"].SortMode = DataGridViewColumnSortMode.Programmatic;
                    foreach (DataRow dRow in InputTable.Rows)
                    {
                        if (rowIndex != 0)
                        {
                            DateTime outdt;
                            if (DateTime.TryParse(dRow[0].ToString(), out outdt))
                            {
                                dRow[1] = outdt.ToString("HH:mm:ss");
                                dRow[0] = outdt.ToString("yyyy-MM-dd");
                            }
                        }
                        else
                        {
                            dRow[1] = dRow[0].ToString().Substring(4, dRow[0].ToString().Length - 4);
                            dRow[0] = "Date";
                        }
                        rowIndex++;

                    }
                }
                else
                {
                    MessageBox.Show("One DateTime column found. \n\rHowever atleast one Time column was also found, please delete excess columns before using this function.");
                }

            }
            else if (numDateTimeCols == 0 && numDateCols == 0)
            {
                MessageBox.Show("No Date or DateTime column was found.");
            }
            if (numDateCols > 1)
            {
                MessageBox.Show("More than 1 Date column was found, please delete excess Date columns.");
            }
            if (numDateTimeCols > 1)
            {
                MessageBox.Show("More than 1 DateTime column was found, please delete excess DateTime columns.");
            }
            
        }

        public bool MergeDateTime()
        {
            int rowIndex = 0;
            int numDateCols = 0;
            int numTimeCols = 0;
            int numDateTimeCols = 0;
            int timeColNum = -1;
            int dateColNum = -1;
            foreach (DataGridViewCell dCell in dataViewer.Rows[0].Cells)
            {
                if (dCell.Value.ToString() == "Date")
                {
                    numDateCols++;
                    dateColNum = dCell.ColumnIndex;
                }
                else if (dCell.Value.ToString().Length >=4 && dCell.Value.ToString().Substring(0, 4) == "Time")
                {
                    numTimeCols++;
                    timeColNum = dCell.ColumnIndex;
                }
                else if (dCell.Value.ToString().Length >= 8 && dCell.Value.ToString().Substring(0, 8) == "DateTime")
                {
                    numDateTimeCols++;
                }
            }
            if (numDateCols == 1)
            {
                if (numTimeCols == 1)
                {
                    InputTable.Columns[dateColNum].SetOrdinal(0);
                    dataViewer.Columns[dateColNum].DisplayIndex = 0;
                    foreach (DataRow dRow in InputTable.Rows)
                    {
                        if (rowIndex != 0)
                        {
                            dRow[0] = dRow[0] + " " + dRow[timeColNum].ToString();
                        }
                        else
                        {
                            dRow[0] = "Date" + dRow[timeColNum].ToString();
                        }
                        rowIndex++;

                    }
                    InputTable.Columns.RemoveAt(timeColNum);
                    return true;
                }
                else if(numTimeCols > 1)
                {
                    MessageBox.Show("More than 1 Time column was found, please delete excess Time columns.");
                }
                else if (numTimeCols ==0)
                {
                    MessageBox.Show("No Time column was found.");
                }
            }
            else if (numDateCols >1)
            {
                MessageBox.Show("More than 1 Date column was found, please delete excess Date columns.");
            }
            else if (numDateCols == 0)
            {
                if (numDateTimeCols == 1)
                    return true;
                MessageBox.Show("No Date column was found.");
            }
            return false;
        }
        
        private int ColToDelete;
        private int RowToDelete;
        private void dataViewer_MouseDown(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.DataGridView.HitTestInfo hti = dataViewer.HitTest(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
                if (hti.ColumnIndex == -1 && hti.RowIndex >= 0)
                {
                    // row header click
                    dataViewer.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                }
                else if (hti.RowIndex == -1 && hti.ColumnIndex >= 0)
                {
                    // column header click
                    dataViewer.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (hti.RowIndex == -1)
                {
                    ColToDelete = hti.ColumnIndex;
                    ContextMenuStrip cMenu = new ContextMenuStrip();
                    ToolStripMenuItem mnuDelete = new ToolStripMenuItem("Delete Column");
                    mnuDelete.Click += new EventHandler(mnuDeleteCol_Click);
                    cMenu.Items.Add(mnuDelete);
                    cMenu.Show(Cursor.Position);
                }
                if (hti.ColumnIndex == -1)
                {
                    RowToDelete = hti.RowIndex;
                    ContextMenuStrip cMenu = new ContextMenuStrip();
                    ToolStripMenuItem mnuDelete = new ToolStripMenuItem("Delete Row");
                    mnuDelete.Click += new EventHandler(mnuDeleteRow_Click);
                    cMenu.Items.Add(mnuDelete);
                    cMenu.Show(Cursor.Position);
                }
            }
        }
        public void mnuDeleteCol_Click(object sender, EventArgs e)
        {
            InputTable.Columns.RemoveAt(ColToDelete);
            setVarBoxesInPanel();
        }
        public void mnuDeleteRow_Click(object sender, EventArgs e)
        {
            InputTable.Rows.RemoveAt(RowToDelete);
        }
        #endregion

        #region Menu Strip
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }


        private bool sortDates()
        {
            int numDateCols = 0, numTimeCols = 0, numDateTimeCols = 0;
            int dateColNum = 0, timeColNum = 0, dateTimeColNum = 0;
            foreach (DataGridViewCell dCell in dataViewer.Rows[0].Cells)
            {
                if (dCell.Value.ToString().Length >= 8 && dCell.Value.ToString().Substring(0, 8) == "DateTime")
                {
                    numDateTimeCols++;
                    dateTimeColNum = dCell.ColumnIndex;
                }
                else if (dCell.Value.ToString() == "Date")
                {
                    numDateCols++;
                    dateColNum = dCell.ColumnIndex;
                }
                else if (dCell.Value.ToString().Length >= 4 && dCell.Value.ToString().Substring(0, 4) == "Time")
                {
                    numTimeCols++;
                    timeColNum = dCell.ColumnIndex;
                }
            }
            if (numDateTimeCols == 0 && numDateCols == 0 && numTimeCols == 0)
            {
                MessageBox.Show("No Date, Time, or DateTime columns found.");
            }
            else if (numDateTimeCols == 1 && numDateCols == 0 && numTimeCols == 0)
            {
                if (QuicksortDateTime(dateTimeColNum, 1, dataViewer.Rows.Count - 1))
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Too many Date, Time, or DateTime columns found. \n\rNote: Currently this program does not allow sorting of sperate Date and Time columns");
            }
            return false;


        }    
        private void emptyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setAllEmpty("!Empty");
        }
        private void setColOrderingToNatural()
        {
            foreach (DataGridViewColumn dCol in dataViewer.Columns)
            {
                dCol.DisplayIndex = InputTable.Columns[dCol.Index].Ordinal;
            }
        }

        private void setAllEmpty(string newEmptyvalue)
        {
            if (InputTable == null)
                MessageBox.Show("You have not opened a valid Datatable yet", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                foreach (ToolStripItem TSI in dataToolStripMenuItem.DropDownItems)
                {
                    if (TSI.Text == newEmptyvalue)
                    {
                        TSI.Image = Image.FromFile("tick.jpg");
                    }
                    else
                    {
                        TSI.Image = null;
                    }
                }
                foreach (DataGridViewRow dRow in dataViewer.Rows)
                {
                    foreach (DataGridViewCell dCell in dRow.Cells)
                    {
                        if (dCell.Value.ToString() == "!Empty" || dCell.Value.ToString() == "NaN" || dCell.Value.ToString() == "na" || dCell.Value.ToString() == "nan" || dCell.Value.ToString() == "N/A" || dCell.Value.ToString() == "#N/A" || dCell.Value.ToString() == "" || dCell.Value.ToString() == " ")
                        {
                            dCell.Value = newEmptyvalue;
                        }
                    }
                }
            }
        }
        #endregion

        
        public bool QuicksortDateTime(int dateTimeColNum, int left, int right)
        {
            int rowError = 0;
            try
            {
                int i = left, j = right;
                rowError = (left + right) / 2;
                DateTime pivot = Convert.ToDateTime(dataViewer.Rows[(left + right) / 2].Cells[dateTimeColNum].Value.ToString());
                while (i <= j)
                {
                    rowError = i;
                    while (Convert.ToDateTime(dataViewer.Rows[i].Cells[dateTimeColNum].Value.ToString()).CompareTo(pivot) < 0)
                    {
                        i++;
                        rowError = i;
                    }
                    rowError = j;
                    while (Convert.ToDateTime(dataViewer.Rows[j].Cells[dateTimeColNum].Value.ToString()).CompareTo(pivot) > 0)
                    {
                        j--;
                        rowError = j;
                    }
                    if (i <= j)
                    {
                        // Swap
                        SwitchRows(InputTable, i, j);
                        i++;
                        j--;
                    }
                }
                // Recursive calls
                if (left < j)
                {
                    QuicksortDateTime(dateTimeColNum, left, j);
                }
                if (i < right)
                {
                    QuicksortDateTime(dateTimeColNum, i, right);
                }
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("An entry in the DateTime column is not a valid DateTime.\n\rError in row " + rowError);
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        private void comboEmpty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            setAllEmpty(comboEmpty.Text);
            blankPhrase = comboEmpty.Text;
            Cursor.Current = Cursors.Default;
        }
        private void comboEmpty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                setAllEmpty(comboEmpty.Text);
            }
        }
        #region Unfinished Functions
        public void QuicksortDateAndTime(int DateColNum, int TimeColNum, int left, int right)//Not Finished
        {
            int i = left, j = right;
            DateTime pivot = Convert.ToDateTime(dataViewer.Rows[(left + right) / 2].Cells[DateColNum].Value.ToString());
            while (i <= j)
            {
                while (Convert.ToDateTime(dataViewer.Rows[i].Cells[DateColNum].Value.ToString()).CompareTo(pivot) < 0)
                {
                    i++;
                }
                while (Convert.ToDateTime(dataViewer.Rows[j].Cells[DateColNum].Value.ToString()).CompareTo(pivot) > 0)
                {
                    j--;
                }
                if (i <= j)
                {
                    // Swap
                    SwitchRows(InputTable, i, j);
                    i++;
                    j--;
                }
            }
            // Recursive calls
            if (left < j)
            {
                QuicksortDateAndTime(DateColNum, TimeColNum, left, j);
            }
            if (i < right)
            {
                QuicksortDateAndTime(DateColNum, TimeColNum, i, right);
            }
        }
        #endregion


        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.O)
            {
                openFile();
            }
        }

        private void txtAggregatorPeriodNumber_TextChanged(object sender, EventArgs e)
        {
            string outString = "";
            TextBox textChanged = sender as TextBox;
            if (textChanged.Text != "Quantity")
            {
                foreach (Char input in textChanged.Text)
                {
                    if ((input < '0' || input > '9'))
                        textChanged.Text.Replace(input, '\0');
                    else
                        outString += input;
                }
                textChanged.Text = outString;
                textChanged.SelectionStart = textChanged.Text.Length;
            }
        }
        
        #region Aggregation
        private void btnAggregate_Click(object sender, EventArgs e)
        {
            if (dataViewer.DataSource == InputTable)
            {
                string direction = "";
                if (txtAggregatorPeriodNumber.Text == "" || txtAggregatorPeriodNumber.Text == "Quantity")
                {
                    MessageBox.Show("Please enter an aggregation period.");
                }
                else
                {
                    int periodNumber = Convert.ToInt32(txtAggregatorPeriodNumber.Text);
                    if (comboAggregatorPeriod.Text == "")
                    {
                        MessageBox.Show("Please select an aggregation period type.");
                    }
                    else
                    {
                        btnAggregate.Text = "Revert to full data set";
                        string periodType = comboAggregatorPeriod.Text;
                        if (radioBackward.Checked)
                        {
                            direction = "Backward";
                            Aggregate(direction, periodNumber, periodType);
                            getStartEndDates();
                        }
                        else if (radioCentered.Checked)
                        {
                            direction = "Centered";
                            Aggregate(direction, periodNumber, periodType);
                            getStartEndDates();
                        }
                        else if (radioForward.Checked)
                        {
                            direction = "Forward";
                            Aggregate(direction, periodNumber, periodType);
                            getStartEndDates();
                        }
                        else
                        {
                            MessageBox.Show("You must first select the aggregation direction.");
                        }
                    }
                }
            }
            else
            {
                dataViewer.DataSource = InputTable;
                btnAggregate.Text = "Aggregate";
            }
        }

        private void Aggregate(string direction, int periodNumber, string periodType)
        {
            if (dataViewer.DataSource == null)
                MessageBox.Show("You have not opened a valid Datatable yet", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                    int numDateTimeCols = 0;
                    int dateTimeColNum = -1;
                    foreach (DataGridViewCell dCell in dataViewer.Rows[0].Cells)
                    {
                        if (dCell.Value.ToString().Length >= 8 && dCell.Value.ToString().Substring(0, 8) == "DateTime")
                        {
                            numDateTimeCols++;
                            dateTimeColNum = dCell.ColumnIndex;
                        }
                    }
                    if (numDateTimeCols == 1)
                    {
                        
                        ColAggType(dateTimeColNum);
                        Cursor.Current = Cursors.WaitCursor;
                        AggregateColBased(direction, periodNumber, periodType, dateTimeColNum);
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        MessageBox.Show("No DateTime column found.");
                    }
            }

        }

        private void ColAggType(int dateTimeColNum)
        {
            ColHeaders = new HeaderInfo[dataViewer.Columns.Count - 1];
            int index = 0;
            foreach (DataGridViewCell dCell in dataViewer.Rows[0].Cells)
            {
                if (dCell.ColumnIndex != dateTimeColNum)
                {
                    HeaderInfo header = new HeaderInfo();
                    header.headerText = dCell.Value.ToString();
                    header.colNum = dCell.ColumnIndex;
                    ColHeaders[index] = header;
                    index++;
                }
            }
            if (index > 0)
            {
                FrmColAggType ColAggType = new FrmColAggType();
                ColAggType.generateColHeaders(ColHeaders);
                ColAggType.ShowDialog();
                if (ColAggType.exitByCancel == false)
                {
                    for (int i = 0; i < ColHeaders.Length; i++)
                    {
                        ColHeaders[i].aggType = ColAggType.retrieveAggType(ColHeaders[i].colNum);
                    }
                }
            }
        }

        private void AggregateColBased(string direction, int periodNumber, string periodType, int dateTimeColNum)
        {
            aggregatedTable = new DataTable();

            for (int i = 0; i <= dataViewer.Columns.Count - 1; i++)
            {
                aggregatedTable.Columns.Add(i.ToString());
            }
            DateTime startTime = dateTimeAggregateStart.Value;
            if (direction == "Backward")
            {
                switch (comboAggregatorPeriod.Text)
                {
                    case "Second/s":
                        startTime = dateTimeAggregateStart.Value.Subtract(TimeSpan.FromSeconds(periodNumber));
                        startTime = startTime.AddSeconds(1);
                        break;
                    case "Minute/s":
                        startTime = dateTimeAggregateStart.Value.Subtract(TimeSpan.FromMinutes(periodNumber));
                        startTime = startTime.AddSeconds(1);
                        break;
                    case "Hour/s":
                        startTime = dateTimeAggregateStart.Value.Subtract(TimeSpan.FromHours(periodNumber));
                        startTime = startTime.AddSeconds(1);
                        break;
                    case "Day/s":
                        startTime = dateTimeAggregateStart.Value.Subtract(TimeSpan.FromDays(periodNumber));
                        startTime = startTime.AddSeconds(1);
                        break;
                    case "Month/s":
                        MessageBox.Show("Unfortunately Backward aggregation cannot currently be applied monthly.");
                        return;
                    case "Year/s":
                        MessageBox.Show("Unfortunately Backward aggregation cannot currently be applied Yearly.");
                        return;
                    default:
                        //This will never occur due to previous checking
                        break;

                }
            }
            DateTime endTime = dateTimeAggregateEnd.Value;
            DateTime periodStartTime = startTime;
            DateTime periodEndTime = endTime;
            DateTime tempTime = DateTime.MinValue;
            DateTime dateTimeToUse = dateTimeAggregateStart.Value;
            int lastValRow;
            tempTime = DateTime.MinValue;
            periodEndTime = startTime;
            aggregatedTable.ImportRow(InputTable.Rows[0]);
            int runNum = 1;
            int firstRowHolder = 1;
            int lastRowHolder = 1;
            DialogResult result = MessageBox.Show("Should an aggregation period contains incomplete or missing data:\n\r Click ‘Yes’ to overwrite aggregated value with the warning message !Partial, or ‘No’ to use the value calculated using the incomplete data.", "", MessageBoxButtons.YesNo);
            do
            {
                int firstValRow = 1;
                tempTime = DateTime.MinValue;
                for (firstValRow = firstRowHolder; tempTime < periodStartTime && firstValRow < dataViewer.Rows.Count; firstValRow++)
                {
                        tempTime = Convert.ToDateTime(dataViewer.Rows[firstValRow].Cells[dateTimeColNum].Value);
                }
                firstValRow -= 1;
                firstRowHolder = firstValRow;
                switch (comboAggregatorPeriod.Text)
                {
                    case "Second/s":
                        if (direction == "Centered" && runNum == 1)
                            dateTimeToUse = dateTimeToUse.AddSeconds(periodNumber / 2);
                        if (runNum != 1)
                            dateTimeToUse = dateTimeToUse.AddSeconds(periodNumber);
                        periodStartTime = periodStartTime.AddSeconds(periodNumber);
                        periodEndTime = periodEndTime.AddSeconds(periodNumber);
                        break;

                    case "Minute/s":
                        if (direction == "Centered" && runNum == 1)
                            dateTimeToUse = dateTimeToUse.AddSeconds((60 * periodNumber) / 2);
                        if (runNum != 1)
                            dateTimeToUse = dateTimeToUse.AddMinutes(periodNumber);
                        periodStartTime = periodStartTime.AddMinutes(periodNumber);
                        periodEndTime = periodEndTime.AddMinutes(periodNumber);
                        break;
                    case "Hour/s":
                        if (direction == "Centered" && runNum == 1)
                            dateTimeToUse = dateTimeToUse.AddSeconds((60 * (60 * periodNumber)) / 2);
                        if (runNum != 1)
                            dateTimeToUse = dateTimeToUse.AddHours(periodNumber);
                        periodStartTime = periodStartTime.AddHours(periodNumber);
                        periodEndTime = periodEndTime.AddHours(periodNumber);
                        break;
                    case "Day/s":
                        if (direction == "Centered" && runNum == 1)
                            dateTimeToUse = dateTimeToUse.AddSeconds((24 * (60 * (60 * periodNumber))) / 2);
                        if (runNum != 1)
                            dateTimeToUse = dateTimeToUse.AddDays(periodNumber);
                        periodStartTime = periodStartTime.AddDays(periodNumber);
                        periodEndTime = periodEndTime.AddDays(periodNumber);
                        break;
                    case "Month/s":
                        if (direction == "Centered" && runNum == 1)
                            dateTimeToUse = dateTimeToUse.AddMonths(periodNumber / 2);
                        if (runNum != 1)
                            dateTimeToUse = dateTimeToUse.AddMonths(periodNumber);
                        periodStartTime = periodStartTime.AddMonths(periodNumber);
                        periodEndTime = periodEndTime.AddMonths(periodNumber);
                        break;
                    case "Year/s":
                        if (direction == "Centered" && runNum == 1)
                            dateTimeToUse = dateTimeToUse.AddYears(periodNumber / 2);
                        if (runNum != 1)
                            dateTimeToUse = dateTimeToUse.AddYears(periodNumber);
                        periodStartTime = periodStartTime.AddYears(periodNumber);
                        periodEndTime = periodEndTime.AddYears(periodNumber);
                        break;
                    default:
                        //This will never occur due to previous checking
                        break;

                }
                if (direction == "Backward")
                {

                    for (lastValRow = lastRowHolder; tempTime <= periodEndTime; lastValRow++)
                    {
                        if (lastValRow <= dataViewer.Rows.Count - 1)
                        {
                            tempTime = Convert.ToDateTime(dataViewer.Rows[lastValRow].Cells[dateTimeColNum].Value);
                        }
                        else
                            break;
                    }
                }
                else
                {

                    for (lastValRow = lastRowHolder; tempTime < periodEndTime && lastValRow <= dataViewer.Rows.Count - 1; lastValRow++)
                    {
                        if (lastValRow <= dataViewer.Rows.Count - 1)
                        {
                            tempTime = Convert.ToDateTime(dataViewer.Rows[lastValRow].Cells[dateTimeColNum].Value);
                        }
                        else
                            break;
                    }
                }
                lastValRow -= 2;
                lastRowHolder = lastValRow;
                if (lastRowHolder <= 0)
                    lastRowHolder = 1;
                DataRow newRow = AggregateColBasedPeriod(direction, periodNumber, firstValRow, lastValRow, dateTimeColNum, dateTimeToUse.ToString("yyyy-MM-dd HH:mm:ss"), result);
                if (newRow != null)
                {
                    aggregatedTable.Rows.Add(newRow);
                }
                runNum++;
            } while (periodEndTime <= endTime);
            dataViewer.Columns.Clear();
            dataViewer.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataViewer.DataSource = aggregatedTable;
            foreach (DataGridViewColumn dCol in dataViewer.Columns)
            {
                dCol.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
        private DataRow AggregateColBasedPeriod(string direction, int periodNumber, int startRow, int EndRow, int dateTimeColNum, string dateTimeToUse, DialogResult result)
        {
            int index = 0;
            DataRow dRow = aggregatedTable.NewRow();
            if (EndRow < startRow) //Timestamp missing
            {
                foreach (DataGridViewCell dCell in dataViewer.Rows[1].Cells)
                {
                    if (dCell.ColumnIndex != dateTimeColNum)
                    {
                        dRow[index] = blankPhrase;
                    }
                    index++;
                }
                dRow[dateTimeColNum] = dateTimeToUse;
                return dRow;
            }
            int[] valueCounts = new int[InputTable.Columns.Count];
            for (int a = 0; a < valueCounts.Length; a++)
            {
                valueCounts[a] = 0;
            }
            for (int i = startRow; i <= EndRow; i++)
            {
                index = 0;
                foreach (DataGridViewCell dCell in dataViewer.Rows[i].Cells)
                {
                    if (dCell.ColumnIndex != dateTimeColNum)
                    {
                            if (Regex.IsMatch(dCell.Value.ToString(), "[0-9]+.?[0-9]*") && dRow[index].ToString() != "!Partial")
                            {

                                if (dRow[index].ToString() == "")
                                {
                                    dRow[index] = dCell.Value.ToString();
                                }
                                else
                                {
                                        dRow[index] = (Convert.ToDouble(dRow[index].ToString()) + Convert.ToDouble(dCell.Value.ToString())).ToString();
                                }
                                valueCounts[index]++;
                            }
                            else if(result == DialogResult.Yes)
                            {
                                dRow[index] = "!Partial";
                            }
                    }
                    index++;
                }
                dRow[dateTimeColNum] = dateTimeToUse;
            }

            foreach (HeaderInfo header in ColHeaders)
            {
                if (header.aggType == "Mean")
                {
                    if (Regex.IsMatch(dRow[header.colNum].ToString(), "[0-9]+.?[0-9]*"))
                    {
                        try
                        {
                            dRow[header.colNum] = Convert.ToDouble(dRow[header.colNum].ToString()) / valueCounts[header.colNum];
                        }
                        catch (IndexOutOfRangeException iore)
                        {
                            MessageBox.Show(iore.Message + " " + header.colNum);
                        }
                    }
                }
            }
            DateTime startTime = dateTimeAggregateStart.Value;
            DateTime endTime = dateTimeAggregateEnd.Value;
            DateTime tempTime = DateTime.MinValue;
            if (direction == "Backward")
            {
                for (int i = EndRow; i >= startRow; i--)
                {
                    if (Convert.ToDateTime(dataViewer.Rows[i].Cells[dateTimeColNum].Value) <= Convert.ToDateTime(dateTimeToUse))
                    {
                        foreach (HeaderInfo header in ColHeaders)
                        {
                            if (header.aggType == "Nearest timestamp")
                            {
                                dRow[header.colNum] = dataViewer.Rows[i].Cells[header.colNum].Value.ToString();
                                break;
                            }
                        }
                    }
                }
            }
            else if (direction == "Forward")
            {
                for (int i = startRow; i <= EndRow; i++)
                {
                    if (Convert.ToDateTime(dataViewer.Rows[i].Cells[dateTimeColNum].Value) >= Convert.ToDateTime(dateTimeToUse))
                    {
                        foreach (HeaderInfo header in ColHeaders)
                        {
                            if (header.aggType == "Nearest timestamp")
                            {
                                dRow[header.colNum] = dataViewer.Rows[i].Cells[header.colNum].Value.ToString();
                                break;
                            }
                        }
                    }
                }
            }
            else //Centered
            {
                TimeSpan difference = TimeSpan.MaxValue;
                int currentRow = -1;
                for (int i = startRow; i <= EndRow; i++)
                {
                    if (Convert.ToDateTime(dataViewer.Rows[i].Cells[dateTimeColNum].Value).Subtract(Convert.ToDateTime(dateTimeToUse)) <= difference && Convert.ToDateTime(dataViewer.Rows[i].Cells[dateTimeColNum].Value).Subtract(Convert.ToDateTime(dateTimeToUse)) >= TimeSpan.Zero)
                    {
                        difference = Convert.ToDateTime(dataViewer.Rows[i].Cells[dateTimeColNum].Value).Subtract(Convert.ToDateTime(dateTimeToUse));
                        currentRow = i;
                    }
                    else if (Convert.ToDateTime(dateTimeToUse).Subtract(Convert.ToDateTime(dataViewer.Rows[i].Cells[dateTimeColNum].Value)) <= difference && Convert.ToDateTime(dateTimeToUse).Subtract(Convert.ToDateTime(dataViewer.Rows[i].Cells[dateTimeColNum].Value)) >= TimeSpan.Zero)
                    {
                        difference = Convert.ToDateTime(dateTimeToUse).Subtract(Convert.ToDateTime(dataViewer.Rows[i].Cells[dateTimeColNum].Value));
                        currentRow = i;
                    }
                }
                if (currentRow != -1)
                    foreach (HeaderInfo header in ColHeaders)
                    {
                        if (header.aggType == "Nearest timestamp")
                        {
                            dRow[header.colNum] = dataViewer.Rows[currentRow].Cells[header.colNum].Value.ToString();
                            break;
                        }
                    }
            }
            return dRow;
        }
        #endregion

        private void addNewVaribleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewVariable newVariable = new FrmNewVariable();
            newVariable.ShowDialog();
            if (newVariable.exitByCancel == false)
            {
                try
                {
                    //Assembly assembly = Assembly.GetExecutingAssembly();
                    //Stream objStream = assembly.GetManifestResourceStream("GetPropertiesSample.License.txt");
                    StreamWriter writer = File.AppendText(@"Control Files\ABBREVIATIONS.txt");
                    string output = newVariable.testCode + '\t' + newVariable.testName;
                    testTypeUnits newTest = new testTypeUnits();
                    newTest.possibleUnits = new List<string>();
                    newTest.testCode = newVariable.testCode;
                    newTest.testName = newVariable.testName;
                    if (newVariable.RecommendedUnits != "")
                    {
                        output += '\t' + newVariable.RecommendedUnits;
                        newTest.RecommendedUnits = newVariable.RecommendedUnits;
                        newTest.possibleUnits.Add(newVariable.RecommendedUnits);
                        if (newVariable.possibleUnits.Count != 0)
                        {
                            output += '\t';
                            foreach (string posUnits in newVariable.possibleUnits)
                            {
                                output += posUnits;
                                newTest.possibleUnits.Add(posUnits);
                            }
                        }
                    }
                    writer.WriteLine(output);
                    writer.Close();
                    GLEONCodeData.Add(newTest);
                    newVariable.Close();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString());
                }
            }
        }

        private void gLEONConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed at The University of Waikato.\n\rBy Chris McBride and Sam Shute.");
        }

        private void dataViewer_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmCellDataChange frmChangeValue = new FrmCellDataChange();
            frmChangeValue.Text = e.RowIndex + ", " + e.ColumnIndex;
            frmChangeValue.setText(dataViewer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            frmChangeValue.ShowDialog();
            if (frmChangeValue.save)
            {
                dataViewer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = frmChangeValue.getText();
            }
        }

        private void sortDatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataViewer.DataSource == null)
                MessageBox.Show("You have not opened a valid Datatable yet", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                sortDates();
        }

        private void btnLoadAllHeaders_Click(object sender, EventArgs e)
        {
            foreach (Control btnToClick in panelVariableControls.Controls)
            {
                if (btnToClick.GetType() == typeof(Button))
                {
                    Button ButtonNewHeader = btnToClick as Button;
                    if (ButtonNewHeader.Text != dataViewer.Rows[0].Cells[Convert.ToInt32(ButtonNewHeader.Name.ToString().Substring(0, ButtonNewHeader.Name.ToString().IndexOf('B')))].Value.ToString())
                    {
                        ButtonNewHeader.PerformClick();
                        MessageBox.Show(ButtonNewHeader.Name.ToString().Substring(0, ButtonNewHeader.Name.ToString().IndexOf('B')));
                    }
                }
            }
        }

        private void comboAggregatorPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboAggregatorPeriod.ForeColor = Color.Black;
        }

        private void txtAggregatorPeriodNumber_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtAggregatorPeriodNumber.Text == "Quantity")
            {
                txtAggregatorPeriodNumber.ForeColor = Color.Black;
                txtAggregatorPeriodNumber.Text = "";
            }
        }

        private void txtFileNameAppend_TextChanged(object sender, EventArgs e)
        {
            updateFileNameLabel();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FillMissingRows();
        }

        private void dateTimeAggregateStart_ValueChanged(object sender, EventArgs e)
        {
            updateFileNameLabel();
        }

        private void dateTimeAggregateEnd_ValueChanged(object sender, EventArgs e)
        {
            updateFileNameLabel();
        }

        private void radioBackward_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBackward.Checked == true)
            {
                string holder = comboAggregatorPeriod.Text;
                comboAggregatorPeriod.Items.Clear();
                comboAggregatorPeriod.Items.Add("Second/s");
                comboAggregatorPeriod.Items.Add("Minute/s");
                comboAggregatorPeriod.Items.Add("Hour/s");
                comboAggregatorPeriod.Items.Add("Day/s");
                if(holder !="Month/s" && holder != "Year/s")
                    comboAggregatorPeriod.Text = holder;
            }
            else if (radioBackward.Checked == false)
            {
                comboAggregatorPeriod.Items.Add("Month/s");
                comboAggregatorPeriod.Items.Add("Year/s");
            }
        }

        private void txtGPSLat_MouseClick(object sender, MouseEventArgs e)
        {
            txtGPSLat.ForeColor = Color.Black;
            txtGPSLat.Text = "";
        }

        private void txtGPSLong_MouseClick(object sender, MouseEventArgs e)
        {
            txtGPSLong.ForeColor = Color.Black;
            txtGPSLong.Text = "";
        }

        private void setSelectedAsHeaderRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataViewer.DataSource == null)
                MessageBox.Show("You have not opened a valid Datatable yet", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (dataViewer.SelectedRows.Count == 1)
                {
                    int newHeaderIndex = dataViewer.CurrentRow.Index;
                    for (int i = newHeaderIndex; i > 0; i--)
                    {
                        SwitchRows(InputTable, i, i - 1);
                    }
                    foreach (DataGridViewCell dCell in dataViewer.Rows[0].Cells)
                    {
                        dCell.Style.BackColor = Color.LightYellow;
                    }
                    HeaderSelected = true;
                }
                else if (dataViewer.SelectedRows.Count == 0)
                    MessageBox.Show("You must select atleast one row.");
                else
                    MessageBox.Show("Too many rows selected.");
                getStartEndDates();
            }
        }

        private void stripIncompleteRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InputTable == null)
                MessageBox.Show("You have not opened a valid Datatable yet", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                stripMetadata();
        }

        private void btnSetToEmpty_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < InputTable.Rows.Count; y++)
            {
                for (int x = 0; x < InputTable.Columns.Count; x++)
                {
                    if (InputTable.Rows[y].ItemArray[x].ToString() == txtSetToEmpty.Text)
                    {
                        InputTable.Rows[y].ItemArray[x] = blankPhrase;
                    }
                }
            }
        }

        private void saveHeadersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEnterFileName enterFileName = new FrmEnterFileName();
            enterFileName.ShowDialog();
            if (enterFileName.exitByCancel == false)
            {
                using (StreamWriter sWriter = new StreamWriter(System.Windows.Forms.Application.StartupPath + @"\Headers\" + enterFileName.filename+".hdr"))
                {
                    sWriter.WriteLine(InputTable.Columns.Count);
                    for (int i = 0; i < InputTable.Columns.Count; i++)
                    {
                        int index = i;
                        string comboMainName = index + "ComboMain";
                        Control comboMaintemp = panelVariableControls.Controls[comboMainName];
                        ComboBox comboMain = comboMaintemp as ComboBox;
                        string combo2Name = index + "Combo2";
                        Control combo2temp = panelVariableControls.Controls[combo2Name];
                        ComboBox combo2 = combo2temp as ComboBox;
                        string combo3Name = index + "Combo3";
                        Control combo3temp = panelVariableControls.Controls[combo3Name];
                        ComboBox combo3 = combo3temp as ComboBox;
                        string combo4Name = index + "Combo4";
                        Control combo4temp = panelVariableControls.Controls[combo4Name];
                        ComboBox combo4 = combo4temp as ComboBox;
                        string Text1Name = index + "Text1";
                        Control Text1temp = panelVariableControls.Controls[Text1Name];
                        TextBox Text1 = Text1temp as TextBox;
                        string Text2Name = index + "Text2";
                        Control Text2temp = panelVariableControls.Controls[Text2Name];
                        TextBox Text2 = Text2temp as TextBox;
                        sWriter.WriteLine(comboMain.Text + "\t" + combo2.Text + "\t" + combo3.Text + "\t" + combo4.Text + "\t" + Text1.Text + "\t" + Text2.Text);
                    }
                    MessageBox.Show("File saved");
                }
            }
        }

        private void loadHeadersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InputTable != null)
            {
                string filepath = getFiletoRead("Header Files (*.hdr)|*.*", System.Windows.Forms.Application.StartupPath + @"\Headers\");
                if (filepath != "")
                {
                    try
                    {
                        using (StreamReader sReader = new StreamReader(filepath))
                        {
                            int colCount = Convert.ToInt32(sReader.ReadLine());
                            if (colCount == InputTable.Columns.Count)
                            {
                                bool invalidData = false;
                                for (int i = 0; i < InputTable.Columns.Count; i++)
                                {
                                    int index = i;
                                    string comboMainName = index + "ComboMain";
                                    Control comboMaintemp = panelVariableControls.Controls[comboMainName];
                                    ComboBox comboMain = comboMaintemp as ComboBox;
                                    string combo2Name = index + "Combo2";
                                    Control combo2temp = panelVariableControls.Controls[combo2Name];
                                    ComboBox combo2 = combo2temp as ComboBox;
                                    string combo3Name = index + "Combo3";
                                    Control combo3temp = panelVariableControls.Controls[combo3Name];
                                    ComboBox combo3 = combo3temp as ComboBox;
                                    string combo4Name = index + "Combo4";
                                    Control combo4temp = panelVariableControls.Controls[combo4Name];
                                    ComboBox combo4 = combo4temp as ComboBox;
                                    string Text1Name = index + "Text1";
                                    Control Text1temp = panelVariableControls.Controls[Text1Name];
                                    TextBox Text1 = Text1temp as TextBox;
                                    string Text2Name = index + "Text2";
                                    Control Text2temp = panelVariableControls.Controls[Text2Name];
                                    TextBox Text2 = Text2temp as TextBox;
                                    string[] input = sReader.ReadLine().Split('\t');
                                    if (input.Length == 6)
                                    {
                                        comboMain.Text = input[0];
                                        combo2.Text = input[1];
                                        combo3.Text = input[2];
                                        combo4.Text = input[3];
                                        Text1.Text = input[4];
                                        Text2.Text = input[5];
                                    }
                                    else
                                    {
                                        invalidData = true;
                                    }
                                }
                                if (invalidData == true)
                                {
                                    MessageBox.Show("Some columns did not have enough entries and have been ignored");
                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error, file was not valid");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please open a dataset before attempting to open a header file.");
            }
        }

        private void testerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkFoldersExist();
        }


    }
    


    public struct testTypeUnits
    {
        public string testCode;
        public string testName;
        public List<string> possibleUnits;
        public string RecommendedUnits;
    }

    public struct countryCodesTimes
    {
        public string countryName;
        public string countryCode;
        public List<string> countryTimeZone;
    }
    public struct HeaderInfo
    {
        public string headerText;
        public int colNum;
        public string aggType;
    }
}