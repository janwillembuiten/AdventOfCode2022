using System.Collections;

namespace Day5
{
    internal class Program
    {
        const int numberOfStacks = 9;

        static void Main(string[] args)
        {
            var stacks = new Dictionary<int, Stack<string>>();


            for (var j = 0; j < numberOfStacks; j++)
            {
                stacks[j] = new Stack<string>();
            }

            var lines = File.ReadAllLines(@"C:\Dev\AdventOfCode2022\Day5\input.txt");

            var startLine = 0;

            // loop untill numbers line and identify the bottom of the stack
            for (var i = 0; i < lines.Length; i++)
            {
                var crates = lines[i];

                if (crates.Contains("1"))
                {
                    startLine = i - 1;
                    break;
                }
            }

            // Process the crates from bottom to top
            for (var i = startLine; i >= 0; i--)
            {
                var crates = lines[i];

                if (crates.Contains("["))
                {
                    for (var j = 0; j < numberOfStacks; j++)
                    {
                        var stackContent = crates.Substring(j * 4, 3).Trim('[', ']', ' ');
                        if (!string.IsNullOrWhiteSpace(stackContent))
                        {
                            stacks[j].Push(stackContent);
                        }
                    }
                }
            }

            // process the instructions now
            // e.g. move 3 from 9 to 7
            for (var i = startLine + 3; i < lines.Length; i++)
            {
                var instructionLine = lines[i];
                var parts = instructionLine.Split(" ");
                
                var amountOfCrates = int.Parse(parts[1]);
                var from = int.Parse(parts[3]) - 1;
                var to = int.Parse(parts[5]) - 1;

                var tempStack = new Stack<string>();

                for(var d=0; d < amountOfCrates; d++)
                {
                    var crate = stacks[from].Pop();

                    // Part 1:
                    stacks[to].Push(crate);

                    // Part 2:
                    tempStack.Push(crate);
                }

                // Part 2:
                for (var d = 0; d < amountOfCrates; d++)
                {
                    stacks[to].Push(tempStack.Pop());
                }
                    
            }

            var output = "";
            for (var j = 0; j < numberOfStacks; j++)
            {
                output += stacks[j].Pop();
            }

            Console.WriteLine($"output: {output}");
        }
    }
}