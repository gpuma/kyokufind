using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kyokuFind
{
    /// <summary>
    /// logs events into the richtextbox that acts as a console
    /// </summary>
    class Console
    {
        RichTextBox console;
        public Console(RichTextBox txtConsole)
        {
            this.console = txtConsole;
        }
        //writes to the console
        public void Log(string msg)
        {
            console.AppendText(msg + System.Environment.NewLine);
            console.ScrollToCaret();
        }
        public void Clear()
        {
            console.Clear();
        }
    }
}
