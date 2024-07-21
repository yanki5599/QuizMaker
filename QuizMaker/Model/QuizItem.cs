using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuizMaker.Model
{
    public class QuizItem
    {
        [XmlElement]
        public string Question {  get; set; }
        [XmlElement]
        public string Answer { get; set; }

        public QuizItem(string q, string ans)
        {
            Question = q;
            Answer = ans;
        }

        public QuizItem() { }
        
    }
}
