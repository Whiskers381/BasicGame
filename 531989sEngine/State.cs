using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BasicEngine
{
    public abstract class State
    {
        #region Fields

        protected ContentManager _Content;

        protected Game1 _Game;  

        protected GraphicsDevice _GraphicsDevice;

        protected Camera2d _Camera2D;

        protected List<SpriteText> _Texts;

        protected Color _BackgroundColour;



        #endregion Fields

        #region Methods

        public State(ContentManager content, Game1 game, GraphicsDevice graphicsDevice, Camera2d camera2D)
        {
            _Camera2D = camera2D;
            _Content = content;
            _Game = game;
            _GraphicsDevice = graphicsDevice;
            _Texts = new List<SpriteText>();
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch,ref Color BackgroundColour);

        public abstract void PostUpdate(GameTime gameTime,ref Peripherals IoController);

        public abstract void Update(GameTime gameTime,ref Peripherals IoController);

        #endregion Methods
    }
}
