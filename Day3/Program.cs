namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var lines = File.ReadAllLines(@"C:\Dev\AdventOfCode2022\Day3\input.txt");

            PartTwo(lines);
        }

        private static void PartOne(string[] lines)
        {
            int total = 0;
            foreach(var sack in lines)
            {
                int lineTotal = 0;
                var compartmentOne = sack.Substring(0, sack.Length / 2).ToCharArray();
                var compartmentTwo = sack.Substring(sack.Length / 2).ToCharArray();

                var duplicateItems = compartmentOne.Intersect(compartmentTwo);

                foreach(Char duplicateItem in duplicateItems)
                {
                    var value = ((int)duplicateItem <= 90) ? (int)duplicateItem - 38 : (int)duplicateItem - 96;
                    lineTotal += value;
                    
                }

                total += lineTotal;
            }

            Console.WriteLine($"Total: {total}");
        }

        private static void PartTwo(string[] lines)
        {
            int total = 0;
            for (int i = 0; i < lines.Length; i+=3)
            {
                var sack1 = lines[i].ToCharArray();
                var sack2 = lines[i + 1].ToCharArray();
                var sack3 = lines[i + 2].ToCharArray();

                var lineTotal = 0;

                var duplicateItems = sack1.Intersect(sack2).Intersect(sack3);

                foreach (Char duplicateItem in duplicateItems)
                {
                    var value = ((int)duplicateItem <= 90) ? (int)duplicateItem - 38 : (int)duplicateItem - 96;
                    lineTotal += value;

                }

                total += lineTotal;
            }

            Console.WriteLine($"Total: {total}");
        }
    }
}