using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicEngine
{
    public class TexturedMover : Mover
    {
        #region MemberVariables

        protected enum _TextureOptions { Up, Down, Left, Right };
        //protected int CurrentTextureOption;

        protected int _CurrentTextureChangeFrequency = 3;// 3 is pretty smooth but a little fast 4 is too slow ¯\_(ツ)_/¯
        protected int _CurrentTextureChangeCounter = 0;// Incresed every update cycle resets at mTextureChangeFrequency

        protected List<Texture2D> _UpTextures = new List<Texture2D>();
        protected List<Texture2D> _DownTextures = new List<Texture2D>();
        protected List<Texture2D> _LeftTextures = new List<Texture2D>();
        protected List<Texture2D> _RightTextures = new List<Texture2D>();

        #endregion

        #region Constructors

        public TexturedMover(List<Texture2D> uptextures, List<Texture2D> downtextures, List<Texture2D> lefttextures, List<Texture2D> righttextures, Vector2 defaultCoordinates) : base(righttextures[0], defaultCoordinates)
        {
            _UpTextures = uptextures;
            _DownTextures = downtextures;
            _LeftTextures = lefttextures;
            _RightTextures = righttextures;
        }
        #endregion

        #region Event handlers

        //public override void StopMoveing()
        //{

        //}
        //public override void StopMoveingX()
        //{

        //}
        //public override void StopMoveingY()
        //{

        //}

        //public override void StartMoveingUp()
        //{

        //}
        //public override void StopMoveingUp()
        //{

        //}

        //public override void StartMoveingDown()
        //{

        //}
        //public override void StopMoveingDown()
        //{

        //}

        //public override void StartMoveingLeft()
        //{

        //}
        //public override void StopMoveingLeft()
        //{

        //}

        //public override void StartMoveingRight()
        //{

        //}
        //public override void StopMoveingRight()
        //{

        //}

        #endregion

        public override void Update(float deltaTime)
        {

        }
    }
}
