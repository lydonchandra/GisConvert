using ManyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GisConvert
{
    class InfoCommand : ConsoleCommand
    {
        public InfoCommand()
        {
            IsCommand("info");            
            AllowsAnyAdditionalArguments("<foo1> <foo2> <fooN> where N is a word");
        }

        public override int Run(string[] remainingArguments)
        {
            if (this.isOgrType(remainingArguments) == true)
            {
                new OgrinfoCommand().Run(remainingArguments);
            }
            return 0;
        }

        public bool isOgrType(string[] remainingArguments)
        {
            //TODO return false for GDAL type
            return true;
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
