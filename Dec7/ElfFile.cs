namespace Dec7;

public class ElfFile
{
    public int Size { get; set; }
    public string Name { get; set; }

    public ElfFile(string name, int size)
    {
        Name = name;
        Size = size;
    }
    public override string ToString()
    {
        return $"{Name} - {Size}";
    }
}