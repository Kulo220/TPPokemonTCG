using TPpokemon;

namespace PokemonTCG.WinForms
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            // TODO : 1. créer un deck pour le joueur : au moins 1 CartePokemon avec une
            // Attaque (ajoutée à sa liste Attaques) et 4 CarteEnergie
            List<Carte> deckJoueur = new List<Carte>();
            CartePokemon pikachu = new CartePokemon("Pikachu", "Souris électrique", Rarete.Commune, 60, TypePokemon.Electrik);
            pikachu.Attaques.Add(new Attaque("Éclair", 20, 1));
            deckJoueur.Add(pikachu);

            for (int i = 0; i < 4; i++)
            {
                deckJoueur.Add(new CarteEnergie("Énergie Électrique", TypePokemon.Electrik));
            }

            // TODO : 2. créer un deck pour l'adversaire avec au moins 1 CartePokemon
            List<Carte> deckAdversaire = new List<Carte>();
            CartePokemon salameche = new CartePokemon("Salamèche", "Lézard", Rarete.Commune, 70, TypePokemon.Feu);
            salameche.Attaques.Add(new Attaque("Flammèche", 30, 1));
            deckAdversaire.Add(salameche);

            // TODO : 3. créer les deux Joueur
            Joueur joueur = new Joueur("Sacha", deckJoueur);
            Joueur adversaire = new Joueur("Régis", deckAdversaire);

            // TODO : 4. l'adversaire pioche et joue son Pokémon (il doit avoir un
            // Pokémon actif dès le début de la partie)
            adversaire.Piocher();
            adversaire.JouerCarte(salameche);

            // TODO : 5. remplacer la ligne ci-dessous par
            // Application.Run(new FrmPartie(joueur, adversaire))
            Application.Run(new FrmPartie(joueur, adversaire));
        }
    }
}