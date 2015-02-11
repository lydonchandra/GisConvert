using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GisConvert
{
    public partial class OutputForm : Form
    {
        string filePath;
        public OutputForm(object commandList)
        {            
            InitializeComponent();
            string commandOutput = string.Empty;
            if (commandList.GetType() == typeof(List<string>))
            {
                commandOutput = CommandRunner.runCommand("cmd.exe", (List<string>)commandList);
                
            }
            else if (commandList.GetType() == typeof(string[]))
            {
                commandOutput = CommandRunner.runCommand("cmd.exe", ( (string[])commandList).ToList() );
            }
            this.richTextBox1.Text = commandOutput;
        }
    }
}
