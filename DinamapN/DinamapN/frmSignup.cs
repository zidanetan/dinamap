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

        //Gender and Ethnicity have drop-down menus
        private void frmSignup_Load(object sender, EventArgs e)
        {
            txtGender.DropDownStyle = ComboBoxStyle.DropDownList;
            txtEth.DropDownStyle = ComboBoxStyle.DropDownList;
            txtFName.Select();
        }

        //User clicks Back button
        private void button1_Click(object sender, EventArgs e)
        {
            frmStart fStart = new frmStart();

            fStart.Show();

            this.Visible = false;
        }

        //Save Patient registration to Database
        private void saveDB(Hashtable h)
        {
            
            string query = buildQueryString(h);
            try
            {
                OdbcConnection MyConnection = new OdbcConnection("DSN=dinamapMySQL2");
                MyConnection.Open();
                OdbcCommand DbCommand = MyConnection.CreateCommand();
                DbCommand.CommandText = query;
                DbCommand.ExecuteNonQuery();
                continueSignup(h);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Error. Check data validity.");
            }
        }

        //move on to frmInit
        private void continueSignup(Hashtable h)
        {
            string query = buildQueryString2(h);//build query string

            try//patient should already exist in DB
            {
                OdbcConnection MyConnection = new OdbcConnection("DSN=dinamapMySQL2");
                MyConnection.Open();
                OdbcCommand DbCommand = MyConnection.CreateCommand();
                DbCommand.CommandText = query;
                string patientID = DbCommand.ExecuteScalar().ToString();

                //continue on to next form
                frmInit fInit = new frmInit(patientID);
                fInit.Show();
                this.Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }


        //create SQL INSERT statement with Patient info for new patients
        private string buildQueryString(Hashtable h)
        {
            StringBuilder sb = new StringBuilder();
            
            try
            {
                sb.Append("INSERT INTO Patient (Last_Name, First_Name, Gender, Ethnicity, Comments, VUH, DOB, SSN, Diagnosis, Other_Diagnosis, Diagnosis_Questionable) VALUES");
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
                sb.Append("',STR_TO_DATE('");
                sb.Append(h["DOB"]);
                sb.Append("','%m/%d/%Y'),'");
                sb.Append(h["SSN"]);
                sb.Append("','");
                sb.Append(h["Diagnosis"]);
                sb.Append("','");
                sb.Append(h["Other_Diagnosis"]);
                sb.Append("','");

                if (h["Diagnosis_Questionable"].ToString() == "False")
                    h["Diagnosis_Questionable"] = "0";
                else
                    h["Diagnosis_Questionable"] = "1";

                sb.Append(h["Diagnosis_Questionable"]);
                sb.Append("'");
                sb.Append(");");
            }
            catch (Exception)
            {
            
            }

            return sb.ToString();
        }

        //Build query string to see if patient already exists in DB
        private string buildQueryString2(Hashtable h)
        {
            StringBuilder sb2 = new StringBuilder();

            try
            {
                //Construct query from inputs (first and last name to begin)
                sb2.Append("Select * from patient where First_Name = '");
                sb2.Append(txtFName.Text);
                sb2.Append("' AND Last_Name = '");
                sb2.Append(txtLName.Text);
                sb2.Append("'");
                sb2.Append(" AND DOB = ");
                sb2.Append("STR_TO_DATE('");
                sb2.Append(txtDOB.Text);
                sb2.Append("','%m/%d/%Y')");
            }

            catch (Exception)
            {

            }
            return sb2.ToString();
        }

        
        //User clicks Register Patient button
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Hashtable h = validateForm();
           
            if(h["Errors"].ToString() == "")//if no errors...
            {
                RegisterPatient(h);
            }
            else
            {
                MessageBox.Show("Please fix the following fields:\n" + h["Errors"]);
            }
        }

        private void RegisterPatient(Hashtable h)
        {
            //check if patient entry already exists in database
            string query = buildQueryString2(h);//build query string

            //connect to DB and send query
            try
            {
                OdbcConnection MyConnection = new OdbcConnection("DSN=dinamapMySQL2");
                MyConnection.Open();
                OdbcCommand DbCommand = MyConnection.CreateCommand();
                DbCommand.CommandText = query;
                if (DbCommand.ExecuteScalar() == null || DbCommand.ExecuteScalar().ToString() == "")
                {//patient is new
                    saveDB(h);
                }
                else
                {//patient already exists in DB
                    MessageBox.Show("Patient already registered.\nGo back and try Existing Patient Login.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        //Check for mandatory fields and formatting errors
        private Hashtable validateForm()
        {
            Hashtable h = new Hashtable();
            h["Errors"] = "";

            if (txtFName.Text != "")
                h["First_Name"] = txtFName.Text;
            else
                h["Errors"] += "First Name\n";

            if (txtLName.Text != "")
                h["Last_Name"] = txtLName.Text;
            else
                h["Errors"] += "Last Name\n";

            if (txtGender.SelectedItem != null)
                h["Gender"] = txtGender.SelectedItem.ToString();
            else
                h["Errors"] += "Gender\n";

            if (txtDOB.MaskCompleted)
                h["DOB"] = txtDOB.Text;
            else
                h["Errors"] += "DOB\n";

            if (txtEth.SelectedItem != null)
                h["Ethnicity"] = txtEth.SelectedItem.ToString();
            else
                h["Errors"] += "Ethnicity\n";

            if (txtSSN.Text != "   -  -")
                if (txtSSN.Text.Remove(6, 1).Remove(3, 1).Length == 9)
                    h["SSN"] = txtSSN.Text.Remove(6, 1).Remove(3, 1);
                else
                    h["Errors"] += "SSN Length\n";
            else
                h["SSN"] = txtSSN.Text.Remove(6, 1).Remove(3, 1);
            h["Diagnosis"] = txtDiag.Text;
            h["Other_Diagnosis"] = txtODiag.Text;
            h["Diagnosis_Questionable"] = txtQuestionable.Checked;
            h["Comments"] = txtComments.Text;

            return h;
        }

        private void frmSignup_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
