using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DinamapN
{
    public partial class frmMeasurement : Form
    {
        //Variable Global
        int nRegister;

        public frmMeasurement()
        {
            InitializeComponent();
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            string min = comboBox1.SelectedItem.ToString();
            string sec = comboBox2.SelectedItem.ToString();
           
            if (min == "Min" || sec == "Sec" || (min == "0" && sec == "0"))
            {
                MessageBox.Show("The interval must be set before measurements can be taken.");
                panel4.BackColor = System.Drawing.Color.IndianRed;
            }
            else
	        {
                int interval = Convert.ToInt32(min) * 60 * 1000 + Convert.ToInt32(sec) * 1000;
                MessageBox.Show(interval.ToString());
                timer1.Interval = interval;
                timer1.Start();
                cmdStart.Enabled = false;
                cmdStop.Enabled = true;
                panel4.BackColor = SystemColors.Control;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();

            nRegister++;
            
            this.mGrid.Rows.Add(lblTime.Text, random.Next(250), random.Next(250), random.Next(250), txtComment.Text.ToString());
            lblNum.Text = nRegister.ToString();        
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            cmdStop.Enabled = false;
            cmdStart.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
        }

        private Hashtable responseToArray()
        {
            Hashtable h = new Hashtable();
            XmlDocument doc = new XmlDocument();
            doc = Tool.Dina_GetState();

            XmlNodeList doc_results = doc.GetElementsByTagName("Result");

            MessageBox.Show("inside response to array");

            foreach (XmlNode pnode in doc_results)
            {
                //MessageBox.Show("pnode");

                foreach (XmlNode cnode in pnode.ChildNodes)
                {
                    //MessageBox.Show("cnode");
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
            this.responseToArray();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            cmdStart.Enabled = true;
            cmdStop.Enabled = false;
            nRegister = 0;
        }

        private void sysTime_Tick(object sender, EventArgs e)
        {
            string szHour;
            szHour = DateTime.Now.ToString("hh:mm:ss");
            lblTime.Text = szHour;
        }

        private void frmMeasurement_Activated(object sender, System.EventArgs e)
        {
            sysTime.Start();
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