using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DinamapN
{
    
    public partial class frmMeasurement : Form
    {
        //Variable Global
        int nRegister;
        
        
        public frmMeasurement()
        {
            InitializeComponent();
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            string min = comboBox1.SelectedItem.ToString();
            string sec = comboBox2.SelectedItem.ToString();
           
            if (min == "Min" || sec == "Sec" || (min == "0" && sec == "0"))
            {
                MessageBox.Show("The interval must be set before measurements can be taken.");
                panel4.BackColor = System.Drawing.Color.IndianRed;
            }
            else
	        {
                int interval = Convert.ToInt32(min) * 60 * 1000 + Convert.ToInt32(sec) * 1000;
                MessageBox.Show(interval.ToString());
                timer1.Interval = interval;
                timer1.Start();
                cmdStart.Enabled = false;
                cmdStop.Enabled = true;
                panel4.BackColor = SystemColors.Control;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();

            nRegister++;
            
            this.mGrid.Rows.Add(lblTime.Text, random.Next(250), random.Next(250), random.Next(250), txtComment.Text.ToString());
            lblNum.Text = nRegister.ToString();        
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            cmdStop.Enabled = false;
            cmdStart.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
        }

        private void frmMeasurement_Load(object sender, EventArgs e)
        {
            //Image imgStart = Image.FromFile("C:\\Users\\dlugokja\\Documents\\Downloads\\Knob_Buttons_Toolbar_icons_by_iTweek\\knobs\\PNG\\Knob Play Green.png");
            //cmdStart.Image = imgStart;

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            cmdStart.Enabled = true;
            cmdStop.Enabled = false;
            nRegister = 0;
        }

        private void sysTime_Tick(object sender, EventArgs e)
        {
            string szHour;
            szHour = DateTime.Now.ToString("hh:mm:ss");
            lblTime.Text = szHour;
        }

        private void frmMeasurement_Activated(object sender, System.EventArgs e)
        {
            sysTime.Start();
        }

        private void frmMeasurement_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}