using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GisConvert
{
    class CommandRunner
    {
        public static string runCommand(string exePath, string[] arguments)
        {
            return CommandRunner.runCommand(exePath, new List<string>(arguments));
        }

        public static string runCommand(string exePath, List<string> arguments)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            string gisConvertPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            startInfo.WorkingDirectory = Path.GetDirectoryName(gisConvertPath);
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = exePath;
            //startInfo.Arguments = arguments;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardInput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = false;

            process.StartInfo = startInfo;
            process.Start();

            using (StreamWriter sw = process.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    foreach (string command in arguments)
                    {
                        sw.WriteLine(command);
                    }
                    //sw.WriteLine("sdkshell.bat");
                    //sw.WriteLine("ogrinfo.exe -so " + arguments + " waptitle");                    
                }
            }

            string output = "";
            string status = "";
            using (System.IO.StreamReader myOutput = process.StandardOutput)
            {
                output = myOutput.ReadToEnd();

            }
            using (System.IO.StreamReader myError = process.StandardError)
            {
                output += myError.ReadToEnd();
            }

            if (output.Contains("Usage: "))
            {
                status = Environment.NewLine + "Error occured: ogr command syntax incorrect" + Environment.NewLine;
                status += output;
            }
            if (output.Contains("ERROR ") && !(output.Contains("ERROR 1")))
            {
                status = Environment.NewLine + "Error occured: ogr command" + Environment.NewLine;
                status += output;
            }
            process.WaitForExit();
            status = output;
            return output;
        }



        public static string runCommand_OpenShell(string exePath, List<string> arguments)
        {
            //System.Diagnostics.Debugger.Break();
            
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            string gisConvertPath = System.Reflection.Assembly.GetEntryAssembly().Location;            
            startInfo.WorkingDirectory = Path.GetDirectoryName(gisConvertPath);
            string sdkshellPath = "\"" + startInfo.WorkingDirectory + "\\sdkshell.bat\"";
            
            // cmd.exe /K : Carries out the command specified by string but remains
            System.Diagnostics.Process.Start("cmd.exe", "/K " + sdkshellPath);
                        
            string output = "";
            return output;
        }

    }
}
