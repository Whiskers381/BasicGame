#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

#endregion Using

namespace BasicEngine
{
    public class XmlWriting
    {
        XmlDocument _Document;
        XmlNode _RootNode;

        public XmlWriting()
        {
            _Document = new XmlDocument();
            _Document.InsertBefore(_Document.CreateXmlDeclaration("1.0", "utf-8", null), _Document.DocumentElement);

            _Document.AppendChild(_Document.CreateElement(string.Empty, "Level", string.Empty));//RootNode
            _RootNode = _Document.FirstChild.NextSibling;
            _RootNode.AppendChild(_Document.CreateElement(string.Empty, "FaultTrees", string.Empty));///////////////////////////////////

            //XmlLoading.fMEA.ToXml(_Document, _RootNode.SelectSingleNode("FaultTrees"));

            //foreach (FaultTree faultTree in FaultTrees)
            //{
            //    faultTree.ToXml(_Document, _RootNode.SelectSingleNode("FaultTrees"));
            //}

            //if (!Directory.Exists(OutPutPath))
            //{
            //    Directory.CreateDirectory(OutPutPath);
            //}

            //_Document.Save(Path.Combine(OutPutPath, OutputName));
        }

        public void NewSavePlayersGame()
        {
            XmlDocument document = new XmlDocument();
            document.InsertBefore(_Document.CreateXmlDeclaration("1.0", "utf-8", null), _Document.DocumentElement);

            document.AppendChild(document.CreateElement(string.Empty, "Level", string.Empty));//RootNode
            XmlNode rootNode = document.FirstChild.NextSibling;
        }

        public void SavePlayersGame()
        {

        }
    }
}
