using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BasicEngine
{
    public class GamePlaying : State
    {

        protected PlayerCharacter _PlayerCharacter;

        public GamePlaying(ContentManager content, Game1 game, GraphicsDevice graphicsDevice, Camera2d camera2D) : base(content, game, graphicsDevice, camera2D)
        {
            //_PlayerCharacter = new PlayerCharacter();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _GraphicsDevice.Clear(new Color(0, 50, 50));
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
