namespace DinamapN
{
    partial class frmInit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInit));
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle01 = new System.Windows.Forms.Label();
            this.pnlPanel01 = new System.Windows.Forms.Panel();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.lblName02 = new System.Windows.Forms.Label();
            this.lblName01 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStudy = new System.Windows.Forms.Button();
            this.chkBoxURI = new System.Windows.Forms.CheckBox();
            this.pnlPanel02 = new System.Windows.Forms.Panel();
            this.cmdURL = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblURI = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.pnlPanel01.SuspendLayout();
            this.pnlPanel02.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgLogo
            // 
            this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
            this.imgLogo.Location = new System.Drawing.Point(-1, 12);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(503, 78);
            this.imgLogo.TabIndex = 0;
            this.imgLogo.TabStop = false;
            // 
            // lblTitle01
            // 
            this.lblTitle01.AutoSize = true;
            this.lblTitle01.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle01.Location = new System.Drawing.Point(107, 93);
            this.lblTitle01.Name = "lblTitle01";
            this.lblTitle01.Size = new System.Drawing.Size(278, 18);
            this.lblTitle01.TabIndex = 1;
            this.lblTitle01.Text = "Dinamap - Monitoring Program";
            // 
            // pnlPanel01
            // 
            this.pnlPanel01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPanel01.Controls.Add(this.txtLName);
            this.pnlPanel01.Controls.Add(this.txtFName);
            this.pnlPanel01.Controls.Add(this.lblName02);
            this.pnlPanel01.Controls.Add(this.lblName01);
            this.pnlPanel01.Location = new System.Drawing.Point(396, 148);
            this.pnlPanel01.Name = "pnlPanel01";
            this.pnlPanel01.Size = new System.Drawing.Size(280, 62);
            this.pnlPanel01.TabIndex = 4;
            // 
            // txtLName
            // 
            this.txtLName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLName.Location = new System.Drawing.Point(93, 31);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(176, 22);
            this.txtLName.TabIndex = 7;
            // 
            // txtFName
            // 
            this.txtFName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFName.Location = new System.Drawing.Point(93, 3);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(176, 22);
            this.txtFName.TabIndex = 6;
            // 
            // lblName02
            // 
            this.lblName02.AutoSize = true;
            this.lblName02.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName02.Location = new System.Drawing.Point(7, 32);
            this.lblName02.Name = "lblName02";
            this.lblName02.Size = new System.Drawing.Size(88, 16);
            this.lblName02.TabIndex = 5;
            this.lblName02.Text = "Last Name: ";
            // 
            // lblName01
            // 
            this.lblName01.AutoSize = true;
            this.lblName01.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName01.Location = new System.Drawing.Point(7, 4);
            this.lblName01.Name = "lblName01";
            this.lblName01.Size = new System.Drawing.Size(89, 16);
            this.lblName01.TabIndex = 4;
            this.lblName01.Text = "First Name: ";
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(419, 230);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(62, 29);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStudy
            // 
            this.btnStudy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStudy.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudy.Location = new System.Drawing.Point(35, 230);
            this.btnStudy.Name = "btnStudy";
            this.btnStudy.Size = new System.Drawing.Size(208, 29);
            this.btnStudy.TabIndex = 6;
            this.btnStudy.Text = "Proceed with Study";
            this.btnStudy.UseVisualStyleBackColor = true;
            this.btnStudy.Click += new System.EventHandler(this.btnStudy_Click);
            // 
            // chkBoxURI
            // 
            this.chkBoxURI.AutoSize = true;
            this.chkBoxURI.Checked = true;
            this.chkBoxURI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxURI.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxURI.Location = new System.Drawing.Point(191, 124);
            this.chkBoxURI.Name = "chkBoxURI";
            this.chkBoxURI.Size = new System.Drawing.Size(114, 18);
            this.chkBoxURI.TabIndex = 7;
            this.chkBoxURI.Text = "Automatic URI";
            this.chkBoxURI.UseVisualStyleBackColor = true;
            this.chkBoxURI.CheckedChanged += new System.EventHandler(this.chkBoxURI_CheckedChanged);
            // 
            // pnlPanel02
            // 
            this.pnlPanel02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPanel02.Controls.Add(this.cmdURL);
            this.pnlPanel02.Controls.Add(this.textBox2);
            this.pnlPanel02.Controls.Add(this.lblURI);
            this.pnlPanel02.Location = new System.Drawing.Point(110, 148);
            this.pnlPanel02.Name = "pnlPanel02";
            this.pnlPanel02.Size = new System.Drawing.Size(280, 62);
            this.pnlPanel02.TabIndex = 8;
            // 
            // cmdURL
            // 
            this.cmdURL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdURL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdURL.Location = new System.Drawing.Point(219, 4);
            this.cmdURL.Name = "cmdURL";
            this.cmdURL.Size = new System.Drawing.Size(39, 16);
            this.cmdURL.TabIndex = 7;
            this.cmdURL.Text = "URL";
            this.cmdURL.UseVisualStyleBackColor = true;
            this.cmdURL.Click += new System.EventHandler(this.cmdURL_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(10, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(259, 22);
            this.textBox2.TabIndex = 6;
            // 
            // lblURI
            // 
            this.lblURI.AutoSize = true;
            this.lblURI.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblURI.Location = new System.Drawing.Point(7, 4);
            this.lblURI.Name = "lblURI";
            this.lblURI.Size = new System.Drawing.Size(191, 16);
            this.lblURI.TabIndex = 4;
            this.lblURI.Text = "Unique Record Identify URI:";
            // 
            // frmInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 270);
            this.ControlBox = false;
            this.Controls.Add(this.pnlPanel02);
            this.Controls.Add(this.chkBoxURI);
            this.Controls.Add(this.pnlPanel01);
            this.Controls.Add(this.btnStudy);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTitle01);
            this.Controls.Add(this.imgLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInit";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.frmInit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.pnlPanel01.ResumeLayout(false);
            this.pnlPanel01.PerformLayout();
            this.pnlPanel02.ResumeLayout(false);
            this.pnlPanel02.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.Label lblTitle01;
        private System.Windows.Forms.Panel pnlPanel01;
        private System.Windows.Forms.Label lblName02;
        private System.Windows.Forms.Label lblName01;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStudy;
        private System.Windows.Forms.CheckBox chkBoxURI;
        private System.Windows.Forms.Panel pnlPanel02;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblURI;
        private System.Windows.Forms.Button cmdURL;
    }
}

