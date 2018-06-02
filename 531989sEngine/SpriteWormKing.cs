#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml;

#endregion Using

namespace BasicEngine
{
    public class SpriteWormKing : SpriteTextureSprite, IBadGuy, IDerivedFromXml
    {
        #region Member Variables

        public List<WormKingPart> _Parts = new List<WormKingPart>();//this isn't meant to be public but i wanted the camra to folow the worm for now and cba making a temp getter
        protected List<WormKingMovment> _Movements = new List<WormKingMovment>();
        protected int _Length;
        protected int _PartDelay;

        

        protected Vector2 _PlayerCharacterCoordinates;

        //protected int _MovmentSpeed = 200;//200-300 is a good idea
        public float _RotationAngle = 0;

        #endregion Member Variables

        #region Setters

        public void UpdatePlayerCharacterCoordinates(Vector2 playerCharacterCoordinates)
        {
            _PlayerCharacterCoordinates = new Vector2(playerCharacterCoordinates.X + 8,playerCharacterCoordinates.Y + 16);
        }

        #endregion Setters

        #region Constructors
        public SpriteWormKing() : base()
        {

        }

        public SpriteWormKing(Texture2D texture, Vector2 defaultCoordinates, int Length, int partDelay, Color color, string textureName):
            base(texture, defaultCoordinates, textureName)//, int partDelay
        {
            _Length = Length;
            _PartDelay = partDelay;

            _Colour = color;

            for (int LengthIndex = 1; LengthIndex <= _Length; LengthIndex++)
            {
                _Parts.Add(new WormKingPart(texture, new Vector2(_DefaultCoordinates.X, _DefaultCoordinates.Y), _Colour));

                for(int SegmentIndex = 0; SegmentIndex < _PartDelay; SegmentIndex++)
                {
                    _Movements.Add(new WormKingMovment(_RotationAngle, defaultCoordinates));
                }
            }
        }

        #endregion Constructors

        #region Draw and Update

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(_CurrentTexture, _Rectangle, null, Color.Green, _RotationAngle, new Vector2(16, 24), SpriteEffects.None, 0);

            foreach (WormKingPart part in _Parts)
            {
                part.Draw(spriteBatch);
            }
        }

        public override void Update(float deltaTime)
        {
            _Rectangle = new Rectangle((int)Math.Round(_CurrentX), (int)Math.Round(_CurrentY), _CurrentTexture.Width, _CurrentTexture.Height);

            if(_CurrentY > 0 && _CurrentY < 480)
            {
                UpdateRotation(deltaTime, 2);
                
            }
            else
            {
                UpdateRotation(deltaTime, 2);
                //UpdateRotation(deltaTime, -2);
                //RotationAngle -= 0.5f;

            }
            Move(_MovementSpeed * deltaTime);

            foreach (WormKingPart part in _Parts)
            {
                part.Update(deltaTime);
            }
            UpdateMovmentOfParts();
        }

        #endregion Draw and Update

        #region Protected Methods

        protected void UpdateMovmentOfParts()
        {
            for (int i = 0; i < _Length; i++)
            {
                _Parts[i].UpdateMovement(_Movements[i * _PartDelay]);
            }
            _Movements.RemoveAt(0);
            _Movements.Add(new WormKingMovment(_RotationAngle, _CurrentCoordinates));
        }

        //https://gamedev.stackexchange.com/questions/50793/moving-a-sprite-in-the-direction-its-facing-xna
        protected void Move(float speed)
        {
            Vector2 direction = new Vector2((float)Math.Cos(_RotationAngle),
                                            (float)Math.Sin(_RotationAngle));
            direction.Normalize();
            _CurrentCoordinates += direction * speed;
        }

        //https://stackoverflow.com/questions/29997133/how-do-i-make-a-texture-rotate-to-face-a-vector2
        protected void UpdateRotation(float deltaTime, double maxAngularVelocity)
        {
            Vector2 diffVec = _PlayerCharacterCoordinates - _CurrentCoordinates;
            float angle = (float)Math.Atan2(diffVec.Y, diffVec.X);

            float newRotation;

            // To make the gun point at the player:
            newRotation = MathHelper.WrapAngle(angle); // Adjust to between -PI and PI.  Actually Atan2() returns in this range anyway.

            // To make rotate towards the player with a maximum angular rotation, using the smallest direction
            var timeStepf = (float)deltaTime;
            var diffAng = MathHelper.WrapAngle(newRotation - (float)_RotationAngle); // Adjust difference to between -PI and PI.
            diffAng = timeStepf * MathHelper.Clamp(diffAng / timeStepf, (float)-maxAngularVelocity, (float)maxAngularVelocity); // Clamp the difference by the maximum angular velocity.
            newRotation = MathHelper.WrapAngle((float)_RotationAngle + diffAng); // Adjust to between -PI and PI.

            _RotationAngle = newRotation;
        }

        #endregion Protected Methods

        #region Public Methods

        public override XmlNode ToXml(XmlDocument document, XmlNode parentNode)
        {
            XmlNode node = XmlTool.CreateEmptyNode(document, parentNode, "WormKing");

            XmlTool.CreateTextNode(document, node, "Texture", _TextureName);

            XmlTool.CreateCoordinateNode(document, node, "DefaultCoordinates", (int)_DefaultX, (int)_DefaultY);

            XmlTool.CreateTextNode(document, node, "Length", _Length.ToString());

            XmlTool.CreateTextNode(document, node, "Length", _PartDelay.ToString());

            return node;
        }

        #endregion Public Methods
    }
    public class WormKingPart : SpriteTextureSprite
    {
        protected float _RotationAngle;

        public WormKingPart(Texture2D texture, Vector2 defaultCoordinates) : base(texture, defaultCoordinates)
        {

        }
        public WormKingPart(Texture2D texture, Vector2 defaultCoordinates, Color color) : base(texture, defaultCoordinates)
        {
            _Colour = color;
        }

        public void UpdateMovement(WormKingMovment movment)
        {
            _RotationAngle = movment.RotationAngle;
            _CurrentCoordinates = movment.Coordinates;
        }
        //public override void Update(float deltaTime)
        //{

        //}

        public override void Draw(SpriteBatch spriteBatch)
        {
            _Rectangle.X = (int)Math.Round(_CurrentX);
            _Rectangle.Y = (int)Math.Round(_CurrentY);
            spriteBatch.Draw(_CurrentTexture, _Rectangle, null, _Colour, _RotationAngle, new Vector2(16, 24), SpriteEffects.None, 0);
        }
    }
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
