using QuizMaker.Services;

namespace QuizMaker
{
    internal class QuizWriter
    {

        private MyXMLService _xMLService;

        public QuizWriter(MyXMLService xMLService)
        {
            this._xMLService = xMLService;
        }

        internal void RunMenu()
        {
            while (true)
            {
                Console.WriteLine("=======================");
                string q = ReadFromUser("Write a question: ");
                //maybe check if question already exist.
                string ans = ReadFromUser("Write the answer: ");

                SaveToXml(q, ans);
            }
        }

        public static string ReadFromUser(string msg)
        {
            string? input = null;
            do
            {
                Console.WriteLine(msg);
                input = Console.ReadLine();
            }while(input == null);
            return input;
        }

        private void SaveToXml(string q, string ans)
        {
            _xMLService.AddQuizItemToXml(new Model.QuizItem(q, ans));
        }
    }
}