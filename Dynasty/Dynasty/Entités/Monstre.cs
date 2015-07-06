using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dynasty.Entités
{
    public class Monstre : Personnage
    {
        static Random generator;
        TimeSpan Time;
        public int Deplacement { get; set; }
        public Monstre(string nom, int vie, int force, int vitesse,
            int PosX, int PosY, Texture2D texture) : base (nom, vie, force, vitesse, PosX, PosY)
        {
            Deplacement = 100;
            Texture = texture;
            RectangleDestination = new Rectangle(PosX, PosY, 32, 32);
            generator = new Random(DateTime.Now.Millisecond);
        }
        public void Move(GameTime gametime)
        {

            //A modifier pour qu'ils ne bougent pas tous, mais certains à la fois
            //Ajouter la gestion des sprites (ici il se téléporte)
            //Améliorer le rand()
            //Modifier le "Déplacement" ???
            if (gametime.TotalGameTime.Subtract(Time).Seconds >= 3)
            {
                if (generator.Next(0, 1000) <= 500)
                {
                    RectangleDestination.X += generator.Next(-Deplacement, Deplacement);
                    Time = gametime.TotalGameTime;
                }
                else
                {
                    RectangleDestination.Y += generator.Next(-Deplacement, Deplacement);
                    Time = gametime.TotalGameTime;
                }
            }
        }
    }
}
