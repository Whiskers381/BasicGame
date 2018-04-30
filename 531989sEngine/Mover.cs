using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicEngine
{
    class Mover : Sprite
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
        public Mover(Texture2D Texture, Vector2 DefaultCoordinates) : base(Texture, DefaultCoordinates)
        {

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
            _CurrentTextureChangeCounter += 1;
            UpdateLogic(deltaTime);
            //UpdateCurrentTexture();//Calls the update methods of it's children as this class isn't meant to be used on its own because anything that moves would require its own update logic to actualy move 
            base.Update(deltaTime);
        }
        public virtual void UpdateLogic(float deltaTime)
        {

        }
    }
}
