﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BasicEngine
{
    public class StateGamePlaying : State
    {
        protected PlayerCharacter _PlayerCharacter;

        protected Dictionary<int, Level> _Levels;

        protected Level _CurrentLevel;
        protected Level _NextLevel;

        protected List<Sprite> _Sprites;

        protected List<WormKing> _WormKings = new List<WormKing>();

        public void ChangeLevel(Level level)
        {
            _NextLevel = level;
        }

        public StateGamePlaying(ContentManager content, Game1 game, GraphicsDevice graphicsDevice, Camera2d camera2D) : base(content, game, graphicsDevice, camera2D)
        {
            _Sprites = new List<Sprite>();

            _Levels = _Game.XmlContent.Levels;

            _CurrentLevel = _Levels[_Game.XmlContent.FirstLevel];

            _PlayerCharacter = new PlayerCharacter(
                _Game.XmlContent.PlayerCharacterUpTextures,
                _Game.XmlContent.PlayerCharacterDownTextures,
                _Game.XmlContent.PlayerCharacterLeftTextures,
                _Game.XmlContent.PlayerCharacterRightTextures,
                _CurrentLevel.PlayerCharacterDefaultCoordinates);

            //_WormKings.Add(new WormKing(content.Load<Texture2D>("WormKingPart"), new Vector2(200, 200), 20, 8));
            //_WormKings.Add(new WormKing(content.Load<Texture2D>("WormKingPart"), new Vector2(300, 300), 40, 8, Color.Green));
            _WormKings.Add(new WormKing(content.Load<Texture2D>("WormKingPart"), new Vector2(400, 400), 500, 8, Color.GreenYellow));

            foreach(WormKing wormKing in _WormKings)
            {
                _Sprites.Add(wormKing);
            }

            foreach (Sprite text in _Texts)
            {
                _Sprites.Add(text);
            }
            foreach (Sprite block in _CurrentLevel.Blocks)
            {
                _Sprites.Add(block);
            }
            _Sprites.Add(_PlayerCharacter);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _GraphicsDevice.Clear(new Color(0, 50, 50));

            spriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, _Camera2D.get_transformation(_GraphicsDevice));

            foreach (Sprite sprite in _Sprites)
            {
                sprite.Draw(spriteBatch);
            }

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (_NextLevel != null)
            {
                _CurrentLevel = _NextLevel;

                _NextLevel = null;
            }

            _Camera2D.Pos = _PlayerCharacter.CurrentCoordinates;//new Vector2(_WormKing._Parts[19].CurrentX, _WormKing._Parts[19].CurrentY)

            _PlayerCharacter.Update(1.0f / 60.0f);

            foreach(WormKing wormKing in _WormKings)
            {
                wormKing.Update(1.0f / 60.0f);
                wormKing.UpdatePlayerCharacterCoordinates(_PlayerCharacter.CurrentCoordinates);
            }
        }
    }
}