using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ContactManager.Controller;
using ContactManager.Model;

namespace ContactManager.View
{
    /// <summary>
    /// Hauptfenster der Applikation (View).
    /// Zeigt alle Personen in einer Liste an und bietet die Suche sowie
    /// die Aktionen Erfassen, Bearbeiten, Aktivieren/Deaktivieren und
    /// Löschen an. Die eigentliche Logik macht die Kontaktverwaltung
    /// (Controller), das Fenster zeigt nur an.
    /// </summary>
    public partial class HauptForm : Form
    {
        /// <summary>
        /// Der Controller mit der ganzen Verwaltungslogik
        /// </summary>
        private Kontaktverwaltung verwaltung;

        /// <summary>
        /// Konstruktor: erstellt den Controller (dieser lädt automatisch
        /// den Datenstamm) und füllt das Kategorie-Auswahlfeld
        /// </summary>
        public HauptForm()
        {
            InitializeComponent();

            // Die Datendatei liegt im gleichen Ordner wie die Programmdatei
            verwaltung = new Kontaktverwaltung(
                Path.Combine(Application.StartupPath, "kontaktdaten.xml"));

            // Auswahlfeld für die Such-Kategorie füllen. Die Texte sind
            // bewusst ausführlich: ein Lernender ist auch ein Mitarbeiter,
            // darum findet "Mitarbeiter" auch die Lernenden.
            CmbKategorie.Items.Add("Alle");
            CmbKategorie.Items.Add("Kunden");
            CmbKategorie.Items.Add("Mitarbeiter (inkl. Lernende)");
            CmbKategorie.Items.Add("Nur Lernende");
            CmbKategorie.SelectedIndex = 0;
        }

        /// <summary>
        /// Wird nach dem Erscheinen des Fensters ausgeführt und zeigt
        /// alle geladenen Personen an
        /// </summary>
        private void HauptForm_Load(object sender, EventArgs e)
        {
            ListeAnzeigen(verwaltung.AlleSortiert());

            // Konnte die Datendatei nicht gelesen werden, erfährt es der
            // Benutzer hier. Die Meldung kommt vom Fenster und nicht vom
            // Datenspeicher, damit die Logik von der Anzeige getrennt bleibt.
            if (verwaltung.LetzterFehler != "")
            {
                MessageBox.Show(verwaltung.LetzterFehler, "Hinweis zum Datenstamm",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Zeigt die übergebenen Personen in der ListBox an und
        /// aktualisiert die Statuszeile. Die ListBox zeigt für jedes
        /// Objekt automatisch dessen ToString-Text an.
        /// </summary>
        /// <param name="anzuzeigendePersonen">Die anzuzeigenden Personen</param>
        private void ListeAnzeigen(List<Person> anzuzeigendePersonen)
        {
            LstPersonen.Items.Clear();

            foreach (Person person in anzuzeigendePersonen)
            {
                LstPersonen.Items.Add(person);
            }

            LblStatus.Text = "Angezeigt: " + LstPersonen.Items.Count + " von " +
                             verwaltung.AllePersonen.Count + " Personen | " +
                             "Alle Änderungen werden automatisch gespeichert";
        }

        /// <summary>
        /// Wendet die aktuell eingestellten Suchkriterien (neu) an.
        /// Sind alle Felder leer, werden einfach alle Personen angezeigt.
        /// So bleibt der Suchfilter auch nach einer Aktion (z.B. Bearbeiten)
        /// erhalten.
        /// </summary>
        private void AnsichtAktualisieren()
        {
            List<Person> resultate = verwaltung.Suchen(
                TxtNachname.Text.Trim(),
                TxtVorname.Text.Trim(),
                ChkGeburtsdatum.Checked,
                DtpGeburtsdatum.Value.Date,
                GewaehlteKategorie());

            ListeAnzeigen(resultate);
        }

        /// <summary>
        /// Wandelt den angezeigten Text der Auswahlliste in die Kategorie
        /// um, welche die Kontaktverwaltung versteht.
        /// </summary>
        /// <returns>"Alle", "Kunde", "Mitarbeiter" oder "Lernender"</returns>
        private string GewaehlteKategorie()
        {
            string auswahl = Convert.ToString(CmbKategorie.SelectedItem);

            if (auswahl == "Kunden")
            {
                return "Kunde";
            }
            else if (auswahl == "Mitarbeiter (inkl. Lernende)")
            {
                return "Mitarbeiter";
            }
            else if (auswahl == "Nur Lernende")
            {
                return "Lernender";
            }

            return "Alle";
        }

        /// <summary>
        /// Fragt nach, wenn bereits eine Person mit gleichem Vornamen,
        /// Nachnamen und Geburtsdatum erfasst ist. Doppelerfassungen
        /// werden so bemerkt, aber nicht ganz verboten: es kann echte
        /// Namensgleichheit geben.
        /// </summary>
        /// <param name="person">Die neu erfasste Person</param>
        /// <returns>true, wenn die Person erfasst werden soll</returns>
        private bool ErfassenBestaetigt(Person person)
        {
            if (!verwaltung.ExistiertBereits(person))
            {
                return true;
            }

            DialogResult antwort = MessageBox.Show(
                "Es ist bereits eine Person mit diesem Vornamen, Nachnamen " +
                "und Geburtsdatum erfasst.\n\nSoll sie trotzdem erfasst werden?",
                "Mögliche Doppelerfassung",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return antwort == DialogResult.Yes;
        }

        /// <summary>
        /// Gibt die aktuell ausgewählte Person zurück oder null,
        /// wenn nichts ausgewählt ist
        /// </summary>
        /// <returns>Die ausgewählte Person oder null</returns>
        private Person AusgewaehltePerson()
        {
            if (LstPersonen.SelectedItem == null)
            {
                return null;
            }

            return (Person)LstPersonen.SelectedItem;
        }

        /// <summary>
        /// Markiert die übergebene Person in der Liste, damit die Auswahl
        /// nach einer Aktion (z.B. Bearbeiten oder Statuswechsel) nicht
        /// verloren geht. Ist die Person gerade nicht in der Liste
        /// (z.B. vom Suchfilter ausgeblendet), passiert einfach nichts.
        /// </summary>
        /// <param name="person">Die zu markierende Person</param>
        private void PersonMarkieren(Person person)
        {
            LstPersonen.SelectedItem = person;
        }

        /// <summary>
        /// Startet die Suche mit den eingegebenen Kriterien
        /// </summary>
        private void CmdSuchen_Click(object sender, EventArgs e)
        {
            AnsichtAktualisieren();
        }

        /// <summary>
        /// Setzt alle Suchkriterien zurück und zeigt wieder alle Personen an
        /// </summary>
        private void CmdAlleAnzeigen_Click(object sender, EventArgs e)
        {
            TxtNachname.Text = "";
            TxtVorname.Text = "";
            ChkGeburtsdatum.Checked = false;
            CmbKategorie.SelectedIndex = 0;

            ListeAnzeigen(verwaltung.AlleSortiert());
        }

        /// <summary>
        /// Schaltet das Geburtsdatum-Feld frei, wenn danach gesucht
        /// werden soll
        /// </summary>
        private void ChkGeburtsdatum_CheckedChanged(object sender, EventArgs e)
        {
            DtpGeburtsdatum.Enabled = ChkGeburtsdatum.Checked;
        }

        /// <summary>
        /// Öffnet den Dialog zum Erfassen eines neuen Kunden
        /// </summary>
        private void CmdNeuerKunde_Click(object sender, EventArgs e)
        {
            KundeForm dialog = new KundeForm(null);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (!ErfassenBestaetigt(dialog.Ergebnis))
                {
                    return;
                }

                verwaltung.Hinzufuegen(dialog.Ergebnis);

                // Filter zurücksetzen, damit die neue Person sicher
                // sichtbar ist
                CmdAlleAnzeigen_Click(sender, e);

                // Die neu erfasste Person direkt markieren
                PersonMarkieren(dialog.Ergebnis);
            }
        }

        /// <summary>
        /// Öffnet den Dialog zum Erfassen eines neuen Mitarbeiters oder
        /// Lernenden. Die Mitarbeiternummer wird automatisch vergeben.
        /// </summary>
        private void CmdNeuerMitarbeiter_Click(object sender, EventArgs e)
        {
            MitarbeiterForm dialog = new MitarbeiterForm(null);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (!ErfassenBestaetigt(dialog.Ergebnis))
                {
                    return;
                }

                verwaltung.Hinzufuegen(dialog.Ergebnis);

                // Filter zurücksetzen, damit die neue Person sicher
                // sichtbar ist
                CmdAlleAnzeigen_Click(sender, e);

                // Die neu erfasste Person direkt markieren
                PersonMarkieren(dialog.Ergebnis);
            }
        }

        /// <summary>
        /// Öffnet die ausgewählte Person im passenden Dialog zum
        /// Bearbeiten. Mit dem is-Operator wird geprüft, ob es ein Kunde
        /// oder ein Mitarbeiter ist.
        /// </summary>
        private void CmdBearbeiten_Click(object sender, EventArgs e)
        {
            Person person = AusgewaehltePerson();

            if (person == null)
            {
                MessageBox.Show("Bitte zuerst eine Person aus der Liste auswählen.",
                    "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (person is Kunde)
            {
                KundeForm dialog = new KundeForm((Kunde)person);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    verwaltung.Ersetzen(person, dialog.Ergebnis);
                    AnsichtAktualisieren();

                    // Das Ergebnis markieren (nicht "person", denn beim
                    // Ersetzen wurde ein neues Objekt erzeugt)
                    PersonMarkieren(dialog.Ergebnis);
                }
            }
            else if (person is Mitarbeiter)
            {
                // Gilt auch für Lernende, denn ein Lernender ist ein Mitarbeiter
                MitarbeiterForm dialog = new MitarbeiterForm((Mitarbeiter)person);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    verwaltung.Ersetzen(person, dialog.Ergebnis);
                    AnsichtAktualisieren();

                    // Das Ergebnis markieren (nicht "person", denn beim
                    // Ersetzen wurde ein neues Objekt erzeugt)
                    PersonMarkieren(dialog.Ergebnis);
                }
            }
        }

        /// <summary>
        /// Doppelklick auf einen Eintrag öffnet ihn direkt zum Bearbeiten
        /// (gleiche Methode wie der Button, damit kein doppelter Code entsteht)
        /// </summary>
        private void LstPersonen_DoubleClick(object sender, EventArgs e)
        {
            CmdBearbeiten_Click(sender, e);
        }

        /// <summary>
        /// Schaltet den Status der ausgewählten Person zwischen aktiv
        /// und passiv um
        /// </summary>
        private void CmdAktivPassiv_Click(object sender, EventArgs e)
        {
            Person person = AusgewaehltePerson();

            if (person == null)
            {
                MessageBox.Show("Bitte zuerst eine Person aus der Liste auswählen.",
                    "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            verwaltung.AktivUmschalten(person);
            AnsichtAktualisieren();

            // Die Person bleibt nach dem Statuswechsel markiert
            PersonMarkieren(person);
        }

        /// <summary>
        /// Löscht die ausgewählte Person nach einer Sicherheitsabfrage
        /// </summary>
        private void CmdLoeschen_Click(object sender, EventArgs e)
        {
            Person person = AusgewaehltePerson();

            if (person == null)
            {
                MessageBox.Show("Bitte zuerst eine Person aus der Liste auswählen.",
                    "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Sicherheitsabfrage, damit niemand aus Versehen Daten löscht
            DialogResult antwort = MessageBox.Show(
                "Soll die folgende Person wirklich gelöscht werden?\n\n" + person,
                "Löschen bestätigen",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (antwort == DialogResult.Yes)
            {
                verwaltung.Loeschen(person);
                AnsichtAktualisieren();
            }
        }

        /// <summary>
        /// Importiert Kontakte aus einer CSV-Datei. Die erste Spalte der
        /// Datei bestimmt, ob ein Kunde, ein Mitarbeiter oder ein Lernender
        /// erfasst wird. Bereits vorhandene Personen werden übersprungen,
        /// damit dieselbe Datei nicht doppelt importiert werden kann.
        /// </summary>
        private void CmdCsvImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dateiauswahl = new OpenFileDialog();
            dateiauswahl.Title = "CSV-Datei mit Kontakten auswählen";
            dateiauswahl.Filter = "CSV-Dateien (*.csv)|*.csv|Alle Dateien (*.*)|*.*";

            if (dateiauswahl.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                CsvImporter importer = new CsvImporter();
                List<Person> geleseneKontakte = importer.Einlesen(dateiauswahl.FileName);

                List<Person> neueKontakte = new List<Person>();
                int uebersprungen = 0;

                foreach (Person kontakt in geleseneKontakte)
                {
                    if (verwaltung.ExistiertBereits(kontakt))
                    {
                        uebersprungen++;
                    }
                    else
                    {
                        neueKontakte.Add(kontakt);
                    }
                }

                // Alle auf einmal erfassen: so wird die Datei nur ein
                // einziges Mal geschrieben statt nach jeder Zeile.
                // Mitarbeiter und Lernende erhalten dabei automatisch
                // ihre Mitarbeiternummer.
                verwaltung.MehrereHinzufuegen(neueKontakte);

                CmdAlleAnzeigen_Click(sender, e);
                MeldungNachImport(neueKontakte.Count, uebersprungen, importer);
            }
            catch (Exception ex)
            {
                // Zum Beispiel wenn die Datei gesperrt ist oder nicht mehr existiert
                MessageBox.Show("Die Datei konnte nicht gelesen werden:\n" + ex.Message,
                    "Fehler beim Import", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Zeigt dem Benutzer nach dem Import an, was genau passiert ist
        /// </summary>
        /// <param name="importiert">Anzahl neu importierter Kontakte</param>
        /// <param name="uebersprungen">Anzahl bereits vorhandener Kontakte</param>
        /// <param name="importer">Der Importer mit den Fehlermeldungen</param>
        private void MeldungNachImport(int importiert, int uebersprungen, CsvImporter importer)
        {
            string meldung = "Neu importiert: " + importiert + " Kontakte\n" +
                             "Übersprungen (schon vorhanden): " + uebersprungen + "\n" +
                             "Fehlerhafte Zeilen: " + importer.AnzahlFehlerhaft;

            if (importer.AnzahlFehlerhaft > 0)
            {
                meldung = meldung + "\n\nDiese Zeilen wurden nicht importiert:\n" +
                          importer.Fehlermeldungen;
            }

            MessageBox.Show(meldung, "Import abgeschlossen",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Öffnet das Dashboard mit der Übersicht über den Datenstamm.
        /// Die Kontaktverwaltung wird übergeben, damit beide Fenster mit
        /// denselben Daten arbeiten.
        /// </summary>
        private void CmdDashboard_Click(object sender, EventArgs e)
        {
            DashboardForm dialog = new DashboardForm(verwaltung);
            dialog.ShowDialog();
        }
    }
}
