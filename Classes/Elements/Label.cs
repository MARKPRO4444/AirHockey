using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Content;   
using System.Collections.Generic;
namespace AirHockey.Classes.Elements
{
	public class Label
	{
		private SpriteFont spriteFont;
		private Vector2 position;
		private Color color;
		private string text;

		public Color Color
		{
			get { return color; }
			set { color = value; }
		}

		public string Text
		{
			get { return text; }
			set { text = value; }
		}

		public Label(Color color, Vector2 position, string text)
		{
			this.color = color;
			this.position = position;
			this.text = text;
		}

		public Label()
		{
			spriteFont = null;
			color = Color.White;
			text = "0:0";
			position = new Vector2(350, 0);
		}

		public void LoadContent(ContentManager manager)
		{
			spriteFont = manager.Load<SpriteFont>("spriteFont");
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.DrawString(spriteFont, text, position, color);
		}
	}
}