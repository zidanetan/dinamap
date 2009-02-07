using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DinamapN
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmInit fInit = new frmInit();

            this.Visible = false;

            fInit.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSignup fSignup = new frmSignup();

            this.Visible = false;

            fSignup.Show();
        }

        private void frmStart_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
