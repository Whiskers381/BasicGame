using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BasicEngine
    //Josh was here
{
    public class SpriteDevGuy : SpriteMover
    {
        public SpriteDevGuy(Texture2D texture, Vector2 defaultCoordinates) : base(texture, defaultCoordinates)
        {

        }

        #region Update

        //protected float countCock = 0;
        public override void Update(float deltaTime)
        {
            //if (countCock < 10)
            //{
            //    _Colour = new Color(255, 255, 255, 255);
            //}
            //if(countCock > 10)
            //{
            //    _Colour = new Color(255, 255, 255, 0);
            //}
            //if (countCock > 20)
            //{
            //    countCock = 0;
            //}
            //countCock += 1;

            KeyboardState keyboard = Keyboard.GetState();

            MoveByMovmentSpeed(keyboard, deltaTime);
            MoveByPixel(keyboard, deltaTime, 30);
        }

        protected void MoveByMovmentSpeed(KeyboardState keyboard, float deltaTime)
        {
            if (keyboard.IsKeyDown(Keys.W))
            {
                MoveUp(deltaTime);
            }
            if (keyboard.IsKeyDown(Keys.S))
            {
                MoveDown(deltaTime);
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                MoveLeft(deltaTime);
            }
            if (keyboard.IsKeyDown(Keys.D))
            {
                MoveRight(deltaTime);
            }
        }

        /// <summary>
        /// Moves DevGuy by _MovementSpeed * deltaTime / MagicNumbersAreBadForYou
        /// </summary>
        /// <param name="keyboard"></param>
        /// <param name="deltaTime"></param>
        /// <param name="MagicNumbersAreBadForYou"></param>
        protected void MoveByPixel(KeyboardState keyboard, float deltaTime, float MagicNumbersAreBadForYou)
        {
            if (keyboard.IsKeyDown(Keys.Up))
            {
                MoveUp(deltaTime / MagicNumbersAreBadForYou);
            }
            if (keyboard.IsKeyDown(Keys.Down))
            {
                MoveDown(deltaTime / MagicNumbersAreBadForYou);
            }
            if (keyboard.IsKeyDown(Keys.Left))
            {
                MoveLeft(deltaTime / MagicNumbersAreBadForYou);
            }
            if (keyboard.IsKeyDown(Keys.Right))
            {
                MoveRight(deltaTime / MagicNumbersAreBadForYou);
            }
        }

        #endregion Update

        public override void Draw(SpriteBatch spriteBatch)
        {
            _Rectangle.X = (int)Math.Round(_CurrentX);
            _Rectangle.Y = (int)Math.Round(_CurrentY);
            spriteBatch.Draw(_CurrentTexture, _Rectangle, null, _Colour, 0f, new Vector2(0, 0), SpriteEffects.None, 0);
        }
    }
}