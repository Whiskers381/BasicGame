using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace BasicEngine
{
    class Peripherals
    {

        //Ignore these for now
        //Motion
        private bool UpKey = false;
        private bool LeftKey = false;
        private bool DownKey = false;
        private bool RightKey = false;
        private bool CrouchKey = false;
        private bool SprintKey = false;
        private bool JumpKey = false;
        
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
            //Updates the mouse and keyboard
            MouseUpdate(game);
            KeyboardUpdate(game);
            #region Debug writeouts
#if DEBUG
            Console.Write("Mouse Pos {0},{1}.  Current Keys down are: ", _MousePos[0], _MousePos[1]);
            if(UpKey)
            { Console.Write(" W"); }
            if (LeftKey)
            { Console.Write(" A"); }
            if (DownKey)
            { Console.Write(" S"); }
            if (RightKey)
            { Console.Write(" D"); }
            if (SprintKey)
            { Console.Write(" Shift"); }
            if (CrouchKey)
            { Console.Write(" Ctrl"); }
            if (JumpKey)
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
            if (_state.IsKeyDown(Keys.W)) { UpKey = true;}else { UpKey = false; }
            if (_state.IsKeyDown(Keys.A)) { LeftKey = true; } else { LeftKey = false; }
            if (_state.IsKeyDown(Keys.S)) { DownKey = true; } else { DownKey = false; }
            if (_state.IsKeyDown(Keys.D)) { RightKey = true; } else { RightKey = false; }
            if (_state.IsKeyDown(Keys.LeftShift)) { SprintKey = true; } else { SprintKey = false; }
            if (_state.IsKeyDown(Keys.LeftControl)) { CrouchKey = true; } else { CrouchKey = false; }
            if (_state.IsKeyDown(Keys.Space)) { JumpKey = true; } else { JumpKey = false; }
            if (_state.IsKeyDown(Keys.F11) && FullScreenKey == false) { FullScreenKey = true; Thread.Sleep(100); }
            else if(_state.IsKeyDown(Keys.F11) && FullScreenKey == true) { FullScreenKey = false; Thread.Sleep(100); }
            
            #endregion

        }
    }
}
