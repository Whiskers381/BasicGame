using System;
using System.Linq;
using System.Xml;

namespace BasicEngine
{
    /// <summary>
    /// Contains tools for makeing the reading and writing of XML simpler
    /// </summary>
    public static class XmlTool
    {
        #region <AbstractionMethodsForDataWriting>

        public static XmlElement CreateEmptyNode(XmlDocument document, XmlElement Node, string Name)
        {
            Node.AppendChild(document.CreateElement(string.Empty, Name, string.Empty));
            return Node;
        }
        public static XmlElement CreateEmptyNode(XmlDocument document, XmlNode Node, string Name)
        {
            return CreateEmptyNode(document, (XmlElement)Node, Name);
        }

        /// <summary>
        /// Creates and adds an element and value to a given node
        /// </summary>
        public static XmlElement CreateAttribute(XmlDocument document, XmlElement Node, string Name, string Value)
        {
            Node.SetAttributeNode(document.CreateAttribute(Name));
            Node.SetAttribute(Name, Value);
            return Node;
        }
        public static XmlElement CreateAttribute(XmlDocument document, XmlNode Node, string Name, string Value)
        {
            return CreateAttribute(document, (XmlElement)Node, Name, Value);
        }

        /// <summary>
        /// Creates and adds an element and value to a given node
        /// </summary>
        public static XmlElement CreateTextNode(XmlDocument document, XmlElement Node, string Name, string Value)
        {
            Node.AppendChild(document.CreateElement(string.Empty, Name, string.Empty));
            Node.SelectSingleNode(Name).AppendChild(document.CreateTextNode(Value));
            return Node;
        }
        public static XmlElement CreateTextNode(XmlDocument document, XmlNode Node, string Name, string Value)
        {
            return CreateTextNode(document, (XmlElement)Node, Name, Value);
        }

        #endregion </AbstractionMethodsForDataWriting>

        #region <AbstractionMethodsForDataRetrieval>

        #region <All>

        #region <Attribute>

        public static int AttributeInt(XmlNode xmlNode, string attributeName)
        {
            return Int32.Parse(xmlNode.Attributes.GetNamedItem(attributeName).Value);
        }

        public static bool AttributeBool(XmlNode xmlNode, string attributeName)
        {
            return bool.Parse(xmlNode.Attributes.GetNamedItem(attributeName).Value);
        }

        #endregion </Attribute>

        #region <Value>

        public static ulong ULongValue(XmlNode xmlNode)
        {
            return ulong.Parse(xmlNode.FirstChild.Value);
        }

        #region <FromParent>

        public static string StringValueFromParent(XmlNode ParentNode, string NodeName)
        {
            try//The schema allows for the Description node to be empty so we have to accommodate for the impending "NullReferenceException" as a result here.
            {
                return ParentNode.SelectSingleNode(NodeName).FirstChild.Value;
            }
            catch (NullReferenceException)
            {
                return "";
            }
        }

        public static int IntValueFromParent(XmlNode ParentNode, string NodeName)
        {
            return int.Parse(StringValueFromParent(ParentNode, NodeName));
        }

        public static ulong ULongValueFromParent(XmlNode ParentNode, string NodeName)
        {
            return ulong.Parse(StringValueFromParent(ParentNode, NodeName));
        }

        public static float FloatValueFromParent(XmlNode ParentNode, string NodeName)
        {
            return float.Parse(StringValueFromParent(ParentNode, NodeName));
        }

        public static bool BoolValueFromParent(XmlNode ParentNode, string NodeName)
        {
            return bool.Parse(StringValueFromParent(ParentNode, NodeName));
        }

        #endregion </FromParent>

        #endregion </Value>

        #endregion </All>

        #region <LogicNode>

        public static string Type(XmlNode xmlNode)
        {
            return xmlNode.LocalName;
        }

        public static int Id(XmlNode xmlNode)
        {
            return AttributeInt(xmlNode, "ID");
        }

        #endregion </LogicNode>

        #region <SpecialCase>

        public static float FloatValueWithSfCheck(XmlNode ParentNode, string NodeName)
        {
            string StringForm = StringValueFromParent(ParentNode, NodeName);
            try
            {
                return float.Parse(StringForm);
            }
            catch (FormatException)
            {
                //a*10^n
                //Exsample of sf form the xml doc: "1.73618e-011"
                //We can split it up into [1.73618][e-][011] -----> a = 1.73618, e- = 10^, n = 011
                string a = "";
                string n = "";
                string ThisCharacter;//To save on repeatedly calling: "StringForm[i].ToString()"
                bool aSide = true;//Find out if we should be storing the value in "a" or "n"
                for (int i = 0; i < StringForm.Count(); i++)//for each Character in StringForm
                {
                    ThisCharacter = StringForm[i].ToString();
                    if (ThisCharacter == "-")
                    {
                        aSide = false;
                    }
                    else if (aSide && ThisCharacter != "e")
                    {
                        a += ThisCharacter;
                    }
                    else if (!aSide)
                    {
                        n += ThisCharacter;
                    }
                }
                return float.Parse((float.Parse(a) * (10 ^ Int32.Parse(n))).ToString());
            }
        }

        #endregion </SpecialCase>

        #endregion </AbstractionMethodsForDataRetrieval>
    }
}