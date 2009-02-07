using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace DinamapN
{
    public partial class frmSignup : Form
    {
        public frmSignup()
        {
            InitializeComponent();
        }

        private void frmSignup_Load(object sender, EventArgs e)
        {
            txtGender.DropDownStyle = ComboBoxStyle.DropDownList;
            txtEth.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmStart fStart = new frmStart();

            this.Visible = false;

            fStart.Show();
        }

        private void saveDB(Hashtable h)
        {
            
            string query = buildQueryString(h);

            try
            {
                OdbcConnection MyConnection = new OdbcConnection("DSN=dinamap");
                MyConnection.Open();
                OdbcCommand DbCommand = MyConnection.CreateCommand();
                DbCommand.CommandText = query;
                DbCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                
            }
        }



        private string buildQueryString(Hashtable h)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.Append("INSERT INTO Patients (Last_Name, First_Name, Gender, Ethnicity, Comments, VUH, DOB, SSN, Diagnosis, Other_Diagnosis, Diagnosis_Questionable) VALUES");
                sb.Append("(");
                sb.Append("'");
                sb.Append(h["Last_Name"]);
                sb.Append("','");
                sb.Append(h["First_Name"]);
                sb.Append("','");
                sb.Append(h["Gender"]);
                sb.Append("','");
                sb.Append(h["Ethnicity"]);
                sb.Append("','");
                sb.Append(h["Comments"]);
                sb.Append("','");
                sb.Append(h["VUH"]);
                sb.Append("','");
                sb.Append(h["DOB"]);
                sb.Append("','");
                sb.Append(h["SSN"]);
                sb.Append("','");
                sb.Append(h["Diagnosis"]);
                sb.Append("','");
                sb.Append(h["Other_Diagnosis"]);
                sb.Append("','");
                sb.Append(h["Diagnosis_Questionable"]);
                sb.Append("'");
                sb.Append(");");
            }
            catch (Exception)
            {}

            return sb.ToString();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Hashtable h = validateForm();
           
            if(h["Errors"].ToString() == "")
            {
                saveDB(h);
            }
            else
            {
                MessageBox.Show("Please fix the following fields: " + h["Errors"]);
            }
        }

        private Hashtable validateForm()
        {
            Hashtable h = new Hashtable();
            return h;
        }

        private void frmSignup_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
