using System;
using System.Windows.Forms;
using ContactManager.Controller;

namespace ContactManager.View
{
    /// <summary>
    /// Dashboard (View): zeigt eine kurze Übersicht über den Datenstamm.
    /// Die Zahlen werden von der Kontaktverwaltung (Controller) geholt,
    /// das Fenster rechnet selber nichts aus.
    /// </summary>
    public partial class DashboardForm : Form
    {
        /// <summary>
        /// Der Controller mit den Daten
        /// </summary>
        private Kontaktverwaltung verwaltung;

        /// <summary>
        /// Konstruktor. Bekommt die Kontaktverwaltung vom Hauptfenster
        /// übergeben, damit beide mit denselben Daten arbeiten.
        /// </summary>
        /// <param name="kontaktverwaltung">Die Verwaltung mit den anzuzeigenden Daten</param>
        public DashboardForm(Kontaktverwaltung kontaktverwaltung)
        {
            InitializeComponent();
            verwaltung = kontaktverwaltung;
        }

        /// <summary>
        /// Wird beim Öffnen des Fensters ausgeführt und füllt alle Zahlen ab
        /// </summary>
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            int anzahlLernende = verwaltung.Anzahl("Lernender");

            // Achtung: Ein Lernender ist auch ein Mitarbeiter. Damit die
            // Zahlen für den Benutzer verständlich bleiben, werden die
            // Lernenden hier abgezogen und separat ausgewiesen.
            int anzahlMitarbeiter = verwaltung.Anzahl("Mitarbeiter") - anzahlLernende;

            LblTotalWert.Text = Convert.ToString(verwaltung.Anzahl("Alle"));
            LblKundenWert.Text = Convert.ToString(verwaltung.Anzahl("Kunde"));
            LblMitarbeiterWert.Text = Convert.ToString(anzahlMitarbeiter);
            LblLernendeWert.Text = Convert.ToString(anzahlLernende);
            LblAktivWert.Text = Convert.ToString(verwaltung.AnzahlNachStatus(true));
            LblPassivWert.Text = Convert.ToString(verwaltung.AnzahlNachStatus(false));
            LblNotizenWert.Text = Convert.ToString(verwaltung.AnzahlKontaktnotizen());
            LblNaechsteNummerWert.Text = Convert.ToString(verwaltung.NaechsteMitarbeiternummer());
        }

        /// <summary>
        /// Schliesst das Dashboard
        /// </summary>
        private void CmdSchliessen_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
