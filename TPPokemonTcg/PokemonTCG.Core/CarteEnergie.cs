using System;
using System.Collections.Generic;
using System.Text;

namespace TPpokemon
{
    public class CarteEnergie : Carte
    {
        public TypePokemon Type { get; set; }



        public CarteEnergie(string nom, TypePokemon type) : base(nom, "Carte énergie", Rarete.Commune)
                {
            Type = type;

        }
    }
}
