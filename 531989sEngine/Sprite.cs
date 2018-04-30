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
    class Sprite
    {
        #region MemberVariables

        #region Texture Stuff
        protected Texture2D _CurrentTexture;
        protected Rectangle _Rectangle;
        #endregion

        #region Coordinates
        public Vector2 _CurrentCoordinates;
        public float _CurrentX
        {
            get
            {
                return this._CurrentCoordinates.X;
            }
            set
            {
                this._CurrentCoordinates.X = value;
            }
        }
        public float _CurrentY
        {
            get
            {
                return this._CurrentCoordinates.Y;
            }
            set
            {
                this._CurrentCoordinates.Y = value;
            }
        }
        public Vector2 _DefaultCoordinates;
        public float _DefaultX
        {
            get
            {
                return this._DefaultCoordinates.X;
            }
            set
            {
                this._DefaultCoordinates.X = value;
            }
        }
        public float _DefaultY
        {
            get
            {
                return this._DefaultCoordinates.Y;
            }
            set
            {
                this._DefaultCoordinates.Y = value;
            }
        }
        #endregion

        #endregion

        #region Constructors
        public Sprite()
        {

        }
        public Sprite(Texture2D texture, Vector2 defaultCoordinates)
        {
            _CurrentTexture = texture;
            _DefaultCoordinates = defaultCoordinates;
            Reset();
            _Rectangle = new Rectangle((int)_CurrentX, (int)_CurrentY, texture.Width, texture.Height);
        }
        #endregion

        
        public virtual void Update(float deltaTime)
        {

        }
        public bool IntersectsWith(Sprite pSprite)
        {
            return _Rectangle.Intersects(pSprite._Rectangle);
        }
        public void Reset()
        {
            _CurrentCoordinates = _DefaultCoordinates;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_CurrentTexture, _CurrentTexture.Bounds, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, 0);
        }
    }
}