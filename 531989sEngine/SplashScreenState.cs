using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace BasicEngine
{
    public class SplashScreenState : State
    {
        float _DurationLimit = 4f;
        float _Duration = 0f;

        public SplashScreenState(ContentManager content, Game1 game, GraphicsDevice graphicsDevice, Camera2d camera2D) : base(content, game, graphicsDevice, camera2D)
        {
            _Texts = _Game.XmlContent.SplashScreenText;
            _Camera2D.Pos = new Vector2(400, 240);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _GraphicsDevice.Clear(new Color(0, 50, 50));

            spriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, _Camera2D.get_transformation(_GraphicsDevice));

            foreach (TextSprite text in _Texts)
            {
                text.Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (_Duration >= _DurationLimit || Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                _Game.ChangeState(new StartScreenState(_Content, _Game, _GraphicsDevice, _Camera2D));
            }
            else
            {
                _Duration += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
    }
}
