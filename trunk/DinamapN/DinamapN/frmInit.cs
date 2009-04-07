using System;
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
        private string studyID;

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
            txtStudyID.Select();
        }

        // When the user clicks the "Proceed to Study" button...
        private void btnStudy_Click(object sender, EventArgs e)
        {
            try
            {
                // If Patient and study ID input fields aren't blank...
                if (txtPatientID.Text != "" && txtStudyID.Text != "")
                {
                    // Store inputs into global vars
                    patientID = txtPatientID.Text;
                    studyID = txtStudyID.Text;

                    // Create directories to store data locally
                    if (!Directory.Exists("C:\\Dinamap"))
                        Directory.CreateDirectory("C:\\Dinamap");
                    Directory.CreateDirectory("C:\\Dinamap\\" + studyID + "_" + patientID);
                    Directory.CreateDirectory("C:\\Dinamap\\" + studyID + "_" + patientID + "\\raw_xml");
                    Directory.CreateDirectory("C:\\Dinamap\\" + studyID + "_" + patientID + "\\queued_sql");
               
                    // Open study measurements window
                    frmMain fMain = new frmMain(patientID, studyID);

                    // Hide this window
                    this.Visible = false;
                    
                    // Show study measurements window
                    fMain.Show();
                }

                // Prompt user to fill input fields if either are blank
                else
                {
                    MessageBox.Show("Please enter Patient ID and Study ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Local directory could not be created.: " + ex.ToString());
            }
        }

        private void frmInit_Load(object sender, EventArgs e)
        {
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