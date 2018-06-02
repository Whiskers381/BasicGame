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
    public class SpritePortal : SpriteTextureSprite, IDerivedFromXml
    {
        protected int _LinkedLevelName;

        public int LinkedLevelName { get { return _LinkedLevelName; } set { } }

        //This looks redundant but all sprites must have their own class so that later on extra behavour and texture garbage can be added
        public SpritePortal(Texture2D texture, Vector2 defaultCoordinates, int linkedLevelName) : base(texture, defaultCoordinates)
        {
            _LinkedLevelName = linkedLevelName;
        }

        public override XmlNode ToXml(XmlDocument document, XmlNode ParentNode)
        {
            XmlElement node = XmlTool.CreateEmptyNode(document, ParentNode, "Level");
            XmlTool.CreateTextNode(document, node, "Name", _LinkedLevelName.ToString());

            XmlTool.CreateEmptyNode(document, node, "Coordinates");
            XmlTool.CreateTextNode(
                document,
                node.SelectSingleNode("Coordinates"),
                "X", _DefaultX.ToString());
            XmlTool.CreateTextNode(
                document,
                node.SelectSingleNode("Coordinates"),
                "Y", _DefaultY.ToString());

            return ParentNode.AppendChild(node);
        }
    }
}
