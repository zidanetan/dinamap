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
        private string studyID;
        private XmlDocument lastMeasurement = new XmlDocument();
        private OdbcConnection MyConnection;

        // Constructor w/out arguments (loaded from menu)
        public frmMeasurement()
        {
            InitializeComponent();
        }

        // Constructor w/ arguments (loaded from FormInit)
        public frmMeasurement(string patient, string study)
        {
            InitializeComponent();
            
            // Store Patient & Study ID's for later use
            patientID = patient;
            studyID = study;

            // Show ID's on form
            lblPatientID.Text = patient;
            lblStudyID.Text = study;
            
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
                int interval = 1000; // Set time interval for measurements (10 seconds)
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
            if (currentMeasurement.InnerText != lastMeasurement.InnerText)
            {
                Hashtable h = this.handleResponse();
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
        private Hashtable handleResponse()
        {
            Hashtable h = new Hashtable();
            if (dinamapConnectedCheckBox.Checked)
                lastMeasurement = Tool.Dina_GetStateOn();
            else
                lastMeasurement = Tool.Dina_GetStateOff();

            this.saveLocalXML(lastMeasurement);
            h = responseToHash(lastMeasurement);
            this.saveMySQL(h);
            //this.saveAccess(h);
            return h;
        }

        // Saves XML from measurement locally
        private void saveLocalXML(XmlDocument doc)
        {
            doc.PreserveWhitespace = false;
            try
            {
                doc.Save("C:\\Dinamap\\" + studyID + "_" + patientID + "\\raw_xml\\" + numMeasurements + ".xml");
            }
            catch(Exception ex)
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
            if (success)
            {
                this.mGrid.Rows.Add(DinamapN.Properties.Resources.successful, ((DateTime)h["Systolic_blood_pressure_Time_stamp"]),
                    h["Systolic_blood_pressure_Value"],
                    h["Diastolic_blood_pressure_Value"], h["Pulse_Value"], "",true);
                numMeasurementsSuccessful++;
            }
            // Show measurement with "failed" icon and field
            else
            {
                this.mGrid.Rows.Add(DinamapN.Properties.Resources.error, ((DateTime)h["Systolic_blood_pressure_Time_stamp"]),
                    h["Systolic_blood_pressure_Value"],
                    h["Diastolic_blood_pressure_Value"], h["Pulse_Value"], "",false);
                numMeasurementsFailed++;
            }
            // Update measurement stats and display
            numMeasurements++;
            lblNum.Text = numMeasurements.ToString();
            toolStripStatusLabelNumSuccessful.Text = numMeasurementsSuccessful.ToString();                    
            toolStripStatusLabelNumFailed.Text = numMeasurementsFailed.ToString();
        }

        // Constructs query from hashtable built from a successful measurement
        private string buildMeasurementSQL(Hashtable h)
        {
            StringBuilder queryBuilder = new StringBuilder();

            try
            {
                queryBuilder.Append("INSERT INTO MeasurementsData (Study_ID, Time, SP, DP, MAP, Pulse, Comments) VALUES");
                queryBuilder.Append("(");
                queryBuilder.Append("'");
                queryBuilder.Append(studyID);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error building SQL query string: " + ex.ToString());
            }
            return queryBuilder.ToString();
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
                    if(cnode.Name == "Units")
                    {
                        h.Add(pnode.Attributes["name"].InnerText + "_" + cnode.Name, cnode.Attributes["name"].InnerText);
                    }
                    else if(cnode.Name == "Time_stamp")
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
            string insertStatement;
            string commentText;

            // Go through all rows, start after the last one handled
            for (int i = numCommentMarker; i < numMeasurements; i++)
            {
                numCommentMarker++;  // Show this row was handled
                inputRow = mGrid.Rows[i]; // pull row
                valueUploadStatus = inputRow.Cells[6].FormattedValue.ToString(); // Find if measurement was uploaded
                commentText = inputRow.Cells[5].FormattedValue.ToString(); // Pull comment
                insertStatement = buildCommentSQL(inputRow); // Build SQL string

                // Only attempt upload if comment exists and measurement was
                // successfully uploaded
                if (valueUploadStatus.Equals("True") && !commentText.Equals(""))
                {
                    // Upload value 
                    try
                    {
                        MyConnection.Open();
                        OdbcCommand DbCommand = MyConnection.CreateCommand();
                        DbCommand.CommandText = insertStatement;
                        DbCommand.ExecuteNonQuery();
                        MyConnection.Close();
                        mGrid.Rows[i].Cells[5].Style.BackColor = Color.Green;
                    }
                    // Save locally if unsuccessful
                    catch(Exception ex)
                    {
                        saveLocalSQL(insertStatement);
                        mGrid.Rows[i].Cells[5].Style.BackColor = Color.Red;
                    }
                }
                // Save locally if measurement failed.
                else if (valueUploadStatus.Equals("False") && !commentText.Equals(""))
                {
                    MessageBox.Show("Entry " + i.ToString() + " value record failed to upload previously.  Comment upload command stored locally.");
                    saveLocalSQL(insertStatement);
                    mGrid.Rows[i].Cells[5].Style.BackColor = Color.Red;
                }
                mGrid.Rows[i].Cells[5].ReadOnly = true;
            }
        }

        // Constructs SQL update statement string  to commit comments
        // for a given row from the grid viewer
        private string buildCommentSQL(DataGridViewRow inputRow)
        {
            string commentText = inputRow.Cells[5].FormattedValue.ToString(); // Grab comment from row
            commentText = commentText.Replace("'", "''"); // Correct for SQL format
            string commentTime = ((DateTime)inputRow.Cells[1].Value).ToString("yyyy:MM:dd HH:mm:ss"); // Grab date from row, convert for SQL
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append("UPDATE MeasurementsData SET Comments = '");
            queryBuilder.Append(commentText);
            queryBuilder.Append("' WHERE ((Study_ID = '");
            queryBuilder.Append(studyID);
            queryBuilder.Append("') AND (Time = '");
            queryBuilder.Append(commentTime);
            queryBuilder.Append("'));");
            return queryBuilder.ToString();
        }

        // Saves SQL statements to local directory for uploading later
        private void saveLocalSQL(string statement)
        {
            try
            {
                StreamWriter output = new StreamWriter("C:\\Dinamap\\" + studyID + "_" + patientID + "\\queued_sql\\" + "queued_sql.sql", true);
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

        //Scan for saved .sql files and upload them, delete if successful
        public class ScanDirectory
        {
            public void WalkDirectory(string directory)
            {
                WalkDirectory(new DirectoryInfo(directory));
            }

            private void WalkDirectory(DirectoryInfo directory)
            {
                // Scan all files in the current path
                foreach (FileInfo file in directory.GetFiles())
                {
                    if (file.Name.EndsWith(".sql"))
                            readFileSQL(file);
                }

                DirectoryInfo[] subDirectories = directory.GetDirectories();

                // Scan the directories in the current directory and call this method 
                // again to go one level into the directory tree
                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    WalkDirectory(subDirectory);
                }
            }

            private void readFileSQL(FileInfo file)
            {
                Boolean failures = false;
                StreamReader reader = new StreamReader(file.FullName);
                FileInfo file2 = new FileInfo(file.FullName + "2");
                StreamWriter writer = new StreamWriter(file2.FullName, true);                
                OdbcConnection MyConnection = new OdbcConnection("DSN=dinamapMySQL2");
                try 
                {
                    MyConnection.Open();
                }
                catch 
                {
                    reader.Close();
                    writer.Close();
                    file2.Delete();
                    return;
                }
                
                OdbcCommand DbCommand = MyConnection.CreateCommand();
                string SQLstatement;

                while (!reader.EndOfStream)
                {
                    SQLstatement = reader.ReadLine();

                    try
                    {
                        DbCommand.CommandText = SQLstatement;
                        DbCommand.ExecuteNonQuery();
                    }
                    catch
                    {
                        writer.WriteLine(SQLstatement);
                        failures = true;
                    }
                }

                reader.Close();
                writer.Close();
                file.Delete();
                if (failures)
                    file2.MoveTo(file.FullName);
                else
                    file2.Delete();
                MessageBox.Show("Uploaded queued SQL and deleted file: " + file.FullName);
            }
        }
    }
}