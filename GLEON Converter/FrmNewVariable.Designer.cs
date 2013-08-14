namespace WindowsFormsApplication1
{
    partial class FrmNewVariable
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtVariableName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVariableCode = new System.Windows.Forms.TextBox();
            this.txtUnits1 = new System.Windows.Forms.TextBox();
            this.txtUnits2 = new System.Windows.Forms.TextBox();
            this.panelUnits = new System.Windows.Forms.Panel();
            this.btnMoreUnits = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelUnits.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Variable Name";
            // 
            // txtVariableName
            // 
            this.txtVariableName.Location = new System.Drawing.Point(129, 6);
            this.txtVariableName.Name = "txtVariableName";
            this.txtVariableName.Size = new System.Drawing.Size(100, 20);
            this.txtVariableName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Variable Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Recommended Unit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Secondary Units";
            // 
            // txtVariableCode
            // 
            this.txtVariableCode.Location = new System.Drawing.Point(129, 32);
            this.txtVariableCode.Name = "txtVariableCode";
            this.txtVariableCode.Size = new System.Drawing.Size(100, 20);
            this.txtVariableCode.TabIndex = 9;
            this.txtVariableCode.TextChanged += new System.EventHandler(this.txtVariableCode_TextChanged);
            // 
            // txtUnits1
            // 
            this.txtUnits1.Location = new System.Drawing.Point(117, 0);
            this.txtUnits1.Name = "txtUnits1";
            this.txtUnits1.Size = new System.Drawing.Size(100, 20);
            this.txtUnits1.TabIndex = 10;
            // 
            // txtUnits2
            // 
            this.txtUnits2.Location = new System.Drawing.Point(117, 26);
            this.txtUnits2.Name = "txtUnits2";
            this.txtUnits2.Size = new System.Drawing.Size(100, 20);
            this.txtUnits2.TabIndex = 11;
            // 
            // panelUnits
            // 
            this.panelUnits.Controls.Add(this.btnMoreUnits);
            this.panelUnits.Controls.Add(this.label3);
            this.panelUnits.Controls.Add(this.txtUnits2);
            this.panelUnits.Controls.Add(this.label4);
            this.panelUnits.Controls.Add(this.txtUnits1);
            this.panelUnits.Location = new System.Drawing.Point(12, 58);
            this.panelUnits.Name = "panelUnits";
            this.panelUnits.Size = new System.Drawing.Size(234, 82);
            this.panelUnits.TabIndex = 12;
            // 
            // btnMoreUnits
            // 
            this.btnMoreUnits.Location = new System.Drawing.Point(117, 52);
            this.btnMoreUnits.Name = "btnMoreUnits";
            this.btnMoreUnits.Size = new System.Drawing.Size(100, 23);
            this.btnMoreUnits.TabIndex = 12;
            this.btnMoreUnits.Text = "More Units";
            this.btnMoreUnits.UseVisualStyleBackColor = true;
            this.btnMoreUnits.Click += new System.EventHandler(this.btnMoreUnits_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(141, 148);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 23);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add New Variable";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(12, 148);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmNewVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 183);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panelUnits);
            this.Controls.Add(this.txtVariableCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVariableName);
            this.Controls.Add(this.label1);
            this.Name = "FrmNewVariable";
            this.Text = "Add New Variable";
            this.panelUnits.ResumeLayout(false);
            this.panelUnits.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVariableName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVariableCode;
        private System.Windows.Forms.TextBox txtUnits1;
        private System.Windows.Forms.TextBox txtUnits2;
        private System.Windows.Forms.Panel panelUnits;
        private System.Windows.Forms.Button btnMoreUnits;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
    }
}