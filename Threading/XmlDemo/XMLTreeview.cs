using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XmlDemo
{
    //[Serializable]
    [XmlRoot(ElementName = "Screen")]
    public class Screen
    {
        [XmlElement(ElementName = "Item")]
        public List<Items> itemList { get; set; }
        [XmlAttribute("name")]
        public string screenName { get; set; }

        public Screen()
        {
            this.itemList = new List<Items>();
            this.screenName = "";
        }
    }

    public class Items
    {
        [XmlElement(ElementName = "Caption")]
        public List<Captions> captions { get; set; }
        [XmlAttribute("name")]
        public string itemName { get; set; }

        public Items()
        {
            this.captions = new List<Captions>();
            this.itemName = "";
        }
    }

    public class Captions
    {
        [XmlAttribute("name")]
        public string name { get; set; }
        public string font { get; set; }
        public string size { get; set; }
        public string text { get; set; }
        public Captions(string name, string font, string size, string text)
        {
            this.name = name;
            this.font = font;
            this.size = size;
            this.text = text;
        }

        public Captions()
        {
            this.name = "";
            this.font = "";
            this.size = "";
            this.text = "";
        }
    }

    public class ManageXML
    {
        /// <summary>  
        /// 绑定TreeView  
        /// </summary>  
        //public static List<Item> bindTvXml(TreeView menuTreeView, XmlDocument xml)
        //{
        //    for (int i = 0; i < xml.DocumentElement.ChildNodes.Count; i++)
        //    {
        //        try
        //        {
        //            XmlNode Xnode = xml.DocumentElement.ChildNodes[i];
        //            TreeNode node = new TreeNode();
        //            node.Text = Xnode.Name;
        //            node.Tag = Xnode;
        //            bindChildNode(node, Xnode);//绑定子节点
        //            menuTreeView.Nodes.Clear();
        //            menuTreeView.Nodes.Add(node);
        //            menuTreeView.HideSelection = false;
        //        }
        //        catch (Exception me)
        //        {
        //            MessageBox.Show(me.Message);
        //        }
        //    }
        //    return treeList;
        //} 
        /// <summary>  
        /// 递归绑定子节点  
        /// </summary>  
        /// <param name="node"></param>  
        /// <param name="xml"></param>  
        //private static void bindChildNode(TreeNode node, XmlNode xml)
        //{
        //    TreeNode childItem = new TreeNode();
        //    TreeNode childCaption = new TreeNode();
        //    Item ItemClasss = new Item();
        //    for (int i = 0; i < xml.ChildNodes.Count; i++)
        //    {
        //        try
        //        {
        //            XmlNode ChildXml = xml.ChildNodes[i];
        //            childItem.Text = ChildXml.Name; 
        //            node.Nodes.Add(childItem);
        //            if (ChildXml.Attributes["name"].Value.Contains("节目"))
        //            {
        //                ItemClasss.id = ChildXml.Attributes["name"].Value;
        //                ItemClasss.node = childItem;
        //            }
        //            Caption[] captionClass = new Caption[ChildXml.ChildNodes.Count];
        //            for (int j = 0; j < ChildXml.ChildNodes.Count; j++)
        //            {
        //                XmlNode xmlNode = ChildXml.ChildNodes[j];
        //                if (xmlNode!=null)
        //                {
        //                    if (xmlNode.Attributes["name"].Value != null)
        //                    {
        //                        childCaption.Text = xmlNode.Name;
        //                        captionClass[j].id = xmlNode.Attributes["name"].Value;
        //                        captionClass[j].value = xmlNode.InnerText;
        //                        captionClass[j].node = childCaption;
        //                        treeList.Add(ItemClasss);
        //                        childItem.Nodes.Add(childCaption);
        //                    }
        //                }
        //            }
        //            ItemClasss.caption = captionClass;
        //            //    if (ChildXml.HasChildNodes)
        //            //    {
        //            //        if (ChildXml.ChildNodes[0].NodeType == XmlNodeType.Text)
        //            //        {
        //            //            XmlNode xmlNode = ChildXml.ChildNodes[0];
        //            //            if (xmlNode.Value != "")
        //            //            {
        //            //                if (ChildXml.Attributes["name"].Value != null)
        //            //                {
        //            //                    CaptionStruct captionStruct = new CaptionStruct();
        //            //                    Childnode.Text = ChildXml.Name;
        //            //                    captionStruct.id = ChildXml.Attributes["name"].Value;
        //            //                    captionStruct.value = xmlNode.Value;
        //            //                    captionStruct.node = Childnode;
        //            //                    itemStruct.caption = captionStruct;
        //            //                    treeList.Add(itemStruct);
        //            //                }
        //            //            }
        //            //            else
        //            //            {
        //            //                Childnode.Text = ChildXml.Name;
        //            //            }
        //            //        }
        //            //        else
        //            //            bindChildNode(Childnode, ChildXml);
        //            //    }
        //            //node.Nodes.Add(Childnode);
        //        }
        //        catch (Exception me)
        //        {
        //            MessageBox.Show(me.Message);
        //        }
        //    }
        //}
        public static void SaveToXml(string filePath, object sourceObj, Type type, string xmlRootName)
        {
            if (!string.IsNullOrWhiteSpace(filePath) && sourceObj != null)
            {
                type = type != null ? type : sourceObj.GetType();

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = string.IsNullOrWhiteSpace(xmlRootName) ?
                        new System.Xml.Serialization.XmlSerializer(type) :
                        new System.Xml.Serialization.XmlSerializer(type, new XmlRootAttribute(xmlRootName));
                    xmlSerializer.Serialize(writer, sourceObj);
                }
            }
        }

        public static object LoadFromXml(string filePath, Type type)
        {
            object result = null;

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Screen));
                    result = (Screen)xmlSerializer.Deserialize(reader);
                }
            }
            return result;
        }

        private static void XmlSerializeInternal(Stream stream, object o, Encoding encoding)
        {
            if (o == null)
                throw new ArgumentNullException("o");
            if (encoding == null)
                throw new ArgumentNullException("encoding");

            XmlSerializer serializer = new XmlSerializer(o.GetType());

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineChars = "\r\n";
            settings.Encoding = encoding;
            settings.IndentChars = "    ";

            using (XmlWriter writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, o);
                writer.Close();
            }
        }

        /// <summary>
        /// 将一个对象序列化为XML字符串
        /// </summary>
        /// <param name="o">要序列化的对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>序列化产生的XML字符串</returns>
        public static string XmlSerialize(object o, Encoding encoding)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializeInternal(stream, o, encoding);

                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// 将一个对象按XML序列化的方式写入到一个文件
        /// </summary>
        /// <param name="o">要序列化的对象</param>
        /// <param name="path">保存文件路径</param>
        /// <param name="encoding">编码方式</param>
        public static void XmlSerializeToFile(object o, string path, Encoding encoding)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                XmlSerializeInternal(file, o, encoding);
            }
        }

        /// <summary>
        /// 从XML字符串中反序列化对象
        /// </summary>
        /// <typeparam name="T">结果对象类型</typeparam>
        /// <param name="s">包含对象的XML字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>反序列化得到的对象</returns>
        public static T XmlDeserialize<T>(string s, Encoding encoding)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("s");
            if (encoding == null)
                throw new ArgumentNullException("encoding");

            XmlSerializer mySerializer = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(encoding.GetBytes(s)))
            {
                using (StreamReader sr = new StreamReader(ms, encoding))
                {
                    return (T)mySerializer.Deserialize(sr);
                }
            }
        }

        /// <summary>
        /// 读入一个文件，并按XML的方式反序列化对象。
        /// </summary>
        /// <typeparam name="T">结果对象类型</typeparam>
        /// <param name="path">文件路径</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>反序列化得到的对象</returns>
        public static T XmlDeserializeFromFile<T>(string path, Encoding encoding)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");
            if (encoding == null)
                throw new ArgumentNullException("encoding");

            string xml = File.ReadAllText(path, encoding);
            return XmlDeserialize<T>(xml, encoding);
        }
    }
}

