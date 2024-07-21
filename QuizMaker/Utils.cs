using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    internal static class Utils
    {
        public static string ReadFromUser(string msg, bool allowNull = false, bool allowEmpty = false)
        {
            string? input = null;
            do
            {
                Console.WriteLine(msg);
                input = Console.ReadLine();

                // Check conditions based on allowNull and allowEmpty flags
                if (!allowNull && string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be null or empty.");
                }
                else if (!allowEmpty && string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty.");
                }

            } while ((!allowNull && string.IsNullOrWhiteSpace(input)) || (!allowEmpty && string.IsNullOrEmpty(input)));

            return input!;
        }
    }
}
