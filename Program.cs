using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Estore.Ce.UI;

namespace Estore.Ce
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("An unexpected error occurred:\n" + ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
            }
        }
    }
}