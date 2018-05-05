using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;

namespace BasicEngine
{
    public class Block : TextureSprite
    {
        private int _Width;
        public int Width { get { return _Width; } set { } }
        private int _Height;
        public int Height { get { return _Width; } set { } }

        public Block(Texture2D texture, Vector2 defaultCoordinates, int width, int height) : base(texture, defaultCoordinates)
        {
            _Width = width;
            _Height = height;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            _Rectangle.X = (int)Math.Round(_CurrentX);
            _Rectangle.Y = (int)Math.Round(_CurrentY);
            spriteBatch.Draw(_CurrentTexture, _Rectangle, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, 0);
        }
    }
}
