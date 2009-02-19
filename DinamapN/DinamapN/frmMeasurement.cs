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
        private string patientID;
        private string studyID;
        private XmlDocument lastMeasurement = new XmlDocument();
        

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

                    try
                    {
                        this.mGrid.Rows.Add(((DateTime) h["Systolic_blood_pressure_Time_stamp"]).TimeOfDay,
                                            h["Systolic_blood_pressure_Value"],
                                            h["Diastolic_blood_pressure_Value"], h["Pulse_Value"], "");
                        numMeasurements++;
                        lblNum.Text = numMeasurements.ToString();
                    }
                    catch(Exception)
                    {
                    }
                }
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            measurementTimer.Stop();
            cmdStop.Enabled = false;
            cmdStart.Enabled = true;
        }

        private Hashtable handleResponse()
        {
            Hashtable h = new Hashtable();

            lastMeasurement = Tool.Dina_GetState();

            this.saveLocal(lastMeasurement);

            h = responseToHash(lastMeasurement);

            this.saveMySQL(h);
            this.saveAccess(h);
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
            }
            catch (Exception)
            {
                StreamWriter output = new StreamWriter("C:\\" + studyID + "_" + patientID + "\\queued_sql\\" + "queued_sql.sql", true);
                output.WriteLine(query);
                output.Close();
            }
        }

        private void saveAccess(Hashtable h)
        {
            string query = buildQueryString(h,true);
            MessageBox.Show(query);
            try
            {
                OdbcConnection MyConnection = new OdbcConnection("DSN=dinamapAccess");
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
    }
}