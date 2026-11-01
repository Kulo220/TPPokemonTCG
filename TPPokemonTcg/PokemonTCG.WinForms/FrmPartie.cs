using System;
using System.Drawing;
using System.Windows.Forms;
using TPpokemon;

namespace PokemonTCG.WinForms
{
    public partial class FrmPartie : Form
    {
        private readonly Joueur _joueur;
        private readonly Joueur _adversaire;

        public FrmPartie(Joueur joueur, Joueur adversaire)
        {
            InitializeComponent();
            // TODO : 1. mémoriser joueur et adversaire dans les attributs privés
            _joueur = joueur;
            _adversaire = adversaire;

            // TODO : 2. afficher le nom du joueur dans le texte de grpJoueur
            grpJoueur.Text = _joueur.Nom;
            grpAdversaire.Text = _adversaire.Nom;

            // TODO : 3. définir DisplayMember = "Nom" sur lstMain, lstBanc et
            // cmbAttaques (chaque liste affichera la propriété Nom des objets)
            lstMain.DisplayMember = "Nom";
            lstBanc.DisplayMember = "Nom";
            cmbAttaques.DisplayMember = "Nom";

            // TODO : 4. appeler ActualiserAffichage()
            ActualiserAffichage();
        }

        private void ActualiserAffichage()
        {
            // TODO : 1. lblDeck : "Deck : n carte(s)"
            lblDeck.Text = $"Deck : {_joueur.Deck.Count} carte(s)";

            // TODO : 2. lstMain : vider la liste puis y ajouter les cartes de la main
            // (Items.AddRange avec Main.ToArray())
            lstMain.Items.Clear();
            lstMain.Items.AddRange(_joueur.Main.ToArray());

            // TODO : 3. lstBanc : même principe avec le banc
            lstBanc.Items.Clear();
            lstBanc.Items.AddRange(_joueur.Banc.ToArray());

            // TODO : 4. lblActif : Decrire() du Pokémon actif, ou "Aucun Pokémon actif"
            lblActif.Text = _joueur.PokemonActif != null
                ? _joueur.PokemonActif.Decrire()
                : "Aucun Pokémon actif";

            // TODO : 5. lblEnergies : "Énergies : n" (0 sans Pokémon actif)
            lblEnergies.Text = _joueur.PokemonActif != null
                ? $"Énergies : {_joueur.PokemonActif.EnergiesAttachees}"
                : "Énergies : 0";

            // TODO : 6. cmbAttaques : vider puis y ajouter les attaques du Pokémon actif
            cmbAttaques.Items.Clear();
            if (_joueur.PokemonActif != null)
            {
                cmbAttaques.Items.AddRange(_joueur.PokemonActif.Attaques.ToArray());
            }

            // TODO : 7. lblActifAdversaire : comme lblActif, pour l'adv
            lblActifAdversaire.Text = _adversaire.PokemonActif != null
                ? _adversaire.PokemonActif.Decrire()
                : "Aucun Pokémon actif";
        }

        private void AfficherMessage(string texte, bool erreur)
        {
            // TODO : afficher le texte dans lblMessage, en rouge si erreur, en vert sinon
            lblMessage.Text = texte;
            lblMessage.ForeColor = erreur ? Color.Red : Color.Green;
        }

        private void FrmPartie_Load(object sender, EventArgs e)
        {
            ActualiserAffichage();
        }

        private void btnAttaquer_Click(object sender, EventArgs e)
        {
            // TODO : 1. si cmbAttaques.SelectedItem est null : message d'erreur
            // puis return
            if (cmbAttaques.SelectedItem == null)
            {
                AfficherMessage("Veuillez sélectionner une attaque.", true);
                return;
            }

            // TODO : 2. récupérer l'attaque sélectionnée (conversion en Attaque)
            Attaque attaque = (Attaque)cmbAttaques.SelectedItem;

            // TODO : 3. dans un try, appeler _joueur.Attaquer(attaque, _adversaire)
            // et afficher les dégâts infligés ; si le Pokémon adverse
            // est K.O., l'indiquer dans le message
            // TODO : 4. attraper InvalidOperationException et ArgumentException
            try
            {
                int degats = _joueur.Attaquer(attaque, _adversaire);
                string message = $"{_joueur.Nom} utilise {attaque.Nom} et inflige {degats} dégâts !";

                if (_adversaire.PokemonActif == null || _adversaire.PokemonActif.EstKO)
                {
                    message += " Le Pokémon adverse est K.O. !";
                }

                AfficherMessage(message, false);
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is ArgumentException)
            {
                AfficherMessage(ex.Message, true);
            }

            // TODO : 5. actualiser l'affichage
            ActualiserAffichage();
        }

        private void btnPasserTour_Click(object sender, EventArgs e)
        {
            // TODO : 1. appeler _joueur.PasserSonTour()
            _joueur.PasserSonTour();

            // TODO : 2. afficher le message "Tour terminé."
            AfficherMessage("Tour terminé.", false);

            // TODO : 3. actualiser
            ActualiserAffichage();
        }

        private void btnPiocher_Click(object sender, EventArgs e)
        {
            // TODO : 1. dans un try, appeler _joueur.Piocher() et afficher un
            // message de succès contenant le nom de la carte piochée
            // TODO : 2. attraper InvalidOperationException : afficher ex.Message en erreur
            try
            {
                Carte cartePiochee = _joueur.Piocher();
                AfficherMessage($"Carte piochée : {cartePiochee.Nom}", false);
            }
            catch (InvalidOperationException ex)
            {
                AfficherMessage(ex.Message, true);
            }

            // TODO : 3. actualiser l'affichage
            ActualiserAffichage();
        }

        private void btnJouerCarte_Click(object sender, EventArgs e)
        {
            // TODO : 1. si lstMain.SelectedItem est null : message d'erreur
            // (ex : "Sélectionnez une carte.") puis return
            if (lstMain.SelectedItem == null)
            {
                AfficherMessage("Sélectionnez une carte.", true);
                return;
            }

            // TODO : 2. récupérer la carte sélectionnée (conversion en Carte)
            Carte carte = (Carte)lstMain.SelectedItem;

            // TODO : 3. dans un try, appeler _joueur.JouerCarte(carte) et afficher
            // un message de succès ; attraper InvalidOperationException
            try
            {
                _joueur.JouerCarte(carte);
                AfficherMessage($"Carte jouée : {carte.Nom}", false);
            }
            catch (InvalidOperationException ex)
            {
                AfficherMessage(ex.Message, true);
            }

            // TODO : 4. actualiser l'affichage
            ActualiserAffichage();
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {
        }
    }
}