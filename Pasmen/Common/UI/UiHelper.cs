using Pasmen.Common;
using System;

namespace Pasmen
{
    internal static class UiHelper
    {
        #region write
        public static void ProposeInitialActions()
        {
            Console.WriteLine();
            PrintMenuActions();
            Console.WriteLine();
            Console.WriteLine("Select password index or enter menu action: ");
        }

        public static void PrintMenuActions()
        {
            foreach (PasmenMenuActionType enumType in Enum.GetValues(typeof(PasmenMenuActionType)))
            {
                Console.WriteLine($"[{MenuActionsHelper.GetActionKeyByType(enumType)}] {enumType}");
            }
        }

        public static void PrintEntryActions()
        {
            foreach (PasmenEntryActionType enumType in Enum.GetValues(typeof(PasmenEntryActionType)))
            {
                Console.WriteLine($"[{(int)enumType} {enumType}]");
            }
        }

        public static void WriteError(string msg, bool pressAnyKeyToContinue = false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Error: " + msg);
            Console.ForegroundColor = ConsoleColor.White;

            if (pressAnyKeyToContinue)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        public static void WriteSucccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void AlertOperationResult(string msg)
        {
            Console.Clear();
            WriteSucccess(msg);
            Console.ReadKey();
        }
        #endregion write

        #region read
        public static PasmenEntryActionType ResolveEntryActionType(int input)
        {
            var action = Enum.TryParse(input.ToString(), out PasmenEntryActionType result);
            return action ? result : throw new ArgumentException();
        }

        public static PasmenMenuActionType ResolveMenuActionType(string input)
        {
            return MenuActionsHelper.GetActionTypeByKey(input);
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
        #endregion
    }
}