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
    public abstract class Sprite : Movement, IDerivedFromXml
    {
        #region Fields

        protected Color _Colour;
        protected Rectangle _Rectangle;
        public Rectangle Rectangle { get { return _Rectangle; } }


        protected float _DefaultX
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
        protected float _DefaultY
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

        public Vector2 CurrentCoordinates { get { return _CurrentCoordinates; } set { _CurrentCoordinates = value; } }
        public float CurrentX { get { return _CurrentX; } set { _CurrentX = value; } }
        public float CurrentY { get { return _CurrentY; } set { _CurrentY = value; } }


        #endregion Fields

        #region Methods

        public Sprite()
        {

        }

        public Sprite(Vector2 defaultCoordinates)
        {
            _DefaultCoordinates = defaultCoordinates;
            Reset();

            _Colour = Color.White;
        }

        public void Reset()
        {
            _CurrentCoordinates = _DefaultCoordinates;
        }

        public bool IntersectsWith(Sprite pSprite)
        {
            return _Rectangle.Intersects(pSprite._Rectangle);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }

        public virtual XmlNode ToXml(XmlDocument document, XmlNode parentNode)
        {
            throw new NotImplementedException();
        }


        #endregion Methods
    }
}
