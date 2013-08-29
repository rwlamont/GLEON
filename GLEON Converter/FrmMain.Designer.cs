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
            this.dataViewer = new System.Windows.Forms.DataGridView();
            this.panelVariableControls = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtDataSetNotes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btdMergeDateTime = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSiteInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveHeadersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadHeadersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadInMetaFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertDatesToStandardFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headerGuessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortDatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setSelectedAsHeaderRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stripIncompleteRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewVaribleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLEONConverterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.btnLoadAllHeaders = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContactEmail = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtElevation = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSiteNotes = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
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
            this.comboCountries = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboFileExtension = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnSetToEmpty = new System.Windows.Forms.Button();
            this.txtSetToEmpty = new System.Windows.Forms.TextBox();
            this.markIncompleteRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.dataViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewer.Location = new System.Drawing.Point(3, 242);
            this.dataViewer.Name = "dataViewer";
            this.dataViewer.ReadOnly = true;
            this.dataViewer.Size = new System.Drawing.Size(659, 476);
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
            this.panelVariableControls.Location = new System.Drawing.Point(0, 56);
            this.panelVariableControls.Name = "panelVariableControls";
            this.panelVariableControls.Size = new System.Drawing.Size(659, 180);
            this.panelVariableControls.TabIndex = 36;
            this.panelVariableControls.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panelVariableControls_Scroll);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(668, 695);
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
            this.txtDataSetNotes.Location = new System.Drawing.Point(678, 360);
            this.txtDataSetNotes.Multiline = true;
            this.txtDataSetNotes.Name = "txtDataSetNotes";
            this.txtDataSetNotes.Size = new System.Drawing.Size(306, 85);
            this.txtDataSetNotes.TabIndex = 16;
            this.txtDataSetNotes.TextChanged += new System.EventHandler(this.txtDataSetNotes_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(675, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Data set notes";
            // 
            // lblFileName
            // 
            this.lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFileName.Location = new System.Drawing.Point(760, 643);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(234, 18);
            this.lblFileName.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(665, 643);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 18);
            this.label7.TabIndex = 53;
            this.label7.Text = "Output file name:";
            // 
            // btdMergeDateTime
            // 
            this.btdMergeDateTime.Location = new System.Drawing.Point(12, 27);
            this.btdMergeDateTime.Name = "btdMergeDateTime";
            this.btdMergeDateTime.Size = new System.Drawing.Size(113, 23);
            this.btdMergeDateTime.TabIndex = 3;
            this.btdMergeDateTime.Text = "Merge/Split datetime";
            this.btdMergeDateTime.UseVisualStyleBackColor = true;
            this.btdMergeDateTime.Click += new System.EventHandler(this.btdMergeDateTime_Click);
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
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 72;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openSiteInfoToolStripMenuItem,
            this.saveHeadersToolStripMenuItem,
            this.loadHeadersToolStripMenuItem,
            this.loadInMetaFileToolStripMenuItem,
            this.markIncompleteRowsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.openFileToolStripMenuItem.Text = "Open dataset";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // openSiteInfoToolStripMenuItem
            // 
            this.openSiteInfoToolStripMenuItem.Name = "openSiteInfoToolStripMenuItem";
            this.openSiteInfoToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.openSiteInfoToolStripMenuItem.Text = "Open .meta file";
            this.openSiteInfoToolStripMenuItem.Click += new System.EventHandler(this.openSiteInfoToolStripMenuItem_Click);
            // 
            // saveHeadersToolStripMenuItem
            // 
            this.saveHeadersToolStripMenuItem.Name = "saveHeadersToolStripMenuItem";
            this.saveHeadersToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.saveHeadersToolStripMenuItem.Text = "Save Headers";
            this.saveHeadersToolStripMenuItem.Click += new System.EventHandler(this.saveHeadersToolStripMenuItem_Click);
            // 
            // loadHeadersToolStripMenuItem
            // 
            this.loadHeadersToolStripMenuItem.Name = "loadHeadersToolStripMenuItem";
            this.loadHeadersToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.loadHeadersToolStripMenuItem.Text = "Load Headers";
            this.loadHeadersToolStripMenuItem.Click += new System.EventHandler(this.loadHeadersToolStripMenuItem_Click);
            // 
            // loadInMetaFileToolStripMenuItem
            // 
            this.loadInMetaFileToolStripMenuItem.Name = "loadInMetaFileToolStripMenuItem";
            this.loadInMetaFileToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.loadInMetaFileToolStripMenuItem.Text = "Load In MetaFile";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertDatesToStandardFormatToolStripMenuItem,
            this.headerGuessToolStripMenuItem,
            this.sortDatesToolStripMenuItem,
            this.setSelectedAsHeaderRowToolStripMenuItem,
            this.stripIncompleteRowsToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // convertDatesToStandardFormatToolStripMenuItem
            // 
            this.convertDatesToStandardFormatToolStripMenuItem.Name = "convertDatesToStandardFormatToolStripMenuItem";
            this.convertDatesToStandardFormatToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.convertDatesToStandardFormatToolStripMenuItem.Text = "Convert dates to standard format";
            this.convertDatesToStandardFormatToolStripMenuItem.Click += new System.EventHandler(this.convertDatesToStandardFormatToolStripMenuItem_Click);
            // 
            // headerGuessToolStripMenuItem
            // 
            this.headerGuessToolStripMenuItem.Name = "headerGuessToolStripMenuItem";
            this.headerGuessToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.headerGuessToolStripMenuItem.Text = "Header guess";
            this.headerGuessToolStripMenuItem.Click += new System.EventHandler(this.headerGuessToolStripMenuItem_Click);
            // 
            // sortDatesToolStripMenuItem
            // 
            this.sortDatesToolStripMenuItem.Name = "sortDatesToolStripMenuItem";
            this.sortDatesToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.sortDatesToolStripMenuItem.Text = "Sort dates";
            this.sortDatesToolStripMenuItem.Click += new System.EventHandler(this.sortDatesToolStripMenuItem_Click);
            // 
            // setSelectedAsHeaderRowToolStripMenuItem
            // 
            this.setSelectedAsHeaderRowToolStripMenuItem.Name = "setSelectedAsHeaderRowToolStripMenuItem";
            this.setSelectedAsHeaderRowToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.setSelectedAsHeaderRowToolStripMenuItem.Text = "Set selected as header row";
            this.setSelectedAsHeaderRowToolStripMenuItem.Click += new System.EventHandler(this.setSelectedAsHeaderRowToolStripMenuItem_Click);
            // 
            // stripIncompleteRowsToolStripMenuItem
            // 
            this.stripIncompleteRowsToolStripMenuItem.Name = "stripIncompleteRowsToolStripMenuItem";
            this.stripIncompleteRowsToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.stripIncompleteRowsToolStripMenuItem.Text = "Strip incomplete rows";
            this.stripIncompleteRowsToolStripMenuItem.Click += new System.EventHandler(this.stripIncompleteRowsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewVaribleToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
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
            this.gLEONConverterToolStripMenuItem,
            this.testerToolStripMenuItem});
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
            // testerToolStripMenuItem
            // 
            this.testerToolStripMenuItem.Name = "testerToolStripMenuItem";
            this.testerToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.testerToolStripMenuItem.Text = "tester";
            this.testerToolStripMenuItem.Click += new System.EventHandler(this.testerToolStripMenuItem_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
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
            this.checkMeta.Location = new System.Drawing.Point(926, 672);
            this.checkMeta.Name = "checkMeta";
            this.checkMeta.Size = new System.Drawing.Size(68, 17);
            this.checkMeta.TabIndex = 29;
            this.checkMeta.Text = ".meta file";
            this.checkMeta.UseVisualStyleBackColor = true;
            // 
            // checkData
            // 
            this.checkData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkData.AutoSize = true;
            this.checkData.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkData.Checked = true;
            this.checkData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkData.Location = new System.Drawing.Point(867, 672);
            this.checkData.Name = "checkData";
            this.checkData.Size = new System.Drawing.Size(49, 17);
            this.checkData.TabIndex = 28;
            this.checkData.Text = "Data";
            this.checkData.UseVisualStyleBackColor = true;
            // 
            // btnAggregate
            // 
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
            this.panel1.Location = new System.Drawing.Point(668, 451);
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
            this.label21.ForeColor = System.Drawing.Color.Gray;
            this.label21.Location = new System.Drawing.Point(140, 8);
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
            this.label20.Location = new System.Drawing.Point(675, 603);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(133, 13);
            this.label20.TabIndex = 89;
            this.label20.Text = "Text to append to filename";
            // 
            // txtFileNameAppend
            // 
            this.txtFileNameAppend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileNameAppend.Location = new System.Drawing.Point(678, 619);
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
            this.checkExportEmpty.Location = new System.Drawing.Point(668, 672);
            this.checkExportEmpty.Name = "checkExportEmpty";
            this.checkExportEmpty.Size = new System.Drawing.Size(116, 17);
            this.checkExportEmpty.TabIndex = 27;
            this.checkExportEmpty.Text = "Include empty lines";
            this.checkExportEmpty.UseVisualStyleBackColor = true;
            // 
            // btnLoadAllHeaders
            // 
            this.btnLoadAllHeaders.Location = new System.Drawing.Point(131, 27);
            this.btnLoadAllHeaders.Name = "btnLoadAllHeaders";
            this.btnLoadAllHeaders.Size = new System.Drawing.Size(93, 23);
            this.btnLoadAllHeaders.TabIndex = 4;
            this.btnLoadAllHeaders.Text = "Load all headers";
            this.btnLoadAllHeaders.UseVisualStyleBackColor = true;
            this.btnLoadAllHeaders.Click += new System.EventHandler(this.btnLoadAllHeaders_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtContactEmail);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.txtElevation);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtSiteNotes);
            this.panel2.Controls.Add(this.label9);
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
            this.panel2.Controls.Add(this.comboCountries);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(668, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 314);
            this.panel2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(27, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 92;
            this.label3.Text = ".meta information";
            // 
            // txtContactEmail
            // 
            this.txtContactEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContactEmail.Location = new System.Drawing.Point(91, 154);
            this.txtContactEmail.Name = "txtContactEmail";
            this.txtContactEmail.Size = new System.Drawing.Size(224, 20);
            this.txtContactEmail.TabIndex = 11;
            this.txtContactEmail.TextChanged += new System.EventHandler(this.txtContactEmail_TextChanged);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 157);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(71, 13);
            this.label22.TabIndex = 90;
            this.label22.Text = "Contact email";
            // 
            // txtElevation
            // 
            this.txtElevation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtElevation.Location = new System.Drawing.Point(276, 177);
            this.txtElevation.Name = "txtElevation";
            this.txtElevation.Size = new System.Drawing.Size(39, 20);
            this.txtElevation.TabIndex = 12;
            this.txtElevation.TextChanged += new System.EventHandler(this.txtElevation_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 89;
            this.label8.Text = "Site notes";
            // 
            // txtSiteNotes
            // 
            this.txtSiteNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSiteNotes.Location = new System.Drawing.Point(10, 236);
            this.txtSiteNotes.Multiline = true;
            this.txtSiteNotes.Name = "txtSiteNotes";
            this.txtSiteNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSiteNotes.Size = new System.Drawing.Size(306, 73);
            this.txtSiteNotes.TabIndex = 15;
            this.txtSiteNotes.TextChanged += new System.EventHandler(this.txtSiteNotes_TextChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 87;
            this.label9.Text = "Elevation (masl)";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(160, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 86;
            this.label10.Text = "GPS long";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 85;
            this.label11.Text = "GPS lat";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 84;
            this.label12.Text = "Contact number";
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContactNumber.Location = new System.Drawing.Point(91, 128);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(224, 20);
            this.txtContactNumber.TabIndex = 10;
            this.txtContactNumber.TextChanged += new System.EventHandler(this.txtContactNumber_TextChanged);
            // 
            // txtGPSLat
            // 
            this.txtGPSLat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGPSLat.Location = new System.Drawing.Point(51, 201);
            this.txtGPSLat.Name = "txtGPSLat";
            this.txtGPSLat.Size = new System.Drawing.Size(99, 20);
            this.txtGPSLat.TabIndex = 13;
            this.txtGPSLat.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtGPSLat_MouseClick);
            this.txtGPSLat.TextChanged += new System.EventHandler(this.txtGPSLat_TextChanged);
            // 
            // txtGPSLong
            // 
            this.txtGPSLong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGPSLong.Location = new System.Drawing.Point(218, 201);
            this.txtGPSLong.Name = "txtGPSLong";
            this.txtGPSLong.Size = new System.Drawing.Size(97, 20);
            this.txtGPSLong.TabIndex = 14;
            this.txtGPSLong.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtGPSLong_MouseClick);
            this.txtGPSLong.TextChanged += new System.EventHandler(this.txtGPSLong_TextChanged);
            // 
            // txtContactName
            // 
            this.txtContactName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContactName.Location = new System.Drawing.Point(91, 102);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(224, 20);
            this.txtContactName.TabIndex = 9;
            this.txtContactName.TextChanged += new System.EventHandler(this.txtContactName_TextChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 105);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 13);
            this.label13.TabIndex = 78;
            this.label13.Text = "Contact name";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 77;
            this.label14.Text = "Site manager";
            // 
            // txtOwner
            // 
            this.txtOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwner.Location = new System.Drawing.Point(91, 76);
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
            // comboCountries
            // 
            this.comboCountries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboCountries.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboCountries.FormattingEnabled = true;
            this.comboCountries.Location = new System.Drawing.Point(91, 53);
            this.comboCountries.Name = "comboCountries";
            this.comboCountries.Size = new System.Drawing.Size(224, 21);
            this.comboCountries.TabIndex = 7;
            this.comboCountries.TextChanged += new System.EventHandler(this.comboCountries_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Country";
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
            this.label5.Location = new System.Drawing.Point(897, 603);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 96;
            this.label5.Text = "File type";
            // 
            // comboFileExtension
            // 
            this.comboFileExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboFileExtension.FormattingEnabled = true;
            this.comboFileExtension.Location = new System.Drawing.Point(900, 619);
            this.comboFileExtension.Name = "comboFileExtension";
            this.comboFileExtension.Size = new System.Drawing.Size(94, 21);
            this.comboFileExtension.TabIndex = 26;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(816, 673);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(45, 13);
            this.label23.TabIndex = 97;
            this.label23.Text = "Include:";
            // 
            // btnSetToEmpty
            // 
            this.btnSetToEmpty.Location = new System.Drawing.Point(579, 27);
            this.btnSetToEmpty.Name = "btnSetToEmpty";
            this.btnSetToEmpty.Size = new System.Drawing.Size(80, 23);
            this.btnSetToEmpty.TabIndex = 98;
            this.btnSetToEmpty.Text = "Set as empty";
            this.btnSetToEmpty.UseVisualStyleBackColor = true;
            this.btnSetToEmpty.Click += new System.EventHandler(this.btnSetToEmpty_Click);
            // 
            // txtSetToEmpty
            // 
            this.txtSetToEmpty.Location = new System.Drawing.Point(456, 29);
            this.txtSetToEmpty.Name = "txtSetToEmpty";
            this.txtSetToEmpty.Size = new System.Drawing.Size(117, 20);
            this.txtSetToEmpty.TabIndex = 99;
            // 
            // markIncompleteRowsToolStripMenuItem
            // 
            this.markIncompleteRowsToolStripMenuItem.Name = "markIncompleteRowsToolStripMenuItem";
            this.markIncompleteRowsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.markIncompleteRowsToolStripMenuItem.Text = "mark incomplete rows";
            this.markIncompleteRowsToolStripMenuItem.Click += new System.EventHandler(this.markIncompleteRowsToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.txtSetToEmpty);
            this.Controls.Add(this.btnSetToEmpty);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboFileExtension);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnLoadAllHeaders);
            this.Controls.Add(this.checkExportEmpty);
            this.Controls.Add(this.txtFileNameAppend);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkData);
            this.Controls.Add(this.checkMeta);
            this.Controls.Add(this.comboEmpty);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btdMergeDateTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDataSetNotes);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.panelVariableControls);
            this.Controls.Add(this.dataViewer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "FrmMain";
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
        private System.Windows.Forms.Button btdMergeDateTime;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertDatesToStandardFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem headerGuessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSiteInfoToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLEONConverterToolStripMenuItem;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtFileNameAppend;
        private System.Windows.Forms.CheckBox checkExportEmpty;
        private System.Windows.Forms.ToolStripMenuItem sortDatesToolStripMenuItem;
        private System.Windows.Forms.Button btnLoadAllHeaders;
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
        private System.Windows.Forms.ComboBox comboCountries;
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
        private System.Windows.Forms.ToolStripMenuItem setSelectedAsHeaderRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stripIncompleteRowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveHeadersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadHeadersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadInMetaFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markIncompleteRowsToolStripMenuItem;
    }
}

