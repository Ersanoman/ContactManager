using System;
using System.Drawing;
using System.Windows.Forms;
using ContactManager.Controller;

namespace ContactManager.View
{
    /// <summary>
    /// Dashboard (View): zeigt eine kurze Übersicht über den Datenstamm
    /// sowie ein Kreisdiagramm mit der Verteilung der drei Kategorien.
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
        /// Farbe der Kunden im Kreisdiagramm (dunkelblau)
        /// </summary>
        private Color farbeKunden = Color.FromArgb(31, 78, 121);

        /// <summary>
        /// Farbe der Mitarbeiter im Kreisdiagramm (orange)
        /// </summary>
        private Color farbeMitarbeiter = Color.FromArgb(199, 123, 48);

        /// <summary>
        /// Farbe der Lernenden im Kreisdiagramm (grün)
        /// </summary>
        private Color farbeLernende = Color.FromArgb(79, 138, 91);

        /// <summary>
        /// Anzahl Kunden, wird beim Öffnen des Fensters ermittelt
        /// </summary>
        private int anzahlKunden;

        /// <summary>
        /// Anzahl Mitarbeiter ohne die Lernenden
        /// </summary>
        private int anzahlMitarbeiter;

        /// <summary>
        /// Anzahl Lernende
        /// </summary>
        private int anzahlLernende;

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
            anzahlLernende = verwaltung.Anzahl("Lernender");

            // Achtung: Ein Lernender ist auch ein Mitarbeiter. Damit die
            // Zahlen für den Benutzer verständlich bleiben, werden die
            // Lernenden hier abgezogen und separat ausgewiesen.
            anzahlMitarbeiter = verwaltung.Anzahl("Mitarbeiter") - anzahlLernende;
            anzahlKunden = verwaltung.Anzahl("Kunde");

            LblTotalWert.Text = Convert.ToString(verwaltung.Anzahl("Alle"));
            LblKundenWert.Text = Convert.ToString(anzahlKunden);
            LblMitarbeiterWert.Text = Convert.ToString(anzahlMitarbeiter);
            LblLernendeWert.Text = Convert.ToString(anzahlLernende);
            LblAktivWert.Text = Convert.ToString(verwaltung.AnzahlNachStatus(true));
            LblPassivWert.Text = Convert.ToString(verwaltung.AnzahlNachStatus(false));
            LblNotizenWert.Text = Convert.ToString(verwaltung.AnzahlKontaktnotizen());
            LblNaechsteNummerWert.Text = Convert.ToString(verwaltung.NaechsteMitarbeiternummer());

            // Legende: farbiges Quadrat und Text pro Kategorie
            int total = anzahlKunden + anzahlMitarbeiter + anzahlLernende;
            PnlFarbeKunden.BackColor = farbeKunden;
            PnlFarbeMitarbeiter.BackColor = farbeMitarbeiter;
            PnlFarbeLernende.BackColor = farbeLernende;
            LblLegendeKunden.Text = LegendeText("Kunden", anzahlKunden, total);
            LblLegendeMitarbeiter.Text = LegendeText("Mitarbeiter", anzahlMitarbeiter, total);
            LblLegendeLernende.Text = LegendeText("Lernende", anzahlLernende, total);
        }

        /// <summary>
        /// Baut den Text für eine Zeile der Legende zusammen,
        /// zum Beispiel "Kunden: 6 (55 %)".
        /// </summary>
        /// <param name="bezeichnung">Name der Kategorie</param>
        /// <param name="anzahl">Anzahl Personen dieser Kategorie</param>
        /// <param name="total">Anzahl Personen insgesamt</param>
        /// <returns>Der fertige Text für die Legende</returns>
        private string LegendeText(string bezeichnung, int anzahl, int total)
        {
            // Ohne Daten gibt es nichts zu rechnen (und keine Division durch 0)
            if (total == 0)
            {
                return bezeichnung + ": 0";
            }

            int prozent = Convert.ToInt32(Math.Round(100.0 * anzahl / total));
            return bezeichnung + ": " + anzahl + " (" + prozent + " %)";
        }

        /// <summary>
        /// Zeichnet das Kreisdiagramm. Diese Methode wird von Windows immer
        /// dann aufgerufen, wenn die Fläche neu gezeichnet werden muss.
        /// </summary>
        private void PnlDiagramm_Paint(object sender, PaintEventArgs e)
        {
            int total = anzahlKunden + anzahlMitarbeiter + anzahlLernende;

            // Ohne Daten wird nur ein Hinweis geschrieben, sonst müsste
            // durch 0 geteilt werden
            if (total == 0)
            {
                e.Graphics.DrawString("Noch keine Daten", Font, Brushes.Gray, 22, 66);
                return;
            }

            // Kanten weicher zeichnen, damit der Kreis nicht stufig wirkt
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Das Quadrat, in welches der Kreis gezeichnet wird
            Rectangle flaeche = new Rectangle(0, 0, 148, 148);

            // Bei -90 Grad beginnen, damit das erste Segment oben startet.
            // Jedes Segment liefert den Startwinkel für das nächste zurück.
            float startwinkel = -90;
            startwinkel = SegmentZeichnen(e.Graphics, flaeche, startwinkel, anzahlKunden, total, farbeKunden);
            startwinkel = SegmentZeichnen(e.Graphics, flaeche, startwinkel, anzahlMitarbeiter, total, farbeMitarbeiter);
            SegmentZeichnen(e.Graphics, flaeche, startwinkel, anzahlLernende, total, farbeLernende);
        }

        /// <summary>
        /// Zeichnet ein einzelnes Kreissegment und gibt den Winkel zurück,
        /// bei dem das nächste Segment beginnen muss.
        /// </summary>
        /// <param name="zeichner">Die Zeichenfläche des Panels</param>
        /// <param name="flaeche">Quadrat, in das der Kreis passt</param>
        /// <param name="startwinkel">Winkel, bei dem das Segment beginnt</param>
        /// <param name="anzahl">Anzahl Personen dieser Kategorie</param>
        /// <param name="total">Anzahl Personen insgesamt</param>
        /// <param name="farbe">Farbe des Segments</param>
        /// <returns>Startwinkel für das nächste Segment</returns>
        private float SegmentZeichnen(Graphics zeichner, Rectangle flaeche, float startwinkel,
                                      int anzahl, int total, Color farbe)
        {
            // Anteil am ganzen Kreis: 360 Grad mal Anteil dieser Kategorie
            float winkel = 360f * anzahl / total;

            if (anzahl > 0)
            {
                SolidBrush pinsel = new SolidBrush(farbe);
                zeichner.FillPie(pinsel, flaeche, startwinkel, winkel);
                pinsel.Dispose();
            }

            return startwinkel + winkel;
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
