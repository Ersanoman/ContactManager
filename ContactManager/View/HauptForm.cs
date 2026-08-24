using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContactManager.Controller;
using ContactManager.Model;

namespace ContactManager.View
{
    // Hauptfenster der Applikation (View).
    // Zeigt alle Personen in einer Liste an und bietet die Suche sowie
    // die Aktionen Erfassen, Bearbeiten, Aktivieren/Deaktivieren und
    // Löschen an. Die eigentliche Logik macht die Kontaktverwaltung
    // (Controller), das Fenster zeigt nur an.
    public partial class HauptForm : Form
    {
        // Der Controller mit der ganzen Verwaltungslogik
        private Kontaktverwaltung verwaltung;

        // Konstruktor: erstellt den Controller (dieser lädt automatisch
        // den Datenstamm) und füllt das Kategorie-Auswahlfeld
        public HauptForm()
        {
            InitializeComponent();

            verwaltung = new Kontaktverwaltung();

            // Auswahlfeld für die Such-Kategorie füllen
            CmbKategorie.Items.Add("Alle");
            CmbKategorie.Items.Add("Kunde");
            CmbKategorie.Items.Add("Mitarbeiter");
            CmbKategorie.Items.Add("Lernender");
            CmbKategorie.SelectedIndex = 0;
        }

        // Wird nach dem Erscheinen des Fensters ausgeführt und zeigt
        // alle geladenen Personen an
        private void HauptForm_Load(object sender, EventArgs e)
        {
            ListeAnzeigen(verwaltung.AlleSortiert());
        }

        // Zeigt die übergebenen Personen in der ListBox an und
        // aktualisiert die Statuszeile. Die ListBox zeigt für jedes
        // Objekt automatisch dessen ToString-Text an.
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

        // Wendet die aktuell eingestellten Suchkriterien (neu) an.
        // Sind alle Felder leer, werden einfach alle Personen angezeigt.
        // So bleibt der Suchfilter auch nach einer Aktion (z.B. Bearbeiten)
        // erhalten.
        private void AnsichtAktualisieren()
        {
            List<Person> resultate = verwaltung.Suchen(
                TxtNachname.Text.Trim(),
                TxtVorname.Text.Trim(),
                ChkGeburtsdatum.Checked,
                DtpGeburtsdatum.Value.Date,
                Convert.ToString(CmbKategorie.SelectedItem));

            ListeAnzeigen(resultate);
        }

        // Gibt die aktuell ausgewählte Person zurück oder null,
        // wenn nichts ausgewählt ist
        private Person AusgewaehltePerson()
        {
            if (LstPersonen.SelectedItem == null)
            {
                return null;
            }

            return (Person)LstPersonen.SelectedItem;
        }

        // Markiert die übergebene Person in der Liste, damit die Auswahl
        // nach einer Aktion (z.B. Bearbeiten oder Statuswechsel) nicht
        // verloren geht. Ist die Person gerade nicht in der Liste
        // (z.B. vom Suchfilter ausgeblendet), passiert einfach nichts.
        private void PersonMarkieren(Person person)
        {
            LstPersonen.SelectedItem = person;
        }

        // Startet die Suche mit den eingegebenen Kriterien
        private void CmdSuchen_Click(object sender, EventArgs e)
        {
            AnsichtAktualisieren();
        }

        // Setzt alle Suchkriterien zurück und zeigt wieder alle Personen an
        private void CmdAlleAnzeigen_Click(object sender, EventArgs e)
        {
            TxtNachname.Text = "";
            TxtVorname.Text = "";
            ChkGeburtsdatum.Checked = false;
            CmbKategorie.SelectedIndex = 0;

            ListeAnzeigen(verwaltung.AlleSortiert());
        }

        // Schaltet das Geburtsdatum-Feld frei, wenn danach gesucht
        // werden soll
        private void ChkGeburtsdatum_CheckedChanged(object sender, EventArgs e)
        {
            DtpGeburtsdatum.Enabled = ChkGeburtsdatum.Checked;
        }

        // Öffnet den Dialog zum Erfassen eines neuen Kunden
        private void CmdNeuerKunde_Click(object sender, EventArgs e)
        {
            KundeForm dialog = new KundeForm(null);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                verwaltung.Hinzufuegen(dialog.Ergebnis);

                // Filter zurücksetzen, damit die neue Person sicher
                // sichtbar ist
                CmdAlleAnzeigen_Click(sender, e);

                // Die neu erfasste Person direkt markieren
                PersonMarkieren(dialog.Ergebnis);
            }
        }

        // Öffnet den Dialog zum Erfassen eines neuen Mitarbeiters oder
        // Lernenden. Die Mitarbeiternummer wird automatisch vergeben.
        private void CmdNeuerMitarbeiter_Click(object sender, EventArgs e)
        {
            MitarbeiterForm dialog = new MitarbeiterForm(null);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                verwaltung.Hinzufuegen(dialog.Ergebnis);

                // Filter zurücksetzen, damit die neue Person sicher
                // sichtbar ist
                CmdAlleAnzeigen_Click(sender, e);

                // Die neu erfasste Person direkt markieren
                PersonMarkieren(dialog.Ergebnis);
            }
        }

        // Öffnet die ausgewählte Person im passenden Dialog zum
        // Bearbeiten. Mit dem is-Operator wird geprüft, ob es ein Kunde
        // oder ein Mitarbeiter ist.
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

        // Doppelklick auf einen Eintrag öffnet ihn direkt zum Bearbeiten
        // (gleiche Methode wie der Button, damit kein doppelter Code entsteht)
        private void LstPersonen_DoubleClick(object sender, EventArgs e)
        {
            CmdBearbeiten_Click(sender, e);
        }

        // Schaltet den Status der ausgewählten Person zwischen aktiv
        // und passiv um
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

        // Löscht die ausgewählte Person nach einer Sicherheitsabfrage
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
    }
}
