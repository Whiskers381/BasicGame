using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicEngine
{
    class PlayerCharacter : Mover
    {
        public PlayerCharacter(Texture2D texture, Vector2 defaultCoordinates) : base(texture, defaultCoordinates)
        {

        }
    }
}
