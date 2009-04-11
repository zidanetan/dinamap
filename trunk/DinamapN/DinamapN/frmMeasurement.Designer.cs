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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMeasurement));
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelUpload = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelNumSuccessful = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelNumFailed = new System.Windows.Forms.ToolStripStatusLabel();
            this.mGrid = new System.Windows.Forms.DataGridView();
            this.Upload = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueUploaded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.measurementTimer = new System.Windows.Forms.Timer(this.components);
            this.sysTimer = new System.Windows.Forms.Timer(this.components);
            this.Uploaded = new System.Windows.Forms.DataGridViewImageColumn();
            this.timePanel = new System.Windows.Forms.Panel();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dinamapConnectedCheckBox = new System.Windows.Forms.CheckBox();
            this.headPanel = new System.Windows.Forms.Panel();
            this.lblTitle01 = new System.Windows.Forms.Label();
            this.bodyPanel.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mGrid)).BeginInit();
            this.timePanel.SuspendLayout();
            this.headPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bodyPanel
            // 
            this.bodyPanel.AutoSize = true;
            this.bodyPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bodyPanel.Controls.Add(this.statusStrip2);
            this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bodyPanel.Location = new System.Drawing.Point(0, 351);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(757, 22);
            this.bodyPanel.TabIndex = 0;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelUpload,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabelNumSuccessful,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabelNumFailed});
            this.statusStrip2.Location = new System.Drawing.Point(0, 0);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(757, 22);
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
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(111, 17);
            this.toolStripStatusLabel5.Text = "Successful Uploads:";
            // 
            // toolStripStatusLabelNumSuccessful
            // 
            this.toolStripStatusLabelNumSuccessful.Name = "toolStripStatusLabelNumSuccessful";
            this.toolStripStatusLabelNumSuccessful.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabelNumSuccessful.Text = "__";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(87, 17);
            this.toolStripStatusLabel7.Text = "Failed Uploads:";
            // 
            // toolStripStatusLabelNumFailed
            // 
            this.toolStripStatusLabelNumFailed.Name = "toolStripStatusLabelNumFailed";
            this.toolStripStatusLabelNumFailed.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabelNumFailed.Text = "__";
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
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mGrid.DefaultCellStyle = dataGridViewCellStyle14;
            this.mGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.mGrid.Location = new System.Drawing.Point(8, 120);
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
            this.mGrid.Size = new System.Drawing.Size(742, 228);
            this.mGrid.TabIndex = 0;
            this.mGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.mGrid_CellEndEdit);
            this.mGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mGrid_CellClick);
            this.mGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mGrid_CellContentClick);
            // 
            // Upload
            // 
            this.Upload.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Upload.HeaderText = "";
            this.Upload.MinimumWidth = 20;
            this.Upload.Name = "Upload";
            this.Upload.ReadOnly = true;
            this.Upload.Width = 20;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Time";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
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
            this.Column5.Width = 400;
            // 
            // ValueUploaded
            // 
            this.ValueUploaded.DataPropertyName = "(none)";
            this.ValueUploaded.HeaderText = "ValueUploaded";
            this.ValueUploaded.Name = "ValueUploaded";
            this.ValueUploaded.ReadOnly = true;
            this.ValueUploaded.Visible = false;
            this.ValueUploaded.Width = 400;
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
            // timePanel
            // 
            this.timePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.timePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timePanel.Controls.Add(this.lblNum);
            this.timePanel.Controls.Add(this.lblTime);
            this.timePanel.Controls.Add(this.label2);
            this.timePanel.Controls.Add(this.label1);
            this.timePanel.Location = new System.Drawing.Point(76, 53);
            this.timePanel.Name = "timePanel";
            this.timePanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.timePanel.Size = new System.Drawing.Size(507, 32);
            this.timePanel.TabIndex = 2;
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNum.Location = new System.Drawing.Point(457, 6);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(19, 18);
            this.lblNum.TabIndex = 3;
            this.lblNum.Text = "0";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTime.Location = new System.Drawing.Point(133, 6);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(86, 18);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "00:00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(297, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Measurements:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Time:";
            // 
            // cmdStart
            // 
            this.cmdStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdStart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.cmdStart.FlatAppearance.BorderSize = 10;
            this.cmdStart.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdStart.Image = ((System.Drawing.Image)(resources.GetObject("cmdStart.Image")));
            this.cmdStart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdStart.Location = new System.Drawing.Point(663, 17);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 32);
            this.cmdStart.TabIndex = 3;
            this.cmdStart.Text = "Start";
            this.cmdStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdStart.UseMnemonic = false;
            this.cmdStart.UseVisualStyleBackColor = false;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmdStop.Enabled = false;
            this.cmdStop.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdStop.Image = ((System.Drawing.Image)(resources.GetObject("cmdStop.Image")));
            this.cmdStop.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdStop.Location = new System.Drawing.Point(663, 55);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(75, 32);
            this.cmdStop.TabIndex = 4;
            this.cmdStop.Text = "Stop";
            this.cmdStop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdStop.UseVisualStyleBackColor = false;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(375, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(331, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Enter comments after measurements are loaded ";
            // 
            // dinamapConnectedCheckBox
            // 
            this.dinamapConnectedCheckBox.AutoSize = true;
            this.dinamapConnectedCheckBox.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.dinamapConnectedCheckBox.Location = new System.Drawing.Point(25, 90);
            this.dinamapConnectedCheckBox.Name = "dinamapConnectedCheckBox";
            this.dinamapConnectedCheckBox.Size = new System.Drawing.Size(164, 20);
            this.dinamapConnectedCheckBox.TabIndex = 11;
            this.dinamapConnectedCheckBox.Text = "Dinamap connected?";
            this.dinamapConnectedCheckBox.UseVisualStyleBackColor = true;
            // 
            // headPanel
            // 
            this.headPanel.AutoSize = true;
            this.headPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headPanel.BackColor = System.Drawing.SystemColors.Control;
            this.headPanel.Controls.Add(this.lblTitle01);
            this.headPanel.Controls.Add(this.dinamapConnectedCheckBox);
            this.headPanel.Controls.Add(this.label6);
            this.headPanel.Controls.Add(this.cmdStop);
            this.headPanel.Controls.Add(this.cmdStart);
            this.headPanel.Controls.Add(this.timePanel);
            this.headPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headPanel.Location = new System.Drawing.Point(0, 0);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(757, 113);
            this.headPanel.TabIndex = 1;
            // 
            // lblTitle01
            // 
            this.lblTitle01.AutoSize = true;
            this.lblTitle01.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle01.Location = new System.Drawing.Point(157, 17);
            this.lblTitle01.Name = "lblTitle01";
            this.lblTitle01.Size = new System.Drawing.Size(344, 23);
            this.lblTitle01.TabIndex = 12;
            this.lblTitle01.Text = "Dinamap - Monitoring Program";
            // 
            // frmMeasurement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(757, 373);
            this.Controls.Add(this.mGrid);
            this.Controls.Add(this.bodyPanel);
            this.Controls.Add(this.headPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMeasurement";
            this.Text = "Scan Measurement";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMeasurement_Load);
            this.bodyPanel.ResumeLayout(false);
            this.bodyPanel.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mGrid)).EndInit();
            this.timePanel.ResumeLayout(false);
            this.timePanel.PerformLayout();
            this.headPanel.ResumeLayout(false);
            this.headPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.Timer measurementTimer;
        private System.Windows.Forms.Timer sysTimer;

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
        private System.Windows.Forms.Panel timePanel;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox dinamapConnectedCheckBox;
        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Label lblTitle01;
    }
}