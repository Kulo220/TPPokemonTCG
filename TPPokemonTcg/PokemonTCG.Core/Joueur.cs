using TPpokemon;

namespace TPpokemon 
{
    public class Joueur
    {
        public const int TailleBancMax = 5;
        public string Nom { get; set; }
        public List<Carte> Deck { get; set; }
        public List<Carte> Main { get; set; } = new List<Carte>();
        public CartePokemon PokemonActif { get; private set; }
        public List<CartePokemon> Banc { get; set; } = new List<CartePokemon>();

        // 2 attributs privés pour suivre l'état du tour
        private bool _aPiocheCeTour = false;
        private bool _energieAttacheeCeTour = false;

        public Joueur(string nom, List<Carte> deck)
        {
            // Initialisation de Nom et Deck
            Nom = nom;
            Deck = deck;
        }

        public Carte Piocher()
        {
            // TODO : 1. lever une InvalidOperationException si déjà pioché ce tour

            if (_aPiocheCeTour)
            {
                throw new InvalidOperationException("Le joueur a déjà pioché une carte ce tour.");
            }

            // 2. Lever une exception si le deck est vide
            if (Deck.Count == 0)
            {
                throw new InvalidOperationException("Le deck est vide.");
            }

            // 3. Récupérer la première carte (index 0) et la retirer du deck
            Carte carte = Deck[0];
            Deck.RemoveAt(0);

            // 4. L'ajouter à la main
            Main.Add(carte);

            // 5. Mémoriser que le joueur a pioché ce tour
            _aPiocheCeTour = true;

            // 6. Retourner la carte piochée
            return carte;
        }

        public void JouerCarte(Carte carte)
        {
            // 1. Lever une exception si la carte n'est pas dans la main
            if (!Main.Contains(carte))
            {
                throw new InvalidOperationException("La carte n'est pas dans la main.");
            }

            // 2. Traitement selon le type de la carte
            switch (carte)
            {
                case CartePokemon pokemon:
                    if (PokemonActif == null)
                    {
                        PokemonActif = pokemon;
                    }
                    else
                    {
                        if (Banc.Count >= TailleBancMax)
                        {
                            throw new InvalidOperationException("Le banc est déjà plein.");
                        }
                        Banc.Add(pokemon);
                    }
                    break;

                case CarteEnergie _:
                    if (PokemonActif == null)
                    {
                        throw new InvalidOperationException("Il n'y a pas de Pokémon actif sur lequel attacher l'énergie.");
                    }
                    if (_energieAttacheeCeTour)
                    {
                        throw new InvalidOperationException("Une énergie a déjà été attachée ce tour.");
                    }
                    PokemonActif.AttacherEnergie();
                    _energieAttacheeCeTour = true;
                    break;

                case CarteDresseur dresseur:
                    Console.WriteLine(dresseur.Effet);
                    break;

                default:
                    throw new InvalidOperationException("Type de carte non reconnu.");
            }

            // 3. Retirer la carte de la main (uniquement si aucune exception levée plus haut)
            Main.Remove(carte);
        }

        public int Attaquer(Attaque attaque, Joueur adversaire)
        {
            // 1. Lever une exception si l'un des deux joueurs n'a pas de Pokémon actif
            if (PokemonActif == null || adversaire.PokemonActif == null)
            {
                throw new InvalidOperationException("Les deux joueurs doivent avoir un Pokémon actif.");
            }

            // 2. Lever une ArgumentException si l'attaque n'appartient pas au Pokémon actif
            if (!PokemonActif.Attaques.Contains(attaque))
            {
                throw new ArgumentException("L'attaque sélectionnée n'appartient pas au Pokémon actif.");
            }

            // 3. Lever une exception si les énergies attachées sont inférieures au coût
            if (PokemonActif.EnergiesAttachees < attaque.Cout)
            {
                throw new InvalidOperationException("Le Pokémon n'a pas assez d'énergies attachées pour lancer cette attaque.");
            }

            // 4. Infliger les dégâts au Pokémon adverse
            adversaire.PokemonActif.RecevoirDegats(attaque.Degats);

            // 5. Retourner les dégâts infligés
            return attaque.Degats;
        }

        public void PasserSonTour()
        {
            // Réinitialisation des actions limitées par tour
            _aPiocheCeTour = false;
            _energieAttacheeCeTour = false;
        }
    }
}