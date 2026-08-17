using System;
using System.Windows.Forms;
using ContactManager.Model;

namespace ContactManager.View
{
    // Dialogfenster (View) zum Erfassen eines neuen Mitarbeiters oder
    // Lernenden sowie zum Bearbeiten einer bestehenden Person.
    // Über die Checkbox "Ist Lernender" wird gesteuert, ob ein Objekt
    // der Klasse Mitarbeiter oder der abgeleiteten Klasse Lernender
    // erzeugt wird.
    public partial class MitarbeiterForm : Form
    {
        // Der Mitarbeiter, der bearbeitet wird (null = Neuerfassung)
        private Mitarbeiter original;

        // Der fertige Mitarbeiter (oder Lernende). Ist erst gefüllt,
        // nachdem der Dialog mit "Speichern" geschlossen wurde.
        public Mitarbeiter Ergebnis { get; private set; }

        // Konstruktor. Bekommt den zu bearbeitenden Mitarbeiter übergeben
        // oder null, wenn eine neue Person erfasst werden soll.
        public MitarbeiterForm(Mitarbeiter vorhandenerMitarbeiter)
        {
            InitializeComponent();

            original = vorhandenerMitarbeiter;

            // Auswahlfelder füllen. Die Reihenfolge muss zu den
            // Zahlenwerten der Enumerationen Anrede und Geschlecht passen.
            CmbAnrede.Items.Add("Herr");
            CmbAnrede.Items.Add("Frau");
            CmbGeschlecht.Items.Add("Männlich");
            CmbGeschlecht.Items.Add("Weiblich");
            CmbGeschlecht.Items.Add("Divers");

            // Länderliste für die Nationalität füllen
            foreach (string land in Laenderliste.Alle())
            {
                CmbNationalitaet.Items.Add(land);
            }

            // Ein Geburtsdatum kann nicht in der Zukunft liegen
            DtpGeburtsdatum.MaxDate = DateTime.Today;

            if (original == null)
            {
                // Neuerfassung: Standardwerte setzen
                Text = "Neuen Mitarbeiter erfassen";
                CmbAnrede.SelectedIndex = 0;
                CmbGeschlecht.SelectedIndex = 0;
                DtpGeburtsdatum.Value = new DateTime(1990, 1, 1);
                ChkAktiv.Checked = true;
                CmbNationalitaet.Text = "Schweiz";
                TxtMitarbeiternummer.Text = "(wird automatisch vergeben)";
            }
            else
            {
                // Bearbeitung: alle Felder mit den bestehenden Werten füllen
                Text = "Mitarbeiter bearbeiten";
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

                TxtMitarbeiternummer.Text = Convert.ToString(original.Mitarbeiternummer);
                TxtAbteilung.Text = original.Abteilung;
                TxtAhvNummer.Text = original.AhvNummer;
                TxtAdresse.Text = original.Adresse;
                TxtPostleitzahl.Text = original.Postleitzahl;
                TxtWohnort.Text = original.Wohnort;
                CmbNationalitaet.Text = original.Nationalitaet;
                DtpEintrittsdatum.Value = original.Eintrittsdatum;
                NumBeschaeftigungsgrad.Value = original.Beschaeftigungsgrad;
                TxtRolle.Text = original.Rolle;
                NumKaderstufe.Value = original.Kaderstufe;
                TxtGeschaeftsadresse.Text = original.Geschaeftsadresse;

                // DateTime.MinValue bedeutet: kein Austrittsdatum vorhanden
                if (original.Austrittsdatum != DateTime.MinValue)
                {
                    ChkAusgetreten.Checked = true;
                    DtpAustrittsdatum.Value = original.Austrittsdatum;
                }

                // Mit dem is-Operator prüfen, ob es ein Lernender ist,
                // und die Lehrdaten übernehmen
                if (original is Lernender)
                {
                    Lernender lernender = (Lernender)original;
                    ChkLernender.Checked = true;
                    NumLehrjahre.Value = lernender.Lehrjahre;
                    NumAktuellesLehrjahr.Value = lernender.AktuellesLehrjahr;
                }
            }
        }

        // Schaltet die Eingabefelder für die Lehrdaten frei, wenn die
        // Person ein Lernender ist
        private void ChkLernender_CheckedChanged(object sender, EventArgs e)
        {
            NumLehrjahre.Enabled = ChkLernender.Checked;
            NumAktuellesLehrjahr.Enabled = ChkLernender.Checked;
        }

        // Schaltet das Austrittsdatum-Feld frei, wenn die Person
        // ausgetreten ist
        private void ChkAusgetreten_CheckedChanged(object sender, EventArgs e)
        {
            DtpAustrittsdatum.Enabled = ChkAusgetreten.Checked;
        }

        // Gemeinsamer KeyPress-Handler für beide Telefonfelder:
        // lässt nur Ziffern, Leerzeichen und die Löschtaste durch.
        // So können gar keine Buchstaben eingetippt werden.
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

        // Prüft, ob eine Telefonnummer nur aus Ziffern (und Leerzeichen)
        // besteht. Wichtig gegen eingefügten Text (Ctrl+V), denn der
        // kommt am KeyPress-Handler vorbei.
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

        // Prüft, ob die AHV-Nummer gültig ist. Erwartet wird das
        // Schweizer Format 756.XXXX.XXXX.XX (13 Ziffern, beginnt mit 756).
        private bool AhvNummerGueltig(string ahvNummer)
        {
            // Die Trennpunkte entfernen, damit nur die Ziffern übrig bleiben
            string ziffern = ahvNummer.Replace(".", "");

            // Eine AHV-Nummer besteht aus genau 13 Ziffern
            if (ziffern.Length != 13)
            {
                return false;
            }

            // Schweizer AHV-Nummern beginnen immer mit dem Ländercode 756
            if (ziffern.Substring(0, 3) != "756")
            {
                return false;
            }

            // Prüfen, ob wirklich nur Ziffern drin sind. Wenn die
            // Umwandlung in eine Zahl scheitert, ist die Eingabe ungültig.
            try
            {
                Convert.ToInt64(ziffern);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        // Prüft, ob die Postleitzahl gültig ist. Schweizer Postleitzahlen
        // sind vierstellige Zahlen (1000 bis 9999).
        private bool PostleitzahlGueltig(string postleitzahl)
        {
            try
            {
                int wert = Convert.ToInt32(postleitzahl);
                return wert >= 1000 && wert <= 9999;
            }
            catch (Exception)
            {
                // Die Eingabe ist keine gültige Zahl
                return false;
            }
        }

        // Prüft alle Eingaben. Bei einem Fehler wird eine verständliche
        // Meldung angezeigt und false zurückgegeben.
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

            if (TxtAbteilung.Text.Trim() == "")
            {
                MessageBox.Show("Bitte eine Abteilung eingeben (Pflichtfeld).",
                    "Eingabe unvollständig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (TxtAhvNummer.Text.Trim() == "")
            {
                MessageBox.Show("Bitte eine AHV-Nummer eingeben (Pflichtfeld).",
                    "Eingabe unvollständig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // AHV-Nummer auf das richtige Format prüfen
            if (!AhvNummerGueltig(TxtAhvNummer.Text.Trim()))
            {
                MessageBox.Show("Die AHV-Nummer ist ungültig. " +
                    "Erwartet wird das Format 756.XXXX.XXXX.XX.",
                    "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Postleitzahl prüfen (nur wenn eine da ist)
            if (TxtPostleitzahl.Text.Trim() != "" &&
                !PostleitzahlGueltig(TxtPostleitzahl.Text.Trim()))
            {
                MessageBox.Show("Die Postleitzahl ist ungültig. " +
                    "Erwartet wird eine vierstellige Zahl (1000 bis 9999).",
                    "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Das Austrittsdatum darf nicht vor dem Eintrittsdatum liegen
            if (ChkAusgetreten.Checked && DtpAustrittsdatum.Value.Date < DtpEintrittsdatum.Value.Date)
            {
                MessageBox.Show("Das Austrittsdatum darf nicht vor dem Eintrittsdatum liegen.",
                    "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Das aktuelle Lehrjahr kann nicht grösser als die Lehrdauer sein
            if (ChkLernender.Checked && NumAktuellesLehrjahr.Value > NumLehrjahre.Value)
            {
                MessageBox.Show("Das aktuelle Lehrjahr kann nicht grösser sein " +
                    "als die gesamte Anzahl Lehrjahre.",
                    "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Prüft die Eingaben, baut daraus das Mitarbeiter- oder
        // Lernender-Objekt und schliesst den Dialog mit OK
        private void CmdSpeichern_Click(object sender, EventArgs e)
        {
            if (!EingabenGueltig())
            {
                return;
            }

            Mitarbeiter mitarbeiter;

            // Je nach Checkbox wird ein Lernender oder ein "normaler"
            // Mitarbeiter erzeugt (Vererbungshierarchie)
            if (ChkLernender.Checked)
            {
                Lernender lernender = new Lernender();
                lernender.Lehrjahre = (int)NumLehrjahre.Value;
                lernender.AktuellesLehrjahr = (int)NumAktuellesLehrjahr.Value;
                mitarbeiter = lernender;
            }
            else
            {
                mitarbeiter = new Mitarbeiter();
            }

            // Allgemeine Personendaten (aus der Basisklasse Person)
            mitarbeiter.Anrede = (Anrede)CmbAnrede.SelectedIndex;
            mitarbeiter.Titel = TxtTitel.Text.Trim();
            mitarbeiter.Vorname = TxtVorname.Text.Trim();
            mitarbeiter.Nachname = TxtNachname.Text.Trim();
            mitarbeiter.Geburtsdatum = DtpGeburtsdatum.Value.Date;
            mitarbeiter.Geschlecht = (Geschlecht)CmbGeschlecht.SelectedIndex;
            mitarbeiter.TelefonnummerGeschaeft = TxtTelefonGeschaeft.Text.Trim();
            mitarbeiter.Mobiltelefonnummer = TxtMobiltelefon.Text.Trim();
            mitarbeiter.EMailAdresse = TxtEMail.Text.Trim();
            mitarbeiter.Aktiv = ChkAktiv.Checked;

            // Anstellungsdaten des Mitarbeiters
            mitarbeiter.Abteilung = TxtAbteilung.Text.Trim();
            mitarbeiter.AhvNummer = TxtAhvNummer.Text.Trim();
            mitarbeiter.Adresse = TxtAdresse.Text.Trim();
            mitarbeiter.Postleitzahl = TxtPostleitzahl.Text.Trim();
            mitarbeiter.Wohnort = TxtWohnort.Text.Trim();
            mitarbeiter.Nationalitaet = CmbNationalitaet.Text.Trim();
            mitarbeiter.Eintrittsdatum = DtpEintrittsdatum.Value.Date;
            mitarbeiter.Beschaeftigungsgrad = (int)NumBeschaeftigungsgrad.Value;
            mitarbeiter.Rolle = TxtRolle.Text.Trim();
            mitarbeiter.Kaderstufe = (int)NumKaderstufe.Value;
            mitarbeiter.Geschaeftsadresse = TxtGeschaeftsadresse.Text.Trim();

            // DateTime.MinValue bedeutet: kein Austrittsdatum
            // (ternärer Operator)
            mitarbeiter.Austrittsdatum = ChkAusgetreten.Checked
                ? DtpAustrittsdatum.Value.Date
                : DateTime.MinValue;

            // Beim Bearbeiten bleibt die bestehende Mitarbeiternummer
            // erhalten. Bei einer Neuerfassung bleibt sie 0 und wird von
            // der Kontaktverwaltung automatisch vergeben.
            if (original != null)
            {
                mitarbeiter.Mitarbeiternummer = original.Mitarbeiternummer;
            }

            Ergebnis = mitarbeiter;
            DialogResult = DialogResult.OK;
            Close();
        }

        // Schliesst den Dialog ohne zu speichern
        private void CmdAbbrechen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
