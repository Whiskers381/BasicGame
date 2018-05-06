using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;
using System.Diagnostics;

namespace BasicEngine//531989sEngine
{
    public abstract class Sprite
    {
        #region Fields
        protected Color _Color;

        public Vector2 _CurrentCoordinates = new Vector2(0, 0);
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
        public Vector2 _DefaultCoordinates = new Vector2(0, 0);
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

        #endregion Fields

        #region Methods

        public Sprite(Vector2 defaultCoordinates)
        {
            _DefaultCoordinates = defaultCoordinates;
            Reset();

            _Color = Color.White;
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
