using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BasicEngine
{
    public class StartScreenState : State
    {
        public StartScreenState(ContentManager content, Game1 game, GraphicsDevice graphicsDevice, Camera2d camera2D) : base(content, game, graphicsDevice, camera2D)
        {
            _Texts = _Game.XmlContent.StartScreenText;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _GraphicsDevice.Clear(new Color(0, 50, 50));

            spriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, _Camera2D.get_transformation(_GraphicsDevice));

            foreach (Text text in _Texts)
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
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                _Game.ChangeState(new GamePlaying(_Content, _Game, _GraphicsDevice, _Camera2D));
            }
        }
    }
}
