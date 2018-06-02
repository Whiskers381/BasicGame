
#region Using

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
using System.IO;
using System.Xml;

#endregion Using

namespace BasicEngine
{
    public class Level : ContentManager
    {
        #region Member Variables

        protected string _Name;
        protected Vector2 _PlayerCharacterDefaultCoordinates;

        protected List<Vector2> _LinkedLevels = new List<Vector2>();
        protected List<SpritePortal> _Portals = new List<SpritePortal>();

        protected List<Sprite> _AllSprites = new List<Sprite>();
        protected List<Sprite> _SpritesWithUpdate = new List<Sprite>();
        protected List<SpriteWormKing> _WormKings = new List<SpriteWormKing>();

        protected List<IBadGuy> _BadGuys = new List<IBadGuy>();
        

        protected List<SpriteBlock> _Blocks = new List<SpriteBlock>();
        protected Texture2D _BlockTexture;

        #endregion Member Variables

        #region Getters
        public string Name { get { return _Name; } }
        public Vector2 PlayerCharacterDefaultCoordinates { get { return _PlayerCharacterDefaultCoordinates; } }

        public List<Vector2> NextLevelCoordinates { get { return _LinkedLevels; } }
        public List<SpritePortal> Portals { get { return _Portals; }}

        public List<Sprite> AllSprites { get { return _AllSprites; } }
        public List<Sprite> SpritesWithUpdate { get { return _SpritesWithUpdate; } }
        public List<SpriteWormKing> WormKings { get { return _WormKings; } }
        public List<IBadGuy> BadGuys { get { return _BadGuys; } }

        public List<SpriteBlock> Blocks { get { return _Blocks; } }
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

                SpritePortal portal = new SpritePortal(
                    Load<Texture2D>(linkedlevel.SelectSingleNode("PortalTexture").FirstChild.Value),
                    _LinkedLevels[_LinkedLevels.Count - 1],
                    Int32.Parse(linkedlevel.SelectSingleNode("Name").FirstChild.Value));

                _Portals.Add(portal);
                _AllSprites.Add(portal);
            }

            Trace.Unindent();

            #endregion Next Level

            #region BadGuys



            #endregion BadGuys

            #region Bosses

            foreach(XmlNode boss in rootNode.SelectSingleNode("Bosses").ChildNodes)
            {
                SpriteWormKing wormKing = new SpriteWormKing();
                switch(boss.Name)
                {
                    case "WormKing":
                        wormKing = new SpriteWormKing(
                            Load<Texture2D>(boss.SelectSingleNode("Texture").FirstChild.Value),
                            GetDefaultXmlCoordinates(boss),
                            Int32.Parse(boss.SelectSingleNode("Length").FirstChild.Value),
                            Int32.Parse(boss.SelectSingleNode("PartDelay").FirstChild.Value),
                            Color.White,
                            boss.SelectSingleNode("Texture").FirstChild.Value
                            );
                        break;
                    default:
                        Trace.WriteLine("***" + "No loading code for: " + boss.Name + "***");
                        break;
                }
                _BadGuys.Add(wormKing);
                _WormKings.Add(wormKing);
                _AllSprites.Add(wormKing);
                _SpritesWithUpdate.Add(wormKing);
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

        public XmlDocument ToXml()
        {
            string outPutPath = Path.Combine("XML", "SavedLevels");
            string outputName = Name + ".xml";

            XmlDocument document = new XmlDocument();

            document.InsertBefore(document.CreateXmlDeclaration("1.0", "utf-8", null), document.DocumentElement);

            document.AppendChild(document.CreateElement(string.Empty, "Level", string.Empty));//RootNode
            XmlNode rootNode = document.FirstChild.NextSibling;

            XmlTool.CreateTextNode(document, rootNode, "Name", Name);

            XmlTool.CreateEmptyNode(document, rootNode, "PlayerDefaultCoordinates");
            XmlTool.CreateTextNode(
                document,
                rootNode.SelectSingleNode("PlayerDefaultCoordinates"),
                "X", _PlayerCharacterDefaultCoordinates.X.ToString());
            XmlTool.CreateTextNode(
                document,
                rootNode.SelectSingleNode("PlayerDefaultCoordinates"),
                "Y", _PlayerCharacterDefaultCoordinates.Y.ToString());

            XmlElement linkedLevelNode = XmlTool.CreateEmptyNode(document, rootNode, "LinkedLevels");
            foreach(SpritePortal portal in _Portals)
            {
                 linkedLevelNode.AppendChild(portal.ToXml(document, rootNode.SelectSingleNode("LinkedLevels")));
            }

            XmlTool.CreateEmptyNode(document, rootNode, "BadGuys");

            XmlTool.CreateEmptyNode(document, rootNode, "Bosses");

            foreach(SpriteWormKing wormKing in _WormKings)
            {
                wormKing.ToXml(document, rootNode.SelectSingleNode("Bosses"));
            }

            return document;
        }
    }
}
