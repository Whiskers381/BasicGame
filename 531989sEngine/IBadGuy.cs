using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;
using System.Diagnostics;

namespace BasicEngine
{
    public interface IBadGuy
    {
        //The reason why there is no "Vector2 _PlayerCharacterCoordinates;" here
        //https://stackoverflow.com/questions/2115114/why-cant-c-sharp-interfaces-contain-fields

        void UpdatePlayerCharacterCoordinates(Vector2 playerCharacterCoordinates);
    }
}
