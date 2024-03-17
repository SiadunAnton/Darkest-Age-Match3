using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class VirtualFile
{
    private readonly string _path;

    public VirtualFile(string path)
    {
        _path = path;
    }

    public object Read()
    {
        using FileStream file = File.Open(_path, FileMode.Open);
        {
            return new BinaryFormatter().Deserialize(file);
        }
    }

    public bool Exists()
    {
        return File.Exists(_path);
    }

    public void Save(object data)
    {
        using FileStream file = File.Create(_path);
        {
            new BinaryFormatter().Serialize(file, data);
        }
    }

    public void Delete()
    {
        if (File.Exists(_path))
        {
            File.Delete(_path);
        }
    }
}
