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
            this.lblTitle01 = new System.Windows.Forms.Label();
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.txtStudyID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStudy = new System.Windows.Forms.Button();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle01
            // 
            this.lblTitle01.AutoSize = true;
            this.lblTitle01.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle01.Location = new System.Drawing.Point(85, 77);
            this.lblTitle01.Name = "lblTitle01";
            this.lblTitle01.Size = new System.Drawing.Size(344, 23);
            this.lblTitle01.TabIndex = 1;
            this.lblTitle01.Text = "Dinamap - Monitoring Program";
            // 
            // txtPatientID
            // 
            this.txtPatientID.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientID.Location = new System.Drawing.Point(226, 152);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(148, 23);
            this.txtPatientID.TabIndex = 7;
            // 
            // txtStudyID
            // 
            this.txtStudyID.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudyID.Location = new System.Drawing.Point(226, 189);
            this.txtStudyID.Name = "txtStudyID";
            this.txtStudyID.Size = new System.Drawing.Size(148, 23);
            this.txtStudyID.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Patient ID: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(136, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Study ID: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(128, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Enter required information:";
            // 
            // btnStudy
            // 
            this.btnStudy.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudy.Image = ((System.Drawing.Image)(resources.GetObject("btnStudy.Image")));
            this.btnStudy.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStudy.Location = new System.Drawing.Point(215, 233);
            this.btnStudy.Name = "btnStudy";
            this.btnStudy.Padding = new System.Windows.Forms.Padding(3);
            this.btnStudy.Size = new System.Drawing.Size(214, 46);
            this.btnStudy.TabIndex = 6;
            this.btnStudy.Text = "Proceed with Study";
            this.btnStudy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudy.UseVisualStyleBackColor = true;
            this.btnStudy.Click += new System.EventHandler(this.btnStudy_Click);
            // 
            // imgLogo
            // 
            this.imgLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
            this.imgLogo.Location = new System.Drawing.Point(0, -1);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(497, 75);
            this.imgLogo.TabIndex = 0;
            this.imgLogo.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(89, 234);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(3);
            this.button1.Size = new System.Drawing.Size(104, 45);
            this.button1.TabIndex = 12;
            this.button1.Text = "Back";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(496, 291);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStudyID);
            this.Controls.Add(this.txtPatientID);
            this.Controls.Add(this.btnStudy);
            this.Controls.Add(this.lblTitle01);
            this.Controls.Add(this.imgLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.Load += new System.EventHandler(this.frmInit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.Label lblTitle01;
        private System.Windows.Forms.Button btnStudy;
        private System.Windows.Forms.TextBox txtPatientID;
        private System.Windows.Forms.TextBox txtStudyID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}

