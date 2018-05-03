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
    class Level : ContentManager
    {
        #region Member Variables
        protected string _Name;
        protected Vector2 _PlayerCharacterDefaultCoordinates;

        protected Vector2 _NextLevelCoordinates;
        protected string _NextLevelName;

        protected List<Block> _Blocks = new List<Block>();
        #endregion Member Variables

        #region Getters
        public string Name { get { return _Name; } set { } }
        public Vector2 PlayerCharacterDefaultCoordinates { get { return _PlayerCharacterDefaultCoordinates; } set { } }

        public Vector2 NextLevelCoordinates { get { return _NextLevelCoordinates; } set { } }
        public string NextLevelName { get { return _NextLevelName; } set { } }

        public List<Block> Blocks { get { return _Blocks; } set { } }
        #endregion Getters


        public Level(IServiceProvider serviceProvider, string rootDirectory, XmlNode rootNode) : base(serviceProvider, rootDirectory)
        {
            _Name = rootNode.SelectSingleNode("Name").FirstChild.Value;

            _PlayerCharacterDefaultCoordinates = new Vector2(
                Int32.Parse(rootNode.SelectSingleNode("PlayerDefaultCoordinates").SelectSingleNode("X").FirstChild.Value),
                Int32.Parse(rootNode.SelectSingleNode("PlayerDefaultCoordinates").SelectSingleNode("Y").FirstChild.Value));

            #region Next Level
            _NextLevelName = rootNode.SelectSingleNode("NextLevel").SelectSingleNode("Name").FirstChild.Value;
            _NextLevelCoordinates = new Vector2(
                Int32.Parse(rootNode.SelectSingleNode("NextLevel").SelectSingleNode("Coordinates").SelectSingleNode("X").FirstChild.Value),
                Int32.Parse(rootNode.SelectSingleNode("NextLevel").SelectSingleNode("Coordinates").SelectSingleNode("Y").FirstChild.Value));
            #endregion Next Level

            #region Blocks
            foreach (XmlNode block in rootNode.SelectSingleNode("Blocks").SelectNodes("Blocks"))
            {
                /*
                _Blocks.Add(new Block(
                    //TBC
                    new Vector2(
                        Int32.Parse(block.SelectSingleNode("X").FirstChild.Value),
                        Int32.Parse(block.SelectSingleNode("Y").FirstChild.Value)),
                    Int32.Parse(block.SelectSingleNode("Width").FirstChild.Value),
                    Int32.Parse(block.SelectSingleNode("Height").FirstChild.Value)));
                    */
            }

            
            #endregion Blocks
        }
    }
}
