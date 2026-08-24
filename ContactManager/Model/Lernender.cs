using System.Xml.Serialization;

namespace ContactManager.Model
{
    /// <summary>
    /// Ein Lernender (Lehrling) der Firma.
    /// Ein Lernender ist ein spezieller Mitarbeiter ("Ist-ein"-Beziehung):
    /// Er erbt alles vom Mitarbeiter und hat zusätzlich die Angaben zur Lehre.
    /// </summary>
    public class Lernender : Mitarbeiter
    {
        /// <summary>
        /// Private Felder für die Properties mit Wertprüfung (Datenkapselung)
        /// </summary>
        private int lehrjahre;
        private int aktuellesLehrjahr;

        /// <summary>
        /// Gesamtdauer der Lehre in Jahren.
        /// Das set lässt nur Werte von 1 bis 4 zu, ungültige Werte
        /// werden ignoriert.
        /// </summary>
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

        /// <summary>
        /// Aktuelles Lehrjahr des Lernenden.
        /// Das set lässt nur Werte von 1 bis 4 zu, ungültige Werte
        /// werden ignoriert.
        /// </summary>
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

        /// <summary>
        /// Name der Kategorie für die Anzeige und die Suche
        /// </summary>
        [XmlIgnore]
        public override string Kategorie
        {
            get { return "Lernender"; }
        }

        /// <summary>
        /// Leerer Konstruktor: setzt Standardwerte (3-jährige Lehre,
        /// 1. Lehrjahr). Wird auch für die XML-Serialisierung gebraucht.
        /// </summary>
        public Lernender()
        {
            lehrjahre = 3;
            aktuellesLehrjahr = 1;
        }
    }
}
