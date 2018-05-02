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
    class LoadXml
    {
        protected List<Level> _Levels = new List<Level>();

        public LoadXml()
        {
            
            
        }
        private void LoadBaseFile()
        {
            XmlNode RootNode = GetRootNode("BlankGame.xml");

            foreach (XmlNode level in RootNode.SelectSingleNode("Levels"))
            {
                _Levels.Add(new Level(GetRootNode(XmlTool.StringValueFromParent(level, "Name") + ".xml")));
            }
        }
        private XmlNode GetRootNode(string name)
        {
            XmlDocument document = new XmlDocument();
            document.Load("name");
            return document.FirstChild.NextSibling;
        }
    }
}
