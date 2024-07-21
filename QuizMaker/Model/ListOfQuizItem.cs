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
        [XmlArrayAttribute("Data")]
        public QuizItem[] QuizItems { get; set; }

        
    }
}
