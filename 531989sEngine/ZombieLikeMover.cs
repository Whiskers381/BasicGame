using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicEngine
{
    public class ZombieLikeMover : TexturedMover
    {
        public ZombieLikeMover(List<Texture2D> uptextures, List<Texture2D> downtextures, List<Texture2D> lefttextures, List<Texture2D> righttextures, Vector2 defaultCoordinates):
            base(uptextures, downtextures, lefttextures, righttextures, defaultCoordinates)
        {

        }
        public override void Update(float deltaTime)
        {
            //if (mX <= mStartX)
            //{
            //    mCurrentTextureState = (int)mTextureStates.Right;
            //}
            //else if (mX >= mEndX)
            //{
            //    mCurrentTextureState = (int)mTextureStates.Left;
            //}
            //switch (mCurrentTextureState)
            //{
            //    case (int)mTextureStates.Right:
            //        mX = mX + (mMovmentSpeed * deltaTime);
            //        break;
            //    case (int)mTextureStates.Left:
            //        mX = mX - (mMovmentSpeed * deltaTime);
            //        break;
            //}
        }
    }
}
