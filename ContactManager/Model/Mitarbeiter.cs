using System;
using System.Xml.Serialization;

namespace ContactManager.Model
{
    /// <summary>
    /// Ein Mitarbeiter der Firma.
    /// Erbt alle allgemeinen Personendaten von der Basisklasse Person und
    /// hat zusätzlich die Daten zur Anstellung.
    /// </summary>
    public class Mitarbeiter : Person
    {
        /// <summary>
        /// Private Felder für die Properties mit Wertprüfung (Datenkapselung)
        /// </summary>
        private int kaderstufe;
        private int beschaeftigungsgrad;

        /// <summary>
        /// Eindeutige Mitarbeiternummer.
        /// Wird von der Kontaktverwaltung automatisch vergeben (ab 1000).
        /// 0 bedeutet: noch keine Nummer vergeben.
        /// </summary>
        public int Mitarbeiternummer { get; set; }

        /// <summary>
        /// Abteilung, in der der Mitarbeiter arbeitet
        /// </summary>
        public string Abteilung { get; set; }

        /// <summary>
        /// Schweizer AHV-Nummer im Format 756.XXXX.XXXX.XX
        /// </summary>
        public string AhvNummer { get; set; }

        /// <summary>
        /// Private Wohnadresse (Strasse und Hausnummer)
        /// </summary>
        public string Adresse { get; set; }

        /// <summary>
        /// Postleitzahl des Wohnorts (in der Schweiz vierstellig)
        /// </summary>
        public string Postleitzahl { get; set; }

        /// <summary>
        /// Wohnort des Mitarbeiters
        /// </summary>
        public string Wohnort { get; set; }

        /// <summary>
        /// Nationalität des Mitarbeiters
        /// </summary>
        public string Nationalitaet { get; set; }

        /// <summary>
        /// Datum des Firmeneintritts
        /// </summary>
        public DateTime Eintrittsdatum { get; set; }

        /// <summary>
        /// Datum des Firmenaustritts.
        /// DateTime.MinValue bedeutet: noch angestellt, kein Austritt.
        /// </summary>
        public DateTime Austrittsdatum { get; set; }

        /// <summary>
        /// Beschäftigungsgrad in Prozent.
        /// Das set lässt nur Werte von 0 bis 100 zu, ungültige Werte
        /// werden ignoriert (Datenkapselung).
        /// </summary>
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

        /// <summary>
        /// Rolle bzw. Tätigkeitsbezeichnung des Mitarbeiters
        /// </summary>
        public string Rolle { get; set; }

        /// <summary>
        /// Kaderstufe des Mitarbeiters.
        /// Das set lässt nur Werte von 0 bis 5 zu, ungültige Werte
        /// werden ignoriert (Datenkapselung).
        /// </summary>
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

        /// <summary>
        /// Geschäftsadresse des Arbeitsorts
        /// </summary>
        public string Geschaeftsadresse { get; set; }

        /// <summary>
        /// Name der Kategorie für die Anzeige und die Suche
        /// </summary>
        [XmlIgnore]
        public override string Kategorie
        {
            get { return "Mitarbeiter"; }
        }

        /// <summary>
        /// Leerer Konstruktor: setzt Standardwerte.
        /// Wird auch für die XML-Serialisierung gebraucht.
        /// </summary>
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

        /// <summary>
        /// Gibt den Mitarbeiter als lesbaren Text zurück.
        /// Ruft ToString der Basisklasse auf und hängt die
        /// Mitarbeiternummer an.
        /// </summary>
        /// <returns>Zusammenfassung des Mitarbeiters als Text</returns>
        public override string ToString()
        {
            return base.ToString() + " - Nr. " + Mitarbeiternummer;
        }
    }
}
