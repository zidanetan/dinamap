using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace DinamapN
{
    public partial class frmInit : Form
    {
        private string patientID;
        private string visitID;

        public frmInit()
        {
            InitializeComponent();
        }

        public frmInit(String patient)
        {
            InitializeComponent();
            patientID = patient;
            this.txtPatientID.ReadOnly = true;
            this.txtPatientID.Text = patientID;
            this.panel1.Enabled = false;
            this.resultsGrid.Enabled = false;
        }

        private string buildQueryString(Hashtable h)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.Append("INSERT INTO Visit (Patient_ID, Study_ID, Protocol_ID, Date, Nurse, Physician) VALUES");
                sb.Append("(");
                sb.Append("'");
                sb.Append(h["Patient_ID"]);
                sb.Append("','");
                sb.Append(h["Study_ID"]);
                sb.Append("','");
                sb.Append(h["Protocol_ID"]);
                sb.Append("','");
                sb.Append(h[DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss")]);
                sb.Append("','");
                sb.Append(h["Nurse"]);
                sb.Append("','");
                sb.Append(h["Physician"]);
                sb.Append("'");
                sb.Append(");");
            }
            catch (Exception)
            {   
            }

            return sb.ToString();
        }

        private Hashtable validateForm()
        {
            Hashtable h = new Hashtable();
            h["Errors"] = "";

            if (txtPatientID.Text != "")
                h["Patient_ID"] = txtPatientID.Text;
            else
                h["Errors"] += "Patient ID\n";

            if (txtProtocolID.SelectedItem != null)
                h["Protocol_ID"] = txtProtocolID.SelectedItem.ToString();
            else
                h["Errors"] += "Protocol\n";

            if (txtStudyID.SelectedItem != null)
                h["Study_ID"] = txtStudyID.SelectedItem.ToString();
            else
                h["Errors"] += "Study\n";

            if (txtNurse.Text != "")
                h["Nurse"] = txtNurse.Text;
            else
                h["Errors"] += "Nurse\n";

            if (txtPhysician.Text != "")
                h["Physician"] = txtPhysician.Text;
            else
                h["Errors"] += "Physician\n";

            return h;
        }

        private string buildQueryString2(Hashtable h)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.Append("SELECT * from Visit where Patient_ID = '");
                sb.Append(h["Patient_ID"]);
                sb.Append("' and Study_ID = '");
                sb.Append(h["Study_ID"]);
                sb.Append("' and Protocol_ID = '");
                sb.Append(h["Protocol_ID"]);
                sb.Append("' and Nurse = '");
                sb.Append(h["Nurse"]);
                sb.Append("' and Physician = '");
                sb.Append(h["Physician"]);
                sb.Append("' order by Date desc;");
            }
            catch (Exception)
            {
            }
            
            return sb.ToString();
        }

        // When the user clicks the "Proceed to Study" button...
        private void btnStudy_Click(object sender, EventArgs e)
        {
            Hashtable h = validateForm();

            if (h["Errors"].ToString() == "")//if no errors...
            {
                RegisterVisit(h);
            }
            else
            {
                MessageBox.Show("Please complete the following fields:\n" + h["Errors"]);
            }
        }
            
        private void RegisterVisit(Hashtable h)
        {
            string query1 = buildQueryString(h);
            string query2 = buildQueryString2(h);

            try
            {
                OdbcConnection MyConnection = new OdbcConnection("DSN=dinamapMySQL2");
                MyConnection.Open();
                OdbcCommand DbCommand = MyConnection.CreateCommand();
                DbCommand.CommandText = query1;
                DbCommand.ExecuteNonQuery();
                DbCommand.CommandText = query2;
                visitID = DbCommand.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error. Check Network Connection.");
            }

            ProceedToStudy();
        }

        private void ProceedToStudy()
        {
            try
            {
                // Store inputs into global vars
                patientID = txtPatientID.Text;
                
                // Create directories to store data locally
                if (!Directory.Exists("C:\\Dinamap"))
                    Directory.CreateDirectory("C:\\Dinamap");
                Directory.CreateDirectory("C:\\Dinamap\\" + visitID + "_" + patientID);
                Directory.CreateDirectory("C:\\Dinamap\\" + visitID + "_" + patientID + "\\raw_xml");
                Directory.CreateDirectory("C:\\Dinamap\\" + visitID + "_" + patientID + "\\queued_sql");
           
                // Open study measurements window
                frmMain fMain = new frmMain(patientID, visitID);

                // Hide this window
                this.Visible = false;
                
                // Show study measurements window
                fMain.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Local directory could not be created.: " + ex.ToString());
            }
        }

        private void frmInit_Load(object sender, EventArgs e)
        {
            try
            {
                OdbcConnection MyConnection = new OdbcConnection("DSN=dinamapMySQL2");
                MyConnection.Open();
                OdbcCommand DbCommand = MyConnection.CreateCommand();
                DbCommand.CommandText = "SELECT Title, Protocol_ID from Protocol";
                OdbcDataReader MyReader = DbCommand.ExecuteReader();
                if (MyReader != null)
                {
                    while (MyReader.Read())
                    {
                        //txtProtocolID.Items.Insert(Convert.ToInt16(MyReader["Protocol_ID"].ToString().Remove(0, 2)), MyReader["Protocol_ID"].ToString() + " " + MyReader["Title"].ToString());
                        txtProtocolID.Items.Add(new ListItem(MyReader["Protocol_ID"],MyReader["Title"]));
                    }
                }
                DbCommand.CommandText = "SELECT Title, Study_ID from Study";
                OdbcDataReader MyReader2 = DbCommand.ExecuteReader();
                if (MyReader2 != null)
                {
                    while (MyReader2.Read())
                        txtStudyID.Items.Insert(Convert.ToInt16(MyReader2["Study_ID"]), MyReader2["Title"]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error. Check network connection then go back and try again.");
            }
            txtStudyID.DropDownStyle = ComboBoxStyle.DropDownList;
            txtProtocolID.DropDownStyle = ComboBoxStyle.DropDownList;
            // User ready to begin inputting info on load
            this.txtFirstName.Focus();
            this.txtFirstName.ScrollToCaret();
        }

        // When the user clicks the "Back" button...
        private void btnBack_Click(object sender, EventArgs e)
        {
            frmStart fStart = new frmStart();

            this.Visible = false;

            fStart.Show();
        }

        // End program when user closes window
        private void frmInit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
        // When the user clicks the "Lookup" button...
        private void btnLookup_Click(object sender, EventArgs e)
        {
            // If no data inputted...
            if (txtFirstName.Text.Equals("") && txtLastName.Text.Equals("") && maskedTxtDOB.Text.Equals("  /  /"))
            {
                txtSearchStatus.Visible = true;         // Trigger message
                txtSearchStatus.Text = "Please enter data before searching!";
                return; // exit
            }
            Cursor.Current = Cursors.WaitCursor;    // Trigger hourglass
            txtSearchStatus.Visible = true;         // Trigger "searching" message
            txtSearchStatus.Text = "Searching records...";
            DateTime dateOfBirth;   //for converting from input to SQL
            string query;           //overall search query string
            StringBuilder queryBuilder = new StringBuilder();     //for building query string
            try
            {
                //Construct query from inputs (first and last name to begin)
                queryBuilder.Append("Select * from patient where First_Name LIKE '");
                queryBuilder.Append(this.txtFirstName.Text);
                queryBuilder.Append("%' AND Last_Name LIKE '");
                queryBuilder.Append(this.txtLastName.Text);
                queryBuilder.Append("%'");
                //Validate DOB input
                if (DateTime.TryParse(maskedTxtDOB.Text.ToString(), out dateOfBirth)){
                    //Add DOB to query if found to be valid, convert to proper form
                    queryBuilder.Append(" AND DOB = '");
                    queryBuilder.Append(dateOfBirth.ToString("yyyy:MM:dd"));
                    queryBuilder.Append("';");
                }
                //Ignore if blank (don't add to query)
                else if (maskedTxtDOB.Text.ToString() == "  /  /")
                    queryBuilder.Append(";");
                //If improper format and not blank, prompt to correct and exit
                else {
                    MessageBox.Show("Please correct DOB time format.  Should be MM/DD/YYYY");
                    Cursor.Current = Cursors.Default;
                    txtSearchStatus.Visible = false;
                    return;
                }
                query = queryBuilder.ToString();    //Compile query to one string
                resultsGrid.DataSource = bindingSource1; // Bind grid view to database 
                OdbcConnection MyConnection = new OdbcConnection("DSN=dinamapMySQL2"); // Define database connection
                OdbcDataAdapter dataAdapter = new OdbcDataAdapter(query, MyConnection.ConnectionString); // Define query and bind
                MyConnection.Open(); // Open database connection
                DataTable t = new DataTable(); // Pull data from query
                dataAdapter.Fill(t);
                bindingSource1.DataSource = t; // Fill grid with datas
                // Set only some fields visible (sensitive info in others)
                resultsGrid.Columns[0].Visible=false;
                resultsGrid.Columns[4].Visible = false;
                resultsGrid.Columns[5].Visible = false;
                resultsGrid.Columns[6].Visible = false;
                resultsGrid.Columns[8].Visible = false;
                resultsGrid.Columns[9].Visible = false;
                resultsGrid.Columns[10].Visible = false;
                resultsGrid.Columns[11].Visible = false;
                Cursor.Current = Cursors.Default; //Reset cursor
                resultsGrid.Rows[0].Selected = false;

                // Display message if no results
                if (resultsGrid.RowCount > 0)
                    txtSearchStatus.Visible = false;
                else
                    txtSearchStatus.Text = "No results found!";
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        // When the user clicks any data grid cell...
        private void resultsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // If not the header row...
                txtPatientID.Text = resultsGrid.Rows[e.RowIndex].Cells[0].FormattedValue.ToString(); // Pull "Patient ID"
        }

        // When the user presses a key inside an input field...
        private void patientLookup_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == 13) // If that key is 'enter'...
                this.btnLookup_Click(sender, e); // "Press" the lookup button
        }

    }
}