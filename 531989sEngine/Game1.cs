using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml;

namespace BasicEngine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        #region Member Variables
        float _SplashScreenDurationLimit = 4f;
        float _CurrentSplashScreenDuration = 0f;

        GraphicsDeviceManager _Graphics;
        SpriteBatch _SpriteBatch;

        Camera2d _Camera2d = new Camera2d();
        Camera3d _Camera3d;

        public static int _ScreenWidth = 800;
        public static int _ScreenHeight = 480;

        public static int _HalfScreenWidth = 400;
        public static int _HalfScreenHeight = 240;

        List<Sprite> _Sprites = new List<Sprite>();

        List<Text> _SplashScreenText = new List<Text>();
        List<Text> _StartScreenText = new List<Text>();
        List<Sprite> _GamePlayingSprites = new List<Sprite>();

        enum GameStates { SplashScreen, StartScreen, GamePlaying, GamePaused, GameOver, GameWin };
        int _CurrentGameState;

        SpriteFont _MessageFont;

        #endregion Member Variables

        public Game1()
        {
            _Graphics = new GraphicsDeviceManager(this);
            _Graphics.ToggleFullScreen();
            _Camera3d = new Camera3d(new Vector3(400, 240,10),new Vector3(400,240,10), new Vector3(0,0,0));
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

            _SplashScreenText.Add(new Text(_MessageFont, "Made By:", (int)Text.XAdjust.Centre, (int)Text.YAdjust.Centre, new Vector2(0,50)));
            _SplashScreenText.Add(new Text(_MessageFont, "James Williams and Josh Cantwell", (int)Text.XAdjust.Centre, (int)Text.YAdjust.Centre, new Vector2(0, -0)));
            _SplashScreenText.Add(new Text(_MessageFont, "at the University of Hull", (int)Text.XAdjust.Centre, (int)Text.YAdjust.Centre, new Vector2(0, -50)));

            _StartScreenText.Add(new Text(_MessageFont, "Welcome", (int)Text.XAdjust.Centre, (int)Text.YAdjust.Centre, new Vector2(0, 50)));
            _StartScreenText.Add(new Text(_MessageFont, "Press SPACEBAR to continue to simulation", (int)Text.XAdjust.Centre, (int)Text.YAdjust.Centre, new Vector2(0, -0)));
            _StartScreenText.Add(new Text(_MessageFont, "........", (int)Text.XAdjust.Centre, (int)Text.YAdjust.Centre, new Vector2(0, -50)));
            _StartScreenText.Add(new Text(_MessageFont, ".......", (int)Text.XAdjust.Centre, (int)Text.YAdjust.Centre, new Vector2(0, -100)));
            _StartScreenText.Add(new Text(_MessageFont, "......", (int)Text.XAdjust.Centre, (int)Text.YAdjust.Centre, new Vector2(0, -150)));
            _StartScreenText.Add(new Text(_MessageFont, ".....", (int)Text.XAdjust.Centre, (int)Text.YAdjust.Centre, new Vector2(0, -200)));
            _StartScreenText.Add(new Text(_MessageFont, "....", (int)Text.XAdjust.Centre, (int)Text.YAdjust.Centre, new Vector2(0, -250)));
            _StartScreenText.Add(new Text(_MessageFont, "...", (int)Text.XAdjust.Centre, (int)Text.YAdjust.Centre, new Vector2(0, -300)));



            Texture2D Block = Content.Load<Texture2D>("BB_Block");

            _GamePlayingSprites.Add(new Sprite(Block,new Vector2(0,0)));
        }
        protected void LoadXmlContent()
        {
            XmlDocument mXmlDocument = new XmlDocument();
            mXmlDocument.Load("TestOne.xml");
            XmlNode LevelNode = mXmlDocument.FirstChild.NextSibling;

            List<Sprite> mSprites = new List<Sprite>();
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
            
        }

        private void UpdateStartScreen(GameTime gameTime)
        {
            KeyboardState keys = Keyboard.GetState();
            if (keys.IsKeyDown(Keys.Space))
            {
                _CurrentGameState = (int)GameStates.GamePlaying;
                //mCurrentLevel.mPlayerCharacter.Reset();
            }
            //if (keys.IsKeyDown(Keys.D0))
            //{
            //    SetCurrentLevelTo(0);
            //}
            //else if (keys.IsKeyDown(Keys.D1))
            //{
            //    SetCurrentLevelTo(1);
            //}
            //else if (keys.IsKeyDown(Keys.D2))
            //{
            //    SetCurrentLevelTo(2);
            //}
            //else if (keys.IsKeyDown(Keys.D3))
            //{
            //    SetCurrentLevelTo(3);
            //}
            //else if (keys.IsKeyDown(Keys.D4))
            //{
            //    SetCurrentLevelTo(4);
            //}
            //else if (keys.IsKeyDown(Keys.D5))
            //{
            //    SetCurrentLevelTo(5);
            //}
            //else if (keys.IsKeyDown(Keys.D6))
            //{
            //    SetCurrentLevelTo(6);
            //}
            //else if (keys.IsKeyDown(Keys.D7))
            //{
            //    SetCurrentLevelTo(7);
            //}
            //else if (keys.IsKeyDown(Keys.D8))
            //{
            //    SetCurrentLevelTo(8);
            //}
            //else if (keys.IsKeyDown(Keys.D9))
            //{
            //    SetCurrentLevelTo(9);
            //}
        }

        private void UpdateSplashScreen(GameTime gameTime)
        {
            if (_CurrentSplashScreenDuration >= _SplashScreenDurationLimit)
            {
                _CurrentGameState = (int)GameStates.StartScreen;
            }
            else
            {
                _CurrentSplashScreenDuration += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
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
            GraphicsDevice.Clear(new Color(0, 50, 50));
            //_Camera2d.Pos = new Vector2(_PlayerCharacter._X, 240);
            _SpriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, _Camera2d.get_transformation(GraphicsDevice));

            foreach (Sprite sprite in _GamePlayingSprites)
            {
                //sprite.UpdateCameraPosition(_Camera2d.Pos);
                sprite.Draw(_SpriteBatch);
            }
            _SpriteBatch.End();
        }

        private void DrawStartScreen(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(0, 50, 50));

            _Camera2d.Pos = new Vector2(400, 240);
            this._SpriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, _Camera2d.get_transformation(GraphicsDevice));

            //_Camera3d.Roll(10f);
            //_Camera3d.Pitch(10f);
            //this._SpriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, _Camera3d.ViewMatrix);

            foreach (Text text in _StartScreenText)
            {
                text.Draw(_SpriteBatch);
            }

            _SpriteBatch.End();
        }

        private void DrawSplashScreen(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(0, 50, 50));

            _Camera2d.Pos = new Vector2(400, 240);
            this._SpriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, _Camera2d.get_transformation(GraphicsDevice));

            //_Camera3d.Roll(10f);
            //_Camera3d.Pitch(10f);
            //this._SpriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, _Camera3d.ViewMatrix);

            foreach (Text text in _SplashScreenText)
            {
                text.Draw(_SpriteBatch);
            }

            _SpriteBatch.End();
        }
        #endregion
    }
}
