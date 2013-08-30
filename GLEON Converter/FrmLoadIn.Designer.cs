namespace WindowsFormsApplication1
{
    partial class FrmLoadIn
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
            this.lblData = new System.Windows.Forms.Label();
            this.lblMeta = new System.Windows.Forms.Label();
            this.txtMeta = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.btnData = new System.Windows.Forms.Button();
            this.btnMeta = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.brnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(59, 53);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(49, 13);
            this.lblData.TabIndex = 0;
            this.lblData.Text = "Data File";
            // 
            // lblMeta
            // 
            this.lblMeta.AutoSize = true;
            this.lblMeta.Location = new System.Drawing.Point(59, 130);
            this.lblMeta.Name = "lblMeta";
            this.lblMeta.Size = new System.Drawing.Size(50, 13);
            this.lblMeta.TabIndex = 1;
            this.lblMeta.Text = "Meta File";
            // 
            // txtMeta
            // 
            this.txtMeta.Location = new System.Drawing.Point(190, 123);
            this.txtMeta.Name = "txtMeta";
            this.txtMeta.Size = new System.Drawing.Size(227, 20);
            this.txtMeta.TabIndex = 2;
            this.txtMeta.Text = "C:\\Users\\rwlamont\\Documents\\meta file testdatastd.meta";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(190, 50);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(227, 20);
            this.txtData.TabIndex = 3;
            this.txtData.Text = "C:\\Users\\rwlamont\\Documents\\test.csv";
            // 
            // btnData
            // 
            this.btnData.Location = new System.Drawing.Point(434, 48);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(75, 23);
            this.btnData.TabIndex = 4;
            this.btnData.Text = "Open Data";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // btnMeta
            // 
            this.btnMeta.Location = new System.Drawing.Point(434, 121);
            this.btnMeta.Name = "btnMeta";
            this.btnMeta.Size = new System.Drawing.Size(75, 23);
            this.btnMeta.TabIndex = 5;
            this.btnMeta.Text = "Open Meta";
            this.btnMeta.UseVisualStyleBackColor = true;
            this.btnMeta.Click += new System.EventHandler(this.btnMeta_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(505, 317);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // brnCancel
            // 
            this.brnCancel.Location = new System.Drawing.Point(12, 317);
            this.brnCancel.Name = "brnCancel";
            this.brnCancel.Size = new System.Drawing.Size(75, 23);
            this.brnCancel.TabIndex = 7;
            this.brnCancel.Text = "Cancel";
            this.brnCancel.UseVisualStyleBackColor = true;
            this.brnCancel.Click += new System.EventHandler(this.brnCancel_Click);
            // 
            // FrmLoadIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 352);
            this.Controls.Add(this.brnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnMeta);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.txtMeta);
            this.Controls.Add(this.lblMeta);
            this.Controls.Add(this.lblData);
            this.Name = "FrmLoadIn";
            this.Text = "LoadIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblMeta;
        private System.Windows.Forms.TextBox txtMeta;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.Button btnMeta;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button brnCancel;
    }
}