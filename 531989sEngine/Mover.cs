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

        protected int _MovmentSpeed = 250;//200-300 is a good idea

        #endregion

        #region Constructors

        public Mover(Texture2D texture, Vector2 defaultCoordinates) : base(texture, defaultCoordinates)
        {

        }

        #endregion

        #region Event handlers

        public virtual void StopMoveing()
        {

        }
        public virtual void StopMoveingX()
        {

        }
        public virtual void StopMoveingY()
        {

        }

        public virtual void StartMoveingUp()
        {

        }
        public virtual void StopMoveingUp()
        {

        }

        public virtual void StartMoveingDown()
        {

        }
        public virtual void StopMoveingDown()
        {

        }

        public virtual void StartMoveingLeft()
        {

        }
        public virtual void StopMoveingLeft()
        {

        }

        public virtual void StartMoveingRight()
        {

        }
        public virtual void StopMoveingRight()
        {

        }
        #endregion

        public override void Update(float deltaTime)
        {

        }
        public virtual void MoveUp(float deltaTime)
        {
            _CurrentY -= _MovmentSpeed * deltaTime;
        }
        public virtual void MoveDown(float deltaTime)
        {
            _CurrentY += _MovmentSpeed * deltaTime;
        }
        public virtual void MoveLeft(float deltaTime)
        {
            _CurrentX -= _MovmentSpeed * deltaTime;
        }
        public virtual void MoveRight(float deltaTime)
        {
            _CurrentX += _MovmentSpeed * deltaTime;
        }
    }
}
