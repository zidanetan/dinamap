using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DinamapN
{
    public partial class frmMain : Form
    {
        private string patientID;
        private string studyID;

        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(string patient, string study)
        {
            InitializeComponent();
            patientID = patient;
            studyID = study;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void scanMeasurementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMeasurement newMDIChild = new frmMeasurement();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOptions newMDIChild = new frmOptions();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout newMDIChild = new frmAbout();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();  
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Tool.Dina_CheckReadiness())
            {
                frmMeasurement newMDIChild = new frmMeasurement(patientID, studyID);

                scanMeasurementToolStripMenuItem.Enabled = true;
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
            else
            {
                frmInit fInit = new frmInit();
                this.Close();
                fInit.Show();
            }
         }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}