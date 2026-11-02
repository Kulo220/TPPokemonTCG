namespace PokemonTCG.WinForms
{
    partial class FrmPartie
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpJoueur = new GroupBox();
            btnPasserTour = new Button();
            btnAttaquer = new Button();
            btnJouerCarte = new Button();
            btnPiocher = new Button();
            cmbAttaques = new ComboBox();
            lblEnergies = new Label();
            lblActif = new Label();
            lstBanc = new ListBox();
            lstMain = new ListBox();
            lblDeck = new Label();
            grpAdversaire = new GroupBox();
            lblActifAdversaire = new Label();
            lblMessage = new Label();
            grpJoueur.SuspendLayout();
            grpAdversaire.SuspendLayout();
            SuspendLayout();
            // 
            // grpJoueur
            // 
            grpJoueur.Controls.Add(btnPasserTour);
            grpJoueur.Controls.Add(btnAttaquer);
            grpJoueur.Controls.Add(btnJouerCarte);
            grpJoueur.Controls.Add(btnPiocher);
            grpJoueur.Controls.Add(cmbAttaques);
            grpJoueur.Controls.Add(lblEnergies);
            grpJoueur.Controls.Add(lblActif);
            grpJoueur.Controls.Add(lstBanc);
            grpJoueur.Controls.Add(lstMain);
            grpJoueur.Controls.Add(lblDeck);
            grpJoueur.Location = new Point(21, 27);
            grpJoueur.Name = "grpJoueur";
            grpJoueur.Size = new Size(514, 341);
            grpJoueur.TabIndex = 0;
            grpJoueur.TabStop = false;
            grpJoueur.Text = "groupeJoueur";
            // 
            // btnPasserTour
            // 
            btnPasserTour.Location = new Point(326, 259);
            btnPasserTour.Name = "btnPasserTour";
            btnPasserTour.Size = new Size(109, 23);
            btnPasserTour.TabIndex = 10;
            btnPasserTour.Text = "btnPasserTour";
            btnPasserTour.UseVisualStyleBackColor = true;
            btnPasserTour.Click += btnPasserTour_Click;
            // 
            // btnAttaquer
            // 
            btnAttaquer.BackColor = SystemColors.ControlLight;
            btnAttaquer.Location = new Point(285, 219);
            btnAttaquer.Name = "btnAttaquer";
            btnAttaquer.Size = new Size(109, 23);
            btnAttaquer.TabIndex = 9;
            btnAttaquer.Text = "btnAttaquer";
            btnAttaquer.UseVisualStyleBackColor = false;
            btnAttaquer.Click += btnAttaquer_Click;
            // 
            // btnJouerCarte
            // 
            btnJouerCarte.Location = new Point(35, 259);
            btnJouerCarte.Name = "btnJouerCarte";
            btnJouerCarte.Size = new Size(109, 23);
            btnJouerCarte.TabIndex = 8;
            btnJouerCarte.Text = "btnJouerCarte";
            btnJouerCarte.UseVisualStyleBackColor = true;
            btnJouerCarte.Click += btnJouerCarte_Click;
            // 
            // btnPiocher
            // 
            btnPiocher.Location = new Point(173, 259);
            btnPiocher.Name = "btnPiocher";
            btnPiocher.Size = new Size(109, 23);
            btnPiocher.TabIndex = 7;
            btnPiocher.Text = "btnPiocher";
            btnPiocher.UseVisualStyleBackColor = true;
            btnPiocher.Click += btnPiocher_Click;
            // 
            // cmbAttaques
            // 
            cmbAttaques.FormattingEnabled = true;
            cmbAttaques.Location = new Point(36, 220);
            cmbAttaques.Name = "cmbAttaques";
            cmbAttaques.Size = new Size(121, 23);
            cmbAttaques.TabIndex = 6;
            // 
            // lblEnergies
            // 
            lblEnergies.AutoSize = true;
            lblEnergies.Location = new Point(285, 192);
            lblEnergies.Name = "lblEnergies";
            lblEnergies.Size = new Size(64, 15);
            lblEnergies.TabIndex = 4;
            lblEnergies.Text = "lblEnergies";
            // 
            // lblActif
            // 
            lblActif.AutoSize = true;
            lblActif.Location = new Point(36, 192);
            lblActif.Name = "lblActif";
            lblActif.Size = new Size(45, 15);
            lblActif.TabIndex = 3;
            lblActif.Text = "lblActif";
            // 
            // lstBanc
            // 
            lstBanc.FormattingEnabled = true;
            lstBanc.Location = new Point(285, 73);
            lstBanc.Name = "lstBanc";
            lstBanc.Size = new Size(195, 94);
            lstBanc.TabIndex = 2;
            // 
            // lstMain
            // 
            lstMain.FormattingEnabled = true;
            lstMain.Location = new Point(35, 73);
            lstMain.Name = "lstMain";
            lstMain.Size = new Size(195, 94);
            lstMain.TabIndex = 1;
            // 
            // lblDeck
            // 
            lblDeck.AutoSize = true;
            lblDeck.Location = new Point(35, 38);
            lblDeck.Name = "lblDeck";
            lblDeck.Size = new Size(46, 15);
            lblDeck.TabIndex = 0;
            lblDeck.Text = "lblDeck";
            // 
            // grpAdversaire
            // 
            grpAdversaire.Controls.Add(lblActifAdversaire);
            grpAdversaire.Location = new Point(553, 36);
            grpAdversaire.Name = "grpAdversaire";
            grpAdversaire.Size = new Size(235, 332);
            grpAdversaire.TabIndex = 11;
            grpAdversaire.TabStop = false;
            grpAdversaire.Text = "grpAdversaire";
            // 
            // lblActifAdversaire
            // 
            lblActifAdversaire.AutoSize = true;
            lblActifAdversaire.Location = new Point(72, 143);
            lblActifAdversaire.Name = "lblActifAdversaire";
            lblActifAdversaire.Size = new Size(100, 15);
            lblActifAdversaire.TabIndex = 11;
            lblActifAdversaire.Text = "lblActifAdversaire";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(140, 400);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(78, 15);
            lblMessage.TabIndex = 12;
            lblMessage.Text = "labelMessage";
            lblMessage.Click += lblMessage_Click;
            // 
            // FrmPartie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblMessage);
            Controls.Add(grpAdversaire);
            Controls.Add(grpJoueur);
            Name = "FrmPartie";
            Text = "FrmPartie";
            Load += FrmPartie_Load;
            grpJoueur.ResumeLayout(false);
            grpJoueur.PerformLayout();
            grpAdversaire.ResumeLayout(false);
            grpAdversaire.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpJoueur;
        private Button btnJouerCarte;
        private Button btnPiocher;
        private ComboBox cmbAttaques;
        private Label lblEnergies;
        private Label lblActif;
        private ListBox lstBanc;
        private ListBox lstMain;
        private Label lblDeck;
        private GroupBox grpAdversaire;
        private Label lblActifAdversaire;
        private Label lblMessage;
        private Button btnPasserTour;
        private Button btnAttaquer;
    }
}