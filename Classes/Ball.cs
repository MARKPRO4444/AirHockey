using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Content;   // для тетушки Контент 0_0
using System.Collections.Generic;
namespace AirHockey.Classes
{
	public class Ball
	{
		private Vector2 position;
		public Texture2D texture;
		private Rectangle collision;
		private Vector2 velocity = new Vector2(4, 4);

        public Rectangle Collision
        {
            get { return collision; }
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public void LoadContent(ContentManager manager)
		{
			texture = manager.Load<Texture2D>("healthbar");
		}

		public void Update()
		{
			position += velocity;

            if (position.Y + texture.Height > 480 || position.Y < 0)
            {
                velocity = velocity * new Vector2(1, -1);
            }

            if (position.X + texture.Width > 800 || position.X < 0)
            {
                velocity = velocity * new Vector2(-1, 1);
            }

            collision = new Rectangle((int)position.X, (int)position.Y,
                texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, position, Color.DarkCyan);
		}
	}
}

