using System;

namespace ContactManager.Model
{
    // Ein einzelner Eintrag in der Kontakthistorie eines Kunden.
    // Jeder Kundenkontakt wird als Notiz mit Zeitstempel protokolliert.
    public class Kontakteintrag
    {
        // Zeitpunkt, an dem der Kundenkontakt stattgefunden hat
        public DateTime Zeitpunkt { get; set; }

        // Inhalt der Notiz (freier Text)
        public string Notiz { get; set; }

        // Leerer Konstruktor, wird für die XML-Serialisierung gebraucht
        public Kontakteintrag()
        {
            Notiz = "";
        }

        // Konstruktor, der den Eintrag direkt mit Zeitpunkt und Notiz füllt
        public Kontakteintrag(DateTime zeitpunkt, string notiz)
        {
            Zeitpunkt = zeitpunkt;
            Notiz = notiz;
        }

        // Gibt den Eintrag als lesbaren Text zurück.
        // Die ListBox zeigt automatisch diesen Text an.
        public override string ToString()
        {
            return Zeitpunkt.ToString("dd.MM.yyyy HH:mm") + " - " + Notiz;
        }
    }
}
