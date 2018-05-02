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
    class Block
    {
        private Vector2 _DefaultCoordinates;
        public Vector2 DefaultCoordinates { get { return _DefaultCoordinates; } set { } }
        private int _Width;
        public int Width { get { return _Width; } set { } }
        private int _Height;
        public int Height { get { return _Width; } set { } }

        public Block(Vector2 defaultCoordinates, int width, int height)
        {
            _DefaultCoordinates = defaultCoordinates;
            _Width = width;
            _Height = height;
        }
    }
}
