using System;
using System.Collections.Generic;
using System.Text;

namespace TPpokemon
{
    public class CarteDresseur : Carte
    {
        public string Categorie { get; set; }
        public string Effet { get; set; }


        public CarteDresseur(string nom, Rarete rarete, string categorie, string effet)
            : base(nom, effet, rarete)
        {
            Categorie = categorie;
            Effet = effet;
        }

    }
}
