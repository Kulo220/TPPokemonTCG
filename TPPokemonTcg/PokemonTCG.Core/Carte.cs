using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TPpokemon;

namespace TPpokemon
{
    public abstract class Carte
    {
        public string Nom { get; set; }
        public string Description { get; set; }
        public Rarete Rarete { get; set; }
        protected Carte(string nom, string description, Rarete rarete)
        {
            Nom = nom;
            Description = description;
            Rarete = rarete;
        }
        public virtual string Decrire()
        {
            // TODO : retourner une chaîne au format "Nom (Rarete) : Description"
            // ex : "Pikachu (Commune) : Souris électrique"

            return $"{Nom} ({Rarete}) : {Description} ";

        }
    }
}