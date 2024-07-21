using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    internal static class Utils
    {
        public static string ReadFromUser(string msg)
        {
            string? input = null;
            do
            {
                Console.WriteLine(msg);
                input = Console.ReadLine();
            } while (input == null);
            return input;
        }
    }
}
