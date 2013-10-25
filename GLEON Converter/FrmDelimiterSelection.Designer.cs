namespace WindowsFormsApplication1
{
    partial class FrmDelimiterSelection
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
            this.dataTemp = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboDelimiters = new System.Windows.Forms.ComboBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.checkBoxRowStripping = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUnitRow = new System.Windows.Forms.Button();
            this.btnHeaderRow = new System.Windows.Forms.Button();
            this.euroFormatCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // dataTemp
            // 
            this.dataTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTemp.Location = new System.Drawing.Point(12, 52);
            this.dataTemp.Name = "dataTemp";
            this.dataTemp.Size = new System.Drawing.Size(612, 403);
            this.dataTemp.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please Select File Delimiter";
            // 
            // comboDelimiters
            // 
            this.comboDelimiters.FormattingEnabled = true;
            this.comboDelimiters.Location = new System.Drawing.Point(150, 25);
            this.comboDelimiters.Name = "comboDelimiters";
            this.comboDelimiters.Size = new System.Drawing.Size(134, 21);
            this.comboDelimiters.TabIndex = 2;
            this.comboDelimiters.SelectedIndexChanged += new System.EventHandler(this.comboDelimiters_SelectedIndexChanged);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(549, 461);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(290, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "OR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Enter a custom file delimiter";
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Location = new System.Drawing.Point(389, 28);
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(25, 20);
            this.txtDelimiter.TabIndex = 6;
            this.txtDelimiter.TextChanged += new System.EventHandler(this.txtDelimiter_TextChanged);
            // 
            // checkBoxRowStripping
            // 
            this.checkBoxRowStripping.AutoSize = true;
            this.checkBoxRowStripping.Location = new System.Drawing.Point(464, 31);
            this.checkBoxRowStripping.Name = "checkBoxRowStripping";
            this.checkBoxRowStripping.Size = new System.Drawing.Size(160, 17);
            this.checkBoxRowStripping.TabIndex = 7;
            this.checkBoxRowStripping.Text = "Strip incomplete rows shown";
            this.checkBoxRowStripping.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUnitRow
            // 
            this.btnUnitRow.Location = new System.Drawing.Point(332, 461);
            this.btnUnitRow.Name = "btnUnitRow";
            this.btnUnitRow.Size = new System.Drawing.Size(116, 23);
            this.btnUnitRow.TabIndex = 10;
            this.btnUnitRow.Text = "Unit Row (optional)";
            this.btnUnitRow.UseVisualStyleBackColor = true;
            this.btnUnitRow.Click += new System.EventHandler(this.btnUnitRow_Click);
            // 
            // btnHeaderRow
            // 
            this.btnHeaderRow.BackColor = System.Drawing.Color.OrangeRed;
            this.btnHeaderRow.ForeColor = System.Drawing.Color.Black;
            this.btnHeaderRow.Location = new System.Drawing.Point(168, 461);
            this.btnHeaderRow.Name = "btnHeaderRow";
            this.btnHeaderRow.Size = new System.Drawing.Size(116, 23);
            this.btnHeaderRow.TabIndex = 11;
            this.btnHeaderRow.Text = "Set Header Row";
            this.btnHeaderRow.UseVisualStyleBackColor = false;
            this.btnHeaderRow.Click += new System.EventHandler(this.btnHeaderRow_Click);
            // 
            // euroFormatCheckBox
            // 
            this.euroFormatCheckBox.AutoSize = true;
            this.euroFormatCheckBox.Location = new System.Drawing.Point(464, 8);
            this.euroFormatCheckBox.Name = "euroFormatCheckBox";
            this.euroFormatCheckBox.Size = new System.Drawing.Size(147, 17);
            this.euroFormatCheckBox.TabIndex = 12;
            this.euroFormatCheckBox.Text = "European Number Format";
            this.euroFormatCheckBox.UseVisualStyleBackColor = true;
            // 
            // FrmDelimiterSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 495);
            this.ControlBox = false;
            this.Controls.Add(this.euroFormatCheckBox);
            this.Controls.Add(this.btnHeaderRow);
            this.Controls.Add(this.btnUnitRow);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.checkBoxRowStripping);
            this.Controls.Add(this.txtDelimiter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.comboDelimiters);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataTemp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmDelimiterSelection";
            this.Text = "Select Delimiter";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTemp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataTemp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboDelimiters;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDelimiter;
        private System.Windows.Forms.CheckBox checkBoxRowStripping;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUnitRow;
        private System.Windows.Forms.Button btnHeaderRow;
        private System.Windows.Forms.CheckBox euroFormatCheckBox;
    }
}