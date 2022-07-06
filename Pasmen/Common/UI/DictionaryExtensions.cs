using System;
using System.Collections.Generic;
using System.Linq;

namespace Pasmen
{
    public static class DictionaryExtensions
    {
        public static void PrintPasswords(this Dictionary<string, string> passwords)
        {
            Console.Clear();

            if (passwords.Count == 0)
            {
                Console.WriteLine("No passwords stored in DB yet");
                return;
            }

            Console.WriteLine($"Total passwords stored: {passwords.Count}");
            Console.WriteLine();

            Console.WriteLine("Passwords:");
            for (int i = 0; i < passwords.Count; i++)
            {
                Console.WriteLine($"[{i + 1}]. {passwords.Keys.ElementAt(i)}");
            }
        }

        public static void PrintPasswordEntry(this Dictionary<string, string> passwords, int index)
        {
            Console.Clear();
            if (index > passwords.Count)
                throw new ArgumentException($"Password with index {index} not found");

            var element = passwords.ElementAt(index);
            Console.WriteLine($"Password {element.Key}, value: '{element.Value}'");
            Console.WriteLine();
        }

        public static void AddPassword(this Dictionary<string, string> passwords)
        {
            Console.Clear();
            Console.WriteLine("Enter name of password: ");
            var key = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter value of password: ");
            var value = Console.ReadLine();

            passwords.Add(key, value);
        }

        public static void EditPasswordValue(this Dictionary<string, string> passwords, int index)
        {
            var element = passwords.ElementAt(index);

            Console.Clear();
            Console.WriteLine($"Enter new value for {element.Key}");

            passwords.Remove(element.Key);
            passwords.Add(element.Key, Console.ReadLine());
        }

        public static void RemovePassword(this Dictionary<string, string> passwords, int index)
        {
            var element = passwords.ElementAt(index);
            Console.WriteLine($"Are you sure to remove entry {index}?");
            passwords.Remove(element.Key);
        }
    }
}
