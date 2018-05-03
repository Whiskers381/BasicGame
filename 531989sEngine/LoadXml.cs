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

namespace BasicEngine
{
    class LoadXml : ContentManager
    {
        protected Dictionary<int, Level> _Levels = new Dictionary<int, Level>();
        private IServiceProvider _ServiceProvider;
        private string _RootDirectory;


        public LoadXml(IServiceProvider serviceProvider, string rootDirectory, out Dictionary<int, Level> Levels ) : base(serviceProvider, rootDirectory)
        {
            _ServiceProvider = serviceProvider;
            _RootDirectory = rootDirectory;

            Levels = new Dictionary<int, Level>();

            LoadBaseFile();

            Levels = _Levels;
        }

        private void LoadBaseFile()
        {
            XmlNode RootNode = GetRootNode("BlankGame");

            foreach (XmlNode level in RootNode.SelectSingleNode("Levels"))
            {
                _Levels.Add(int.Parse(level.SelectSingleNode("Name").FirstChild.Value), new Level(_ServiceProvider, _RootDirectory, GetRootNode(level.SelectSingleNode("Name").FirstChild.Value)));
            }
        }
        private XmlNode GetRootNode(string name)
        {
            XmlDocument document = new XmlDocument();
            document.Load(System.IO.Path.Combine("Xml", name + ".xml"));
            return document.FirstChild.NextSibling;
        }
    }
}
