﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;

namespace BasicEngine
{
    class Text
    {
        SpriteFont _Font;
        string _Text;
        Color _Color;

        public enum XAdjust { Left, Right, Centre }
        public enum YAdjust { Top, Bottem, Centre }

        #region Coordinates
        public Vector2 _CurrentCoordinates = new Vector2(0,0);
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
        #endregion

        public Text(SpriteFont font, string text, int xAdjust, int yAdjust, Vector2 coordinates)
        {
            _Font = font;
            _Text = text;
            _Color = Color.Red;

            switch (xAdjust)
            {
                case (int)XAdjust.Left:
                    _DefaultCoordinates.X = coordinates.X;
                    break;
                case (int)XAdjust.Right:
                    _DefaultCoordinates.X = Game1._ScreenWidth - _Font.MeasureString(_Text).X + coordinates.X;
                    break;
                case (int)XAdjust.Centre:
                    _DefaultCoordinates.X = (Game1._HalfScreenWidth) - (_Font.MeasureString(_Text).X + coordinates.X / 2);
                    break;
            }
            switch (yAdjust)
            {
                case (int)YAdjust.Top:
                    _DefaultCoordinates.Y = coordinates.Y;
                    break;
                case (int)YAdjust.Bottem:
                    _DefaultCoordinates.Y = Game1._ScreenWidth - _Font.MeasureString(_Text).Y + coordinates.Y;
                    break;
                case (int)YAdjust.Centre:
                    _DefaultCoordinates.Y = (Game1._HalfScreenHeight) - (_Font.MeasureString(_Text).Y + coordinates.Y / 2);
                    break;
            }
            Reset();
        }
        public Text(SpriteFont font, string text, int xAdjust, int yAdjust, Vector2 coordinates, Color color) : this(font, text, xAdjust, yAdjust, coordinates)
        {
            _Color = color;
        }

        public void Reset()
        {
            _CurrentCoordinates = _DefaultCoordinates;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_Font, _Text, new Vector2((Game1._ScreenWidth / 2) - (_Font.MeasureString(_Text).X / 2), _CurrentY), Color.Red);
        }
    }
}