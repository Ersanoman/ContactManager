using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ContactManager.Model;

namespace ContactManager.Controller
{
    /// <summary>
    /// Liest Kontakte aus einer CSV-Datei ein (z.B. aus Excel exportiert).
    /// Die erste Spalte bestimmt, welche Art von Person erzeugt wird:
    /// "Kunde", "Mitarbeiter" oder "Lernender". So kann mit einer einzigen
    /// Datei die ganze Vererbungshierarchie importiert werden.
    ///
    /// Aufbau einer Zeile, getrennt mit Strichpunkt:
    /// Typ;Anrede;Titel;Vorname;Nachname;Geburtsdatum;Geschlecht;
    /// TelefonGeschaeft;Mobiltelefon;EMail;Status;
    /// Abteilung;AhvNummer;Adresse;Postleitzahl;Wohnort;Nationalitaet;
    /// Eintrittsdatum;Austrittsdatum;Beschaeftigungsgrad;Rolle;Kaderstufe;
    /// Geschaeftsadresse;Lehrjahre;AktuellesLehrjahr
    ///
    /// Bei Kunden bleiben die Spalten ab "Abteilung" leer.
    /// Die erste Zeile darf eine Überschriftszeile sein, sie wird übersprungen.
    /// </summary>
    public class CsvImporter
    {
        /// <summary>
        /// So viele Spalten braucht es mindestens (die Angaben, welche
        /// jede Person hat). Die Mitarbeiterspalten dürfen fehlen.
        /// </summary>
        private const int MinimaleSpalten = 11;

        /// <summary>
        /// Anzahl der Zeilen, die nicht eingelesen werden konnten
        /// </summary>
        public int AnzahlFehlerhaft { get; private set; }

        /// <summary>
        /// Beschreibung der fehlerhaften Zeilen für die Meldung an den Benutzer
        /// </summary>
        public string Fehlermeldungen { get; private set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public CsvImporter()
        {
            Fehlermeldungen = "";
        }

        /// <summary>
        /// Liest die CSV-Datei ein und gibt alle gültigen Kontakte zurück.
        /// Fehlerhafte Zeilen werden übersprungen und gezählt, damit der
        /// Import wegen einer einzelnen kaputten Zeile nicht abbricht.
        /// </summary>
        /// <param name="dateipfad">Vollständiger Pfad zur CSV-Datei</param>
        /// <returns>Alle gültigen Kontakte aus der Datei</returns>
        public List<Person> Einlesen(string dateipfad)
        {
            List<Person> kontakte = new List<Person>();
            AnzahlFehlerhaft = 0;
            Fehlermeldungen = "";

            // Encoding.Default entspricht der Windows-Einstellung, damit
            // Umlaute aus einer Excel-Datei richtig ankommen. Ist die Datei
            // als UTF-8 gespeichert, erkennt .NET das automatisch.
            string[] zeilen = File.ReadAllLines(dateipfad, Encoding.Default);

            for (int i = 0; i < zeilen.Length; i++)
            {
                string zeile = zeilen[i].Trim();

                // Leerzeilen einfach überspringen
                if (zeile == "")
                {
                    continue;
                }

                // Überschriftszeile überspringen (nur die allererste Zeile)
                if (i == 0 && zeile.ToLower().StartsWith("typ"))
                {
                    continue;
                }

                try
                {
                    kontakte.Add(ZeileUmwandeln(zeile));
                }
                catch (Exception ex)
                {
                    // Die Zeilennummer wird für den Benutzer ab 1 gezählt
                    AnzahlFehlerhaft++;
                    Fehlermeldungen = Fehlermeldungen + "Zeile " + (i + 1) + ": " + ex.Message + "\n";
                }
            }

            return kontakte;
        }

        /// <summary>
        /// Wandelt eine einzelne CSV-Zeile in einen Kunden, einen Mitarbeiter
        /// oder einen Lernenden um. Stimmt etwas nicht, wird eine Exception
        /// ausgelöst, die von der Methode Einlesen aufgefangen wird.
        /// </summary>
        /// <param name="zeile">Eine Zeile aus der CSV-Datei</param>
        /// <returns>Der erzeugte Kunde, Mitarbeiter oder Lernende</returns>
        private Person ZeileUmwandeln(string zeile)
        {
            string[] teile = zeile.Split(';');

            if (teile.Length < MinimaleSpalten)
            {
                throw new Exception("Die Zeile hat nur " + teile.Length +
                                    " statt mindestens " + MinimaleSpalten + " Spalten.");
            }

            // Die Spalten mit sprechenden Namen versehen, damit weiter unten
            // nicht mit blossen Spaltennummern gearbeitet werden muss
            string typ = Feld(teile, 0);
            string vorname = Feld(teile, 3);
            string nachname = Feld(teile, 4);
            string geburtstext = Feld(teile, 5);

            // Vorname und Nachname sind Pflichtfelder
            if (vorname == "" || nachname == "")
            {
                throw new Exception("Vorname oder Nachname fehlt.");
            }

            // In Namen gehören keine Zahlen
            if (!Pruefung.OhneZiffern(vorname) || !Pruefung.OhneZiffern(nachname))
            {
                throw new Exception("Vorname oder Nachname enthält Zahlen.");
            }

            // Das Geburtsdatum muss in der Vergangenheit und nach 1900 liegen.
            // Sonst könnte das Datums-Auswahlfeld im Formular den Wert später
            // gar nicht anzeigen.
            DateTime geburtsdatum = DatumUmwandeln(geburtstext);
            if (!Pruefung.GeburtsdatumPlausibel(geburtsdatum))
            {
                throw new Exception("Das Geburtsdatum '" + geburtstext +
                                    "' liegt in der Zukunft oder vor 1900.");
            }

            // Die erste Spalte entscheidet, welches Objekt erzeugt wird
            Person person = PersonErzeugen(typ);

            // Die Angaben, welche jede Person hat (aus der Basisklasse)
            person.Anrede = AnredeUmwandeln(Feld(teile, 1));
            person.Titel = Feld(teile, 2);
            person.Vorname = vorname;
            person.Nachname = nachname;
            person.Geburtsdatum = geburtsdatum;
            person.Geschlecht = GeschlechtUmwandeln(Feld(teile, 6));
            person.TelefonnummerGeschaeft = Feld(teile, 7);
            person.Mobiltelefonnummer = Feld(teile, 8);
            person.EMailAdresse = Feld(teile, 9);

            // Alles ausser dem Wort "passiv" gilt als aktiv
            person.Aktiv = Feld(teile, 10).ToLower() != "passiv";

            // Die zusätzlichen Angaben nur bei Mitarbeitern und Lernenden
            if (person is Mitarbeiter)
            {
                MitarbeiterFeldenFuellen((Mitarbeiter)person, teile);
            }

            // Und die Lehrangaben nur bei Lernenden
            if (person is Lernender)
            {
                Lernender lernender = (Lernender)person;
                lernender.Lehrjahre = ZahlImBereich(Feld(teile, 23), 3, 1, 4, "Lehrjahre");
                lernender.AktuellesLehrjahr = ZahlImBereich(Feld(teile, 24), 1, 1, 4, "aktuelles Lehrjahr");

                if (lernender.AktuellesLehrjahr > lernender.Lehrjahre)
                {
                    throw new Exception("Das aktuelle Lehrjahr ist grösser als die Anzahl Lehrjahre.");
                }
            }

            return person;
        }

        /// <summary>
        /// Erzeugt anhand der Typ-Spalte das passende Objekt der
        /// Vererbungshierarchie
        /// </summary>
        /// <param name="typ">Inhalt der Spalte "Typ"</param>
        /// <returns>Ein leeres Objekt der passenden Klasse</returns>
        private Person PersonErzeugen(string typ)
        {
            string kleingeschrieben = typ.ToLower();

            if (kleingeschrieben == "kunde")
            {
                return new Kunde();
            }
            else if (kleingeschrieben == "mitarbeiter")
            {
                return new Mitarbeiter();
            }
            else if (kleingeschrieben == "lernender")
            {
                return new Lernender();
            }

            throw new Exception("Unbekannter Typ '" + typ +
                                "'. Erlaubt sind Kunde, Mitarbeiter oder Lernender.");
        }

        /// <summary>
        /// Füllt die Angaben ab, welche nur Mitarbeiter (und damit auch
        /// Lernende) besitzen. Die Mitarbeiternummer wird nicht eingelesen,
        /// diese vergibt die Kontaktverwaltung automatisch.
        /// </summary>
        /// <param name="mitarbeiter">Der zu füllende Mitarbeiter</param>
        /// <param name="teile">Die Spalten der CSV-Zeile</param>
        private void MitarbeiterFeldenFuellen(Mitarbeiter mitarbeiter, string[] teile)
        {
            mitarbeiter.Abteilung = Feld(teile, 11);
            mitarbeiter.AhvNummer = Feld(teile, 12);
            mitarbeiter.Adresse = Feld(teile, 13);
            mitarbeiter.Postleitzahl = Feld(teile, 14);
            mitarbeiter.Wohnort = Feld(teile, 15);
            mitarbeiter.Nationalitaet = Feld(teile, 16);
            mitarbeiter.Eintrittsdatum = DatumUmwandelnOptional(Feld(teile, 17), DateTime.Today);
            mitarbeiter.Austrittsdatum = DatumUmwandelnOptional(Feld(teile, 18), DateTime.MinValue);
            mitarbeiter.Beschaeftigungsgrad = ZahlImBereich(Feld(teile, 19), 100, 0, 100, "Beschäftigungsgrad");
            mitarbeiter.Rolle = Feld(teile, 20);
            mitarbeiter.Kaderstufe = ZahlImBereich(Feld(teile, 21), 0, 0, 5, "Kaderstufe");
            mitarbeiter.Geschaeftsadresse = Feld(teile, 22);

            // Ein Austritt kann nicht vor dem Eintritt liegen
            if (mitarbeiter.Austrittsdatum != DateTime.MinValue &&
                mitarbeiter.Austrittsdatum < mitarbeiter.Eintrittsdatum)
            {
                throw new Exception("Das Austrittsdatum liegt vor dem Eintrittsdatum.");
            }
        }

        /// <summary>
        /// Gibt den Inhalt einer Spalte zurück. Fehlt die Spalte in der
        /// Zeile (z.B. bei einer Kundenzeile ohne Mitarbeiterangaben),
        /// wird ein leerer Text geliefert statt ein Absturz ausgelöst.
        /// </summary>
        /// <param name="teile">Die Spalten der CSV-Zeile</param>
        /// <param name="index">Nummer der gewünschten Spalte</param>
        /// <returns>Inhalt der Spalte oder ein leerer Text</returns>
        private string Feld(string[] teile, int index)
        {
            if (index < teile.Length)
            {
                return teile[index].Trim();
            }

            return "";
        }

        /// <summary>
        /// Wandelt einen Text im Format TT.MM.JJJJ in ein Datum um.
        /// Bewusst von Hand zerlegt, damit das Ergebnis nicht von den
        /// Ländereinstellungen des Computers abhängt.
        /// </summary>
        /// <param name="text">Datum im Format TT.MM.JJJJ</param>
        /// <returns>Das umgewandelte Datum</returns>
        private DateTime DatumUmwandeln(string text)
        {
            string[] teile = text.Split('.');

            if (teile.Length != 3)
            {
                throw new Exception("Das Datum '" + text +
                                    "' hat nicht das Format TT.MM.JJJJ.");
            }

            try
            {
                int tag = Convert.ToInt32(teile[0]);
                int monat = Convert.ToInt32(teile[1]);
                int jahr = Convert.ToInt32(teile[2]);
                return new DateTime(jahr, monat, tag);
            }
            catch (Exception)
            {
                throw new Exception("Das Datum '" + text + "' ist ungültig.");
            }
        }

        /// <summary>
        /// Wie DatumUmwandeln, aber die Spalte darf auch leer sein.
        /// In diesem Fall wird der übergebene Standardwert verwendet
        /// (z.B. für ein fehlendes Austrittsdatum).
        /// </summary>
        /// <param name="text">Datum im Format TT.MM.JJJJ oder leer</param>
        /// <param name="standardwert">Wert, der bei leerer Spalte gilt</param>
        /// <returns>Das umgewandelte Datum oder der Standardwert</returns>
        private DateTime DatumUmwandelnOptional(string text, DateTime standardwert)
        {
            if (text == "")
            {
                return standardwert;
            }

            return DatumUmwandeln(text);
        }

        /// <summary>
        /// Wandelt einen Text in eine ganze Zahl um. Ist die Spalte leer,
        /// wird der Standardwert verwendet.
        /// </summary>
        /// <param name="text">Der umzuwandelnde Text</param>
        /// <param name="standardwert">Wert, der bei leerer Spalte gilt</param>
        /// <returns>Die umgewandelte Zahl oder der Standardwert</returns>
        private int ZahlUmwandeln(string text, int standardwert)
        {
            if (text == "")
            {
                return standardwert;
            }

            try
            {
                return Convert.ToInt32(text);
            }
            catch (Exception)
            {
                throw new Exception("'" + text + "' ist keine gültige Zahl.");
            }
        }

        /// <summary>
        /// Wandelt einen Text in eine ganze Zahl um und prüft zusätzlich,
        /// ob sie im erlaubten Bereich liegt. Ohne diese Prüfung würden
        /// unsinnige Werte von den Properties stillschweigend verworfen
        /// und der Benutzer würde nichts davon merken.
        /// </summary>
        /// <param name="text">Der umzuwandelnde Text</param>
        /// <param name="standardwert">Wert, der bei leerer Spalte gilt</param>
        /// <param name="minimum">Kleinster erlaubter Wert</param>
        /// <param name="maximum">Grösster erlaubter Wert</param>
        /// <param name="feldname">Name der Spalte für die Fehlermeldung</param>
        /// <returns>Die geprüfte Zahl</returns>
        private int ZahlImBereich(string text, int standardwert, int minimum, int maximum, string feldname)
        {
            int wert = ZahlUmwandeln(text, standardwert);

            if (wert < minimum || wert > maximum)
            {
                throw new Exception("Der Wert '" + text + "' für " + feldname +
                                    " liegt nicht zwischen " + minimum + " und " + maximum + ".");
            }

            return wert;
        }

        /// <summary>
        /// Wandelt den Text der Anrede in den passenden Enumerationswert um
        /// </summary>
        /// <param name="text">Text aus der Spalte Anrede</param>
        /// <returns>Der passende Wert der Enumeration Anrede</returns>
        private Anrede AnredeUmwandeln(string text)
        {
            if (text.ToLower() == "frau")
            {
                return Anrede.Frau;
            }

            return Anrede.Herr;
        }

        /// <summary>
        /// Wandelt den Text des Geschlechts in den passenden Enumerationswert um
        /// </summary>
        /// <param name="text">Text aus der Spalte Geschlecht</param>
        /// <returns>Der passende Wert der Enumeration Geschlecht</returns>
        private Geschlecht GeschlechtUmwandeln(string text)
        {
            string kleingeschrieben = text.ToLower();

            if (kleingeschrieben == "weiblich" || kleingeschrieben == "w")
            {
                return Geschlecht.Weiblich;
            }
            else if (kleingeschrieben == "divers" || kleingeschrieben == "d")
            {
                return Geschlecht.Divers;
            }

            return Geschlecht.Maennlich;
        }
    }
}
