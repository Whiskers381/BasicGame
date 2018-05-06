using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml;

namespace BasicEngine
{
    public class WormKingMovment
    {
        public float RotationAngle;
        public Vector2 Coordinates;

        public WormKingMovment(float rotationAngle, Vector2 coordinates)
        {
            RotationAngle = rotationAngle;
            Coordinates = coordinates;
        }
    }
}
