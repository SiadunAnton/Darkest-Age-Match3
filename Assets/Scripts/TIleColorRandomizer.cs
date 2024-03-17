using UnityEngine;

public class TIleColorRandomizer : MonoBehaviour
{
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void SetRandomColor()
    {
        _renderer.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        var value = Random.Range(0, 7);
        switch(value)
        {
            case 0:
                return Color.blue;
            case 1:
                return Color.cyan;
            case 2:
                return Color.magenta;
            case 3:
                return Color.white;
            case 4:
                return Color.green;
            case 5:
                return Color.yellow;
            case 6:
                return Color.red;
        }
        return Color.black;                
    }
}
