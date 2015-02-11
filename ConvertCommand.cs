using ManyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GisConvert
{
    class ConvertCommand : ConsoleCommand
    {
        public ConvertCommand()
        {
            IsCommand("convert");            
            AllowsAnyAdditionalArguments("<foo1> <foo2> <fooN> where N is a word");
        }

        public override int Run(string[] remainingArguments)
        {
            if (this.isOgrType(remainingArguments) == true)
            {
                new Ogr2ogrForm(remainingArguments).ShowDialog();
            }
            else
            {
                //gdal
            }
            return 0;
        }

        public bool isOgrType(string[] remainingArguments)
        {
            //TODO return false for GDAL type
            return true;
        }

    }
}
