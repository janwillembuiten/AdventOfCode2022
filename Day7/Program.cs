namespace Day7
{
    public class DirectoryItem
    {
        public string Name { get; set; }

        public DirectoryItem(string name, int size, DirectoryItem? parent)
        {
            Name = name;
            Size = size;
            Parent = parent;
        }

        public int Size { get; set; }

        public DirectoryItem? Parent { get; set; }

        public List<DirectoryItem> Items { get; set; } = new();

        public bool IsDirectory => Items.Any();

        public int TotalSize => Items.Sum(i => i.TotalSize) + Size;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"C:\Dev\AdventOfCode2022\Day7\input.txt");
            
            DirectoryItem root = new DirectoryItem("/", 0, null);
            DirectoryItem? current = null;

            for (var i=0; i < lines.Length; i++)
            {
                var line = lines[i];

                if(line.StartsWith("$"))
                {
                    // command
                    var cmd = line.Substring(2);
                    if(cmd.StartsWith("cd"))
                    {
                        var dirName = cmd.Substring(3);

                        if(dirName == "/")
                        {                            
                            current = root;
                        }
                        else if(dirName == "..")
                        {
                            current = current?.Parent;
                        }
                        else
                        {
                            current = current?.Items.FirstOrDefault(i => i.Name == dirName);
                        }    
                    }
                    //else if(cmd.StartsWith("ls"))
                    //{
                    //}
                }
                else if(line.StartsWith("dir"))
                {
                    var dirName = line.Substring(4);
                    current?.Items.Add(new DirectoryItem(dirName, 0, current));
                }
                else
                {
                    var fileSize = int.Parse(line.Split(" ")[0]);
                    var fileName = line.Split(" ")[1];

                    current?.Items.Add(new DirectoryItem(fileName, fileSize, current));
                }
            }

            // Part 1:
            var dirs = FindDirectoriesWithMaxSize(root, 100000);
            Console.WriteLine($"Total size of files: {dirs.Sum(d => d.TotalSize)}");


            // Part 2:
            var totalSpace = 70000000;
            var spaceNeeded = 30000000;
            var currentSpace = totalSpace - root.TotalSize;

            while(currentSpace < spaceNeeded)
            {
                //find smalles dir to remove
                var remaining = spaceNeeded - currentSpace;
                var possibleDirsToRemove = FindDirectoriesWithMinSize(root, remaining).OrderBy(d => d.TotalSize);

                var dirToRemove = possibleDirsToRemove.FirstOrDefault();

                if(dirToRemove != null)
                {
                    currentSpace += dirToRemove.TotalSize;
                    Console.WriteLine($"Removing dir {dirToRemove.Name} with size {dirToRemove.TotalSize}");

                }
            }
        }

        private static IEnumerable<DirectoryItem> FindDirectoriesWithMaxSize(DirectoryItem root, int maxSize)
        {
            var dirs = new List<DirectoryItem>();

            foreach(var dir in root.Items.Where(i => i.IsDirectory))
            {
                if(dir.TotalSize <= maxSize)
                {
                    dirs.Add(dir);
                }

                dirs.AddRange(FindDirectoriesWithMaxSize(dir, maxSize));
            }

            return dirs;
        }

        private static IEnumerable<DirectoryItem> FindDirectoriesWithMinSize(DirectoryItem root, int minSize)
        {
            var dirs = new List<DirectoryItem>();

            foreach (var dir in root.Items.Where(i => i.IsDirectory))
            {
                if (dir.TotalSize >= minSize)
                {
                    dirs.Add(dir);
                }

                dirs.AddRange(FindDirectoriesWithMinSize(dir, minSize));
            }

            return dirs;
        }
    }
}