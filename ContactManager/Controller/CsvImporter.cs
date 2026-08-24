using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ContactManager.Model;

namespace ContactManager.Controller
{
    // Liest Kontakte aus einer CSV-Datei ein (z.B. aus Excel exportiert).
    // Die erste Spalte bestimmt, welche Art von Person erzeugt wird:
    // "Kunde", "Mitarbeiter" oder "Lernender". So kann mit einer einzigen
    // Datei die ganze Vererbungshierarchie importiert werden.
    //
    // Aufbau einer Zeile, getrennt mit Strichpunkt:
    // Typ;Anrede;Titel;Vorname;Nachname;Geburtsdatum;Geschlecht;
    // TelefonGeschaeft;Mobiltelefon;EMail;Status;
    // Abteilung;AhvNummer;Adresse;Postleitzahl;Wohnort;Nationalitaet;
    // Eintrittsdatum;Austrittsdatum;Beschaeftigungsgrad;Rolle;Kaderstufe;
    // Geschaeftsadresse;Lehrjahre;AktuellesLehrjahr
    //
    // Bei Kunden bleiben die Spalten ab "Abteilung" leer.
    // Die erste Zeile darf eine Überschriftszeile sein, sie wird übersprungen.
    public class CsvImporter
    {
        // So viele Spalten braucht es mindestens (die Angaben, welche
        // jede Person hat). Die Mitarbeiterspalten dürfen fehlen.
        private const int MinimaleSpalten = 11;

        // Anzahl der Zeilen, die nicht eingelesen werden konnten
        public int AnzahlFehlerhaft { get; private set; }

        // Beschreibung der fehlerhaften Zeilen für die Meldung an den Benutzer
        public string Fehlermeldungen { get; private set; }

        // Konstruktor
        public CsvImporter()
        {
            Fehlermeldungen = "";
        }

        // Liest die CSV-Datei ein und gibt alle gültigen Kontakte zurück.
        // Fehlerhafte Zeilen werden übersprungen und gezählt, damit der
        // Import wegen einer einzelnen kaputten Zeile nicht abbricht.
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

        // Wandelt eine einzelne CSV-Zeile in einen Kunden, einen Mitarbeiter
        // oder einen Lernenden um. Stimmt etwas nicht, wird eine Exception
        // ausgelöst, die von der Methode Einlesen aufgefangen wird.
        private Person ZeileUmwandeln(string zeile)
        {
            string[] teile = zeile.Split(';');

            if (teile.Length < MinimaleSpalten)
            {
                throw new Exception("Die Zeile hat nur " + teile.Length +
                                    " statt mindestens " + MinimaleSpalten + " Spalten.");
            }

            // Vorname und Nachname sind Pflichtfelder
            if (Feld(teile, 3) == "" || Feld(teile, 4) == "")
            {
                throw new Exception("Vorname oder Nachname fehlt.");
            }

            // Die erste Spalte entscheidet, welches Objekt erzeugt wird
            Person person = PersonErzeugen(Feld(teile, 0));

            // Die Angaben, welche jede Person hat (aus der Basisklasse)
            person.Anrede = AnredeUmwandeln(Feld(teile, 1));
            person.Titel = Feld(teile, 2);
            person.Vorname = Feld(teile, 3);
            person.Nachname = Feld(teile, 4);
            person.Geburtsdatum = DatumUmwandeln(Feld(teile, 5));
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
                lernender.Lehrjahre = ZahlUmwandeln(Feld(teile, 23), 3);
                lernender.AktuellesLehrjahr = ZahlUmwandeln(Feld(teile, 24), 1);
            }

            return person;
        }

        // Erzeugt anhand der Typ-Spalte das passende Objekt der
        // Vererbungshierarchie
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

        // Füllt die Angaben ab, welche nur Mitarbeiter (und damit auch
        // Lernende) besitzen. Die Mitarbeiternummer wird nicht eingelesen,
        // diese vergibt die Kontaktverwaltung automatisch.
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
            mitarbeiter.Beschaeftigungsgrad = ZahlUmwandeln(Feld(teile, 19), 100);
            mitarbeiter.Rolle = Feld(teile, 20);
            mitarbeiter.Kaderstufe = ZahlUmwandeln(Feld(teile, 21), 0);
            mitarbeiter.Geschaeftsadresse = Feld(teile, 22);
        }

        // Gibt den Inhalt einer Spalte zurück. Fehlt die Spalte in der
        // Zeile (z.B. bei einer Kundenzeile ohne Mitarbeiterangaben),
        // wird ein leerer Text geliefert statt ein Absturz ausgelöst.
        private string Feld(string[] teile, int index)
        {
            if (index < teile.Length)
            {
                return teile[index].Trim();
            }

            return "";
        }

        // Wandelt einen Text im Format TT.MM.JJJJ in ein Datum um.
        // Bewusst von Hand zerlegt, damit das Ergebnis nicht von den
        // Ländereinstellungen des Computers abhängt.
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

        // Wie DatumUmwandeln, aber die Spalte darf auch leer sein.
        // In diesem Fall wird der übergebene Standardwert verwendet
        // (z.B. für ein fehlendes Austrittsdatum).
        private DateTime DatumUmwandelnOptional(string text, DateTime standardwert)
        {
            if (text == "")
            {
                return standardwert;
            }

            return DatumUmwandeln(text);
        }

        // Wandelt einen Text in eine ganze Zahl um. Ist die Spalte leer,
        // wird der Standardwert verwendet.
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

        // Wandelt den Text der Anrede in den passenden Enumerationswert um
        private Anrede AnredeUmwandeln(string text)
        {
            if (text.ToLower() == "frau")
            {
                return Anrede.Frau;
            }

            return Anrede.Herr;
        }

        // Wandelt den Text des Geschlechts in den passenden Enumerationswert um
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
