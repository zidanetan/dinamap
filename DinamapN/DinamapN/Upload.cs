using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Xml;

namespace DinamapN
{
    public partial class Upload : Form
    {
        public Upload()
        {
            InitializeComponent();
        }

        private void Upload_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlTextReader textReader = new XmlTextReader("C:\\dinamap.xml");
         
        }

    }
}
