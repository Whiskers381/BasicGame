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
    public class DevGuy : Mover
    {
        public DevGuy(Texture2D texture, Vector2 defaultCoordinates) : base(texture, defaultCoordinates)
        {

        }

        public override void Update(float deltaTime)
        {
            KeyboardState keys = Keyboard.GetState();
            if (keys.IsKeyDown(Keys.W))
            {
                MoveUp(deltaTime);
            }
            if (keys.IsKeyDown(Keys.S))
            {
                MoveDown(deltaTime);
            }
            if (keys.IsKeyDown(Keys.A))
            {
                MoveLeft(deltaTime);
            }
            if (keys.IsKeyDown(Keys.D))
            {
                MoveRight(deltaTime);
            }
        }
    }
}