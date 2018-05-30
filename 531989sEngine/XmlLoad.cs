#region Useing

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

#endregion Useing

namespace BasicEngine
{
    public class XmlLoad : ContentManager
    {
        #region MemberVariables

        private IServiceProvider _ServiceProvider;
        private string _RootDirectory;

        protected Dictionary<int, Level> _Levels = new Dictionary<int, Level>();
        protected int _FirstLevel = 1;

        protected Dictionary<string, SpriteFont> _Fonts = new Dictionary<string, SpriteFont>();

        protected List<Texture2D> _PlayerCharacterUpTextures = new List<Texture2D>();
        protected List<Texture2D> _PlayerCharacterDownTextures = new List<Texture2D>();
        protected List<Texture2D> _PlayerCharacterLeftTextures = new List<Texture2D>();
        protected List<Texture2D> _PlayerCharacterRightTextures = new List<Texture2D>();

        protected List<Texture2D> _BadGuyOneUpTextures = new List<Texture2D>();
        protected List<Texture2D> _BadGuyOneDownTextures = new List<Texture2D>();
        protected List<Texture2D> _BadGuyOneLeftTextures = new List<Texture2D>();
        protected List<Texture2D> _BadGuyOneRightTextures = new List<Texture2D>();

        protected List<SpriteText> _SplashScreenText = new List<SpriteText>();
        protected List<SpriteText> _StartScreenText = new List<SpriteText>();

        protected Texture2D _BlockTexture;

        #endregion MemberVariables

        #region Getters

        public Dictionary<int, Level> Levels { get { return _Levels; } set { } }
        public int FirstLevel { get { return _FirstLevel; } set { } }

        public Dictionary<string, SpriteFont> Fonts { get { return _Fonts; } set { } }

        public List<Texture2D> PlayerCharacterUpTextures { get { return _PlayerCharacterUpTextures; } set { } }
        public List<Texture2D> PlayerCharacterDownTextures { get { return _PlayerCharacterDownTextures; } set { } }
        public List<Texture2D> PlayerCharacterLeftTextures { get { return _PlayerCharacterLeftTextures; } set { } }
        public List<Texture2D> PlayerCharacterRightTextures { get { return _PlayerCharacterRightTextures; } set { } }

        public List<Texture2D> BadGuyOneUpTextures { get { return _PlayerCharacterUpTextures; } set { } }
        public List<Texture2D> BadGuyOneDownTextures { get { return _PlayerCharacterDownTextures; } set { } }
        public List<Texture2D> BadGuyOneLeftTextures { get { return _PlayerCharacterLeftTextures; } set { } }
        public List<Texture2D> BadGuyOneRightTextures { get { return _PlayerCharacterRightTextures; } set { } }

        public List<SpriteText> SplashScreenText { get { return _SplashScreenText; } set { } }
        public List<SpriteText> StartScreenText { get { return _StartScreenText; } set { } }

        public Texture2D BlockTexture { get { return _BlockTexture; } set { } }

        #endregion Getters

        /// <summary>
        /// Handles All xml loading starting with the base file
        /// also has getters for all the information loaded.
        /// </summary>
        /// <param name="serviceProvider">Pass in Content.ServiceProvider from Game1</param>
        /// <param name="rootDirectory">Pass in Content.RootDirectory from Game1</param>
        public XmlLoad(IServiceProvider serviceProvider, string rootDirectory) : base(serviceProvider, rootDirectory)
        {
            _ServiceProvider = serviceProvider;
            _RootDirectory = rootDirectory;

            _Levels = new Dictionary<int, Level>();

            Trace.Indent();
            Trace.WriteLine("Loading Textures from: " + "BlankGame" + ".xml");
            LoadBaseFile("BlankGame");
            Trace.Unindent();
        }

        /// <summary>
        /// Loads the base game file from Xml
        /// </summary>
        /// <param name="baseGameFile">Name of the base game file(No extensions)</param>
        private void LoadBaseFile(string baseGameFile)
        {
            //var Dank = new ChangMyMind.meme("This is human readable");

            XmlNode RootNode = GetRootNode(baseGameFile);

            //foreach font in BlankGame.xml/Game/Fonts.SelectNodes(Font)
            foreach (XmlNode font in RootNode.SelectSingleNode("Fonts").SelectNodes("Font"))
            {
                _Fonts.Add(font.FirstChild.Value, Load<SpriteFont>(font.FirstChild.Value));
            }

            //foreach state in BlankGame.xml/Game/States.ChildNodes
            foreach (XmlNode state in RootNode.SelectSingleNode("States").ChildNodes)
            {
                switch(state.Name)
                {
                    //BlankGame.xml/Game/States/SplashScreen
                    case "SplashScreen":
                        _SplashScreenText = GetTextObjsFromXml(state);
                        break;
                    //BlankGame.xml/Game/States/SplashScreen
                    case "StartScreen":
                        _StartScreenText = GetTextObjsFromXml(state);
                        break;
                    //BlankGame.xml/Game/States/???
                    default:
                        Trace.WriteLine("***" + "No texture loading code for: " + state.Name + "***");
                        break;
                }
            }

            //foreach spriteType in BlankGame.xml/Game/Textures.ChildNodes
            foreach (XmlNode spriteType in RootNode.SelectSingleNode("Textures").ChildNodes)
            {
                switch (spriteType.Name)
                {
                    //BlankGame.xml/Game/Textures/PlayerCharacter
                    case "PlayerCharacter":
                        foreach(XmlNode textureGroup in spriteType.ChildNodes)
                        {
                            //foreach textureGroup in BlankGame.xml/Game/Textures/PlayerCharacter.ChildNodes
                            switch (textureGroup.Name)
                            {
                                //BlankGame.xml/Game/Textures/PlayerCharacter/Up
                                case "Up":
                                    _PlayerCharacterUpTextures = GetTexture2Ds(textureGroup);
                                    break;
                                //BlankGame.xml/Game/Textures/PlayerCharacter/Down
                                case "Down":
                                    _PlayerCharacterDownTextures = GetTexture2Ds(textureGroup);
                                    break;
                                //BlankGame.xml/Game/Textures/PlayerCharacter/Left
                                case "Left":
                                    _PlayerCharacterLeftTextures = GetTexture2Ds(textureGroup);
                                    break;
                                //BlankGame.xml/Game/Textures/PlayerCharacter/Right
                                case "Right":
                                    _PlayerCharacterRightTextures = GetTexture2Ds(textureGroup);
                                    break;
                                //BlankGame.xml/Game/Textures/PlayerCharacter/???
                                default:
                                    Trace.WriteLine("***" + "No texture loading code for: " + spriteType.Name + "/" +  textureGroup.Name + "***");
                                    break;
                            }
                        }
                        break;
                    //BlankGame.xml/Game/Textures/BadGuyOne
                    case "BadGuyOne":
                        //foreach textureGroup in BlankGame.xml/Game/Textures/BadGuyOne.ChildNodes
                        foreach (XmlNode textureGroup in spriteType.ChildNodes)
                        {
                            //there will be tones of diffrent bad guy types all with diffrent loading reqirments so to keep it simple the loading code will not be refactored.
                            switch (textureGroup.Name)
                            {
                                //BlankGame.xml/Game/Textures/BadGuyOne/Up
                                case "Up":
                                    _BadGuyOneUpTextures = GetTexture2Ds(textureGroup);
                                    break;
                                //BlankGame.xml/Game/Textures/BadGuyOne/Down
                                case "Down":
                                    _BadGuyOneDownTextures = GetTexture2Ds(textureGroup);
                                    break;
                                //BlankGame.xml/Game/Textures/BadGuyOne/Left
                                case "Left":
                                    _BadGuyOneLeftTextures = GetTexture2Ds(textureGroup);
                                    break;
                                //BlankGame.xml/Game/Textures/BadGuyOne/Right
                                case "Right":
                                    _BadGuyOneRightTextures = GetTexture2Ds(textureGroup);
                                    break;
                                //BlankGame.xml/Game/Textures/BadGuyOne/???
                                default:
                                    Trace.WriteLine("***" + "No texture loading code for: " + spriteType.Name + "/" + textureGroup.Name + "***");
                                    break;
                            }
                        }
                        break;
                    //BlankGame.xml/Game/Textures/Block
                    case "Block":
                        _BlockTexture = Load<Texture2D>(spriteType.FirstChild.FirstChild.Value);
                        break;
                    //BlankGame.xml/Game/Textures/???
                    default:
                        Trace.WriteLine("***" + "No texture loading code for: " + spriteType.Name + "***");
                        break;
                }

            }

            foreach (XmlNode level in RootNode.SelectSingleNode("Levels"))
            {
                _Levels.Add(
                    int.Parse(level.SelectSingleNode("Name").FirstChild.Value),
                    new Level(_ServiceProvider, _RootDirectory,
                    GetRootNode(level.SelectSingleNode("Name").FirstChild.Value),
                    _BlockTexture));
            }
        }

        private List<Texture2D> GetTexture2Ds(XmlNode textureGroup)
        {
            List<Texture2D> result = new List<Texture2D>();
            foreach (XmlNode texture in textureGroup.ChildNodes)
            {
                result.Add(Load<Texture2D>(texture.FirstChild.Value));
            }
            return result;
        }

        private XmlNode GetRootNode(string name)
        {
            XmlDocument document = new XmlDocument();
            document.Load(System.IO.Path.Combine("Xml", name + ".xml"));
            return document.FirstChild.NextSibling;
        }

        /// <summary>
        /// Gets a list of all text objects stored in xml
        /// </summary>
        /// <param name="ParentNode">The parent to all the TextObj nodes</param>
        /// <returns></returns>
        private List<SpriteText> GetTextObjsFromXml(XmlNode ParentNode)
        {
            List<SpriteText> result = new List<SpriteText>();

            foreach (XmlNode textObj in ParentNode.ChildNodes)
            {
                result.Add(new SpriteText(
                    textObj.SelectSingleNode("Text").FirstChild.Value,
                    _Fonts[textObj.SelectSingleNode("Font").FirstChild.Value],
                    textObj.SelectSingleNode("XAdjust").FirstChild.Value,
                    textObj.SelectSingleNode("YAdjust").FirstChild.Value,
                    GetXmlCoordinates(textObj)));
            }
            return result;
        }

        /// <summary>
        /// Gets Coordinates from "Coordinates" node
        /// </summary>
        /// <param name="ParentNode">Parent of "Coordinates" node</param>
        /// <returns></returns>
        private Vector2 GetXmlCoordinates(XmlNode ParentNode)
        {
            return new Vector2(int.Parse(ParentNode.SelectSingleNode("Coordinates/X").FirstChild.Value), int.Parse(ParentNode.SelectSingleNode("Coordinates/Y").FirstChild.Value));
        }
    }
}
