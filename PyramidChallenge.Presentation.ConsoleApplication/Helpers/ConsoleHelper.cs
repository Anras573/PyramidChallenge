using System;
using System.IO;

namespace PyramidChallenge.Presentation.ConsoleApplication.Helpers
{
    public static class ConsoleHelper
    {
        public static string GetFile(string name)
        {
            Console.WriteLine($"Enter path for {name}:");

            string path = string.Empty;

            while (string.IsNullOrWhiteSpace(path))
            {
                path = Console.ReadLine();

                if (!File.Exists(path))
                {
                    Console.WriteLine($"{path} does not exitst! Please try again:");
                    path = string.Empty;
                }
            }

            return path;
        }
    }
}
