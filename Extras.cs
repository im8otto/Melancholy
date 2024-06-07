﻿using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Melancholy
{
    public static class Extras
    {
        public static Classes.Settings Settings = new();
        public static bool AddNonInventoryItems { get; set; } = false;
        public static bool AddRetiredOfferings { get; set; } = false;
        public static bool AddEventItems { get; set; } = true;
        public static bool AddBannersBadges { get; set; } = true;

        private static int Padding(string output) => (Console.WindowWidth / 2) - (output.Length / 2);
        private static void CenterText(string text) => Console.WriteLine("{0}{1}", new string(' ', Padding(text)), text);

        public static void Header()
        {
            CenterText("\"Two facts: boys make better girls and furries are superior to all\" - Essence");
            CenterText("MarketUpdater developed by Essence_BHVR (discord: bhvr)");
            Console.WriteLine(Environment.NewLine);
        }

        public static async Task MakeFile<T>(List<T> list, string fileName)
        {
            var json = JsonConvert.SerializeObject(list, Formatting.Indented);
            await using (var writer = new StreamWriter($"IDs/{fileName}"))
            {
                await writer.WriteAsync(json);
            }

            Console.WriteLine($"{fileName} generated");
        }

        /*public static string NormalizeInput(string input)
        {
            return input.Normalize(NormalizationForm.FormC);
        }

        public static bool ValidateVersionFormat(string version)
        {
            string pattern = @"^\d+\.\d+\.\d+$";
            return Regex.IsMatch(version, pattern);
        }
        
        public static string ConvertToAscii(string input)
        {
            Encoding ascii = Encoding.ASCII;
            Encoding utf8 = Encoding.UTF8;
            byte[] utf8Bytes = utf8.GetBytes(input);
            byte[] asciiBytes = Encoding.Convert(utf8, ascii, utf8Bytes);
            return ascii.GetString(asciiBytes);
        }*/

        public static string PromptInput(string message)
        {
            string input;

            do
            {
                Console.Write(message);
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));

            return input.Replace("\"", "");
        }

        public static string PromptOptionInput(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            return input;
        }

        public static int PromptIntInput(string message)
        {
            int parsedInt = 0;
            string input;

            do
            {
                input = PromptInput(message);
                if (!int.TryParse(input, out parsedInt))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (parsedInt == 0 & !int.TryParse(input, out parsedInt));

            return parsedInt;
        }
    }
}
