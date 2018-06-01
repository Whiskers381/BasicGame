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
    public class StateDevEnvironment : StateGamePlaying
    {
        protected SpriteDevGuy _DevGuy;

        public StateDevEnvironment(ContentManager content, Game1 game, GraphicsDevice graphicsDevice, Camera2d camera2D) : base(content, game, graphicsDevice, camera2D)
        {
            _DevGuy = new SpriteDevGuy(content.Load<Texture2D>("DevGuy"), new Vector2(0,0));
            _AllSprites.Add(_DevGuy);
        }
        public override void Update(GameTime gameTime,ref Peripherals IoController)
        {
            if (_NextLevel != null)
            {
                _CurrentLevel = _NextLevel;

                _NextLevel = null;
            }

            _Camera2D.Pos = _DevGuy.CurrentCoordinates;

            _DevGuy.Update(_IoController, 1.0f / 60.0f);
        }
    }
}
