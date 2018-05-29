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
    public abstract class Sprite : Physics
    {
        #region Fields
        protected Color _Colour;

        //Vector coords are depreciated from this file as they're implemented through the Physics classs
        //protected Vector2 _CurrentCoordinates = new Vector2(0, 0);
        protected float _CurrentX
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
        protected float _CurrentY
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
        //Vector coords are depreciated from this file as they're implemented through the Physics classs
        //protected Vector2 _DefaultCoordinates = new Vector2(0, 0);
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

        public Vector2 CurrentCoordinates { get { return _CurrentCoordinates; } set { } }
        public float CurrentX { get { return _CurrentX; } set { } }
        public float CurrentY { get { return _CurrentY; } set { } }

        #endregion Fields

        #region Methods

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

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}
