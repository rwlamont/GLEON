namespace WindowsFormsApplication1
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataViewer = new System.Windows.Forms.DataGridView();
            this.panelVariableControls = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtDataSetNotes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSiteInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortDatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stripIncompleteRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewVaribleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLEONConverterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label15 = new System.Windows.Forms.Label();
            this.comboEmpty = new System.Windows.Forms.ComboBox();
            this.checkMeta = new System.Windows.Forms.CheckBox();
            this.checkData = new System.Windows.Forms.CheckBox();
            this.btnAggregate = new System.Windows.Forms.Button();
            this.comboAggregatorPeriod = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.radioBackward = new System.Windows.Forms.RadioButton();
            this.radioCentered = new System.Windows.Forms.RadioButton();
            this.radioForward = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtAggregatorPeriodNumber = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dateTimeAggregateStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimeAggregateEnd = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.txtFileNameAppend = new System.Windows.Forms.TextBox();
            this.checkExportEmpty = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.comboCountries = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtGPSGridSystem = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtElevation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOrg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContactEmail = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSiteNotes = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.txtGPSLat = new System.Windows.Forms.TextBox();
            this.txtGPSLong = new System.Windows.Forms.TextBox();
            this.txtContactName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.comboSiteName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboFileExtension = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnSetToEmpty = new System.Windows.Forms.Button();
            this.txtSetToEmpty = new System.Windows.Forms.TextBox();
            this.mergeDateTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataViewer
            // 
            this.dataViewer.AllowUserToAddRows = false;
            this.dataViewer.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            this.dataViewer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dataViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataViewer.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataViewer.Location = new System.Drawing.Point(3, 242);
            this.dataViewer.Name = "dataViewer";
            this.dataViewer.ReadOnly = true;
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.dataViewer.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dataViewer.Size = new System.Drawing.Size(915, 608);
            this.dataViewer.TabIndex = 0;
            this.dataViewer.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewer_CellContentDoubleClick);
            this.dataViewer.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataViewer_ColumnWidthChanged);
            this.dataViewer.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataViewer_Scroll);
            this.dataViewer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataViewer_KeyDown);
            this.dataViewer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataViewer_MouseDown);
            // 
            // panelVariableControls
            // 
            this.panelVariableControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVariableControls.AutoScroll = true;
            this.panelVariableControls.ForeColor = System.Drawing.Color.Black;
            this.panelVariableControls.Location = new System.Drawing.Point(0, 56);
            this.panelVariableControls.Name = "panelVariableControls";
            this.panelVariableControls.Size = new System.Drawing.Size(915, 180);
            this.panelVariableControls.TabIndex = 36;
            this.panelVariableControls.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panelVariableControls_Scroll);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExport.Location = new System.Drawing.Point(924, 827);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(326, 23);
            this.btnExport.TabIndex = 30;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtDataSetNotes
            // 
            this.txtDataSetNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataSetNotes.Location = new System.Drawing.Point(9, 418);
            this.txtDataSetNotes.Multiline = true;
            this.txtDataSetNotes.Name = "txtDataSetNotes";
            this.txtDataSetNotes.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtDataSetNotes.Size = new System.Drawing.Size(306, 127);
            this.txtDataSetNotes.TabIndex = 16;
            this.txtDataSetNotes.TextChanged += new System.EventHandler(this.txtDataSetNotes_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 392);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Data set notes";
            // 
            // lblFileName
            // 
            this.lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFileName.ForeColor = System.Drawing.Color.Black;
            this.lblFileName.Location = new System.Drawing.Point(1016, 775);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(234, 18);
            this.lblFileName.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(921, 775);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 18);
            this.label7.TabIndex = 53;
            this.label7.Text = "Output file name:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 72;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openSiteInfoToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openFileToolStripMenuItem.Text = "Open dataset";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // openSiteInfoToolStripMenuItem
            // 
            this.openSiteInfoToolStripMenuItem.Name = "openSiteInfoToolStripMenuItem";
            this.openSiteInfoToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openSiteInfoToolStripMenuItem.Text = "Open .meta file";
            this.openSiteInfoToolStripMenuItem.Click += new System.EventHandler(this.openSiteInfoToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.loadInMetaFileToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortDatesToolStripMenuItem,
            this.stripIncompleteRowsToolStripMenuItem,
            this.mergeDateTimeToolStripMenuItem});
            this.dataToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // sortDatesToolStripMenuItem
            // 
            this.sortDatesToolStripMenuItem.Name = "sortDatesToolStripMenuItem";
            this.sortDatesToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.sortDatesToolStripMenuItem.Text = "Sort dates";
            this.sortDatesToolStripMenuItem.Click += new System.EventHandler(this.sortDatesToolStripMenuItem_Click);
            // 
            // stripIncompleteRowsToolStripMenuItem
            // 
            this.stripIncompleteRowsToolStripMenuItem.Name = "stripIncompleteRowsToolStripMenuItem";
            this.stripIncompleteRowsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.stripIncompleteRowsToolStripMenuItem.Text = "Strip incomplete rows";
            this.stripIncompleteRowsToolStripMenuItem.Click += new System.EventHandler(this.stripIncompleteRowsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewVaribleToolStripMenuItem});
            this.optionsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // addNewVaribleToolStripMenuItem
            // 
            this.addNewVaribleToolStripMenuItem.Name = "addNewVaribleToolStripMenuItem";
            this.addNewVaribleToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.addNewVaribleToolStripMenuItem.Text = "Add new variable";
            this.addNewVaribleToolStripMenuItem.Click += new System.EventHandler(this.addNewVaribleToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gLEONConverterToolStripMenuItem});
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // gLEONConverterToolStripMenuItem
            // 
            this.gLEONConverterToolStripMenuItem.Name = "gLEONConverterToolStripMenuItem";
            this.gLEONConverterToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.gLEONConverterToolStripMenuItem.Text = "Data Standardizer";
            this.gLEONConverterToolStripMenuItem.Click += new System.EventHandler(this.gLEONConverterToolStripMenuItem_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(230, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 13);
            this.label15.TabIndex = 74;
            this.label15.Text = "Empty place holder:";
            // 
            // comboEmpty
            // 
            this.comboEmpty.FormattingEnabled = true;
            this.comboEmpty.Location = new System.Drawing.Point(336, 28);
            this.comboEmpty.Name = "comboEmpty";
            this.comboEmpty.Size = new System.Drawing.Size(114, 21);
            this.comboEmpty.TabIndex = 5;
            this.comboEmpty.SelectedIndexChanged += new System.EventHandler(this.comboEmpty_SelectedIndexChanged);
            this.comboEmpty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboEmpty_KeyDown);
            // 
            // checkMeta
            // 
            this.checkMeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkMeta.AutoSize = true;
            this.checkMeta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkMeta.Checked = true;
            this.checkMeta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkMeta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkMeta.Location = new System.Drawing.Point(1163, 804);
            this.checkMeta.Name = "checkMeta";
            this.checkMeta.Size = new System.Drawing.Size(87, 17);
            this.checkMeta.TabIndex = 29;
            this.checkMeta.Text = "Metadata file";
            this.checkMeta.UseVisualStyleBackColor = true;
            // 
            // checkData
            // 
            this.checkData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkData.AutoSize = true;
            this.checkData.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkData.Checked = true;
            this.checkData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkData.ForeColor = System.Drawing.Color.Black;
            this.checkData.Location = new System.Drawing.Point(1108, 804);
            this.checkData.Name = "checkData";
            this.checkData.Size = new System.Drawing.Size(49, 17);
            this.checkData.TabIndex = 28;
            this.checkData.Text = "Data";
            this.checkData.UseVisualStyleBackColor = true;
            // 
            // btnAggregate
            // 
            this.btnAggregate.ForeColor = System.Drawing.Color.Black;
            this.btnAggregate.Location = new System.Drawing.Point(3, 66);
            this.btnAggregate.Name = "btnAggregate";
            this.btnAggregate.Size = new System.Drawing.Size(318, 23);
            this.btnAggregate.TabIndex = 24;
            this.btnAggregate.Text = "Aggregate";
            this.btnAggregate.UseVisualStyleBackColor = true;
            this.btnAggregate.Click += new System.EventHandler(this.btnAggregate_Click);
            // 
            // comboAggregatorPeriod
            // 
            this.comboAggregatorPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAggregatorPeriod.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboAggregatorPeriod.FormattingEnabled = true;
            this.comboAggregatorPeriod.Location = new System.Drawing.Point(214, 8);
            this.comboAggregatorPeriod.Name = "comboAggregatorPeriod";
            this.comboAggregatorPeriod.Size = new System.Drawing.Size(107, 21);
            this.comboAggregatorPeriod.TabIndex = 20;
            this.comboAggregatorPeriod.SelectedIndexChanged += new System.EventHandler(this.comboAggregatorPeriod_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 13);
            this.label16.TabIndex = 81;
            this.label16.Text = "Aggregation time step:";
            // 
            // radioBackward
            // 
            this.radioBackward.AutoSize = true;
            this.radioBackward.Location = new System.Drawing.Point(61, 35);
            this.radioBackward.Name = "radioBackward";
            this.radioBackward.Size = new System.Drawing.Size(73, 17);
            this.radioBackward.TabIndex = 21;
            this.radioBackward.TabStop = true;
            this.radioBackward.Text = "Backward";
            this.radioBackward.UseVisualStyleBackColor = true;
            this.radioBackward.CheckedChanged += new System.EventHandler(this.radioBackward_CheckedChanged);
            // 
            // radioCentered
            // 
            this.radioCentered.AutoSize = true;
            this.radioCentered.Location = new System.Drawing.Point(155, 35);
            this.radioCentered.Name = "radioCentered";
            this.radioCentered.Size = new System.Drawing.Size(68, 17);
            this.radioCentered.TabIndex = 22;
            this.radioCentered.TabStop = true;
            this.radioCentered.Text = "Centered";
            this.radioCentered.UseVisualStyleBackColor = true;
            // 
            // radioForward
            // 
            this.radioForward.AutoSize = true;
            this.radioForward.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioForward.Location = new System.Drawing.Point(258, 35);
            this.radioForward.Name = "radioForward";
            this.radioForward.Size = new System.Drawing.Size(63, 17);
            this.radioForward.TabIndex = 23;
            this.radioForward.TabStop = true;
            this.radioForward.Text = "Forward";
            this.radioForward.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.dateTimeAggregateStart);
            this.panel1.Controls.Add(this.dateTimeAggregateEnd);
            this.panel1.Location = new System.Drawing.Point(924, 583);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 149);
            this.panel1.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtAggregatorPeriodNumber);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.radioForward);
            this.panel3.Controls.Add(this.radioCentered);
            this.panel3.Controls.Add(this.radioBackward);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.btnAggregate);
            this.panel3.Controls.Add(this.comboAggregatorPeriod);
            this.panel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Location = new System.Drawing.Point(7, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(326, 93);
            this.panel3.TabIndex = 19;
            // 
            // txtAggregatorPeriodNumber
            // 
            this.txtAggregatorPeriodNumber.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAggregatorPeriodNumber.Location = new System.Drawing.Point(119, 8);
            this.txtAggregatorPeriodNumber.Name = "txtAggregatorPeriodNumber";
            this.txtAggregatorPeriodNumber.Size = new System.Drawing.Size(89, 20);
            this.txtAggregatorPeriodNumber.TabIndex = 19;
            this.txtAggregatorPeriodNumber.Text = "Quantity";
            this.txtAggregatorPeriodNumber.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAggregatorPeriodNumber_MouseClick);
            this.txtAggregatorPeriodNumber.TextChanged += new System.EventHandler(this.txtAggregatorPeriodNumber_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 37);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 13);
            this.label17.TabIndex = 88;
            this.label17.Text = "Direction:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.OrangeRed;
            this.label21.Location = new System.Drawing.Point(28, 8);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(91, 13);
            this.label21.TabIndex = 94;
            this.label21.Text = "Output time range";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(247, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(23, 13);
            this.label19.TabIndex = 93;
            this.label19.Text = "To:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(66, 8);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 13);
            this.label18.TabIndex = 92;
            this.label18.Text = "From:";
            // 
            // dateTimeAggregateStart
            // 
            this.dateTimeAggregateStart.Location = new System.Drawing.Point(7, 24);
            this.dateTimeAggregateStart.Name = "dateTimeAggregateStart";
            this.dateTimeAggregateStart.Size = new System.Drawing.Size(160, 20);
            this.dateTimeAggregateStart.TabIndex = 17;
            this.dateTimeAggregateStart.ValueChanged += new System.EventHandler(this.dateTimeAggregateStart_ValueChanged);
            // 
            // dateTimeAggregateEnd
            // 
            this.dateTimeAggregateEnd.Location = new System.Drawing.Point(173, 24);
            this.dateTimeAggregateEnd.Name = "dateTimeAggregateEnd";
            this.dateTimeAggregateEnd.Size = new System.Drawing.Size(160, 20);
            this.dateTimeAggregateEnd.TabIndex = 18;
            this.dateTimeAggregateEnd.ValueChanged += new System.EventHandler(this.dateTimeAggregateEnd_ValueChanged);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label20.Location = new System.Drawing.Point(931, 735);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(133, 13);
            this.label20.TabIndex = 89;
            this.label20.Text = "Text to append to filename";
            // 
            // txtFileNameAppend
            // 
            this.txtFileNameAppend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileNameAppend.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtFileNameAppend.Location = new System.Drawing.Point(934, 751);
            this.txtFileNameAppend.Name = "txtFileNameAppend";
            this.txtFileNameAppend.Size = new System.Drawing.Size(216, 20);
            this.txtFileNameAppend.TabIndex = 25;
            this.txtFileNameAppend.TextChanged += new System.EventHandler(this.txtFileNameAppend_TextChanged);
            // 
            // checkExportEmpty
            // 
            this.checkExportEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkExportEmpty.AutoSize = true;
            this.checkExportEmpty.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkExportEmpty.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkExportEmpty.Location = new System.Drawing.Point(924, 804);
            this.checkExportEmpty.Name = "checkExportEmpty";
            this.checkExportEmpty.Size = new System.Drawing.Size(116, 17);
            this.checkExportEmpty.TabIndex = 27;
            this.checkExportEmpty.Text = "Include empty lines";
            this.checkExportEmpty.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtDataSetNotes);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.comboCountries);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.txtGPSGridSystem);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtElevation);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtOrg);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtContactEmail);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtSiteNotes);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtContactNumber);
            this.panel2.Controls.Add(this.txtGPSLat);
            this.panel2.Controls.Add(this.txtGPSLong);
            this.panel2.Controls.Add(this.txtContactName);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtOwner);
            this.panel2.Controls.Add(this.comboSiteName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(924, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 550);
            this.panel2.TabIndex = 6;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(8, 264);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(71, 13);
            this.label25.TabIndex = 102;
            this.label25.Text = "Country Code";
            this.label25.Click += new System.EventHandler(this.label25_Click);
            // 
            // comboCountries
            // 
            this.comboCountries.FormattingEnabled = true;
            this.comboCountries.Location = new System.Drawing.Point(91, 261);
            this.comboCountries.Name = "comboCountries";
            this.comboCountries.Size = new System.Drawing.Size(224, 21);
            this.comboCountries.TabIndex = 101;
            this.comboCountries.SelectedIndexChanged += new System.EventHandler(this.comboCountries_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(8, 214);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(88, 13);
            this.label24.TabIndex = 100;
            this.label24.Text = "GPS Grid System";
            // 
            // txtGPSGridSystem
            // 
            this.txtGPSGridSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGPSGridSystem.Location = new System.Drawing.Point(102, 212);
            this.txtGPSGridSystem.Name = "txtGPSGridSystem";
            this.txtGPSGridSystem.Size = new System.Drawing.Size(213, 20);
            this.txtGPSGridSystem.TabIndex = 95;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 87;
            this.label9.Text = "Elevation (masl)";
            // 
            // txtElevation
            // 
            this.txtElevation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtElevation.Location = new System.Drawing.Point(276, 183);
            this.txtElevation.Name = "txtElevation";
            this.txtElevation.Size = new System.Drawing.Size(39, 20);
            this.txtElevation.TabIndex = 12;
            this.txtElevation.TextChanged += new System.EventHandler(this.txtElevation_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 94;
            this.label4.Text = "Organisation";
            // 
            // txtOrg
            // 
            this.txtOrg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrg.Location = new System.Drawing.Point(91, 157);
            this.txtOrg.Name = "txtOrg";
            this.txtOrg.Size = new System.Drawing.Size(224, 20);
            this.txtOrg.TabIndex = 93;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(27, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 92;
            this.label3.Text = "Meta information";
            // 
            // txtContactEmail
            // 
            this.txtContactEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContactEmail.Location = new System.Drawing.Point(91, 131);
            this.txtContactEmail.Name = "txtContactEmail";
            this.txtContactEmail.Size = new System.Drawing.Size(224, 20);
            this.txtContactEmail.TabIndex = 11;
            this.txtContactEmail.TextChanged += new System.EventHandler(this.txtContactEmail_TextChanged);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 134);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(71, 13);
            this.label22.TabIndex = 90;
            this.label22.Text = "Contact email";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 289);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 89;
            this.label8.Text = "Site notes";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtSiteNotes
            // 
            this.txtSiteNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSiteNotes.Location = new System.Drawing.Point(9, 305);
            this.txtSiteNotes.Multiline = true;
            this.txtSiteNotes.Name = "txtSiteNotes";
            this.txtSiteNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSiteNotes.Size = new System.Drawing.Size(306, 74);
            this.txtSiteNotes.TabIndex = 15;
            this.txtSiteNotes.TextChanged += new System.EventHandler(this.txtSiteNotes_TextChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(163, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 86;
            this.label10.Text = "GPS long";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 238);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 85;
            this.label11.Text = "GPS lat";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 84;
            this.label12.Text = "Phone number";
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContactNumber.Location = new System.Drawing.Point(91, 105);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(224, 20);
            this.txtContactNumber.TabIndex = 10;
            this.txtContactNumber.TextChanged += new System.EventHandler(this.txtContactNumber_TextChanged);
            // 
            // txtGPSLat
            // 
            this.txtGPSLat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGPSLat.Location = new System.Drawing.Point(58, 235);
            this.txtGPSLat.Name = "txtGPSLat";
            this.txtGPSLat.Size = new System.Drawing.Size(99, 20);
            this.txtGPSLat.TabIndex = 13;
            this.txtGPSLat.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtGPSLat_MouseClick);
            this.txtGPSLat.TextChanged += new System.EventHandler(this.txtGPSLat_TextChanged);
            // 
            // txtGPSLong
            // 
            this.txtGPSLong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGPSLong.Location = new System.Drawing.Point(218, 235);
            this.txtGPSLong.Name = "txtGPSLong";
            this.txtGPSLong.Size = new System.Drawing.Size(97, 20);
            this.txtGPSLong.TabIndex = 14;
            this.txtGPSLong.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtGPSLong_MouseClick);
            this.txtGPSLong.TextChanged += new System.EventHandler(this.txtGPSLong_TextChanged);
            // 
            // txtContactName
            // 
            this.txtContactName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContactName.Location = new System.Drawing.Point(91, 79);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(224, 20);
            this.txtContactName.TabIndex = 9;
            this.txtContactName.TextChanged += new System.EventHandler(this.txtContactName_TextChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 13);
            this.label13.TabIndex = 78;
            this.label13.Text = "Contact name";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 77;
            this.label14.Text = "Site owner";
            // 
            // txtOwner
            // 
            this.txtOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwner.Location = new System.Drawing.Point(91, 53);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(224, 20);
            this.txtOwner.TabIndex = 8;
            this.txtOwner.TextChanged += new System.EventHandler(this.txtOwner_TextChanged);
            // 
            // comboSiteName
            // 
            this.comboSiteName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboSiteName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboSiteName.FormattingEnabled = true;
            this.comboSiteName.Location = new System.Drawing.Point(91, 26);
            this.comboSiteName.Name = "comboSiteName";
            this.comboSiteName.Size = new System.Drawing.Size(224, 21);
            this.comboSiteName.TabIndex = 6;
            this.comboSiteName.SelectedIndexChanged += new System.EventHandler(this.comboSiteName_SelectedIndexChanged);
            this.comboSiteName.TextChanged += new System.EventHandler(this.comboSiteName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Site name";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1153, 735);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 96;
            this.label5.Text = "File type";
            // 
            // comboFileExtension
            // 
            this.comboFileExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboFileExtension.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboFileExtension.FormattingEnabled = true;
            this.comboFileExtension.Location = new System.Drawing.Point(1156, 751);
            this.comboFileExtension.Name = "comboFileExtension";
            this.comboFileExtension.Size = new System.Drawing.Size(94, 21);
            this.comboFileExtension.TabIndex = 26;
            this.comboFileExtension.SelectedIndexChanged += new System.EventHandler(this.comboFileExtension_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label23.Location = new System.Drawing.Point(1057, 805);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(45, 13);
            this.label23.TabIndex = 97;
            this.label23.Text = "Include:";
            // 
            // btnSetToEmpty
            // 
            this.btnSetToEmpty.BackColor = System.Drawing.Color.Transparent;
            this.btnSetToEmpty.ForeColor = System.Drawing.Color.Black;
            this.btnSetToEmpty.Location = new System.Drawing.Point(579, 27);
            this.btnSetToEmpty.Name = "btnSetToEmpty";
            this.btnSetToEmpty.Size = new System.Drawing.Size(80, 23);
            this.btnSetToEmpty.TabIndex = 98;
            this.btnSetToEmpty.Text = "Set as empty";
            this.btnSetToEmpty.UseVisualStyleBackColor = false;
            this.btnSetToEmpty.Click += new System.EventHandler(this.btnSetToEmpty_Click);
            // 
            // txtSetToEmpty
            // 
            this.txtSetToEmpty.Location = new System.Drawing.Point(456, 29);
            this.txtSetToEmpty.Name = "txtSetToEmpty";
            this.txtSetToEmpty.Size = new System.Drawing.Size(117, 20);
            this.txtSetToEmpty.TabIndex = 99;
            // 
            // mergeDateTimeToolStripMenuItem
            // 
            this.mergeDateTimeToolStripMenuItem.Name = "mergeDateTimeToolStripMenuItem";
            this.mergeDateTimeToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.mergeDateTimeToolStripMenuItem.Text = "Merge and standardise date time";
            this.mergeDateTimeToolStripMenuItem.Click += new System.EventHandler(this.mergeDateTimeToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 862);
            this.Controls.Add(this.txtSetToEmpty);
            this.Controls.Add(this.btnSetToEmpty);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboFileExtension);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.checkExportEmpty);
            this.Controls.Add(this.txtFileNameAppend);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkData);
            this.Controls.Add(this.checkMeta);
            this.Controls.Add(this.comboEmpty);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.panelVariableControls);
            this.Controls.Add(this.dataViewer);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1024, 780);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Standardizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataViewer)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataViewer;
        private System.Windows.Forms.Panel panelVariableControls;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtDataSetNotes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboEmpty;
        private System.Windows.Forms.CheckBox checkMeta;
        private System.Windows.Forms.CheckBox checkData;
        private System.Windows.Forms.Button btnAggregate;
        private System.Windows.Forms.ComboBox comboAggregatorPeriod;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton radioBackward;
        private System.Windows.Forms.RadioButton radioCentered;
        private System.Windows.Forms.RadioButton radioForward;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtAggregatorPeriodNumber;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dateTimeAggregateStart;
        private System.Windows.Forms.DateTimePicker dateTimeAggregateEnd;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewVaribleToolStripMenuItem;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtFileNameAppend;
        private System.Windows.Forms.CheckBox checkExportEmpty;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSiteNotes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.TextBox txtGPSLat;
        private System.Windows.Forms.TextBox txtGPSLong;
        private System.Windows.Forms.TextBox txtElevation;
        private System.Windows.Forms.TextBox txtContactName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.ComboBox comboSiteName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContactEmail;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboFileExtension;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSetToEmpty;
        private System.Windows.Forms.TextBox txtSetToEmpty;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtGPSGridSystem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOrg;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox comboCountries;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLEONConverterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortDatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stripIncompleteRowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSiteInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergeDateTimeToolStripMenuItem;
    }
}

