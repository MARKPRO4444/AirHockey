﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Content;   
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

namespace AirHockey.Classes
{
    public class Player1
    {
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 stateVelocity;
        private Texture2D texture;
        private int numFrame = 0;
        private float speedX;
        private float speedY;
        private Rectangle collision;
        private int score = 0;

        private Rectangle sourceRectangle;

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Rectangle Collision
        {
            get { return collision; }
            set { collision = value; }
        }

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public Vector2 StateVelocity
        {
            get { return stateVelocity; }
            set { stateVelocity = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public Player1()
        {
            sourceRectangle = new Rectangle(numFrame * 144, 0, 144, 100);
            position = new Vector2(100, 100);
            stateVelocity = new Vector2(-5, -5);

            speedX = 0;
            speedY = 0;

            velocity = new Vector2(speedX, speedY);
        }
        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("healthbar");
        }
        public void Update()
        {
            #region Control
            KeyboardState state = Keyboard.GetState();

            velocity = Vector2.Zero;
            speedX = 0;
            speedY = 0;

            if (state.IsKeyDown(Keys.W))
            {
                speedY = -5;
            }
            if (state.IsKeyDown(Keys.S))
            {
                speedY = 5;
            }

            velocity = new Vector2(speedX, speedY);
            position = position + velocity;
            #endregion

            if (position.X < 0)
            {
                position.X = 0;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
            }
            if (position.X + texture.Width > 800)
            {
                position.X = 800 - texture.Width;
            }
            if (position.Y + texture.Height > 600)
            {
                position.Y = 600 - texture.Height;
            }

            collision = new Rectangle((int)position.X, (int)position.Y,
                texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}

