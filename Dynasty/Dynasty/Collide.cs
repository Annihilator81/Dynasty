using Dynasty.Entités;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dynasty
{
    public class Collide : Game1
    {
        public bool CollideWithMob { get; set; }
        public TimeSpan Time;
        public List<int> ListMonstresTouchés { get; set; }
        public bool IsCollideWithScreen(Joueur joueur)
        {
            //Gauche
            if (joueur.RectangleDestination.X <= 0)
            {
                Game1.map.X--;
                joueur.RectangleDestination.X = Game1.WindowWidth - 50;
                return true;
            }
            //haut
            if (joueur.RectangleDestination.Y <= 0)
            {
                Game1.map.Y++;
                joueur.RectangleDestination.Y = Game1.WindowHeight - 50;
                return true;
            }
            //bas
            if (joueur.RectangleDestination.Y + 32
                >= Game1.WindowHeight)
            {
                Game1.map.Y--;
                joueur.RectangleDestination.Y = 20;
                return true;
            }
            //droite
            if (joueur.RectangleDestination.X + 32
                >= Game1.WindowWidth)
            {
                Game1.map.X++;
                joueur.RectangleDestination.X = 20;
                return true;
            }
            return false;
        }
        public TimeSpan IsCollideWithMob(GameTime gametime)
        {
            int i = 0;
            foreach (var mob in map.ListMonstres)
            {
                if (joueur.RectangleDestination.Intersects(mob.RectangleDestination))
                {
                  //  ListMonstresTouchés.Add(i);
                    joueur.Vie -= mob.Force;
                    joueur.Texture = Game1.FrameHeroDegat;

                    //On vérifie ou étais le perso comparé au monstre
                    //Pour éloigné le perso du monstre pour pas qu'il meurt instantannément + effet de recul
                    if (joueur.RectangleDestination.X - mob.RectangleDestination.X <= 0)
                    {
                        joueur.RectangleDestination.X -= 40;
                    }
                    if (joueur.RectangleDestination.X - mob.RectangleDestination.X >= 0)
                    {
                        joueur.RectangleDestination.X += 40;
                    }
                    if (joueur.RectangleDestination.Y - mob.RectangleDestination.Y <= 0)
                    {
                        joueur.RectangleDestination.Y -= 40;
                    }
                    if (joueur.RectangleDestination.Y - mob.RectangleDestination.Y >= 0)
                    {
                        joueur.RectangleDestination.Y += 40;
                    }
                    Time = gametime.TotalGameTime;
                }
                i++;
            }
            return Time;
        }
        public TimeSpan IsCollideWithSword(GameTime gametime)
        {
            foreach (var mob in map.ListMonstres)
            {
                if (joueur.RectangleDestinationAttak.Intersects(mob.RectangleDestination))
                {
                    mob.Vie -= joueur.Force;
                   // mob.Texture =
                    //a rajouter
                    if (joueur.RectangleDestinationAttak.X - mob.RectangleDestination.X <= 0)
                    {
                        mob.RectangleDestination.X -= 40;
                    }
                    if (joueur.RectangleDestinationAttak.X - mob.RectangleDestination.X >= 0)
                    {
                        mob.RectangleDestination.X += 40;
                    }
                    if (joueur.RectangleDestinationAttak.Y - mob.RectangleDestination.Y <= 0)
                    {
                        mob.RectangleDestination.Y -= 40;
                    }
                    if (joueur.RectangleDestinationAttak.Y - mob.RectangleDestination.Y >= 0)
                    {
                        mob.RectangleDestination.Y += 40;
                    }
                    Time = gametime.TotalGameTime;
                }
            }
            return Time;

        }
    }
}
