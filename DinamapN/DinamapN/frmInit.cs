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

        private void btnStudy_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPatientID.Text != "" && txtStudyID.Text != "")
                {
                    patientID = txtPatientID.Text;
                    studyID = txtStudyID.Text;

                    Directory.CreateDirectory("C:\\" + studyID + "_" + patientID);
                    Directory.CreateDirectory("C:\\" + studyID + "_" + patientID + "\\raw_xml");
                    Directory.CreateDirectory("C:\\" + studyID + "_" + patientID + "\\queued_sql");
               
                    frmMain fMain = new frmMain(patientID, studyID);

                    this.Visible = false;
                    
                    fMain.Show();
                }
                else
                {
                    MessageBox.Show("Please enter Patient ID and Study ID.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Local directory could not be created.");
            }
        }

        private void frmInit_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmStart fStart = new frmStart();

            this.Visible = false;

            fStart.Show();
        }

        private void frmInit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = bindingSource1;
                String query = "select * from patient where Last_Name LIKE '" + this.textBox1.Text + "%' AND First_Name LIKE '" + this.textBox2.Text + "%'";
                OdbcConnection MyConnection = new OdbcConnection("DSN=dinamapMySQL2");
                OdbcDataAdapter dataAdapter = new OdbcDataAdapter(query, MyConnection.ConnectionString);
                MyConnection.Open();

                DataTable t = new DataTable();
                
                dataAdapter.Fill(t);
                bindingSource1.DataSource = t;

                dataGridView1.Columns[0].Visible=false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtPatientID.Text = dataGridView1.SelectedRows[1].ToString();
        }
    }
}