using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Fire_Emblem_3DS_Convoy_Editor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 0)
                Application.Run(new ConvoyEditor());
            else
                Application.Run(new ConvoyEditor(args[0]));
        }
    }
}
