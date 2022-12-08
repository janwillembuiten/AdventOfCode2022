namespace Day6
{
    internal class Program
    {
        //const int markerLength = 4;
        const int markerLength = 14;

        static void Main(string[] args)
        {
            // File.ReadAllLines(@"C:\Dev\AdventOfCode2022\Day6\input.txt");

            var inputBuffer = File.ReadAllText(@"C:\Dev\AdventOfCode2022\Day6\input.txt");

            for(var i = 0; i < inputBuffer.Length; i++)
            {
                if(i >= markerLength)
                {
                    var lastChars = inputBuffer.Substring(i - markerLength, markerLength);
                    if(isMarker(lastChars))
                    {
                        Console.WriteLine($"The first marker is after character: {i}");
                        break;
                    }                    
                }
            }
        }

        static bool isMarker(string substream)
        {
            for (var j = 0; j < substream.Length; j++)
            {
                for (var k = 0; k < substream.Length; k++)
                {
                    if (j != k && substream[j] == substream[k])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}