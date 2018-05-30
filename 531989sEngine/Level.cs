using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Xml;

namespace BasicEngine
{
    public class Level : ContentManager
    {
        #region Member Variables

        protected string _Name;
        protected Vector2 _PlayerCharacterDefaultCoordinates;

        protected List<Vector2> _LinkedLevels = new List<Vector2>();
        protected List<SpriteTextureSprite> _Portals = new List<SpriteTextureSprite>();

        protected List<Sprite> _AllSprites = new List<Sprite>();
        protected List<Sprite> _SpritesWithUpdate = new List<Sprite>();
        protected List<SpriteWormKing> _WormKings = new List<SpriteWormKing>();

        protected List<SpriteBlock> _Blocks = new List<SpriteBlock>();
        protected Texture2D _BlockTexture;

        #endregion Member Variables

        #region Getters
        public string Name { get { return _Name; } set { } }
        public Vector2 PlayerCharacterDefaultCoordinates { get { return _PlayerCharacterDefaultCoordinates; } set { } }

        public List<Vector2> NextLevelCoordinates { get { return _LinkedLevels; } set { } }

        public List<Sprite> AllSprites { get { return _AllSprites; } set { } }
        public List<Sprite> SpritesWithUpdate { get { return _SpritesWithUpdate; } set { } }
        public List<SpriteWormKing> WormKings { get { return _WormKings; } set { } }

        public List<SpriteBlock> Blocks { get { return _Blocks; } set { } }
        #endregion Getters


        public Level(IServiceProvider serviceProvider, string rootDirectory, XmlNode rootNode, Texture2D blockTexture) : base(serviceProvider, rootDirectory)
        {
            _Name = rootNode.SelectSingleNode("Name").FirstChild.Value;

            _PlayerCharacterDefaultCoordinates = new Vector2(
                Int32.Parse(rootNode.SelectSingleNode("PlayerDefaultCoordinates").SelectSingleNode("X").FirstChild.Value),
                Int32.Parse(rootNode.SelectSingleNode("PlayerDefaultCoordinates").SelectSingleNode("Y").FirstChild.Value));

            #region Next Level

            Trace.WriteLine("Loading LinkedLevels for " + Name + "...");
            Trace.Indent();

            //_NextLevelName = rootNode.SelectSingleNode("NextLevel").SelectSingleNode("Name").FirstChild.Value;
            foreach (XmlNode linkedlevel in rootNode.SelectSingleNode("LinkedLevels").ChildNodes)
            {
                Trace.WriteLine(linkedlevel.SelectSingleNode("Name").FirstChild.Value);

                _LinkedLevels.Add(new Vector2(
                Int32.Parse(linkedlevel.SelectSingleNode("Coordinates").SelectSingleNode("X").FirstChild.Value),
                Int32.Parse(linkedlevel.SelectSingleNode("Coordinates").SelectSingleNode("Y").FirstChild.Value)));

                _Portals.Add(new SpriteTextureSprite(Load<Texture2D>(linkedlevel.SelectSingleNode("PortalTexture").FirstChild.Value), _LinkedLevels[_LinkedLevels.Count - 1]));
            }

            Trace.Unindent();

            #endregion Next Level

            #region BadGuys



            #endregion BadGuys

            #region Bosses

            foreach(XmlNode boss in rootNode.SelectSingleNode("Bosses").ChildNodes)
            {
                switch(boss.Name)
                {
                    case "WormKing":
                        _WormKings.Add(new SpriteWormKing(
                            Load<Texture2D>(boss.SelectSingleNode("Texture").FirstChild.Value),
                            GetDefaultXmlCoordinates(boss),
                            Int32.Parse(boss.SelectSingleNode("Length").FirstChild.Value),
                            Int32.Parse(boss.SelectSingleNode("PartDelay").FirstChild.Value),
                            Color.White
                            ));
                        break;
                    default:
                        Trace.WriteLine("***" + "No loading code for: " + boss.Name + "***");
                        break;
                }
            }


            #endregion Bosses

            #region Blocks

            _BlockTexture = blockTexture;
            _Blocks = GetBlocks(rootNode);

            #endregion Blocks

            //foreach (Sprite text in _Texts)
            //{
            //    _AllSprites.Add(text);
            //}

            foreach (SpriteBlock block in _Blocks)
            {
                _AllSprites.Add(block);
            }

            foreach (SpriteWormKing wormKing in _WormKings)
            {
                _AllSprites.Add(wormKing);
                _SpritesWithUpdate.Add(wormKing);
            }
        }

        private List<SpriteBlock> GetBlocks(XmlNode rootNode)
        {
            List<SpriteBlock> result = new List<SpriteBlock>();

            foreach (XmlNode block in rootNode.SelectSingleNode("Blocks").SelectNodes("Block"))
            {
                result.Add(new SpriteBlock(
                    _BlockTexture,
                    new Vector2(
                        Int32.Parse(block.SelectSingleNode("DefaultCoordinates/X").FirstChild.Value),
                        Int32.Parse(block.SelectSingleNode("DefaultCoordinates/Y").FirstChild.Value)),
                    Int32.Parse(block.SelectSingleNode("Width").FirstChild.Value),
                    Int32.Parse(block.SelectSingleNode("Height").FirstChild.Value)));
            }

            return result;
        }
        /// <summary>
        /// Gets Coordinates from "Coordinates" node
        /// </summary>
        /// <param name="ParentNode">Parent of "Coordinates" node</param>
        /// <returns></returns>
        private Vector2 GetDefaultXmlCoordinates(XmlNode ParentNode)
        {
            return new Vector2(
                int.Parse(ParentNode.SelectSingleNode("DefaultCoordinates/X").FirstChild.Value),
                int.Parse(ParentNode.SelectSingleNode("DefaultCoordinates/Y").FirstChild.Value));
        }
        private Vector2 GetXmlCoordinates(XmlNode ParentNode)
        {
            return new Vector2(
                int.Parse(ParentNode.SelectSingleNode("Coordinates/X").FirstChild.Value),
                int.Parse(ParentNode.SelectSingleNode("Coordinates/Y").FirstChild.Value));
        }
    }
}
