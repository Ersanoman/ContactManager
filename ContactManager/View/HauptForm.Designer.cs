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
            this.GrpSuche = new System.Windows.Forms.GroupBox();
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
            this.LstPersonen = new System.Windows.Forms.ListBox();
            this.CmdNeuerKunde = new System.Windows.Forms.Button();
            this.CmdNeuerMitarbeiter = new System.Windows.Forms.Button();
            this.CmdBearbeiten = new System.Windows.Forms.Button();
            this.CmdAktivPassiv = new System.Windows.Forms.Button();
            this.CmdLoeschen = new System.Windows.Forms.Button();
            this.LblStatus = new System.Windows.Forms.Label();
            this.CmdDashboard = new System.Windows.Forms.Button();
            this.CmdCsvImport = new System.Windows.Forms.Button();
            this.GrpSuche.SuspendLayout();
            this.SuspendLayout();
            //
            // GrpSuche
            //
            this.GrpSuche.Controls.Add(this.LblNachname);
            this.GrpSuche.Controls.Add(this.TxtNachname);
            this.GrpSuche.Controls.Add(this.LblVorname);
            this.GrpSuche.Controls.Add(this.TxtVorname);
            this.GrpSuche.Controls.Add(this.ChkGeburtsdatum);
            this.GrpSuche.Controls.Add(this.DtpGeburtsdatum);
            this.GrpSuche.Controls.Add(this.LblKategorie);
            this.GrpSuche.Controls.Add(this.CmbKategorie);
            this.GrpSuche.Controls.Add(this.CmdSuchen);
            this.GrpSuche.Controls.Add(this.CmdAlleAnzeigen);
            this.GrpSuche.Location = new System.Drawing.Point(12, 12);
            this.GrpSuche.Name = "GrpSuche";
            this.GrpSuche.Size = new System.Drawing.Size(656, 112);
            this.GrpSuche.TabIndex = 0;
            this.GrpSuche.TabStop = false;
            this.GrpSuche.Text = "Suche";
            //
            // LblNachname
            //
            this.LblNachname.AutoSize = true;
            this.LblNachname.Location = new System.Drawing.Point(16, 30);
            this.LblNachname.Name = "LblNachname";
            this.LblNachname.Size = new System.Drawing.Size(61, 13);
            this.LblNachname.TabIndex = 0;
            this.LblNachname.Text = "Nachname:";
            //
            // TxtNachname
            //
            this.TxtNachname.Location = new System.Drawing.Point(115, 27);
            this.TxtNachname.Name = "TxtNachname";
            this.TxtNachname.Size = new System.Drawing.Size(160, 20);
            this.TxtNachname.TabIndex = 1;
            //
            // LblVorname
            //
            this.LblVorname.AutoSize = true;
            this.LblVorname.Location = new System.Drawing.Point(16, 62);
            this.LblVorname.Name = "LblVorname";
            this.LblVorname.Size = new System.Drawing.Size(52, 13);
            this.LblVorname.TabIndex = 2;
            this.LblVorname.Text = "Vorname:";
            //
            // TxtVorname
            //
            this.TxtVorname.Location = new System.Drawing.Point(115, 59);
            this.TxtVorname.Name = "TxtVorname";
            this.TxtVorname.Size = new System.Drawing.Size(160, 20);
            this.TxtVorname.TabIndex = 3;
            //
            // ChkGeburtsdatum
            //
            this.ChkGeburtsdatum.AutoSize = true;
            this.ChkGeburtsdatum.Location = new System.Drawing.Point(300, 29);
            this.ChkGeburtsdatum.Name = "ChkGeburtsdatum";
            this.ChkGeburtsdatum.Size = new System.Drawing.Size(97, 17);
            this.ChkGeburtsdatum.TabIndex = 4;
            this.ChkGeburtsdatum.Text = "Geburtsdatum:";
            this.ChkGeburtsdatum.UseVisualStyleBackColor = true;
            this.ChkGeburtsdatum.CheckedChanged += new System.EventHandler(this.ChkGeburtsdatum_CheckedChanged);
            //
            // DtpGeburtsdatum
            //
            this.DtpGeburtsdatum.Enabled = false;
            this.DtpGeburtsdatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpGeburtsdatum.Location = new System.Drawing.Point(410, 27);
            this.DtpGeburtsdatum.Name = "DtpGeburtsdatum";
            this.DtpGeburtsdatum.Size = new System.Drawing.Size(110, 20);
            this.DtpGeburtsdatum.TabIndex = 5;
            //
            // LblKategorie
            //
            this.LblKategorie.AutoSize = true;
            this.LblKategorie.Location = new System.Drawing.Point(300, 62);
            this.LblKategorie.Name = "LblKategorie";
            this.LblKategorie.Size = new System.Drawing.Size(54, 13);
            this.LblKategorie.TabIndex = 6;
            this.LblKategorie.Text = "Kategorie:";
            //
            // CmbKategorie
            //
            this.CmbKategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbKategorie.FormattingEnabled = true;
            this.CmbKategorie.Location = new System.Drawing.Point(410, 59);
            this.CmbKategorie.Name = "CmbKategorie";
            this.CmbKategorie.Size = new System.Drawing.Size(110, 21);
            this.CmbKategorie.TabIndex = 7;
            //
            // CmdSuchen
            //
            this.CmdSuchen.Location = new System.Drawing.Point(545, 25);
            this.CmdSuchen.Name = "CmdSuchen";
            this.CmdSuchen.Size = new System.Drawing.Size(95, 30);
            this.CmdSuchen.TabIndex = 8;
            this.CmdSuchen.Text = "Suchen";
            this.CmdSuchen.UseVisualStyleBackColor = true;
            this.CmdSuchen.Click += new System.EventHandler(this.CmdSuchen_Click);
            //
            // CmdAlleAnzeigen
            //
            this.CmdAlleAnzeigen.Location = new System.Drawing.Point(545, 61);
            this.CmdAlleAnzeigen.Name = "CmdAlleAnzeigen";
            this.CmdAlleAnzeigen.Size = new System.Drawing.Size(95, 30);
            this.CmdAlleAnzeigen.TabIndex = 9;
            this.CmdAlleAnzeigen.Text = "Alle anzeigen";
            this.CmdAlleAnzeigen.UseVisualStyleBackColor = true;
            this.CmdAlleAnzeigen.Click += new System.EventHandler(this.CmdAlleAnzeigen_Click);
            //
            // LstPersonen
            //
            this.LstPersonen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstPersonen.FormattingEnabled = true;
            this.LstPersonen.HorizontalScrollbar = true;
            this.LstPersonen.Location = new System.Drawing.Point(12, 140);
            this.LstPersonen.Name = "LstPersonen";
            this.LstPersonen.Size = new System.Drawing.Size(656, 394);
            this.LstPersonen.TabIndex = 1;
            this.LstPersonen.DoubleClick += new System.EventHandler(this.LstPersonen_DoubleClick);
            //
            // CmdNeuerKunde
            //
            this.CmdNeuerKunde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdNeuerKunde.Location = new System.Drawing.Point(684, 12);
            this.CmdNeuerKunde.Name = "CmdNeuerKunde";
            this.CmdNeuerKunde.Size = new System.Drawing.Size(164, 34);
            this.CmdNeuerKunde.TabIndex = 2;
            this.CmdNeuerKunde.Text = "Neuer Kunde";
            this.CmdNeuerKunde.UseVisualStyleBackColor = true;
            this.CmdNeuerKunde.Click += new System.EventHandler(this.CmdNeuerKunde_Click);
            //
            // CmdNeuerMitarbeiter
            //
            this.CmdNeuerMitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdNeuerMitarbeiter.Location = new System.Drawing.Point(684, 52);
            this.CmdNeuerMitarbeiter.Name = "CmdNeuerMitarbeiter";
            this.CmdNeuerMitarbeiter.Size = new System.Drawing.Size(164, 34);
            this.CmdNeuerMitarbeiter.TabIndex = 3;
            this.CmdNeuerMitarbeiter.Text = "Neuer Mitarbeiter";
            this.CmdNeuerMitarbeiter.UseVisualStyleBackColor = true;
            this.CmdNeuerMitarbeiter.Click += new System.EventHandler(this.CmdNeuerMitarbeiter_Click);
            //
            // CmdBearbeiten
            //
            this.CmdBearbeiten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdBearbeiten.Location = new System.Drawing.Point(684, 104);
            this.CmdBearbeiten.Name = "CmdBearbeiten";
            this.CmdBearbeiten.Size = new System.Drawing.Size(164, 34);
            this.CmdBearbeiten.TabIndex = 4;
            this.CmdBearbeiten.Text = "Bearbeiten";
            this.CmdBearbeiten.UseVisualStyleBackColor = true;
            this.CmdBearbeiten.Click += new System.EventHandler(this.CmdBearbeiten_Click);
            //
            // CmdAktivPassiv
            //
            this.CmdAktivPassiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdAktivPassiv.Location = new System.Drawing.Point(684, 144);
            this.CmdAktivPassiv.Name = "CmdAktivPassiv";
            this.CmdAktivPassiv.Size = new System.Drawing.Size(164, 34);
            this.CmdAktivPassiv.TabIndex = 5;
            this.CmdAktivPassiv.Text = "Aktivieren / Deaktivieren";
            this.CmdAktivPassiv.UseVisualStyleBackColor = true;
            this.CmdAktivPassiv.Click += new System.EventHandler(this.CmdAktivPassiv_Click);
            //
            // CmdLoeschen
            //
            this.CmdLoeschen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdLoeschen.Location = new System.Drawing.Point(684, 184);
            this.CmdLoeschen.Name = "CmdLoeschen";
            this.CmdLoeschen.Size = new System.Drawing.Size(164, 34);
            this.CmdLoeschen.TabIndex = 6;
            this.CmdLoeschen.Text = "Löschen";
            this.CmdLoeschen.UseVisualStyleBackColor = true;
            this.CmdLoeschen.Click += new System.EventHandler(this.CmdLoeschen_Click);
            //
            // CmdDashboard
            //
            this.CmdDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdDashboard.Location = new System.Drawing.Point(684, 236);
            this.CmdDashboard.Name = "CmdDashboard";
            this.CmdDashboard.Size = new System.Drawing.Size(164, 34);
            this.CmdDashboard.TabIndex = 7;
            this.CmdDashboard.Text = "Dashboard";
            this.CmdDashboard.UseVisualStyleBackColor = true;
            this.CmdDashboard.Click += new System.EventHandler(this.CmdDashboard_Click);
            //
            // CmdCsvImport
            //
            this.CmdCsvImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdCsvImport.Location = new System.Drawing.Point(684, 276);
            this.CmdCsvImport.Name = "CmdCsvImport";
            this.CmdCsvImport.Size = new System.Drawing.Size(164, 34);
            this.CmdCsvImport.TabIndex = 8;
            this.CmdCsvImport.Text = "Kontakte importieren (CSV)";
            this.CmdCsvImport.UseVisualStyleBackColor = true;
            this.CmdCsvImport.Click += new System.EventHandler(this.CmdCsvImport_Click);
            //
            // LblStatus
            //
            this.LblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblStatus.AutoSize = true;
            this.LblStatus.Location = new System.Drawing.Point(12, 552);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(40, 13);
            this.LblStatus.TabIndex = 9;
            this.LblStatus.Text = "Status";
            //
            // HauptForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 580);
            this.Controls.Add(this.GrpSuche);
            this.Controls.Add(this.LstPersonen);
            this.Controls.Add(this.CmdNeuerKunde);
            this.Controls.Add(this.CmdNeuerMitarbeiter);
            this.Controls.Add(this.CmdBearbeiten);
            this.Controls.Add(this.CmdAktivPassiv);
            this.Controls.Add(this.CmdLoeschen);
            this.Controls.Add(this.CmdDashboard);
            this.Controls.Add(this.CmdCsvImport);
            this.Controls.Add(this.LblStatus);
            this.MinimumSize = new System.Drawing.Size(876, 619);
            this.Name = "HauptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contact Manager";
            this.Load += new System.EventHandler(this.HauptForm_Load);
            this.GrpSuche.ResumeLayout(false);
            this.GrpSuche.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox GrpSuche;
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
        private System.Windows.Forms.ListBox LstPersonen;
        private System.Windows.Forms.Button CmdNeuerKunde;
        private System.Windows.Forms.Button CmdNeuerMitarbeiter;
        private System.Windows.Forms.Button CmdBearbeiten;
        private System.Windows.Forms.Button CmdAktivPassiv;
        private System.Windows.Forms.Button CmdLoeschen;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.Button CmdDashboard;
        private System.Windows.Forms.Button CmdCsvImport;
    }
}
