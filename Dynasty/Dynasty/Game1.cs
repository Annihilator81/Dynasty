using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Dynasty.Entités;
using System;

namespace Dynasty
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public SpriteFont spriteFont;
        public static Joueur joueur;
        public Collide collide;
        public Controller controller;
        public static int WindowWidth;
        public static int WindowHeight;
        public static MapConstructor map;
        bool GameIsStart = true;
        TimeSpan Time;

        //Textures
        public static Texture2D textureMonstre;
        public static Texture2D TextureHerbe;
        public static Texture2D TexturePierreSol;
        public static Texture2D FrameHeroDegat;
        public static Texture2D FrameHero;

        public static Texture2D test { get; set; }
        public static Texture2D test3 { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

           // graphics.IsFullScreen = true;
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            WindowWidth = GraphicsDevice.Viewport.Width;
            WindowHeight = GraphicsDevice.Viewport.Height;
            joueur = new Joueur("Pierre", 100, 100, 3, 250, 250);
            collide = new Collide();
            controller = new Controller();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //Textures Héro
            joueur.Texture = Content.Load<Texture2D>("FrameHero");
            joueur.TextureAttaque = Content.Load<Texture2D>("Sword");
            FrameHeroDegat = Content.Load<Texture2D>("FrameHeroDegat");
            FrameHero = Content.Load<Texture2D>("FrameHero");
            //Textures sol
            TextureHerbe = Content.Load<Texture2D>("grass1");
            TexturePierreSol = Content.Load<Texture2D>("brique");
            //Texture Monstres
            textureMonstre = Content.Load<Texture2D>("monstre");

            //Texte
            spriteFont = Content.Load<SpriteFont>("font");

            //TEST
            test = Content.Load<Texture2D>("grass4");
            test3 = Content.Load<Texture2D>("grass");
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            //Si on veut quitter
            if (controller.Quitter())
            {
                Exit();
            }
            //Premier lancement
            if (GameIsStart == true)
            {
                map = new MapConstructor(0, 0);
                map.ReadTheMap();
                GameIsStart = false;
            }
            //Si on collide pas, on déplace le perso
            if (!collide.IsCollideWithScreen(joueur))
            {
                if (gameTime.TotalGameTime.Subtract(collide.IsCollideWithMob(gameTime)).Seconds >= 1)
                {
                    joueur.Texture = FrameHero;
                }
                joueur.SeDéplacer(gameTime);
                joueur.Attaquer(gameTime);
                if (gameTime.TotalGameTime.Subtract(collide.IsCollideWithSword(gameTime)).Milliseconds >= 500)
                {
                    map.ListMonstres[collide.ListMonstresTouchés[0]].Texture = textureMonstre;
                    collide.ListMonstresTouchés.RemoveAt(0);
                  //  collide.ListMonstresTouchés.
                }
            }
            //Si on collide on change de map
            else
            {
                map.ReadTheMap();
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            map.Draw(gameTime);
            spriteBatch.DrawString(spriteFont, "Coord : x:" + map.X + " y: " + map.Y, new Vector2(500, 20), Color.Black);
            spriteBatch.DrawString(spriteFont, "Vie : " + joueur.Vie, new Vector2(500, 30), Color.Black);
            if (joueur.IsAttacking == true)
            { joueur.DrawAnimatedEntityAttacking(spriteBatch); }
            joueur.DrawAnimatedEntity(spriteBatch);

            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
