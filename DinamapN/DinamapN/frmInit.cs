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
        }
    }
}