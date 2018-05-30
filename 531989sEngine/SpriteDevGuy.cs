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
    public class SpriteDevGuy : SpriteMover
    {
        public SpriteDevGuy(Texture2D texture, Vector2 defaultCoordinates) : base(texture, defaultCoordinates)
        {
            _IsPlayerControlled = true;
        }

        #region Update

        public void Update(Peripherals IoController, float deltaTime)
        {
            Move(IoController, deltaTime);
        }


        #endregion Update

    }
}