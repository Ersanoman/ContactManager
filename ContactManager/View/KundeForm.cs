using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContactManager.Controller;
using ContactManager.Model;

namespace ContactManager.View
{
    /// <summary>
    /// Dialogfenster (View) zum Erfassen eines neuen Kunden oder zum
    /// Bearbeiten eines bestehenden Kunden. Enthält auch die
    /// Kontakthistorie, in der Notizen zu Kundenkontakten protokolliert
    /// und angeschaut werden können.
    /// </summary>
    public partial class KundeForm : Form
    {
        /// <summary>
        /// Der Kunde, der bearbeitet wird (null = Neuerfassung)
        /// </summary>
        private Kunde original;

        /// <summary>
        /// Arbeitskopie der Kontakthistorie. Erst beim Speichern wird sie
        /// übernommen, damit Abbrechen keine Spuren hinterlässt.
        /// </summary>
        private List<Kontakteintrag> kontakthistorie;

        /// <summary>
        /// Der fertige Kunde. Ist erst gefüllt, nachdem der Dialog mit
        /// "Speichern" geschlossen wurde.
        /// </summary>
        public Kunde Ergebnis { get; private set; }

        /// <summary>
        /// Konstruktor. Bekommt den zu bearbeitenden Kunden übergeben
        /// oder null, wenn ein neuer Kunde erfasst werden soll.
        /// </summary>
        /// <param name="vorhandenerKunde">Der zu bearbeitende Kunde oder null für eine Neuerfassung</param>
        public KundeForm(Kunde vorhandenerKunde)
        {
            InitializeComponent();

            original = vorhandenerKunde;
            kontakthistorie = new List<Kontakteintrag>();

            // Auswahlfelder füllen. Die Reihenfolge muss zu den
            // Zahlenwerten der Enumerationen Anrede und Geschlecht passen.
            CmbAnrede.Items.Add("Herr");
            CmbAnrede.Items.Add("Frau");
            CmbGeschlecht.Items.Add("Männlich");
            CmbGeschlecht.Items.Add("Weiblich");
            CmbGeschlecht.Items.Add("Divers");

            // Ein Geburtsdatum kann nicht in der Zukunft liegen
            DtpGeburtsdatum.MaxDate = DateTime.Today;

            if (original == null)
            {
                // Neuerfassung: Standardwerte setzen
                Text = "Neuen Kunden erfassen";
                CmbAnrede.SelectedIndex = 0;
                CmbGeschlecht.SelectedIndex = 0;
                DtpGeburtsdatum.Value = new DateTime(1990, 1, 1);
                ChkAktiv.Checked = true;
            }
            else
            {
                // Bearbeitung: alle Felder mit den bestehenden Werten füllen
                Text = "Kunden bearbeiten";
                CmbAnrede.SelectedIndex = (int)original.Anrede;
                TxtTitel.Text = original.Titel;
                TxtVorname.Text = original.Vorname;
                TxtNachname.Text = original.Nachname;
                // Ein Datum ausserhalb des erlaubten Bereichs (z.B. aus einer
                // importierten Datei) würde im Auswahlfeld einen Laufzeitfehler
                // auslösen. Darum wird es vorher geprüft.
                if (Pruefung.DatumImBereich(original.Geburtsdatum,
                        DtpGeburtsdatum.MinDate, DtpGeburtsdatum.MaxDate))
                {
                    DtpGeburtsdatum.Value = original.Geburtsdatum;
                }
                CmbGeschlecht.SelectedIndex = (int)original.Geschlecht;
                TxtTelefonGeschaeft.Text = original.TelefonnummerGeschaeft;
                TxtMobiltelefon.Text = original.Mobiltelefonnummer;
                TxtEMail.Text = original.EMailAdresse;
                ChkAktiv.Checked = original.Aktiv;

                // Arbeitskopie der Kontakthistorie erstellen
                foreach (Kontakteintrag eintrag in original.Kontakthistorie)
                {
                    kontakthistorie.Add(eintrag);
                }
            }

            HistorieAnzeigen();
        }

        /// <summary>
        /// Zeigt die Arbeitskopie der Kontakthistorie in der ListBox an
        /// </summary>
        private void HistorieAnzeigen()
        {
            LstKontakthistorie.Items.Clear();

            foreach (Kontakteintrag eintrag in kontakthistorie)
            {
                LstKontakthistorie.Items.Add(eintrag);
            }
        }

        /// <summary>
        /// Fügt der Kontakthistorie eine neue Notiz mit dem aktuellen
        /// Zeitpunkt hinzu und leert das Eingabefeld
        /// </summary>
        private void CmdNotizHinzufuegen_Click(object sender, EventArgs e)
        {
            string notiz = TxtNeueNotiz.Text.Trim();

            if (notiz == "")
            {
                MessageBox.Show("Bitte zuerst einen Notiztext eingeben.",
                    "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            kontakthistorie.Add(new Kontakteintrag(DateTime.Now, notiz));
            HistorieAnzeigen();
            TxtNeueNotiz.Text = "";
        }

        /// <summary>
        /// Gemeinsamer KeyPress-Handler für beide Telefonfelder:
        /// lässt nur Ziffern, Leerzeichen und die Löschtaste durch.
        /// So können gar keine Buchstaben eingetippt werden.
        /// </summary>
        private void TxtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool istZiffer = e.KeyChar >= '0' && e.KeyChar <= '9';
            bool istLeerzeichen = e.KeyChar == ' ';
            bool istLoeschtaste = e.KeyChar == (char)8; // Backspace

            if (!istZiffer && !istLeerzeichen && !istLoeschtaste)
            {
                // Eingabe verwerfen
                e.Handled = true;
            }
        }

        /// <summary>
        /// Prüft alle Eingaben. Die einzelnen Prüfungen stehen in eigenen
        /// Methoden, damit jede nur eine Aufgabe hat. Sobald eine davon
        /// false liefert, wird abgebrochen und der Benutzer sieht die
        /// erste unpassende Eingabe.
        /// </summary>
        /// <returns>true, wenn alle Eingaben gültig sind</returns>
        private bool EingabenGueltig()
        {
            return PflichtfelderAusgefuellt()
                && NamenOhneZahlen()
                && FormateGueltig();
        }

        /// <summary>
        /// Prüft, ob alle Pflichtfelder ausgefüllt sind
        /// (im Formular mit einem Stern markiert).
        /// </summary>
        /// <returns>true, wenn kein Pflichtfeld leer ist</returns>
        private bool PflichtfelderAusgefuellt()
        {
            if (TxtVorname.Text.Trim() == "")
            {
                Meldung("Bitte einen Vornamen eingeben (Pflichtfeld).");
                return false;
            }

            if (TxtNachname.Text.Trim() == "")
            {
                Meldung("Bitte einen Nachnamen eingeben (Pflichtfeld).");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Prüft die Felder, in die keine Zahlen gehören.
        /// </summary>
        /// <returns>true, wenn keines dieser Felder eine Zahl enthält</returns>
        private bool NamenOhneZahlen()
        {
            if (!Pruefung.OhneZiffern(TxtVorname.Text))
            {
                Meldung("Der Vorname darf keine Zahlen enthalten.");
                return false;
            }

            if (!Pruefung.OhneZiffern(TxtNachname.Text))
            {
                Meldung("Der Nachname darf keine Zahlen enthalten.");
                return false;
            }

            if (!Pruefung.OhneZiffern(TxtTitel.Text))
            {
                Meldung("Der Titel darf keine Zahlen enthalten.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Prüft die Felder mit einem vorgegebenen Format:
        /// E-Mail-Adresse und Telefonnummern.
        /// </summary>
        /// <returns>true, wenn alle Formate stimmen</returns>
        private bool FormateGueltig()
        {
            // E-Mail-Adresse nur prüfen, wenn eine eingegeben wurde
            if (TxtEMail.Text.Trim() != "" && !Pruefung.EMailGueltig(TxtEMail.Text.Trim()))
            {
                Meldung("Die E-Mail-Adresse ist ungültig. Beispiel: name@firma.ch");
                return false;
            }

            if (!Pruefung.TelefonnummerGueltig(TxtTelefonGeschaeft.Text))
            {
                Meldung("Die Telefonnummer Geschäft darf nur Zahlen enthalten.");
                return false;
            }

            if (!Pruefung.TelefonnummerGueltig(TxtMobiltelefon.Text))
            {
                Meldung("Die Mobiltelefonnummer darf nur Zahlen enthalten.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Zeigt dem Benutzer einen Hinweis zu einer fehlerhaften Eingabe an.
        /// Spart das mehrfache Schreiben derselben MessageBox-Zeile.
        /// </summary>
        /// <param name="text">Der anzuzeigende Hinweistext</param>
        private void Meldung(string text)
        {
            MessageBox.Show(text, "Eingabe prüfen",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Prüft die Eingaben, baut daraus das Kundenobjekt und schliesst
        /// den Dialog mit OK
        /// </summary>
        private void CmdSpeichern_Click(object sender, EventArgs e)
        {
            if (!EingabenGueltig())
            {
                return;
            }

            // Neues Kundenobjekt mit den eingegebenen Werten erstellen
            Kunde kunde = new Kunde();
            kunde.Anrede = (Anrede)CmbAnrede.SelectedIndex;
            kunde.Titel = TxtTitel.Text.Trim();
            kunde.Vorname = TxtVorname.Text.Trim();
            kunde.Nachname = TxtNachname.Text.Trim();
            kunde.Geburtsdatum = DtpGeburtsdatum.Value.Date;
            kunde.Geschlecht = (Geschlecht)CmbGeschlecht.SelectedIndex;
            kunde.TelefonnummerGeschaeft = TxtTelefonGeschaeft.Text.Trim();
            kunde.Mobiltelefonnummer = TxtMobiltelefon.Text.Trim();
            kunde.EMailAdresse = TxtEMail.Text.Trim();
            kunde.Aktiv = ChkAktiv.Checked;
            kunde.Kontakthistorie = kontakthistorie;

            Ergebnis = kunde;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Schliesst den Dialog ohne zu speichern
        /// </summary>
        private void CmdAbbrechen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
