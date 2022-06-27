using Pasmen.Common;
using Pasmen.Data.AbstractFactory;
using Pasmen.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

namespace Pasmen
{
    internal static class Client
    {

        private static void Main()
        {
            var pasmenFactory = PasmenAbstractFactory.Instance;
            var configuration = PasmenConfiguration.Instance;
            var passwords = new Dictionary<string, string>();

            passwords = ResolvePasswordEntries();

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
                passwords.PrintPasswordEntry(selectedNumber - 1);
                var action = UiHelper.AskAction();
                HandleAction(action, selectedNumber - 1, passwords);
            }
        }

        private static Dictionary<string, string> ResolvePasswordEntries()
        {
            var stringifiedData = TryGetDatabaseData();

            if (!string.IsNullOrEmpty(stringifiedData))
            {
                var decryptedData = TryDecryptStringData(stringifiedData);
                return TryDeserializeStringData(stringifiedData);
            }

            return new Dictionary<string, string>;
        }

        private static string TryGetDatabaseData()
        {
            var conf = PasmenConfiguration.Instance;

            try
            {
                return ReadProposedDatabase(conf);
            }
            catch (PasmenDatabaseMissingException missingEx)
            {
                UiHelper.WriteError(missingEx.Message);
                conf.DbFileName = UiHelper.PromptDatabaseName();

                File.Create(conf.BaseDirectory + conf.DbFileName + PasmenConfiguration.Pasmen_FILE_EXTENSION);
                return null;
            }
            catch (PasmenDatabaseException ex)
            {
                UiHelper.WriteError($"Error: {ex.Message}");
                throw;
            }
        }

        private static string ReadProposedDatabase(PasmenConfiguration configuration)
        {
            configuration.DbFileName = PasmenFileReader.PromptDatabaseName();
            return PasmenFileReader.ReadFile(configuration.BaseDirectory + configuration.DbFileName);
        }

        private static string TryDecryptStringData(string stringifiedData)
        {
            try
            {
                return PasmenAbstractFactory.Instance.GetEncryptionHandler().Decrypt(stringifiedData);
            }
            catch (Exception ex)
            {
                UiHelper.WriteError($"DB corrupted. DB decoding error: {ex.Message}");
            }

            return stringifiedData;
        }

        private static Dictionary<string, string> TryDeserializeStringData(string stringifiedData)
        {
            try
            {
                var passwords = PasmenAbstractFactory.Instance.GetDataSource().DeserializeData(stringifiedData);
                return passwords;
            }
            catch (Exception ex)
            {
                UiHelper.WriteError($"DB corrupted. DB deserialization error: {ex.Message}");
                throw;
            }
        }

        private static void HandleAction(PasmenActionType action, int index, Dictionary<string, string> passwords)
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

                case PasmenActionType.Save:
                    {
                        return;
                    }

                case PasmenActionType.Load:
                    {
                        ResolvePasswordEntries();
                        return;
                    }
            }
        }
    }
}
