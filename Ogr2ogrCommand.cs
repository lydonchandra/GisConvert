using ManyConsole;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GisConvert
{
    class Ogr2ogrCommand : ConsoleCommand
    {
        public Ogr2ogrCommand()
        {
            IsCommand("ogr2ogr");
            //HasOption("i|info", "call ogrinfo", v => isInfo = (v != null));
            AllowsAnyAdditionalArguments("<foo1> <foo2> <fooN> where N is a word");
        }

        public override int Run(string[] remainingArguments)
        {
            if (remainingArguments != null && remainingArguments.Length >= 1)
            {
                List<string> commandList = new string[] { "sdkshell.bat" }.ToList();

                if (remainingArguments.Length == 1)
                {
                    string fullOgrCommand = remainingArguments[0];
                    //ie ogr2ogr -overwrite -f MSSQLSpatial "MSSQL:server=.\MSSQLSERVER2008;database=geodb;trusted_connection=yes" "rivers.tab"
                    commandList.Add(remainingArguments[0]);
                    new OutputForm(commandList).ShowDialog();
                }
                else
                {
                    string outputFormat = remainingArguments[0];
                    if (string.IsNullOrEmpty(outputFormat) == false)
                    {
                        if (remainingArguments.Length >= 3)
                        {
                            string inputPath = remainingArguments[1];
                            string outputPath = remainingArguments[2];
                            if (File.Exists(outputPath) == true)
                            {
                                string dirPath = Path.GetDirectoryName(outputPath);
                                string fileExt = Path.GetExtension(outputPath);
                                string fileName = Path.GetFileNameWithoutExtension(outputPath);
                                outputPath = dirPath + Path.DirectorySeparatorChar + fileName + "_" + DateTime.Now.Ticks + fileExt;
                            }
                            string outEpsgArg = string.Empty;
                            if (remainingArguments.Length >= 4)
                            {
                                if (string.IsNullOrEmpty(remainingArguments[3]) == false)
                                {
                                    //t_srs : transform to this srs
                                    outEpsgArg = " -t_srs " + remainingArguments[3];
                                }
                            }
                            string ogrinfo = string.Format(
                                "ogr2ogr.exe -f  \"{0}\"   \"{1}\"   \"{2}\"  {3} ",
                                outputFormat,
                                outputPath,
                                inputPath,
                                (string.IsNullOrEmpty(outEpsgArg) == false) ? outEpsgArg : string.Empty);

                            commandList.Add(ogrinfo);
                            new OutputForm(commandList).ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Invalid ogr2ogr parameters");
                        }
                    }
                }
            }
            return 0;
        }

        /*
         * public Ogr2ogrForm(List<string> commandList)
        {            
            InitializeComponent();
                        
            //this.filePath = filePath;
            this.richTextBox1.Text = filePath;
            //var commandList = new List<string>();            
            //commandList.Add("sdkshell.bat");
            //commandList.Add("ogrinfo.exe -so " + filePath + " waptitle");
            string commandOutput = CommandRunner.runCommand("cmd.exe", commandList);
            this.richTextBox1.Text = commandOutput;
        }
         */

        /*Path = remainingArguments[0];

            if (File.Exists(Path))
            {
                PrintEmlFile(Path);
            }
            else if (Directory.Exists(Path))
            {
                PrintEmlDirectory(Path);
            }
            else
            {
                throw new Exception("Could not find file or directory at " + Path);
            }
        
         */
    }
}
