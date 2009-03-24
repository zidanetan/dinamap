namespace DinamapN
{
    partial class frmMeasurement
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMeasurement));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelUpload = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelNumSuccessful = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelNumFailed = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.idPanel = new System.Windows.Forms.Panel();
            this.lblStudyID = new System.Windows.Forms.Label();
            this.lblPatientID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdStop = new System.Windows.Forms.Button();
            this.cmdStart = new System.Windows.Forms.Button();
            this.timePanel = new System.Windows.Forms.Panel();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnComment = new System.Windows.Forms.Button();
            this.measurementTimer = new System.Windows.Forms.Timer(this.components);
            this.sysTimer = new System.Windows.Forms.Timer(this.components);
            this.mGrid = new System.Windows.Forms.DataGridView();
            this.Upload = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueUploaded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uploaded = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.idPanel.SuspendLayout();
            this.timePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.statusStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 310);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 297);
            this.panel1.TabIndex = 0;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelUpload,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabelNumSuccessful,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabelNumFailed});
            this.statusStrip2.Location = new System.Drawing.Point(0, 275);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(772, 22);
            this.statusStrip2.TabIndex = 3;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabelUpload
            // 
            this.toolStripStatusLabelUpload.Name = "toolStripStatusLabelUpload";
            this.toolStripStatusLabelUpload.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(102, 17);
            this.toolStripStatusLabel5.Text = "Successful Uploads:";
            this.toolStripStatusLabel5.Click += new System.EventHandler(this.toolStripStatusLabel5_Click);
            // 
            // toolStripStatusLabelNumSuccessful
            // 
            this.toolStripStatusLabelNumSuccessful.Name = "toolStripStatusLabelNumSuccessful";
            this.toolStripStatusLabelNumSuccessful.Size = new System.Drawing.Size(19, 17);
            this.toolStripStatusLabelNumSuccessful.Text = "__";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel7.Text = "Failed Uploads:";
            // 
            // toolStripStatusLabelNumFailed
            // 
            this.toolStripStatusLabelNumFailed.Name = "toolStripStatusLabelNumFailed";
            this.toolStripStatusLabelNumFailed.Size = new System.Drawing.Size(19, 17);
            this.toolStripStatusLabelNumFailed.Text = "__";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.idPanel);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cmdStop);
            this.panel2.Controls.Add(this.cmdStart);
            this.panel2.Controls.Add(this.timePanel);
            this.panel2.Controls.Add(this.txtComment);
            this.panel2.Controls.Add(this.btnComment);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(772, 143);
            this.panel2.TabIndex = 1;
            // 
            // idPanel
            // 
            this.idPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.idPanel.Controls.Add(this.lblStudyID);
            this.idPanel.Controls.Add(this.lblPatientID);
            this.idPanel.Controls.Add(this.label7);
            this.idPanel.Controls.Add(this.label5);
            this.idPanel.Location = new System.Drawing.Point(400, 17);
            this.idPanel.Name = "idPanel";
            this.idPanel.Size = new System.Drawing.Size(215, 70);
            this.idPanel.TabIndex = 10;
            // 
            // lblStudyID
            // 
            this.lblStudyID.AutoSize = true;
            this.lblStudyID.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudyID.Location = new System.Drawing.Point(90, 44);
            this.lblStudyID.Name = "lblStudyID";
            this.lblStudyID.Size = new System.Drawing.Size(0, 14);
            this.lblStudyID.TabIndex = 14;
            // 
            // lblPatientID
            // 
            this.lblPatientID.AutoSize = true;
            this.lblPatientID.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientID.Location = new System.Drawing.Point(90, 15);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(0, 14);
            this.lblPatientID.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Patient ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Study ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(53, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Enter Comment: ";
            // 
            // cmdStop
            // 
            this.cmdStop.Enabled = false;
            this.cmdStop.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdStop.Image = ((System.Drawing.Image)(resources.GetObject("cmdStop.Image")));
            this.cmdStop.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdStop.Location = new System.Drawing.Point(675, 55);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(75, 32);
            this.cmdStop.TabIndex = 4;
            this.cmdStop.Text = "Stop";
            this.cmdStop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdStop.UseVisualStyleBackColor = true;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // cmdStart
            // 
            this.cmdStart.BackColor = System.Drawing.SystemColors.Control;
            this.cmdStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdStart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.cmdStart.FlatAppearance.BorderSize = 10;
            this.cmdStart.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdStart.Image = ((System.Drawing.Image)(resources.GetObject("cmdStart.Image")));
            this.cmdStart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdStart.Location = new System.Drawing.Point(675, 17);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 32);
            this.cmdStart.TabIndex = 3;
            this.cmdStart.Text = "Start";
            this.cmdStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdStart.UseMnemonic = false;
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // timePanel
            // 
            this.timePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.timePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.timePanel.Controls.Add(this.lblNum);
            this.timePanel.Controls.Add(this.lblTime);
            this.timePanel.Controls.Add(this.label2);
            this.timePanel.Controls.Add(this.label1);
            this.timePanel.Location = new System.Drawing.Point(55, 17);
            this.timePanel.Name = "timePanel";
            this.timePanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.timePanel.Size = new System.Drawing.Size(295, 70);
            this.timePanel.TabIndex = 2;
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum.Location = new System.Drawing.Point(181, 42);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(19, 18);
            this.lblNum.TabIndex = 3;
            this.lblNum.Text = "0";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(181, 15);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(86, 18);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "00:00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Measurements:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Time:";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(176, 110);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(439, 20);
            this.txtComment.TabIndex = 1;
            // 
            // btnComment
            // 
            this.btnComment.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComment.Location = new System.Drawing.Point(631, 106);
            this.btnComment.Name = "btnComment";
            this.btnComment.Size = new System.Drawing.Size(131, 26);
            this.btnComment.TabIndex = 0;
            this.btnComment.Text = "Add Comment";
            this.btnComment.UseVisualStyleBackColor = true;
            // 
            // measurementTimer
            // 
            this.measurementTimer.Interval = 1000;
            this.measurementTimer.Tick += new System.EventHandler(this.measurementTimer_Tick);
            // 
            // sysTimer
            // 
            this.sysTimer.Enabled = true;
            this.sysTimer.Interval = 1000;
            this.sysTimer.Tick += new System.EventHandler(this.sysTime_Tick);
            // 
            // mGrid
            // 
            this.mGrid.AllowUserToAddRows = false;
            this.mGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.mGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Upload,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.ValueUploaded});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.NullValue = " ";
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mGrid.DefaultCellStyle = dataGridViewCellStyle14;
            this.mGrid.Location = new System.Drawing.Point(1, 149);
            this.mGrid.MultiSelect = false;
            this.mGrid.Name = "mGrid";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.mGrid.RowHeadersVisible = false;
            this.mGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.mGrid.Size = new System.Drawing.Size(770, 431);
            this.mGrid.TabIndex = 0;
            this.mGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.mGrid_CellEndEdit);
            this.mGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mGrid_CellContentClick);
            // 
            // Upload
            // 
            this.Upload.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Upload.HeaderText = "";
            this.Upload.Name = "Upload";
            this.Upload.ReadOnly = true;
            this.Upload.Width = 5;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Time";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "SP";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 75;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "DP";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 75;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Pulse";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 75;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Comments";
            this.Column5.Name = "Column5";
            this.Column5.Width = 385;
            // 
            // ValueUploaded
            // 
            this.ValueUploaded.DataPropertyName = "(none)";
            this.ValueUploaded.HeaderText = "ValueUploaded";
            this.ValueUploaded.Name = "ValueUploaded";
            this.ValueUploaded.ReadOnly = true;
            this.ValueUploaded.Visible = false;
            // 
            // Uploaded
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.NullValue = " ";
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Uploaded.DefaultCellStyle = dataGridViewCellStyle16;
            this.Uploaded.HeaderText = "";
            this.Uploaded.Image = ((System.Drawing.Image)(resources.GetObject("Uploaded.Image")));
            this.Uploaded.Name = "Uploaded";
            this.Uploaded.ReadOnly = true;
            this.Uploaded.Width = 20;
            // 
            // frmMeasurement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(772, 607);
            this.Controls.Add(this.mGrid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMeasurement";
            this.Text = "Scan Measurement";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMeasurement_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.idPanel.ResumeLayout(false);
            this.idPanel.PerformLayout();
            this.timePanel.ResumeLayout(false);
            this.timePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel timePanel;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnComment;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Timer measurementTimer;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.Timer sysTimer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel idPanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStudyID;
        private System.Windows.Forms.Label lblPatientID;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.DataGridView mGrid;
        private System.Windows.Forms.DataGridViewImageColumn Uploaded;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUpload;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelNumSuccessful;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelNumFailed;
        private System.Windows.Forms.DataGridViewImageColumn Upload;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueUploaded;
    }
}