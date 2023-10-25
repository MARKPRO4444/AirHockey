using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using AirHockey.Classes;
using AirHockey.Classes.Elements;

namespace AirHockey;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public static GameMode gameMode = GameMode.Play;

    Player1 player1;
    Player2 player2;
    Gate1 gate1;
    Ball ball;
    Gate2 gate2;
    Label lblScore = new Label("0:0", new Vector2(350, 0), Color.Brown);
    ScreenEnd screenEnd;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 800;
        _graphics.PreferredBackBufferHeight = 480;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        player1 = new Player1();
        player2 = new Player2();
        gate1 = new Gate1();
        ball = new Ball();
        gate2 = new Gate2();
        screenEnd = new ScreenEnd();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        player1.LoadContent(Content);
        player2.LoadContent(Content);
        gate1.LoadContent(Content);
        gate2.LoadContent(Content);
        ball.LoadContent(Content);
        screenEnd.LoadContent(Content);
        lblScore.LoadContent(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        switch(gameMode)
        {
            case GameMode.Play:
                player1.Update();
                player2.Update();
                gate1.Update();
                gate2.Update();
                ball.Update();
                UpdateCollision();
                UpdateScore();
                End();
                break;
            case GameMode.End:
                screenEnd.Update();
                break;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Green);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        switch (gameMode)
        {
            case GameMode.Play:
                player1.Draw(_spriteBatch);
                player2.Draw(_spriteBatch);
                gate1.Draw(_spriteBatch);
                gate2.Draw(_spriteBatch);
                ball.Draw(_spriteBatch);
                lblScore.Draw(_spriteBatch);
                break;
            case GameMode.End:
                screenEnd.Draw(_spriteBatch);
                break;
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    public void UpdateCollision()
    {
        if (ball.Collision.Intersects(gate1.Collision))
        {
            player2.Score++;
            ball.Position = new Vector2(330, 220);
        }
        if (ball.Collision.Intersects(gate2.Collision))
        {
            player1.Score++;
            ball.Position = new Vector2(330, 220);
        }

        if(player1.Collision.Intersects(ball.Collision))
        {
            ball.Velocity = ball.Velocity * new Vector2(-1, 1);
        }
        if(player2.Collision.Intersects(ball.Collision))
        {
            ball.Velocity = ball.Velocity * new Vector2(-1, 1);
        }
    }

    public void UpdateScore()
    {
        screenEnd.UpdateUI(player1.Score.ToString()+":"+(player2.Score-1).ToString(), 0, 0);
        lblScore.Text = player1.Score + ":" + (player2.Score-1);
    }

    public void End()
    {
        if (player1.Score == 5 || player1.Score == 5)
        {
            if (player1.Score >= 5)
            {
                System.Console.WriteLine("Player1 Wiin!!");
            }
            else if (player2.Score >= 5)
            {
                System.Console.WriteLine("Player2 Wiin!!");
            }
            gameMode = GameMode.End;
            System.Console.WriteLine("The End :(");
        }
    }
}

