using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Dynasty.Entités;
using Microsoft.Xna.Framework.Graphics;

namespace Dynasty
{
    public class Controller
    {
        public KeyboardState keyBoardState;
        public MouseState mouseState;
        public Texture2D ImageMenu;
        public Texture2D ImagePlay;
        public Texture2D ImageSettings;
        public Texture2D ImageQuit;
        public Rectangle Play;
        public Rectangle Settings;
        public Rectangle Quit;
        public bool InMenu { get; set; }
        public Controller()
        {
            Play = new Rectangle(340, 200, 100, 32);
            //   Settings = new Rectangle(0, 180, 80, 32);
            Quit = new Rectangle(340, 250, 100, 32);
        }

        public void Quitter()
        {
            keyBoardState = Keyboard.GetState();
            if (keyBoardState.IsKeyDown(Keys.Escape))
            {
                Game1.MenuIsSkip = false;
            }
        }
        public bool LoadMenu()
        {
            mouseState = Mouse.GetState(Game1.win); // si je lui file pas la fenetre ça bug I DON4T KNOW WHY. BITCH. FOCUS???LOL
            Point mousePosition = new Point(mouseState.Position.X, mouseState.Position.Y);
            if (mouseState.LeftButton == ButtonState.Pressed && Play.Contains(mousePosition))
            {
                InMenu = false;
                Game1.MenuIsSkip = true;
            }
            else if (mouseState.LeftButton == ButtonState.Pressed && Quit.Contains(mousePosition))
            {
                Game1.IsExit = true;
            }
            else
            {
                InMenu = true;
            }
            return InMenu;
        }
        public void DrawMenu(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageMenu, Vector2.Zero, Color.White);
            spriteBatch.Draw(ImagePlay, Play, Color.White);
            //  spriteBatch.Draw(ImageSettings, Settings, Color.White);
            spriteBatch.Draw(ImageQuit, Quit, Color.White);
        }
    }
}
