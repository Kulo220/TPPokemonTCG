using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPpokemon;

namespace Methode_Situation_ResultatAttendu
{
    // 6 1er test
    [TestClass]
    public class JoueurTests
    {
        private Joueur _joueur = null!;
        private Joueur _adversaire = null!;
        private CartePokemon _pikachu = null!;
        private Attaque _eclair = null!;

        [TestInitialize]
        public void Initialiser()
        {
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
        }

        [TestMethod]
        public void Piocher_DeckRempli_AjouteLaCarteALaMain()
        {
            Carte carte = _joueur.Piocher();
            Assert.AreSame(_pikachu, carte);
            Assert.AreEqual(1, _joueur.Main.Count);
            Assert.AreEqual(2, _joueur.Deck.Count);
        }

        [TestMethod]
        public void Piocher_DeuxFoisDansLeMemeTour_LeveUneException()
        {
            _joueur.Piocher();
            Assert.Throws<InvalidOperationException>(() => _joueur.Piocher());
        }

        [TestMethod]
        public void Piocher_ApresPasserSonTour_EstAutorise()
        {
            _joueur.Piocher();
            _joueur.PasserSonTour();
            _joueur.Piocher();
            Assert.AreEqual(2, _joueur.Main.Count);
        }

        [TestMethod]
        public void JouerCarte_PremierPokemon_DevientPokemonActif()
        {
            _joueur.Piocher();
            _joueur.JouerCarte(_pikachu);
            Assert.AreSame(_pikachu, _joueur.PokemonActif);
            Assert.AreEqual(0, _joueur.Main.Count);
        }

        [TestMethod]
        public void JouerCarte_DeuxiemeEnergieDansLeTour_LeveUneException()
        {
            _joueur.Piocher();
            _joueur.JouerCarte(_pikachu);
            _joueur.PasserSonTour();
            Carte energie1 = _joueur.Piocher();
            _joueur.PasserSonTour();
            Carte energie2 = _joueur.Piocher();
            _joueur.JouerCarte(energie1);
            Assert.Throws<InvalidOperationException>(() => _joueur.JouerCarte(energie2));
        }

        [TestMethod]
        public void Attaquer_EnergieSuffisante_RetireLesPVAdverses()
        {
            _joueur.Piocher();
            _joueur.JouerCarte(_pikachu);
            _joueur.PasserSonTour();
            _joueur.JouerCarte(_joueur.Piocher()); // énergie attachée
            int degats = _joueur.Attaquer(_eclair, _adversaire);
            Assert.AreEqual(20, degats);
            Assert.AreEqual(50, _adversaire.PokemonActif!.PointsDeVie);
        }

        [TestMethod]
        public void Attaquer_SansEnergie_LeveUneException()
        {
            _joueur.Piocher();
            _joueur.JouerCarte(_pikachu);
            Assert.Throws<InvalidOperationException>(() => _joueur.Attaquer(_eclair, _adversaire));
        }

        // 5 dernier test

        [TestMethod]
        public void JouerCarte_BancPlein_LeveUneException()
        {
            // Arrange : un joueur avec 1 actif et 5 sur le banc
            _joueur.Piocher();
            _joueur.JouerCarte(_pikachu); // devient actif

            for (int i = 0; i < 5; i++)
            {
                var p = new CartePokemon($"Pikachu{i}", "Test", Rarete.Commune, 50, TypePokemon.Electrik);
                _joueur.Deck.Insert(0, p);
                _joueur.PasserSonTour();
                _joueur.Piocher();
                _joueur.JouerCarte(p);
            }

            var sixiemePokemon = new CartePokemon("Sixieme", "Test", Rarete.Commune, 50, TypePokemon.Electrik);
            _joueur.Deck.Insert(0, sixiemePokemon);
            _joueur.PasserSonTour();
            _joueur.Piocher();

            // Act & Assert : poser un 6e Pokémon sur le banc doit lever InvalidOperationException
            Assert.Throws<InvalidOperationException>(() => _joueur.JouerCarte(sixiemePokemon));
        }

        [TestMethod]
        public void JouerCarte_CarteAbsenteDeLaMain_LeveUneException()
        {
            // Arrange
            var carteHorsMain = new CartePokemon("Mewtwo", "Légendaire", Rarete.UltraRare, 120, TypePokemon.Psy);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _joueur.JouerCarte(carteHorsMain));
        }

        [TestMethod]
        public void Attaquer_SansPokemonActif_LeveUneException()
        {
            // Arrange : le joueur n'a pas posé son Pokémon actif
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _joueur.Attaquer(_eclair, _adversaire));
        }

        [TestMethod]
        public void RecevoirDegats_SuperieurAuxPV_MetPVA0EtEstKOVrai()
        {
            // Arrange
            var pokemon = new CartePokemon("Pikachu", "Souris", Rarete.Commune, 60, TypePokemon.Electrik);

            // Act
            pokemon.RecevoirDegats(999);

            // Assert
            Assert.AreEqual(0, pokemon.PointsDeVie);
            Assert.IsTrue(pokemon.EstKO);
        }

        [TestMethod]
        public void RecevoirDegats_DegatsNegatifs_LeveArgumentOutOfRangeException()
        {
            // Arrange
            var pokemon = new CartePokemon("Pikachu", "Souris", Rarete.Commune, 60, TypePokemon.Electrik);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => pokemon.RecevoirDegats(-5));
        }
    }
}

