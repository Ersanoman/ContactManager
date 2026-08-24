using System;
using System.Xml.Serialization;

namespace ContactManager.Model
{
    /// <summary>
    /// Basisklasse der Vererbungshierarchie.
    /// Hier stecken alle Daten drin, die Kunden und Mitarbeiter gemeinsam haben.
    /// Es werden nie direkt Personen erzeugt, sondern immer Kunden,
    /// Mitarbeiter oder Lernende.
    ///
    /// Die XmlInclude-Attribute braucht es, damit die XML-Serialisierung
    /// weiss, dass in einer Personen-Liste auch die abgeleiteten Klassen
    /// vorkommen können.
    /// </summary>
    [XmlInclude(typeof(Kunde))]
    [XmlInclude(typeof(Mitarbeiter))]
    [XmlInclude(typeof(Lernender))]
    public class Person
    {
        /// <summary>
        /// Anrede der Person (Herr oder Frau)
        /// </summary>
        public Anrede Anrede { get; set; }

        /// <summary>
        /// Akademischer Titel, z.B. "Dr." (darf leer sein)
        /// </summary>
        public string Titel { get; set; }

        /// <summary>
        /// Vorname der Person
        /// </summary>
        public string Vorname { get; set; }

        /// <summary>
        /// Nachname der Person
        /// </summary>
        public string Nachname { get; set; }

        /// <summary>
        /// Geburtsdatum der Person
        /// </summary>
        public DateTime Geburtsdatum { get; set; }

        /// <summary>
        /// Geschlecht der Person
        /// </summary>
        public Geschlecht Geschlecht { get; set; }

        /// <summary>
        /// Geschäftliche Telefonnummer
        /// </summary>
        public string TelefonnummerGeschaeft { get; set; }

        /// <summary>
        /// Mobiltelefonnummer
        /// </summary>
        public string Mobiltelefonnummer { get; set; }

        /// <summary>
        /// E-Mail-Adresse
        /// </summary>
        public string EMailAdresse { get; set; }

        /// <summary>
        /// Status der Person: true = aktiv, false = passiv.
        /// So können Personen deaktiviert werden, ohne sie zu löschen.
        /// </summary>
        public bool Aktiv { get; set; }

        /// <summary>
        /// Name der Kategorie für die Anzeige und die Suche.
        /// Wird von den abgeleiteten Klassen überschrieben.
        /// </summary>
        [XmlIgnore]
        public virtual string Kategorie
        {
            get { return "Person"; }
        }

        /// <summary>
        /// Leerer Konstruktor: setzt Standardwerte.
        /// Wird auch für die XML-Serialisierung gebraucht.
        /// </summary>
        public Person()
        {
            Titel = "";
            Vorname = "";
            Nachname = "";
            Geburtsdatum = new DateTime(1990, 1, 1);
            TelefonnummerGeschaeft = "";
            Mobiltelefonnummer = "";
            EMailAdresse = "";
            Aktiv = true;
        }

        /// <summary>
        /// Gibt die Person als lesbaren Text zurück, z.B.
        /// "[Kunde] Muster Max, geb. 01.01.1990 (aktiv)".
        /// Die ListBox im Hauptfenster zeigt automatisch diesen Text an.
        /// </summary>
        /// <returns>Zusammenfassung der Person als Text</returns>
        public override string ToString()
        {
            // Ternärer Operator: aktiv oder passiv als Text
            string status = Aktiv ? "aktiv" : "passiv";
            return "[" + Kategorie + "] " + Nachname + " " + Vorname +
                   ", geb. " + Geburtsdatum.ToString("dd.MM.yyyy") + " (" + status + ")";
        }
    }
}
