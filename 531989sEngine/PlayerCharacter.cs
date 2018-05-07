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
    public class PlayerCharacter : TexturedMover
    {
        public PlayerCharacter(List<Texture2D> uptextures, List<Texture2D> downtextures, List<Texture2D> lefttextures, List<Texture2D> righttextures, Vector2 defaultCoordinates):
            base(uptextures, downtextures, lefttextures, righttextures, defaultCoordinates)
        {

        }
        public override void Update(float deltaTime)
        {
            KeyboardState keys = Keyboard.GetState();
            if(keys.IsKeyDown(Keys.W))
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
