using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DinamapN
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Graba en el Regedit [HKEY_CURRENT_USER/Software/DinamapN]

            Tool.SetConfigurationRegistry("URL", txtURL.Text.ToString());
            Tool.SetConfigurationRegistry("DllLocation", txtDLL.Text.ToString());
        }
    }
}