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

    Player1 player1;
    Player2 player2;
    Gate1 gate1;
    Ball ball;
    Gate2 gate2;
    Label lblScore = new Label(Color.Black, new Vector2(380, 0), "0:0");

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
        lblScore.LoadContent(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        player1.Update();
        player2.Update();
        gate1.Update();
        gate2.Update();
        ball.Update();
        UpdateCollision();
        UpdateScore();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Green);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        player1.Draw(_spriteBatch);
        player2.Draw(_spriteBatch);
        gate1.Draw(_spriteBatch);
        gate2.Draw(_spriteBatch);
        ball.Draw(_spriteBatch);
        lblScore.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    public void UpdateCollision()
    {
        if (ball.Collision.Intersects(gate1.Collision))
        {
            player2.Score++;
            ball.Position = new Vector2(330, 220);
            Thread.Sleep(2000);
        }
        if (ball.Collision.Intersects(gate2.Collision))
        {
            player1.Score++;
            ball.Position = new Vector2(330, 220);
            Thread.Sleep(2000);
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
        lblScore.Text = player1.Score + ":" + player2.Score;
    }
}

