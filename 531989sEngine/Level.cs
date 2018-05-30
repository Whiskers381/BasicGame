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
        //protected string _NextLevelName;

        protected List<SpriteBlock> _Blocks = new List<SpriteBlock>();
        protected Texture2D _BlockTexture;
        #endregion Member Variables

        #region Getters
        public string Name { get { return _Name; } set { } }
        public Vector2 PlayerCharacterDefaultCoordinates { get { return _PlayerCharacterDefaultCoordinates; } set { } }

        public List<Vector2> NextLevelCoordinates { get { return _LinkedLevels; } set { } }
        //public string NextLevelName { get { return _NextLevelName; } set { } }

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

            #region Blocks

            _BlockTexture = blockTexture;
            _Blocks = GetBlocks(rootNode);
            
            #endregion Blocks
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
    }
}
