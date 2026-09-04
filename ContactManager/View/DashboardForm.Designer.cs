namespace ContactManager.View
{
    partial class DashboardForm
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
            this.GrpBestand = new System.Windows.Forms.GroupBox();
            this.LblTotal = new System.Windows.Forms.Label();
            this.LblTotalWert = new System.Windows.Forms.Label();
            this.LblKunden = new System.Windows.Forms.Label();
            this.LblKundenWert = new System.Windows.Forms.Label();
            this.LblMitarbeiter = new System.Windows.Forms.Label();
            this.LblMitarbeiterWert = new System.Windows.Forms.Label();
            this.LblLernende = new System.Windows.Forms.Label();
            this.LblLernendeWert = new System.Windows.Forms.Label();
            this.GrpStatus = new System.Windows.Forms.GroupBox();
            this.LblAktiv = new System.Windows.Forms.Label();
            this.LblAktivWert = new System.Windows.Forms.Label();
            this.LblPassiv = new System.Windows.Forms.Label();
            this.LblPassivWert = new System.Windows.Forms.Label();
            this.GrpWeiteres = new System.Windows.Forms.GroupBox();
            this.LblNotizen = new System.Windows.Forms.Label();
            this.LblNotizenWert = new System.Windows.Forms.Label();
            this.LblNaechsteNummer = new System.Windows.Forms.Label();
            this.LblNaechsteNummerWert = new System.Windows.Forms.Label();
            this.CmdSchliessen = new System.Windows.Forms.Button();
            this.GrpVerteilung = new System.Windows.Forms.GroupBox();
            this.PnlDiagramm = new System.Windows.Forms.Panel();
            this.PnlFarbeKunden = new System.Windows.Forms.Panel();
            this.LblLegendeKunden = new System.Windows.Forms.Label();
            this.PnlFarbeMitarbeiter = new System.Windows.Forms.Panel();
            this.LblLegendeMitarbeiter = new System.Windows.Forms.Label();
            this.PnlFarbeLernende = new System.Windows.Forms.Panel();
            this.LblLegendeLernende = new System.Windows.Forms.Label();
            this.LblDiagrammHinweis = new System.Windows.Forms.Label();
            this.GrpBestand.SuspendLayout();
            this.GrpStatus.SuspendLayout();
            this.GrpWeiteres.SuspendLayout();
            this.GrpVerteilung.SuspendLayout();
            this.SuspendLayout();
            //
            // GrpBestand
            //
            this.GrpBestand.Controls.Add(this.LblTotal);
            this.GrpBestand.Controls.Add(this.LblTotalWert);
            this.GrpBestand.Controls.Add(this.LblKunden);
            this.GrpBestand.Controls.Add(this.LblKundenWert);
            this.GrpBestand.Controls.Add(this.LblMitarbeiter);
            this.GrpBestand.Controls.Add(this.LblMitarbeiterWert);
            this.GrpBestand.Controls.Add(this.LblLernende);
            this.GrpBestand.Controls.Add(this.LblLernendeWert);
            this.GrpBestand.Location = new System.Drawing.Point(12, 12);
            this.GrpBestand.Name = "GrpBestand";
            this.GrpBestand.Size = new System.Drawing.Size(300, 140);
            this.GrpBestand.TabIndex = 0;
            this.GrpBestand.TabStop = false;
            this.GrpBestand.Text = "Erfasste Personen";
            //
            // LblTotal
            //
            this.LblTotal.AutoSize = true;
            this.LblTotal.Location = new System.Drawing.Point(16, 28);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(34, 13);
            this.LblTotal.TabIndex = 0;
            this.LblTotal.Text = "Total:";
            //
            // LblTotalWert
            //
            this.LblTotalWert.AutoSize = true;
            this.LblTotalWert.Location = new System.Drawing.Point(210, 28);
            this.LblTotalWert.Name = "LblTotalWert";
            this.LblTotalWert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LblTotalWert.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.LblTotalWert.Size = new System.Drawing.Size(13, 13);
            this.LblTotalWert.TabIndex = 1;
            this.LblTotalWert.Text = "0";
            //
            // LblKunden
            //
            this.LblKunden.AutoSize = true;
            this.LblKunden.Location = new System.Drawing.Point(16, 55);
            this.LblKunden.Name = "LblKunden";
            this.LblKunden.Size = new System.Drawing.Size(48, 13);
            this.LblKunden.TabIndex = 2;
            this.LblKunden.Text = "Kunden:";
            //
            // LblKundenWert
            //
            this.LblKundenWert.AutoSize = true;
            this.LblKundenWert.Location = new System.Drawing.Point(210, 55);
            this.LblKundenWert.Name = "LblKundenWert";
            this.LblKundenWert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LblKundenWert.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.LblKundenWert.Size = new System.Drawing.Size(13, 13);
            this.LblKundenWert.TabIndex = 3;
            this.LblKundenWert.Text = "0";
            //
            // LblMitarbeiter
            //
            this.LblMitarbeiter.AutoSize = true;
            this.LblMitarbeiter.Location = new System.Drawing.Point(16, 82);
            this.LblMitarbeiter.Name = "LblMitarbeiter";
            this.LblMitarbeiter.Size = new System.Drawing.Size(150, 13);
            this.LblMitarbeiter.TabIndex = 4;
            this.LblMitarbeiter.Text = "Mitarbeiter (ohne Lernende):";
            //
            // LblMitarbeiterWert
            //
            this.LblMitarbeiterWert.AutoSize = true;
            this.LblMitarbeiterWert.Location = new System.Drawing.Point(210, 82);
            this.LblMitarbeiterWert.Name = "LblMitarbeiterWert";
            this.LblMitarbeiterWert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LblMitarbeiterWert.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.LblMitarbeiterWert.Size = new System.Drawing.Size(13, 13);
            this.LblMitarbeiterWert.TabIndex = 5;
            this.LblMitarbeiterWert.Text = "0";
            //
            // LblLernende
            //
            this.LblLernende.AutoSize = true;
            this.LblLernende.Location = new System.Drawing.Point(16, 109);
            this.LblLernende.Name = "LblLernende";
            this.LblLernende.Size = new System.Drawing.Size(57, 13);
            this.LblLernende.TabIndex = 6;
            this.LblLernende.Text = "Lernende:";
            //
            // LblLernendeWert
            //
            this.LblLernendeWert.AutoSize = true;
            this.LblLernendeWert.Location = new System.Drawing.Point(210, 109);
            this.LblLernendeWert.Name = "LblLernendeWert";
            this.LblLernendeWert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LblLernendeWert.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.LblLernendeWert.Size = new System.Drawing.Size(13, 13);
            this.LblLernendeWert.TabIndex = 7;
            this.LblLernendeWert.Text = "0";
            //
            // GrpStatus
            //
            this.GrpStatus.Controls.Add(this.LblAktiv);
            this.GrpStatus.Controls.Add(this.LblAktivWert);
            this.GrpStatus.Controls.Add(this.LblPassiv);
            this.GrpStatus.Controls.Add(this.LblPassivWert);
            this.GrpStatus.Location = new System.Drawing.Point(12, 164);
            this.GrpStatus.Name = "GrpStatus";
            this.GrpStatus.Size = new System.Drawing.Size(300, 90);
            this.GrpStatus.TabIndex = 1;
            this.GrpStatus.TabStop = false;
            this.GrpStatus.Text = "Status";
            //
            // LblAktiv
            //
            this.LblAktiv.AutoSize = true;
            this.LblAktiv.Location = new System.Drawing.Point(16, 28);
            this.LblAktiv.Name = "LblAktiv";
            this.LblAktiv.Size = new System.Drawing.Size(33, 13);
            this.LblAktiv.TabIndex = 0;
            this.LblAktiv.Text = "Aktiv:";
            //
            // LblAktivWert
            //
            this.LblAktivWert.AutoSize = true;
            this.LblAktivWert.Location = new System.Drawing.Point(210, 28);
            this.LblAktivWert.Name = "LblAktivWert";
            this.LblAktivWert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LblAktivWert.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.LblAktivWert.Size = new System.Drawing.Size(13, 13);
            this.LblAktivWert.TabIndex = 1;
            this.LblAktivWert.Text = "0";
            //
            // LblPassiv
            //
            this.LblPassiv.AutoSize = true;
            this.LblPassiv.Location = new System.Drawing.Point(16, 55);
            this.LblPassiv.Name = "LblPassiv";
            this.LblPassiv.Size = new System.Drawing.Size(42, 13);
            this.LblPassiv.TabIndex = 2;
            this.LblPassiv.Text = "Passiv:";
            //
            // LblPassivWert
            //
            this.LblPassivWert.AutoSize = true;
            this.LblPassivWert.Location = new System.Drawing.Point(210, 55);
            this.LblPassivWert.Name = "LblPassivWert";
            this.LblPassivWert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LblPassivWert.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.LblPassivWert.Size = new System.Drawing.Size(13, 13);
            this.LblPassivWert.TabIndex = 3;
            this.LblPassivWert.Text = "0";
            //
            // GrpWeiteres
            //
            this.GrpWeiteres.Controls.Add(this.LblNotizen);
            this.GrpWeiteres.Controls.Add(this.LblNotizenWert);
            this.GrpWeiteres.Controls.Add(this.LblNaechsteNummer);
            this.GrpWeiteres.Controls.Add(this.LblNaechsteNummerWert);
            this.GrpWeiteres.Location = new System.Drawing.Point(12, 266);
            this.GrpWeiteres.Name = "GrpWeiteres";
            this.GrpWeiteres.Size = new System.Drawing.Size(300, 90);
            this.GrpWeiteres.TabIndex = 2;
            this.GrpWeiteres.TabStop = false;
            this.GrpWeiteres.Text = "Weitere Angaben";
            //
            // LblNotizen
            //
            this.LblNotizen.AutoSize = true;
            this.LblNotizen.Location = new System.Drawing.Point(16, 28);
            this.LblNotizen.Name = "LblNotizen";
            this.LblNotizen.Size = new System.Drawing.Size(105, 13);
            this.LblNotizen.TabIndex = 0;
            this.LblNotizen.Text = "Erfasste Kundennotizen:";
            //
            // LblNotizenWert
            //
            this.LblNotizenWert.AutoSize = true;
            this.LblNotizenWert.Location = new System.Drawing.Point(210, 28);
            this.LblNotizenWert.Name = "LblNotizenWert";
            this.LblNotizenWert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LblNotizenWert.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.LblNotizenWert.Size = new System.Drawing.Size(13, 13);
            this.LblNotizenWert.TabIndex = 1;
            this.LblNotizenWert.Text = "0";
            //
            // LblNaechsteNummer
            //
            this.LblNaechsteNummer.AutoSize = true;
            this.LblNaechsteNummer.Location = new System.Drawing.Point(16, 55);
            this.LblNaechsteNummer.Name = "LblNaechsteNummer";
            this.LblNaechsteNummer.Size = new System.Drawing.Size(140, 13);
            this.LblNaechsteNummer.TabIndex = 2;
            this.LblNaechsteNummer.Text = "Nächste Mitarbeiternummer:";
            //
            // LblNaechsteNummerWert
            //
            this.LblNaechsteNummerWert.AutoSize = true;
            this.LblNaechsteNummerWert.Location = new System.Drawing.Point(210, 55);
            this.LblNaechsteNummerWert.Name = "LblNaechsteNummerWert";
            this.LblNaechsteNummerWert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LblNaechsteNummerWert.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.LblNaechsteNummerWert.Size = new System.Drawing.Size(13, 13);
            this.LblNaechsteNummerWert.TabIndex = 3;
            this.LblNaechsteNummerWert.Text = "0";
            //
            // CmdSchliessen
            //
            this.CmdSchliessen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdSchliessen.Location = new System.Drawing.Point(528, 372);
            this.CmdSchliessen.Name = "CmdSchliessen";
            this.CmdSchliessen.BackColor = System.Drawing.Color.White;
            this.CmdSchliessen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.CmdSchliessen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(235, 240, 245);
            this.CmdSchliessen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSchliessen.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.CmdSchliessen.Size = new System.Drawing.Size(100, 32);
            this.CmdSchliessen.TabIndex = 4;
            this.CmdSchliessen.Text = "&Schliessen";
            this.CmdSchliessen.UseVisualStyleBackColor = false;
            this.CmdSchliessen.Click += new System.EventHandler(this.CmdSchliessen_Click);
            //
            // GrpVerteilung
            //
            this.GrpVerteilung.Controls.Add(this.PnlDiagramm);
            this.GrpVerteilung.Controls.Add(this.PnlFarbeKunden);
            this.GrpVerteilung.Controls.Add(this.LblLegendeKunden);
            this.GrpVerteilung.Controls.Add(this.PnlFarbeMitarbeiter);
            this.GrpVerteilung.Controls.Add(this.LblLegendeMitarbeiter);
            this.GrpVerteilung.Controls.Add(this.PnlFarbeLernende);
            this.GrpVerteilung.Controls.Add(this.LblLegendeLernende);
            this.GrpVerteilung.Controls.Add(this.LblDiagrammHinweis);
            this.GrpVerteilung.Location = new System.Drawing.Point(324, 12);
            this.GrpVerteilung.Name = "GrpVerteilung";
            this.GrpVerteilung.Size = new System.Drawing.Size(304, 344);
            this.GrpVerteilung.TabIndex = 3;
            this.GrpVerteilung.TabStop = false;
            this.GrpVerteilung.Text = "Verteilung der Kategorien";
            //
            // PnlDiagramm
            //
            this.PnlDiagramm.BackColor = System.Drawing.Color.White;
            this.PnlDiagramm.Location = new System.Drawing.Point(77, 28);
            this.PnlDiagramm.Name = "PnlDiagramm";
            this.PnlDiagramm.Size = new System.Drawing.Size(150, 150);
            this.PnlDiagramm.TabIndex = 0;
            this.PnlDiagramm.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlDiagramm_Paint);
            //
            // PnlFarbeKunden
            //
            this.PnlFarbeKunden.Location = new System.Drawing.Point(40, 199);
            this.PnlFarbeKunden.Name = "PnlFarbeKunden";
            this.PnlFarbeKunden.Size = new System.Drawing.Size(13, 13);
            this.PnlFarbeKunden.TabIndex = 1;
            //
            // LblLegendeKunden
            //
            this.LblLegendeKunden.AutoSize = true;
            this.LblLegendeKunden.Location = new System.Drawing.Point(62, 197);
            this.LblLegendeKunden.Name = "LblLegendeKunden";
            this.LblLegendeKunden.Size = new System.Drawing.Size(60, 15);
            this.LblLegendeKunden.TabIndex = 2;
            this.LblLegendeKunden.Text = "Kunden";
            //
            // PnlFarbeMitarbeiter
            //
            this.PnlFarbeMitarbeiter.Location = new System.Drawing.Point(40, 227);
            this.PnlFarbeMitarbeiter.Name = "PnlFarbeMitarbeiter";
            this.PnlFarbeMitarbeiter.Size = new System.Drawing.Size(13, 13);
            this.PnlFarbeMitarbeiter.TabIndex = 3;
            //
            // LblLegendeMitarbeiter
            //
            this.LblLegendeMitarbeiter.AutoSize = true;
            this.LblLegendeMitarbeiter.Location = new System.Drawing.Point(62, 225);
            this.LblLegendeMitarbeiter.Name = "LblLegendeMitarbeiter";
            this.LblLegendeMitarbeiter.Size = new System.Drawing.Size(70, 15);
            this.LblLegendeMitarbeiter.TabIndex = 4;
            this.LblLegendeMitarbeiter.Text = "Mitarbeiter";
            //
            // PnlFarbeLernende
            //
            this.PnlFarbeLernende.Location = new System.Drawing.Point(40, 255);
            this.PnlFarbeLernende.Name = "PnlFarbeLernende";
            this.PnlFarbeLernende.Size = new System.Drawing.Size(13, 13);
            this.PnlFarbeLernende.TabIndex = 5;
            //
            // LblLegendeLernende
            //
            this.LblLegendeLernende.AutoSize = true;
            this.LblLegendeLernende.Location = new System.Drawing.Point(62, 253);
            this.LblLegendeLernende.Name = "LblLegendeLernende";
            this.LblLegendeLernende.Size = new System.Drawing.Size(64, 15);
            this.LblLegendeLernende.TabIndex = 6;
            this.LblLegendeLernende.Text = "Lernende";
            //
            // LblDiagrammHinweis
            //
            this.LblDiagrammHinweis.AutoSize = true;
            this.LblDiagrammHinweis.ForeColor = System.Drawing.Color.FromArgb(90, 100, 112);
            this.LblDiagrammHinweis.Location = new System.Drawing.Point(20, 296);
            this.LblDiagrammHinweis.Name = "LblDiagrammHinweis";
            this.LblDiagrammHinweis.Size = new System.Drawing.Size(195, 15);
            this.LblDiagrammHinweis.TabIndex = 7;
            this.LblDiagrammHinweis.Text = "Anteile am gesamten Datenstamm";
            //
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CmdSchliessen;
            this.ClientSize = new System.Drawing.Size(640, 420);
            this.Controls.Add(this.GrpBestand);
            this.Controls.Add(this.GrpStatus);
            this.Controls.Add(this.GrpWeiteres);
            this.Controls.Add(this.GrpVerteilung);
            this.Controls.Add(this.CmdSchliessen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BackColor = System.Drawing.Color.White;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.GrpBestand.ResumeLayout(false);
            this.GrpBestand.PerformLayout();
            this.GrpStatus.ResumeLayout(false);
            this.GrpStatus.PerformLayout();
            this.GrpWeiteres.ResumeLayout(false);
            this.GrpWeiteres.PerformLayout();
            this.GrpVerteilung.ResumeLayout(false);
            this.GrpVerteilung.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBestand;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Label LblTotalWert;
        private System.Windows.Forms.Label LblKunden;
        private System.Windows.Forms.Label LblKundenWert;
        private System.Windows.Forms.Label LblMitarbeiter;
        private System.Windows.Forms.Label LblMitarbeiterWert;
        private System.Windows.Forms.Label LblLernende;
        private System.Windows.Forms.Label LblLernendeWert;
        private System.Windows.Forms.GroupBox GrpStatus;
        private System.Windows.Forms.Label LblAktiv;
        private System.Windows.Forms.Label LblAktivWert;
        private System.Windows.Forms.Label LblPassiv;
        private System.Windows.Forms.Label LblPassivWert;
        private System.Windows.Forms.GroupBox GrpWeiteres;
        private System.Windows.Forms.Label LblNotizen;
        private System.Windows.Forms.Label LblNotizenWert;
        private System.Windows.Forms.Label LblNaechsteNummer;
        private System.Windows.Forms.Label LblNaechsteNummerWert;
        private System.Windows.Forms.Button CmdSchliessen;
        private System.Windows.Forms.GroupBox GrpVerteilung;
        private System.Windows.Forms.Panel PnlDiagramm;
        private System.Windows.Forms.Panel PnlFarbeKunden;
        private System.Windows.Forms.Label LblLegendeKunden;
        private System.Windows.Forms.Panel PnlFarbeMitarbeiter;
        private System.Windows.Forms.Label LblLegendeMitarbeiter;
        private System.Windows.Forms.Panel PnlFarbeLernende;
        private System.Windows.Forms.Label LblLegendeLernende;
        private System.Windows.Forms.Label LblDiagrammHinweis;
    }
}
