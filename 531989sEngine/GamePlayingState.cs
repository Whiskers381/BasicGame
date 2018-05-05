using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BasicEngine
{
    public class GamePlaying : State
    {
        protected PlayerCharacter _PlayerCharacter;

        protected Dictionary<int, Level> _Levels;

        protected Level _CurrentLevel;
        protected Level _NextLevel;

        protected List<Sprite> _Sprites;

        public void ChangeLevel(Level level)
        {
            _NextLevel = level;
        }

        public GamePlaying(ContentManager content, Game1 game, GraphicsDevice graphicsDevice, Camera2d camera2D) : base(content, game, graphicsDevice, camera2D)
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

            foreach(Sprite text in _Texts)
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

            _Camera2D.Pos = new Vector2(_PlayerCharacter._CurrentX, 240);

            _PlayerCharacter.Update(1.0f / 60.0f);
        }
    }
}
