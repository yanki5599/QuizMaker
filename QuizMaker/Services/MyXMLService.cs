using QuizMaker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace QuizMaker.Services
{
    internal class MyXMLService
    {
        public readonly string _xmlPath;
        private XmlDocument activeDoc;

        public MyXMLService(string xmlPath)
        {
            _xmlPath = xmlPath;
            activeDoc = ReadXML();
        }

        public void CreateXML()
        {
            if (!File.Exists(_xmlPath))
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
                {
                    Indent = true
                };

                using (XmlWriter xmlWriter = XmlWriter.Create(_xmlPath, xmlWriterSettings))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Data");
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                }
            }
        }

        public void AddQuizItemToXml(QuizItem quizItemModel)
        {
            CreateXML();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(QuizItem));

            using (StringWriter stringWriter = new StringWriter())
            {
                // Serialize the model into the StringWriter
                xmlSerializer.Serialize(stringWriter, quizItemModel);

                // Load the serialized model string into an XmlDocument
                XmlDocument serializedDoc = new XmlDocument();
                serializedDoc.LoadXml(stringWriter.ToString());

                // Import the serialized document's root element into the target document
                XmlNode importedNode = activeDoc.ImportNode(serializedDoc.DocumentElement, true);

                // Append the imported node directly to the document's root element or another specific node
                activeDoc.DocumentElement.AppendChild(importedNode);

                // Save the active document
                activeDoc.Save(_xmlPath);
            }
        }

        public List<QuizItem> GetQuizItems()
        {
            CreateXML(); // if doesntl exist
            ListOfQuizItem list;
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Data");
            XmlSerializer serializer = new XmlSerializer(typeof(ListOfQuizItem), xmlRootAttribute);

            FileStream fs = new FileStream(_xmlPath, FileMode.Open);

            QuizItem quizItem;

            list = (ListOfQuizItem) serializer.Deserialize(fs);

            return list.QuizItems.ToList();
        }
        public XmlDocument? ReadXML()
        {
            CreateXML();
            XmlDocument xmlDoc = new XmlDocument();

            using (FileStream fileStream = new FileStream(_xmlPath, FileMode.Open, FileAccess.Read))
            {
                xmlDoc.Load(fileStream);
            }
            return xmlDoc;
        }

    }
}
