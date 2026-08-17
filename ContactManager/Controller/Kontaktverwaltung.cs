using System;
using System.Collections.Generic;
using ContactManager.Model;

namespace ContactManager.Controller
{
    // Zentrale Verwaltungsklasse (Controller) der Applikation.
    // Hält die Liste aller Personen und stellt den Formularen alle
    // Funktionen bereit: Erfassen, Mutieren, Löschen, Aktivieren/
    // Deaktivieren, Suchen und die automatische Mitarbeiternummer.
    // Nach jeder Änderung wird automatisch gespeichert.
    public class Kontaktverwaltung
    {
        // Zentrale Liste mit allen Personen. Dank der Vererbung können
        // Kunden, Mitarbeiter und Lernende zusammen in einer Liste vom
        // Basistyp Person verwaltet werden.
        private List<Person> personen;

        // Zuständig für das Speichern und Laden auf die Festplatte
        private Datenspeicher datenspeicher;

        // Konstruktor: lädt beim Programmstart automatisch alle Daten
        public Kontaktverwaltung()
        {
            datenspeicher = new Datenspeicher();
            personen = datenspeicher.Laden();
        }

        // Liste aller verwalteten Personen
        public List<Person> AllePersonen
        {
            get { return personen; }
        }

        // Fügt eine neue Person hinzu. Mitarbeiter und Lernende bekommen
        // automatisch die nächste freie Mitarbeiternummer.
        public void Hinzufuegen(Person person)
        {
            MitarbeiternummerVergeben(person);
            personen.Add(person);
            Speichern();
        }

        // Ersetzt eine bestehende Person durch die bearbeitete Version
        // (Mutieren). Die Position in der Liste bleibt gleich.
        // Nötig, weil beim Bearbeiten auch der Typ wechseln kann
        // (z.B. ein Mitarbeiter wird zum Lernenden).
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

        // Löscht eine Person definitiv aus dem Datenstamm
        public void Loeschen(Person person)
        {
            personen.Remove(person);
            Speichern();
        }

        // Schaltet den Status um: aus aktiv wird passiv und umgekehrt
        public void AktivUmschalten(Person person)
        {
            person.Aktiv = !person.Aktiv;
            Speichern();
        }

        // Ermittelt die nächste freie Mitarbeiternummer.
        // Die erste Nummer ist 1000, danach immer höchste Nummer + 1.
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

        // Durchsucht den Datenstamm nach den übergebenen Kriterien.
        // Alle Kriterien sind kombinierbar, leere Kriterien werden
        // ignoriert. Die Namenssuche findet auch Teiltreffer und
        // ignoriert Gross-/Kleinschreibung.
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

            return resultate;
        }

        // Speichert den aktuellen Datenstamm. Wird von aussen aufgerufen,
        // wenn eine Person direkt verändert wurde.
        public void AenderungenSpeichern()
        {
            Speichern();
        }

        // Vergibt einem Mitarbeiter oder Lernenden die nächste freie
        // Nummer, falls er noch keine hat (Wert 0). Bei Kunden passiert nichts.
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

        // Speichert alle Personen über den Datenspeicher auf die
        // Festplatte (automatisches Speichern nach jeder Änderung)
        private void Speichern()
        {
            datenspeicher.Speichern(personen);
        }
    }
}
