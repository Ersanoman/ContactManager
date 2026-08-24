using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ContactManager.Model;

namespace ContactManager.Controller
{
    // Liest Kundendaten aus einer CSV-Datei ein (z.B. aus Excel exportiert).
    // Aufbau einer Zeile, getrennt mit Strichpunkt:
    // Anrede;Titel;Vorname;Nachname;Geburtsdatum;Geschlecht;
    // TelefonGeschaeft;Mobiltelefon;EMail;Status
    // Die erste Zeile darf eine Überschriftszeile sein, sie wird übersprungen.
    public class CsvImporter
    {
        // So viele Spalten muss eine gültige Zeile haben
        private const int AnzahlSpalten = 10;

        // Anzahl der Zeilen, die nicht eingelesen werden konnten
        public int AnzahlFehlerhaft { get; private set; }

        // Beschreibung der fehlerhaften Zeilen für die Meldung an den Benutzer
        public string Fehlermeldungen { get; private set; }

        // Konstruktor
        public CsvImporter()
        {
            Fehlermeldungen = "";
        }

        // Liest die CSV-Datei ein und gibt alle gültigen Kunden zurück.
        // Fehlerhafte Zeilen werden übersprungen und gezählt, damit der
        // Import wegen einer einzelnen kaputten Zeile nicht abbricht.
        public List<Kunde> Einlesen(string dateipfad)
        {
            List<Kunde> kunden = new List<Kunde>();
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
                if (i == 0 && zeile.ToLower().StartsWith("anrede"))
                {
                    continue;
                }

                try
                {
                    kunden.Add(ZeileUmwandeln(zeile));
                }
                catch (Exception ex)
                {
                    // Die Zeilennummer wird für den Benutzer ab 1 gezählt
                    AnzahlFehlerhaft++;
                    Fehlermeldungen = Fehlermeldungen + "Zeile " + (i + 1) + ": " + ex.Message + "\n";
                }
            }

            return kunden;
        }

        // Wandelt eine einzelne CSV-Zeile in einen Kunden um.
        // Stimmt etwas nicht, wird eine Exception ausgelöst, die von der
        // Methode Einlesen aufgefangen wird.
        private Kunde ZeileUmwandeln(string zeile)
        {
            string[] teile = zeile.Split(';');

            if (teile.Length < AnzahlSpalten)
            {
                throw new Exception("Die Zeile hat nur " + teile.Length +
                                    " statt " + AnzahlSpalten + " Spalten.");
            }

            // Vorname und Nachname sind Pflichtfelder
            if (teile[2].Trim() == "" || teile[3].Trim() == "")
            {
                throw new Exception("Vorname oder Nachname fehlt.");
            }

            Kunde kunde = new Kunde();
            kunde.Anrede = AnredeUmwandeln(teile[0].Trim());
            kunde.Titel = teile[1].Trim();
            kunde.Vorname = teile[2].Trim();
            kunde.Nachname = teile[3].Trim();
            kunde.Geburtsdatum = DatumUmwandeln(teile[4].Trim());
            kunde.Geschlecht = GeschlechtUmwandeln(teile[5].Trim());
            kunde.TelefonnummerGeschaeft = teile[6].Trim();
            kunde.Mobiltelefonnummer = teile[7].Trim();
            kunde.EMailAdresse = teile[8].Trim();

            // Alles ausser dem Wort "passiv" gilt als aktiv
            kunde.Aktiv = teile[9].Trim().ToLower() != "passiv";

            return kunde;
        }

        // Wandelt einen Text im Format TT.MM.JJJJ in ein Datum um.
        // Bewusst von Hand zerlegt, damit das Ergebnis nicht von den
        // Ländereinstellungen des Computers abhängt.
        private DateTime DatumUmwandeln(string text)
        {
            string[] teile = text.Split('.');

            if (teile.Length != 3)
            {
                throw new Exception("Das Geburtsdatum '" + text +
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
                throw new Exception("Das Geburtsdatum '" + text + "' ist ungültig.");
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
