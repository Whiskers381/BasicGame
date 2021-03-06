﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace BasicEngine
{
    public class StateSplashScreen : State
    {
        float _DurationLimit = 4f;
        float _Duration = 0f;

        public StateSplashScreen(ContentManager content, Game1 game, GraphicsDevice graphicsDevice, Camera2d camera2D) : base(content, game, graphicsDevice, camera2D)
        {
            _Texts = XmlContent.SplashScreenText;
            _Camera2D.Pos = new Vector2(400, 240);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch,ref Color BackgroundColour)
        {
            _GraphicsDevice.Clear(BackgroundColour);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, _Camera2D.get_transformation(_GraphicsDevice));

            /*foreach (SpriteText text in _Texts)
            {
                text.Draw(spriteBatch);
            }*/
            for(ushort SpriteIndex = 0; SpriteIndex < _Texts.Count; SpriteIndex++)
            {
                _Texts[SpriteIndex].Draw(spriteBatch);
            }

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime,ref Peripherals IoController)
        {

        }

        public override void Update(GameTime gameTime,ref Peripherals IoController)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (_Duration >= _DurationLimit || keyboard.IsKeyDown(Keys.Enter))
            {
                
                _Game.ChangeState(new StateStartScreen(_Content, _Game, _GraphicsDevice, _Camera2D));
                Thread.Sleep(150);
            }
            else
            {
                _Duration += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
    }
}
