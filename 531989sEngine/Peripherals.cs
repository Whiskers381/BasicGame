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

        //Ignore these for now
        //Motion
        private bool _UpKey { get; set; } = false;
        private bool _LeftKey { get; set; } = false;
        private bool _DownKey { get; set; } = false;
        private bool _RightKey { get; set; } = false;
        private bool _CrouchKey { get; set; } = false;
        private bool _SprintKey { get; set; } = false;
        private bool _JumpKey { get; set; } = false;

        private float _ControllerX { get; set; } = 0;
        private float _ControllerY { get; set; } = 0;
        //private GamePadDeadZone _ControllerDeadZone { get; set; } = 2;

        private bool _IsControllerX { get; set; } = false;
        private bool _IsControllerY { get; set; } = false;

        //System
        public bool Escape = false;
        public bool FullScreenKey = false;


        //Member variables
        private int[] _MousePos = new int[] { 0, 0 };
        // Poll for current keyboard state
        

        public Peripherals()
        {
            
                

        }
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
            // x = gamePadState.ThumbSticks.Left.X * characterInstance.MaxSpeed
            _ControllerX = _state.ThumbSticks.Left.X;
            _ControllerY = _state.ThumbSticks.Left.Y;
            if(_ControllerX != 0)
            {
                _IsControllerX = true;
            }
            else
            {
                _IsControllerX = false;
            }
            if (_ControllerY != 0)
            {
                _IsControllerY = true;
            }
            else
            {
                _IsControllerY = false;
            }

        }
        #region Auto getters
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
        //Controller Getters
        public bool GetIsControllerX
        {
            get
            {
                return _IsControllerX;
            }
        }
        public bool GetIsControllerY
        {
            get
            {
                return _IsControllerY;
            }
        }
        public float GetControllerX
        {
            get
            {
                return _ControllerX;
            }
        }
        public float GetControllerY
        {
            get
            {
                return _ControllerY;
            }
        }
        #endregion
    }
}
