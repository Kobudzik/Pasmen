using Pasmen.Common;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Pasmen
{
    internal static class Client
    {
        private static void Main()
        {
            var passwords = PasmenService.ResolvePasswordEntries();

            for (int i = 0; i < int.MaxValue; i++)
            {
                passwords.PrintAddedPasswordNames();
                UiHelper.ProposeInitialActions();

                var input = Console.ReadKey().KeyChar.ToString();

                try
                {
                    if (int.TryParse(input, NumberStyles.Integer, CultureInfo.CurrentCulture, out var pickedIndex))
                    {
                        passwords.PrintPasswordEntry(pickedIndex - 1);
                        UiHelper.PrintEntryActions();

                        var pickedEntryAction = UiHelper.ReadInt();
                        HandleEntryAction(UiHelper.ResolveEntryActionType(pickedEntryAction), pickedIndex - 1, ref passwords);
                    }
                    else
                    {
                        var actionType = UiHelper.ResolveMenuActionType(input);
                        HandleMenuAction(actionType, ref passwords);
                    }
                }
                catch (Exception ex)
                {
                    UiHelper.WriteError(ex.Message, true);
                }
            }
        }

        public static void HandleEntryAction(PasmenEntryActionType action, int index, ref Dictionary<string, string> passwords)
        {
            switch (action)
            {
                case PasmenEntryActionType.Remove:
                    {
                        passwords.RemovePassword(index);
                        break;
                    }

                case PasmenEntryActionType.Edit:
                    {
                        passwords.EditPasswordValue(index);
                        break;
                    }

                case PasmenEntryActionType.Back:
                    {
                        return;
                    }
                default:
                    throw new NotImplementedException();
            }
        }

        public static void HandleMenuAction(PasmenMenuActionType action, ref Dictionary<string, string> passwords)
        {
            switch (action)
            {
                case PasmenMenuActionType.Add:
                    {
                        passwords.AddPassword();
                        break;
                    }

                case PasmenMenuActionType.Clear:
                    {
                        passwords.Clear();
                        break;
                    }

                case PasmenMenuActionType.Save:
                    {
                        PasmenService.SavePasswordEntries(passwords);
                        UiHelper.AlertOperationResult("File saved succesfully. Press any key to continue.");
                        break;
                    }

                case PasmenMenuActionType.ReloadFile:
                    {
                        passwords = PasmenService.ResolvePasswordEntries();
                        UiHelper.AlertOperationResult("Reloaded succesfully. Press any key to continue.");
                        break;
                    }
                case PasmenMenuActionType.Exit:
                    {
                        Environment.Exit(0);
                        break;
                    }

                default:
                    throw new NotImplementedException();
            }
        }
    }
}