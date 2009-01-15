using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace uploadGCRC
{
    public partial class frmUploadGCRC : Form
    {
        public frmUploadGCRC()
        {
            InitializeComponent();
        }
        
        private void uploadGCRC_Load(object sender, EventArgs e)
        {
            OdbcConnection MyConnection = new OdbcConnection("DSN=dinamap");
            MyConnection.Open();
            OdbcCommand DbCommand = MyConnection.CreateCommand();
            DbCommand.CommandText = "SELECT * FROM gifts";
            OdbcDataReader DbReader = DbCommand.ExecuteReader();

            int fCount = DbReader.FieldCount;
            label1.Text += ":";
            for (int i = 0; i < fCount; i++)
            {
                String fName = DbReader.GetName(i);
                label1.Text += fName + ":";
            }
            label1.Text += "\n";

            while (DbReader.Read())
            {
                label1.Text += ":";
                for (int i = 0; i < fCount; i++)
                {
                    String col = DbReader.GetString(i);

                    label1.Text += col + ":";
                }
                label1.Text += "\n";
            }

            DbReader.Close();
            DbCommand.Dispose();
            MyConnection.Close();
        }
    }
}
