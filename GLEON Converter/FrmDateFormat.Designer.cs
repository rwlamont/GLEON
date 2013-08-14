namespace WindowsFormsApplication1
{
    partial class FrmDateFormat
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
            this.comboFirst = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIn = new System.Windows.Forms.Label();
            this.comboSecond = new System.Windows.Forms.ComboBox();
            this.comboThird = new System.Windows.Forms.ComboBox();
            this.comboFourth = new System.Windows.Forms.ComboBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblOut = new System.Windows.Forms.Label();
            this.txtCustomFormat = new System.Windows.Forms.TextBox();
            this.checkCustom = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboFirst
            // 
            this.comboFirst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFirst.FormattingEnabled = true;
            this.comboFirst.Location = new System.Drawing.Point(53, 25);
            this.comboFirst.Name = "comboFirst";
            this.comboFirst.Size = new System.Drawing.Size(83, 21);
            this.comboFirst.TabIndex = 0;
            this.comboFirst.SelectedIndexChanged += new System.EventHandler(this.comboFirst_SelectedIndexChanged);
            this.comboFirst.TextChanged += new System.EventHandler(this.comboFirst_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output:";
            // 
            // lblIn
            // 
            this.lblIn.AutoSize = true;
            this.lblIn.Location = new System.Drawing.Point(60, 9);
            this.lblIn.Name = "lblIn";
            this.lblIn.Size = new System.Drawing.Size(0, 13);
            this.lblIn.TabIndex = 3;
            // 
            // comboSecond
            // 
            this.comboSecond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSecond.FormattingEnabled = true;
            this.comboSecond.Location = new System.Drawing.Point(142, 25);
            this.comboSecond.Name = "comboSecond";
            this.comboSecond.Size = new System.Drawing.Size(83, 21);
            this.comboSecond.TabIndex = 4;
            this.comboSecond.SelectedIndexChanged += new System.EventHandler(this.comboSecond_SelectedIndexChanged);
            // 
            // comboThird
            // 
            this.comboThird.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboThird.FormattingEnabled = true;
            this.comboThird.Location = new System.Drawing.Point(231, 25);
            this.comboThird.Name = "comboThird";
            this.comboThird.Size = new System.Drawing.Size(83, 21);
            this.comboThird.TabIndex = 6;
            this.comboThird.SelectedIndexChanged += new System.EventHandler(this.comboThird_SelectedIndexChanged);
            // 
            // comboFourth
            // 
            this.comboFourth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFourth.FormattingEnabled = true;
            this.comboFourth.Location = new System.Drawing.Point(320, 25);
            this.comboFourth.Name = "comboFourth";
            this.comboFourth.Size = new System.Drawing.Size(83, 21);
            this.comboFourth.TabIndex = 7;
            this.comboFourth.SelectedIndexChanged += new System.EventHandler(this.comboFourth_SelectedIndexChanged);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(330, 86);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 8;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblOut
            // 
            this.lblOut.AutoSize = true;
            this.lblOut.Location = new System.Drawing.Point(60, 49);
            this.lblOut.Name = "lblOut";
            this.lblOut.Size = new System.Drawing.Size(0, 13);
            this.lblOut.TabIndex = 9;
            // 
            // txtCustomFormat
            // 
            this.txtCustomFormat.Location = new System.Drawing.Point(224, 88);
            this.txtCustomFormat.Name = "txtCustomFormat";
            this.txtCustomFormat.Size = new System.Drawing.Size(100, 20);
            this.txtCustomFormat.TabIndex = 10;
            this.txtCustomFormat.TextChanged += new System.EventHandler(this.txtCustomFormat_TextChanged);
            // 
            // checkCustom
            // 
            this.checkCustom.AutoSize = true;
            this.checkCustom.Location = new System.Drawing.Point(97, 90);
            this.checkCustom.Name = "checkCustom";
            this.checkCustom.Size = new System.Drawing.Size(121, 17);
            this.checkCustom.TabIndex = 12;
            this.checkCustom.Text = "Use Custom Format:";
            this.checkCustom.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmDateFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 121);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.checkCustom);
            this.Controls.Add(this.txtCustomFormat);
            this.Controls.Add(this.lblOut);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.comboFourth);
            this.Controls.Add(this.comboThird);
            this.Controls.Add(this.comboSecond);
            this.Controls.Add(this.lblIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboFirst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmDateFormat";
            this.Text = "Enter DateTime Format";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboFirst;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIn;
        private System.Windows.Forms.ComboBox comboSecond;
        private System.Windows.Forms.ComboBox comboThird;
        private System.Windows.Forms.ComboBox comboFourth;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblOut;
        private System.Windows.Forms.TextBox txtCustomFormat;
        private System.Windows.Forms.CheckBox checkCustom;
        private System.Windows.Forms.Button btnCancel;
    }
}