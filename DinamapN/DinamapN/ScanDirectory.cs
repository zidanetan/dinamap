using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DinamapN
{
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