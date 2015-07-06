using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Dynasty.Entités;

namespace Dynasty
{
    public class Controller
    {
        KeyboardState keyBoardState;
        public Controller()
        {
        }

        public bool Quitter()
        {
            keyBoardState = Keyboard.GetState();
            if (keyBoardState.IsKeyDown(Keys.Escape))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
