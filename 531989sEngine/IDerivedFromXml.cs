using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;
using System.Diagnostics;

namespace BasicEngine
{
    public interface IDerivedFromXml
    {
        XmlNode ToXml(XmlDocument document, XmlNode parentNode);
    }
}
