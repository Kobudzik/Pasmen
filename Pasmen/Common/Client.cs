using Pasmen.Common;
using System;
using System.Collections.Generic;

namespace Pasmen
{
    internal static class Client
    {
        private static void Main()
        {
            var passwords = PasmenService.ResolvePasswordEntries();

            for (int i = 0; i < int.MaxValue; i++)
            {
                passwords.PrintPasswordNames();

                if (passwords.Count == 0)
                {
                    Console.WriteLine("Do you want to enter your first Password? (y), (n)");
                    var input = Console.ReadLine();

                    if (input == "Y" || input == "y")
                    {
                        passwords.AddPassword();
                        continue;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

                var selectedNumber = UiHelper.ReadInt();

                try
                {
                    passwords.PrintPasswordEntry(selectedNumber - 1);
                }
                catch (ArgumentException argEx)
                {
                    UiHelper.WriteError(argEx.Message);
                    continue;
                }

                HandleAction(UiHelper.AskAction(), selectedNumber - 1, passwords);
            }
        }

        public static void HandleAction(PasmenActionType action, int index, Dictionary<string, string> passwords)
        {
            switch (action)
            {
                case PasmenActionType.Add:
                    {
                        passwords.AddPassword();
                        break;
                    }

                case PasmenActionType.Remove:
                    {
                        passwords.RemovePassword(index);
                        break;
                    }

                case PasmenActionType.Clear:
                    {
                        passwords.Clear();
                        break;
                    }

                case PasmenActionType.Edit:
                    {
                        passwords.EditPasswordValue(index);
                        break;
                    }

                case PasmenActionType.Back:
                    {
                        return;
                    }

                case PasmenActionType.SaveAll:
                    {
                        PasmenService.SavePasswordEntries(passwords);
                        return;
                    }

                case PasmenActionType.ReloadFile:
                    {
                        PasmenService.ResolvePasswordEntries();
                        return;
                    }
            }
        }
    }
}