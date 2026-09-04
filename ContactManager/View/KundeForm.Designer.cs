namespace ContactManager.View
{
    partial class KundeForm
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
            this.GrpHistorie = new System.Windows.Forms.GroupBox();
            this.LstKontakthistorie = new System.Windows.Forms.ListBox();
            this.LblNeueNotiz = new System.Windows.Forms.Label();
            this.TxtNeueNotiz = new System.Windows.Forms.TextBox();
            this.CmdNotizHinzufuegen = new System.Windows.Forms.Button();
            this.CmdSpeichern = new System.Windows.Forms.Button();
            this.CmdAbbrechen = new System.Windows.Forms.Button();
            this.LblPflichtfeld = new System.Windows.Forms.Label();
            this.GrpPersonalien.SuspendLayout();
            this.GrpKontakt.SuspendLayout();
            this.GrpHistorie.SuspendLayout();
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
            this.GrpPersonalien.Size = new System.Drawing.Size(336, 242);
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
            this.CmbAnrede.Location = new System.Drawing.Point(140, 27);
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
            this.TxtTitel.Location = new System.Drawing.Point(140, 59);
            this.TxtTitel.Name = "TxtTitel";
            this.TxtTitel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTitel.Size = new System.Drawing.Size(190, 23);
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
            this.TxtVorname.Location = new System.Drawing.Point(140, 91);
            this.TxtVorname.Name = "TxtVorname";
            this.TxtVorname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtVorname.Size = new System.Drawing.Size(190, 23);
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
            this.TxtNachname.Location = new System.Drawing.Point(140, 123);
            this.TxtNachname.Name = "TxtNachname";
            this.TxtNachname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNachname.Size = new System.Drawing.Size(190, 23);
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
            this.DtpGeburtsdatum.Location = new System.Drawing.Point(140, 155);
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
            this.CmbGeschlecht.Location = new System.Drawing.Point(140, 187);
            this.CmbGeschlecht.Name = "CmbGeschlecht";
            this.CmbGeschlecht.Size = new System.Drawing.Size(120, 21);
            this.CmbGeschlecht.TabIndex = 11;
            //
            // ChkAktiv
            //
            this.ChkAktiv.AutoSize = true;
            this.ChkAktiv.Location = new System.Drawing.Point(140, 215);
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
            this.GrpKontakt.Size = new System.Drawing.Size(336, 130);
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
            this.TxtTelefonGeschaeft.Location = new System.Drawing.Point(140, 27);
            this.TxtTelefonGeschaeft.Name = "TxtTelefonGeschaeft";
            this.TxtTelefonGeschaeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTelefonGeschaeft.Size = new System.Drawing.Size(190, 23);
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
            this.TxtMobiltelefon.Location = new System.Drawing.Point(140, 59);
            this.TxtMobiltelefon.Name = "TxtMobiltelefon";
            this.TxtMobiltelefon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtMobiltelefon.Size = new System.Drawing.Size(190, 23);
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
            this.TxtEMail.Location = new System.Drawing.Point(140, 91);
            this.TxtEMail.Name = "TxtEMail";
            this.TxtEMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEMail.Size = new System.Drawing.Size(190, 23);
            this.TxtEMail.TabIndex = 5;
            //
            // GrpHistorie
            //
            this.GrpHistorie.Controls.Add(this.LstKontakthistorie);
            this.GrpHistorie.Controls.Add(this.LblNeueNotiz);
            this.GrpHistorie.Controls.Add(this.TxtNeueNotiz);
            this.GrpHistorie.Controls.Add(this.CmdNotizHinzufuegen);
            this.GrpHistorie.Location = new System.Drawing.Point(360, 12);
            this.GrpHistorie.Name = "GrpHistorie";
            this.GrpHistorie.Size = new System.Drawing.Size(344, 434);
            this.GrpHistorie.TabIndex = 2;
            this.GrpHistorie.TabStop = false;
            this.GrpHistorie.Text = "Kontakthistorie";
            //
            // LstKontakthistorie
            //
            this.LstKontakthistorie.FormattingEnabled = true;
            this.LstKontakthistorie.HorizontalScrollbar = true;
            this.LstKontakthistorie.Location = new System.Drawing.Point(12, 24);
            this.LstKontakthistorie.Name = "LstKontakthistorie";
            this.LstKontakthistorie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LstKontakthistorie.BackColor = System.Drawing.Color.White;
            this.LstKontakthistorie.Size = new System.Drawing.Size(320, 212);
            this.LstKontakthistorie.TabIndex = 0;
            //
            // LblNeueNotiz
            //
            this.LblNeueNotiz.AutoSize = true;
            this.LblNeueNotiz.Location = new System.Drawing.Point(12, 254);
            this.LblNeueNotiz.Name = "LblNeueNotiz";
            this.LblNeueNotiz.Size = new System.Drawing.Size(63, 13);
            this.LblNeueNotiz.TabIndex = 1;
            this.LblNeueNotiz.Text = "Neue Notiz:";
            //
            // TxtNeueNotiz
            //
            this.TxtNeueNotiz.AcceptsReturn = true;
            this.TxtNeueNotiz.Location = new System.Drawing.Point(12, 274);
            this.TxtNeueNotiz.Multiline = true;
            this.TxtNeueNotiz.Name = "TxtNeueNotiz";
            this.TxtNeueNotiz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNeueNotiz.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtNeueNotiz.Size = new System.Drawing.Size(320, 110);
            this.TxtNeueNotiz.TabIndex = 2;
            //
            // CmdNotizHinzufuegen
            //
            this.CmdNotizHinzufuegen.Location = new System.Drawing.Point(12, 392);
            this.CmdNotizHinzufuegen.Name = "CmdNotizHinzufuegen";
            this.CmdNotizHinzufuegen.BackColor = System.Drawing.Color.White;
            this.CmdNotizHinzufuegen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.CmdNotizHinzufuegen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.CmdNotizHinzufuegen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdNotizHinzufuegen.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.CmdNotizHinzufuegen.Size = new System.Drawing.Size(150, 30);
            this.CmdNotizHinzufuegen.TabIndex = 3;
            this.CmdNotizHinzufuegen.Text = "Notiz &hinzufügen";
            this.CmdNotizHinzufuegen.UseVisualStyleBackColor = false;
            this.CmdNotizHinzufuegen.Click += new System.EventHandler(this.CmdNotizHinzufuegen_Click);
            //
            // CmdSpeichern
            //
            this.CmdSpeichern.Location = new System.Drawing.Point(484, 486);
            this.CmdSpeichern.Name = "CmdSpeichern";
            this.CmdSpeichern.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.CmdSpeichern.FlatAppearance.BorderSize = 0;
            this.CmdSpeichern.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(42, 100, 150);
            this.CmdSpeichern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSpeichern.ForeColor = System.Drawing.Color.White;
            this.CmdSpeichern.Size = new System.Drawing.Size(100, 36);
            this.CmdSpeichern.TabIndex = 3;
            this.CmdSpeichern.Text = "&Speichern";
            this.CmdSpeichern.UseVisualStyleBackColor = false;
            this.CmdSpeichern.Click += new System.EventHandler(this.CmdSpeichern_Click);
            //
            // CmdAbbrechen
            //
            this.CmdAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdAbbrechen.Location = new System.Drawing.Point(604, 486);
            this.CmdAbbrechen.Name = "CmdAbbrechen";
            this.CmdAbbrechen.BackColor = System.Drawing.Color.White;
            this.CmdAbbrechen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.CmdAbbrechen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.CmdAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdAbbrechen.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.CmdAbbrechen.Size = new System.Drawing.Size(100, 36);
            this.CmdAbbrechen.TabIndex = 4;
            this.CmdAbbrechen.Text = "Abbrechen";
            this.CmdAbbrechen.UseVisualStyleBackColor = false;
            this.CmdAbbrechen.Click += new System.EventHandler(this.CmdAbbrechen_Click);
            //
            // LblPflichtfeld
            //
            this.LblPflichtfeld.AutoSize = true;
            this.LblPflichtfeld.Location = new System.Drawing.Point(12, 498);
            this.LblPflichtfeld.Name = "LblPflichtfeld";
            this.LblPflichtfeld.Size = new System.Drawing.Size(61, 13);
            this.LblPflichtfeld.TabIndex = 5;
            this.LblPflichtfeld.Text = "* Pflichtfeld";
            //
            // KundeForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AcceptButton = this.CmdSpeichern;
            this.CancelButton = this.CmdAbbrechen;
            this.ClientSize = new System.Drawing.Size(716, 536);
            this.Controls.Add(this.GrpPersonalien);
            this.Controls.Add(this.GrpKontakt);
            this.Controls.Add(this.GrpHistorie);
            this.Controls.Add(this.CmdSpeichern);
            this.Controls.Add(this.CmdAbbrechen);
            this.Controls.Add(this.LblPflichtfeld);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BackColor = System.Drawing.Color.White;
            this.Name = "KundeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kunde";
            this.GrpPersonalien.ResumeLayout(false);
            this.GrpPersonalien.PerformLayout();
            this.GrpKontakt.ResumeLayout(false);
            this.GrpKontakt.PerformLayout();
            this.GrpHistorie.ResumeLayout(false);
            this.GrpHistorie.PerformLayout();
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
        private System.Windows.Forms.GroupBox GrpHistorie;
        private System.Windows.Forms.ListBox LstKontakthistorie;
        private System.Windows.Forms.Label LblNeueNotiz;
        private System.Windows.Forms.TextBox TxtNeueNotiz;
        private System.Windows.Forms.Button CmdNotizHinzufuegen;
        private System.Windows.Forms.Button CmdSpeichern;
        private System.Windows.Forms.Button CmdAbbrechen;
        private System.Windows.Forms.Label LblPflichtfeld;
    }
}
