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

        private void cmdStart_Click(object sender, EventArgs e)
        {
	            int interval = 10000;
	            measurementTimer.Enabled = true;
                measurementTimer.Interval = interval;
                measurementTimer.Start();
                cmdStart.Enabled = false;
                cmdStop.Enabled = true;
        }

        private void measurementTimer_Tick(object sender, EventArgs e)
        {
            XmlDocument currentMeasurement = new XmlDocument();
            currentMeasurement = Tool.Dina_GetState();

            if (currentMeasurement.InnerText != lastMeasurement.InnerText)
            {
                Hashtable h = this.handleResponse();
            }
        }


        private void cmdStop_Click(object sender, EventArgs e)
        {
            measurementTimer.Stop();
            cmdStop.Enabled = false;
            cmdStart.Enabled = true;
            switch (MessageBox.Show("Upload Comments to CRC database?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    uploadAllComments();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private Hashtable handleResponse()
        {
            Hashtable h = new Hashtable();

            lastMeasurement = Tool.Dina_GetState();

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
                try
                {
                    this.mGrid.Rows.Add(Image.FromFile("C:\\successful.png"), ((DateTime)h["Systolic_blood_pressure_Time_stamp"]),
                                        h["Systolic_blood_pressure_Value"],
                                        h["Diastolic_blood_pressure_Value"], h["Pulse_Value"], "",true);
                    numMeasurements++;
                    numMeasurementsS++;
                    toolStripStatusLabelNumSuccessful.Text = numMeasurementsS.ToString();                    
                    lblNum.Text = numMeasurements.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                try
                {
                    this.mGrid.Rows.Add(Image.FromFile("C:\\error.png"), ((DateTime)h["Systolic_blood_pressure_Time_stamp"]),
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
        private string buildQueryString(Hashtable h, Boolean access)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                if (access)
                    sb.Append("INSERT INTO MeasurementsData (Study_ID, MeasurementTime, SP, DP, MAP, Pulse, Comments) VALUES");
                else
                    sb.Append("INSERT INTO MeasurementsData (Study_ID, Time, SP, DP, MAP, Pulse, Comments) VALUES");
                sb.Append("(");
                sb.Append("'");
                sb.Append(studyID);
                sb.Append("','");
                if (access)
                    sb.Append(((DateTime)h["Systolic_blood_pressure_Time_stamp"]).ToString("MM/dd/yyyy HH:mm:ss"));

                else
                    sb.Append(((DateTime)h["Systolic_blood_pressure_Time_stamp"]).ToString("yyyy:MM:dd HH:mm:ss"));
                sb.Append("','");
                sb.Append(h["Systolic_blood_pressure_Value"]);
                sb.Append("','");
                sb.Append(h["Diastolic_blood_pressure_Value"]);
                sb.Append("','");
                sb.Append(h["Mean_arterial_pressure_Value"]);
                sb.Append("','");
                sb.Append(h["Pulse_Value"]);
                sb.Append("','");
                sb.Append(this.txtComment.Text);
                sb.Append("'");
                sb.Append(");");
            }
            catch (Exception)
            { }

            return sb.ToString();
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

        private string buildCommentSQL(DataGridViewRow inputRow)
        {
            string commentText = inputRow.Cells[5].FormattedValue.ToString();
            string commentTime = ((DateTime)inputRow.Cells[1].Value).ToString("yyyy:MM:dd HH:mm:ss");
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE MeasurementsData SET Comments = '");
            sb.Append(commentText);
            sb.Append("' WHERE ((Study_ID = '");
            sb.Append(studyID);
            sb.Append("') AND (Time = '");
            sb.Append(commentTime);
            sb.Append("'));");
            return sb.ToString();
        }

        private void mGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {

        }

    }
}