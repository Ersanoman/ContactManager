namespace ContactManager.View
{
    partial class MitarbeiterForm
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
            this.GrpPersonalien = new System.Windows.Forms.GroupBox();
            this.LblAnrede = new System.Windows.Forms.Label();
            this.CmbAnrede = new System.Windows.Forms.ComboBox();
            this.LblTitel = new System.Windows.Forms.Label();
            this.TxtTitel = new System.Windows.Forms.TextBox();
            this.LblVorname = new System.Windows.Forms.Label();
            this.TxtVorname = new System.Windows.Forms.TextBox();
            this.LblNachname = new System.Windows.Forms.Label();
            this.TxtNachname = new System.Windows.Forms.TextBox();
            this.LblGeburtsdatum = new System.Windows.Forms.Label();
            this.DtpGeburtsdatum = new System.Windows.Forms.DateTimePicker();
            this.LblGeschlecht = new System.Windows.Forms.Label();
            this.CmbGeschlecht = new System.Windows.Forms.ComboBox();
            this.ChkAktiv = new System.Windows.Forms.CheckBox();
            this.GrpKontakt = new System.Windows.Forms.GroupBox();
            this.LblTelefonGeschaeft = new System.Windows.Forms.Label();
            this.TxtTelefonGeschaeft = new System.Windows.Forms.TextBox();
            this.LblMobiltelefon = new System.Windows.Forms.Label();
            this.TxtMobiltelefon = new System.Windows.Forms.TextBox();
            this.LblEMail = new System.Windows.Forms.Label();
            this.TxtEMail = new System.Windows.Forms.TextBox();
            this.GrpLernender = new System.Windows.Forms.GroupBox();
            this.ChkLernender = new System.Windows.Forms.CheckBox();
            this.LblLehrjahre = new System.Windows.Forms.Label();
            this.NumLehrjahre = new System.Windows.Forms.NumericUpDown();
            this.LblAktuellesLehrjahr = new System.Windows.Forms.Label();
            this.NumAktuellesLehrjahr = new System.Windows.Forms.NumericUpDown();
            this.GrpAnstellung = new System.Windows.Forms.GroupBox();
            this.LblMitarbeiternummer = new System.Windows.Forms.Label();
            this.TxtMitarbeiternummer = new System.Windows.Forms.TextBox();
            this.LblAbteilung = new System.Windows.Forms.Label();
            this.TxtAbteilung = new System.Windows.Forms.TextBox();
            this.LblAhvNummer = new System.Windows.Forms.Label();
            this.TxtAhvNummer = new System.Windows.Forms.TextBox();
            this.LblAdresse = new System.Windows.Forms.Label();
            this.TxtAdresse = new System.Windows.Forms.TextBox();
            this.LblPostleitzahl = new System.Windows.Forms.Label();
            this.TxtPostleitzahl = new System.Windows.Forms.TextBox();
            this.LblWohnort = new System.Windows.Forms.Label();
            this.TxtWohnort = new System.Windows.Forms.TextBox();
            this.LblNationalitaet = new System.Windows.Forms.Label();
            this.CmbNationalitaet = new System.Windows.Forms.ComboBox();
            this.LblEintrittsdatum = new System.Windows.Forms.Label();
            this.DtpEintrittsdatum = new System.Windows.Forms.DateTimePicker();
            this.ChkAusgetreten = new System.Windows.Forms.CheckBox();
            this.DtpAustrittsdatum = new System.Windows.Forms.DateTimePicker();
            this.LblBeschaeftigungsgrad = new System.Windows.Forms.Label();
            this.NumBeschaeftigungsgrad = new System.Windows.Forms.NumericUpDown();
            this.LblRolle = new System.Windows.Forms.Label();
            this.TxtRolle = new System.Windows.Forms.TextBox();
            this.LblKaderstufe = new System.Windows.Forms.Label();
            this.NumKaderstufe = new System.Windows.Forms.NumericUpDown();
            this.LblGeschaeftsadresse = new System.Windows.Forms.Label();
            this.TxtGeschaeftsadresse = new System.Windows.Forms.TextBox();
            this.CmdSpeichern = new System.Windows.Forms.Button();
            this.CmdAbbrechen = new System.Windows.Forms.Button();
            this.LblPflichtfeld = new System.Windows.Forms.Label();
            this.GrpPersonalien.SuspendLayout();
            this.GrpKontakt.SuspendLayout();
            this.GrpLernender.SuspendLayout();
            this.GrpAnstellung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumLehrjahre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumAktuellesLehrjahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumBeschaeftigungsgrad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumKaderstufe)).BeginInit();
            this.SuspendLayout();
            //
            // GrpPersonalien
            //
            this.GrpPersonalien.Controls.Add(this.LblAnrede);
            this.GrpPersonalien.Controls.Add(this.CmbAnrede);
            this.GrpPersonalien.Controls.Add(this.LblTitel);
            this.GrpPersonalien.Controls.Add(this.TxtTitel);
            this.GrpPersonalien.Controls.Add(this.LblVorname);
            this.GrpPersonalien.Controls.Add(this.TxtVorname);
            this.GrpPersonalien.Controls.Add(this.LblNachname);
            this.GrpPersonalien.Controls.Add(this.TxtNachname);
            this.GrpPersonalien.Controls.Add(this.LblGeburtsdatum);
            this.GrpPersonalien.Controls.Add(this.DtpGeburtsdatum);
            this.GrpPersonalien.Controls.Add(this.LblGeschlecht);
            this.GrpPersonalien.Controls.Add(this.CmbGeschlecht);
            this.GrpPersonalien.Controls.Add(this.ChkAktiv);
            this.GrpPersonalien.Location = new System.Drawing.Point(12, 12);
            this.GrpPersonalien.Name = "GrpPersonalien";
            this.GrpPersonalien.Size = new System.Drawing.Size(350, 242);
            this.GrpPersonalien.TabIndex = 0;
            this.GrpPersonalien.TabStop = false;
            this.GrpPersonalien.Text = "Personalien";
            //
            // LblAnrede
            //
            this.LblAnrede.AutoSize = true;
            this.LblAnrede.Location = new System.Drawing.Point(16, 30);
            this.LblAnrede.Name = "LblAnrede";
            this.LblAnrede.Size = new System.Drawing.Size(45, 13);
            this.LblAnrede.TabIndex = 0;
            this.LblAnrede.Text = "Anrede:";
            //
            // CmbAnrede
            //
            this.CmbAnrede.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAnrede.FormattingEnabled = true;
            this.CmbAnrede.Location = new System.Drawing.Point(142, 27);
            this.CmbAnrede.Name = "CmbAnrede";
            this.CmbAnrede.Size = new System.Drawing.Size(100, 21);
            this.CmbAnrede.TabIndex = 1;
            //
            // LblTitel
            //
            this.LblTitel.AutoSize = true;
            this.LblTitel.Location = new System.Drawing.Point(16, 62);
            this.LblTitel.Name = "LblTitel";
            this.LblTitel.Size = new System.Drawing.Size(30, 13);
            this.LblTitel.TabIndex = 2;
            this.LblTitel.Text = "Titel:";
            //
            // TxtTitel
            //
            this.TxtTitel.Location = new System.Drawing.Point(142, 59);
            this.TxtTitel.Name = "TxtTitel";
            this.TxtTitel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTitel.Size = new System.Drawing.Size(196, 23);
            this.TxtTitel.TabIndex = 3;
            //
            // LblVorname
            //
            this.LblVorname.AutoSize = true;
            this.LblVorname.Location = new System.Drawing.Point(16, 94);
            this.LblVorname.Name = "LblVorname";
            this.LblVorname.Size = new System.Drawing.Size(52, 13);
            this.LblVorname.TabIndex = 4;
            this.LblVorname.Text = "Vorname:*";
            //
            // TxtVorname
            //
            this.TxtVorname.Location = new System.Drawing.Point(142, 91);
            this.TxtVorname.Name = "TxtVorname";
            this.TxtVorname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtVorname.Size = new System.Drawing.Size(196, 23);
            this.TxtVorname.TabIndex = 5;
            //
            // LblNachname
            //
            this.LblNachname.AutoSize = true;
            this.LblNachname.Location = new System.Drawing.Point(16, 126);
            this.LblNachname.Name = "LblNachname";
            this.LblNachname.Size = new System.Drawing.Size(61, 13);
            this.LblNachname.TabIndex = 6;
            this.LblNachname.Text = "Nachname:*";
            //
            // TxtNachname
            //
            this.TxtNachname.Location = new System.Drawing.Point(142, 123);
            this.TxtNachname.Name = "TxtNachname";
            this.TxtNachname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNachname.Size = new System.Drawing.Size(196, 23);
            this.TxtNachname.TabIndex = 7;
            //
            // LblGeburtsdatum
            //
            this.LblGeburtsdatum.AutoSize = true;
            this.LblGeburtsdatum.Location = new System.Drawing.Point(16, 158);
            this.LblGeburtsdatum.Name = "LblGeburtsdatum";
            this.LblGeburtsdatum.Size = new System.Drawing.Size(77, 13);
            this.LblGeburtsdatum.TabIndex = 8;
            this.LblGeburtsdatum.Text = "Geburtsdatum:";
            //
            // DtpGeburtsdatum
            //
            this.DtpGeburtsdatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpGeburtsdatum.Location = new System.Drawing.Point(142, 155);
            this.DtpGeburtsdatum.Name = "DtpGeburtsdatum";
            this.DtpGeburtsdatum.Size = new System.Drawing.Size(120, 20);
            this.DtpGeburtsdatum.TabIndex = 9;
            //
            // LblGeschlecht
            //
            this.LblGeschlecht.AutoSize = true;
            this.LblGeschlecht.Location = new System.Drawing.Point(16, 190);
            this.LblGeschlecht.Name = "LblGeschlecht";
            this.LblGeschlecht.Size = new System.Drawing.Size(64, 13);
            this.LblGeschlecht.TabIndex = 10;
            this.LblGeschlecht.Text = "Geschlecht:";
            //
            // CmbGeschlecht
            //
            this.CmbGeschlecht.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbGeschlecht.FormattingEnabled = true;
            this.CmbGeschlecht.Location = new System.Drawing.Point(142, 187);
            this.CmbGeschlecht.Name = "CmbGeschlecht";
            this.CmbGeschlecht.Size = new System.Drawing.Size(120, 21);
            this.CmbGeschlecht.TabIndex = 11;
            //
            // ChkAktiv
            //
            this.ChkAktiv.AutoSize = true;
            this.ChkAktiv.Location = new System.Drawing.Point(142, 215);
            this.ChkAktiv.Name = "ChkAktiv";
            this.ChkAktiv.Size = new System.Drawing.Size(48, 17);
            this.ChkAktiv.TabIndex = 12;
            this.ChkAktiv.Text = "aktiv";
            this.ChkAktiv.UseVisualStyleBackColor = true;
            //
            // GrpKontakt
            //
            this.GrpKontakt.Controls.Add(this.LblTelefonGeschaeft);
            this.GrpKontakt.Controls.Add(this.TxtTelefonGeschaeft);
            this.GrpKontakt.Controls.Add(this.LblMobiltelefon);
            this.GrpKontakt.Controls.Add(this.TxtMobiltelefon);
            this.GrpKontakt.Controls.Add(this.LblEMail);
            this.GrpKontakt.Controls.Add(this.TxtEMail);
            this.GrpKontakt.Location = new System.Drawing.Point(12, 266);
            this.GrpKontakt.Name = "GrpKontakt";
            this.GrpKontakt.Size = new System.Drawing.Size(350, 130);
            this.GrpKontakt.TabIndex = 1;
            this.GrpKontakt.TabStop = false;
            this.GrpKontakt.Text = "Kontaktdaten";
            //
            // LblTelefonGeschaeft
            //
            this.LblTelefonGeschaeft.AutoSize = true;
            this.LblTelefonGeschaeft.Location = new System.Drawing.Point(16, 30);
            this.LblTelefonGeschaeft.Name = "LblTelefonGeschaeft";
            this.LblTelefonGeschaeft.Size = new System.Drawing.Size(93, 13);
            this.LblTelefonGeschaeft.TabIndex = 0;
            this.LblTelefonGeschaeft.Text = "Telefon Geschäft:";
            //
            // TxtTelefonGeschaeft
            //
            this.TxtTelefonGeschaeft.Location = new System.Drawing.Point(142, 27);
            this.TxtTelefonGeschaeft.Name = "TxtTelefonGeschaeft";
            this.TxtTelefonGeschaeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTelefonGeschaeft.Size = new System.Drawing.Size(196, 23);
            this.TxtTelefonGeschaeft.TabIndex = 1;
            this.TxtTelefonGeschaeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTelefon_KeyPress);
            //
            // LblMobiltelefon
            //
            this.LblMobiltelefon.AutoSize = true;
            this.LblMobiltelefon.Location = new System.Drawing.Point(16, 62);
            this.LblMobiltelefon.Name = "LblMobiltelefon";
            this.LblMobiltelefon.Size = new System.Drawing.Size(68, 13);
            this.LblMobiltelefon.TabIndex = 2;
            this.LblMobiltelefon.Text = "Mobiltelefon:";
            //
            // TxtMobiltelefon
            //
            this.TxtMobiltelefon.Location = new System.Drawing.Point(142, 59);
            this.TxtMobiltelefon.Name = "TxtMobiltelefon";
            this.TxtMobiltelefon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtMobiltelefon.Size = new System.Drawing.Size(196, 23);
            this.TxtMobiltelefon.TabIndex = 3;
            this.TxtMobiltelefon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTelefon_KeyPress);
            //
            // LblEMail
            //
            this.LblEMail.AutoSize = true;
            this.LblEMail.Location = new System.Drawing.Point(16, 94);
            this.LblEMail.Name = "LblEMail";
            this.LblEMail.Size = new System.Drawing.Size(39, 13);
            this.LblEMail.TabIndex = 4;
            this.LblEMail.Text = "E-Mail:";
            //
            // TxtEMail
            //
            this.TxtEMail.Location = new System.Drawing.Point(142, 91);
            this.TxtEMail.Name = "TxtEMail";
            this.TxtEMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEMail.Size = new System.Drawing.Size(196, 23);
            this.TxtEMail.TabIndex = 5;
            //
            // GrpLernender
            //
            this.GrpLernender.Controls.Add(this.ChkLernender);
            this.GrpLernender.Controls.Add(this.LblLehrjahre);
            this.GrpLernender.Controls.Add(this.NumLehrjahre);
            this.GrpLernender.Controls.Add(this.LblAktuellesLehrjahr);
            this.GrpLernender.Controls.Add(this.NumAktuellesLehrjahr);
            this.GrpLernender.Location = new System.Drawing.Point(12, 408);
            this.GrpLernender.Name = "GrpLernender";
            this.GrpLernender.Size = new System.Drawing.Size(350, 130);
            this.GrpLernender.TabIndex = 2;
            this.GrpLernender.TabStop = false;
            this.GrpLernender.Text = "Lernender";
            //
            // ChkLernender
            //
            this.ChkLernender.AutoSize = true;
            this.ChkLernender.Location = new System.Drawing.Point(16, 28);
            this.ChkLernender.Name = "ChkLernender";
            this.ChkLernender.Size = new System.Drawing.Size(88, 17);
            this.ChkLernender.TabIndex = 0;
            this.ChkLernender.Text = "Ist Lernender";
            this.ChkLernender.UseVisualStyleBackColor = true;
            this.ChkLernender.CheckedChanged += new System.EventHandler(this.ChkLernender_CheckedChanged);
            //
            // LblLehrjahre
            //
            this.LblLehrjahre.AutoSize = true;
            this.LblLehrjahre.Location = new System.Drawing.Point(16, 62);
            this.LblLehrjahre.Name = "LblLehrjahre";
            this.LblLehrjahre.Size = new System.Drawing.Size(90, 13);
            this.LblLehrjahre.TabIndex = 1;
            this.LblLehrjahre.Text = "Lehrjahre (Total):";
            //
            // NumLehrjahre
            //
            this.NumLehrjahre.Enabled = false;
            this.NumLehrjahre.Location = new System.Drawing.Point(200, 60);
            this.NumLehrjahre.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            this.NumLehrjahre.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.NumLehrjahre.Name = "NumLehrjahre";
            this.NumLehrjahre.Size = new System.Drawing.Size(60, 20);
            this.NumLehrjahre.TabIndex = 2;
            this.NumLehrjahre.Value = new decimal(new int[] { 3, 0, 0, 0 });
            //
            // LblAktuellesLehrjahr
            //
            this.LblAktuellesLehrjahr.AutoSize = true;
            this.LblAktuellesLehrjahr.Location = new System.Drawing.Point(16, 94);
            this.LblAktuellesLehrjahr.Name = "LblAktuellesLehrjahr";
            this.LblAktuellesLehrjahr.Size = new System.Drawing.Size(95, 13);
            this.LblAktuellesLehrjahr.TabIndex = 3;
            this.LblAktuellesLehrjahr.Text = "Aktuelles Lehrjahr:";
            //
            // NumAktuellesLehrjahr
            //
            this.NumAktuellesLehrjahr.Enabled = false;
            this.NumAktuellesLehrjahr.Location = new System.Drawing.Point(200, 92);
            this.NumAktuellesLehrjahr.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            this.NumAktuellesLehrjahr.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.NumAktuellesLehrjahr.Name = "NumAktuellesLehrjahr";
            this.NumAktuellesLehrjahr.Size = new System.Drawing.Size(60, 20);
            this.NumAktuellesLehrjahr.TabIndex = 4;
            this.NumAktuellesLehrjahr.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // GrpAnstellung
            //
            this.GrpAnstellung.Controls.Add(this.LblMitarbeiternummer);
            this.GrpAnstellung.Controls.Add(this.TxtMitarbeiternummer);
            this.GrpAnstellung.Controls.Add(this.LblAbteilung);
            this.GrpAnstellung.Controls.Add(this.TxtAbteilung);
            this.GrpAnstellung.Controls.Add(this.LblAhvNummer);
            this.GrpAnstellung.Controls.Add(this.TxtAhvNummer);
            this.GrpAnstellung.Controls.Add(this.LblAdresse);
            this.GrpAnstellung.Controls.Add(this.TxtAdresse);
            this.GrpAnstellung.Controls.Add(this.LblPostleitzahl);
            this.GrpAnstellung.Controls.Add(this.TxtPostleitzahl);
            this.GrpAnstellung.Controls.Add(this.LblWohnort);
            this.GrpAnstellung.Controls.Add(this.TxtWohnort);
            this.GrpAnstellung.Controls.Add(this.LblNationalitaet);
            this.GrpAnstellung.Controls.Add(this.CmbNationalitaet);
            this.GrpAnstellung.Controls.Add(this.LblEintrittsdatum);
            this.GrpAnstellung.Controls.Add(this.DtpEintrittsdatum);
            this.GrpAnstellung.Controls.Add(this.ChkAusgetreten);
            this.GrpAnstellung.Controls.Add(this.DtpAustrittsdatum);
            this.GrpAnstellung.Controls.Add(this.LblBeschaeftigungsgrad);
            this.GrpAnstellung.Controls.Add(this.NumBeschaeftigungsgrad);
            this.GrpAnstellung.Controls.Add(this.LblRolle);
            this.GrpAnstellung.Controls.Add(this.TxtRolle);
            this.GrpAnstellung.Controls.Add(this.LblKaderstufe);
            this.GrpAnstellung.Controls.Add(this.NumKaderstufe);
            this.GrpAnstellung.Controls.Add(this.LblGeschaeftsadresse);
            this.GrpAnstellung.Controls.Add(this.TxtGeschaeftsadresse);
            this.GrpAnstellung.Location = new System.Drawing.Point(374, 12);
            this.GrpAnstellung.Name = "GrpAnstellung";
            this.GrpAnstellung.Size = new System.Drawing.Size(370, 470);
            this.GrpAnstellung.TabIndex = 3;
            this.GrpAnstellung.TabStop = false;
            this.GrpAnstellung.Text = "Anstellung";
            //
            // LblMitarbeiternummer
            //
            this.LblMitarbeiternummer.AutoSize = true;
            this.LblMitarbeiternummer.Location = new System.Drawing.Point(16, 30);
            this.LblMitarbeiternummer.Name = "LblMitarbeiternummer";
            this.LblMitarbeiternummer.Size = new System.Drawing.Size(100, 13);
            this.LblMitarbeiternummer.TabIndex = 0;
            this.LblMitarbeiternummer.Text = "Mitarbeiternummer:";
            //
            // TxtMitarbeiternummer
            //
            this.TxtMitarbeiternummer.Location = new System.Drawing.Point(182, 27);
            this.TxtMitarbeiternummer.Name = "TxtMitarbeiternummer";
            this.TxtMitarbeiternummer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtMitarbeiternummer.ReadOnly = true;
            this.TxtMitarbeiternummer.Size = new System.Drawing.Size(176, 23);
            this.TxtMitarbeiternummer.TabIndex = 1;
            this.TxtMitarbeiternummer.TabStop = false;
            //
            // LblAbteilung
            //
            this.LblAbteilung.AutoSize = true;
            this.LblAbteilung.Location = new System.Drawing.Point(16, 62);
            this.LblAbteilung.Name = "LblAbteilung";
            this.LblAbteilung.Size = new System.Drawing.Size(53, 13);
            this.LblAbteilung.TabIndex = 2;
            this.LblAbteilung.Text = "Abteilung:*";
            //
            // TxtAbteilung
            //
            this.TxtAbteilung.Location = new System.Drawing.Point(182, 59);
            this.TxtAbteilung.Name = "TxtAbteilung";
            this.TxtAbteilung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtAbteilung.Size = new System.Drawing.Size(176, 23);
            this.TxtAbteilung.TabIndex = 3;
            //
            // LblAhvNummer
            //
            this.LblAhvNummer.AutoSize = true;
            this.LblAhvNummer.Location = new System.Drawing.Point(16, 94);
            this.LblAhvNummer.Name = "LblAhvNummer";
            this.LblAhvNummer.Size = new System.Drawing.Size(74, 13);
            this.LblAhvNummer.TabIndex = 4;
            this.LblAhvNummer.Text = "AHV-Nummer:*";
            //
            // TxtAhvNummer
            //
            this.TxtAhvNummer.Location = new System.Drawing.Point(182, 91);
            this.TxtAhvNummer.Name = "TxtAhvNummer";
            this.TxtAhvNummer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtAhvNummer.Size = new System.Drawing.Size(176, 23);
            this.TxtAhvNummer.TabIndex = 5;
            //
            // LblAdresse
            //
            this.LblAdresse.AutoSize = true;
            this.LblAdresse.Location = new System.Drawing.Point(16, 126);
            this.LblAdresse.Name = "LblAdresse";
            this.LblAdresse.Size = new System.Drawing.Size(48, 13);
            this.LblAdresse.TabIndex = 6;
            this.LblAdresse.Text = "Adresse:";
            //
            // TxtAdresse
            //
            this.TxtAdresse.Location = new System.Drawing.Point(182, 123);
            this.TxtAdresse.Name = "TxtAdresse";
            this.TxtAdresse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtAdresse.Size = new System.Drawing.Size(176, 23);
            this.TxtAdresse.TabIndex = 7;
            //
            // LblPostleitzahl
            //
            this.LblPostleitzahl.AutoSize = true;
            this.LblPostleitzahl.Location = new System.Drawing.Point(16, 158);
            this.LblPostleitzahl.Name = "LblPostleitzahl";
            this.LblPostleitzahl.Size = new System.Drawing.Size(64, 13);
            this.LblPostleitzahl.TabIndex = 8;
            this.LblPostleitzahl.Text = "Postleitzahl:";
            //
            // TxtPostleitzahl
            //
            this.TxtPostleitzahl.Location = new System.Drawing.Point(182, 155);
            this.TxtPostleitzahl.Name = "TxtPostleitzahl";
            this.TxtPostleitzahl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPostleitzahl.Size = new System.Drawing.Size(60, 20);
            this.TxtPostleitzahl.TabIndex = 9;
            //
            // LblWohnort
            //
            this.LblWohnort.AutoSize = true;
            this.LblWohnort.Location = new System.Drawing.Point(16, 190);
            this.LblWohnort.Name = "LblWohnort";
            this.LblWohnort.Size = new System.Drawing.Size(51, 13);
            this.LblWohnort.TabIndex = 10;
            this.LblWohnort.Text = "Wohnort:";
            //
            // TxtWohnort
            //
            this.TxtWohnort.Location = new System.Drawing.Point(182, 187);
            this.TxtWohnort.Name = "TxtWohnort";
            this.TxtWohnort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtWohnort.Size = new System.Drawing.Size(176, 23);
            this.TxtWohnort.TabIndex = 11;
            //
            // LblNationalitaet
            //
            this.LblNationalitaet.AutoSize = true;
            this.LblNationalitaet.Location = new System.Drawing.Point(16, 222);
            this.LblNationalitaet.Name = "LblNationalitaet";
            this.LblNationalitaet.Size = new System.Drawing.Size(69, 13);
            this.LblNationalitaet.TabIndex = 12;
            this.LblNationalitaet.Text = "Nationalität:";
            //
            // CmbNationalitaet
            //
            this.CmbNationalitaet.FormattingEnabled = true;
            this.CmbNationalitaet.Location = new System.Drawing.Point(182, 218);
            this.CmbNationalitaet.Name = "CmbNationalitaet";
            this.CmbNationalitaet.Size = new System.Drawing.Size(180, 21);
            this.CmbNationalitaet.TabIndex = 13;
            //
            // LblEintrittsdatum
            //
            this.LblEintrittsdatum.AutoSize = true;
            this.LblEintrittsdatum.Location = new System.Drawing.Point(16, 254);
            this.LblEintrittsdatum.Name = "LblEintrittsdatum";
            this.LblEintrittsdatum.Size = new System.Drawing.Size(75, 13);
            this.LblEintrittsdatum.TabIndex = 14;
            this.LblEintrittsdatum.Text = "Eintrittsdatum:";
            //
            // DtpEintrittsdatum
            //
            this.DtpEintrittsdatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpEintrittsdatum.Location = new System.Drawing.Point(182, 251);
            this.DtpEintrittsdatum.Name = "DtpEintrittsdatum";
            this.DtpEintrittsdatum.Size = new System.Drawing.Size(120, 20);
            this.DtpEintrittsdatum.TabIndex = 15;
            //
            // ChkAusgetreten
            //
            this.ChkAusgetreten.AutoSize = true;
            this.ChkAusgetreten.Location = new System.Drawing.Point(16, 285);
            this.ChkAusgetreten.Name = "ChkAusgetreten";
            this.ChkAusgetreten.Size = new System.Drawing.Size(105, 17);
            this.ChkAusgetreten.TabIndex = 16;
            this.ChkAusgetreten.Text = "Ausgetreten am:";
            this.ChkAusgetreten.UseVisualStyleBackColor = true;
            this.ChkAusgetreten.CheckedChanged += new System.EventHandler(this.ChkAusgetreten_CheckedChanged);
            //
            // DtpAustrittsdatum
            //
            this.DtpAustrittsdatum.Enabled = false;
            this.DtpAustrittsdatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpAustrittsdatum.Location = new System.Drawing.Point(182, 283);
            this.DtpAustrittsdatum.Name = "DtpAustrittsdatum";
            this.DtpAustrittsdatum.Size = new System.Drawing.Size(120, 20);
            this.DtpAustrittsdatum.TabIndex = 17;
            //
            // LblBeschaeftigungsgrad
            //
            this.LblBeschaeftigungsgrad.AutoSize = true;
            this.LblBeschaeftigungsgrad.Location = new System.Drawing.Point(16, 318);
            this.LblBeschaeftigungsgrad.Name = "LblBeschaeftigungsgrad";
            this.LblBeschaeftigungsgrad.Size = new System.Drawing.Size(129, 13);
            this.LblBeschaeftigungsgrad.TabIndex = 18;
            this.LblBeschaeftigungsgrad.Text = "Beschäftigungsgrad (%):";
            //
            // NumBeschaeftigungsgrad
            //
            this.NumBeschaeftigungsgrad.Location = new System.Drawing.Point(182, 316);
            this.NumBeschaeftigungsgrad.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.NumBeschaeftigungsgrad.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.NumBeschaeftigungsgrad.Name = "NumBeschaeftigungsgrad";
            this.NumBeschaeftigungsgrad.Size = new System.Drawing.Size(60, 20);
            this.NumBeschaeftigungsgrad.TabIndex = 19;
            this.NumBeschaeftigungsgrad.Value = new decimal(new int[] { 100, 0, 0, 0 });
            //
            // LblRolle
            //
            this.LblRolle.AutoSize = true;
            this.LblRolle.Location = new System.Drawing.Point(16, 350);
            this.LblRolle.Name = "LblRolle";
            this.LblRolle.Size = new System.Drawing.Size(87, 13);
            this.LblRolle.TabIndex = 20;
            this.LblRolle.Text = "Rolle / Tätigkeit:";
            //
            // TxtRolle
            //
            this.TxtRolle.Location = new System.Drawing.Point(182, 347);
            this.TxtRolle.Name = "TxtRolle";
            this.TxtRolle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtRolle.Size = new System.Drawing.Size(176, 23);
            this.TxtRolle.TabIndex = 21;
            //
            // LblKaderstufe
            //
            this.LblKaderstufe.AutoSize = true;
            this.LblKaderstufe.Location = new System.Drawing.Point(16, 382);
            this.LblKaderstufe.Name = "LblKaderstufe";
            this.LblKaderstufe.Size = new System.Drawing.Size(92, 13);
            this.LblKaderstufe.TabIndex = 22;
            this.LblKaderstufe.Text = "Kaderstufe (0 - 5):";
            //
            // NumKaderstufe
            //
            this.NumKaderstufe.Location = new System.Drawing.Point(182, 380);
            this.NumKaderstufe.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.NumKaderstufe.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.NumKaderstufe.Name = "NumKaderstufe";
            this.NumKaderstufe.Size = new System.Drawing.Size(60, 20);
            this.NumKaderstufe.TabIndex = 23;
            //
            // LblGeschaeftsadresse
            //
            this.LblGeschaeftsadresse.AutoSize = true;
            this.LblGeschaeftsadresse.Location = new System.Drawing.Point(16, 414);
            this.LblGeschaeftsadresse.Name = "LblGeschaeftsadresse";
            this.LblGeschaeftsadresse.Size = new System.Drawing.Size(100, 13);
            this.LblGeschaeftsadresse.TabIndex = 24;
            this.LblGeschaeftsadresse.Text = "Geschäftsadresse:";
            //
            // TxtGeschaeftsadresse
            //
            this.TxtGeschaeftsadresse.Location = new System.Drawing.Point(182, 411);
            this.TxtGeschaeftsadresse.Name = "TxtGeschaeftsadresse";
            this.TxtGeschaeftsadresse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtGeschaeftsadresse.Size = new System.Drawing.Size(176, 23);
            this.TxtGeschaeftsadresse.TabIndex = 25;
            //
            // CmdSpeichern
            //
            this.CmdSpeichern.Location = new System.Drawing.Point(524, 596);
            this.CmdSpeichern.Name = "CmdSpeichern";
            this.CmdSpeichern.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.CmdSpeichern.FlatAppearance.BorderSize = 0;
            this.CmdSpeichern.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(42, 100, 150);
            this.CmdSpeichern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSpeichern.ForeColor = System.Drawing.Color.White;
            this.CmdSpeichern.Size = new System.Drawing.Size(100, 36);
            this.CmdSpeichern.TabIndex = 4;
            this.CmdSpeichern.Text = "Speichern";
            this.CmdSpeichern.UseVisualStyleBackColor = false;
            this.CmdSpeichern.Click += new System.EventHandler(this.CmdSpeichern_Click);
            //
            // CmdAbbrechen
            //
            this.CmdAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdAbbrechen.Location = new System.Drawing.Point(644, 596);
            this.CmdAbbrechen.Name = "CmdAbbrechen";
            this.CmdAbbrechen.BackColor = System.Drawing.Color.White;
            this.CmdAbbrechen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.CmdAbbrechen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.CmdAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdAbbrechen.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.CmdAbbrechen.Size = new System.Drawing.Size(100, 36);
            this.CmdAbbrechen.TabIndex = 5;
            this.CmdAbbrechen.Text = "Abbrechen";
            this.CmdAbbrechen.UseVisualStyleBackColor = false;
            this.CmdAbbrechen.Click += new System.EventHandler(this.CmdAbbrechen_Click);
            //
            // LblPflichtfeld
            //
            this.LblPflichtfeld.AutoSize = true;
            this.LblPflichtfeld.Location = new System.Drawing.Point(12, 606);
            this.LblPflichtfeld.Name = "LblPflichtfeld";
            this.LblPflichtfeld.ForeColor = System.Drawing.Color.FromArgb(90, 100, 112);
            this.LblPflichtfeld.Size = new System.Drawing.Size(390, 15);
            this.LblPflichtfeld.TabIndex = 6;
            this.LblPflichtfeld.Text = "* Pflichtfeld   |   AHV-Nummer: 756.XXXX.XXXX.XX   |   Postleitzahl: 1000 bis 9999";
            //
            // MitarbeiterForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CmdAbbrechen;
            this.ClientSize = new System.Drawing.Size(756, 650);
            this.Controls.Add(this.GrpPersonalien);
            this.Controls.Add(this.GrpKontakt);
            this.Controls.Add(this.GrpLernender);
            this.Controls.Add(this.GrpAnstellung);
            this.Controls.Add(this.CmdSpeichern);
            this.Controls.Add(this.CmdAbbrechen);
            this.Controls.Add(this.LblPflichtfeld);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BackColor = System.Drawing.Color.White;
            this.Name = "MitarbeiterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mitarbeiter";
            this.GrpPersonalien.ResumeLayout(false);
            this.GrpPersonalien.PerformLayout();
            this.GrpKontakt.ResumeLayout(false);
            this.GrpKontakt.PerformLayout();
            this.GrpLernender.ResumeLayout(false);
            this.GrpLernender.PerformLayout();
            this.GrpAnstellung.ResumeLayout(false);
            this.GrpAnstellung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumLehrjahre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumAktuellesLehrjahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumBeschaeftigungsgrad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumKaderstufe)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox GrpPersonalien;
        private System.Windows.Forms.Label LblAnrede;
        private System.Windows.Forms.ComboBox CmbAnrede;
        private System.Windows.Forms.Label LblTitel;
        private System.Windows.Forms.TextBox TxtTitel;
        private System.Windows.Forms.Label LblVorname;
        private System.Windows.Forms.TextBox TxtVorname;
        private System.Windows.Forms.Label LblNachname;
        private System.Windows.Forms.TextBox TxtNachname;
        private System.Windows.Forms.Label LblGeburtsdatum;
        private System.Windows.Forms.DateTimePicker DtpGeburtsdatum;
        private System.Windows.Forms.Label LblGeschlecht;
        private System.Windows.Forms.ComboBox CmbGeschlecht;
        private System.Windows.Forms.CheckBox ChkAktiv;
        private System.Windows.Forms.GroupBox GrpKontakt;
        private System.Windows.Forms.Label LblTelefonGeschaeft;
        private System.Windows.Forms.TextBox TxtTelefonGeschaeft;
        private System.Windows.Forms.Label LblMobiltelefon;
        private System.Windows.Forms.TextBox TxtMobiltelefon;
        private System.Windows.Forms.Label LblEMail;
        private System.Windows.Forms.TextBox TxtEMail;
        private System.Windows.Forms.GroupBox GrpLernender;
        private System.Windows.Forms.CheckBox ChkLernender;
        private System.Windows.Forms.Label LblLehrjahre;
        private System.Windows.Forms.NumericUpDown NumLehrjahre;
        private System.Windows.Forms.Label LblAktuellesLehrjahr;
        private System.Windows.Forms.NumericUpDown NumAktuellesLehrjahr;
        private System.Windows.Forms.GroupBox GrpAnstellung;
        private System.Windows.Forms.Label LblMitarbeiternummer;
        private System.Windows.Forms.TextBox TxtMitarbeiternummer;
        private System.Windows.Forms.Label LblAbteilung;
        private System.Windows.Forms.TextBox TxtAbteilung;
        private System.Windows.Forms.Label LblAhvNummer;
        private System.Windows.Forms.TextBox TxtAhvNummer;
        private System.Windows.Forms.Label LblAdresse;
        private System.Windows.Forms.TextBox TxtAdresse;
        private System.Windows.Forms.Label LblPostleitzahl;
        private System.Windows.Forms.TextBox TxtPostleitzahl;
        private System.Windows.Forms.Label LblWohnort;
        private System.Windows.Forms.TextBox TxtWohnort;
        private System.Windows.Forms.Label LblNationalitaet;
        private System.Windows.Forms.ComboBox CmbNationalitaet;
        private System.Windows.Forms.Label LblEintrittsdatum;
        private System.Windows.Forms.DateTimePicker DtpEintrittsdatum;
        private System.Windows.Forms.CheckBox ChkAusgetreten;
        private System.Windows.Forms.DateTimePicker DtpAustrittsdatum;
        private System.Windows.Forms.Label LblBeschaeftigungsgrad;
        private System.Windows.Forms.NumericUpDown NumBeschaeftigungsgrad;
        private System.Windows.Forms.Label LblRolle;
        private System.Windows.Forms.TextBox TxtRolle;
        private System.Windows.Forms.Label LblKaderstufe;
        private System.Windows.Forms.NumericUpDown NumKaderstufe;
        private System.Windows.Forms.Label LblGeschaeftsadresse;
        private System.Windows.Forms.TextBox TxtGeschaeftsadresse;
        private System.Windows.Forms.Button CmdSpeichern;
        private System.Windows.Forms.Button CmdAbbrechen;
        private System.Windows.Forms.Label LblPflichtfeld;
    }
}
