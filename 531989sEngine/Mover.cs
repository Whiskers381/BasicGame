using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicEngine
{
    public class Mover : TextureSprite
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

        protected int _MovmentSpeed = 250;//200-300 is a good idea
        #endregion

        #region Constructors
        public Mover(List<Texture2D> uptextures, List<Texture2D> downtextures, List<Texture2D> lefttextures, List<Texture2D> righttextures, Vector2 defaultCoordinates) : base(righttextures[0], defaultCoordinates)
        {
            _UpTextures = uptextures;
            _DownTextures = downtextures;
            _LeftTextures = lefttextures;
            _RightTextures = righttextures;
        }
        #endregion
        #region Event handlers

        public void StopMoveing()
        {

        }
        public void StopMoveingX()
        {

        }
        public void StopMoveingY()
        {

        }

        public void StartMoveingUp()
        {

        }
        public void StopMoveingUp()
        {

        }

        public void StartMoveingDown()
        {

        }
        public void StopMoveingDown()
        {

        }

        public void StartMoveingLeft()
        {

        }
        public void StopMoveingLeft()
        {

        }

        public void StartMoveingRight()
        {

        }
        public void StopMoveingRight()
        {

        }
        #endregion

        public override void Update(float deltaTime)
        {

        }
    }
}
