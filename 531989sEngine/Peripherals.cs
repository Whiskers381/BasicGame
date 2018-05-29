using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace BasicEngine
{
    class Peripherals
    {

        //Ignore these for now
        private bool WkeyDown = false;
        private bool AkeyDown = false;
        private bool SkeyDown = false;
        private bool DkeyDown = false;
        private bool CtrlkeyDown = false;
        private bool ShftkeyDown = false;
        private bool SpacekeyDown = false;
        private bool Escape = false;


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
        }
        public void MouseUpdate(Game1 game)
        {
            MouseState state = Mouse.GetState();
            _MousePos[0] = state.X;
            _MousePos[1] = state.Y;
#if DEBUG
            Console.WriteLine( "Mouse X pos, {0} Mouse Y Pos, {1}", _MousePos[0],_MousePos[1] );
#endif
        }
        public void KeyboardUpdate(Game1 game)
        {
            KeyboardState _state = Keyboard.GetState();
            if (_state.IsKeyDown(Keys.Escape)) { game.Exit(); Console.WriteLine("Escape"); }
            else { Console.WriteLine("No Escape"); }
        }
    }
}
