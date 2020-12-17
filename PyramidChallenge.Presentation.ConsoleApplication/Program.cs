using Microsoft.Extensions.DependencyInjection;
using PyramidChallenge.Bootstrapping;
using PyramidChallenge.Domain.Acquaintances;
using PyramidChallenge.Domain.Extensions;
using PyramidChallenge.Domain.Models.Node;
using PyramidChallenge.Presentation.ConsoleApplication.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PyramidChallenge.Presentation.ConsoleApplication
{
    public class Program
    {
        private static IServiceProvider _serviceProvider;

        private static readonly List<Action> _options = new List<Action>
        {
            TraverseDemoInput,
            TraverseFile
        };

        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            Bootstrapper.Bootstrap(services);

            _serviceProvider = services.BuildServiceProvider();

            ListOptions();
        }

        private static void ListOptions()
        {
            Console.WriteLine("Choose option to run, or enter exit to exit program.");

            foreach (var (i, action) in _options.AsIndexable())
                Console.WriteLine($"{i} - {action.Method.Name}");

            var input = Console.ReadLine().Trim();

            if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                Environment.Exit(0);

            if (int.TryParse(input, out var choice))
            {
                var action = _options.ElementAtOrDefault(choice);

                if (action != null)
                {
                    action.Invoke();
                }
            }

            ListOptions();
        }

        private static void TraverseDemoInput()
        {
            const string path = "Files/pyramid.txt";

            ParseFile(path);
        }

        private static void TraverseFile()
        {
            var path = ConsoleHelper.GetFile("Input file");

            ParseFile(path);
        }

        private static void ParseFile(string path)
        {
            var _parser = _serviceProvider.GetRequiredService<IParser<IEnumerable<string>, BinaryNode>>();
            var _traverser = _serviceProvider.GetRequiredService<ITraverser>();

            Console.WriteLine("Input:");

            var lines = File.ReadLines(path);

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

            var pyramid = _parser.Parse(lines);
            var traverseResult = _traverser.Traverse(pyramid);

            var pathAsString = string.Join(", ", traverseResult.Route);

            Console.WriteLine($"Max sum: {traverseResult.Distance}");
            Console.WriteLine($"Path: {pathAsString}");
        }
    }
}
