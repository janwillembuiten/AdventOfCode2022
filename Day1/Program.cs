namespace Day1
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var lines = await File.ReadAllLinesAsync(@"C:\Dev\AdventOfCode2022\Day1\input.txt");

            //Day1(lines);
            Day1Part2(lines);
        }


        public static void Day1(string[] lines)
        {
            int highestElfIndex = 1;
            int highestNumberOfCalories = 0;

            int currentNumberOfCalories = 0;
            int elveIndex = 0;

            for (var i = 0; i < lines.Length; i++)
            {
                if (int.TryParse(lines[i], out var calories))
                {
                    currentNumberOfCalories += calories;
                }
                else
                {
                    if (currentNumberOfCalories > highestNumberOfCalories)
                    {
                        highestNumberOfCalories = currentNumberOfCalories;
                        highestElfIndex = elveIndex;
                    }

                    elveIndex++;
                    currentNumberOfCalories = 0;
                }
            }


            Console.WriteLine(highestNumberOfCalories);
            Console.WriteLine($"The elve with the highest calories is: {highestElfIndex} (with {highestNumberOfCalories} calories)");
        }

        public static void Day1Part2(string[] lines)
        {
            var caloriesList = new List<int>();
            int currentNumberOfCalories = 0;
            int elveIndex = 0;

            for (var i = 0; i < lines.Length; i++)
            {
                if (int.TryParse(lines[i], out var calories))
                {
                    currentNumberOfCalories += calories;
                }
                else
                {
                    caloriesList.Add(currentNumberOfCalories);
                    elveIndex++;
                    currentNumberOfCalories = 0;
                }
            }

            var highest = caloriesList.OrderByDescending(c => c).Take(3);

            Console.WriteLine(highest.Sum());
        }
    }
}