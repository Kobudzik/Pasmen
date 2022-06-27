using Pasmen.Common;
using System;

namespace Pasmen
{
    internal static class UiHelper
    {
        public static PasmenActionType AskAction()
        {
            foreach (PasmenActionType enumType in Enum.GetValues(typeof(PasmenActionType)))
            {
                Console.WriteLine($"[{(int)enumType} {enumType}]");
            }

            var input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            var action = Enum.TryParse(input.ToString(), out PasmenActionType result);
            return action ? result : AskAction();
        }

        public static string PromptDatabaseName()
        {
            Console.WriteLine("Enter Pasmen DB name");
            return Console.ReadLine();
        }

        public static string PromptDatabasePassword()
        {
            Console.WriteLine("Enter Pasmen DB password");
            return Console.ReadLine();
        }

        public static void WriteError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteSucccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static int ReadInt()
        {
            var input = Console.ReadKey();
            Console.WriteLine();
            var parsingSuccedeed = int.TryParse(input.KeyChar.ToString(), out int result);

            if (!parsingSuccedeed)
            {
                WriteError("Entered value must be a number!");
                return ReadInt();
            }

            return result;
        }
    }
}