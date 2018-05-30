﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicEngine
{
    public class SpritePortal : SpriteTextureSprite
    {
        //This looks redundant but all sprites must have their own class so that later on extra behavour and texture garbage can be added
        public SpritePortal(Texture2D texture, Vector2 defaultCoordinates) : base(texture, defaultCoordinates)
        {

        }
    }
}
