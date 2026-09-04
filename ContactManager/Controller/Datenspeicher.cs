using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ContactManager.Model;

namespace ContactManager.Controller
{
    /// <summary>
    /// Zuständig für das Speichern und Laden des gesamten Datenstamms
    /// auf die Festplatte. Die Daten werden per XML-Serialisierung in
    /// eine Datei geschrieben und von dort wieder als Objekte eingelesen.
    /// </summary>
    public class Datenspeicher
    {
        /// <summary>
        /// Vollständiger Pfad zur XML-Datei mit dem Datenstamm
        /// </summary>
        private string dateipfad;

        /// <summary>
        /// Meldung des letzten Fehlers beim Speichern oder Laden.
        /// Ist der Text leer, ist alles gut gegangen. Der Datenspeicher
        /// zeigt selber keine Meldung an, denn das ist Aufgabe der
        /// Fenster (Trennung von Logik und Anzeige).
        /// </summary>
        public string LetzterFehler { get; private set; }

        /// <summary>
        /// Konstruktor: die Datei "kontaktdaten.xml" liegt im gleichen
        /// Ordner wie die Programmdatei (.exe)
        /// </summary>
        public Datenspeicher()
        {
            dateipfad = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "kontaktdaten.xml");
            LetzterFehler = "";
        }

        /// <summary>
        /// Konstruktor mit eigenem Dateipfad (Konstruktor-Überladung).
        /// Damit lässt sich der Datenstamm auch aus einer anderen Datei
        /// lesen, zum Beispiel beim Testen.
        /// </summary>
        /// <param name="eigenerDateipfad">Vollständiger Pfad zur XML-Datei</param>
        public Datenspeicher(string eigenerDateipfad)
        {
            dateipfad = eigenerDateipfad;
            LetzterFehler = "";
        }

        /// <summary>
        /// Speichert alle Personen als XML-Datei auf die Festplatte.
        /// Dank der XmlInclude-Attribute auf der Klasse Person werden auch
        /// Kunden, Mitarbeiter und Lernende korrekt gespeichert.
        /// Fehler werden abgefangen, damit das Programm nicht abstürzt.
        /// </summary>
        /// <param name="personen">Liste aller zu speichernden Personen</param>
        public void Speichern(List<Person> personen)
        {
            LetzterFehler = "";

            try
            {
                XmlSerializer serialisierer = new XmlSerializer(typeof(List<Person>));

                // using schliesst die Datei am Schluss automatisch wieder
                using (StreamWriter schreiber = new StreamWriter(dateipfad))
                {
                    serialisierer.Serialize(schreiber, personen);
                }
            }
            catch (Exception ex)
            {
                LetzterFehler = "Die Daten konnten nicht gespeichert werden:\n" + ex.Message;
            }
        }

        /// <summary>
        /// Lädt alle Personen aus der XML-Datei von der Festplatte.
        /// Gibt es noch keine Datei (erster Start) oder ist sie kaputt,
        /// wird eine leere Liste zurückgegeben, damit das Programm
        /// trotzdem starten kann.
        /// </summary>
        /// <returns>Liste aller geladenen Personen (nie null)</returns>
        public List<Person> Laden()
        {
            LetzterFehler = "";

            // Beim allerersten Programmstart existiert noch keine Datei
            if (!File.Exists(dateipfad))
            {
                return new List<Person>();
            }

            try
            {
                XmlSerializer serialisierer = new XmlSerializer(typeof(List<Person>));

                // using schliesst die Datei am Schluss automatisch wieder
                using (StreamReader leser = new StreamReader(dateipfad))
                {
                    return (List<Person>)serialisierer.Deserialize(leser);
                }
            }
            catch (Exception ex)
            {
                LetzterFehler = "Die Datendatei konnte nicht gelesen werden:\n" + ex.Message +
                                "\n\nDas Programm startet mit einem leeren Datenstamm.";
                return new List<Person>();
            }
        }
    }
}
