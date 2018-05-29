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
        // _IsPlayerControlled is a variables used to detect if a sprite is going to be moved via the keyboard inputs (W,A,S,D etc) therefore is false by default   
        bool _IsPlayerControlled = false;

    }
}
