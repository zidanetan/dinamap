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
        public frmMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void scanMeasurementToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            try
            {
                if (Tool.checkReadiness() == false)
                {
                    MessageBox.Show("Dinamap monitor not ready.");
                    frmInit fInit = new frmInit();
                    this.Close();
                    fInit.Show();
                }
                else if (Tool.checkReadiness() == true)
                {
                    frmMeasurement newMDIChild = new frmMeasurement();

                    scanMeasurementToolStripMenuItem.Enabled = false;
                    newMDIChild.MdiParent = this;
                    newMDIChild.WindowState = FormWindowState.Maximized;
                    newMDIChild.Show(); 
                }
            }
            catch(System.DllNotFoundException ex)
            {
                MessageBox.Show("DinaWin.dll could not load.");
                frmInit fInit = new frmInit();
                this.Close();
                fInit.Show();
            }
        }
    }
}