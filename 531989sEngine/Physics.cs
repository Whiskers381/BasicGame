using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BasicEngine
{
    public class Physics
    {
        protected Vector2 _CurrentCoordinates = new Vector2(0, 0);
        protected Vector2 _DefaultCoordinates = new Vector2(0, 0);
        // _IsPlayerControlled is a variables used to detect if a sprite is going to be moved via the keyboard inputs (W,A,S,D etc) therefore is false by default as the majority of sprites are static or have fixed movement
        protected bool _IsPlayerControlled = false;

        protected float _CurrentX { get { return _CurrentCoordinates.X; } set { _CurrentCoordinates.X = value; } }
        protected float _CurrentY { get { return _CurrentCoordinates.Y; } set { _CurrentCoordinates.Y = value; } }

        protected int _MovmentSpeed = 225;//200-300 is a good idea
        protected int _SprintSpeed = 450;//200-300 is a good idea
        protected int _CurrentSpeed = 100;

        

        #region Move Update

        public void SpriteMoveUpdate(Peripherals PeripheralIO, float deltaTime)
        {
            Move(PeripheralIO, deltaTime);
        }
        #endregion
        #region Movement
        protected void Move(Peripherals PeripheralIO, float deltaTime)
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
                    Sprint();
                }
                else
                {
                    StopSprint();
                }
                if (PeripheralIO.GetCrouchKey)
                {
                    //Crouch
                }
                if (PeripheralIO.GetJumpKey)
                {
                    //Jump
                }
                if (PeripheralIO.GetIsControllerX)
                {
                    ControllerMoveX(PeripheralIO, deltaTime);
                }
                if (PeripheralIO.GetIsControllerY)
                {
                    ControllerMoveY(PeripheralIO, deltaTime);
                }

            }
        }
        #region Movement
        #region Keyboard Movement
        public void MoveUp(float deltaTime)
        {
            _CurrentY -= _CurrentSpeed * deltaTime;
            Console.WriteLine("Moving up");
        }
        public void MoveDown(float deltaTime)
        {
            _CurrentY += _CurrentSpeed * deltaTime;
            Console.WriteLine("Moving Down");
        }
        public void MoveLeft(float deltaTime)
        {
            _CurrentX -= _CurrentSpeed * deltaTime;
            Console.WriteLine("Moving Left");
        }
        public void MoveRight(float deltaTime)
        {
            _CurrentX += _CurrentSpeed * deltaTime;
            Console.WriteLine("Moving Right");
        }
        public void Sprint()
        {
            _CurrentSpeed = _SprintSpeed;
            Console.WriteLine("Sprinting");
        }
        public void StopSprint()
        {
            _CurrentSpeed = _MovmentSpeed ;
        }
        #endregion
        #region Controller Movement
        public void ControllerMoveX(Peripherals PeripheralIO, float deltaTime)
        {
            Console.WriteLine(PeripheralIO.GetControllerX);
            _CurrentX += (_MovmentSpeed * PeripheralIO.GetControllerX ) * deltaTime;
            Console.WriteLine("Moving X");
        }
        public void ControllerMoveY(Peripherals PeripheralIO, float deltaTime)
        {
            Console.WriteLine(PeripheralIO.GetControllerY);
            _CurrentY -= (_MovmentSpeed * PeripheralIO.GetControllerY) * deltaTime;
            Console.WriteLine("Moving Y");
        }
        #endregion
        #endregion
        #endregion

    }
}
