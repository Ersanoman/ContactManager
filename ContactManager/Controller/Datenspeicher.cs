using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using ContactManager.Model;

namespace ContactManager.Controller
{
    // Zuständig für das Speichern und Laden des gesamten Datenstamms
    // auf die Festplatte. Die Daten werden per XML-Serialisierung in
    // eine Datei geschrieben und von dort wieder als Objekte eingelesen.
    public class Datenspeicher
    {
        // Vollständiger Pfad zur XML-Datei mit dem Datenstamm
        private string dateipfad;

        // Konstruktor: die Datei "kontaktdaten.xml" liegt im gleichen
        // Ordner wie die Programmdatei (.exe)
        public Datenspeicher()
        {
            dateipfad = Path.Combine(Application.StartupPath, "kontaktdaten.xml");
        }

        // Pfad der XML-Datei (nur lesbar)
        public string Dateipfad
        {
            get { return dateipfad; }
        }

        // Speichert alle Personen als XML-Datei auf die Festplatte.
        // Dank der XmlInclude-Attribute auf der Klasse Person werden auch
        // Kunden, Mitarbeiter und Lernende korrekt gespeichert.
        // Fehler werden abgefangen, damit das Programm nicht abstürzt.
        public void Speichern(List<Person> personen)
        {
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
                MessageBox.Show(
                    "Die Daten konnten nicht gespeichert werden:\n" + ex.Message,
                    "Fehler beim Speichern",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Lädt alle Personen aus der XML-Datei von der Festplatte.
        // Gibt es noch keine Datei (erster Start) oder ist sie kaputt,
        // wird eine leere Liste zurückgegeben, damit das Programm
        // trotzdem starten kann.
        public List<Person> Laden()
        {
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
                MessageBox.Show(
                    "Die Datendatei konnte nicht gelesen werden:\n" + ex.Message +
                    "\n\nDas Programm startet mit einem leeren Datenstamm.",
                    "Fehler beim Laden",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return new List<Person>();
            }
        }
    }
}
