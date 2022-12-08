namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            var lines = File.ReadAllLines(@"C:\Dev\AdventOfCode2022\Day4\input.txt");

            var overlappingAssignmentsCount = 0;

            for(var i=0; i < lines.Length; i++)
            {
                var assignments = lines[i].Split(",");
                if(assignments.Length == 2)
                {
                    var assA = assignments[0];
                    var assB = assignments[1];

                    var rangeA = assA.Split("-");
                    var rangeB = assB.Split("-");

                    var rangeAStart = int.Parse(rangeA[0]);
                    var rangeAEnd = int.Parse(rangeA[1]);

                    var rangeBStart = int.Parse(rangeB[0]);
                    var rangeBEnd = int.Parse(rangeB[1]);

                    var rangeALength = (rangeAEnd - rangeAStart) + 1;
                    var rangeBLength = (rangeBEnd - rangeBStart) + 1;

                    var a = Enumerable.Range(rangeAStart, rangeALength);
                    var b = Enumerable.Range(rangeBStart, rangeBLength);

                    var overlapping = a.Intersect(b).ToArray();

                    if(overlapping.Length > 0 ) //Math.Min(rangeALength, rangeBLength))
                    {
                        overlappingAssignmentsCount++;
                    }
                }
            }

            Console.WriteLine($"overlapping ranges: {overlappingAssignmentsCount}");
        }
    }
}