namespace Day2
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var lines = await File.ReadAllLinesAsync(@"C:\Dev\AdventOfCode2022\Day2\input.txt");

            //PartOne(lines);
            PartTwo(lines);

        }

        private static void PartTwo(string[] lines)
        {
            var myTotalPoints = 0;


            foreach (var round in lines)
            {
                var plays = round.Split(" ");
                if (plays.Length == 2)
                {
                    var opponent = plays[0];
                    var outcome = plays[1];

                    var myPoints = 0;

                    string my;
                    if(outcome == "X")
                    {
                        // need to LOSE
                        my = opponent == "A" ? "C" : opponent == "B" ? "A" : "B";                        
                    }
                    else if(outcome == "Y")
                    {
                        // need a DRAW
                        my = opponent;
                        myPoints += 3;
                    }
                    else
                    {
                        // need a WIN
                        my = opponent == "A" ? "B" : opponent == "B" ? "C" : "A";
                        myPoints += 6;
                    }

                    var opponentPoints = GetPlayPoints(opponent);
                    myPoints += GetPlayPoints(my);

                    myTotalPoints += myPoints;
                }
            }

            Console.WriteLine($"Total of {myTotalPoints} points");
        }

        private static void PartOne(string[] lines)
        {
            var myTotalPoints = 0;

            foreach (var round in lines)
            {
                var plays = round.Split(" ");
                if (plays.Length == 2)
                {
                    var opponent = plays[0];
                    var my = plays[1];

                    var opponentPoints = GetPlayPoints(opponent);
                    var myPoints = GetPlayPoints(my);

                    if (myPoints == 1 && opponentPoints == 3 || myPoints == 3 && opponentPoints == 2 || myPoints == 2 && opponentPoints == 1)
                    {
                        myPoints += 6; // WIN
                    }
                    else if (myPoints == opponentPoints)
                    {
                        myPoints += 3; // DRAW
                    }
                    else
                    {
                        // LOSE
                    }

                    myTotalPoints += myPoints;
                }
            }

            Console.WriteLine($"Total of {myTotalPoints} points");
        }

        private static int GetPlayPoints(string source)
        {
            if (source == "A" || source == "X") return 1; // ROCK
            if (source == "B" || source == "Y") return 2; // Paper
            if (source == "C" || source == "Z") return 3; // Scissors
            return 0;
        }

        
    }
}