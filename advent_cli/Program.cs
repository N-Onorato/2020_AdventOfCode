using System;
using System.CommandLine;
using System.CommandLine.Invocation;
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
            test_solution.Handler = CommandHandler.Create<string>(Test_Handler);
            root.AddCommand(test_solution);

            root.Invoke(args);
        }

        static void Test_Handler(string message) {
            TestSolution.run(message);
        }
    }

}
