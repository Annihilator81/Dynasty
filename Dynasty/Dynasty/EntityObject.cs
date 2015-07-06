using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dynasty
{
    public class EntityObject
    {
        public Texture2D Texture { get; set; }
        public Texture2D TextureAttaque { get; set; }
        public Rectangle RectangleSource;
        public Rectangle RectangleDestination;
        public Rectangle RectangleSourceAttak;
        public Rectangle RectangleDestinationAttak;
        public EntityObject(int posX, int posY)
        {
            RectangleDestination = new Rectangle(posX, posY, 32, 32);
            RectangleSource = new Rectangle(0, 0, 32, 32);
            RectangleSourceAttak = new Rectangle(0, 0, 32, 32);
            RectangleDestinationAttak = new Rectangle(posX, posY, 32, 32);
        }
        public void DrawAnimatedEntity(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, RectangleDestination, RectangleSource, Color.White);
        }
        public void DrawAnimatedEntityAttacking(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureAttaque, RectangleDestinationAttak, RectangleSourceAttak, Color.White);
        }
    }
}