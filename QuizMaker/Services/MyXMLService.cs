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

        public MyXMLService(string xmlPath)
        {
            _xmlPath = xmlPath;
        }

        public void CreateXML()
        {
            if (!File.Exists(_xmlPath))
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings {Indent = true};
                SaveListOfQuizItemsToFile(_xmlPath, new ListOfQuizItem());
            }
        }

        public void AddQuizItemToXml(QuizItem quizItemModel)
        {
            CreateXML();
            var list = ReadListOfQuizItemsFromFile();
            list.QuizItems.Add(quizItemModel);
            SaveListOfQuizItemsToFile(_xmlPath, list);
        }

        public ListOfQuizItem ReadListOfQuizItemsFromFile()
        {
            CreateXML();
            try
            {
                XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Data");
                XmlSerializer serializer = new XmlSerializer(typeof(ListOfQuizItem), xmlRootAttribute);

                using (FileStream fileStream = new FileStream(_xmlPath, FileMode.Open))
                {
                    return (ListOfQuizItem)serializer.Deserialize(fileStream)!;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{_xmlPath}' not found. Creating a new one.");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading XML file: {ex.Message}");
                throw;
            }
        }
        
        private void SaveListOfQuizItemsToFile(string filePath, ListOfQuizItem listOfQuizItem)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ListOfQuizItem));

                using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    serializer.Serialize(fileStream, listOfQuizItem);
                }

                Console.WriteLine($"Quiz item added and saved to {filePath} successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to XML file: {ex.Message}");
            }
        }
    }
}
