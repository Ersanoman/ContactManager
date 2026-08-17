using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ContactManager.Model
{
    // Ein Kunde der Firma.
    // Erbt alle allgemeinen Personendaten von der Basisklasse Person und
    // hat zusätzlich eine Kontakthistorie mit Notizen.
    public class Kunde : Person
    {
        // Liste aller protokollierten Kundenkontakte (Notizen)
        public List<Kontakteintrag> Kontakthistorie { get; set; }

        // Name der Kategorie für die Anzeige und die Suche
        [XmlIgnore]
        public override string Kategorie
        {
            get { return "Kunde"; }
        }

        // Leerer Konstruktor: erstellt eine leere Kontakthistorie.
        // Wird auch für die XML-Serialisierung gebraucht.
        public Kunde()
        {
            Kontakthistorie = new List<Kontakteintrag>();
        }

        // Fügt der Kontakthistorie eine neue Notiz mit dem aktuellen
        // Zeitpunkt hinzu
        public void NotizHinzufuegen(string notiz)
        {
            Kontakthistorie.Add(new Kontakteintrag(DateTime.Now, notiz));
        }
    }
}
