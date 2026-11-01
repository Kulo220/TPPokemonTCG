using PokemonTCG.WinForms;
using System;
using System.Collections.Generic;
using System.Text;
using TPpokemon;

namespace PokemonTCG.Tests
{
    public class FrmPartieTests
    {
        private Joueur _joueur;
        private Joueur _adversaire;
        private CartePokemon _pikachu;
        private Attaque _eclair;
        private FrmPartie _form;
        [TestInitialize]
        public void Initialiser()
        {
            // Même jeu de données que JoueurTests
            _pikachu = new CartePokemon("Pikachu", "Souris électrique",
            Rarete.Commune, 60, TypePokemon.Electrik);
            _eclair = new Attaque("Éclair", 20, 1);
            _pikachu.Attaques.Add(_eclair);
            
            var deck = new List<Carte>
            {
             _pikachu,
                new CarteEnergie("Énergie Électrik", TypePokemon.Electrik),
                new CarteEnergie("Énergie Électrik", TypePokemon.Electrik)
            };
            _joueur = new Joueur("Sacha", deck);
            var salameche = new CartePokemon("Salamèche", "Lézard de feu",
            Rarete.Commune, 70, TypePokemon.Feu);
            _adversaire = new Joueur("Régis", new List<Carte> { salameche });
            _adversaire.Piocher();
            _adversaire.JouerCarte(salameche);
            // Le formulaire reçoit les joueurs préparés puis est affiché :
            // PerformClick() ne fait rien sur un formulaire non affiché.
            _form = new FrmPartie(_joueur, _adversaire);
            _form.Show();
        }
        [TestCleanup]
        public void Nettoyer()
        {
            _form.Dispose(); // libère le formulaire après chaque test
        }
        // Aide : retrouver un contrôle du formulaire à partir de son nom
        private T Trouver<T>(string nom) where T : Control
        {
            Control[] trouves = _form.Controls.Find(nom, true);
            Assert.AreEqual(1, trouves.Length, $"Contrôle introuvable : {nom}");
            return (T)trouves[0];
        }
        [TestMethod]
        public void Piocher_Clic_AjouteLaCarteALaListeMain()
        {
            Trouver<Button>("btnPiocher").PerformClick();
            Assert.AreEqual(1, Trouver<ListBox>("lstMain").Items.Count);
            Assert.AreEqual("Deck : 2 carte(s)", Trouver<Label>("lblDeck").Text);
        }
        [TestMethod]
        public void Piocher_DeuxClics_AfficheUnMessageDErreur()
        {
            Button btnPiocher = Trouver<Button>("btnPiocher");
            btnPiocher.PerformClick();
            btnPiocher.PerformClick();
            Assert.AreEqual(1, Trouver<ListBox>("lstMain").Items.Count);
            Assert.AreEqual(Color.Red, Trouver<Label>("lblMessage").ForeColor);
        }
        [TestMethod]
        public void JouerCarte_PokemonSelectionne_DevientPokemonActif()
        {
            Trouver<Button>("btnPiocher").PerformClick();
            ListBox lstMain = Trouver<ListBox>("lstMain");
            lstMain.SelectedIndex = 0;
            Trouver<Button>("btnJouerCarte").PerformClick();
            Assert.AreSame(_pikachu, _joueur.PokemonActif);
            Assert.AreEqual(0, lstMain.Items.Count);
            StringAssert.Contains(Trouver<Label>("lblActif").Text, "Pikachu");
        }
        [TestMethod]
        public void JouerCarte_SansSelection_AfficheUnMessageDErreur()
        {
            // TODO : 1. cliquer sur btnPiocher pour avoir une carte dans la main
            Trouver<Button>("btnPiocher").PerformClick();

            // TODO : 2. SANS sélectionner de carte, cliquer sur btnJouerCarte
            Trouver<ListBox>("lstMain").SelectedIndex = -1;
            Trouver<Button>("btnJouerCarte").PerformClick();

            // TODO : 3. vérifier que la main contient toujours 1 carte (lstMain)
            Assert.AreEqual(1, Trouver<ListBox>("lstMain").Items.Count);

            // TODO : 4. vérifier que lblMessage est affiché en rouge
            Assert.AreEqual(Color.Red, Trouver<Label>("lblMessage").ForeColor);
        }

        [TestMethod]
        public void Attaquer_EnergieSuffisante_MetAJourLAdversaire()
        {
            // TODO : 1. piocher puis jouer Pikachu (le sélectionner dans lstMain)
            Trouver<Button>("btnPiocher").PerformClick();
            ListBox lstMain = Trouver<ListBox>("lstMain");
            lstMain.SelectedIndex = 0;
            Trouver<Button>("btnJouerCarte").PerformClick();

            // TODO : 2. cliquer sur btnPasserTour, puis piocher et jouer une énergie
            Trouver<Button>("btnPasserTour").PerformClick();
            Trouver<Button>("btnPiocher").PerformClick();
            lstMain.SelectedIndex = 0;
            Trouver<Button>("btnJouerCarte").PerformClick();

            // TODO : 3. sélectionner la première attaque dans cmbAttaques
            // (SelectedIndex = 0) puis cliquer sur btnAttaquer
            ComboBox cmbAttaques = Trouver<ComboBox>("cmbAttaques");
            cmbAttaques.SelectedIndex = 0;
            Trouver<Button>("btnAttaquer").PerformClick();

            // TODO : 4. vérifier que le Pokémon actif de adversaire a 50 PV
            Assert.AreEqual(50, _adversaire.PokemonActif.PointsDeVie);

            // TODO : 5. vérifier que lblActifAdversaire contient "PV: 50"
            StringAssert.Contains(Trouver<Label>("lblActifAdversaire").Text, "PV : 50");
        }

        [TestMethod]
        public void Attaquer_SansAttaqueSelectionnee_AfficheUnMessageDErreur()
        {
            // TODO : 1. mettre Pikachu en jeu (piocher, sélectionner, jouer)
            Trouver<Button>("btnPiocher").PerformClick();
            ListBox lstMain = Trouver<ListBox>("lstMain");
            lstMain.SelectedIndex = 0;
            Trouver<Button>("btnJouerCarte").PerformClick();

            // TODO : 2. cliquer sur btnAttaquer sans rien sélectionner dans cmbAttaques
            Trouver<ComboBox>("cmbAttaques").SelectedIndex = -1;
            Trouver<Button>("btnAttaquer").PerformClick();

            // TODO : 3. vérifier que les PV de l'adversaire n'ont pas changé (70)
            Assert.AreEqual(70, _adversaire.PokemonActif.PointsDeVie);

            // TODO : 4. vérifier que lblMessage est affiché en rouge
            Assert.AreEqual(Color.Red, Trouver<Label>("lblMessage").ForeColor);
        }

        [TestMethod]
        public void PasserSonTour_Clic_AutorisePiocherAuTourSuivant()
        {
            // TODO : 1. cliquer sur btnPiocher, puis sur btnPasserTour, puis à nouveau sur btnPiocher
            Trouver<Button>("btnPiocher").PerformClick();
            Trouver<Button>("btnPasserTour").PerformClick();
            Trouver<Button>("btnPiocher").PerformClick();

            // TODO : 2. vérifier que lstMain contient 2 cartes
            Assert.AreEqual(2, Trouver<ListBox>("lstMain").Items.Count);

            // TODO : 3. vérifier que lblDeck affiche "Deck: 1 carte(s)"
            Assert.AreEqual("Deck : 1 carte(s)", Trouver<Label>("lblDeck").Text);
        }
    }

}

