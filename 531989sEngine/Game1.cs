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

        GraphicsDeviceManager _Graphics;
        SpriteBatch _SpriteBatch;

        Camera2d _Camera2D = new Camera2d();

        private LoadXml _XmlContent;
        public LoadXml XmlContent { get { return _XmlContent; } set { } }

        private State _CurrentState;
        private State _NextState;
        public void ChangeState(State state) 
        {
            _NextState = state;
        }

        public static int _ScreenWidth = 800;
        public static int _ScreenHeight = 480;

        public static int _HalfScreenWidth = 400;
        public static int _HalfScreenHeight = 240;

        #endregion Member Variables

        public Game1()
        {
            _Graphics = new GraphicsDeviceManager(this);
            _Graphics.ToggleFullScreen();

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
            _SpriteBatch = new SpriteBatch(GraphicsDevice);

            _XmlContent = new LoadXml(Content.ServiceProvider, Content.RootDirectory);

            _CurrentState = new SplashScreenState(Content, this, GraphicsDevice, _Camera2D);
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

            if(_NextState != null)
            {
                _CurrentState = _NextState;

                _NextState = null;
            }

            _CurrentState.Update(gameTime);
            _CurrentState.PostUpdate(gameTime);

            base.Update(gameTime);
        }

        #endregion

        #region Draw

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _CurrentState.Draw(gameTime, _SpriteBatch);

            base.Draw(gameTime);
        }

        #endregion
    }
}
