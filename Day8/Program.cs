namespace Day8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Part1(args);
            Part2(args);
        }
        
        static void Part1(string[] args)
        {
            var lines = File.ReadAllLines(@"C:\Dev\AdventOfCode2022\Day8\input.txt");

            var rows = new List<List<int>>();

            var visibleTrees = 0;

            for(var y = 0; y < lines.Length; y++)
            {
                var row = lines[y];
                var rowItems = row.Select(r => int.Parse(r.ToString())).ToArray();

                for (var x = 0; x < rowItems.Length; x++)
                {
                    var height = rowItems[x];

                    // check if visible
                    if(y == 0 || y == lines.Length -1 || x == 0 || x == rowItems.Length -1)
                    {
                        // visible because of edge
                        visibleTrees++;
                    }
                    else
                    {
                        // check current height against all other on x axis:
                        var left = rowItems.Take(x);
                        var right = rowItems.Skip(x + 1);
                        
                        if(left.Max() < height || right.Max() < height)
                        {
                            visibleTrees++;
                        }
                        else
                        {
                            // check on the y axis
                            var columnItems = new List<int>();
                            for(var i=0; i < lines.Length; i++)
                            {
                                var c = int.Parse(lines[i].Skip(x).Take(1).First().ToString());
                                columnItems.Add(c);
                            }

                            var top = columnItems.Take(y);
                            var bottom = columnItems.Skip(y + 1);

                            if (top.Max() < height || bottom.Max() < height)
                            {
                                visibleTrees++;
                            }

                        }
                        
                    }
                }
                
            }

            Console.WriteLine($"Visible trees: {visibleTrees}");
        }

        static void Part2(string[] args)
        {
            var lines = File.ReadAllLines(@"C:\Dev\AdventOfCode2022\Day8\input.txt");
            var rows = new List<List<int>>();
            var highestScenicScore = 0;

            for (var y = 0; y < lines.Length; y++)
            {
                var row = lines[y];
                var rowItems = row.Select(r => int.Parse(r.ToString())).ToArray();

                for (var x = 0; x < rowItems.Length; x++)
                {
                    if (y == 0 || y == lines.Length - 1 || x == 0 || x == rowItems.Length - 1)
                    {                        
                        continue;
                    }

                    var height = rowItems[x];

                    var columnItems = new List<int>();
                    for (var i = 0; i < lines.Length; i++)
                    {
                        var c = int.Parse(lines[i].Skip(x).Take(1).First().ToString());
                        columnItems.Add(c);
                    }

                    var left = rowItems.Take(x);
                    var right = rowItems.Skip(x + 1);
                    var top = columnItems.Take(y);
                    var bottom = columnItems.Skip(y + 1);                  

                    var leftViewingDistance = left.Reverse().ToArray().FindScenicScore(height); // Note, Reverse left to have the correct order!
                    var rightViewingDistance = right.ToArray().FindScenicScore(height);
                    var topViewingDistance = top.Reverse().ToArray().FindScenicScore(height); // Note, Reverse the top to have the correct order!
                    var bottomViewingDistance = bottom.ToArray().FindScenicScore(height);

                    var scenicScore = leftViewingDistance * rightViewingDistance * topViewingDistance * bottomViewingDistance;

                    highestScenicScore = Math.Max(highestScenicScore, scenicScore);
                }
            }

            Console.WriteLine($"highestScenicScore: {highestScenicScore}");

        }        
    }


    public static class EnumerableExtensions
    {
        public static int FindScenicScore(this int[] values, int val)
        {
            var score = 0;
            for (var i = 0; i < values.Length; i++)
            {
                score++;

                if (values[i] >= val)
                {
                    break;
                }
            }
            return score;
        }
    }
}