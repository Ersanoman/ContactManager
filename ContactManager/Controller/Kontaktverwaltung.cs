using System;
using System.Collections.Generic;
using ContactManager.Model;

namespace ContactManager.Controller
{
    /// <summary>
    /// Zentrale Verwaltungsklasse (Controller) der Applikation.
    /// Hält die Liste aller Personen und stellt den Formularen alle
    /// Funktionen bereit: Erfassen, Mutieren, Löschen, Aktivieren/
    /// Deaktivieren, Suchen und die automatische Mitarbeiternummer.
    /// Nach jeder Änderung wird automatisch gespeichert.
    /// </summary>
    public class Kontaktverwaltung
    {
        /// <summary>
        /// Zentrale Liste mit allen Personen. Dank der Vererbung können
        /// Kunden, Mitarbeiter und Lernende zusammen in einer Liste vom
        /// Basistyp Person verwaltet werden.
        /// </summary>
        private List<Person> personen;

        /// <summary>
        /// Zuständig für das Speichern und Laden auf die Festplatte
        /// </summary>
        private Datenspeicher datenspeicher;

        /// <summary>
        /// Konstruktor: lädt beim Programmstart automatisch alle Daten
        /// </summary>
        public Kontaktverwaltung()
        {
            datenspeicher = new Datenspeicher();
            personen = datenspeicher.Laden();
        }

        /// <summary>
        /// Liste aller verwalteten Personen
        /// </summary>
        public List<Person> AllePersonen
        {
            get { return personen; }
        }

        /// <summary>
        /// Fügt eine neue Person hinzu. Mitarbeiter und Lernende bekommen
        /// automatisch die nächste freie Mitarbeiternummer.
        /// </summary>
        /// <param name="person">Die neu erfasste Person</param>
        public void Hinzufuegen(Person person)
        {
            MitarbeiternummerVergeben(person);
            personen.Add(person);
            Speichern();
        }

        /// <summary>
        /// Ersetzt eine bestehende Person durch die bearbeitete Version
        /// (Mutieren). Die Position in der Liste bleibt gleich.
        /// Nötig, weil beim Bearbeiten auch der Typ wechseln kann
        /// (z.B. ein Mitarbeiter wird zum Lernenden).
        /// </summary>
        /// <param name="alt">Die bisherige Person aus der Liste</param>
        /// <param name="neu">Die bearbeitete Version der Person</param>
        public void Ersetzen(Person alt, Person neu)
        {
            int position = personen.IndexOf(alt);
            if (position >= 0)
            {
                MitarbeiternummerVergeben(neu);
                personen[position] = neu;
                Speichern();
            }
        }

        /// <summary>
        /// Löscht eine Person definitiv aus dem Datenstamm
        /// </summary>
        /// <param name="person">Die zu löschende Person</param>
        public void Loeschen(Person person)
        {
            personen.Remove(person);
            Speichern();
        }

        /// <summary>
        /// Schaltet den Status um: aus aktiv wird passiv und umgekehrt
        /// </summary>
        /// <param name="person">Die Person, deren Status umgeschaltet wird</param>
        public void AktivUmschalten(Person person)
        {
            person.Aktiv = !person.Aktiv;
            Speichern();
        }

        /// <summary>
        /// Ermittelt die nächste freie Mitarbeiternummer.
        /// Die erste Nummer ist 1000, danach immer höchste Nummer + 1.
        /// </summary>
        /// <returns>Die nächste freie Mitarbeiternummer</returns>
        public int NaechsteMitarbeiternummer()
        {
            int hoechsteNummer = 999;

            foreach (Person person in personen)
            {
                // Nur Mitarbeiter (und Lernende) haben eine Mitarbeiternummer
                if (person is Mitarbeiter)
                {
                    Mitarbeiter mitarbeiter = (Mitarbeiter)person;
                    if (mitarbeiter.Mitarbeiternummer > hoechsteNummer)
                    {
                        hoechsteNummer = mitarbeiter.Mitarbeiternummer;
                    }
                }
            }

            return hoechsteNummer + 1;
        }

        /// <summary>
        /// Gibt alle Personen alphabetisch sortiert zurück.
        /// Die interne Liste bleibt unverändert, es wird eine Kopie sortiert.
        /// </summary>
        /// <returns>Eine sortierte Kopie aller Personen</returns>
        public List<Person> AlleSortiert()
        {
            List<Person> kopie = new List<Person>();

            foreach (Person person in personen)
            {
                kopie.Add(person);
            }

            Sortieren(kopie);
            return kopie;
        }

        /// <summary>
        /// Durchsucht den Datenstamm nach den übergebenen Kriterien.
        /// Alle Kriterien sind kombinierbar, leere Kriterien werden
        /// ignoriert. Die Namenssuche findet auch Teiltreffer und
        /// ignoriert Gross-/Kleinschreibung.
        /// </summary>
        /// <param name="nachname">Gesuchter Nachname (leer = ignorieren)</param>
        /// <param name="vorname">Gesuchter Vorname (leer = ignorieren)</param>
        /// <param name="mitGeburtsdatum">true, wenn nach dem Geburtsdatum gesucht werden soll</param>
        /// <param name="geburtsdatum">Gesuchtes Geburtsdatum</param>
        /// <param name="kategorie">"Alle", "Kunde", "Mitarbeiter" oder "Lernender"</param>
        /// <returns>Alle Personen, welche sämtliche Kriterien erfüllen</returns>
        public List<Person> Suchen(string nachname, string vorname, bool mitGeburtsdatum,
                                   DateTime geburtsdatum, string kategorie)
        {
            List<Person> resultate = new List<Person>();

            foreach (Person person in personen)
            {
                bool passt = true;

                // Kriterium Nachname: Teiltreffer, Gross-/Kleinschreibung egal
                if (nachname != "" && !person.Nachname.ToLower().Contains(nachname.ToLower()))
                {
                    passt = false;
                }

                // Kriterium Vorname: Teiltreffer, Gross-/Kleinschreibung egal
                if (vorname != "" && !person.Vorname.ToLower().Contains(vorname.ToLower()))
                {
                    passt = false;
                }

                // Kriterium Geburtsdatum: nur das Datum vergleichen (ohne Uhrzeit)
                if (mitGeburtsdatum && person.Geburtsdatum.Date != geburtsdatum.Date)
                {
                    passt = false;
                }

                // Kriterium Kategorie: mit dem is-Operator wird der Typ geprüft.
                // Wichtig: Ein Lernender ist auch ein Mitarbeiter, darum findet
                // die Kategorie "Mitarbeiter" auch alle Lernenden.
                if (kategorie == "Kunde" && !(person is Kunde))
                {
                    passt = false;
                }
                else if (kategorie == "Mitarbeiter" && !(person is Mitarbeiter))
                {
                    passt = false;
                }
                else if (kategorie == "Lernender" && !(person is Lernender))
                {
                    passt = false;
                }

                if (passt)
                {
                    resultate.Add(person);
                }
            }

            // Die Treffer werden alphabetisch sortiert ausgegeben
            Sortieren(resultate);
            return resultate;
        }

        /// <summary>
        /// Prüft, ob bereits eine Person mit gleichem Nachnamen, Vornamen
        /// und Geburtsdatum erfasst ist. Wird beim CSV-Import gebraucht,
        /// damit dieselbe Datei nicht zweimal importiert werden kann.
        /// </summary>
        /// <param name="neuePerson">Die zu prüfende Person</param>
        /// <returns>true, wenn die Person bereits erfasst ist</returns>
        public bool ExistiertBereits(Person neuePerson)
        {
            foreach (Person person in personen)
            {
                if (person.Nachname.ToLower() == neuePerson.Nachname.ToLower() &&
                    person.Vorname.ToLower() == neuePerson.Vorname.ToLower() &&
                    person.Geburtsdatum.Date == neuePerson.Geburtsdatum.Date)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Zählt alle Personen einer Kategorie ("Alle", "Kunde",
        /// "Mitarbeiter" oder "Lernender"). Wird für das Dashboard gebraucht.
        /// </summary>
        /// <param name="kategorie">"Alle", "Kunde", "Mitarbeiter" oder "Lernender"</param>
        /// <returns>Anzahl Personen dieser Kategorie</returns>
        public int Anzahl(string kategorie)
        {
            // Die Suchmethode kann wiederverwendet werden: ohne Namensfilter
            // liefert sie einfach alle Personen der gewünschten Kategorie
            return Suchen("", "", false, DateTime.Today, kategorie).Count;
        }

        /// <summary>
        /// Zählt die aktiven oder die passiven Personen.
        /// true = aktive zählen, false = passive zählen.
        /// </summary>
        /// <param name="aktiv">true = aktive zählen, false = passive zählen</param>
        /// <returns>Anzahl Personen mit diesem Status</returns>
        public int AnzahlNachStatus(bool aktiv)
        {
            int anzahl = 0;

            foreach (Person person in personen)
            {
                if (person.Aktiv == aktiv)
                {
                    anzahl++;
                }
            }

            return anzahl;
        }

        /// <summary>
        /// Zählt alle Notizen, die über alle Kunden hinweg erfasst wurden
        /// </summary>
        /// <returns>Anzahl aller Notizen über alle Kunden</returns>
        public int AnzahlKontaktnotizen()
        {
            int anzahl = 0;

            foreach (Person person in personen)
            {
                // Nur Kunden haben eine Kontakthistorie
                if (person is Kunde)
                {
                    Kunde kunde = (Kunde)person;
                    anzahl = anzahl + kunde.Kontakthistorie.Count;
                }
            }

            return anzahl;
        }

        /// <summary>
        /// Sortiert eine Personenliste alphabetisch nach Nachname und
        /// bei gleichem Nachnamen zusätzlich nach Vorname.
        /// Umgesetzt mit dem Bubblesort-Algorithmus (optimierte Variante
        /// aus dem Unterricht): Solange zwei benachbarte Elemente in der
        /// falschen Reihenfolge stehen, werden sie getauscht.
        /// </summary>
        /// <param name="liste">Die zu sortierende Liste</param>
        private void Sortieren(List<Person> liste)
        {
            bool getauscht = true;
            int laenge = liste.Count;

            while (getauscht)
            {
                getauscht = false;

                for (int i = 0; i < laenge - 1; i++)
                {
                    if (VergleicheNamen(liste[i], liste[i + 1]) > 0)
                    {
                        // Die beiden Elemente tauschen
                        Person zwischenspeicher = liste[i];
                        liste[i] = liste[i + 1];
                        liste[i + 1] = zwischenspeicher;
                        getauscht = true;
                    }
                }

                // Das letzte Element steht nach jedem Durchgang bereits
                // richtig und muss nicht mehr verglichen werden
                laenge--;
            }
        }

        /// <summary>
        /// Vergleicht zwei Personen anhand von Nachname und Vorname.
        /// Rückgabe kleiner 0: person1 kommt zuerst,
        /// Rückgabe grösser 0: person2 kommt zuerst, 0: gleich.
        /// </summary>
        /// <param name="person1">Erste Person</param>
        /// <param name="person2">Zweite Person</param>
        /// <returns>Kleiner 0, wenn person1 zuerst kommt; grösser 0 umgekehrt; 0 bei gleich</returns>
        private int VergleicheNamen(Person person1, Person person2)
        {
            // CompareTo vergleicht zwei Texte alphabetisch
            int vergleich = person1.Nachname.ToLower().CompareTo(person2.Nachname.ToLower());

            // Bei gleichem Nachnamen entscheidet der Vorname
            if (vergleich == 0)
            {
                vergleich = person1.Vorname.ToLower().CompareTo(person2.Vorname.ToLower());
            }

            return vergleich;
        }

        /// <summary>
        /// Speichert den aktuellen Datenstamm. Wird von aussen aufgerufen,
        /// wenn eine Person direkt verändert wurde.
        /// </summary>
        public void AenderungenSpeichern()
        {
            Speichern();
        }

        /// <summary>
        /// Vergibt einem Mitarbeiter oder Lernenden die nächste freie
        /// Nummer, falls er noch keine hat (Wert 0). Bei Kunden passiert nichts.
        /// </summary>
        /// <param name="person">Die zu prüfende Person</param>
        private void MitarbeiternummerVergeben(Person person)
        {
            if (person is Mitarbeiter)
            {
                Mitarbeiter mitarbeiter = (Mitarbeiter)person;
                if (mitarbeiter.Mitarbeiternummer == 0)
                {
                    mitarbeiter.Mitarbeiternummer = NaechsteMitarbeiternummer();
                }
            }
        }

        /// <summary>
        /// Speichert alle Personen über den Datenspeicher auf die
        /// Festplatte (automatisches Speichern nach jeder Änderung)
        /// </summary>
        private void Speichern()
        {
            datenspeicher.Speichern(personen);
        }
    }
}
