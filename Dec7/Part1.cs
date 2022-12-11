namespace Dec7;

public class Part1
{
    public static void Calculate()
    {
        Console.WriteLine("Part1");

        var lines = File.ReadLines("Input.txt").ToList();

        var folderStructure = BuildFolderStructure(lines);
        var rootFolder = folderStructure.Item1;
        var folderList = folderStructure.Item2;

        int sum = folderList.Where(x => x.Size <= 100000).Sum(x => x.Size);
    
        
        Console.WriteLine("Result");
        Console.WriteLine(sum);
    }

    public static (ElfFolder, List<ElfFolder>) BuildFolderStructure(List<string> lines)
    {
        var folders = new List<ElfFolder>();
        var rootFolder = new ElfFolder("/");
        var currentFolder = rootFolder;
        folders.Add(rootFolder);
        foreach (var line in lines)
        {
            var cmd = line.Split(" ");
            
            if (cmd[0] == "$")
            {
                switch (cmd[1])
                {
                    case "ls":
                        break;
                    case "cd":
                        switch (cmd[2])
                        {
                            case "..":
                                currentFolder = currentFolder.Parent;
                            break;
                            case "/":
                                currentFolder = rootFolder;
                            break;
                            default:
                                currentFolder = new ElfFolder(currentFolder, cmd[2]);
                                //add subfolder
                                currentFolder.Parent.SubFolders.Add(currentFolder);
                                folders.Add(currentFolder);
                            break;
                        }
                        break;
                    
                    default:
                    break;

                    
                    
                }

                continue;
            }
            int value;
            if (Int32.TryParse(cmd[0], out value))
            {
                currentFolder.Files.Add(new ElfFile(cmd[1],value));
            }
        }

        return (rootFolder, folders);
    }
}