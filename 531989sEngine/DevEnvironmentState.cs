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
    public class DevEnvironmentState : GamePlayingState
    {
        protected DevGuy _DevGuy;

        public DevEnvironmentState(ContentManager content, Game1 game, GraphicsDevice graphicsDevice, Camera2d camera2D) : base(content, game, graphicsDevice, camera2D)
        {
            _DevGuy = new DevGuy(content.Load<Texture2D>("DevGuy"), new Vector2(0,0)); 
        }
    }
}
