using System.Xml.Serialization;

namespace ContactManager.Model
{
    // Ein Lernender (Lehrling) der Firma.
    // Ein Lernender ist ein spezieller Mitarbeiter ("Ist-ein"-Beziehung):
    // Er erbt alles vom Mitarbeiter und hat zusätzlich die Angaben zur Lehre.
    public class Lernender : Mitarbeiter
    {
        // Private Felder für die Properties mit Wertprüfung (Datenkapselung)
        private int lehrjahre;
        private int aktuellesLehrjahr;

        // Gesamtdauer der Lehre in Jahren.
        // Das set lässt nur Werte von 1 bis 4 zu, ungültige Werte
        // werden ignoriert.
        public int Lehrjahre
        {
            get { return lehrjahre; }
            set
            {
                if (value >= 1 && value <= 4)
                {
                    lehrjahre = value;
                }
            }
        }

        // Aktuelles Lehrjahr des Lernenden.
        // Das set lässt nur Werte von 1 bis 4 zu, ungültige Werte
        // werden ignoriert.
        public int AktuellesLehrjahr
        {
            get { return aktuellesLehrjahr; }
            set
            {
                if (value >= 1 && value <= 4)
                {
                    aktuellesLehrjahr = value;
                }
            }
        }

        // Name der Kategorie für die Anzeige und die Suche
        [XmlIgnore]
        public override string Kategorie
        {
            get { return "Lernender"; }
        }

        // Leerer Konstruktor: setzt Standardwerte (3-jährige Lehre,
        // 1. Lehrjahr). Wird auch für die XML-Serialisierung gebraucht.
        public Lernender()
        {
            lehrjahre = 3;
            aktuellesLehrjahr = 1;
        }
    }
}
