using System;
using System.Windows.Forms;
using ContactManager.Controller;

namespace ContactManager.View
{
    // Dashboard (View): zeigt eine kurze Übersicht über den Datenstamm.
    // Die Zahlen werden von der Kontaktverwaltung (Controller) geholt,
    // das Fenster rechnet selber nichts aus.
    public partial class DashboardForm : Form
    {
        // Der Controller mit den Daten
        private Kontaktverwaltung verwaltung;

        // Konstruktor. Bekommt die Kontaktverwaltung vom Hauptfenster
        // übergeben, damit beide mit denselben Daten arbeiten.
        public DashboardForm(Kontaktverwaltung kontaktverwaltung)
        {
            InitializeComponent();
            verwaltung = kontaktverwaltung;
        }

        // Wird beim Öffnen des Fensters ausgeführt und füllt alle Zahlen ab
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

        // Schliesst das Dashboard
        private void CmdSchliessen_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
