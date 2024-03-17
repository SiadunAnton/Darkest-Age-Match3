using UnityEngine;

public class Scoring : MonoBehaviour
{
    [SerializeField] private Points _points;
    [SerializeField] private int _fine = 1;
    private PointsSaver _pointsSaver;

    private void Awake()
    {
        _pointsSaver = new BinaryPointsSaver();
        _points = _pointsSaver.Load();
    }

    private void OnDestroy()
    {
        _pointsSaver.Save(_points);
    }

    public void Add(PointType pointType, int value)
    {
        string typeName = pointType.ToString();
        switch(typeName)
        {
            case "Red":
                _points.Red += value;
                break;
            case "Blue":
                _points.Blue += value;
                break;
            case "White":
                _points.White += value;
                break;
            case "Green":
                _points.Green += value;
                break;
        }
    }

    public void Fine()
    {
        _points.Red -= _fine;
        _points.Blue -= _fine;
        _points.White -= _fine;
        _points.Green -= _fine;
    }
}
