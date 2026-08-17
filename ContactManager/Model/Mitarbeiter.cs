using System;
using System.Xml.Serialization;

namespace ContactManager.Model
{
    // Ein Mitarbeiter der Firma.
    // Erbt alle allgemeinen Personendaten von der Basisklasse Person und
    // hat zusätzlich die Daten zur Anstellung.
    public class Mitarbeiter : Person
    {
        // Private Felder für die Properties mit Wertprüfung (Datenkapselung)
        private int kaderstufe;
        private int beschaeftigungsgrad;

        // Eindeutige Mitarbeiternummer.
        // Wird von der Kontaktverwaltung automatisch vergeben (ab 1000).
        // 0 bedeutet: noch keine Nummer vergeben.
        public int Mitarbeiternummer { get; set; }

        // Abteilung, in der der Mitarbeiter arbeitet
        public string Abteilung { get; set; }

        // Schweizer AHV-Nummer im Format 756.XXXX.XXXX.XX
        public string AhvNummer { get; set; }

        // Private Wohnadresse (Strasse und Hausnummer)
        public string Adresse { get; set; }

        // Postleitzahl des Wohnorts (in der Schweiz vierstellig)
        public string Postleitzahl { get; set; }

        // Wohnort des Mitarbeiters
        public string Wohnort { get; set; }

        // Nationalität des Mitarbeiters
        public string Nationalitaet { get; set; }

        // Datum des Firmeneintritts
        public DateTime Eintrittsdatum { get; set; }

        // Datum des Firmenaustritts.
        // DateTime.MinValue bedeutet: noch angestellt, kein Austritt.
        public DateTime Austrittsdatum { get; set; }

        // Beschäftigungsgrad in Prozent.
        // Das set lässt nur Werte von 0 bis 100 zu, ungültige Werte
        // werden ignoriert (Datenkapselung).
        public int Beschaeftigungsgrad
        {
            get { return beschaeftigungsgrad; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    beschaeftigungsgrad = value;
                }
            }
        }

        // Rolle bzw. Tätigkeitsbezeichnung des Mitarbeiters
        public string Rolle { get; set; }

        // Kaderstufe des Mitarbeiters.
        // Das set lässt nur Werte von 0 bis 5 zu, ungültige Werte
        // werden ignoriert (Datenkapselung).
        public int Kaderstufe
        {
            get { return kaderstufe; }
            set
            {
                if (value >= 0 && value <= 5)
                {
                    kaderstufe = value;
                }
            }
        }

        // Geschäftsadresse des Arbeitsorts
        public string Geschaeftsadresse { get; set; }

        // Name der Kategorie für die Anzeige und die Suche
        [XmlIgnore]
        public override string Kategorie
        {
            get { return "Mitarbeiter"; }
        }

        // Leerer Konstruktor: setzt Standardwerte.
        // Wird auch für die XML-Serialisierung gebraucht.
        public Mitarbeiter()
        {
            Abteilung = "";
            AhvNummer = "";
            Adresse = "";
            Postleitzahl = "";
            Wohnort = "";
            Nationalitaet = "";
            Eintrittsdatum = DateTime.Today;
            Austrittsdatum = DateTime.MinValue;
            beschaeftigungsgrad = 100;
            Rolle = "";
            kaderstufe = 0;
            Geschaeftsadresse = "";
        }

        // Gibt den Mitarbeiter als lesbaren Text zurück.
        // Ruft ToString der Basisklasse auf und hängt die
        // Mitarbeiternummer an.
        public override string ToString()
        {
            return base.ToString() + " - Nr. " + Mitarbeiternummer;
        }
    }
}
