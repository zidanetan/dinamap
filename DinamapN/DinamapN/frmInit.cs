using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DinamapN
{
    public partial class frmInit : Form
    {
        public frmInit()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStudy_Click(object sender, EventArgs e)
        {
            frmMain fMain = new frmMain();

            this.Visible = false;
            fMain.Show();
        }

        private void frmInit_Load(object sender, EventArgs e)
        {
            Point PuntoXY = new Point(110,148);

            pnlPanel01.Location = PuntoXY;
            pnlPanel02.Location = PuntoXY;
            chkBoxURI.Checked = true;
            pnlPanel01.Visible = false; 
        }

        private void chkBoxURI_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxURI.Checked)
            {
                pnlPanel01.Visible = false;
                pnlPanel02.Visible = true;
                chkBoxURI.Text = "Automatic URI";
            }
            else
            {
                pnlPanel01.Visible = true;
                pnlPanel02.Visible = false;
                chkBoxURI.Text = "Register by Name";
            }
        }

        private void cmdURL_Click(object sender, EventArgs e)
        {
            string szPage = "http://www.microsoft.com";

            try
            {
                System.Diagnostics.Process.Start(szPage);
            }
            catch(System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }

        }
    }
}