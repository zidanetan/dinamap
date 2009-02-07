using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DinamapN
{
    public partial class frmInit : Form
    {
        private string patientID;
        private string studyID;

        public frmInit()
        {
            InitializeComponent();
        }

        private void btnStudy_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPatientID.Text != "" && txtStudyID.Text != "")
                {
                    patientID = txtPatientID.Text;
                    studyID = txtStudyID.Text;

                    Directory.CreateDirectory("C:\\" + studyID + "_" + patientID);
                    Directory.CreateDirectory("C:\\" + studyID + "_" + patientID + "\\raw_xml");
                    Directory.CreateDirectory("C:\\" + studyID + "_" + patientID + "\\queued_sql");
               
                    frmMain fMain = new frmMain(patientID, studyID);

                    this.Visible = false;
                    
                    fMain.Show();
                }
                else
                {
                    MessageBox.Show("Please enter Patient ID and Study ID.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Local directory could not be created.");
            }
        }

        private void frmInit_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmStart fStart = new frmStart();

            this.Visible = false;

            fStart.Show();
        }

        private void frmInit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}