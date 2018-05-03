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
    class TypeOneBadGuy : Mover
    {
        public TypeOneBadGuy(Texture2D texture, Vector2 defaultCoordinates) : base(texture, defaultCoordinates)
        {

        }
    }
}
