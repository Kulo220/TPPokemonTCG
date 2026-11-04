using System;
using System.Collections.Generic;
using System.Text;

namespace TPpokemon
{
    public class CartePokemon  :Carte
    {
        public int PointsDeVie { get; set; }
        public TypePokemon Type { get; set; }
        public int EnergiesAttachees { get; set; }
        public List<Attaque> Attaques { get; set; } = new List<Attaque>();
        string Rarete { get; set; }
        public bool EstKO
        {
            get
            {
                // TODO : retourner vrai si le Pokémon n'a plus de points de vie
                if (PointsDeVie <= 0)
                {
                    return true;
                }
                return false;
            }
        }
        public CartePokemon(string nom, string description, Rarete rarete, int pv, TypePokemon type)
            : base(nom, description, rarete) // Nom, Description et Rarete sont transmis et initialisés par Carte
        {
            // TODO : initialiser uniquement les attributs propres à CartePokemon
            PointsDeVie = pv;
            Type = type;
        }

        public void AttacherEnergie()
        {
            // TODO : ajouter 1 au nombre d'énergies attachées
            EnergiesAttachees++;
        }

        public void RecevoirDegats(int degats)
        {
            // TODO : 1. si degats est négatif, lever une ArgumentOutOfRangeException
            // 2. retirer les dégâts aux points de vie
            // 3. les PV ne doivent jamais passer sous 0 (voir Math.Max)
            if (degats < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(degats), "Les dégâts ne peuvent pas être négatifs.");
            }

            PointsDeVie = Math.Max(0, PointsDeVie - degats);
        }

        public override string Decrire()
        {
            // On appelle base.Decrire() (sans paramètre) pour récupérer "Nom (Rarete) : Description",
            // puis on concatène les infos spécifiques du Pokémon, et on retourne le tout.
            return $"{base.Decrire()} | PV : {PointsDeVie} | Type : {Type}";
        }
    }
}
