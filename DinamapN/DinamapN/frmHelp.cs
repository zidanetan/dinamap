using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DinamapN
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.webBrowser1.GoBack();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.webBrowser1.GoBack();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.webBrowser1.GoForward();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(@"http://eecs.vanderbilt.edu/Courses/eece295/2008-2009/GCRC-Dinamap/onlinehelp.php");
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            this.toolStripTextBox1.Text = e.Url.ToString();
        }

        private void frmHelp_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Width = this.Parent.Width;
            this.webBrowser1.Height = this.Parent.Height - this.toolStrip1.Height;
        }

        private void frmHelp_Resize(object sender, EventArgs e)
        {
            this.webBrowser1.Width = this.Parent.Width;
            this.webBrowser1.Height = this.Parent.Height - this.toolStrip1.Height;
        }

    }
}
