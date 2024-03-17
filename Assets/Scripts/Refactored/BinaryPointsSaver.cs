using UnityEngine;

public class BinaryPointsSaver : PointsSaver
{
    private readonly VirtualFile _file;
    
    public BinaryPointsSaver()
    {
        _file = new VirtualFile(Application.persistentDataPath + "/Save.dat");
    }

    public override Points Load()
    {
        return _file.Exists() ?  (Points)_file.Read() : new Points();
    }

    public override void Save(Points points)
    {
        _file.Save( points);
    }

    public override void Clear()
    {
        _file.Delete();
    }
}
