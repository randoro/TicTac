using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TicTac
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static Texture2D boardTexture;
        public static SpriteFont font;
        TurnManager turnManager;
        Board board;
        GameState currentGameState = GameState.menu;

        PlayerType player1Type = PlayerType.Human;
        PlayerType player2Type = PlayerType.AI;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = Globals.windowX;
            graphics.PreferredBackBufferHeight = Globals.windowY;
            graphics.ApplyChanges();

            this.IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            boardTexture = Content.Load<Texture2D>("board");
            font = Content.Load<SpriteFont>("font");
            board = new Board(15, 15);
            //turnManager = new TurnManager(board);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyMouseReader.Update();
            // Allows the game to exit
            

            switch (currentGameState)
            {
                case GameState.menu:
                    if (KeyMouseReader.KeyPressed(Keys.Escape))
                    {
                        this.Exit();
                    }

                    if (KeyMouseReader.KeyPressed(Keys.D1))
                    {
                        StartNewGame(PlayerType.Human, PlayerType.AI);
                    }

                    if (KeyMouseReader.KeyPressed(Keys.D2))
                    {
                        StartNewGame(PlayerType.Human, PlayerType.Human);
                    }

                    if (KeyMouseReader.KeyPressed(Keys.D3))
                    {
                        StartNewGame(PlayerType.AI, PlayerType.AI);
                    }

                    if (KeyMouseReader.KeyPressed(Keys.D4))
                    {
                        StartNewGame(PlayerType.AI, PlayerType.Human);
                    }

                    break;
                case GameState.playing:
                    if (KeyMouseReader.KeyPressed(Keys.Escape))
                    {
                        currentGameState = GameState.menu;
                    }

                    turnManager.Update(gameTime);
                    board.Update(gameTime);
                    break;
                case GameState.gameover:
                    if (KeyMouseReader.KeyPressed(Keys.Escape))
                    {
                        currentGameState = GameState.menu;
                    }
                    if (KeyMouseReader.KeyPressed(Keys.F2))
                    {
                        ReplayGame();
                    }
                    break;
                default:
                    break;
            }

            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            switch (currentGameState)
            {
                case GameState.menu:
                    spriteBatch.DrawString(Game1.font, "Press 1 for Human vs AI (Human Starts)", new Vector2(100, 100), Color.Black);
                    spriteBatch.DrawString(Game1.font, "Press 2 for Human vs Human", new Vector2(100, 120), Color.Black);
                    spriteBatch.DrawString(Game1.font, "Press 3 for AI vs AI", new Vector2(100, 140), Color.Black);
                    spriteBatch.DrawString(Game1.font, "Press 4 for AI vs Human (AI Starts)", new Vector2(100, 160), Color.Black);
                    break;
                case GameState.playing:
                    board.Draw(spriteBatch);
                    break;
                case GameState.gameover:
                    spriteBatch.DrawString(Game1.font, "GameOver", new Vector2(100, 100), Color.Black);
                    spriteBatch.DrawString(Game1.font, "Winner is:", new Vector2(100, 120), Color.Black);
                    spriteBatch.DrawString(Game1.font, "Press F2 to Replay", new Vector2(100, 140), Color.Black);
                    board.Draw(spriteBatch);
                    break;
                default:
                    break;
            }

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }


        public void StartNewGame(PlayerType newPlayer1Type, PlayerType newPlayer2Type)
        {
            player1Type = newPlayer1Type;
            player2Type = newPlayer2Type;
            board.ResetBoard();
            turnManager = new TurnManager(board, player1Type, player2Type);
            currentGameState = GameState.playing;

        }

        public void ReplayGame()
        {
            board.ResetBoard();
            turnManager = new TurnManager(board, player1Type, player2Type);
            currentGameState = GameState.playing;

        }

    }
}
