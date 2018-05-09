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
    public class SpriteText : Sprite
    {

        #region MemberVariables

        SpriteFont _Font;
        string _Text;

        public enum XAdjust { Left, Right, Centre }
        public enum YAdjust { Top, Bottem, Centre }

        #endregion MemberVariables

        #region Constructors

        public SpriteText(string text, SpriteFont font, int xAdjust, int yAdjust, Vector2 coordinates) : this(text, font, coordinates)
        {
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
        public SpriteText(string text, SpriteFont font, int xAdjust, int yAdjust, Vector2 coordinates, Color color) : this(text, font, xAdjust, yAdjust, coordinates)
        {
            _Color = color;
        }
        public SpriteText(string text, SpriteFont font, string xAdjust, string yAdjust, Vector2 coordinates) : base(coordinates)
        {
            _Font = font;
            _Text = text;
            _Color = Color.Red;

            switch (xAdjust)
            {
                case "Left":
                    _DefaultCoordinates.X = coordinates.X;
                    break;
                case "Right":
                    _DefaultCoordinates.X = Game1._ScreenWidth - _Font.MeasureString(_Text).X + coordinates.X;
                    break;
                case "Centre":
                    _DefaultCoordinates.X = (Game1._HalfScreenWidth) - (_Font.MeasureString(_Text).X  / 2) + coordinates.X;
                    break;
            }
            switch (yAdjust)
            {
                case "Top":
                    _DefaultCoordinates.Y = coordinates.Y;
                    break;
                case "Bottem":
                    _DefaultCoordinates.Y = Game1._ScreenHeight - _Font.MeasureString(_Text).Y + coordinates.Y;
                    break;
                case "Centre":
                    _DefaultCoordinates.Y = (Game1._HalfScreenHeight) - (_Font.MeasureString(_Text).Y / 2) + coordinates.Y;
                    break;
            }
            Reset();
        }
        public SpriteText(string text, SpriteFont font, string xAdjust, string yAdjust, Vector2 coordinates, Color color) : this(text, font, xAdjust, yAdjust, coordinates)
        {
            _Color = color;
        }
        private SpriteText(string text, SpriteFont font, Vector2 coordinates) : base(coordinates)
        {
            _Font = font;
            _Text = text;
            _Color = Color.Red;
        }

        #endregion Constructors

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_Font, _Text, new Vector2(_CurrentX, _CurrentY), _Color);
        }

        public override void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}
