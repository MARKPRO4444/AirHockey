using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Content;   
using System.Collections.Generic;
namespace AirHockey.Classes
{
    public class Gate2
    {
        private Vector2 position;
        private Texture2D texture;
        private Rectangle collision;
        private Rectangle destinationRectangle;


        public Rectangle Collision
        {
            get { return collision; }
        }

        public Gate2()
        {
            position = new Vector2(780, 0);
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("healthbar");
        }

        public void Update()
        {
            collision = new Rectangle((int)position.X, (int)position.Y,
                20, 480);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y,
                20, 480);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRectangle, Color.Blue);
        }
    }
}

