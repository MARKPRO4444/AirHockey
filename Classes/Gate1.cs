using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Content;   // для тетушки Контент 0_0
using System.Collections.Generic;
namespace AirHockey.Classes
{
	public class Gate1
	{
		private Vector2 position;
		private Texture2D texture;
		private Rectangle collision;

		public Rectangle Collision
		{
			get { return collision; }
		}

		public void LoadContent(ContentManager manager)
		{
			texture = manager.Load<Texture2D>("healthbar");
		}

		public void Update()
		{
            collision = new Rectangle((int)position.X, (int)position.Y,
    texture.Width, texture.Height);
        }

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, position, Color.WhiteSmoke);
		}
	}
}

