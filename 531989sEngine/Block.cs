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
    public class Block : Sprite
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
    }
}
