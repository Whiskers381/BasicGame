using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicEngine
{
    public class WormKingPart : TextureSprite
    {
        protected float _RotationAngle;

        public WormKingPart(Texture2D texture, Vector2 defaultCoordinates) : base(texture, defaultCoordinates)
        {

        }
        public WormKingPart(Texture2D texture, Vector2 defaultCoordinates, Color color) : base(texture, defaultCoordinates)
        {
            _Color = color;
        }

        public void UpdateMovement(WormKingMovment movment)
        {
            _RotationAngle = movment.RotationAngle;
            _CurrentCoordinates = movment.Coordinates;
        }
        //public override void Update(float deltaTime)
        //{
            
        //}

        public override void Draw(SpriteBatch spriteBatch)
        {
            _Rectangle.X = (int)Math.Round(_CurrentX);
            _Rectangle.Y = (int)Math.Round(_CurrentY);
            spriteBatch.Draw(_CurrentTexture, _Rectangle, null, _Color, _RotationAngle, new Vector2(16, 24), SpriteEffects.None, 0);
        }
    }
}