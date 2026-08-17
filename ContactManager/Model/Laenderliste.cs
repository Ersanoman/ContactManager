namespace ContactManager.Model
{
    // Stellt die Liste aller Länder für das Nationalitäts-Dropdown bereit.
    // Statische Klasse: es muss kein Objekt erzeugt werden, um die Liste
    // zu holen (wie bei der Klasse Math aus dem Unterricht).
    public static class Laenderliste
    {
        // Gibt alle Länder der Welt in alphabetischer Reihenfolge zurück
        // (deutsche Namen, Schweizer Schreibweise)
        public static string[] Alle()
        {
            return new string[]
            {
                "Afghanistan", "Ägypten", "Albanien", "Algerien", "Andorra",
                "Angola", "Antigua und Barbuda", "Äquatorialguinea", "Argentinien",
                "Armenien", "Aserbaidschan", "Äthiopien", "Australien", "Bahamas",
                "Bahrain", "Bangladesch", "Barbados", "Belarus", "Belgien",
                "Belize", "Benin", "Bhutan", "Bolivien", "Bosnien und Herzegowina",
                "Botswana", "Brasilien", "Brunei", "Bulgarien", "Burkina Faso",
                "Burundi", "Chile", "China", "Costa Rica", "Dänemark",
                "Deutschland", "Dominica", "Dominikanische Republik", "Dschibuti",
                "Ecuador", "El Salvador", "Elfenbeinküste", "Eritrea", "Estland",
                "Eswatini", "Fidschi", "Finnland", "Frankreich", "Gabun",
                "Gambia", "Georgien", "Ghana", "Grenada", "Griechenland",
                "Grossbritannien", "Guatemala", "Guinea", "Guinea-Bissau",
                "Guyana", "Haiti", "Honduras", "Indien", "Indonesien", "Irak",
                "Iran", "Irland", "Island", "Israel", "Italien", "Jamaika",
                "Japan", "Jemen", "Jordanien", "Kambodscha", "Kamerun", "Kanada",
                "Kap Verde", "Kasachstan", "Katar", "Kenia", "Kirgisistan",
                "Kiribati", "Kolumbien", "Komoren", "Kongo (Demokratische Republik)",
                "Kongo (Republik)", "Kosovo", "Kroatien", "Kuba", "Kuwait",
                "Laos", "Lesotho", "Lettland", "Libanon", "Liberia", "Libyen",
                "Liechtenstein", "Litauen", "Luxemburg", "Madagaskar", "Malawi",
                "Malaysia", "Malediven", "Mali", "Malta", "Marokko",
                "Marshallinseln", "Mauretanien", "Mauritius", "Mexiko",
                "Mikronesien", "Moldova", "Monaco", "Mongolei", "Montenegro",
                "Mosambik", "Myanmar", "Namibia", "Nauru", "Nepal", "Neuseeland",
                "Nicaragua", "Niederlande", "Niger", "Nigeria", "Nordkorea",
                "Nordmazedonien", "Norwegen", "Oman", "Österreich", "Osttimor",
                "Pakistan", "Palau", "Panama", "Papua-Neuguinea", "Paraguay",
                "Peru", "Philippinen", "Polen", "Portugal", "Ruanda", "Rumänien",
                "Russland", "Salomonen", "Sambia", "Samoa", "San Marino",
                "São Tomé und Príncipe", "Saudi-Arabien", "Schweden", "Schweiz",
                "Senegal", "Serbien", "Seychellen", "Sierra Leone", "Simbabwe",
                "Singapur", "Slowakei", "Slowenien", "Somalia", "Spanien",
                "Sri Lanka", "St. Kitts und Nevis", "St. Lucia",
                "St. Vincent und die Grenadinen", "Südafrika", "Sudan",
                "Südkorea", "Südsudan", "Suriname", "Syrien", "Tadschikistan",
                "Tansania", "Thailand", "Togo", "Tonga", "Trinidad und Tobago",
                "Tschad", "Tschechien", "Tunesien", "Türkei", "Turkmenistan",
                "Tuvalu", "Uganda", "Ukraine", "Ungarn", "Uruguay", "USA",
                "Usbekistan", "Vanuatu", "Vatikanstadt", "Venezuela",
                "Vereinigte Arabische Emirate", "Vietnam",
                "Zentralafrikanische Republik", "Zypern"
            };
        }
    }
}
