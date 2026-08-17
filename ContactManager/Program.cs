using System;
using System.Windows.Forms;
using ContactManager.View;

namespace ContactManager
{
    // Startklasse der Applikation.
    // Von hier aus wird das Hauptfenster gestartet.
    internal static class Program
    {
        // Einstiegspunkt des Programms
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HauptForm());
        }
    }
}
