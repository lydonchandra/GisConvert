using Microsoft.Data.ConnectionUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GisConvert
{
    public partial class Ogr2ogrForm : Form
    {
        string filePath = string.Empty;

        public Ogr2ogrForm(string[] arguments)
        {            
            InitializeComponent();
            string commandOutput = string.Empty;            
            this.richTextBox1.Text = commandOutput;
            this.fillOutputFormats();
            this.fillOutputEpsg();
            this.fillInputEpsg();
            filePath = this.getFilePath(arguments);
        }

        private string getFilePath(string[] arguments)
        {
            return arguments[0];
        }

        private void fillOutputEpsg()
        {
            var epsgArray = new string[] {
                "",
                "EPSG:3857",
                "EPSG:4283",
                "EPSG:28350",
                "EPSG:2193"
            };
            this.cmbOutEpsg.DataSource = epsgArray;
            this.cmbOutEpsg.SelectedIndex = 0;
        }

        private void fillInputEpsg()
        {
            var epsgArray = new string[] {
                "",
                "EPSG:3857",
                "EPSG:4283",
                "EPSG:28350",
                "EPSG:2193"
            };
            this.cmbInputEpsg.DataSource = epsgArray;
            this.cmbInputEpsg.SelectedIndex = 0;
        }

        private void fillOutputFormats()
        {
            // Bind combobox to dictionary
            Dictionary<string, string> outputDict = new Dictionary<string, string>();
            outputDict.Add("Esri Shapefile", "shp");
            outputDict.Add("MapInfo File", "tab");
            outputDict.Add("OCI", "oci");
            outputDict.Add("GeoJSON", "json");
            outputDict.Add("SQLite", "sqlite");

            this.cmbOutputFormat.DataSource = new BindingSource(outputDict, null);
            this.cmbOutputFormat.DisplayMember = "Key";
            this.cmbOutputFormat.ValueMember = "Value";

            // Get combobox selection (in handler)
            //string value = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Value;
            this.cmbOutputFormat.SelectedIndex = 0;
        }


        private string getFinalOgrCommand()
        {
            string ogrTempCommand = "";

            string inputFilePath = filePath;

            string outputFormat = "";
            if (this.cmbOutputFormat.SelectedItem != null)
            {
                outputFormat = ((KeyValuePair<string, string>)this.cmbOutputFormat.SelectedItem).Key;
            }
            else
            {
                if (string.IsNullOrEmpty(this.cmbOutputFormat.Text) == false)
                {
                    outputFormat = this.cmbOutputFormat.Text;
                }
            }

            string transformSrs = string.Empty;
            string selectedOutEpsg = string.Empty;
            if (this.cmbOutEpsg.SelectedItem != null)
            {
                selectedOutEpsg = this.cmbOutEpsg.SelectedItem.ToString();
            }
            else
            {
                if (string.IsNullOrEmpty(this.cmbOutEpsg.Text) == false)
                {
                    selectedOutEpsg = this.cmbOutEpsg.Text;
                }
            }
            if (String.IsNullOrEmpty(selectedOutEpsg) == false)
            {
                transformSrs = "-t_srs " + selectedOutEpsg;
            }


            // sourceSrs
            string sourceSrs = string.Empty;
            string selectedInputEpsg = string.Empty;
            if (this.cmbInputEpsg.SelectedItem != null)
            {
                selectedInputEpsg = this.cmbInputEpsg.SelectedItem.ToString();
            }
            else
            {
                if (string.IsNullOrEmpty(this.cmbInputEpsg.Text) == false)
                {
                    selectedInputEpsg = this.cmbInputEpsg.Text;
                }
            }
            if (String.IsNullOrEmpty(selectedInputEpsg) == false)
            {
                sourceSrs = "-s_srs " + selectedInputEpsg;
            }


            string finalOgrCommand = "";

            string dsn = this.txtDbConnection.Text;
            if (string.IsNullOrEmpty(dsn) == false)
            {
                string server = this.getValue(dsn, "data source");
                string database = this.getValue(dsn, "initial catalog") ?? "testspatial0";
                string uid = this.getValue(dsn, "user id");
                string pwd = this.getValue(dsn, "password");

                ogrTempCommand = string.Format(
                    "MSSQL:server={0};database={1};uid={2};pwd={3}",
                    server, database, uid, pwd
                );

                finalOgrCommand = string.Format("ogr2ogr.exe -overwrite -f MSSQLSpatial \"{0}\" \"{1}\" {2} {3}", ogrTempCommand, inputFilePath, transformSrs, sourceSrs);
            }
            else
            {
                if (string.IsNullOrEmpty(outputFormat) == true)
                {
                    return "outputFormat is empty";
                }

                string ociConnStr = "";
                if (outputFormat.ToUpper() == "OCI")
                {
                    ociConnStr = "OCI:username/password@(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = hostname)(PORT = 1521)))(CONNECT_DATA = (SID =oraclesid)))";
                    finalOgrCommand = string.Format("ogr2ogr.exe -overwrite -f OCI \"{0}\" \"{1}\" {2} {3}", ociConnStr, inputFilePath, transformSrs, sourceSrs);
                }
                else
                {

                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    string fileDir = Path.GetDirectoryName(filePath);
                    string value = ((KeyValuePair<string, string>)this.cmbOutputFormat.SelectedItem).Value;
                    string fileExtension = "." + value;
                    string outputFilePath = fileDir + Path.DirectorySeparatorChar + fileName + fileExtension;

                    finalOgrCommand = string.Format("ogr2ogr.exe -overwrite -f \"{0}\" {1} {2} \"{3}\" \"{4}\"", outputFormat, transformSrs, sourceSrs, outputFilePath, inputFilePath);
                }
            }
            return finalOgrCommand;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (chkUseDsn.Checked == true)
            {
                if (string.IsNullOrEmpty(txtDbConnection.Text) == false)
                {
                    //ogr2ogr -overwrite -f MSSQLSpatial "MSSQL:server=.\MSSQLSERVER2008;database=geodb;trusted_connection=yes" "rivers.tab"
                    //"Data Source=localhost;Integrated Security=False;User ID=sa;Password=sa123!@#"

                    //string dsn = this.txtDbConnection.Text;
                    //string server = this.getValue(dsn, "data source");
                    //string database = this.getValue(dsn, "initial catalog") ?? "testspatial0";
                    //string uid = this.getValue(dsn, "user id");
                    //string pwd = this.getValue(dsn, "password");

                    //string ogrTempCommand = string.Format(
                    //    "MSSQL:server={0};database={1};uid={2};pwd={3}",
                    //    server, database, uid, pwd
                    //);

                    //string inputFilePath = filePath;

                    //string transformSrs = string.Empty;
                    //string selectedOutEpsg = this.cmbOutEpsg.SelectedItem.ToString();
                    //if (String.IsNullOrEmpty(selectedOutEpsg) == false)
                    //{
                    //    transformSrs = "-t_srs " + selectedOutEpsg;
                    //}

                    string ogrCommand = this.getFinalOgrCommand();
                    var ogr2ogrArgs = new List<string> {
                        ogrCommand
                    };
                    new Ogr2ogrCommand().Run(ogr2ogrArgs.ToArray());
                }
                else
                {
                    MessageBox.Show("Enter DSN");
                }
            }
            else
            {
                string outputFormat = ((KeyValuePair<string, string>)this.cmbOutputFormat.SelectedItem).Key;
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string fileDir = Path.GetDirectoryName(filePath);

                string value = ((KeyValuePair<string, string>)this.cmbOutputFormat.SelectedItem).Value;
                string fileExtension = "." + value;

                string outputFilePath = fileDir + Path.DirectorySeparatorChar + fileName + fileExtension;
                var ogr2ogrArgs = new List<string> { 
                    outputFormat, 
                    filePath, 
                    outputFilePath 
                };
                string selectedOutEpsg = this.cmbOutEpsg.SelectedItem.ToString();
                if (String.IsNullOrEmpty(selectedOutEpsg) == false)
                {
                    ogr2ogrArgs.Add(selectedOutEpsg);
                }
                new Ogr2ogrCommand().Run(ogr2ogrArgs.ToArray());
            }
        }


                
        
        private void btnBrowseDatabase_Click(object sender, EventArgs e)
        {
            //Thread thread = new Thread(new
            //  ThreadStart(GetDirectory));
            //thread.SetApartmentState(ApartmentState.STA);
            //thread.Start();
            //thread.Join();

            DataConnectionDialog dcDialog = new DataConnectionDialog();
            //DataConnectionConfiguration dcs = new DataConnectionConfiguration(null);
            //Microsoft.Data.ConnectionUI.DataSource.AddStandardDataSources(dcDialog);

            dcDialog.DataSources.Add(DataSource.SqlDataSource);
            dcDialog.DataSources.Add(DataSource.AccessDataSource);
            dcDialog.DataSources.Add(DataSource.OdbcDataSource);
            dcDialog.DataSources.Add(DataSource.SqlFileDataSource);
            dcDialog.SelectedDataSource = DataSource.SqlDataSource;

            dcDialog.SelectedDataProvider = DataProvider.SqlDataProvider;

            //            dcDialog.SaveSelection = true;            
            dcDialog.AcceptButton = this.btnConvert;

            if (Microsoft.Data.ConnectionUI.DataConnectionDialog.Show(dcDialog) == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dcDialog.ConnectionString) == false)
                {
                    //ogr2ogr -overwrite -f MSSQLSpatial "MSSQL:server=.\MSSQLSERVER2008;database=geodb;trusted_connection=yes" "rivers.tab"
                    //"Data Source=localhost;Integrated Security=False;User ID=sa;Password=sa123!@#"

                    // load tables
                    //using (SqlConnection connection = new SqlConnection(dcDialog.ConnectionString))
                    //{
                    //    connection.Open();
                    //    SqlCommand cmd = new SqlCommand("SELECT * FROM sys.Tables", connection);
                    //    using (SqlDataReader reader = cmd.ExecuteReader())
                    //    {
                    //        while (reader.Read())
                    //        {
                    //            Console.WriteLine(reader.HasRows);
                    //        }
                    //    }
                    //}

                    this.txtDbConnection.Text = dcDialog.ConnectionString;
                    this.rtbFinalOgrCommand.Text = this.getFinalOgrCommand();
                }
            }
        }
         

        public string getValue(string connectionString, string inKey)
        {
            if (string.IsNullOrEmpty(inKey) == true)
            {
                return string.Empty;
            }
            string[] tokens = connectionString.Split(';');
            foreach (string token in tokens)
            {
                string[] kvp = token.Split('=');
                if (kvp != null && kvp.Length > 0)
                {
                    string key = kvp[0];
                    if (kvp.Length > 1)
                    {
                        string value = kvp[1];
                        if (key.ToLower() == inKey.ToLower())
                        {
                            return value;
                        }
                    }
                }
            }
            return string.Empty;
        }

        private void btnOgrCommand_Click(object sender, EventArgs e)
        {
            this.rtbFinalOgrCommand.Text = this.getFinalOgrCommand();
        }

        private void btnOpenCommandPrompt_Click(object sender, EventArgs e)
        {            
            var commandList = new string[] { "sdkshell.bat" , "pause" };
            CommandRunner.runCommand_OpenShell("cmd.exe", ((string[])commandList).ToList());
        }

        private void Ogr2ogrForm_Load(object sender, EventArgs e)
        {

        }
        
            
            

        
    }
}

 