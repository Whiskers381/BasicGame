#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

#endregion Using

namespace BasicEngine
{
    public class WormKing : TextureSprite
    {
        #region Member Variables

        public List<WormKingPart> _Parts = new List<WormKingPart>();//this isn't meant to be public but i wanted the camra to folow the worm for now and cba making a temp getter
        protected List<WormKingMovment> _Movements = new List<WormKingMovment>();
        protected int _length;
        //protected int _partDelay;

        protected int _MovmentSpeed = 200;//200-300 is a good idea
        public float _RotationAngle = 0;

        protected Vector2 _PlayerCharacterCoordinates;

        #endregion Member Variables

        #region Setters

        public void UpdatePlayerCharacterCoordinates(Vector2 playerCharacterCoordinates)
        {
            _PlayerCharacterCoordinates = playerCharacterCoordinates;
        }

        #endregion Setters

        #region Constructors

        public WormKing(Texture2D texture, Vector2 defaultCoordinates, int Length) : base(texture, defaultCoordinates)//, int partDelay
        {
            _length = Length;
            for(int i = 1; i <= _length; i++)
            {
                _Parts.Add(new WormKingPart(texture, new Vector2(_DefaultCoordinates.X, _DefaultCoordinates.Y)));

                for(int j = 0; j < _length; j++)
                {
                    _Movements.Add(new WormKingMovment(_RotationAngle, defaultCoordinates));
                }
            }
        }

        #endregion Constructors

        #region Draw and Update

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(_CurrentTexture, _Rectangle, null, _Color, _RotationAngle, new Vector2(16, 24), SpriteEffects.None, 0);

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
                UpdateRotation(deltaTime, 0.5);
                
            }
            else
            {
                UpdateRotation(deltaTime, -20);
                //RotationAngle -= 0.5f;

            }
            Move(_MovmentSpeed * deltaTime);

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
            for (int i = 0; i < _length; i++)
            {
                _Parts[i].UpdateMovement(_Movements[i * 8]);
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
    }
}
