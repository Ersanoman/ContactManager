using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
                DtpGeburtsdatum.Value = original.Geburtsdatum;
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
        /// Prüft, ob eine Telefonnummer nur aus Ziffern (und Leerzeichen)
        /// besteht. Wichtig gegen eingefügten Text (Ctrl+V), denn der
        /// kommt am KeyPress-Handler vorbei.
        /// </summary>
        /// <param name="nummer">Die zu prüfende Telefonnummer</param>
        /// <returns>true, wenn die Nummer nur Ziffern enthält</returns>
        private bool TelefonnummerGueltig(string nummer)
        {
            // Leerzeichen entfernen, danach dürfen nur Ziffern übrig sein
            string ziffern = nummer.Replace(" ", "");

            foreach (char zeichen in ziffern)
            {
                if (zeichen < '0' || zeichen > '9')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Prüft alle Eingaben. Bei einem Fehler wird eine verständliche
        /// Meldung angezeigt und false zurückgegeben.
        /// </summary>
        /// <returns>true, wenn alle Eingaben gültig sind</returns>
        private bool EingabenGueltig()
        {
            // Pflichtfelder prüfen (im Formular mit * markiert)
            if (TxtVorname.Text.Trim() == "")
            {
                MessageBox.Show("Bitte einen Vornamen eingeben (Pflichtfeld).",
                    "Eingabe unvollständig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (TxtNachname.Text.Trim() == "")
            {
                MessageBox.Show("Bitte einen Nachnamen eingeben (Pflichtfeld).",
                    "Eingabe unvollständig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Einfache Prüfung der E-Mail-Adresse (nur wenn eine da ist)
            string email = TxtEMail.Text.Trim();
            if (email != "" && (!email.Contains("@") || !email.Contains(".")))
            {
                MessageBox.Show("Die E-Mail-Adresse ist ungültig. " +
                    "Sie muss ein @-Zeichen und einen Punkt enthalten.",
                    "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Telefonnummern dürfen nur Zahlen enthalten
            if (TxtTelefonGeschaeft.Text.Trim() != "" &&
                !TelefonnummerGueltig(TxtTelefonGeschaeft.Text.Trim()))
            {
                MessageBox.Show("Die Telefonnummer Geschäft darf nur Zahlen enthalten.",
                    "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (TxtMobiltelefon.Text.Trim() != "" &&
                !TelefonnummerGueltig(TxtMobiltelefon.Text.Trim()))
            {
                MessageBox.Show("Die Mobiltelefonnummer darf nur Zahlen enthalten.",
                    "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
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
