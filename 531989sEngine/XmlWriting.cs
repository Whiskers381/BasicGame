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
        //XmlDocument _Document;
        //XmlNode _RootNode;



        public XmlWriting()
        {
            //_Document = new XmlDocument();
            //_Document.InsertBefore(_Document.CreateXmlDeclaration("1.0", "utf-8", null), _Document.DocumentElement);

            //_Document.AppendChild(_Document.CreateElement(string.Empty, "Level", string.Empty));//RootNode
            //_RootNode = _Document.FirstChild.NextSibling;
            //_RootNode.AppendChild(_Document.CreateElement(string.Empty, "FaultTrees", string.Empty));///////////////////////////////////

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



            //XmlElement Node = document.CreateElement(string.Empty, EventType, string.Empty);

            //Node.SetAttributeNode(document.CreateAttribute("ID"));
            //Node.SetAttribute("ID", Id.ToString());

            //Node.AppendChild(document.CreateElement(string.Empty, "Name", string.Empty));
            //Node.SelectSingleNode("Name").AppendChild(document.CreateTextNode(Name));

            //Node.AppendChild(document.CreateElement(string.Empty, "Children", string.Empty));
            //foreach (LogicalNode Child in Children)
            //{
            //    Node.SelectSingleNode("Children").AppendChild(Child.ToXml(document, Node.SelectSingleNode("Children")));
            //}

            //return ParentNode.AppendChild(Node);

            
        }

        //SavePlayersGame("0001", new Vector2(0,0), "CyberPunkGuy");
        public void SavePlayersGame(string CurrentLevelName, Vector2 CurrentPlayerCoordinates, string PlayersName)
        {
            string outPutPath = Path.Combine("XML", "SaveGames");
            string outputName = "SaveGame" + 0002 + ".xml";

            XmlDocument document = new XmlDocument();
            document.InsertBefore(document.CreateXmlDeclaration("1.0", "utf-8", null), document.DocumentElement);

            document.AppendChild(document.CreateElement(string.Empty, "SavedData", string.Empty));//RootNode
            XmlNode rootNode = document.FirstChild.NextSibling;

            XmlTool.CreateEmptyNode(document, rootNode, "Level");
            XmlTool.CreateTextNode(document, rootNode.SelectSingleNode("Level"), "Name", CurrentLevelName);

            XmlTool.CreateEmptyNode(document, rootNode, "Player");
            XmlTool.CreateTextNode(document, rootNode.SelectSingleNode("Player"), "Name", PlayersName);

            XmlTool.CreateEmptyNode(document, rootNode.SelectSingleNode("Player"), "Coordinates");
            XmlTool.CreateTextNode(document, rootNode.SelectSingleNode("Player/Coordinates"), "X", CurrentPlayerCoordinates.X.ToString());
            XmlTool.CreateTextNode(document, rootNode.SelectSingleNode("Player/Coordinates"), "Y", CurrentPlayerCoordinates.X.ToString());


            if (!Directory.Exists(outPutPath))
            {
                Directory.CreateDirectory(outPutPath);
            }

            document.Save(Path.Combine(outPutPath, outputName));
        }
    }
}
