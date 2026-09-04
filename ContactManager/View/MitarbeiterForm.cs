using System;
using System.Windows.Forms;
using ContactManager.Controller;
using ContactManager.Model;

namespace ContactManager.View
{
    /// <summary>
    /// Dialogfenster (View) zum Erfassen eines neuen Mitarbeiters oder
    /// Lernenden sowie zum Bearbeiten einer bestehenden Person.
    /// Über die Checkbox "Ist Lernender" wird gesteuert, ob ein Objekt
    /// der Klasse Mitarbeiter oder der abgeleiteten Klasse Lernender
    /// erzeugt wird.
    /// </summary>
    public partial class MitarbeiterForm : Form
    {
        /// <summary>
        /// Der Mitarbeiter, der bearbeitet wird (null = Neuerfassung)
        /// </summary>
        private Mitarbeiter original;

        /// <summary>
        /// Der fertige Mitarbeiter (oder Lernende). Ist erst gefüllt,
        /// nachdem der Dialog mit "Speichern" geschlossen wurde.
        /// </summary>
        public Mitarbeiter Ergebnis { get; private set; }

        /// <summary>
        /// Konstruktor. Bekommt den zu bearbeitenden Mitarbeiter übergeben
        /// oder null, wenn eine neue Person erfasst werden soll.
        /// </summary>
        /// <param name="vorhandenerMitarbeiter">Der zu bearbeitende Mitarbeiter oder null für eine Neuerfassung</param>
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

                TxtMitarbeiternummer.Text = Convert.ToString(original.Mitarbeiternummer);
                TxtAbteilung.Text = original.Abteilung;
                TxtAhvNummer.Text = original.AhvNummer;
                TxtAdresse.Text = original.Adresse;
                TxtPostleitzahl.Text = original.Postleitzahl;
                TxtWohnort.Text = original.Wohnort;
                CmbNationalitaet.Text = original.Nationalitaet;
                if (Pruefung.DatumImBereich(original.Eintrittsdatum,
                        DtpEintrittsdatum.MinDate, DtpEintrittsdatum.MaxDate))
                {
                    DtpEintrittsdatum.Value = original.Eintrittsdatum;
                }
                NumBeschaeftigungsgrad.Value = original.Beschaeftigungsgrad;
                TxtRolle.Text = original.Rolle;
                NumKaderstufe.Value = original.Kaderstufe;
                TxtGeschaeftsadresse.Text = original.Geschaeftsadresse;

                // DateTime.MinValue bedeutet: kein Austrittsdatum vorhanden
                if (original.Austrittsdatum != DateTime.MinValue)
                {
                    ChkAusgetreten.Checked = true;
                    if (Pruefung.DatumImBereich(original.Austrittsdatum,
                            DtpAustrittsdatum.MinDate, DtpAustrittsdatum.MaxDate))
                    {
                        DtpAustrittsdatum.Value = original.Austrittsdatum;
                    }
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

        /// <summary>
        /// Schaltet die Eingabefelder für die Lehrdaten frei, wenn die
        /// Person ein Lernender ist
        /// </summary>
        private void ChkLernender_CheckedChanged(object sender, EventArgs e)
        {
            NumLehrjahre.Enabled = ChkLernender.Checked;
            NumAktuellesLehrjahr.Enabled = ChkLernender.Checked;
        }

        /// <summary>
        /// Schaltet das Austrittsdatum-Feld frei, wenn die Person
        /// ausgetreten ist
        /// </summary>
        private void ChkAusgetreten_CheckedChanged(object sender, EventArgs e)
        {
            DtpAustrittsdatum.Enabled = ChkAusgetreten.Checked;
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
                && FormateGueltig()
                && DatenLogischStimmig();
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

            if (TxtAbteilung.Text.Trim() == "")
            {
                Meldung("Bitte eine Abteilung eingeben (Pflichtfeld).");
                return false;
            }

            if (TxtAhvNummer.Text.Trim() == "")
            {
                Meldung("Bitte eine AHV-Nummer eingeben (Pflichtfeld).");
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

            if (!Pruefung.OhneZiffern(TxtWohnort.Text))
            {
                Meldung("Der Wohnort darf keine Zahlen enthalten.");
                return false;
            }

            if (!Pruefung.OhneZiffern(CmbNationalitaet.Text))
            {
                Meldung("Die Nationalität darf keine Zahlen enthalten.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Prüft die Felder mit einem vorgegebenen Format:
        /// AHV-Nummer, E-Mail-Adresse, Telefonnummern und Postleitzahl.
        /// </summary>
        /// <returns>true, wenn alle Formate stimmen</returns>
        private bool FormateGueltig()
        {
            if (!Pruefung.AhvNummerGueltig(TxtAhvNummer.Text.Trim()))
            {
                Meldung("Die AHV-Nummer ist ungültig. " +
                    "Erwartet wird das Format 756.XXXX.XXXX.XX.");
                return false;
            }

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

            // Postleitzahl nur prüfen, wenn eine eingegeben wurde
            if (TxtPostleitzahl.Text.Trim() != "" &&
                !Pruefung.PostleitzahlGueltig(TxtPostleitzahl.Text.Trim()))
            {
                Meldung("Die Postleitzahl ist ungültig. " +
                    "Erwartet wird eine vierstellige Zahl (1000 bis 9999).");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Prüft die Angaben, die zueinander passen müssen:
        /// Austritt nach Eintritt und Lehrjahr innerhalb der Lehrdauer.
        /// </summary>
        /// <returns>true, wenn die Angaben zueinander passen</returns>
        private bool DatenLogischStimmig()
        {
            if (ChkAusgetreten.Checked && DtpAustrittsdatum.Value.Date < DtpEintrittsdatum.Value.Date)
            {
                Meldung("Das Austrittsdatum darf nicht vor dem Eintrittsdatum liegen.");
                return false;
            }

            if (ChkLernender.Checked && NumAktuellesLehrjahr.Value > NumLehrjahre.Value)
            {
                Meldung("Das aktuelle Lehrjahr kann nicht grösser sein " +
                    "als die gesamte Anzahl Lehrjahre.");
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
        /// Prüft die Eingaben, baut daraus das Mitarbeiter- oder
        /// Lernender-Objekt und schliesst den Dialog mit OK.
        /// </summary>
        private void CmdSpeichern_Click(object sender, EventArgs e)
        {
            if (!EingabenGueltig())
            {
                return;
            }

            Mitarbeiter mitarbeiter = PassendesObjektErzeugen();
            PersonendatenUebernehmen(mitarbeiter);
            AnstellungsdatenUebernehmen(mitarbeiter);

            // Beim Bearbeiten bleibt die bestehende Mitarbeiternummer erhalten.
            // Bei einer Neuerfassung bleibt sie 0 und wird von der
            // Kontaktverwaltung automatisch vergeben.
            if (original != null)
            {
                mitarbeiter.Mitarbeiternummer = original.Mitarbeiternummer;
            }

            Ergebnis = mitarbeiter;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Erzeugt je nach Häkchen einen Lernenden oder einen "normalen"
        /// Mitarbeiter. Weil ein Lernender von Mitarbeiter erbt, kann in
        /// beiden Fällen mit dem Typ Mitarbeiter weitergearbeitet werden.
        /// </summary>
        /// <returns>Das leere Objekt der passenden Klasse</returns>
        private Mitarbeiter PassendesObjektErzeugen()
        {
            if (ChkLernender.Checked)
            {
                Lernender lernender = new Lernender();
                lernender.Lehrjahre = (int)NumLehrjahre.Value;
                lernender.AktuellesLehrjahr = (int)NumAktuellesLehrjahr.Value;
                return lernender;
            }

            return new Mitarbeiter();
        }

        /// <summary>
        /// Überträgt die Angaben, die jede Person hat (aus der Basisklasse
        /// Person), aus dem Formular in das Objekt.
        /// </summary>
        /// <param name="person">Das zu füllende Objekt</param>
        private void PersonendatenUebernehmen(Person person)
        {
            person.Anrede = (Anrede)CmbAnrede.SelectedIndex;
            person.Titel = TxtTitel.Text.Trim();
            person.Vorname = TxtVorname.Text.Trim();
            person.Nachname = TxtNachname.Text.Trim();
            person.Geburtsdatum = DtpGeburtsdatum.Value.Date;
            person.Geschlecht = (Geschlecht)CmbGeschlecht.SelectedIndex;
            person.TelefonnummerGeschaeft = TxtTelefonGeschaeft.Text.Trim();
            person.Mobiltelefonnummer = TxtMobiltelefon.Text.Trim();
            person.EMailAdresse = TxtEMail.Text.Trim();
            person.Aktiv = ChkAktiv.Checked;
        }

        /// <summary>
        /// Überträgt die Angaben zur Anstellung aus dem Formular
        /// in das Objekt.
        /// </summary>
        /// <param name="mitarbeiter">Der zu füllende Mitarbeiter</param>
        private void AnstellungsdatenUebernehmen(Mitarbeiter mitarbeiter)
        {
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

            // DateTime.MinValue bedeutet: kein Austrittsdatum (ternärer Operator)
            mitarbeiter.Austrittsdatum = ChkAusgetreten.Checked
                ? DtpAustrittsdatum.Value.Date
                : DateTime.MinValue;
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
