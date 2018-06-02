using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BasicEngine
{
    public class StateStartScreen : State
    {
        public StateStartScreen(ContentManager content, Game1 game, GraphicsDevice graphicsDevice, Camera2d camera2D) : base(content, game, graphicsDevice, camera2D)
        {
            _Texts = XmlContent.StartScreenText;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch,ref Color BackgroundColour)
        {
            _GraphicsDevice.Clear(BackgroundColour);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, _Camera2D.get_transformation(_GraphicsDevice));

            foreach (SpriteText text in _Texts)
            {
                text.Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime,ref Peripherals IoController)
        {
            
        }

        public override void Update(GameTime gameTime,ref Peripherals IoController)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.D2))
            {
                _Game.ChangeState(new StateDevEnvironment(_Content, _Game, _GraphicsDevice, _Camera2D));
            }
            if(IoController.GetUserAction)
            {
                _Game.ChangeState(new StateGamePlaying(_Content, _Game, _GraphicsDevice, _Camera2D));
                Thread.Sleep(150);
            }
        }
    }
}
