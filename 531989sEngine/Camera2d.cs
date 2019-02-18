using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicEngine
{
    #region <NotMine href="http://www.david-amador.com/2009/10/xna-camera-2d-with-zoom-and-rotation/">
    public class Camera2d
    {
        protected float _Zoom;
        public Matrix _Transform;
        protected float _Rotation;

        #region Coordinates
        protected Vector2 _CurrentCoordinates;
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
        protected Vector2 _DefaultCoordinates;
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

        public Camera2d()
        {
            _Zoom = 2.2f;
            _Rotation = 0.0f;
            _CurrentCoordinates = Vector2.Zero;
        }

        public float Zoom
        {
            get { return _Zoom; }
            set { _Zoom = value; if (_Zoom < 0.1f) _Zoom = 0.1f; }
        }

        public float Rotation
        {
            get { return _Rotation; }
            set { _Rotation = value; }
        }

        public void Move(Vector2 amount)
        {
            _CurrentCoordinates += amount;
        }
        public Vector2 Pos
        {
            get { return _CurrentCoordinates; }
            set { _CurrentCoordinates = value; }
        }

        public Matrix get_transformation(GraphicsDevice graphicsDevice)
        {
            //if (_CurrentCoordinates.X < 0)
            //{
            //    _CurrentCoordinates.X = 0;
            //}
            //if (_CurrentCoordinates.Y > 800)
            //{
            //    _CurrentCoordinates.Y = 0;
            //}
            _Transform = Matrix.CreateTranslation(new Vector3(-_CurrentCoordinates.X, -_CurrentCoordinates.Y, 0)) * Matrix.CreateRotationZ(Rotation) * Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) * Matrix.CreateTranslation(new Vector3(graphicsDevice.Viewport.Width * 0.5f, graphicsDevice.Viewport.Height * 0.5f, 0));

            return _Transform;
        }
    }
    #endregion </NotMine>
}
