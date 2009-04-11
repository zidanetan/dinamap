using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Text;
using System.Data.Odbc;

namespace DinamapN
{
    public partial class frmMeasurement : Form
    {
        //Variable Global
        int numMeasurements;
        int numMeasurementsSuccessful;
        int numMeasurementsFailed;
        int numCommentMarker;
        private string patientID;
        private string visitID;
        private XmlDocument lastMeasurement = new XmlDocument();
        private OdbcConnection MyConnection;
        
        // Constructor w/out arguments (loaded from menu)
        public frmMeasurement()
        {
            InitializeComponent();
        }

        // Constructor w/ arguments (loaded from FormInit)
        public frmMeasurement(string patient, string visit)
        {
            InitializeComponent();

            // Store Patient & Visit ID's for later use
            patientID = patient;
            visitID = visit;

            // Show ID's on form
            //lblPatientID.Text = patient;
            //lblVisitID.Text = visit;

            // Load reference XML (necessary for first comparison)
            try
            {
                lastMeasurement.Load("C:\\Windows\\dinamap.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load reference XML file: " + ex.ToString());
            }

            //ScanDirectory stepThru = new ScanDirectory();
            //stepThru.WalkDirectory("C:\\Dinamap");
        }

        // If someone clicks "Start"...
        private void cmdStart_Click(object sender, EventArgs e)
        {
            // Check that Dinamap is connected if desired.  Break if not.
            if (dinamapConnectedCheckBox.Checked && !Tool.Dina_CheckReadiness())
                MessageBox.Show("Dinamap machine not ready!  " +
                    "Please check power, connection, or ensure that USB-serial adapter driver is installed.");
            else
            {
                int interval = 30000; // Set time interval for measurements (10 seconds)
                measurementTimer.Enabled = true; // Enable timer
                measurementTimer.Interval = interval; // Assign interval to timer
                measurementTimer.Start(); // Begin timer
                cmdStart.Enabled = false; // Disable "Start" Icon
                cmdStop.Enabled = true; // Enable "Stop" Icon
                dinamapConnectedCheckBox.Enabled = false;
            }
        }

        // Every second...
        private void measurementTimer_Tick(object sender, EventArgs e)
        {
            XmlDocument currentMeasurement = new XmlDocument();

            // If dinamap not connected, use different pull function for debugging
            if (dinamapConnectedCheckBox.Checked)
                currentMeasurement = Tool.Dina_GetStateOn();
            else
                currentMeasurement = Tool.Dina_GetStateOff();

            // If pulled measurement is not the same as the last one, handle it
            if (currentMeasurement.InnerText != lastMeasurement.InnerText && currentMeasurement != null && lastMeasurement != null)
            {
                this.handleResponse();
            }
        }

        // If someone clicks "Stop"...
        private void cmdStop_Click(object sender, EventArgs e)
        {
            measurementTimer.Stop(); // cease taking measurements
            cmdStop.Enabled = false; // Disable "Stop" icon
            cmdStart.Enabled = true; // Enable "Start" icon
            dinamapConnectedCheckBox.Enabled = true;
            uploadAllComments(); // Upload comments
        }

        // When a new measurement is found...
        private void handleResponse()
        {
            Hashtable h = new Hashtable();
            if (dinamapConnectedCheckBox.Checked)
                lastMeasurement = Tool.Dina_GetStateOn();
            else
                lastMeasurement = Tool.Dina_GetStateOff();

            this.saveLocalXML(lastMeasurement);
            h = responseToHash(lastMeasurement);
            this.saveMySQL(h);
        }

        // Saves XML from measurement locally
        private void saveLocalXML(XmlDocument doc)
        {
            doc.PreserveWhitespace = false;
            try
            {
                doc.Save("C:\\Dinamap\\" + visitID + "_" + patientID + "\\raw_xml\\" + numMeasurements + ".xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving XML locally: " + ex.ToString());
            }
        }

        // Attempt to upload measurement data to SQL database
        private void saveMySQL(Hashtable h)
        {
            // Get query string for uploading measurement record
            string query = buildMeasurementSQL(h);

            try
            {
                // Try to upload measurement
                OdbcConnection MyConnection = new OdbcConnection("DSN=dinamapMySQL2");
                MyConnection.Open();
                OdbcCommand DbCommand = MyConnection.CreateCommand();
                DbCommand.CommandText = query;
                DbCommand.ExecuteNonQuery();
                writeToGrid(true, h); // Update on GUI
            }
            catch (Exception)
            {
                saveLocalSQL(query); // Save failed upload
                writeToGrid(false, h); // Update on GUI
            }
        }

        // Put new measurement on display grid
        public void writeToGrid(bool success, Hashtable h)
        {
            // Show measurement with "success" icon and field
            //MessageBox.Show(h.Count.ToString());
            
            if (h.Count != 0)
            {
                if (success == true)
                {
                    this.mGrid.Rows.Add(DinamapN.Properties.Resources.successful,
                                        ((DateTime) h["Systolic_blood_pressure_Time_stamp"]),
                                        h["Systolic_blood_pressure_Value"],
                                        h["Diastolic_blood_pressure_Value"], h["Pulse_Value"], "", true);
                    numMeasurementsSuccessful++;
                }
                    // Show measurement with "failed" icon and field
                else
                {
                    this.mGrid.Rows.Add(DinamapN.Properties.Resources.error,
                                        ((DateTime) h["Systolic_blood_pressure_Time_stamp"]),
                                        h["Systolic_blood_pressure_Value"],
                                        h["Diastolic_blood_pressure_Value"], h["Pulse_Value"], "", false);
                    numMeasurementsFailed++;
                }
                // Update measurement stats and display
                numMeasurements++;
                lblNum.Text = numMeasurements.ToString();
                toolStripStatusLabelNumSuccessful.Text = numMeasurementsSuccessful.ToString();
                toolStripStatusLabelNumFailed.Text = numMeasurementsFailed.ToString();
            }
        }

        // Constructs query from hashtable built from a successful measurement
        private string buildMeasurementSQL(Hashtable h)
        {
            StringBuilder queryBuilder = new StringBuilder();

            try
            {
                queryBuilder.Append("INSERT INTO MeasurementsData (Visit_ID, Time, SP, DP, MAP, Pulse, Comments) VALUES");
                queryBuilder.Append("(");
                queryBuilder.Append("'");
                queryBuilder.Append(visitID);
                queryBuilder.Append("','");
                queryBuilder.Append(((DateTime)h["Systolic_blood_pressure_Time_stamp"]).ToString("yyyy:MM:dd HH:mm:ss"));
                queryBuilder.Append("','");
                queryBuilder.Append(h["Systolic_blood_pressure_Value"]);
                queryBuilder.Append("','");
                queryBuilder.Append(h["Diastolic_blood_pressure_Value"]);
                queryBuilder.Append("','");
                queryBuilder.Append(h["Mean_arterial_pressure_Value"]);
                queryBuilder.Append("','");
                queryBuilder.Append(h["Pulse_Value"]);
                queryBuilder.Append("','");
                queryBuilder.Append("'");
                queryBuilder.Append(");");
                return queryBuilder.ToString();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error building SQL query string: " + ex.ToString());
                return "";
            }
            
        }

        // Build hash from XML data
        private Hashtable responseToHash(XmlDocument doc)
        {
            Hashtable h = new Hashtable();

            XmlNodeList doc_results = doc.GetElementsByTagName("Result");

            foreach (XmlNode pnode in doc_results)
            {
                foreach (XmlNode cnode in pnode.ChildNodes)
                {
                    if (cnode.Name == "Units")
                    {
                        h.Add(pnode.Attributes["name"].InnerText + "_" + cnode.Name, cnode.Attributes["name"].InnerText);
                    }
                    else if (cnode.Name == "Time_stamp")
                    {
                        DateTime d = new DateTime(
                            Convert.ToInt32(cnode.Attributes["year"].InnerText),
                            Convert.ToInt32(cnode.Attributes["month"].InnerText),
                            Convert.ToInt32(cnode.Attributes["day"].InnerText),
                            Convert.ToInt32(cnode.Attributes["hour"].InnerText),
                            Convert.ToInt32(cnode.Attributes["minute"].InnerText),
                            Convert.ToInt32(cnode.Attributes["second"].InnerText));

                        h.Add(pnode.Attributes["name"].InnerText + "_" + cnode.Name, d);
                    }
                    else
                        h.Add(pnode.Attributes["name"].InnerText + "_" + cnode.Name, cnode.InnerText);
                }
            }

            return h;
        }

        // Upon loading form...
        private void frmMeasurement_Load(object sender, EventArgs e)
        {
            cmdStart.Enabled = true;
            cmdStop.Enabled = false;
            numMeasurements = 0;
            numCommentMarker = 0;

            // Load database connection
            try
            {
                MyConnection = new OdbcConnection("DSN=dinamapMySQL2");
            }
            catch
            {
                MessageBox.Show("DSN does not exist or contains errors.  See administrator.  Measurements will be saved locally.");
            }
        }

        // Every time timer is called by system...
        private void sysTime_Tick(object sender, EventArgs e)
        {
            string szHour;
            szHour = DateTime.Now.ToString("h:mm:ss");
            lblTime.ForeColor = Color.Black;
            lblTime.Text = szHour;
        }

        // When form is activated...
        private void frmMeasurement_Activated(object sender, System.EventArgs e)
        {
            sysTimer.Start();
        }

        // Change comment cell color after user enters something
        private void mGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (mGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.Equals(""))
            {
                mGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
            }
            else
            {
                mGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
            }
            mGrid.ClearSelection();
        }

        // Attempt to upload comments to database
        private void uploadAllComments()
        {
            DataGridViewRow inputRow;
            string valueUploadStatus;
            OdbcCommand insertCommand;
            string commentText;

            // Go through all rows, start after the last one handled
            for (int i = numCommentMarker; i < numMeasurements; i++)
            {
                numCommentMarker++;  // Show this row was handled
                inputRow = mGrid.Rows[i]; // pull row
                valueUploadStatus = inputRow.Cells[6].FormattedValue.ToString(); // Find if measurement was uploaded
                commentText = inputRow.Cells[5].FormattedValue.ToString(); // Pull comment
                insertCommand = buildCommentSQL(inputRow); // Build SQL string

                // Only attempt upload if comment exists and measurement was
                // successfully uploaded
                if (valueUploadStatus.Equals("True") && !commentText.Equals(""))
                {
                    // Upload value 
                    try
                    {
                        MyConnection.Open();
                        insertCommand.ExecuteNonQuery();
                        MyConnection.Close();
                        mGrid.Rows[i].Cells[5].Style.BackColor = Color.Green;
                    }
                    // Save locally if unsuccessful
                    catch (Exception ex)
                    {
                        commentText = commentText.Replace("'", "''");
                        saveLocalSQL(insertCommand.CommandText.Replace("?", ("'" + commentText + "'")));
                        mGrid.Rows[i].Cells[5].Style.BackColor = Color.Red;
                    }
                }
                // Save locally if measurement failed.
                else if (valueUploadStatus.Equals("False") && !commentText.Equals(""))
                {
                    saveLocalSQL(insertCommand.CommandText);
                    mGrid.Rows[i].Cells[5].Style.BackColor = Color.Red;
                }
                mGrid.Rows[i].Cells[5].ReadOnly = true;
            }
        }

        // Constructs SQL update statement string  to commit comments
        // for a given row from the grid viewer
        private OdbcCommand buildCommentSQL(DataGridViewRow inputRow)
        {
            OdbcCommand updateComment = MyConnection.CreateCommand();
            string commentText = inputRow.Cells[5].FormattedValue.ToString(); // Grab comment from row
            //commentText = commentText.Replace("'", "''"); // Correct for SQL format
            string commentTime = ((DateTime)inputRow.Cells[1].Value).ToString("yyyy:MM:dd HH:mm:ss"); // Grab date from row, convert for SQL
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append("UPDATE MeasurementsData SET Comments = ");
            queryBuilder.Append("?");
            queryBuilder.Append(" WHERE ((Visit_ID = '");
            queryBuilder.Append(visitID);
            queryBuilder.Append("') AND (Time = '");
            queryBuilder.Append(commentTime);
            queryBuilder.Append("'));");
            updateComment.CommandText = queryBuilder.ToString();
            updateComment.Parameters.Add("@Comment", OdbcType.Text).Value = commentText;
            return updateComment;
        }

        // Saves SQL statements to local directory for uploading later
        private void saveLocalSQL(string statement)
        {
            try
            {
                StreamWriter output = new StreamWriter("C:\\Dinamap\\" + visitID + "_" + patientID + "\\queued_sql\\" + "queued_sql.sql", true);
                output.WriteLine(statement);
                output.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving SQL locally! " + ex.ToString());
            }
        }

        //Allow user to edit comment cell on click without selecting it
        private void mGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!mGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly)
                mGrid.BeginEdit(true);
            mGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
        }

        //Another check to make sure selection does not occur.
        private void mGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            mGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
        }
    }
}