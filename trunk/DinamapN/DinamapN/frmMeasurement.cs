using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace DinamapN
{
    public partial class frmMeasurement : Form
    {
        //Variable Global
        int numMeasurements;
        private string patientID;
        private string studyID;

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
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            string min = comboBox1.SelectedItem.ToString();
           
            if (min == "Min")
            {
                MessageBox.Show("The interval must be set before measurements can be taken.");
                intervalPanel.BackColor = System.Drawing.Color.LightCoral;
            }
            else
	        {
                int interval = Convert.ToInt32(min) * 1000; //seconds, change to minutes
                
                measurementTimer.Interval = interval;
                measurementTimer.Start();
                cmdStart.Enabled = false;
                cmdStop.Enabled = true;
                intervalPanel.BackColor = SystemColors.Control;
                comboBox1.Enabled = false;
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            numMeasurements++;
            Hashtable h = this.handleResponse();
           
            this.mGrid.Rows.Add(((DateTime)h["Systolic_blood_pressure_Time_stamp"]).TimeOfDay, h["Systolic_blood_pressure_Value"], 
                h["Diastolic_blood_pressure_Value"], h["Pulse_Value"], "");
           
            lblNum.Text = numMeasurements.ToString();        
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            measurementTimer.Stop();
            cmdStop.Enabled = false;
            cmdStart.Enabled = true;
            comboBox1.Enabled = true;
        }

        private Hashtable handleResponse()
        {
            Tool.resetMonitor();

            XmlDocument myDoc = new XmlDocument();
            myDoc = Tool.Dina_GetState();

            this.saveLocal(myDoc);

            return responseToArray(myDoc);
        }

        private void saveLocal(XmlDocument doc)
        {
            doc.PreserveWhitespace = false;
            doc.Save("C:\\" + studyID + "_" + patientID + "\\raw_xml\\"+numMeasurements+".xml");
        }

        private Hashtable responseToArray(XmlDocument doc)
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
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

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

        private void frmMeasurement_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}