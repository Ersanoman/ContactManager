using System;
using System.Windows.Forms;
using ContactManager.View;

namespace ContactManager
{
    /// <summary>
    /// Startklasse der Applikation.
    /// Von hier aus wird das Hauptfenster gestartet.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Einstiegspunkt des Programms
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HauptForm());
        }
    }
}
