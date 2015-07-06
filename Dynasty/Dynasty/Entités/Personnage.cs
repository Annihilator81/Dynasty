using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Dynasty.Entités
{
    public class Personnage : EntityObject
    {
        public string Nom { get; set; }
        public int Vie { get; set; }
        public int Force { get; set; }
        public int Vitesse { get; set; }
        public Personnage(string nom, int vie, int force, int vitesse,
            int PosX, int PosY) : base (PosX, PosY)
        {
            Nom = nom;
            Vie = vie;
            Force = force;
            Vitesse = vitesse;
        }
    }
}
