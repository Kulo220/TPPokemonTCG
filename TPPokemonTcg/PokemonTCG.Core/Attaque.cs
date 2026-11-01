using System;
using System.Collections.Generic;
using System.Text;

namespace TPpokemon
{
    public class Attaque
    {
        public string Nom { get; set; }
        public int Degats { get; set; }
        public int Cout { get; set; }

        public Attaque(string nom, int degats, int cout)
        {
            Nom = nom;
            Degats = degats;
            Cout = cout;
        }

        public override string ToString() => $"Nom : {Nom} Dégats : {Degats} Cout : {Cout}";
    }
}
