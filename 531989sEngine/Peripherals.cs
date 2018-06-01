using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace BasicEngine
{
    public class Peripherals
    {
        #region Is Key downs
        #region System
        public bool Escape = false;
        public bool FullScreenKey = false;
        public bool IsControllerPad = false;
        #endregion
        #region Action mapping
        //Front side actions
        //Motion
        private bool _Up { get; set; } = false;
        private bool _Down { get; set; } = false;
        private bool _Left { get; set; } = false;
        private bool _Right { get; set; } = false;
        //Motion modifiers
        private bool _Sprint { get; set; } = false;
        private bool _Jump { get; set; } = false;
        private bool _Crouch { get; set; } = false;
        //Actions
        private bool _UserAction { get; set; } = false;
        private bool _Reload { get; set; } = false;

        #endregion
        #region Controller mapping
        
        private float _ControllerLeftX { get; set; } = 0;
        private float _ControllerLeftY { get; set; } = 0;
        private float _ControllerRightX { get; set; } = 0;
        private float _ControllerRightY { get; set; } = 0;


        //Lettered Buttons
        private bool _IsControllerXButton { get; set; } = false;
        private bool _IsControllerAButton { get; set; } = false;
        private bool _IsControllerYButton { get; set; } = false;
        private bool _IsControllerBButton { get; set; } = false;
        #endregion
        #region Functional

        #endregion
        #endregion

        #region Member variables
        private int[] _MousePos = new int[] { 0, 0 };
        #endregion

        public void Update(Game1 game)
        {
            //Updates the mouse and keyboard and controller
            MouseUpdate(game);
            KeyboardUpdate(game);
            ControllerUpdate(game);
        }

        public void MouseUpdate(Game1 game)
        {
            MouseState state = Mouse.GetState();
            #region Mouse Detection
            _MousePos[0] = state.X;
            _MousePos[1] = state.Y;
            #endregion
        }
        public void KeyboardUpdate(Game1 game)
        {
            KeyboardState _state = Keyboard.GetState();
            #region Key Detection
            

            if (_state.IsKeyDown(Keys.W)) { _Up = true;}else { _Up = false; }
            if (_state.IsKeyDown(Keys.A)) { _Left = true; } else { _Left = false; }
            if (_state.IsKeyDown(Keys.S)) { _Down = true; } else { _Down = false; }
            if (_state.IsKeyDown(Keys.D)) { _Right = true; } else { _Right = false; }
            if (_state.IsKeyDown(Keys.LeftShift)) { _Sprint = true; } else { _Sprint = false; }
            if (_state.IsKeyDown(Keys.LeftControl)) { _Crouch = true; } else { _Crouch = false; }
            if (_state.IsKeyDown(Keys.Space)) { _Jump = true; } else { _Jump = false; }
            if (_state.IsKeyDown(Keys.F)) { _UserAction = true; } else { _UserAction = false; }

            //System actions
            if (_state.IsKeyDown(Keys.Escape)) { Escape = true; } else { Escape = false; }
            //The the below statements if true they sleep for 150ms, this is to give the user enough time to release the key so the action doesn't keep toggling on and off
            if (_state.IsKeyDown(Keys.F11) && FullScreenKey == false) { FullScreenKey = true; Thread.Sleep(150); }
            else if(_state.IsKeyDown(Keys.F11) && FullScreenKey == true) { FullScreenKey = false; Thread.Sleep(150); }

            

            #endregion

        }
        public void ControllerUpdate(Game1 game)
        {
            GamePadState _state = GamePad.GetState(0);
            _ControllerLeftX = _state.ThumbSticks.Left.X;
            _ControllerLeftY = _state.ThumbSticks.Left.Y;
            _ControllerRightX = _state.ThumbSticks.Right.X;
            _ControllerRightY = _state.ThumbSticks.Right.Y;


            #region Analogue sticks
            if (_ControllerLeftX != 0)
            {
                    if(_ControllerLeftX > 0)
                    {
                        //move right
                        _Right = true;
                    }
                    else if(_ControllerLeftX < 0)
                    {
                        //move left
                        _Left = true;
                    }
            }
            if (_ControllerLeftY != 0)
            {
                if (_ControllerLeftY > 0)
                {
                    //move up
                    _Up = true;
                }
                else if (_ControllerLeftY < 0)
                {
                    //move down
                    _Down = true;
                }
            }
            #endregion
            #region Lettered buttons
            
            if (_state.IsButtonDown(Buttons.A))
            {
                
                _Reload = true;

            }
            else
            {
                
                _Reload = false;
            }
            if (_state.IsButtonDown(Buttons.X))
            {
                
            }
            else
            {
                _IsControllerXButton = false;
            }
            if (_state.IsButtonDown(Buttons.Y))
            {
                _Jump = true;
            }
            else
            {
                _Jump = false;
            }
            if (_state.IsButtonDown(Buttons.B))
            {
                _IsControllerBButton = true;
            }
            else
            {
                _IsControllerBButton = false;
            }
            #endregion
            #region Dpad buttons
            if (_state.IsButtonDown(Buttons.DPadDown))
            {
                _Crouch = true;
            }
            else
            {
                _Crouch = false;
            }
            if (_state.IsButtonDown(Buttons.DPadLeft))
            {
            }
            else
            {
            }
            if (_state.IsButtonDown(Buttons.DPadRight))
            {
            }
            else
            {
            }
            if (_state.IsButtonDown(Buttons.DPadUp))
            {
            }
            else
            {
            }
            #endregion
            #region Triggers
            if (_state.IsButtonDown(Buttons.LeftShoulder))
            {
            }
            else
            {
            }
            if (_state.IsButtonDown(Buttons.RightShoulder))
            {
            }
            else
            {
            }
            if (_state.IsButtonDown(Buttons.LeftTrigger))
            {
            }
            else
            {
            }
            if (_state.IsButtonDown(Buttons.RightTrigger))
            {
            }
            else
            {
            }
            #endregion
            #region Misc Center buttons
            if (_state.IsButtonDown(Buttons.Start))
            {
            }
            else
            {
            }
            if (_state.IsButtonDown(Buttons.Back))
            {
            }
            else
            {
            }
            if (_state.IsButtonDown(Buttons.BigButton))
            {
            }
            else
            {
            }    
            #endregion

        }

        #region Auto getters
        #region Keyboard Getters
        //Keyboard Getters
        public bool GetUp
        {
            get
            {
                return _Up;
            }
        }
        public bool GetLeft
        {
            get
            {
                return _Left;
            }
        }
        public bool GetDown
        {
            get
            {
                return _Down;
            }
        }
        public bool GetRight
        {
            get
            {
                return _Right;
            }
        }
        public bool GetCrouch
        {
            get
            {
                return _Crouch;
            }
        }
        public bool GetSprint
        {
            get
            {
                return _Sprint;
            }
        }
        public bool GetJump
        {
            get
            {
                return _Jump;
            }
        }
        //Functions
        public bool GetUserAction
        {
            get
            {
                return _UserAction;
            }
        }
        #endregion
        #region Controller Getters
        #region Analogue stick getters
        public float GetControllerLeftX
        {
            get
            {
                return _ControllerLeftX;
            }
        }
        public float GetControllerLeftY
        {
            get
            {
                return _ControllerLeftY;
            }
        }
        public float GetControllerRightX
        {
            get
            {
                return _ControllerRightX;
            }
        }
        public float GetControllerRightY
        {
            get
            {
                return _ControllerRightY;
            }
        }

        #endregion
        #region Lettered Button Getters
        public bool GetIsControllerButtonX
        {
            get
            {
                return _IsControllerXButton;
            }
        }
        public bool GetIsControllerButtonY
        {
            get
            {
                return _IsControllerYButton;
            }
        }
        public bool GetIsControllerButtonA
        {
            get
            {
                return _IsControllerAButton;
            }
        }
        public bool GetIsControllerButtonB
        {
            get
            {
                return _IsControllerBButton;
            }
        }
        #endregion
        #endregion
        #endregion
    }
}