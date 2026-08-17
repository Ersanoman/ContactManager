using System;
using System.Xml.Serialization;

namespace ContactManager.Model
{
    // Basisklasse der Vererbungshierarchie.
    // Hier stecken alle Daten drin, die Kunden und Mitarbeiter gemeinsam haben.
    // Es werden nie direkt Personen erzeugt, sondern immer Kunden,
    // Mitarbeiter oder Lernende.
    //
    // Die XmlInclude-Attribute braucht es, damit die XML-Serialisierung
    // weiss, dass in einer Personen-Liste auch die abgeleiteten Klassen
    // vorkommen können.
    [XmlInclude(typeof(Kunde))]
    [XmlInclude(typeof(Mitarbeiter))]
    [XmlInclude(typeof(Lernender))]
    public class Person
    {
        // Anrede der Person (Herr oder Frau)
        public Anrede Anrede { get; set; }

        // Akademischer Titel, z.B. "Dr." (darf leer sein)
        public string Titel { get; set; }

        // Vorname der Person
        public string Vorname { get; set; }

        // Nachname der Person
        public string Nachname { get; set; }

        // Geburtsdatum der Person
        public DateTime Geburtsdatum { get; set; }

        // Geschlecht der Person
        public Geschlecht Geschlecht { get; set; }

        // Geschäftliche Telefonnummer
        public string TelefonnummerGeschaeft { get; set; }

        // Mobiltelefonnummer
        public string Mobiltelefonnummer { get; set; }

        // E-Mail-Adresse
        public string EMailAdresse { get; set; }

        // Status der Person: true = aktiv, false = passiv.
        // So können Personen deaktiviert werden, ohne sie zu löschen.
        public bool Aktiv { get; set; }

        // Name der Kategorie für die Anzeige und die Suche.
        // Wird von den abgeleiteten Klassen überschrieben.
        [XmlIgnore]
        public virtual string Kategorie
        {
            get { return "Person"; }
        }

        // Leerer Konstruktor: setzt Standardwerte.
        // Wird auch für die XML-Serialisierung gebraucht.
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

        // Gibt die Person als lesbaren Text zurück, z.B.
        // "[Kunde] Muster Max, geb. 01.01.1990 (aktiv)".
        // Die ListBox im Hauptfenster zeigt automatisch diesen Text an.
        public override string ToString()
        {
            // Ternärer Operator: aktiv oder passiv als Text
            string status = Aktiv ? "aktiv" : "passiv";
            return "[" + Kategorie + "] " + Nachname + " " + Vorname +
                   ", geb. " + Geburtsdatum.ToString("dd.MM.yyyy") + " (" + status + ")";
        }
    }
}
