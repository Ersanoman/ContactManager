using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ContactManager.Model
{
    /// <summary>
    /// Ein Kunde der Firma.
    /// Erbt alle allgemeinen Personendaten von der Basisklasse Person und
    /// hat zusätzlich eine Kontakthistorie mit Notizen.
    /// </summary>
    public class Kunde : Person
    {
        /// <summary>
        /// Liste aller protokollierten Kundenkontakte (Notizen)
        /// </summary>
        public List<Kontakteintrag> Kontakthistorie { get; set; }

        /// <summary>
        /// Name der Kategorie für die Anzeige und die Suche
        /// </summary>
        [XmlIgnore]
        public override string Kategorie
        {
            get { return "Kunde"; }
        }

        /// <summary>
        /// Leerer Konstruktor: erstellt eine leere Kontakthistorie.
        /// Wird auch für die XML-Serialisierung gebraucht.
        /// </summary>
        public Kunde()
        {
            Kontakthistorie = new List<Kontakteintrag>();
        }

    }
}
