using Dynasty.Entités;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dynasty
{
    public class MapConstructor
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Path { get; set; }
        public Dictionary<string, Texture2D> Ressources { get; set; }
        public Dictionary<string, Monstre> Monstres;
        public List<string> ListTexture { get; set; }
        public List<string> ListElement { get; set; }
        public List<Monstre> ListMonstres { get; set; }
        public bool MapIsLoad = false;
        public MapConstructor(int x, int y)
        {
            X = x;
            Y = y;
            ListTexture = new List<string>();
            ListElement = new List<string>();
            ListMonstres = new List<Monstre>();
            Monstres = new Dictionary<string, Monstre>();
            Ressources = new Dictionary<string, Texture2D>();

            //Add toute les textures ici//
            //Seulement du test pour now//
            Ressources.Add("001", Game1.test);
            Ressources.Add("002", Game1.test3);
            Ressources.Add("003", Game1.TextureHerbe);
            Ressources.Add("004", Game1.TexturePierreSol);
            //Add tout les monstres ici!//
            //Seulement du test pour now//
            Monstres.Add("001", new Monstre("Troll", 100, 5, 10, 0, 0, Game1.textureMonstre));
        }
        public void ReadTheMap()
        {
            MapIsLoad = true;
            ListTexture.RemoveRange(0, ListTexture.Count);
            ListElement.RemoveRange(0, ListElement.Count);
            Path = Directory.GetCurrentDirectory() + @"\Map\" + X + "," + Y + ".txt";
            string line;
            StreamReader sr = new StreamReader(File.Open(Path, FileMode.Open));
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Substring(0, 7) != "monstre")
                {
                    for (int i = 0; i < line.Length; i += 3)
                    {
                        ListTexture.Add(line.Substring(i, 3));
                    }
                }
                else
                {
                    for (int i = 9; i < line.Length; i += 9)
                    {
                        ListElement.Add(line.Substring(i, 9));
                    }
                }
            }
            sr.Close();
   
        }
        public void Draw(GameTime gameTime)
        {
            int index = 0;

            for (int y = 0; y < Game1.WindowHeight; y += 32)
            {
                for (int i = 0; i < Game1.WindowWidth; i += 32)
                {
                    Game1.spriteBatch.Draw(Ressources[ListTexture[index]], new Vector2(i, y), Color.White);
                    index ++;
                }
            }
            if (MapIsLoad == true)
            {
                ListMonstres.RemoveRange(0, ListMonstres.Count);
                for (int i = 0; i < ListElement.Count; i++)
                {
                    //Pour éviter de faire 5 fois Index+Substring
                    string element = ListElement[i].Substring(0, 3);
                    //
                    ListMonstres.Add(new Monstre(
                        Monstres[element].Nom,
                        Monstres[element].Vie,
                        Monstres[element].Force,
                        Monstres[element].Vitesse,
                        int.Parse(ListElement[i].Substring(3, 3)),
                        int.Parse(ListElement[i].Substring(6, 3)),
                        Monstres[element].Texture));
                        
                        foreach (var mob in ListMonstres)
                        {
                            Game1.spriteBatch.Draw(mob.Texture, mob.RectangleDestination, Color.White);
                        }
                }
                MapIsLoad = false;
            }
            else
            {
                    foreach(var mob in ListMonstres)
                    {
                        mob.Move(gameTime);
                        mob.DrawAnimatedEntity(Game1.spriteBatch);
                    }         
            }
        }
    }
}