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

        private XmlLoad _XmlContent;
        public XmlLoad XmlContent { get { return _XmlContent; } set { } }

        private State _CurrentState;
        private State _NextState;
        
        public void ChangeState(State state) 
        {
            _NextState = state;
        }
        //Graphics related variables
        public bool _ShouldBeFullScreen = false;
        public static int _ScreenWidth = 800;
        public static int _ScreenHeight = 480;

        public static int _HalfScreenWidth = _ScreenWidth / 2;
        public static int _HalfScreenHeight = _ScreenHeight / 2;

        private Color _BackgroundColour = new Color(25, 25, 25);

        public Peripherals IoController = new Peripherals();

        private Random _Rand = new Random();

        #endregion Member Variables

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
            //Initialize engine components:
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _SpriteBatch = new SpriteBatch(GraphicsDevice);

            _XmlContent = new XmlLoad(Content.ServiceProvider, Content.RootDirectory);

            _CurrentState = new StateSplashScreen(Content, this, GraphicsDevice, _Camera2D);
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
            //This line allows the game to exit if the escape key is hit
            if (IoController.Escape) { Exit(); }

            //The line below calls the update method for the peripherals (keyboard, mouse...)
            IoController.Update(this);

            //Full screen handling
            #region FullScreen Toggle logic
            _ShouldBeFullScreen = IoController.FullScreenKey;
            if (_Graphics.IsFullScreen == false && _ShouldBeFullScreen)
            {
                //Makes is fullscreen
                _Graphics.ToggleFullScreen();
                _Graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
                _Graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
                _Graphics.ApplyChanges();

            }
            else if (_Graphics.IsFullScreen == true && !_ShouldBeFullScreen)
            {
                //Makes it not fullscreen
                _Graphics.ToggleFullScreen();
                _Graphics.PreferredBackBufferWidth = _ScreenWidth;
                _Graphics.PreferredBackBufferHeight = _ScreenHeight;
                _Graphics.ApplyChanges();
            }
            #endregion

            if (_NextState != null)
            {
                _CurrentState = _NextState;

                _NextState = null;
            }

            _CurrentState.Update(gameTime,ref IoController);
            _CurrentState.PostUpdate(gameTime,ref IoController);

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
            _CurrentState.Draw(gameTime, _SpriteBatch, ref _BackgroundColour);

            base.Draw(gameTime);
        }

        #endregion
    }
}
