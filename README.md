Semesterprojekt Contact Manager
Programming Foundation II
Version 1.0 (Abgabeversion)

Gruppenmitglieder:
------------------
- Nando Ramsauer (Teamleiter)
- Ersan Krizevac

Was funktioniert:
-----------------
- Erfassen, Bearbeiten (Mutieren) und Löschen von Kunden, Mitarbeitern
  und Lernenden
- Aktivieren und Deaktivieren von Personen (Status aktiv/passiv)
- Automatische Vergabe der Mitarbeiternummern ab 1000
- Notizen zu Kundenkontakten mit Zeitstempel (Kontakthistorie);
  ein Doppelklick zeigt die ganze Notiz in einem eigenen Fenster
- Suche nach Nachname, Vorname, Geburtsdatum und Kategorie, auch
  kombinierbar; der Filter bleibt nach dem Bearbeiten aktiv
- Liste alphabetisch nach Nachname sortiert (selbst geschriebener
  Bubblesort in der Kontaktverwaltung)
- Bedienung ohne Maus: mit Tab durch die Felder, mit den Pfeiltasten
  durch die Liste, Enter öffnet den markierten Eintrag, Entf löscht
  ihn (mit Nachfrage), alle Schaltflächen haben ein Alt-Kürzel
- Eingabevalidierung: Pflichtfelder sind mit * markiert, Telefon nur
  Ziffern, keine Zahlen in Namen, E-Mail-Format, AHV-Nummer
  756.XXXX.XXXX.XX und nur einmal vergeben, Postleitzahl 1000-9999,
  Geburtsdatum nicht in der Zukunft und nicht vor 1900, Austritt nicht
  vor Eintritt, aktuelles Lehrjahr nicht grösser als die Lehrdauer
- Nationalität als Dropdown mit allen Ländern, freie Eingabe bleibt
  möglich (z.B. für Doppelbürger)
- Warnung bei möglicher Doppelerfassung (gleicher Name und gleiches
  Geburtsdatum)
- Automatisches Speichern nach jeder Änderung und automatisches Laden
  beim Programmstart (XML-Datei "kontaktdaten.xml"). Schlägt das
  Speichern fehl, erscheint sofort eine Meldung.

Zusätzlich umgesetzte optionale Anforderungen:
----------------------------------------------
- Dashboard mit Kennzahlen zum Datenstamm und einem selbst
  gezeichneten Kreisdiagramm inkl. Legende und Prozentangaben
- CSV-Import für Kunden, Mitarbeiter und Lernende. Fehlerhafte Zeilen
  werden mit Zeilennummer gemeldet und übersprungen, bereits
  vorhandene Personen werden nicht doppelt importiert.
  Beigelegte Beispieldateien:
  * "Beispiel-Kontakte.csv" -> 11 importiert, 0 Fehler
  * "Beispiel-Kontakte-mit-Fehlern.csv" -> 2 importiert,
    1 übersprungen, 5 fehlerhafte Zeilen

Was nicht funktioniert / bewusste Einschränkungen:
---------------------------------------------------
- Es gibt keinen Login und keine Mutationshistorie
- Ein Export ist nicht vorgesehen (in der Aufgabenstellung auch nicht
  verlangt; die Daten stehen als lesbare XML-Datei bereit)
- Läuft das Programm zweimal gleichzeitig, überschreibt die zuletzt
  geschlossene Instanz die Datei der anderen

Überlegungen und bewusste Entscheide:
--------------------------------------
- Lernender erbt von Mitarbeiter und nicht direkt von Person. Ein
  Lernender hat nämlich alle Mitarbeiterdaten und zusätzlich die
  Lehrjahre. Darum heisst der Filter auch "Mitarbeiter (inkl.
  Lernende)" - sonst hätten wir Lernende beim Suchen verloren.
- Alle Prüfregeln liegen in einer eigenen statischen Klasse Pruefung
  statt in den Formularen. So gelten beim CSV-Import genau dieselben
  Regeln wie bei der Eingabe von Hand, und wir mussten sie nur
  einmal schreiben.
- Der Controller kennt kein Windows Forms. Meldungen zeigen immer die
  Fenster an. Dadurch ist die Logik von der Oberfläche getrennt und
  könnte auch ohne die Formulare geprüft werden.
- Beim Speichern schreiben wir zuerst in eine Hilfsdatei und ersetzen
  erst danach die richtige Datei. Würden wir direkt schreiben, wären
  bei einem Abbruch mittendrin alle bisherigen Daten weg.
- Eine doppelte Person wird nur gemeldet, nicht verboten: zwei
  Menschen können gleich heissen und am gleichen Tag Geburtstag
  haben. Die AHV-Nummer dagegen ist wirklich eindeutig, sie wird
  darum hart zurückgewiesen.
- Sortiert wird mit einem selbst geschriebenen Bubblesort statt mit
  einer fertigen Methode, weil das Sortierverfahren Unterrichtsstoff
  ist und wir zeigen wollten, dass wir es verstanden haben.
- Gespeichert wird per XML-Serialisierung statt in einer Datenbank.
  Das entspricht dem Unterrichtsstoff und die Datei lässt sich mit
  einem Texteditor kontrollieren.

Zusatzinformationen:
--------------------
- Kein Login notwendig
- Die Daten werden in der Datei "kontaktdaten.xml" im gleichen Ordner
  wie die ContactManager.exe gespeichert (bin\Debug bzw. bin\Release)
- Architektur: Model-View-Controller mit der Vererbungshierarchie
  Person -> Kunde und Person -> Mitarbeiter -> Lernender
  * Model:      Person, Kunde, Mitarbeiter, Lernender, Kontakteintrag,
                die Enumerationen Anrede und Geschlecht, Länderliste
  * Controller: Kontaktverwaltung, Datenspeicher, CsvImporter, Pruefung
  * View:       HauptForm, KundeForm, MitarbeiterForm, DashboardForm
- Aufbau einer CSV-Zeile (Trennzeichen ist der Strichpunkt): siehe die
  Überschriftszeile in den Beispieldateien. Erlaubte Werte für "Typ"
  sind Kunde, Mitarbeiter oder Lernender. Bei Kunden dürfen die
  Spalten ab "Abteilung" weggelassen werden, bei Mitarbeitern die
  beiden letzten Spalten zu den Lehrjahren.
