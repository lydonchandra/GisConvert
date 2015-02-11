using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GisConvert
{
    public partial class AddContextMenuForm : Form
    {
        public AddContextMenuForm()
        {
            InitializeComponent();
        }
                

        private void btnAddToRighClick_Click(object sender, EventArgs e)
        {
            this.addGisInfoKey();
            this.addGisConvertKey();
        }

        private void addGisInfoKey()
        {
            this.addClassesRootRegistryKey(@"*\shell\GisInfo\command", "info");
        }

        private void addGisConvertKey()
        {            
            this.addClassesRootRegistryKey(@"*\shell\GisConvert\command", "convert");
        }

        private void addClassesRootRegistryKey(string subkey, string commandType)
        {
            Microsoft.Win32.RegistryKey key;
            //add to directory right-click-menu, ie: if we right click on a folder
            //key = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(@"Directory\Background\shell\GisConvert\command");
            //key.SetValue("", @"C:\temp2\GisConvert\GisConvert\bin\Debug\GisConvert.exe");            

            key = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(subkey);
            string gisConvertPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            string registryValue = string.Format(@"""{0}"" ""{1}"" ""%1"" ", gisConvertPath, commandType);
            
            //setting "(Default)" value, key is an empty string
            //key.SetValue("(Default)", @"C:\temp2\GisConvert\GisConvert\bin\Debug\GisConvert.exe");        
            //"C:\temp2\GisConvert\GisConvert\bin\Debug\GisConvert.exe" "info" "%1" 
            key.SetValue("", registryValue);
            key.Close();
        }

        private void btnRemoveFromRightClick_Click(object sender, EventArgs e)
        {
            this.removeClassesRootRegistryKey(@"*\shell\GisInfo");
            this.removeClassesRootRegistryKey(@"*\shell\GisConvert");
        }

        private void removeClassesRootRegistryKey(string subkey) 
        {
            Microsoft.Win32.RegistryKey key;
            Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree(subkey);            
        }
    }
}
