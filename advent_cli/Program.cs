using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using advent_solutions;

namespace advent_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new RootCommand("CLI for running Advent of Code 2020 solutions.");
            
            var test_solution = new Command("test_solution", "A simple test solution that prints the message passed to it.");
            var message_argument = new Argument<string>("message", "message to print.");
            test_solution.Add(message_argument);
            test_solution.Handler = CommandHandler.Create<string>(advent_solutions.TestSolution.run);
            root.AddCommand(test_solution);

            var solution1 = new Command("Day1", "Find the product of two numbers in a list that sum to a value.");
            solution1.AddArgument(new Argument<FileInfo>("input_file", "A newline separated list of values to search."));
            solution1.AddArgument(new Argument<int>("target_sumd", "The value the two numbers should sum to."));
            solution1.AddOption(new Option<bool>("search-all", "Continue searching for values after one is found."));
            solution1.Handler = CommandHandler.Create<FileInfo, int, bool>(Solution1.run);
            root.AddCommand(solution1);

            root.Invoke(args);
        }
    }

}
