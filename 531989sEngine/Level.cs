using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;

namespace BasicEngine
{
    class Level
    {
        #region Member Variables
        protected string _Name;
        protected Vector2 _PlayerCharacterDefaultCoordinates;
        protected List<Block> _Blocks = new List<Block>();
        #endregion Member Variables

        #region Getters
        public string Name { get { return _Name; } set { } }
        public Vector2 PlayerCharacterDefaultCoordinates { get { return _PlayerCharacterDefaultCoordinates; } set { } }
        public List<Block> Blocks { get { return _Blocks; } set { } }
        #endregion Getters


        public Level(XmlNode rootNode)
        {
            _Name = rootNode.SelectSingleNode("Name").FirstChild.Value;

            _PlayerCharacterDefaultCoordinates = new Vector2(
                Int32.Parse(rootNode.SelectSingleNode("PlayerDefaultCoordinates").SelectSingleNode("X").FirstChild.Value),
                Int32.Parse(rootNode.SelectSingleNode("PlayerDefaultCoordinates").SelectSingleNode("X").FirstChild.Value));

            foreach(XmlNode block in rootNode.SelectSingleNode("Blocks"))
            {
                _Blocks.Add(new Block(
                    new Vector2(
                        Int32.Parse(block.SelectSingleNode("X").FirstChild.Value),
                        Int32.Parse(block.SelectSingleNode("Y").FirstChild.Value)),
                    Int32.Parse(block.SelectSingleNode("Width").FirstChild.Value),
                    Int32.Parse(block.SelectSingleNode("Height").FirstChild.Value)));
            }
        }
    }
}
