using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuizMaker.Model
{
    [XmlRoot("Data")]
    public class ListOfQuizItem
    {
        [XmlArray("QuizItems")]
        [XmlArrayItem("QuizItem")]
        public List<QuizItem> QuizItems { get; set; }

        public ListOfQuizItem()
        {
            QuizItems = new List<QuizItem>();
        }

        public ListOfQuizItem(List<QuizItem> quizItems)
        {
            QuizItems = quizItems;
        }
    }
}
