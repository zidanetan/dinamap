namespace DinamapN
{
    partial class frmOptions
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDLL = new System.Windows.Forms.TextBox();
            this.cmdURL = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCOM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBaudRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDataBits = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtParity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStopBits = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtURL);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmdURL);
            this.panel1.Controls.Add(this.txtDLL);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 104);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtStopBits);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtParity);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtDataBits);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtBaudRate);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtCOM);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(3, 122);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(628, 195);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DLL Dinawin Ubication:";
            // 
            // txtDLL
            // 
            this.txtDLL.Location = new System.Drawing.Point(134, 12);
            this.txtDLL.Name = "txtDLL";
            this.txtDLL.Size = new System.Drawing.Size(330, 20);
            this.txtDLL.TabIndex = 1;
            // 
            // cmdURL
            // 
            this.cmdURL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdURL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdURL.Location = new System.Drawing.Point(470, 13);
            this.cmdURL.Name = "cmdURL";
            this.cmdURL.Size = new System.Drawing.Size(72, 16);
            this.cmdURL.TabIndex = 8;
            this.cmdURL.Text = "Browse...";
            this.cmdURL.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "URL Default:";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(134, 41);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(330, 20);
            this.txtURL.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(515, 323);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 29);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(3, 323);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(171, 29);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCOM
            // 
            this.txtCOM.Location = new System.Drawing.Point(95, 26);
            this.txtCOM.Name = "txtCOM";
            this.txtCOM.Size = new System.Drawing.Size(76, 20);
            this.txtCOM.TabIndex = 12;
            this.txtCOM.Text = "COM1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "COM Port:";
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.Location = new System.Drawing.Point(95, 52);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(76, 20);
            this.txtBaudRate.TabIndex = 14;
            this.txtBaudRate.Text = "9600";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Baud Rate:";
            // 
            // txtDataBits
            // 
            this.txtDataBits.Location = new System.Drawing.Point(95, 78);
            this.txtDataBits.Name = "txtDataBits";
            this.txtDataBits.Size = new System.Drawing.Size(76, 20);
            this.txtDataBits.TabIndex = 16;
            this.txtDataBits.Text = "8";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Data Bits:";
            // 
            // txtParity
            // 
            this.txtParity.Location = new System.Drawing.Point(95, 104);
            this.txtParity.Name = "txtParity";
            this.txtParity.Size = new System.Drawing.Size(76, 20);
            this.txtParity.TabIndex = 18;
            this.txtParity.Text = "None";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Parity:";
            // 
            // txtStopBits
            // 
            this.txtStopBits.Location = new System.Drawing.Point(95, 130);
            this.txtStopBits.Name = "txtStopBits";
            this.txtStopBits.Size = new System.Drawing.Size(76, 20);
            this.txtStopBits.TabIndex = 20;
            this.txtStopBits.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Stop Bits:";
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 362);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmOptions";
            this.Text = "Dinamap Options";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDLL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdURL;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtCOM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDataBits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBaudRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStopBits;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtParity;
        private System.Windows.Forms.Label label6;

    }
}