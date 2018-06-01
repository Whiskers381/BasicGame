using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace BasicEngine
{
    public class StateGamePlaying : State
    {
        protected SpritePlayerCharacter _PlayerCharacter;

        protected Dictionary<int, Level> _Levels;
        protected List<SpritePortal> _Portals;
        protected Level _CurrentLevel;
        protected Level _NextLevel;

        protected Peripherals _IoController;

        protected List<Sprite> _AllSprites;
        protected List<Sprite> _SpritesWithUpdate;
        protected List<SpriteWormKing> _WormKings = new List<SpriteWormKing>();
        protected List<IBadGuy> _badGuys = new List<IBadGuy>();
        protected List<SpriteBlock> _Blocks;


        public void ChangeLevel(Level level)
        {
            _PlayerCharacter.CurrentCoordinates = level.PlayerCharacterDefaultCoordinates;

            _AllSprites = level.AllSprites;
            _SpritesWithUpdate = level.SpritesWithUpdate;
            _WormKings = level.WormKings;
            _badGuys = level.BadGuys;

            _Blocks = level.Blocks;

            _AllSprites.Add(_PlayerCharacter);

            _Portals = level.Portals;

            _NextLevel = level;

        }

        public StateGamePlaying(ContentManager content, Game1 game, GraphicsDevice graphicsDevice, Camera2d camera2D) : base(content, game, graphicsDevice, camera2D)
        {
            _IoController = game.IoController;
            _AllSprites = new List<Sprite>();

            _Levels = _Game.XmlContent.Levels;

            _CurrentLevel = _Levels[_Game.XmlContent.FirstLevel];

            _PlayerCharacter = new SpritePlayerCharacter(
                _Game.XmlContent.PlayerCharacterUpTextures,
                _Game.XmlContent.PlayerCharacterDownTextures,
                _Game.XmlContent.PlayerCharacterLeftTextures,
                _Game.XmlContent.PlayerCharacterRightTextures,
                _CurrentLevel.PlayerCharacterDefaultCoordinates,ref game.IoController);

            ChangeLevel(_Levels[_Game.XmlContent.FirstLevel]);

            //foreach (Sprite block in _CurrentLevel.Blocks)
            //{
            //    _AllSprites.Add(block);
            //}
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch,ref Color BackgroundColour)
        {
            _GraphicsDevice.Clear(BackgroundColour);

            spriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, _Camera2D.get_transformation(_GraphicsDevice));

            foreach (Sprite sprite in _AllSprites)
            {
                sprite.Draw(spriteBatch);
            }

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime,ref Peripherals IoController)
        {

        }

        public override void Update(GameTime gameTime,ref Peripherals IoController)
        {
            if (_NextLevel != null)
            {
                ChangeLevel(_NextLevel);
                _CurrentLevel = _NextLevel;

                

                _NextLevel = null;
            }

            for(int CollisionTargetIndex = 0; CollisionTargetIndex < _Blocks.Count; CollisionTargetIndex++)
            {


                if (_PlayerCharacter.IntersectsWith(_Blocks[CollisionTargetIndex]))
                {
                    if (_Blocks[CollisionTargetIndex].CurrentY > _PlayerCharacter.CurrentY)
                    {
                        _PlayerCharacter.CurrentY = _PlayerCharacter.CurrentY - 2;
                    }
                    else if (_Blocks[CollisionTargetIndex].Rectangle.Height < _PlayerCharacter.CurrentY)
                    {
                        _PlayerCharacter.CurrentY = _PlayerCharacter.CurrentY +2;
                    }

                    if (_PlayerCharacter.CurrentX > _Blocks[CollisionTargetIndex].CurrentX)
                    {
                        _PlayerCharacter.CurrentX = _PlayerCharacter.CurrentX + 10;
                    }
                    else if (_PlayerCharacter.CurrentX < _Blocks[CollisionTargetIndex].CurrentX)
                    {
                        _PlayerCharacter.CurrentX = _PlayerCharacter.CurrentX - 10;
                    }

                }
                else
                {
                    Console.WriteLine("No collision");
                }
            }


            _Camera2D.Pos = _PlayerCharacter.CurrentCoordinates;
            _PlayerCharacter.Update(_IoController, 1.0f / 60.0f);


            foreach(SpritePortal portal in _Portals)
            {
                if(_PlayerCharacter.IntersectsWith(portal))
                {
                    _NextLevel = _Levels[portal.LinkedLevelName];
                }
            }


            foreach(IBadGuy badGuy in _badGuys)
            {
                badGuy.UpdatePlayerCharacterCoordinates(_PlayerCharacter.CurrentCoordinates);
            }

            //foreach(SpriteWormKing wormKing in _WormKings)
            //{
            //    //wormKing.Update(1.0f / 60.0f);
            //    wormKing.UpdatePlayerCharacterCoordinates(_PlayerCharacter.CurrentCoordinates);
            //}

            foreach(Sprite sprite in _SpritesWithUpdate)
            {
                sprite.Update(1.0f / 60.0f);
            }
        }
    }
}
