namespace ContactManager.View
{
    partial class HauptForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.PnlKopf = new System.Windows.Forms.Panel();
            this.LblTitel = new System.Windows.Forms.Label();
            this.LblUntertitel = new System.Windows.Forms.Label();
            this.PnlSuche = new System.Windows.Forms.Panel();
            this.LblSucheTitel = new System.Windows.Forms.Label();
            this.LblNachname = new System.Windows.Forms.Label();
            this.TxtNachname = new System.Windows.Forms.TextBox();
            this.LblVorname = new System.Windows.Forms.Label();
            this.TxtVorname = new System.Windows.Forms.TextBox();
            this.ChkGeburtsdatum = new System.Windows.Forms.CheckBox();
            this.DtpGeburtsdatum = new System.Windows.Forms.DateTimePicker();
            this.LblKategorie = new System.Windows.Forms.Label();
            this.CmbKategorie = new System.Windows.Forms.ComboBox();
            this.CmdSuchen = new System.Windows.Forms.Button();
            this.CmdAlleAnzeigen = new System.Windows.Forms.Button();
            this.LblListe = new System.Windows.Forms.Label();
            this.LstPersonen = new System.Windows.Forms.ListBox();
            this.LblGruppeNeu = new System.Windows.Forms.Label();
            this.CmdNeuerKunde = new System.Windows.Forms.Button();
            this.CmdNeuerMitarbeiter = new System.Windows.Forms.Button();
            this.LblGruppeAktion = new System.Windows.Forms.Label();
            this.CmdBearbeiten = new System.Windows.Forms.Button();
            this.CmdAktivPassiv = new System.Windows.Forms.Button();
            this.CmdLoeschen = new System.Windows.Forms.Button();
            this.LblGruppeWerkzeuge = new System.Windows.Forms.Label();
            this.CmdDashboard = new System.Windows.Forms.Button();
            this.CmdCsvImport = new System.Windows.Forms.Button();
            this.PnlStatus = new System.Windows.Forms.Panel();
            this.LblStatus = new System.Windows.Forms.Label();
            this.PnlKopf.SuspendLayout();
            this.PnlSuche.SuspendLayout();
            this.PnlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlKopf
            // 
            this.PnlKopf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlKopf.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.PnlKopf.Controls.Add(this.LblTitel);
            this.PnlKopf.Controls.Add(this.LblUntertitel);
            this.PnlKopf.Location = new System.Drawing.Point(0, 0);
            this.PnlKopf.Name = "PnlKopf";
            this.PnlKopf.Size = new System.Drawing.Size(1044, 64);
            this.PnlKopf.TabIndex = 0;
            // 
            // LblTitel
            // 
            this.LblTitel.AutoSize = true;
            this.LblTitel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.LblTitel.ForeColor = System.Drawing.Color.White;
            this.LblTitel.Location = new System.Drawing.Point(20, 6);
            this.LblTitel.Name = "LblTitel";
            this.LblTitel.Size = new System.Drawing.Size(163, 30);
            this.LblTitel.TabIndex = 0;
            this.LblTitel.Text = "Contact Manager";
            // 
            // LblUntertitel
            // 
            this.LblUntertitel.AutoSize = true;
            this.LblUntertitel.ForeColor = System.Drawing.Color.FromArgb(168, 196, 220);
            this.LblUntertitel.Location = new System.Drawing.Point(23, 42);
            this.LblUntertitel.Name = "LblUntertitel";
            this.LblUntertitel.Size = new System.Drawing.Size(190, 15);
            this.LblUntertitel.TabIndex = 1;
            this.LblUntertitel.Text = "Kunden- und Mitarbeiterverwaltung";
            // 
            // PnlSuche
            // 
            this.PnlSuche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlSuche.BackColor = System.Drawing.Color.White;
            this.PnlSuche.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlSuche.Controls.Add(this.LblSucheTitel);
            this.PnlSuche.Controls.Add(this.LblNachname);
            this.PnlSuche.Controls.Add(this.TxtNachname);
            this.PnlSuche.Controls.Add(this.LblVorname);
            this.PnlSuche.Controls.Add(this.TxtVorname);
            this.PnlSuche.Controls.Add(this.ChkGeburtsdatum);
            this.PnlSuche.Controls.Add(this.DtpGeburtsdatum);
            this.PnlSuche.Controls.Add(this.LblKategorie);
            this.PnlSuche.Controls.Add(this.CmbKategorie);
            this.PnlSuche.Controls.Add(this.CmdSuchen);
            this.PnlSuche.Controls.Add(this.CmdAlleAnzeigen);
            this.PnlSuche.Location = new System.Drawing.Point(16, 80);
            this.PnlSuche.Name = "PnlSuche";
            this.PnlSuche.Size = new System.Drawing.Size(736, 124);
            this.PnlSuche.TabIndex = 1;
            // 
            // LblSucheTitel
            // 
            this.LblSucheTitel.AutoSize = true;
            this.LblSucheTitel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LblSucheTitel.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.LblSucheTitel.Location = new System.Drawing.Point(14, 10);
            this.LblSucheTitel.Name = "LblSucheTitel";
            this.LblSucheTitel.Size = new System.Drawing.Size(48, 19);
            this.LblSucheTitel.TabIndex = 0;
            this.LblSucheTitel.Text = "Suche";
            // 
            // LblNachname
            // 
            this.LblNachname.AutoSize = true;
            this.LblNachname.Location = new System.Drawing.Point(16, 43);
            this.LblNachname.Name = "LblNachname";
            this.LblNachname.Size = new System.Drawing.Size(68, 15);
            this.LblNachname.TabIndex = 1;
            this.LblNachname.Text = "Nachname:";
            // 
            // TxtNachname
            // 
            this.TxtNachname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNachname.Location = new System.Drawing.Point(110, 40);
            this.TxtNachname.Name = "TxtNachname";
            this.TxtNachname.Size = new System.Drawing.Size(180, 23);
            this.TxtNachname.TabIndex = 2;
            // 
            // LblVorname
            // 
            this.LblVorname.AutoSize = true;
            this.LblVorname.Location = new System.Drawing.Point(16, 77);
            this.LblVorname.Name = "LblVorname";
            this.LblVorname.Size = new System.Drawing.Size(58, 15);
            this.LblVorname.TabIndex = 3;
            this.LblVorname.Text = "Vorname:";
            // 
            // TxtVorname
            // 
            this.TxtVorname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtVorname.Location = new System.Drawing.Point(110, 74);
            this.TxtVorname.Name = "TxtVorname";
            this.TxtVorname.Size = new System.Drawing.Size(180, 23);
            this.TxtVorname.TabIndex = 4;
            // 
            // ChkGeburtsdatum
            // 
            this.ChkGeburtsdatum.AutoSize = true;
            this.ChkGeburtsdatum.Location = new System.Drawing.Point(300, 43);
            this.ChkGeburtsdatum.Name = "ChkGeburtsdatum";
            this.ChkGeburtsdatum.Size = new System.Drawing.Size(107, 19);
            this.ChkGeburtsdatum.TabIndex = 5;
            this.ChkGeburtsdatum.Text = "Geburtsdatum:";
            this.ChkGeburtsdatum.UseVisualStyleBackColor = true;
            this.ChkGeburtsdatum.CheckedChanged += new System.EventHandler(this.ChkGeburtsdatum_CheckedChanged);
            // 
            // DtpGeburtsdatum
            // 
            this.DtpGeburtsdatum.Enabled = false;
            this.DtpGeburtsdatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpGeburtsdatum.Location = new System.Drawing.Point(442, 40);
            this.DtpGeburtsdatum.Name = "DtpGeburtsdatum";
            this.DtpGeburtsdatum.Size = new System.Drawing.Size(130, 23);
            this.DtpGeburtsdatum.TabIndex = 6;
            // 
            // LblKategorie
            // 
            this.LblKategorie.AutoSize = true;
            this.LblKategorie.Location = new System.Drawing.Point(300, 77);
            this.LblKategorie.Name = "LblKategorie";
            this.LblKategorie.Size = new System.Drawing.Size(60, 15);
            this.LblKategorie.TabIndex = 7;
            this.LblKategorie.Text = "Kategorie:";
            // 
            // CmbKategorie
            // 
            this.CmbKategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbKategorie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbKategorie.FormattingEnabled = true;
            this.CmbKategorie.Location = new System.Drawing.Point(442, 74);
            this.CmbKategorie.Name = "CmbKategorie";
            this.CmbKategorie.Size = new System.Drawing.Size(130, 23);
            this.CmbKategorie.TabIndex = 8;
            // 
            // CmdSuchen
            // 
            this.CmdSuchen.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.CmdSuchen.FlatAppearance.BorderSize = 0;
            this.CmdSuchen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(42, 100, 150);
            this.CmdSuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSuchen.ForeColor = System.Drawing.Color.White;
            this.CmdSuchen.Location = new System.Drawing.Point(590, 38);
            this.CmdSuchen.Name = "CmdSuchen";
            this.CmdSuchen.Size = new System.Drawing.Size(130, 30);
            this.CmdSuchen.TabIndex = 9;
            this.CmdSuchen.Text = "&Suchen";
            this.CmdSuchen.UseVisualStyleBackColor = false;
            this.CmdSuchen.Click += new System.EventHandler(this.CmdSuchen_Click);
            // 
            // CmdAlleAnzeigen
            // 
            this.CmdAlleAnzeigen.BackColor = System.Drawing.Color.White;
            this.CmdAlleAnzeigen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.CmdAlleAnzeigen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.CmdAlleAnzeigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdAlleAnzeigen.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.CmdAlleAnzeigen.Location = new System.Drawing.Point(590, 72);
            this.CmdAlleAnzeigen.Name = "CmdAlleAnzeigen";
            this.CmdAlleAnzeigen.Size = new System.Drawing.Size(130, 30);
            this.CmdAlleAnzeigen.TabIndex = 10;
            this.CmdAlleAnzeigen.Text = "Filter &zurücksetzen";
            this.CmdAlleAnzeigen.UseVisualStyleBackColor = false;
            this.CmdAlleAnzeigen.Click += new System.EventHandler(this.CmdAlleAnzeigen_Click);
            // 
            // LblListe
            // 
            this.LblListe.AutoSize = true;
            this.LblListe.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.LblListe.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.LblListe.Location = new System.Drawing.Point(16, 218);
            this.LblListe.Name = "LblListe";
            this.LblListe.Size = new System.Drawing.Size(122, 17);
            this.LblListe.TabIndex = 2;
            this.LblListe.Text = "Erfasste Personen";
            // 
            // LstPersonen
            // 
            this.LstPersonen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstPersonen.BackColor = System.Drawing.Color.White;
            this.LstPersonen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LstPersonen.FormattingEnabled = true;
            this.LstPersonen.HorizontalScrollbar = true;
            this.LstPersonen.IntegralHeight = false;
            this.LstPersonen.ItemHeight = 19;
            this.LstPersonen.Location = new System.Drawing.Point(16, 240);
            this.LstPersonen.Name = "LstPersonen";
            this.LstPersonen.Size = new System.Drawing.Size(736, 380);
            this.LstPersonen.TabIndex = 3;
            this.LstPersonen.DoubleClick += new System.EventHandler(this.LstPersonen_DoubleClick);
            // 
            // LblGruppeNeu
            // 
            this.LblGruppeNeu.AutoSize = true;
            this.LblGruppeNeu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblGruppeNeu.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.LblGruppeNeu.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.LblGruppeNeu.Location = new System.Drawing.Point(770, 84);
            this.LblGruppeNeu.Name = "LblGruppeNeu";
            this.LblGruppeNeu.Size = new System.Drawing.Size(88, 14);
            this.LblGruppeNeu.TabIndex = 4;
            this.LblGruppeNeu.Text = "NEU ERFASSEN";
            // 
            // CmdNeuerKunde
            // 
            this.CmdNeuerKunde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdNeuerKunde.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.CmdNeuerKunde.FlatAppearance.BorderSize = 0;
            this.CmdNeuerKunde.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(42, 100, 150);
            this.CmdNeuerKunde.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdNeuerKunde.ForeColor = System.Drawing.Color.White;
            this.CmdNeuerKunde.Location = new System.Drawing.Point(768, 104);
            this.CmdNeuerKunde.Name = "CmdNeuerKunde";
            this.CmdNeuerKunde.Size = new System.Drawing.Size(260, 40);
            this.CmdNeuerKunde.TabIndex = 5;
            this.CmdNeuerKunde.Text = "+   Neuer &Kunde";
            this.CmdNeuerKunde.UseVisualStyleBackColor = false;
            this.CmdNeuerKunde.Click += new System.EventHandler(this.CmdNeuerKunde_Click);
            // 
            // CmdNeuerMitarbeiter
            // 
            this.CmdNeuerMitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdNeuerMitarbeiter.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.CmdNeuerMitarbeiter.FlatAppearance.BorderSize = 0;
            this.CmdNeuerMitarbeiter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(42, 100, 150);
            this.CmdNeuerMitarbeiter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdNeuerMitarbeiter.ForeColor = System.Drawing.Color.White;
            this.CmdNeuerMitarbeiter.Location = new System.Drawing.Point(768, 150);
            this.CmdNeuerMitarbeiter.Name = "CmdNeuerMitarbeiter";
            this.CmdNeuerMitarbeiter.Size = new System.Drawing.Size(260, 40);
            this.CmdNeuerMitarbeiter.TabIndex = 6;
            this.CmdNeuerMitarbeiter.Text = "+   Neuer &Mitarbeiter";
            this.CmdNeuerMitarbeiter.UseVisualStyleBackColor = false;
            this.CmdNeuerMitarbeiter.Click += new System.EventHandler(this.CmdNeuerMitarbeiter_Click);
            // 
            // LblGruppeAktion
            // 
            this.LblGruppeAktion.AutoSize = true;
            this.LblGruppeAktion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblGruppeAktion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.LblGruppeAktion.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.LblGruppeAktion.Location = new System.Drawing.Point(770, 206);
            this.LblGruppeAktion.Name = "LblGruppeAktion";
            this.LblGruppeAktion.Size = new System.Drawing.Size(139, 14);
            this.LblGruppeAktion.TabIndex = 7;
            this.LblGruppeAktion.Text = "AUSGEWÄHLTE PERSON";
            // 
            // CmdBearbeiten
            // 
            this.CmdBearbeiten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdBearbeiten.BackColor = System.Drawing.Color.White;
            this.CmdBearbeiten.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.CmdBearbeiten.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.CmdBearbeiten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdBearbeiten.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.CmdBearbeiten.Location = new System.Drawing.Point(768, 226);
            this.CmdBearbeiten.Name = "CmdBearbeiten";
            this.CmdBearbeiten.Size = new System.Drawing.Size(260, 40);
            this.CmdBearbeiten.TabIndex = 8;
            this.CmdBearbeiten.Text = "&Bearbeiten";
            this.CmdBearbeiten.UseVisualStyleBackColor = false;
            this.CmdBearbeiten.Click += new System.EventHandler(this.CmdBearbeiten_Click);
            // 
            // CmdAktivPassiv
            // 
            this.CmdAktivPassiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdAktivPassiv.BackColor = System.Drawing.Color.White;
            this.CmdAktivPassiv.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.CmdAktivPassiv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.CmdAktivPassiv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdAktivPassiv.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.CmdAktivPassiv.Location = new System.Drawing.Point(768, 272);
            this.CmdAktivPassiv.Name = "CmdAktivPassiv";
            this.CmdAktivPassiv.Size = new System.Drawing.Size(260, 40);
            this.CmdAktivPassiv.TabIndex = 9;
            this.CmdAktivPassiv.Text = "&Aktivieren / Deaktivieren";
            this.CmdAktivPassiv.UseVisualStyleBackColor = false;
            this.CmdAktivPassiv.Click += new System.EventHandler(this.CmdAktivPassiv_Click);
            // 
            // CmdLoeschen
            // 
            this.CmdLoeschen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdLoeschen.BackColor = System.Drawing.Color.White;
            this.CmdLoeschen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(224, 180, 180);
            this.CmdLoeschen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(250, 235, 235);
            this.CmdLoeschen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdLoeschen.ForeColor = System.Drawing.Color.FromArgb(168, 45, 45);
            this.CmdLoeschen.Location = new System.Drawing.Point(768, 318);
            this.CmdLoeschen.Name = "CmdLoeschen";
            this.CmdLoeschen.Size = new System.Drawing.Size(260, 40);
            this.CmdLoeschen.TabIndex = 10;
            this.CmdLoeschen.Text = "&Löschen";
            this.CmdLoeschen.UseVisualStyleBackColor = false;
            this.CmdLoeschen.Click += new System.EventHandler(this.CmdLoeschen_Click);
            // 
            // LblGruppeWerkzeuge
            // 
            this.LblGruppeWerkzeuge.AutoSize = true;
            this.LblGruppeWerkzeuge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblGruppeWerkzeuge.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.LblGruppeWerkzeuge.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.LblGruppeWerkzeuge.Location = new System.Drawing.Point(770, 374);
            this.LblGruppeWerkzeuge.Name = "LblGruppeWerkzeuge";
            this.LblGruppeWerkzeuge.Size = new System.Drawing.Size(78, 14);
            this.LblGruppeWerkzeuge.TabIndex = 11;
            this.LblGruppeWerkzeuge.Text = "WERKZEUGE";
            // 
            // CmdDashboard
            // 
            this.CmdDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdDashboard.BackColor = System.Drawing.Color.White;
            this.CmdDashboard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.CmdDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.CmdDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdDashboard.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.CmdDashboard.Location = new System.Drawing.Point(768, 394);
            this.CmdDashboard.Name = "CmdDashboard";
            this.CmdDashboard.Size = new System.Drawing.Size(260, 40);
            this.CmdDashboard.TabIndex = 12;
            this.CmdDashboard.Text = "&Dashboard";
            this.CmdDashboard.UseVisualStyleBackColor = false;
            this.CmdDashboard.Click += new System.EventHandler(this.CmdDashboard_Click);
            // 
            // CmdCsvImport
            // 
            this.CmdCsvImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdCsvImport.BackColor = System.Drawing.Color.White;
            this.CmdCsvImport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.CmdCsvImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.CmdCsvImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdCsvImport.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.CmdCsvImport.Location = new System.Drawing.Point(768, 440);
            this.CmdCsvImport.Name = "CmdCsvImport";
            this.CmdCsvImport.Size = new System.Drawing.Size(260, 40);
            this.CmdCsvImport.TabIndex = 13;
            this.CmdCsvImport.Text = "Kontakte &importieren (CSV)";
            this.CmdCsvImport.UseVisualStyleBackColor = false;
            this.CmdCsvImport.Click += new System.EventHandler(this.CmdCsvImport_Click);
            // 
            // PnlStatus
            // 
            this.PnlStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlStatus.BackColor = System.Drawing.Color.FromArgb(228, 231, 235);
            this.PnlStatus.Controls.Add(this.LblStatus);
            this.PnlStatus.Location = new System.Drawing.Point(0, 632);
            this.PnlStatus.Name = "PnlStatus";
            this.PnlStatus.Size = new System.Drawing.Size(1044, 36);
            this.PnlStatus.TabIndex = 14;
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.ForeColor = System.Drawing.Color.FromArgb(68, 68, 68);
            this.LblStatus.Location = new System.Drawing.Point(18, 10);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(42, 15);
            this.LblStatus.TabIndex = 0;
            this.LblStatus.Text = "Status";
            // 
            // HauptForm
            // 
            this.AcceptButton = this.CmdSuchen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.ClientSize = new System.Drawing.Size(1044, 668);
            this.Controls.Add(this.PnlKopf);
            this.Controls.Add(this.PnlSuche);
            this.Controls.Add(this.LblListe);
            this.Controls.Add(this.LstPersonen);
            this.Controls.Add(this.LblGruppeNeu);
            this.Controls.Add(this.CmdNeuerKunde);
            this.Controls.Add(this.CmdNeuerMitarbeiter);
            this.Controls.Add(this.LblGruppeAktion);
            this.Controls.Add(this.CmdBearbeiten);
            this.Controls.Add(this.CmdAktivPassiv);
            this.Controls.Add(this.CmdLoeschen);
            this.Controls.Add(this.LblGruppeWerkzeuge);
            this.Controls.Add(this.CmdDashboard);
            this.Controls.Add(this.CmdCsvImport);
            this.Controls.Add(this.PnlStatus);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1060, 707);
            this.Name = "HauptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contact Manager";
            this.Load += new System.EventHandler(this.HauptForm_Load);
            this.PnlKopf.ResumeLayout(false);
            this.PnlKopf.PerformLayout();
            this.PnlSuche.ResumeLayout(false);
            this.PnlSuche.PerformLayout();
            this.PnlStatus.ResumeLayout(false);
            this.PnlStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel PnlKopf;
        private System.Windows.Forms.Label LblTitel;
        private System.Windows.Forms.Label LblUntertitel;
        private System.Windows.Forms.Panel PnlSuche;
        private System.Windows.Forms.Label LblSucheTitel;
        private System.Windows.Forms.Label LblNachname;
        private System.Windows.Forms.TextBox TxtNachname;
        private System.Windows.Forms.Label LblVorname;
        private System.Windows.Forms.TextBox TxtVorname;
        private System.Windows.Forms.CheckBox ChkGeburtsdatum;
        private System.Windows.Forms.DateTimePicker DtpGeburtsdatum;
        private System.Windows.Forms.Label LblKategorie;
        private System.Windows.Forms.ComboBox CmbKategorie;
        private System.Windows.Forms.Button CmdSuchen;
        private System.Windows.Forms.Button CmdAlleAnzeigen;
        private System.Windows.Forms.Label LblListe;
        private System.Windows.Forms.ListBox LstPersonen;
        private System.Windows.Forms.Label LblGruppeNeu;
        private System.Windows.Forms.Button CmdNeuerKunde;
        private System.Windows.Forms.Button CmdNeuerMitarbeiter;
        private System.Windows.Forms.Label LblGruppeAktion;
        private System.Windows.Forms.Button CmdBearbeiten;
        private System.Windows.Forms.Button CmdAktivPassiv;
        private System.Windows.Forms.Button CmdLoeschen;
        private System.Windows.Forms.Label LblGruppeWerkzeuge;
        private System.Windows.Forms.Button CmdDashboard;
        private System.Windows.Forms.Button CmdCsvImport;
        private System.Windows.Forms.Panel PnlStatus;
        private System.Windows.Forms.Label LblStatus;
    }
}
