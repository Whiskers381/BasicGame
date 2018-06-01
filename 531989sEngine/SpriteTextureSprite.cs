using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;

namespace BasicEngine
{
    public class SpriteTextureSprite : Sprite
    {
        #region MemberVariables

        #region Texture Stuff
        protected Texture2D _CurrentTexture;
        #endregion

        #endregion

        #region Constructors

        public SpriteTextureSprite() : base()
        {

        }

        public SpriteTextureSprite(Texture2D texture, Vector2 defaultCoordinates) : base(defaultCoordinates)
        {
            _CurrentTexture = texture;

            _Rectangle = new Rectangle((int)_CurrentX, (int)_CurrentY, texture.Width, texture.Height);
        }

        #endregion

        
        public override void Update(float deltaTime)
        {

        }

        public virtual void UpdateCameraPosition(Vector2 NoneCares) { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _Rectangle.X = (int)Math.Round(_CurrentX);
            _Rectangle.Y = (int)Math.Round(_CurrentY);
            spriteBatch.Draw(_CurrentTexture, _Rectangle, null, _Colour, 0f, new Vector2(0, 0), SpriteEffects.None, 0);
        }
    }
}