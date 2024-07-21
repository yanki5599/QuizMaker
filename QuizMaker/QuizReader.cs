using QuizMaker.Model;
using QuizMaker.Services;

namespace QuizMaker
{
    internal class QuizReader
    {
        private MyXMLService _xMLService;


        public QuizReader(MyXMLService xMLService)
        {
            this._xMLService = xMLService;
        }

        internal void RunMenu()
        {
            while (true) 
            {
                var questionsAndAnswers = GetListOfQuizItems();
                PrintListOfQuestions(questionsAndAnswers);
                string  choice = Utils.ReadFromUser("Enter a question number: ");
                RunQuestion(choice, questionsAndAnswers);
            }
        }

        private List<QuizItem> GetListOfQuizItems()
        {
            return _xMLService.ReadListOfQuizItemsFromFile().QuizItems;
        }

        private void RunQuestion(string choice, List<QuizItem> questionsAndAnswers)
        {
            if (int.TryParse(choice, out int choiceNum) && questionsAndAnswers.Count >= choiceNum)
            {
                Console.WriteLine(questionsAndAnswers[choiceNum -1].Question);

                string userAns = Utils.ReadFromUser("what is your answer?: ");

                if (userAns.Trim().Equals(questionsAndAnswers[choiceNum -1].Answer))
                    Console.WriteLine("correct! well done!! ");
                else
                    Console.WriteLine("Incorrct!! maybe next time...");
            }
            else 
            {
                Console.WriteLine("Invalid choice");
            }
        }

        private void PrintListOfQuestions(List<QuizItem> questions)
        {
            Console.WriteLine("========[ List of questions ]============");
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine($"{i+1}. " + questions[i].Question);
            }
        }
    }
}