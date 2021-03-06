﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        private readonly List<Action> _options;
        private readonly IParser<IEnumerable<string>, BinaryNode> _parser;
        private readonly ITraverser _traverser;

        public Program(IParser<IEnumerable<string>, BinaryNode> parser, ITraverser traverser)
        {
            _options = new List<Action>
            {
                TraverseDemoInput,
                TraverseFile
            };

            _parser = parser;
            _traverser = traverser;
        }

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var program = host.Services.GetRequiredService<Program>();
            
            program.ListOptions();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureServices(services =>
            {
                Bootstrapper.Bootstrap(services);

                services.AddSingleton<Program>();
            });
        }

        private void ListOptions()
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

        private void TraverseDemoInput()
        {
            const string path = "Files/pyramid.txt";

            ParseFile(path);
        }

        private void TraverseFile()
        {
            var path = ConsoleHelper.GetFile("Input file");

            ParseFile(path);
        }

        private void ParseFile(string path)
        {
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
