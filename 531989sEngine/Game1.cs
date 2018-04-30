using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BasicEngine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager _Graphics;
        SpriteBatch _SpriteBatch;
        Camera2d _Camera = new Camera2d();

        public static int _ScreenWidth = 800;
        public static int _ScreenHeight = 480;

        public static int _HalfScreenWidth = 400;
        public static int _HalfScreenHeight = 240;

        List<Text> SplashScreenText = new List<Text>();

        enum GameStates { SplashScreen, StartScreen, GamePlaying, GamePaused, GameOver, GameWin };
        int _CurrentGameState;

        SpriteFont _MessageFont;

        public Game1()
        {
            _Graphics = new GraphicsDeviceManager(this);
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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            _MessageFont = Content.Load<SpriteFont>("UssDallas");

            _CurrentGameState = (int)GameStates.SplashScreen;
            _SpriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            SplashScreenText.Add(new Text(_MessageFont, "Made By:", (int)Text.XAdjust.Centre, (int)Text.YAdjust.Centre, new Vector2(0,50)));
            SplashScreenText.Add(new Text(_MessageFont, "James Williams and Josh Cantwell", (int)Text.XAdjust.Centre, (int)Text.YAdjust.Centre, new Vector2(0, -0)));
            SplashScreenText.Add(new Text(_MessageFont, "at the University of Hull", (int)Text.XAdjust.Centre, (int)Text.YAdjust.Centre, new Vector2(0, -50)));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        #region Update

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            switch (_CurrentGameState)
            {
                case (int)GameStates.SplashScreen:
                    UpdateSplashScreen(gameTime);
                    break;
                case (int)GameStates.StartScreen:
                    UpdateStartScreen(gameTime);
                    break;
                case (int)GameStates.GamePlaying:
                    UpdateGamePlay(gameTime);
                    break;
                case (int)GameStates.GamePaused:
                    UpdateGamePaused(gameTime);
                    break;
                case (int)GameStates.GameOver:
                    UpdateGameOver(gameTime);
                    break;
                case (int)GameStates.GameWin:
                    UpdateGameWin(gameTime);
                    break;
            }

            base.Update(gameTime);
        }

        private void UpdateGameWin(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        private void UpdateGameOver(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        private void UpdateGamePaused(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        private void UpdateGamePlay(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        private void UpdateStartScreen(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        private void UpdateSplashScreen(GameTime gameTime)
        {
            
        }
        #endregion

        #region Draw

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            switch (_CurrentGameState)
            {
                case (int)GameStates.SplashScreen:
                    DrawSplashScreen(gameTime);
                    break;
                case (int)GameStates.StartScreen:
                    DrawStartScreen(gameTime);
                    break;
                case (int)GameStates.GamePlaying:
                    DrawGamePlay(gameTime);
                    break;
                case (int)GameStates.GamePaused:
                    DrawPaused(gameTime);
                    break;
                case (int)GameStates.GameOver:
                    DrawGameOver(gameTime);
                    break;
                case (int)GameStates.GameWin:
                    DrawGameWin(gameTime);
                    break;
            }
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void DrawGameWin(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        private void DrawGameOver(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        private void DrawPaused(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        private void DrawGamePlay(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        private void DrawStartScreen(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        private void DrawSplashScreen(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(0, 50, 50));

            _Camera.Pos = new Vector2(400, 240);

            this._SpriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, _Camera.get_transformation(GraphicsDevice));

            foreach (Text text in SplashScreenText)
            {
                text.Draw(_SpriteBatch);
            }

            _SpriteBatch.End();
        }
        #endregion
    }
}
