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
    public class SpritePlayerCharacter : SpriteTexturedMover
    {
        

        public SpritePlayerCharacter(List<Texture2D> uptextures, List<Texture2D> downtextures, List<Texture2D> lefttextures, List<Texture2D> righttextures, Vector2 defaultCoordinates, ref Peripherals IoController) :
            base(uptextures, downtextures, lefttextures, righttextures, defaultCoordinates)
        {
            _IsPlayerControlled = true;
        }
        public void Update(Peripherals IoController,float deltaTime)
        {
            Move(IoController, deltaTime);
        }
    }
}
