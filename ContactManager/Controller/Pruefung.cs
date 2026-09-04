using System;

namespace ContactManager.Controller
{
    /// <summary>
    /// Sammlung aller Prüfregeln für Benutzereingaben.
    /// Die Klasse ist statisch, es muss also kein Objekt erzeugt werden
    /// (gleiches Prinzip wie bei der Klasse Math aus dem Unterricht).
    /// So stehen die Regeln beiden Erfassungsdialogen zur Verfügung und
    /// müssen nicht doppelt geschrieben werden.
    /// </summary>
    public static class Pruefung
    {
        /// <summary>
        /// Prüft, ob ein Text keine Ziffern enthält.
        /// Wird für Namen, Titel, Wohnort und Nationalität verwendet,
        /// denn dort gehören keine Zahlen hinein.
        /// </summary>
        /// <param name="text">Der zu prüfende Text</param>
        /// <returns>true, wenn keine einzige Ziffer enthalten ist</returns>
        public static bool OhneZiffern(string text)
        {
            foreach (char zeichen in text)
            {
                if (zeichen >= '0' && zeichen <= '9')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Prüft, ob eine Telefonnummer nur aus Ziffern und Leerzeichen besteht.
        /// Wird zusätzlich zur Tastatursperre gebraucht, weil eingefügter
        /// Text (Ctrl+V) nicht über die Tastatur kommt.
        /// </summary>
        /// <param name="nummer">Die zu prüfende Telefonnummer</param>
        /// <returns>true, wenn die Nummer nur Ziffern enthält</returns>
        public static bool TelefonnummerGueltig(string nummer)
        {
            // Leerzeichen entfernen, danach dürfen nur Ziffern übrig sein
            string ziffern = nummer.Replace(" ", "");

            foreach (char zeichen in ziffern)
            {
                if (zeichen < '0' || zeichen > '9')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Prüft eine E-Mail-Adresse auf ihren grundsätzlichen Aufbau:
        /// genau ein @-Zeichen, davor und danach Text, im hinteren Teil
        /// ein Punkt und danach mindestens zwei Zeichen (z.B. ".ch").
        /// </summary>
        /// <param name="email">Die zu prüfende E-Mail-Adresse</param>
        /// <returns>true, wenn die Adresse sinnvoll aufgebaut ist</returns>
        public static bool EMailGueltig(string email)
        {
            // In einer E-Mail-Adresse haben Leerzeichen nichts verloren
            if (email.Contains(" "))
            {
                return false;
            }

            // Genau ein @-Zeichen: beim Trennen entstehen zwei Teile
            string[] teile = email.Split('@');
            if (teile.Length != 2)
            {
                return false;
            }

            // Vor dem @ muss etwas stehen
            if (teile[0].Length == 0)
            {
                return false;
            }

            // Der hintere Teil muss mindestens einen Punkt enthalten
            string[] bereiche = teile[1].Split('.');
            if (bereiche.Length < 2)
            {
                return false;
            }

            // Zwischen den Punkten darf kein Bereich leer sein
            foreach (string bereich in bereiche)
            {
                if (bereich.Length == 0)
                {
                    return false;
                }
            }

            // Die Endung (z.B. ch oder com) braucht mindestens zwei Zeichen
            if (bereiche[bereiche.Length - 1].Length < 2)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Prüft, ob eine AHV-Nummer gültig ist. Erwartet wird das
        /// Schweizer Format 756.XXXX.XXXX.XX, also 13 Ziffern,
        /// beginnend mit dem Ländercode 756.
        /// </summary>
        /// <param name="ahvNummer">Die zu prüfende AHV-Nummer</param>
        /// <returns>true, wenn die AHV-Nummer gültig ist</returns>
        public static bool AhvNummerGueltig(string ahvNummer)
        {
            // Die Trennpunkte entfernen, damit nur die Ziffern übrig bleiben
            string ziffern = ahvNummer.Replace(".", "");

            if (ziffern.Length != 13)
            {
                return false;
            }

            if (ziffern.Substring(0, 3) != "756")
            {
                return false;
            }

            // Es dürfen wirklich nur Ziffern enthalten sein
            return TelefonnummerGueltig(ziffern);
        }

        /// <summary>
        /// Prüft, ob eine Postleitzahl gültig ist. Schweizer Postleitzahlen
        /// sind vierstellige Zahlen von 1000 bis 9999.
        /// </summary>
        /// <param name="postleitzahl">Die zu prüfende Postleitzahl</param>
        /// <returns>true, wenn die Postleitzahl gültig ist</returns>
        public static bool PostleitzahlGueltig(string postleitzahl)
        {
            try
            {
                int wert = Convert.ToInt32(postleitzahl);
                return wert >= 1000 && wert <= 9999;
            }
            catch (Exception)
            {
                // Die Eingabe ist gar keine Zahl
                return false;
            }
        }

        /// <summary>
        /// Prüft, ob ein Geburtsdatum sinnvoll ist: nicht in der Zukunft
        /// und nicht vor dem Jahr 1900.
        /// </summary>
        /// <param name="geburtsdatum">Das zu prüfende Geburtsdatum</param>
        /// <returns>true, wenn das Geburtsdatum plausibel ist</returns>
        public static bool GeburtsdatumPlausibel(DateTime geburtsdatum)
        {
            return geburtsdatum.Date <= DateTime.Today &&
                   geburtsdatum.Year >= 1900;
        }

        /// <summary>
        /// Prüft, ob ein Datum innerhalb eines erlaubten Bereichs liegt.
        /// Wird gebraucht, bevor ein Datum in ein Datums-Auswahlfeld
        /// geschrieben wird: ein Wert ausserhalb von MinDate und MaxDate
        /// würde dort einen Laufzeitfehler auslösen.
        /// </summary>
        /// <param name="datum">Das zu prüfende Datum</param>
        /// <param name="minimum">Kleinstes erlaubtes Datum</param>
        /// <param name="maximum">Grösstes erlaubtes Datum</param>
        /// <returns>true, wenn das Datum im erlaubten Bereich liegt</returns>
        public static bool DatumImBereich(DateTime datum, DateTime minimum, DateTime maximum)
        {
            return datum >= minimum && datum <= maximum;
        }
    }
}
