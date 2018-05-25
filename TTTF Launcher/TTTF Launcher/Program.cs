using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTTF_Launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            launcher l = new launcher();
            bool i = false;
            while (!l.IsDisposed)
            {
                if (!i)
                    l.Show();
                i = true;
                Application.DoEvents();
            }

        }
    }
}
