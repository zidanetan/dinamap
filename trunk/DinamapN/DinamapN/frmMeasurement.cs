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
        int numMeasurementsS;
        int numMeasurementsF;
        private string patientID;
        private string studyID;
        private XmlDocument lastMeasurement = new XmlDocument();
        private OdbcConnection MyConnection;

        public frmMeasurement()
        {
            InitializeComponent();
        }

        public frmMeasurement(string patient, string study)
        {
            InitializeComponent();
            
            patientID = patient;
            studyID = study;

            lblPatientID.Text = patient;
            lblStudyID.Text = study;
            
            lastMeasurement.Load("C:\\dinamap.xml");
        }

        // If someone clicks "Start"...
        private void cmdStart_Click(object sender, EventArgs e)
        {
	            int interval = 10000;  // Set time interval for measurements
	            measurementTimer.Enabled = true; // Enable timer
                measurementTimer.Interval = interval; // Assign interval to timer
                measurementTimer.Start(); // Begin timer
                cmdStart.Enabled = false; // Disable "Start" Icon
                cmdStop.Enabled = true; // Enable "Stop" Icon
                dinamapConnectedCheckBox.Enabled = false;
        }

        private void measurementTimer_Tick(object sender, EventArgs e)
        {
            XmlDocument currentMeasurement = new XmlDocument();
            if (dinamapConnectedCheckBox.Checked)
                currentMeasurement = Tool.Dina_GetStateOn();
            else
                currentMeasurement = Tool.Dina_GetStateOff();

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
            // Prompt user to upload comments
            switch (MessageBox.Show("Upload Comments to CRC database?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    uploadAllComments();
                    return;
                case DialogResult.No:
                    return;
            }
        }

        private Hashtable handleResponse()
        {
            Hashtable h = new Hashtable();

            if (dinamapConnectedCheckBox.Checked)
                lastMeasurement = Tool.Dina_GetStateOn();
            else
                lastMeasurement = Tool.Dina_GetStateOff();

            this.saveLocal(lastMeasurement);

            h = responseToHash(lastMeasurement);
            this.saveMySQL(h);
            //this.saveAccess(h);
            return h;
        }

        private void saveLocal(XmlDocument doc)
        {
            doc.PreserveWhitespace = false;
            doc.Save("C:\\" + studyID + "_" + patientID + "\\raw_xml\\"+numMeasurements+".xml");
        }

        private void saveMySQL(Hashtable h)
        {
            string query = buildQueryString(h, false);

            try
            {
                OdbcConnection MyConnection = new OdbcConnection("DSN=dinamapMySQL2");
                MyConnection.Open();
                OdbcCommand DbCommand = MyConnection.CreateCommand();
                DbCommand.CommandText = query;
                DbCommand.ExecuteNonQuery();
                writeToGrid(true, h);
            }
            catch (Exception)
            {
                StreamWriter output = new StreamWriter("C:\\" + studyID + "_" + patientID + "\\queued_sql\\" + "queued_sql.sql", true);
                output.WriteLine(query);
                output.Close();
                writeToGrid(false, h);
            }
        }

        public void writeToGrid(bool success, Hashtable h)
        {
            if (success)
            {
                //try
                //{
                    this.mGrid.Rows.Add(DinamapN.Properties.Resources.successful, ((DateTime)h["Systolic_blood_pressure_Time_stamp"]),
                                        h["Systolic_blood_pressure_Value"],
                                        h["Diastolic_blood_pressure_Value"], h["Pulse_Value"], "",true);
                    numMeasurements++;
                    numMeasurementsS++;
                    toolStripStatusLabelNumSuccessful.Text = numMeasurementsS.ToString();                    
                    lblNum.Text = numMeasurements.ToString();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message.ToString());
                //}
            }
            else
            {
                try
                {
                    
                    this.mGrid.Rows.Add(DinamapN.Properties.Resources.error, ((DateTime)h["Systolic_blood_pressure_Time_stamp"]),
                                        h["Systolic_blood_pressure_Value"],
                                        h["Diastolic_blood_pressure_Value"], h["Pulse_Value"], "",false);
                    numMeasurements++;
                    numMeasurementsF++;
                    toolStripStatusLabelNumFailed.Text = numMeasurementsS.ToString();
                    lblNum.Text = numMeasurements.ToString();
                }
                catch (Exception)
                {
                }
            }
        }


/*
        private void saveAccess(Hashtable h)
       {
            string query = buildQueryString(h,true);
            MessageBox.Show(query);
            try
            {
                OdbcConnection MyConnection = new OdbcConnection("DSN=dinamap");
                MyConnection.Open();
                OdbcCommand DbCommand = MyConnection.CreateCommand();
                DbCommand.CommandText = query;
                DbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
*/
        // Constructs query from hashtable built from a successful measurement
        private string buildQueryString(Hashtable h, Boolean access)
        {
            StringBuilder queryBuilder = new StringBuilder();

            try
            {
                // "Time" is reserved keyword for MsAccess, use "MeasurementTime instead
                if (access)
                    queryBuilder.Append("INSERT INTO MeasurementsData (Study_ID, MeasurementTime, SP, DP, MAP, Pulse, Comments) VALUES");
                else
                    queryBuilder.Append("INSERT INTO MeasurementsData (Study_ID, Time, SP, DP, MAP, Pulse, Comments) VALUES");
                queryBuilder.Append("(");
                queryBuilder.Append("'");
                queryBuilder.Append(studyID);
                queryBuilder.Append("','");
                // Use different date/time convention for MS access
                if (access)
                    queryBuilder.Append(((DateTime)h["Systolic_blood_pressure_Time_stamp"]).ToString("MM/dd/yyyy HH:mm:ss"));
                else
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
            catch (Exception)
            { }

            return queryBuilder.ToString();
        }

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

        private void frmMeasurement_Load(object sender, EventArgs e)
        {
            cmdStart.Enabled = true;
            cmdStop.Enabled = false;
            numMeasurements = 0;
            MyConnection = new OdbcConnection("DSN=dinamapMySQL2");
        }

        private void sysTime_Tick(object sender, EventArgs e)
        {
            string szHour;
            szHour = DateTime.Now.ToString("h:mm:ss");
            lblTime.Text = szHour;
        }

        private void frmMeasurement_Activated(object sender, System.EventArgs e)
        {
            sysTimer.Start();
        }

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
        }
        
        private void uploadAllComments()
        {
            DataGridViewRow inputRow;
            string valueUploadStatus;
            string insertStatement;
            string commentText;

            for (int i = 0; i < numMeasurements; i++)
            {
                inputRow = mGrid.Rows[i];
                valueUploadStatus = inputRow.Cells[6].FormattedValue.ToString();
                commentText = inputRow.Cells[5].FormattedValue.ToString();
                if (valueUploadStatus.Equals("True") && !commentText.Equals(""))
                {
                    insertStatement = buildCommentSQL(inputRow);
                    try
                    {
                        MyConnection.Open();
                        OdbcCommand DbCommand = MyConnection.CreateCommand();
                        DbCommand.CommandText = insertStatement;
                        DbCommand.ExecuteNonQuery();
                        MyConnection.Close();
                        mGrid.Rows[i].Cells[5].Style.BackColor = Color.Green;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        StreamWriter output = new StreamWriter("C:\\" + studyID + "_" + patientID + "\\queued_sql\\" + "queued_sql.sql", true);
                        output.WriteLine(insertStatement);
                        output.Close();
                    }
                }
                else if (valueUploadStatus.Equals("False"))
                {
                    insertStatement = buildCommentSQL(inputRow);
                    MessageBox.Show("Entry " + i.ToString() + " value record failed to upload previously.  Comment upload command stored locally.");
                    StreamWriter output = new StreamWriter("C:\\" + studyID + "_" + patientID + "\\queued_sql\\" + "queued_sql.sql", true);
                    output.WriteLine(insertStatement);
                    output.Close();
                }
            }
        }

        // Constructs SQL update statement string  to commit comments
        // for a given row from the grid viewer
        private string buildCommentSQL(DataGridViewRow inputRow)
        {
            string commentText = inputRow.Cells[5].FormattedValue.ToString(); // Grab comment from row
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

        private void mGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {

        }

    }
}