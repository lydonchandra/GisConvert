using ManyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GisConvert
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string [] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // locate any commands in the assembly (or use an IoC container, or whatever source)
            var commands = GetCommands();
            // then run them.
            if (args.Length > 0)
            {
                return ConsoleCommandDispatcher.DispatchCommand(commands, args, Console.Out);
            }
            else
            {
                Application.Run(new AddContextMenuForm());
                return 0;
            }
        }

        public static IEnumerable<ConsoleCommand> GetCommands()
        {
            return ConsoleCommandDispatcher.FindCommandsInSameAssemblyAs(typeof(Program));
        }
    }
}
