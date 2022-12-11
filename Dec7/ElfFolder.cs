using System.Diagnostics.CodeAnalysis;

namespace Dec7;

public class ElfFolder
{
    public List<ElfFile> Files;
    public List<ElfFolder> SubFolders;
    public ElfFolder Parent;
    public string Name { get;private set; }
    public ElfFolder(string name)
    {
        Name = name;
        Files = new List<ElfFile>();
        SubFolders = new List<ElfFolder>();
        Parent = null;
    }

    public ElfFolder(ElfFolder parent, string name)
    {
        Files = new List<ElfFile>();
        SubFolders = new List<ElfFolder>();
        Parent = parent;
        Name = name;
    }
    
    public int Size => CalculateSize();

    private int CalculateSize()
    {
        int size = 0;

        foreach (var elfFile in Files)
        {
            size += elfFile.Size;
        }

        foreach (var subFolder in SubFolders)
        {
            size += subFolder.Size;
        }
        
        return size;
    }

    public override string ToString()
    {
        return $"{Name} - {Size}";
    }
}