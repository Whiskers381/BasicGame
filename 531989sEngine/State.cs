using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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



        #endregion Fields

        #region Methods

        public State(ContentManager content, Game1 game, GraphicsDevice graphicsDevice)
        {
            _Content = content;

            _Game = game;

            _GraphicsDevice = graphicsDevice;
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void PostUpdate(GameTime gameTime);

        public abstract void Update(GameTime gameTime);

        #endregion Methods
    }
}
