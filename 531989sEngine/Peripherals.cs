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
        //System
        public bool Escape = false;
        public bool FullScreenKey = false;
        #region Keyboard mapping
        //Motion
        private bool _UpKey { get; set; } = false;
        private bool _LeftKey { get; set; } = false;
        private bool _DownKey { get; set; } = false;
        private bool _RightKey { get; set; } = false;
        private bool _CrouchKey { get; set; } = false;
        private bool _SprintKey { get; set; } = false;
        private bool _JumpKey { get; set; } = false;
        #endregion
        #region Controller mapping
        private float _ControllerLeftX { get; set; } = 0;
        private float _ControllerLeftY { get; set; } = 0;
        private float _ControllerRightX { get; set; } = 0;
        private float _ControllerRightY { get; set; } = 0;
        //private GamePadDeadZone _ControllerDeadZone { get; set; } = 2;

        //Analogue sticks
        private bool _IsControllerLeftX { get; set; } = false;
        private bool _IsControllerLeftY { get; set; } = false;
        private bool _IsControllerRightX { get; set; } = false;
        private bool _IsControllerRightY { get; set; } = false;
        private bool _IsControllerLeftClick { get; set; } = false;
        private bool _IsControllerRightClick { get; set; } = false;

        //Lettered Buttons
        private bool _IsControllerXButton { get; set; } = false;
        private bool _IsControllerAButton { get; set; } = false;
        private bool _IsControllerYButton { get; set; } = false;
        private bool _IsControllerBButton { get; set; } = false;

        //Triggers
        private bool _IsControllerLeftShoulder { get; set; } = false;
        private bool _IsControllerLeftTrigger { get; set; } = false;
        private bool _IsControllerRightShoulder { get; set; } = false;
        private bool _IsControllerRightTrigger { get; set; } = false;

        //D Pad
        private bool _IsControllerDDown { get; set; } = false;
        private bool _IsControllerDLeft { get; set; } = false;
        private bool _IsControllerDRight { get; set; } = false;
        private bool _IsControllerDUp { get; set; } = false;

        //Misc Center buttons
        private bool _IsControllerBack { get; set; } = false;
        private bool _IsControllerBig { get; set; } = false;
        private bool _IsControllerStart { get; set; } = false;
        #endregion


        //Member variables
        private int[] _MousePos = new int[] { 0, 0 };

        
        public void Update(Game1 game)
        {
            //Updates the mouse and keyboard and controller
            MouseUpdate(game);
            KeyboardUpdate(game);
            ControllerUpdate(game);

            #region Debug writeouts
#if DEBUG
            Console.Write("Mouse Pos {0},{1}.  Current Keys down are: ", _MousePos[0], _MousePos[1]);
            if(_UpKey)
            { Console.Write(" W"); }
            if (_LeftKey)
            { Console.Write(" A"); }
            if (_DownKey)
            { Console.Write(" S"); }
            if (_RightKey)
            { Console.Write(" D"); }
            if (_SprintKey)
            { Console.Write(" Shift"); }
            if (_CrouchKey)
            { Console.Write(" Ctrl"); }
            if (_JumpKey)
            { Console.Write(" Space"); }
            if (FullScreenKey)
            { Console.Write(" FullScreen"); }
            Console.WriteLine();
#endif
            #endregion
        }
        public void MouseUpdate(Game1 game)
        {
            MouseState state = Mouse.GetState();
            #region Mouse Decection
            _MousePos[0] = state.X;
            _MousePos[1] = state.Y;
            #endregion
        }
        public void KeyboardUpdate(Game1 game)
        {
            KeyboardState _state = Keyboard.GetState();
            #region Key Detection
            if (_state.IsKeyDown(Keys.Escape)) { Escape = true; } else { Escape = false; }
            if (_state.IsKeyDown(Keys.W)) { _UpKey = true;}else { _UpKey = false; }
            if (_state.IsKeyDown(Keys.A)) { _LeftKey = true; } else { _LeftKey = false; }
            if (_state.IsKeyDown(Keys.S)) { _DownKey = true; } else { _DownKey = false; }
            if (_state.IsKeyDown(Keys.D)) { _RightKey = true; } else { _RightKey = false; }
            if (_state.IsKeyDown(Keys.LeftShift)) { _SprintKey = true; } else { _SprintKey = false; }
            if (_state.IsKeyDown(Keys.LeftControl)) { _CrouchKey = true; } else { _CrouchKey = false; }
            if (_state.IsKeyDown(Keys.Space)) { _JumpKey = true; } else { _JumpKey = false; }

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
                _IsControllerLeftX = true;
            }
            else
            {
                _IsControllerLeftX = false;
            }
            if (_ControllerLeftY != 0)
            {
                _IsControllerLeftY = true;
            }
            else
            {
                _IsControllerLeftY = false;
            }
            if (_state.IsButtonDown(Buttons.LeftThumbstickDown))
            {

            }
            else
            {

            }
            if (_state.IsButtonDown(Buttons.RightThumbstickDown))
            {

            }
            else
            {

            }
            #endregion
            #region Lettered buttons
            if (_state.IsButtonDown(Buttons.A))
            {
                _IsControllerAButton = true;
            }
            else
            {
                _IsControllerAButton = false;
            }
            if (_state.IsButtonDown(Buttons.X))
            {
                _IsControllerXButton = true;
            }
            else
            {
                _IsControllerXButton = false;
            }
            if (_state.IsButtonDown(Buttons.Y))
            {
                _IsControllerYButton = true;
            }
            else
            {
                _IsControllerYButton = false;
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
                _IsControllerDDown = true;
            }
            else
            {
                _IsControllerDDown = false;
            }
            if (_state.IsButtonDown(Buttons.DPadLeft))
            {
                _IsControllerDLeft = true;
            }
            else
            {
                _IsControllerDLeft = true;
            }
            if (_state.IsButtonDown(Buttons.DPadRight))
            {
                _IsControllerDRight = true;
            }
            else
            {
                _IsControllerDRight = true;
            }
            if (_state.IsButtonDown(Buttons.DPadUp))
            {
                _IsControllerDUp = true;
            }
            else
            {
                _IsControllerDUp = true;
            }
            #endregion
            #region Triggers
            if (_state.IsButtonDown(Buttons.LeftShoulder))
            {
                _IsControllerLeftShoulder = true;
            }
            else
            {
                _IsControllerLeftShoulder = false;
            }
            if (_state.IsButtonDown(Buttons.RightShoulder))
            {
                _IsControllerRightShoulder = true;
            }
            else
            {
                _IsControllerRightShoulder = false;
            }
            if (_state.IsButtonDown(Buttons.LeftTrigger))
            {
                _IsControllerLeftTrigger = true;
            }
            else
            {
                _IsControllerLeftTrigger = false;
            }
            if (_state.IsButtonDown(Buttons.RightTrigger))
            {
                _IsControllerRightTrigger = true;
            }
            else
            {
                _IsControllerRightTrigger = false;
            }
            #endregion
            #region Misc Center buttons
            if (_state.IsButtonDown(Buttons.Start))
            {
                _IsControllerStart = true;
            }
            else
            {
                _IsControllerStart = false;
            }
            if (_state.IsButtonDown(Buttons.Back))
            {
                _IsControllerBack = true;
            }
            else
            {
                _IsControllerBack = false;
            }
            if (_state.IsButtonDown(Buttons.BigButton))
            {
                _IsControllerBig = true;
            }
            else
            {
                _IsControllerBig = false;
            }
            #endregion
        }
        #region Auto getters
        #region Keyboard Getters
        //Keyboard Getters
        public bool GetUpKey
        {
            get
            {
                return _UpKey;
            }
        }
        public bool GetLeftKey
        {
            get
            {
                return _LeftKey;
            }
        }
        public bool GetDownKey
        {
            get
            {
                return _DownKey;
            }
        }
        public bool GetRightKey
        {
            get
            {
                return _RightKey;
            }
        }
        public bool GetCrouchKey
        {
            get
            {
                return _CrouchKey;
            }
        }
        public bool GetSprintKey
        {
            get
            {
                return _SprintKey;
            }
        }
        public bool GetJumpKey
        {
            get
            {
                return _JumpKey;
            }
        }
        #endregion
        #region Controller Getters
        #region Analogue stick getters
        public bool GetIsControllerLeftX
        {
            get
            {
                return _IsControllerLeftX;
            }
        }
        public bool GetIsControllerLeftY
        {
            get
            {
                return _IsControllerLeftY;
            }
        }
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
        public bool GetIsControllerRightX
        {
            get
            {
                return _IsControllerRightX;
            }
        }
        public bool GetIsControllerRightY
        {
            get
            {
                return _IsControllerRightY;
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
        public bool GetControllerLeftClick
        {
            get
            {
                return _IsControllerLeftClick;
            }
        }
        public bool GetControllerRightClick
        {
            get
            {
                return _IsControllerRightClick;
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
        #region Dpad Getters
        public bool GetIsControllerDPadLeft
        {
            get
            {
                return _IsControllerDLeft;
            }
        }
        public bool GetIsControllerDPadRight
        {
            get
            {
                return _IsControllerDRight;
            }
        }
        public bool GetIsControllerDPadUp
        {
            get
            {
                return _IsControllerDUp;
            }
        }
        public bool GetIsControllerDPadDown
        {
            get
            {
                return _IsControllerDDown;
            }
        }
        #endregion
        #region Trigger Getters
        public bool GetControllerLeftShoulder
        {
            get
            {
                return _IsControllerLeftShoulder;
            }
        }
        public bool GetControllerRightShoulder
        {
            get
            {
                return _IsControllerRightShoulder;
            }
        }
        public bool GetControllerLeftTrigger
        {
            get
            {
                return _IsControllerLeftTrigger;
            }
        }
        public bool GetControllerRightTrigger
        {
            get
            {
                return _IsControllerRightTrigger;
            }
        }
        #endregion
        #region Misc Center Buttons
        public bool GetControllerBack
        {
            get
            {
                return _IsControllerBack;
            }
        }
        public bool GetControllerBig
        {
            get
            {
                return _IsControllerBig;
            }
        }
        public bool GetControllerStart
        {
            get
            {
                return _IsControllerStart;
            }
        }
        #endregion
        #endregion
        #endregion
    }
}