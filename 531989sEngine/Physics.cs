using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BasicEngine
{
    public abstract class Physics
    {
        protected Vector2 _CurrentCoordinates = new Vector2(0, 0);
        protected Vector2 _DefaultCoordinates = new Vector2(0, 0);
        // _IsPlayerControlled is a variables used to detect if a sprite is going to be moved via the keyboard inputs (W,A,S,D etc) therefore is false by default as the majority of sprites are static or have fixed movement
        protected bool _IsPlayerControlled = false;

        protected float _CurrentX { get { return this._CurrentCoordinates.X; } set { this._CurrentCoordinates.X = value; } }
        protected float _CurrentY { get { return this._CurrentCoordinates.Y; } set { this._CurrentCoordinates.Y = value; } }

        protected int _MovmentSpeed = 250;//200-300 is a good idea

        public void SpriteMoveUpdate(Peripherals PeripheralIO, float deltaTime)
        {
            Move(PeripheralIO, deltaTime);
        }
        private void Move(Peripherals PeripheralIO, float deltaTime)
        {
            if(_IsPlayerControlled)
            {

                if(PeripheralIO.GetUpKey)
                {
                    //WMove up (or whatever its  2D game, maybe ladders)
                    MoveUp(deltaTime);
                }
                if (PeripheralIO.GetLeftKey)
                {
                    //Move Left
                    MoveLeft(deltaTime);
                }
                if (PeripheralIO.GetDownKey)
                {
                    //WMove down (or whatever its  2D game, maybe ladders)
                    MoveDown(deltaTime);
                }
                if (PeripheralIO.GetRightKey)
                {
                    //Move Right
                    MoveRight(deltaTime);
                }
                if (PeripheralIO.GetSprintKey)
                {
                    //Sprint
                }
                if (PeripheralIO.GetCrouchKey)
                {
                    //Crouch
                }
                if (PeripheralIO.GetJumpKey)
                {
                    //Jump
                }

            }
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
