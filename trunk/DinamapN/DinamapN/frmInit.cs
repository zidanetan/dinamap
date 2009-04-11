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

        // Constructor for new patient
        public frmInit()
        {
            InitializeComponent();
            patientID = "";
        }

        // Constructor for existing patien
        public frmInit(String patient)
        {
            InitializeComponent();
            patientID = patient;
            // Make sure user cannot lookup a patient
            this.panel1.Enabled = false;
            this.resultsGrid.Enabled = false;
        }

        // Creates an SQL insert statement for the Visit table from the hashtable.
        private string buildVisitInsertString(Hashtable h)
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
                sb.Append(DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss"));
                sb.Append("','");
                sb.Append(h["Nurse"]);
                sb.Append("','");
                sb.Append(h["Physician"]);
                sb.Append("'");
                sb.Append(");");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error building insert statement string for Visit: " + ex.ToString());
            }
            return sb.ToString();
        }

        // Fill a hashtable with form values, make sure they're filled out.
        private Hashtable validateForm()
        {
            Hashtable h = new Hashtable();
            h["Errors"] = "";

            if (patientID != "")
                h["Patient_ID"] = patientID;
            else
                h["Errors"] += "Patient\n";

            if (txtProtocolID.SelectedItem != null)
                h["Protocol_ID"] = ((KeyValuePair)txtProtocolID.SelectedItem).m_objKey.ToString();
            else
                h["Errors"] += "Protocol\n";

            if (txtStudyID.SelectedItem != null)
                h["Study_ID"] = ((KeyValuePair)txtStudyID.SelectedItem).m_objKey.ToString();
            else
                h["Errors"] += "Study\n";

            if (txtNurse.SelectedItem != null)
                h["Nurse"] = txtNurse.SelectedItem;
            else
                h["Errors"] += "Nurse\n";

            if (txtPhysician.SelectedItem != null)
                h["Physician"] = txtPhysician.SelectedItem;
            else
                h["Errors"] += "Physician\n";

            return h;
        }

        // Creates an SQL query statement for the Visit talbe from the hashtable
        private string buildVisitQueryString(Hashtable h)
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
            catch (Exception ex)
            {
                MessageBox.Show("Error building query statement string for Visit: " + ex.ToString());
            }
            return sb.ToString();
        }

        // When the user clicks the "Proceed to Study" button...
        private void btnStudy_Click(object sender, EventArgs e)
        {
            Hashtable h = validateForm();  // Build hashtable from form entries

            // If no errors...
            if (h["Errors"].ToString() == "")//if no errors...
            {
                RegisterVisit(h);   // Create "visit" instance on DB
            }
            // If errors, then alert the user
            else
            {
                MessageBox.Show("Please complete the following fields:\n" + h["Errors"]);
            }
        }
            
        // Upload visit data & pull auto-generated Visit ID
        private void RegisterVisit(Hashtable h)
        {
            string insertStatement = buildVisitInsertString(h);
            string queryStatement = buildVisitQueryString(h);
            
            try
            {
                OdbcConnection MyConnection = new OdbcConnection("DSN=dinamapMySQL2");
                MyConnection.Open();
                OdbcCommand DbCommand = MyConnection.CreateCommand();
                DbCommand.CommandText = insertStatement;
                DbCommand.ExecuteNonQuery();
                DbCommand.CommandText = queryStatement;
                visitID = DbCommand.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error. Check Network Connection.");
            }

            ProceedToStudy();
        }

        // Open study window, create local storage directories
        private void ProceedToStudy()
        {
            try
            {
                
                // Create directories to store data locally
                if (!Directory.Exists("C:\\Dinamap"))
                    Directory.CreateDirectory("C:\\Dinamap");
                Directory.CreateDirectory("C:\\Dinamap\\" + visitID);
                Directory.CreateDirectory("C:\\Dinamap\\" + visitID + "\\raw_xml");
                Directory.CreateDirectory("C:\\Dinamap\\" + visitID + "\\queued_sql");
           
                // Open study measurements window
                frmMain fMain = new frmMain(visitID);

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

        // When the form loads...
        private void frmInit_Load(object sender, EventArgs e)
        {
            fillDropdowns();

            // User ready to begin inputting info on load
            this.txtFirstName.Focus();
            this.txtFirstName.ScrollToCaret();
        }

        // Fill all the drop down menus with DB queried info
        private void fillDropdowns()
        {
            txtStudyID.DropDownStyle = ComboBoxStyle.DropDownList;
            txtProtocolID.DropDownStyle = ComboBoxStyle.DropDownList;
            txtNurse.DropDownStyle = ComboBoxStyle.DropDownList;
            txtPhysician.DropDownStyle = ComboBoxStyle.DropDownList;
            try
            {
                OdbcDataReader studyReader = executePullDownQuery("SELECT Title, Study_ID from Study");
                if (studyReader != null)
                {
                    while (studyReader.Read())
                        txtStudyID.Items.Add(new KeyValuePair(studyReader["Study_ID"].ToString(), studyReader["Title"].ToString()));
                }

                OdbcDataReader nurseReader = executePullDownQuery("SELECT VUNET_ID from Nurse");
                if (nurseReader != null)
                {
                    while (nurseReader.Read())
                        txtNurse.Items.Add(nurseReader["VUNET_ID"].ToString());
                }

                OdbcDataReader physicianReader = executePullDownQuery("SELECT VUNET_ID from Physician");
                if (physicianReader != null)
                {
                    while (physicianReader.Read())
                        txtPhysician.Items.Add(physicianReader["VUNET_ID"].ToString());
                }

                OdbcDataReader protocolReader = executePullDownQuery("SELECT Title, Protocol_ID from Protocol");
                if (protocolReader != null)
                {
                    while (protocolReader.Read())
                    {
                        txtProtocolID.Items.Add(new KeyValuePair(protocolReader["Protocol_ID"].ToString(), protocolReader["Protocol_ID"].ToString() + " - " + protocolReader["Title"].ToString()));
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error. Check network connection then go back and try again.");
            }
        }

        private OdbcDataReader executePullDownQuery(string query)
        {
            try
            {
                OdbcConnection MyConnection = new OdbcConnection("DSN=dinamapMySQL2");
                MyConnection.Open();
                OdbcCommand DbCommand = MyConnection.CreateCommand();
                DbCommand.CommandText = query;
                OdbcDataReader MyReader = DbCommand.ExecuteReader();
                return MyReader;
            }
            catch (Exception ex)
            {
                return null;
            }
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
                    txtSearchStatus.Text = "Click on a patient to select.";
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
            {
                patientID = resultsGrid.Rows[e.RowIndex].Cells[0].FormattedValue.ToString(); // Pull "Patient ID"
                txtSearchStatus.Visible = false;
            }   
        }

        // When the user presses a key inside an input field...
        private void patientLookup_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == 13) // If that key is 'enter'...
                this.btnLookup_Click(sender, e); // "Press" the lookup button
        }

   }
}