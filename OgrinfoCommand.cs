using ManyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GisConvert
{
    class OgrinfoCommand : ConsoleCommand
    {
        public OgrinfoCommand()
        {
            IsCommand("ogrinfo");
            //HasOption("i|info", "call ogrinfo", v => isInfo = (v != null));
            AllowsAnyAdditionalArguments("<foo1> <foo2> <fooN> where N is a word");
        }

        public override int Run(string[] remainingArguments)
        {            
            if (remainingArguments != null && remainingArguments.Length >= 1)
            {
                string filePath = remainingArguments[0];
                if (string.IsNullOrEmpty(filePath) == false)
                {
                    List<string> commandList = new string[] { "sdkshell.bat" }.ToList();

                    string layer = string.Empty;
                    if (remainingArguments.Length >= 2)
                    {
                        layer = remainingArguments[1];
                    }                    

                    // -so : summary output
                    // -al : all layer
                    string ogrinfo = string.Format("ogrinfo.exe -so -al \"{0}\" {1}", filePath, layer);
                    commandList.Add(ogrinfo);
                    new OutputForm(commandList).ShowDialog();                    
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
