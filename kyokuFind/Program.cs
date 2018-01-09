using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace kyokuFind
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //required variables for the app are read into memory
            CONFIG.ReadConfigFile();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
