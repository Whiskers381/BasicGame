using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicEngine
{
    public class PlayerCharacter : Mover
    {
        public PlayerCharacter(List<Texture2D> uptextures, List<Texture2D> downtextures, List<Texture2D> lefttextures, List<Texture2D> righttextures, Vector2 defaultCoordinates):
            base(uptextures, downtextures, lefttextures, righttextures, defaultCoordinates)
        {

        }
    }
}
