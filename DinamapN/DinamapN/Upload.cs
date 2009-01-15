using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

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
            OdbcConnection conn = new OdbcConnection();
            conn.ConnectionString =
            "Driver={MySql};" +
            "Server=db.domain.com;" +
            "Option=131072;" +
            "Port=3306;" +
            "Stmt=;" +
            "DataBase=DataBaseName;" +
            "Uid=UserName;" +
            "Pwd=Secret;"; 
            conn.Open();
        }

    }
}
