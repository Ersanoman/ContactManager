using System;

namespace ContactManager.Model
{
    /// <summary>
    /// Ein einzelner Eintrag in der Kontakthistorie eines Kunden.
    /// Jeder Kundenkontakt wird als Notiz mit Zeitstempel protokolliert.
    /// </summary>
    public class Kontakteintrag
    {
        /// <summary>
        /// Zeitpunkt, an dem der Kundenkontakt stattgefunden hat
        /// </summary>
        public DateTime Zeitpunkt { get; set; }

        /// <summary>
        /// Inhalt der Notiz (freier Text)
        /// </summary>
        public string Notiz { get; set; }

        /// <summary>
        /// Leerer Konstruktor, wird für die XML-Serialisierung gebraucht
        /// </summary>
        public Kontakteintrag()
        {
            Notiz = "";
        }

        /// <summary>
        /// Konstruktor, der den Eintrag direkt mit Zeitpunkt und Notiz füllt
        /// </summary>
        /// <param name="zeitpunkt">Zeitpunkt des Kundenkontakts</param>
        /// <param name="notiz">Inhalt der Notiz</param>
        public Kontakteintrag(DateTime zeitpunkt, string notiz)
        {
            Zeitpunkt = zeitpunkt;
            Notiz = notiz;
        }

        /// <summary>
        /// Gibt den Eintrag als lesbaren Text zurück.
        /// Die ListBox zeigt automatisch diesen Text an.
        /// </summary>
        /// <returns>Zeitpunkt und Notiz als lesbarer Text</returns>
        public override string ToString()
        {
            return Zeitpunkt.ToString("dd.MM.yyyy HH:mm") + " - " + Notiz;
        }
    }
}
