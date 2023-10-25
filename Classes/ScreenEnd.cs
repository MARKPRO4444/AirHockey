using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO; // files

using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;   // для тетушки Контент 0_0
using AirHockey.Classes.Elements;
using AirHockey;
using AirHockey.Classes;

namespace AirHockey.Classes
{
    public class ScreenEnd
    {
        private Label labelHeader;
        private Label lblScore;
        private Label lblInfo;

        private Label lblGameTime;
        private Label lblDistance;


        KeyboardState keyboardState;
        KeyboardState prevKeyboardState;

        private bool flag = false;

        public ScreenEnd()
        {
            labelHeader = new Label("THE END", new Vector2(350, 150), Color.White);
            lblScore = new Label("Score: --", new Vector2(350, 200), Color.White);
            lblGameTime = new Label("Time: 0", new Vector2(350, 250), Color.White);
            lblDistance = new Label("Distance: 0", new Vector2(350, 300), Color.White);
            lblInfo = new Label("Press Enter to continue...", new Vector2(300, 350), Color.LightPink);
        }

        public void Update()
        {
            if (flag == false)
            {
                flag = true;
            }

            keyboardState = Keyboard.GetState();

            if (prevKeyboardState.IsKeyDown(Keys.Enter) &&
                keyboardState.IsKeyUp(Keys.Enter))
            {
                Game1.gameMode = GameMode.Play;

                flag = false;
            }

            prevKeyboardState = keyboardState;
        }

        public void LoadContent(ContentManager manager)
        {
            labelHeader.LoadContent(manager);
            lblScore.LoadContent(manager);
            lblInfo.LoadContent(manager);
            lblGameTime.LoadContent(manager);
            lblDistance.LoadContent(manager);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            labelHeader.Draw(spriteBatch);
            lblScore.Draw(spriteBatch);
            lblInfo.Draw(spriteBatch);
            lblGameTime.Draw(spriteBatch);
            lblDistance.Draw(spriteBatch);
        }

        public void UpdateUI(string score, int distance, double gameTime)
        {
            lblScore.Text = "Score: " + score.ToString();
            lblGameTime.Text = "Time: " + gameTime.ToString();
            lblDistance.Text = "Distance: " + distance.ToString();
        }

        public void SaveData(double GameTime)
        {
            string data = "data.save";

            StreamWriter writer = new StreamWriter(data);

            writer.WriteLine(GameTime);

            writer.Close();
        }

        public void LoadData()
        {

        }

    }
}

